Imports System.Data.SQLite
Imports System.Text

Public Class CacheGPS




    Enum CacheType
        DB_SQLite
        JSON
        XML
        CSV
    End Enum

    Sub New(ByVal type As CacheType)


        Select Case type
            Case CacheType.DB_SQLite

                Try
                    Using con As New SQLiteConnection(My.Settings.DB接続文字列)
                        '接続をオープン
                        con.Open()
                        Using com = con.CreateCommand
                            Dim sql As New StringBuilder
                            sql.AppendLine("")
                            com.CommandText = "SELECT * FROM GPS_CACHE"

                            'INSERT操作を実行
                            'com.ExecuteNonQuery()
                            'データリーダーにデータ取得
                            Using dr = com.ExecuteReader
                                'データを全件出力
                                Do Until Not dr.Read
                                    Debug.Print(dr.Item("LAT").ToString)
                                    Debug.Print(dr.Item("LONG").ToString)
                                    Debug.Print(dr.Item("ADDRESS_L").ToString)
                                    Debug.Print(dr.Item("ADDRESS_M").ToString)
                                    Debug.Print(dr.Item("ADDRESS_S").ToString)
                                Loop

                            End Using
                        End Using
                    End Using
                Catch ex As Exception

                    MsgBox(ex.Message)

                End Try


            Case CacheType.JSON

            Case CacheType.CSV

            Case CacheType.XML
        End Select



    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="x">経度（60でなく10進数）</param>
    ''' <param name="y">緯度（60でなく10進数）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAddress(x As Double, y As Double) As String()


        ' x, y のキャッシュがあるか探す
        ' キャッシュあるなら、その結果を使う
        ' キャッシュないなら、WebAPIを使い住所を解決し、結果をキャッシュする

        Return New String() {}
    End Function


    ''' <summary>
    ''' 指定された緯度・経度のキャッシュを削除する
    ''' </summary>
    ''' <param name="x">削除するキャッシュの経度</param>
    ''' <param name="y">削除するキャッシュの緯度</param>
    ''' <returns>削除に成功すればTrue、失敗または指定のキャッシュが存在しない場合はFlase</returns>
    ''' <remarks></remarks>
    Public Function ClearCache(x As Double, y As Double) As Boolean

        Using con As New SQLiteConnection(My.Settings.DB接続文字列)
            '接続をオープン
            con.Open()
            Using com = con.CreateCommand

                'DBレコードを削除するSQLを作成
                Dim sql As New StringBuilder

                sql.AppendLine("")


                com.CommandText = "SELECT * FROM GPS_CACHE"

                'INSERT操作を実行
                'com.ExecuteNonQuery()
                'データリーダーにデータ取得
                Using dr = com.ExecuteReader
                    'データを全件出力
                    Do Until Not dr.Read
                        Debug.Print(dr.Item("LAT").ToString)
                        Debug.Print(dr.Item("LONG").ToString)
                        Debug.Print(dr.Item("ADDRESS_L").ToString)
                        Debug.Print(dr.Item("ADDRESS_M").ToString)
                        Debug.Print(dr.Item("ADDRESS_S").ToString)
                    Loop

                End Using
            End Using
        End Using

        Return False
    End Function




    Private Function SQLite_Nonquery() As Boolean
        Return False
    End Function

End Class
