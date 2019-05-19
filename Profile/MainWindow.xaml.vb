Class MainWindow
    Dim fileR As String
    Dim thefile As String
    Dim results As String
    Dim person As System.IO.FileStream

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        thefile = String.Format("c:\Profile\{0}.txt", Name.Text)
        results = Dir$(thefile)
        If results = "" Then
            MsgBox("이 이름을 가진 사람의 정보가 존재하지 않습니다.")
            Canvas.IsEnabled = True
            Name.Text = InputName.Text
        Else
            fileR = My.Computer.FileSystem.ReadAllText(String.Format("c:\Profile\{0}.txt", InputName.Text),
            System.Text.Encoding.UTF8)
            Text.Text = fileR
        End If
    End Sub

    Private Sub Add(sender As Object, e As RoutedEventArgs)
        For i As Integer = 0 To i < Name.Text.Length
            Name.
        Next
        thefile = String.Format("c:\Profile\{0}.txt", Name.Text)
        results = Dir$(thefile)
        If results = "" Then
            person = System.IO.File.Create(String.Format("c:\Profile\{0}.txt", Name.Text))
            MsgBox("New Information is added")
            Canvas.IsEnabled = False
        End If
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(String.Format("c:\Profile\{0}.txt", Name.Text), False)
        file.WriteLine(Name.Text)
        file.WriteLine(Age.Text)
        file.WriteLine(Job.Text)
        file.WriteLine(Birth.Text)
        file.WriteLine(Country.Text)
        file.WriteLine(Location.Text)
        file.Close()
    End Sub

End Class