Class MainWindow
    Dim fileR As String
    Dim thefile As String
    Dim results As String

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        thefile = String.Format("c:\Profile\{0}.txt", InputCombo.Text)
        results = Dir$(thefile)
        If results = "" Then
            MsgBox("이 이름을 가진 사람의 정보가 존재하지 않습니다.")
            Canvas.IsEnabled = True
            Nam.Text = InputCombo.Text
        Else
            fileR = My.Computer.FileSystem.ReadAllText(String.Format("c:\Profile\{0}.txt", InputCombo.Text), System.Text.Encoding.UTF8)
            Text.Text = fileR
        End If
    End Sub

    Private Sub Add(sender As Object, e As RoutedEventArgs)
        Dim person As System.IO.FileStream

        thefile = String.Format("c:\Profile\{0}_{1}_{2}_{3}.txt", InputCombo.Text, Age.Text, Birth.Text, Country.Text)
        results = Dir$(thefile)
        If results = "" Then
            person = System.IO.File.Create(String.Format("c:\Profile\{0}_{1}_{2}_{3}.txt", InputCombo.Text, Age.Text, Birth.Text, Country.Text))
            InputCombo.Items.Add(String.Format("{0}_{1}_{2}_{3}", InputCombo.Text, Age.Text, Birth.Text, Country.Text))
            MsgBox("New Information is added")
            person.Close()
        End If
    End Sub

    Private Sub Save(sender As Object, e As RoutedEventArgs)
        If (Canvas.IsEnabled) Then
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(String.Format("c:\Profile\{0}_{1}_{2}_{3}.txt", InputCombo.Text, Age.Text, Birth.Text, Country.Text), False)
            file.WriteLine(Nam.Text)
            file.WriteLine(Age.Text)
            file.WriteLine(Job.Text)
            file.WriteLine(Birth.Text)
            file.WriteLine(Country.Text)
            file.WriteLine(Location.Text)
            file.Close()
            Canvas.IsEnabled = False
            file.Close()
        End If
    End Sub

    Private Sub Initia(sender As Object, e As EventArgs)
        Dim filess As String
        Dim str As String
        Dim News As System.IO.StreamReader
        Dim fileo As System.IO.FileStream

        filess = "c:\Profile\Com\Com.txt"

        results = Dir$(filess)
        News = My.Computer.FileSystem.OpenTextFileReader("c:\Profile\Com\Com.txt", System.Text.Encoding.UTF8)
        If results = "" Then
            fileo = System.IO.File.Create("c:\Profile\Com\Com.txt")
            fileo.Close()
        Else
CHECK:      str = News.ReadLine
            If IsNothing(str) Then
            Else

                If str.Contains("$#-#$") Then
                    InputCombo.Items.Add(str.Replace("$#-#$", ""))
                    GoTo CHECK
                End If
                News.Close()
            End If
        End If
        News.Close()
    End Sub

    Private Sub Over(sender As Object, e As EventArgs)
        Dim file As System.IO.StreamWriter
        Dim i As Integer
        file = My.Computer.FileSystem.OpenTextFileWriter(("c:\Profile\Com\Com.txt"), False)

        For i = 0 To InputCombo.Items.Count
            file.WriteLine(String.Format("{0}$#-#$", InputCombo.Items.Item(i)))
        Next
        file.Close()
    End Sub

    Private Sub FCh(sender As Object, e As DependencyPropertyChangedEventArgs) Handles InputCombo.FocusableChanged
        InputCombo.IsDropDownOpen = False
    End Sub

    Private Sub GF(sender As Object, e As RoutedEventArgs) Handles InputCombo.GotFocus
        InputCombo.IsDropDownOpen = True
    End Sub
End Class