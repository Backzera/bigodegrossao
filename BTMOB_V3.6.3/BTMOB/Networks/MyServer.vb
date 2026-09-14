Imports System.Net.Http
Imports System.Net.NetworkInformation
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports DrakeUI.Framework
Imports System.Threading

Module MyServer
    'Public Function IsInternetAvailable() As Boolean
    '    Try
    '        Using ping As New Ping()
    '            Dim reply As PingReply = ping.Send(mainsite, 5000)
    '            If reply.Status = IPStatus.Success Then
    '                Return True
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        ' Handle or log exception if needed
    '    End Try

    '    Return False
    'End Function
    Public Async Function startlogin(uemail As String,
                                     upass As String,
                                     pinkey As String,
                                     rankey As String,
                                     client As HttpClient) As Task(Of (Boolean, String))
        Try
            ' Create a new instance of HttpClient

            Dim hardwareid As String = GetHWID() + BTRegistry.GetValue(Regz.hwidassist, "")

            ' Create the data object to be sent in the request body
            Dim data As New With {
                    .mname = "BT-MOB",
                    .email = uemail,
                    .pass = upass,
                    .pkey = pinkey,
                    .hid = hardwareid,
                    .ran_key = rankey
                }

            ' Serialize the data to JSON
            Dim jsonData As String = JsonConvert.SerializeObject(data)
            Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")

            ' Send the POST request

            Using response As HttpResponseMessage = Await client.PostAsync(api_login, content)
                If response.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim responseString As String = Await response.Content.ReadAsStringAsync()

                    ' Parse the response (assuming it's in JSON format)
                    Dim result As JObject = JObject.Parse(responseString)

                    ' Check the result for success or failure
                    If result("Success") IsNot Nothing Then
                        Dim datastr As String = result("Success").ToString.Trim("""")
                        Log_d("AuthenticateJector", result("Success").ToString)
                        Return (True, datastr)
                    ElseIf result("Fail") IsNot Nothing Then
                        Return (False, "failed: " & result("Fail").ToString())
                    End If
                Else
                    Return (False, "error: " & response.StatusCode.ToString())
                End If


            End Using
            ' Check if the request was successful


        Catch ex As Exception
            ' Handle any errors that occur during the request
            Return (False, "Error: " & "can't connect to server")
        End Try

        ' Default return value if nothing matched (this might never be hit)
        Return (False, "Unexpected error.")
    End Function
    Public Async Function FetchStore(params As Object, client As HttpClient) As Task(Of (Boolean, Object))
        Try
            ' Serialize the parameters to JSON
            Dim jsonData As String = JsonConvert.SerializeObject(params)
            Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")

            ' Send the POST request
            Using response As HttpResponseMessage = Await client.PostAsync(api_fetchstore, content)
                If response.IsSuccessStatusCode Then
                    ' Read the response content
                    Dim responseString As String = Await response.Content.ReadAsStringAsync()

                    ' Check if the response is JSON
                    If response.Content.Headers.ContentType.MediaType = "application/json" Then
                        ' Parse the JSON response
                        Dim result As JObject = JObject.Parse(responseString)

                        ' Check for "Success", "Fail", or other keys
                        If result("Success") IsNot Nothing Then
                            Return (True, result("Success").ToString())
                        ElseIf result("Req") IsNot Nothing Then
                            Return (True, result("Req").ToString())
                        ElseIf result("Fail") IsNot Nothing Then
                            Return (False, "Fail: " & result("Fail").ToString())
                        Else
                            Return (False, "Unknown response format: " & responseString)
                        End If
                    Else
                        ' Handle non-JSON response (e.g., blob data)
                        Dim rawBytes = Await response.Content.ReadAsByteArrayAsync()
                        Return (True, rawBytes) ' Return the raw data as a byte array
                    End If
                Else
                    ' Handle HTTP errors
                    Return (False, "HTTP error: " & response.StatusCode.ToString())
                End If
            End Using
        Catch ex As Exception
            ' Handle exceptions
            Return (False, "Error: " & ex.Message)
        End Try
    End Function
    Public Async Function FetchAppsAPI(params As Object, client As HttpClient) As Task(Of (Boolean, Object))
        Try

            Dim jsonData As String = JsonConvert.SerializeObject(params)
            Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")


            Using response As HttpResponseMessage = Await client.PostAsync(api_userstoreapps, content)
                If response.IsSuccessStatusCode Then

                    Dim responseString As String = Await response.Content.ReadAsStringAsync()


                    If response.Content.Headers.ContentType.MediaType = "application/json" Then

                        Dim result As JObject = JObject.Parse(responseString)

                        If result("Success") IsNot Nothing Then
                            Return (True, result("Success").ToString())
                        ElseIf result("Req") IsNot Nothing Then
                            Return (True, result("Req").ToString())
                        ElseIf result("Fail") IsNot Nothing Then
                            Return (False, "Fail: " & result("Fail").ToString())
                        Else
                            Return (False, "Unknown response format: " & responseString)
                        End If
                    Else
                        Return (False, "Unknown response 2: ")
                    End If
                Else
                    ' Handle HTTP errors
                    Return (False, "HTTP error: " & response.StatusCode.ToString())
                End If
            End Using
        Catch ex As Exception
            ' Handle exceptions
            Return (False, "Error: " & ex.Message)
        End Try
    End Function
    Public Async Function FetchUpdates(params As Object, client As HttpClient) As Task(Of (Boolean, Object))
        Try

            Dim jsonData As String = JsonConvert.SerializeObject(params)
            Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")


            Using response As HttpResponseMessage = Await client.PostAsync(api_updates, content)
                If response.IsSuccessStatusCode Then

                    Dim responseString As String = Await response.Content.ReadAsStringAsync()


                    If response.Content.Headers.ContentType.MediaType = "application/json" Then

                        Dim result As JObject = JObject.Parse(responseString)

                        If result("Success") IsNot Nothing Then
                            Return (True, result("Success").ToString())
                        ElseIf result("Req") IsNot Nothing Then
                            Return (True, result("Req").ToString())
                        ElseIf result("Fail") IsNot Nothing Then
                            Return (False, "Fail: " & result("Fail").ToString())
                        Else
                            Return (False, "Unknown response format: " & responseString)
                        End If
                    Else
                        Return (False, "Unknown response 2: ")
                    End If
                Else
                    ' Handle HTTP errors
                    Return (False, "HTTP error: " & response.StatusCode.ToString())
                End If
            End Using
        Catch ex As Exception
            ' Handle exceptions
            Return (False, "Error: " & ex.Message)
        End Try
    End Function
    Public Async Function FetchCustomAPI(params As Object, client As HttpClient) As Task(Of (Boolean, Object))
        Try
            ' Serialize request parameters
            Dim jsonData As String = JsonConvert.SerializeObject(params)
            Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")

            ' Send POST request
            Using response As HttpResponseMessage = Await client.PostAsync(api_usercustomapps, content)
                If response.IsSuccessStatusCode Then
                    Dim contentType = response.Content.Headers.ContentType.MediaType

                    If contentType = "application/json" Then
                        ' Handle JSON response
                        Dim responseString As String = Await response.Content.ReadAsStringAsync()
                        Dim result As JObject = JObject.Parse(responseString)

                        If result("Success") IsNot Nothing Then
                            Return (True, result("Success").ToString())
                        ElseIf result("Req") IsNot Nothing Then
                            Return (True, result("Req").ToString())
                        ElseIf result("Fail") IsNot Nothing Then
                            Return (False, "Fail: " & result("Fail").ToString())
                        Else
                            Return (False, "Unknown response format: " & responseString)
                        End If
                    Else

                        Return (False, "Unknown response 1: ")
                    End If
                Else
                    ' Handle HTTP errors
                    Return (False, "HTTP error: " & response.StatusCode.ToString())
                End If
            End Using
        Catch ex As Exception
            ' Handle exceptions
            Return (False, "Error: " & ex.Message)
        End Try
    End Function


    Public Async Function JoinServer(params As Object,
                                 client As HttpClient,
                                 Optional timeoutMilliseconds As Integer = 10000) As Task(Of String)
        Try
            ' Create a cancellation token with a timeout
            Using cts As New CancellationTokenSource(timeoutMilliseconds)

                ' Convert the parameters to a JSON string
                Dim json As String = JsonConvert.SerializeObject(params)
                Dim content As New StringContent(json, Encoding.UTF8, "application/json")

                ' Make the HTTP POST request with cancellation support
                Dim response As HttpResponseMessage = Await client.PostAsync(api_joinwebsocket, content, cts.Token)

                ' Check if the response is successful
                If Not response.IsSuccessStatusCode Then
                    Throw New Exception("Request failed")
                End If

                ' Get the result text
                Dim result As String = Await response.Content.ReadAsStringAsync()
                Return result

            End Using
        Catch ex As TaskCanceledException
            ' Handle timeout specifically
            Return "{""Fail"":""request timeout x89""}"
        Catch ex As Exception
            ' Log or handle other errors
            Return "{""Fail"":""unknown error x88""}"
        End Try
    End Function

    Public Function DecryptReply(ByVal prm_key As String,
                        ByVal prm_iv As String,
                        ByVal prm_text_to_decrypt As String) As String

        Dim sEncryptedString As String = prm_text_to_decrypt
        Dim key() As Byte = System.Text.Encoding.ASCII.GetBytes(prm_key)
        Dim IV() As Byte = System.Text.Encoding.ASCII.GetBytes(prm_iv)

        Dim decryptor As ICryptoTransform
        Dim fromEncrypt() As Byte

        Using myRijndael As New RijndaelManaged
            myRijndael.Padding = PaddingMode.PKCS7
            myRijndael.Mode = CipherMode.CBC
            myRijndael.KeySize = 256
            myRijndael.BlockSize = 128

            decryptor = myRijndael.CreateDecryptor(key, IV)

            Dim sEncrypted As Byte() = Convert.FromBase64String(sEncryptedString)

            Using msDecrypt As New MemoryStream(sEncrypted)
                Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
                    fromEncrypt = New Byte(sEncrypted.Length - 1) {}
                    Dim decryptedByteCount As Integer = csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length)
                    ReDim Preserve fromEncrypt(decryptedByteCount - 1)
                End Using
            End Using
        End Using

        ' Convert the byte array to a string using UTF-8 encoding and trim any null characters
        Return System.Text.Encoding.UTF8.GetString(fromEncrypt).TrimEnd(ControlChars.NullChar)
    End Function

    Public Async Function CommandStore(params As Dictionary(Of String, String), client As HttpClient) As Task(Of (Boolean, Object))
        Try
            ' Encode the parameters
            Dim encodedParams As New Dictionary(Of String, String)()
            For Each key As String In params.Keys
                encodedParams(key) = Uri.EscapeDataString(params(key))
            Next

            ' Convert the encoded parameters to JSON
            Dim jsonString As String = JsonConvert.SerializeObject(encodedParams)

            ' Create HttpClient and set up the request

            Dim content As New StringContent(jsonString, Encoding.UTF8, "application/json")
            Using response As HttpResponseMessage = Await client.PostAsync(api_fetchstore, content)
                If response.IsSuccessStatusCode Then
                    ' Read the response content
                    Dim responseString As String = Await response.Content.ReadAsStringAsync()

                    ' Check if the response is JSON
                    If response.Content.Headers.ContentType.MediaType = "application/json" Then
                        ' Parse the JSON response
                        Dim result As JObject = JObject.Parse(responseString)

                        ' Check for "Success", "Fail", or other keys
                        If result("Success") IsNot Nothing Then
                            Return (True, result("Success").ToString())
                        ElseIf result("Req") IsNot Nothing Then
                            Return (True, result("Req").ToString())
                        ElseIf result("Fail") IsNot Nothing Then
                            Return (False, "Fail: " & result("Fail").ToString())
                        Else
                            Return (False, "Unknown response format: " & responseString)
                        End If
                    Else

                        Return (False, "Unexpected reply: " & responseString) ' Return the raw data as a byte array
                    End If
                Else
                    ' Handle HTTP errors
                    Return (False, "HTTP error: " & response.StatusCode.ToString())
                End If
            End Using

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return (False, "Error: " & ex.Message)
        End Try
    End Function
End Module
