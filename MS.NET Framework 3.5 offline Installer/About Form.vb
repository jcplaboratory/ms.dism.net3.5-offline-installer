Public Class About_Form

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://www.askvg.com/download-microsoft-net-framework-3-5-offline-installer-for-windows-8/")
    End Sub
End Class