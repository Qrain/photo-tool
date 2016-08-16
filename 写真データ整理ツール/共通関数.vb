Imports System.Data.SQLite
Imports System.Text
Imports System.Data.Common
Imports System.Data.SqlClient

Module 共通関数

#Region "SQLiteデータベースに関するメソッドを定義"

    ''' <summary>
    ''' 指定のSQLを実行します。
    ''' </summary>
    ''' <param name="sql">実行するSQL文</param>
    ''' <param name="isTransaction">トランザクション処理とする場合はTrueを指定</param>
    ''' <returns>SQLの実行に成功すればTrue, そうでなければ False</returns>
    ''' <remarks></remarks>
    Public Function SQLite_NonQuery(ByVal sql As String, Optional ByVal isTransaction As Boolean = False) As Boolean
        Using con As New SQLiteConnection(My.Settings.SQLite接続文字列)
            Using com = con.CreateCommand
                Try
                    'DB接続を開いて指定のSQLを実行します
                    con.Open()

                    'トランザクションを開始
                    'SQLite のトランザクション処理: http://kurokawh.blogspot.jp/2013/11/sqlite-sqlite.html
                    If isTransaction Then
                        com.Transaction = con.BeginTransaction
                    End If

                    'SQL文を設定
                    com.CommandText = sql
                    'クエリを実行
                    com.ExecuteNonQuery()

                    'コミットを実行
                    If isTransaction Then
                        com.Transaction.Commit()
                    End If

                    Return True

                Catch ex As Exception

                    '途中で失敗した場合は変更をロールバック
                    If isTransaction Then
                        com.Transaction.Rollback()
                    End If

                    MessageBox.Show(ex.Message, "Error @ DB_NonQuery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Using
        End Using
    End Function

    ''' <summary>
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="sql"></param>
    ''' <returns>型パラメータTに変換された単一値、エラーが発生した場合はNothing</returns>
    ''' <remarks></remarks>
    Public Function SQLite_GetValue(Of T)(ByVal sql As String) As T
        Using conn As New SQLiteConnection(My.Settings.SQLite接続文字列)
            Using comm = conn.CreateCommand
                Try
                    conn.Open()
                    comm.CommandText = sql
                    Return CType(comm.ExecuteScalar, T)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error @ DB_GetValue", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return Nothing
                End Try
            End Using
        End Using
    End Function

    ''' <summary>
    ''' 指定のSQLクエリを実行して、結果をDataTableで取得します。
    ''' </summary>
    ''' <param name="sql">実行するSQL文</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SQLite_GetDataTable(ByVal sql As String) As DataTable

        Dim dtb As New DataTable

        Try
            'DB と DataTableオブジェクトを関連づけるアダプターを作成
            Using adt As New SQLiteDataAdapter(sql, My.Settings.SQLite接続文字列)
                'TimeOut を設定 300ms とする
                adt.SelectCommand.CommandTimeout = 300
                adt.Fill(dtb)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error @ SQLite_GetDataTable", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dtb
    End Function


    Public Function SQLServer_GetDataTable(ByVal sql As String) As DataTable
        Return GetDataTable(New SqlDataAdapter, sql, My.Settings.SQLite接続文字列)
    End Function

    Private Function GetDataTable(ByVal adt As DbDataAdapter, ByVal sql As String, ByVal con As String) As DataTable
        Dim dtb As New DataTable

        Try
            Using adt
                adt.SelectCommand.Connection.ConnectionString = con
                adt.SelectCommand.CommandText = sql
                adt.SelectCommand.CommandTimeout = 300
                adt.Fill(dtb)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error @ GetDataTable", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dtb
    End Function

#End Region

#Region "拡張メソッドに関する定義"

    ''' <summary>
    ''' バイト配列を16進数文字列に変換します。
    ''' </summary>
    ''' <param name="bytes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Function extxHexString(ByVal bytes As Byte()) As String
        Dim str = ""
        For Each b In bytes
            str &= b.ToString("X2")
        Next
        Return str
    End Function



#End Region

End Module
