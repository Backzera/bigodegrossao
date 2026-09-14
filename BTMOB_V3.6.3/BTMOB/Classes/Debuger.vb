Imports System.IO

Module Debuger
    'Private ReadOnly debugLogPath As String = "Resources\logs\debug"
    Private ReadOnly errorLogPath As String = "Resources\logs\error"

    ' Ensures the directories exist before writing logs
    Private Sub EnsureDirectories()
        'If Not Directory.Exists(debugLogPath) Then
        '    Directory.CreateDirectory(debugLogPath)
        'End If
        If Not Directory.Exists(errorLogPath) Then
            Directory.CreateDirectory(errorLogPath)
        End If
    End Sub

    Public Sub Log_d(from As String, msg As String)
#If DEBUG Then
        Try
            'EnsureDirectories()
            Dim logEntry As String = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]-[{myname}-DEBUG]{Environment.NewLine}==>[{from}]{Environment.NewLine}==>[{msg}]"
            Console.WriteLine(logEntry)
            ' Dim filePath As String = Path.Combine(debugLogPath, "debug.log")
            'File.AppendAllText(filePath, $"{logEntry}{Environment.NewLine & Environment.NewLine}")
        Catch ex As Exception

        End Try
#End If
    End Sub

    Public Sub Log_e(from As String, msg As String)
        Try
            EnsureDirectories()

            Dim logEntry As String = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]-[{myname}-ERROR]==>[{from}]==>[{msg}]"
            Console.WriteLine(logEntry)

            Dim filePath As String = Path.Combine(errorLogPath, "error.log")
            File.AppendAllText(filePath, $"{logEntry}{Environment.NewLine & Environment.NewLine}")
        Catch ex As Exception
            Console.WriteLine($"Error [{ex.Message}] while writting error:{vbNewLine} [{DateTime.Now:yyyy-MM-dd HH:mm:ss}]-[{myname}-ERROR]==>[{from}]==>[{msg}]")
        End Try
    End Sub
End Module
