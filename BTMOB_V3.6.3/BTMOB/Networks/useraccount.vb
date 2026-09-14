Imports System.IO
Imports System.Net.Http

Module useraccount


    Public Function SendPostRequest(httpClient As HttpClient, payload As Dictionary(Of String, String), Optional filePath As String = Nothing) As String
        Try
            Dim requestContent As HttpContent

            If String.IsNullOrEmpty(filePath) Then

                Dim postData As New FormUrlEncodedContent(payload)
                requestContent = postData
            Else

                Dim boundary As String = "----WebKitFormBoundary" & DateTime.Now.Ticks.ToString("x")
                Dim multiPartContent As New MultipartFormDataContent(boundary)


                For Each kvp In payload
                    multiPartContent.Add(New StringContent(kvp.Value), kvp.Key)
                Next


                Dim fileBytes = File.ReadAllBytes(filePath)
                Dim fileContent As New ByteArrayContent(fileBytes)
                fileContent.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("image/png")
                multiPartContent.Add(fileContent, "file", Path.GetFileName(filePath))

                requestContent = multiPartContent
            End If


            Dim response = httpClient.PostAsync(api_useraccount, requestContent).Result
            Return response.Content.ReadAsStringAsync().Result
        Catch ex As Exception
            Return $"Error: {ex.Message}"
        End Try
    End Function


    Public Function RemoveIcon(httpClient As HttpClient, iconName As String) As String
        Dim payload As New Dictionary(Of String, String) From {
            {"type", "remico"},
            {"iconame", iconName}
        }
        Return SendPostRequest(httpClient, payload)
    End Function

    Public Function ListIcons(httpClient As HttpClient) As String
        Dim payload As New Dictionary(Of String, String) From {
            {"type", "listico"}
        }
        Return SendPostRequest(httpClient, payload)
    End Function

    Public Function AddIcon(httpClient As HttpClient, filePath As String) As String
        Dim payload As New Dictionary(Of String, String) From {
            {"type", "ico"}
        }
        Return SendPostRequest(httpClient, payload, filePath)
    End Function

    Public Function ChangeUserName(httpClient As HttpClient, newName As String) As String
        Dim payload As New Dictionary(Of String, String) From {
            {"type", "name"},
            {"data", newName}
        }
        Return SendPostRequest(httpClient, payload)
    End Function
End Module
