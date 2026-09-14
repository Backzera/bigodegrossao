Imports System.IO
Imports Newtonsoft.Json

Module Mylogger
    Private ReadOnly errorDirPath As String = "errors"
    Private ReadOnly buildDirPath As String = "logs"

    Public Sub LogError(ByVal userId As String, ByVal methodName As String, ByVal errorMessage As String)
        Try

            Dim directoryPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, errorDirPath, userId)
            Directory.CreateDirectory(directoryPath)


            Dim currentDate As String = DateTime.Now.ToString("yyyy-MM-dd")
            Dim filePath As String = Path.Combine(directoryPath, $"{userId + "-" + currentDate}-log.json")


            Dim errorLog As New List(Of Object)()

            If File.Exists(filePath) Then
                Dim existingLog As String = File.ReadAllText(filePath)
                errorLog = JsonConvert.DeserializeObject(Of List(Of Object))(existingLog)
            End If

            Dim errorObject As New With {
                .Date = DateTime.Now.ToString(),
                .Method = methodName,
                .Content = errorMessage
            }

            errorLog.Add(errorObject)

            Dim jsonLog As String = JsonConvert.SerializeObject(errorLog, Formatting.Indented)

            File.WriteAllText(filePath, jsonLog)
        Catch ex As Exception

            Console.WriteLine($"Error logging failed: {ex.Message}")
        End Try
    End Sub
    Public Sub Logbuild(ByVal userId As String, ByVal methodName As String, ByVal msg As String)
        Try

            Dim directoryPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, buildDirPath, userId)
            Directory.CreateDirectory(directoryPath)


            Dim currentDate As String = DateTime.Now.ToString("yyyy-MM-dd")
            Dim filePath As String = Path.Combine(directoryPath, $"{currentDate}-log.json")


            Dim errorLog As New List(Of Object)()

            If File.Exists(filePath) Then
                Dim existingLog As String = File.ReadAllText(filePath)
                errorLog = JsonConvert.DeserializeObject(Of List(Of Object))(existingLog)
            End If

            Dim errorObject As New With {
                .Date = DateTime.Now.ToString(),
                .Method = methodName,
                .Content = msg
            }

            errorLog.Add(errorObject)

            Dim jsonLog As String = JsonConvert.SerializeObject(errorLog, Formatting.Indented)

            File.WriteAllText(filePath, jsonLog)
        Catch ex As Exception

            Console.WriteLine($"build logging failed: {ex.Message}")
        End Try
    End Sub

End Module
