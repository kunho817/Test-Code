Class MainWindow
    Dim fileR As String
    Dim thefile As String
    Dim results As String
    Dim person As System.IO.FileStream

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        thefile = String.Format("c:\{0}.txt", Name.Text)
        results = Dir$(thefile)
        If results = "" Then
            person = System.IO.File.Create(String.Format("c:\{0}.txt", Name.Text))
            MsgBox("New Information is added")
        Else
            fileR = My.Computer.FileSystem.ReadAllText(String.Format("c:\{0}.txt", InputName.Text),
            System.Text.Encoding.UTF8)
            Text.Text = fileR
        End If
    End Sub

    Private Sub add(sender As Object, e As RoutedEventArgs)

    End Sub

End Class