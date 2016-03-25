Module Driver

    Sub Main()


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
                    ' 0~1399
                    Dim x = Math.Floor(rdm.Next(4000))
                    If x < 1400 Then
                        group(Math.Floor(x / 200)) += 1
                    End If
                Next
                ' ６以上該当したグループが１つでもあればカウントする
                If group.Where(Function(m) m >= 3).Count > 0 Then
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
