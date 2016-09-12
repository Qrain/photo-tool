Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports SPWinFormControls


Namespace DB
    ''' <summary>
    ''' データベース関係の共通関数
    ''' </summary>
    Public Module DB
        ''' <summary>
        ''' 指定のSQLを実行します。
        ''' </summary>
        ''' <param name="constr">DB接続文字列</param>
        ''' <param name="sql">実行するSQL文</param>
        ''' <param name="isTransaction">トランザクション処理とする場合はTrueを指定</param>
        ''' <returns>SQLの実行に成功すればTrue, そうでなければ False</returns>
        ''' <remarks></remarks>
        Public Function ExecNonQuery(ByVal constr As String, ByVal sql As String, Optional ByVal isTransaction As Boolean = False) As Boolean
            Using con As New SqlConnection(constr)
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
                        '
                        Return True
                    Catch ex As Exception
                        '途中で失敗した場合は変更をロールバック
                        If isTransaction Then
                            Try
                                com.Transaction.Rollback()
                            Catch rbex As Exception
                                Message.MsgErr("RollBack Error @ DB_NonQuery", rbex.Message)
                            End Try
                        End If
                        Message.MsgErr("Error @ DB_NonQuery", ex.Message)
                        Return False
                    End Try
                End Using
            End Using
        End Function

        ''' <summary>
        ''' 指定のSQLクエリを実行して、結果をDataTableで取得します。
        ''' </summary>
        ''' <param name="constr">DB接続文字列</param>
        ''' <param name="sql">実行するSQL文</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataTable(ByVal constr As String, ByVal sql As String) As DataTable
            Dim dtb As New DataTable
            Try
                'DB と DataTableオブジェクトを関連づけるアダプターを作成
                Using adt As New SqlDataAdapter(sql, constr)
                    adt.SelectCommand.CommandTimeout = 300
                    adt.Fill(dtb)
                End Using
            Catch ex As Exception
                Message.MsgErr("Error @ SQLite_GetDataTable", ex.Message)
            End Try
            Return dtb
        End Function

        ''' <summary>
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="constr">DB接続文字列</param>
        ''' <param name="sql"></param>
        ''' <returns>型パラメータTに変換された単一値、エラーが発生した場合はNothing</returns>
        ''' <remarks></remarks>
        Public Function GetValue(Of T)(ByVal constr As String, ByVal sql As String) As T
            Using conn As New SqlConnection(constr)
                Using comm = conn.CreateCommand
                    Try
                        conn.Open()
                        comm.CommandText = sql
                        Return CType(comm.ExecuteScalar, T)
                    Catch ex As Exception
                        Message.MsgErr("Error @ DB_GetValue", ex.Message)
                        Return Nothing
                    End Try
                End Using
            End Using
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="o"></param>
        ''' <returns></returns>
        Public Function sNvl(ByVal o As Object) As String
            Return If(IsNothing(o) OrElse IsDBNull(o), "", o)
        End Function

        Public Function dNvl(ByVal o As Object) As Date
            Return If(IsNothing(o) OrElse IsDBNull(o), New Date(), CDate(o))
        End Function
    End Module
End Namespace

Namespace Message
    Public Module Message
        Public Function MsgInfo(ByVal msg As String) As DialogResult
            Return MsgInfo("インフォメーション", msg)
        End Function
        Public Function MsgInfo(ByVal cap As String, ByVal msg As String) As DialogResult
            Return MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Function

        Public Function MsgWarn(ByVal msg As String) As DialogResult
            Return MsgWarn("警告", msg)
        End Function

        Public Function MsgWarn(ByVal cap As String, ByVal msg As String) As DialogResult
            Return MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Function

        Public Function MsgErr(ByVal msg As String) As DialogResult
            Return MsgErr("エラー", msg)
        End Function

        Public Function MsgErr(ByVal cap As String, ByVal msg As String) As DialogResult
            Return MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Function

        Public Function MsgOKCancel(ByVal cap As String, ByVal msg As String) As DialogResult
            Return MessageBox.Show(msg, cap, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        End Function
    End Module

End Namespace

Namespace Utlis
    Public Module Utils
        Public gObj As Object

        ''' <summary>
        ''' 指定したファイルのMD5ハッシュ値を計算して文字列として返します。
        ''' </summary>
        ''' <param name="filename">ハッシュ値計算対象のファイルパス</param>
        ''' <returns></returns>
        Public Function GetMD5(ByVal filename As String) As String
            'ファイルストリームからハッシュ値を計算
            Using stm = My.Computer.FileSystem.GetFileInfo(filename).OpenRead(), md5obj = MD5.Create
                stm.Position = 0
                Dim str = ""
                'バイト配列 → 文字列 に変換処理
                For Each b In md5obj.ComputeHash(stm)
                    str &= b.ToString("X2")
                Next
                Return str
            End Using
        End Function

        ''' <summary>
        ''' 文字列をAESで暗号化又は復号化します
        ''' </summary>
        ''' <param name="text">対象文字列</param>
        ''' <param name="encrypt">暗号化の場合はTrue、復号化の場合はFalse</param>
        ''' <returns></returns>
        Private Function EnDecrypt(text As String, encrypt As Boolean) As String
            ' 128bitのIV（初期ベクタ）と256bitのKey（暗号キー）
            Dim aesIV As String = "xGi#-~zG*hqa$u*C"
            Dim aesKey As String = "mJjS//QqpAi+/kYC(_FKiHTEc|hT%yh!"
            ' AES暗号化サービスプロバイダ
            Dim aes As New AesCryptoServiceProvider()
            aes.BlockSize = 128
            aes.KeySize = 256
            aes.IV = Encoding.UTF8.GetBytes(aesIV)
            aes.Key = Encoding.UTF8.GetBytes(aesKey)
            aes.Mode = CipherMode.CBC
            aes.Padding = PaddingMode.PKCS7

            Dim src As Byte()

            If encrypt Then
                ' 文字列をバイト型配列に変換
                src = Encoding.Unicode.GetBytes(text)
            Else
                ' Base64形式の文字列からバイト型配列に変換
                src = System.Convert.FromBase64String(text)
            End If

            ' 暗号化及び復号化する
            Using ct As ICryptoTransform = If(encrypt, aes.CreateEncryptor, aes.CreateDecryptor())
                Dim dest As Byte() = ct.TransformFinalBlock(src, 0, src.Length)
                If encrypt Then
                    ' バイト型配列からBase64形式の文字列に変換
                    Return Convert.ToBase64String(dest)
                Else
                    Return Encoding.Unicode.GetString(dest)
                End If
            End Using
        End Function


        ''' <summary>
        ''' バイト配列を16進数文字列に変換します。
        ''' </summary>
        ''' <param name="bytes"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.Runtime.CompilerServices.Extension()>
        Public Function exByte2HexString(ByVal bytes As Byte()) As String
            Dim str = ""
            For Each b In bytes
                str &= b.ToString("X2")
            Next
            Return str
        End Function

        ''' <summary>
        ''' UTF-8でエンコーディングされた文字列をバイト配列に変換します。
        ''' </summary>
        ''' <param name="str">変換する文字列</param>
        ''' <returns></returns>
        <System.Runtime.CompilerServices.Extension()>
        Public Function exUTF8Str2Byte(ByVal str As String) As Byte()
            Return System.Text.Encoding.UTF8.GetBytes(str)
        End Function

        ''' <summary>
        ''' String.Format の拡張メソッドです。
        ''' </summary>
        ''' <param name="format">適用するフォーマット文字列</param>
        ''' <param name="args">文字列置換されるオブジェクト配列</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.Runtime.CompilerServices.Extension()>
        Public Function exFormat(ByVal format As String, ByVal ParamArray args As Object()) As String
            Return String.Format(format, args)
        End Function

        <System.Runtime.CompilerServices.Extension()>
        Public Function exIntPtr(ByVal str As String) As IntPtr
            Dim bytes As Byte() = str.exUTF8Str2Byte
            Dim size As Integer = Marshal.SizeOf(bytes(0)) * bytes.Length
            Return Marshal.AllocHGlobal(size)
        End Function

        <System.Runtime.CompilerServices.Extension()>
        Public Function exIntPtr(ByVal intArray As Integer()) As IntPtr
            Return Marshal.AllocHGlobal(Marshal.SizeOf(intArray(0)) * intArray.Length)
        End Function


        Public Function GetPtr(ByRef obj As Object) As IntPtr
            'ガベージコレクタがオブジェクトを移動できないようにする
            Dim gch As GCHandle = GCHandle.Alloc(obj, GCHandleType.Pinned)
            '固定オブジェクトのアドレスを取得する
            Dim pointer As IntPtr = gch.AddrOfPinnedObject()
            'Dim address As Integer = gch.AddrOfPinnedObject().ToInt32()
            'ハンドルを解放しオブジェクトが移動できるようにする
            gch.Free()
            Return pointer
        End Function


        Public Function GetPtr() As IntPtr
            'ガベージコレクタがオブジェクトを移動できないようにする
            Dim gch As GCHandle = GCHandle.Alloc(gObj, GCHandleType.Pinned)
            '固定オブジェクトのアドレスを取得する
            Dim pointer As IntPtr = gch.AddrOfPinnedObject()
            'Dim address As Integer = gch.AddrOfPinnedObject().ToInt32()
            'ハンドルを解放しオブジェクトが移動できるようにする
            gch.Free()
            Return pointer
        End Function
    End Module

    ''' <summary>
    ''' 任意のデータ型のペアを表すクラスです。
    ''' </summary>
    ''' <typeparam name="T">ペアの左側のオブジェクトのデータ型</typeparam>
    ''' <typeparam name="U">ペアの右側のオブジェクトのデータ型</typeparam>
    Public Class Pair(Of T, U)
        ' 値同士の区切り文字（デフォルトはカンマ）
        Protected Overridable Property Delimiter As String = ", "
        ''' <summary>
        ''' ペアオブジェクトの左側の値
        ''' </summary>
        ''' <returns></returns>
        Public Property L As T
        ''' <summary>
        ''' ペアオブジェクトの右側の値
        ''' </summary>
        ''' <returns></returns>
        Public Property R As U

        Public Sub New(ByVal l As T, ByVal r As U)
            Me.L = l
            Me.R = r
        End Sub

        Public Overrides Function ToString() As String
            Return If(L Is Nothing, "", L.ToString) & Delimiter & If(R Is Nothing, "", R.ToString)
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            ' 比較対象が自分と同型でなければfalse
            If TypeOf obj IsNot Pair(Of T, U) Then
                Return False
            End If
            '
            Dim o = DirectCast(obj, Pair(Of T, U))
            Dim eqL, eqR As Boolean
            ' L=Nullで対象のLもNullなら同一とみなす、
            If L Is Nothing Then
                eqL = o.L Is Nothing
            Else
                eqL = L.Equals(o.L)
            End If
            '
            If R Is Nothing Then
                eqR = o.R Is Nothing
            Else
                eqR = R.Equals(o.R)
            End If
            '
            Return eqL AndAlso eqR
        End Function

        Public Overrides Function GetHashCode() As Integer
            Dim result As Long = 1
            result = result * 31 + L.GetHashCode
            result = result * 31 + R.GetHashCode
            ' Integer型のOverflow対策
            Return result And &H7FFFFFFFL
        End Function
    End Class

    Public Class MyWatch
        Private sw As New Stopwatch

        ''' <summary>
        ''' ストップウォッチをリセットして、スタートさせます。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Start()
            sw.Reset()
            sw.Start()
        End Sub

        ''' <summary>
        ''' ストップウォッチを停止して、任意の形式で結果秒数を表示します。
        ''' </summary>
        ''' <param name="fmt">フォーマット文字列</param>
        ''' <remarks></remarks>
        Public Sub [Stop](Optional ByVal fmt As String = "処理時間: {0}ms")
            sw.Stop()
            Console.WriteLine(fmt.exFormat(sw.ElapsedMilliseconds))
        End Sub
    End Class

End Namespace


Namespace WinForm
    Public Enum SetupType
        必須 '入力が必須な項目
        参照 '参照のみ可能な項目
        通常 'コントロールの標準な設定
    End Enum

    Public Module WinForm

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="venmType"></param>
        ''' <param name="vctrls"></param>
        Sub SetupControls(ByVal venmType As SetupType, ByVal ParamArray vctrls() As Control)
            SetupControls(venmType, vctrls.AsEnumerable)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="venmType"></param>
        ''' <param name="venuCtrls"></param>
        Sub SetupControls(ByVal venmType As SetupType, ByVal venuCtrls As IEnumerable(Of Control))
            For Each ctrl In venuCtrls
                Select Case venmType
                    Case SetupType.参照
                        ctrl.BackColor = Color.FromArgb(192, 255, 255)
                        ctrl.TabStop = False
                        '
                        If TypeOf ctrl Is TextBox OrElse
                       TypeOf ctrl Is MaskedTextBox OrElse
                       TypeOf ctrl Is SPEdit OrElse
                       TypeOf ctrl Is SPNumber Then

                            '共通の基底クラスに変換
                            With CType(ctrl, TextBoxBase)
                                .ReadOnly = True
                            End With
                        Else
                            'それ以外の未定義なコントロール
                            ctrl.Enabled = False
                        End If

                    Case SetupType.必須, SetupType.通常
                        '
                        ctrl.TabStop = True

                        If venmType = SetupType.必須 Then
                            '必須項目ならば背景色を黄色に設定
                            ctrl.BackColor = Color.FromArgb(255, 255, 192)
                        ElseIf venmType = SetupType.通常 Then
                            '通常項目ならば背景色をWindow標準に設定
                            ctrl.BackColor = Drawing.SystemColors.Window
                        End If
                        '
                        If TypeOf ctrl Is TextBox OrElse
                       TypeOf ctrl Is MaskedTextBox OrElse
                       TypeOf ctrl Is SPEdit OrElse
                       TypeOf ctrl Is SPNumber Then
                            '
                            With CType(ctrl, TextBoxBase)
                                .ReadOnly = False
                            End With
                        Else
                            'それ以外の未定義なコントロール
                            ctrl.Enabled = True
                        End If
                End Select
            Next
        End Sub

        ''' <summary>
        ''' データグリッドビューをよく使っている設定にセットアップする
        ''' </summary>
        ''' <param name="dgv"></param>
        Public Sub SetupDataGridViewProperties(ByVal dgv As DataGridView)
            ' 編集不可とする
            dgv.ReadOnly = True
            ' データソースの項目名によって勝手に列が生成されないよう設定
            dgv.AutoGenerateColumns = False
            ' ユーザーが行を追加及び削除できないよう設定
            dgv.AllowUserToAddRows = False
            dgv.AllowUserToDeleteRows = False

            ' 列ヘッダの高さを調節できないように設定
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            ' 行ヘッダーについてユーザーが調節できないよう設定し、幅を２５に固定
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            dgv.RowHeadersWidth = 25
            ' 複数選択を無効にする
            dgv.MultiSelect = False
            ' ユーザーが各項目をソートできないよう設定
            For Each col As DataGridViewColumn In dgv.Columns
                ' NotSortable: クリックしてもソートしない
                col.SortMode = DataGridViewColumnSortMode.NotSortable
                ' Automatic: ユーザーが列ヘッダクリックでソート
                'col.SortMode = DataGridViewColumnSortMode.Automatic
            Next

            ' ユーザが行および列をリサイズできないよう設定
            dgv.AllowUserToResizeColumns = True
            dgv.AllowUserToResizeRows = False

            ' 単一セルではなく行全体を選択できるように設定
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End Sub

        ''' <summary>
        ''' dgvで指定したDataGridViewについて、colsで指定した列の同値セル同士を結合します。
        ''' また、スクロール時の表示制御を行います。
        ''' </summary>
        ''' <param name="dgv">設定対象のDataGridView</param>
        ''' <param name="cols">結合したい列オブジェクト</param>
        Public Sub SetupDataGridViewCellMerge(ByVal dgv As DataGridView, ParamArray ByVal cols As DataGridViewColumn())
            ' 結合対象の列が未指定ならリターン
            If cols.Count = 0 Then
                Return
            End If

            ' 一個前のセルを記憶するためのコレクション
            Dim preCells As IEnumerable(Of DataGridViewCell) = Nothing

            ' 同一セル判断関数定義
            Dim IsSameCellValue =
            Function(col As Integer, row As Integer) As Boolean
                ' １行目の場合は上のセルを取得できないのでスキップ
                If row = 0 Then
                    Return False
                End If
                ' ※ colsで指定した列のみを結合処理する
                If Not cols.Contains(dgv.Columns(col)) Then
                    Return False
                End If
                '
                Dim cell1 As DataGridViewCell = dgv(col, row)
                Dim cell2 As DataGridViewCell = dgv(col, row - 1)
                '
                If cell1.Value Is Nothing OrElse IsDBNull(cell1.Value) OrElse
                   cell2.Value Is Nothing OrElse IsDBNull(cell2.Value) Then
                    Return False
                End If
                ' ここではセル値のオブジェクトを文字列として比較
                Return cell1.Value.ToString() = cell2.Value.ToString()
            End Function
            '
            ' Scrollイベントを追加　※ユーザーがグリッドを上下左右にスクロールしたとき呼ばれる
            AddHandler dgv.Scroll,
            Sub(s, e)
                '横スクロールは無視
                If e.ScrollOrientation = ScrollOrientation.HorizontalScroll Then
                    Return
                End If
                ' 指定された結合対象列の現在1行目に表示されているセルを取得
                Dim cells = From c In cols Select dgv(c.Index, e.NewValue)
                ' 上方向へのスクロール時は CellFormattingイベントで値表示を制御する
                If e.OldValue < e.NewValue Then
                    ' 下スクロールの時のみ制御する
                    For Each cell In cells
                        ' 前景色を元に戻す
                        cell.Style.ForeColor = dgv.DefaultCellStyle.ForeColor
                        cell.Style.SelectionForeColor = dgv.DefaultCellStyle.SelectionForeColor
                    Next
                Else
                    ' 上スクロール
                    If preCells IsNot Nothing Then
                        For Each cell In preCells
                            If IsSameCellValue(cell.ColumnIndex, cell.RowIndex) Then
                                ' 前のセルの前景色を透明にして表示を消す
                                cell.Style.ForeColor = Color.Transparent
                                cell.Style.SelectionForeColor = Color.Transparent
                            End If
                        Next
                    End If
                End If
                ' 値を更新
                preCells = cells
            End Sub
            '
            ' CellFormattingイベントを追加する ※セルに表示する文字列が取得・要求されたとき呼ばれる
            AddHandler dgv.CellFormatting,
            Sub(s, e)
                ' 当該セルの行数が表示行１行目以降である場合
                If dgv.FirstDisplayedScrollingRowIndex < e.RowIndex Then
                    ' 当該セルと１つ上のセルの値が同一と判断されたら
                    If IsSameCellValue(e.ColumnIndex, e.RowIndex) Then
                        e.CellStyle.ForeColor = Color.Transparent
                        e.CellStyle.SelectionForeColor = Color.Transparent
                        e.FormattingApplied = True '以降の書式設定は不要
                    End If
                End If
            End Sub
            '
            ' CellPaintingイベントを追加　※ セルが画面に描画されたとき呼ばれる？
            AddHandler dgv.CellPainting,
            Sub(s, e)
                ' セルの下側の境界線を「境界線なし」に設定
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
                ' 1行目や列ヘッダ、行ヘッダの場合は何もしない
                If e.RowIndex < 1 OrElse e.ColumnIndex < 0 Then
                    Return
                End If
                If IsSameCellValue(e.ColumnIndex, e.RowIndex) Then
                    ' セルの上側の境界線を「境界線なし」に設定
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
                Else
                    ' セルの上側の境界線を既定の境界線に設定
                    e.AdvancedBorderStyle.Top = dgv.AdvancedCellBorderStyle.Top
                End If
            End Sub
        End Sub

        ''' <summary>
        ''' 同じ Name を持つフォームが既に開かれていればTrue
        ''' </summary>
        ''' <param name="parent">親フォーム</param>
        ''' <param name="child">探す子フォーム</param>
        ''' <returns></returns>
        Public Function IsOpen(ByVal parent As Form, ByVal child As Form) As Boolean
            Return parent.OwnedForms.Select(Function(f) f.Name).Contains(child.Name)
        End Function
    End Module
End Namespace

' 実験中のテストコード
Namespace Lab
    Module Lab
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


End Namespace


