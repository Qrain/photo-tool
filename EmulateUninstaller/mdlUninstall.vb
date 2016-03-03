Imports Microsoft.Win32

Module mdlUninstall

    Public Function sysIsInstalled(ByVal vstrDisplayName As String) As Boolean
        ' インストール済プログラム一覧を取得
        Dim installed As Dictionary(Of String, RegistryKey) = GetInstalledPrograms(Environment.Is64BitOperatingSystem)
        '  DisplayName（表示名）だけを抽出してパラメータが含まれているか判定
        Return installed.Values.Select(Function(x) CStr(x.GetValue("DisplayName", ""))).Contains(vstrDisplayName)
    End Function

    Public Sub sysUninstall(ByVal strDisplayName As String)
        ' インストール済プログラム一覧を取得
        Dim installed As Dictionary(Of String, RegistryKey) = GetInstalledPrograms(Environment.Is64BitOperatingSystem)
        ' DisplayName（表示名）がパラメータと一致するものを抽出
        Dim targets = installed.Where(Function(x) CStr(x.Value.GetValue("DisplayName", "")) = strDisplayName)
        ' 安全な形式のアンインストール文字列に変換する
        Dim uninstStr = targets.Select(Function(x) GetSafeUninstallString(x.Key, x.Value))
        ' 同じ表示名の全てのアンインストーラーを起動する
        For Each cmd In uninstStr
            'Processオブジェクトを作成
            Dim p As New System.Diagnostics.Process()
            'ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
            p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec")
            '出力を読み取れるようにする
            p.StartInfo.UseShellExecute = False
            p.StartInfo.RedirectStandardOutput = True
            'p.StartInfo.RedirectStandardInput = False
            'ウィンドウを表示しないようにする
            p.StartInfo.CreateNoWindow = True
            'コマンドラインを指定（"/c"は実行後閉じるために必要）
            p.StartInfo.Arguments = "/c " & cmd
            '起動
            p.Start()
            'プロセス終了まで待機する
            'WaitForExitはReadToEndの後である必要がある
            '(親プロセス、子プロセスでブロック防止のため)
            p.WaitForExit()
            p.Close()
        Next
    End Sub

    ''' <summary>
    ''' インストール済のプログラム及びそのレジストリ情報の一覧を取得します
    ''' </summary>
    ''' <param name="x64">OSが64bitならばTrue</param>
    ''' <returns></returns>
    Function GetInstalledPrograms(ByVal x64 As Boolean) As Dictionary(Of String, RegistryKey)
        ' ※ルートキー "HKEY_LOCAL_MACHINE" は省略しなければならない
        Dim rootKey As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"
        Dim dic As New Dictionary(Of String, RegistryKey)
        '
        ' Win64bit の場合、32と64で分けてプログラム一覧を取得するので連結処理が必要
        If x64 Then
            ' 32bit版として再帰する
            For Each kv In GetInstalledPrograms(False)
                dic.Add(kv.Key, kv.Value)
            Next
            ' x64上のx86という特別なルートキーを設定する
            rootKey = "SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
        End If
        ' 読み取り専用でレジストリを取得します
        Dim regKey As RegistryKey = Registry.LocalMachine.OpenSubKey(rootKey)
        ' 更新プログラムの表示名にマッチする正規表現
        Dim regexWinUpdate As New System.Text.RegularExpressions.Regex("KB[0-9]{6}$")
        '
        For Each subKey In regKey.GetSubKeyNames
            ' 表示条件を設定していく
            ' サブキー名から更にレジストリを取得する
            Dim subreg = regKey.OpenSubKey(subKey)
            ' SystemComponent: 1 のPGはプログラムと機能には表示されない
            Dim isSystemComponent As Boolean = CInt(subreg.GetValue("SystemComponent", 0)) = 1
            ' Windows Installer（msi）によるインストールかどうか判定
            Dim isWinInstaller As Boolean = CInt(subreg.GetValue("WindowsInstaller", 0)) = 1
            ' アンインストーラーのパス等を持っているか判定
            Dim hasUninstallStirng = subreg.GetValue("UninstallString", "") <> ""
            ' Windows Update プログラムならTrue
            Dim isWinUpdate As Boolean =
                regexWinUpdate.Match(subKey).Success OrElse
                CStr(subreg.GetValue("ParentKeyName", "")) <> "" OrElse
                CStr(subreg.GetValue("ReleaseType", "")) = "Security Update" OrElse
                CStr(subreg.GetValue("ReleaseType", "")) = "Update Rollup" OrElse
                CStr(subreg.GetValue("ReleaseType", "")) = "Hotfix"
            ' ↓ 次の条件に当てはまるプログラムの場合に表示する ↓
            ' システムコンポーネントではないWindowsInstaller（*.msi）によるプログラム
            ' システムコンポーネントではなく更新プログラムでもないUninstallStringのあるプログラム
            If Not isSystemComponent AndAlso (isWinInstaller OrElse Not isWinUpdate AndAlso hasUninstallStirng) Then
                '万が一 x86とx64で SubKeyが重複してる場合はAddで例外発生するので上書き
                If dic.ContainsKey(subKey) Then
                    dic(subKey) = subreg
                Else
                    dic.Add(subKey, subreg)
                End If
            End If
        Next
        ' 結果を返却する
        Return dic
    End Function

    ''' <summary>
    '''  サブキーとレジストリーオブジェクトからUninstallStringを生成します
    ''' </summary>
    ''' <param name="key">レジストリ上のサブキー文字列</param>
    ''' <param name="reg">keyに関連付けられたレジストリキーオブジェクト</param>
    ''' <returns></returns>
    Function GetSafeUninstallString(ByVal key As String, ByVal reg As RegistryKey) As String
        Dim uninstallpath = CStr(reg.GetValue("UninstallString", ""))
        ' WindowsInstaller で UninstallString がない場合はサブキー名から作る
        If CInt(reg.GetValue("WindowsInstaller", 0)) = 1 AndAlso UninstallPath = "" Then
            ' /I インストールオプションで生成
            uninstallpath = "MSIEXEC.EXE /I" & key
        End If
        ' WindowsInstaller 以外のプログラムのアンインストールの場合
        If Not uninstallpath.ToUpper.StartsWith("MSIEXEC.EXE /") AndAlso
          (Not uninstallpath.StartsWith("""") OrElse Not uninstallpath.EndsWith("""")) Then
            ' 空白エラー防止の為 "" で囲う
            uninstallpath = """" & uninstallpath & """"
        End If
        Return uninstallpath
    End Function

End Module
