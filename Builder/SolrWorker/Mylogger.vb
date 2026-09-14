Imports System.IO
Imports System.Xml
Imports Newtonsoft.Json

Module Mylogger
    Private ReadOnly errorDirPath As String = "Apps_errors"
    Private ReadOnly buildDirPath As String = "Apps_logs"
    'Private ReadOnly buildDirPath_err As String = "Solrjector_errors"
    Public Sub LogError(ByVal userId As String, ByVal methodName As String, ByVal errorMessage As String)
        Try

            Dim directoryPath As String = Path.Combine(GetDrive, errorDirPath, userId)
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
                .Content = errorMessage
            }

            errorLog.Add(errorObject)

            Dim jsonLog As String = JsonConvert.SerializeObject(errorLog, Newtonsoft.Json.Formatting.Indented)

            File.WriteAllText(filePath, jsonLog)
        Catch ex As Exception

            Console.WriteLine($"Error logging failed: {ex.Message}")
        End Try
    End Sub
    Public Sub Logbuild(ByVal userId As String, ByVal msg As String)
        Try

            Dim directoryPath As String = Path.Combine(GetDrive, buildDirPath, userId)
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
                .Content = msg
            }

            errorLog.Add(errorObject)

            Dim jsonLog As String = JsonConvert.SerializeObject(errorLog, Newtonsoft.Json.Formatting.Indented)

            File.WriteAllText(filePath, jsonLog)
        Catch ex As Exception

            Console.WriteLine($"build logging failed: {ex.Message}")
        End Try
    End Sub

End Module
