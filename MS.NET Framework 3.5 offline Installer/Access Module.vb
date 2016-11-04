Imports System.Security.Principal
Module Access_Module
    Public Function IsUserAdministrator()
        Dim Identity = WindowsIdentity.GetCurrent
        Dim principal = New WindowsPrincipal(Identity)
        Dim IsElevated As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)
        If IsElevated = True Then
            Return True
        End If
        Return False
    End Function
   
End Module
