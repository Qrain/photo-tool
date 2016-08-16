

Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports CommonLibs.Utlis


Module Driver
    '----------▼ 修正 by sawai yyyy/MM/dd ----------
    ' ==== Old Codes ====
    ' ↑From ↓To
    ' ==== New Codes ====
    '----------▲ 修正 by sawai yyyy/MM/dd ----------

    Sub Main()
        Dim xx = {"1234", "4564", "9999", "0000"}

        'MsgBox(CDate("20071217150000").ToString())
        Return



        'Dim arys = New Integer() {1, 2, 3}
        'Dim gch As GCHandle = GCHandle.Alloc(arys, GCHandleType.Pinned)
        'Dim gch1 As GCHandle = GCHandle.Alloc(arys(0), GCHandleType.Pinned)
        'Dim gch2 As GCHandle = GCHandle.Alloc(arys(1), GCHandleType.Pinned)
        'Dim gch3 As GCHandle = GCHandle.Alloc(arys(2), GCHandleType.Pinned)
        'Console.WriteLine(GetPtr(arys).ToString("X8"))
        'gObj = arys(0)
        'Console.WriteLine(GetPtr().ToString("X8"))
        'gObj = arys(1)
        'Console.WriteLine(GetPtr().ToString("X8"))
        'Console.WriteLine(GetPtr(arys(2)).ToString("X8"))
        'Console.WriteLine(gch.AddrOfPinnedObject.ToString("X8"))
        'Console.WriteLine(gch.AddrOfPinnedObject.ToString("X8"))
        'Console.WriteLine(gch1.AddrOfPinnedObject.ToString("X8"))
        'Console.WriteLine(gch2.AddrOfPinnedObject.ToString("X8"))
        'Console.WriteLine(gch3.AddrOfPinnedObject.ToString("X8"))
        'gch1.Free()
        'gch2.Free()
        'gch3.Free()
        'gch.Free()
        'Application.EnableVisualStyles()
        'Application.Run(New DataGridViewDragAndDrop)


        Dim feedS2E =
            Function(p As Double) As Double
                Return Math.Pow(p, 3) / Math.Pow((2 * (p * p) - 2 * p + 1), 3)
            End Function
        Dim feedOne =
            Function(p As Double) As Double
                Return p / (2 * (p * p) - 2 * p + 1)
            End Function

        For i = 0.7 To 0.72 Step 0.001
            Console.WriteLine(i & ": " & vbTab & feedOne(i))
        Next

        Console.ReadLine()

        Return

        Dim list As New List(Of Integer) From {1, 2, 3}

        Dim selected =
            From i In list
            Select No = "No." & i, Str = "ABC"

        Dim xxxxx As IEnumerable(Of Object) = selected



        ' デフォコンでは時間による乱数シードが使われる
        Dim rdm = New System.Random()
        'Console.WriteLine("１回目")
        'For i = 1 To 10
        '    Console.WriteLine(rdm.Next(400))
        'Next
        'rdm = New System.Random(2)
        'Console.WriteLine("２回目")
        'For i = 1 To 10
        '    Console.WriteLine(rdm.Next(400))
        'Next
        'Console.ReadLine()
        'Return

        ' 1～4000の範囲内で18つの乱数を取る
        Dim group As Integer() = New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        Dim result As New List(Of Double)
        Dim count As Integer = 0
        Dim n = 50000

        For xxx = 1 To 50
            count = 0
            ' n回試行
            For i = 1 To n
                ' 全要素を０で初期化
                Array.Clear(group, 0, group.Count)

                For j = 1 To 18
                    ' 0～3999の範囲で乱数を生成
                    Dim x = Math.Floor(rdm.Next(4000))
                    ' 0~1399
                    If x < 1400 Then
                        group(Math.Floor(x / 200)) += 1
                    End If
                Next
                ' ６以上該当したグループが１つでもあればカウントする
                If group.Where(Function(m) m > 4).Count > 0 Then
                    count += 1
                End If
            Next
            result.Add(count / n)
        Next

        Console.WriteLine("平均値 " & (result.Sum / result.Count) * 100 & " %")
        Console.ReadLine()

    End Sub


    Function GetTime() As Double

        Return 0
    End Function

End Module
