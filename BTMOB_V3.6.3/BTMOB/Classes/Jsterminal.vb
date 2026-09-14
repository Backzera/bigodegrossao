<Runtime.InteropServices.ClassInterface(Runtime.InteropServices.ClassInterfaceType.AutoDual)>
<Runtime.InteropServices.ComVisible(True)>
Public Class Jsterminal
    Public mainform As terminal

    Sub New(m As terminal)
        mainform = m
    End Sub

    Public Function ExecuteCommand(cmd As String) As String
        ' Handle command (simulate or real logic here)
        mainform.commandterminal(cmd)
        'Select Case cmd.ToLower()
        '    Case "help"
        '        Return "Available commands: help, time, echo [text]"
        '    Case "time"
        '        Return DateTime.Now.ToString()
        '    Case Else
        '        If cmd.StartsWith("echo ") Then
        '            Return cmd.Substring(5)
        '        Else
        '            Return "Unknown command: " & cmd
        '        End If
        'End Select
    End Function
End Class
