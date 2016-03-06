Public Class Entry

    Public Shared Sub Main()
        'MsgBox(sysIsInstalled("Microsoft SQL Server 2014 T-SQL Language Service"))
        'sysUninstall("ESET Endpoint Antivirus")
        'sysUninstall("GIMP 2.8.15")
        'sysUninstall("Microsoft SQL Server 2014 T-SQL Language Service")
        'Return
        '
        With New アンインストールツール
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class
