Imports System.IO
Public Class main

    Private Sub main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If System.IO.File.Exists(Application.StartupPath & "\data.dat") = True Then
            Kill(Application.StartupPath & "\data.dat")
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call IsUserAdministrator()
        If IsUserAdministrator() = True Then
            Dim osbuild As String
            osbuild = Environment.OSVersion.Version.Build.ToString
            If osbuild <= 8000 Then
                MsgBox("This Operating System is not supported. Use this application with Microsoft Windows 8 only.", vbCritical)
                Me.Close()
                Application.Exit()
            Else
                ' get list of drives
                Dim sDrives = System.IO.DriveInfo.GetDrives
                For Each sdrive In sDrives
                    comDrive.Items.Add(sdrive.Name)
                Next
                If comDrive.Items.Contains("E:\") Then
                    comDrive.Text = "E:\"
                Else
                    comDrive.Text = sDrives.First.ToString
                End If
                txtinstallcmd.Text = "/online /enable-feature /featurename:NetFX3 /source:""" & txtSource.Text & """ /LimitAccess"
                Infoconsole.Text = "******************************************************************************************************************* " & vbNewLine & "Microsoft.NET Framework 3.5 Offline Installer 2.0 - ©J.C.P Laboratory 2008-2013" & vbNewLine & "*******************************************************************************************************************  " & vbNewLine & "- AskVG.com Exclusive" & vbNewLine & vbNewLine & "Click on " & """" & "Start Installation " & """" & "To Start Installation"
            End If
        ElseIf IsUserAdministrator() = False Then
            MsgBox("This Application cannot start. Please restart and run this application as administrator.", vbCritical)
            Me.Close()
            Application.Exit()
        End If
    End Sub

    Private Sub comDrive_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comDrive.SelectedIndexChanged
        txtSource.Text = comDrive.Text & "sources\sxs"
    End Sub

    Private Sub cmdInstall_Click(sender As Object, e As EventArgs) Handles cmdInstall.Click
        Dim install As New ProcessStartInfo
        If System.IO.Directory.Exists(txtSource.Text) = True Then
            If InStr(txtSource.Text, "\sources\sxs", CompareMethod.Text) Then
                If InStr(txtSource.Text, "\sources\sxs\", CompareMethod.Text) Then
                    MsgBox("Invalid source path. Make sure that selected the appropriate source folder which contains the directory (\sxs) only not with sub directories.", vbCritical, "Invalid path")
                    Infoconsole.Text = "******************************************************************************************************************* " & vbNewLine & "Microsoft.NET Framework 3.5 Offline Installer 2.0 - ©J.C.P Laboratory 2008-2013" & vbNewLine & "*******************************************************************************************************************  " & vbNewLine & vbNewLine & "Invalid Path"
                Else
                    Try
                        If System.IO.File.Exists("\Windows\Logs\dism\dism.log") = True Then
                            Dim write As New System.IO.StreamWriter("\Windows\Logs\dism\dism.log")
                            write.Write("")
                            write.Close()
                        End If
                    Catch ex As Exception
                        'do nothing
                    End Try
                    install.FileName = "cmd.exe"
                    txtinstallcmd.Text = "/online /enable-feature /featurename:NetFX3 /source:""" & txtSource.Text & """ /LimitAccess"
                    If RshowCMD.Checked = True Then
                        install.Arguments = "/c dism.exe" & " " & txtinstallcmd.Text
                        install.WindowStyle = ProcessWindowStyle.Normal
                    ElseIf Rhide.Checked = True Then
                        install.Arguments = "/c dism.exe" & " " & txtinstallcmd.Text & ">>" & """" & Application.StartupPath & """" & "\data.dat"
                        install.WindowStyle = ProcessWindowStyle.Hidden
                    End If
                    Infoconsole.Text = "******************************************************************************************************************* " & vbNewLine & "Microsoft.NET Framework 3.5 Offline Installer 2.0 - ©J.C.P Laboratory 2008-2013" & vbNewLine & "*******************************************************************************************************************  " & vbNewLine & vbNewLine & ".NET Framework Installation Started..."
                    Process.Start(install).WaitForExit()
                    If RshowCMD.Checked = False Then
                        Dim log As New System.IO.StreamReader(Application.StartupPath & "\data.dat")
                        Dim output As String = log.ReadToEnd
                        log.Close()
                        If InStr(output, "The operation completed successfully.") Then
                            Infoconsole.Text = Infoconsole.Text & vbNewLine & "Done"
                            MsgBox("Microsoft.NET Framework 3.5 was installed successfully.", vbInformation)
                        Else
                            Infoconsole.Text = Infoconsole.Text & vbNewLine & "Done With Errors."
                            MsgBox("An error occured while installing Microsoft.NET Framework 3.5." & vbNewLine & "Please verify the disk and installation source path when try again.", vbCritical)
                        End If
                    Else
                        MsgBox("Microsoft.NET Framework 3.5 was installed successfully.", vbInformation)
                        Infoconsole.Text = Infoconsole.Text & vbNewLine & "Done"
                    End If
                End If
            Else
                Infoconsole.Text = "******************************************************************************************************************* " & vbNewLine & "Microsoft.NET Framework 3.5 Offline Installer 2.0 - ©J.C.P Laboratory 2008-2013" & vbNewLine & "*******************************************************************************************************************  " & vbNewLine & vbNewLine & "Invalid Path"
                MsgBox("Invalid source path. Make sure that selected the appropriate source folder which contains the following (\sources\sxs) directories.", vbCritical, "Invalid source path")
            End If
        Else
            Infoconsole.Text = "******************************************************************************************************************* " & vbNewLine & "Microsoft.NET Framework 3.5 Offline Installer 2.0 - ©J.C.P Laboratory 2008-2013" & vbNewLine & "*******************************************************************************************************************  " & vbNewLine & vbNewLine & "Invalid Path"
            MsgBox("Installation source directory not found. Make sure that you have selected the appropriate (Virtual) Drive Letter.", vbCritical, "Installation source directory not found")
        End If
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Process.Start("http://www.jcplaboratory.webs.com")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Process.Start("http://www.jcplaboratory.webs.com")
    End Sub

    Private Sub cmdlog_Click(sender As Object, e As EventArgs) Handles cmdlog.Click
        If System.IO.File.Exists("\Windows\Logs\dism\dism.log") = True Then
            Text_Viewer.ShowDialog()
        Else
            MsgBox("You must install the .NET Framework once to open the log file.", vbExclamation, "Log file not found.")
        End If
    End Sub

    Private Sub cmdBrowse_Click(sender As Object, e As EventArgs) Handles cmdBrowse.Click
        FolderBrowserDialog.ShowDialog()
        txtSource.Text = FolderBrowserDialog.SelectedPath
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtSource_TextChanged(sender As Object, e As EventArgs) Handles txtSource.TextChanged
        txtinstallcmd.Text = "/online /enable-feature /featurename:NetFX3 /source:""" & txtSource.Text & """ /LimitAccess"
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub about_Click(sender As Object, e As EventArgs) Handles about.Click
        About_Form.ShowDialog()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Process.Start("http://www.askvg.com")
    End Sub
End Class
