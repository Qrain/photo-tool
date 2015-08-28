Imports System.Data.SQLite
Imports System.Text
Imports System.Data.Common

Module SQLiteCommon

    ''' <summary>
    ''' 指定のSQLを実行します。
    ''' </summary>
    ''' <param name="sql">実行するSQL文</param>
    ''' <param name="isTransaction">トランザクション処理とする場合はTrueを指定</param>
    ''' <returns>SQLの実行に成功すればTrue, そうでなければ False</returns>
    ''' <remarks></remarks>
    Public Function SQLite_NonQuery(ByVal sql As String, Optional ByVal isTransaction As Boolean = False) As Boolean
        Using con As New SQLiteConnection(My.Settings.DB接続文字列)
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
        Using conn As New SQLiteConnection(My.Settings.DB接続文字列)
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


    Public Function SQLite_GetDataTable(ByVal sql As String) As DataTable

        Dim dtb As New DataTable

        Try
            'DB と DataTableオブジェクトを関連づけるアダプターを作成
            Using adt As New SQLiteDataAdapter(sql, My.Settings.DB接続文字列)
                adt.SelectCommand.CommandTimeout = 300
                adt.Fill(dtb)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error @ SQLite_GetDataTable", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dtb
    End Function



    ''' <summary>
    ''' 汎用的なテーブル取得メソッドです
    ''' </summary>
    ''' <typeparam name="A"></typeparam>
    ''' <param name="sql"></param>
    ''' <param name="con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function rab_GetDataTable(Of A As {New, DbDataAdapter}, C As {New, DbCommand})(ByVal sql As String, ByVal con As String) As DataTable

        Dim dtb As New DataTable

        Try
            'DB と DataTableオブジェクトを関連づけるアダプターを作成
            Using adp As New A
                adp.SelectCommand = New C
                adp.SelectCommand.Connection.ConnectionString = con
                adp.SelectCommand.CommandTimeout = 300
                adp.SelectCommand.CommandText = sql
                adp.Fill(dtb)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error @ DB_GetDataTable", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dtb

    End Function

End Module
