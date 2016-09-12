Imports System

Partial Public Class Test
    Inherits Page

    Private xForwerdedFor As String
    Private remoteAddr As String


    Private Sub Test_Init(sender As Object, e As EventArgs) Handles Me.Init
        xForwerdedFor = Request.ServerVariables.Item("HTTP_X_FORWARDED_FOR")
        remoteAddr = Request.ServerVariables.Item("REMOTE_ADDR")
        ' Null例外防止処理
        xForwerdedFor = If(xForwerdedFor Is Nothing, "", xForwerdedFor.Trim)
        remoteAddr = If(remoteAddr Is Nothing, "", remoteAddr.Trim)
    End Sub

    ''' <summary>
    ''' 全てのリクエストHTTPヘッダを一覧表示します。
    ''' </summary>
    Public Sub AllHeaders()
        Dim heads = Request.Headers

        Response.Write("<table>")
        For Each key As String In heads.AllKeys
            Response.Write("<tr><th>" & key & "</th><td>")
            For Each v In heads.GetValues(key)
                Response.Write("" & v & "<br>")
            Next
            Response.Write("</td></tr>")
        Next
        Response.Write("</table>")
    End Sub

    Public Sub OriginalGIP()
        'https://msdn.microsoft.com/ja-jp/library/cc338803.aspx
        If xForwerdedFor = "" Then
            Response.Write("取得できませんでした")
        Else
            Response.Write(xForwerdedFor)
        End If
    End Sub

    Public Sub ProxyGIP()
        If remoteAddr = "" Then
            Response.Write("取得できませんでした")
        Else
            Response.Write(remoteAddr)
        End If
    End Sub


    Public Sub Message()
        Dim msg As New StringBuilder

        If xForwerdedFor = "" Then
            msg.Append("このアクセスはプロキシ経由ではない可能性が高いです。<br>")
            msg.Append("アクセス元IPアドレス [" & remoteAddr & "] ")
        ElseIf Not IsIPv4(xForwerdedFor) Then
            msg.Append("X-FORWORDED-FORの情報がIPv4の形式ではありません<br>")
            msg.Append("アクセス元IPアドレス [" & remoteAddr & "] ")
        ElseIf IsPrivateAddress(xForwerdedFor) Then
            msg.Append("社内プロキシ経由のアクセスである可能性が高いです。<br>")
            msg.Append("アクセス元IPアドレス [" & xForwerdedFor & "]<br>")
            msg.Append("経由プロキシIPアドレス [" & remoteAddr & "]")
        Else
            msg.Append("アクセス元IPアドレス [" & xForwerdedFor & "]<br>")
            msg.Append("経由プロキシIPアドレス [" & remoteAddr & "]")
        End If

        Response.Write(msg.ToString)
    End Sub

    Private Function IsPrivateAddress(ByVal addr As String) As Boolean
        If Not IsIPv4(addr) Then
            Return False
        End If

        Dim addrs = addr.Split("."c).Select(Function(x) CByte(x))

        '「プライベートIPアドレス空間」
        '10.0.0.0 ~ 10.255.255.255      クラスA 	10.0.0.0/8
        '172.16.0.0 ~ 172.31.255.255    クラスB 	172.16.0.0/12
        '192.168.0.0 ~ 192.168.255.255  クラスC 	192.168.0.0/16
        If addrs(0) = 10 Then
            Return True
        ElseIf addrs(0) = 172 AndAlso addrs(1) >= 16 AndAlso addrs(1) <= 31 Then
            Return True
        ElseIf addrs(0) = 192 AndAlso addrs(1) = 168 Then
            Return True
        End If

        Return False
    End Function

    Private Function IsIPv4(ByVal addr As String) As Boolean
        Dim addrs = addr.Split("."c)

        ' xxx.xxx.xxx.xxx 形式の場合 Falseリターン
        If addrs.Count <> 4 Then
            Return False
        End If

        ' 各オクテットに数値変換できない要素が含まれていればFalse
        If addrs.Select(Function(x) IsNumeric(x)).Contains(False) Then
            Return False
        End If

        ' 各オクテットが0~255の範囲外ならばFalse
        For Each s In addrs
            Dim n = CInt(s)
            If n < 0 OrElse n > 255 Then
                Return False
            End If
        Next

        Return True
    End Function

End Class