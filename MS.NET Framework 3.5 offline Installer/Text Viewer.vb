Public Class Text_Viewer

    Private Sub Text_Viewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim reader As New System.IO.StreamReader("\Windows\logs\dism\dism.log")
        RichTextBox.Text = reader.ReadToEnd
        reader.Close()
    End Sub
End Class