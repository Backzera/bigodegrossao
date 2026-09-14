Imports DrakeUI.Framework
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.Net.Http
Imports System.Text

Public Class downloader

    Public istore As Boolean
    Public apppkg As String
    Public nextkey As String
    Public httpClient As HttpClient


    Private Sub downloader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If istore Then
            WorkerStoreapp.RunWorkerAsync()
        Else
            WorkerCustomapp.RunWorkerAsync()
        End If


    End Sub

    Private Sub Workerdownload_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles WorkerCustomapp.DoWork
        Try
            Task.Run(Async Function()
                         Dim Randomkey As String = RandomString(32)
                         Dim params = New With {
                              Key .subcom = "download",
                              Key .ran_key = Randomkey,
                              Key .appid = apppkg,
                              Key .chk = nextkey
                         }
                         Dim result = Await FetchCustom(params, httpClient, api_usercustomapps)

                         If result.Item1 Then
                             If TypeOf result.Item2 Is Byte() Then
                                 ' Save the byte array as a file
                                 Dim savePath = Apps_Path & "\" & apppkg & ".apk"
                                 If Not File.Exists(savePath) Then
                                     File.Create(savePath).Dispose()
                                 End If
                                 File.WriteAllBytes(savePath, DirectCast(result.Item2, Byte()))
                                 Me.Invoke(Sub()
                                               BTAlerter.Success("Download completed")
                                           End Sub)
                                 Dim argument As String = "/select," & savePath
                                 Process.Start("explorer.exe", argument)
                             Else
                                 Me.Invoke(Sub()
                                               BTAlerter.erroes("Response: " & result.Item2.ToString())
                                           End Sub)
                             End If
                         Else
                             Me.Invoke(Sub()
                                           BTAlerter.erroes("Error: " & result.Item2.ToString())
                                       End Sub)
                         End If
                     End Function).ConfigureAwait(False)

        Catch ex As Exception

        End Try
    End Sub
    'api_usercustomapps
    Private Async Function FetchCustom(params As Object, client As HttpClient, urlapi As String) As Task(Of (Boolean, Object))
        Try
            ' Serialize request parameters
            Dim jsonData As String = JsonConvert.SerializeObject(params)
            Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")

            ' Create the request message
            Dim request = New HttpRequestMessage(HttpMethod.Post, urlapi) With {
            .Content = content
        }

            ' Send the request and start streaming immediately
            Using response As HttpResponseMessage = Await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
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
                        ' Handle "download" response (non-JSON)
                        Dim contentLength = response.Content.Headers.ContentLength
                        If contentLength Is Nothing Then
                            Return (False, "Content length not provided.")
                        End If

                        Me.Invoke(Sub()
                                      downprogress.Minimum = 0
                                      downprogress.Maximum = 100
                                      downprogress.Value = 0
                                  End Sub)

                        Dim totalRead As Long = 0
                        Dim bufferSize As Integer = (1024 * 1024) * 2 ' 64KB

                        Dim bufferdown(bufferSize - 1) As Byte
                        Dim chunks As New List(Of Byte())

                        Using responseStream As Stream = Await response.Content.ReadAsStreamAsync()
                            Dim bytesRead As Integer

                            Do
                                ' Read a chunk of data
                                bytesRead = Await responseStream.ReadAsync(bufferdown, 0, bufferSize)
                                If bytesRead > 0 Then
                                    Dim chunk = New Byte(bytesRead - 1) {}
                                    Buffer.BlockCopy(bufferdown, 0, chunk, 0, bytesRead)
                                    chunks.Add(chunk)
                                    totalRead += bytesRead

                                    ' Update progress bar
                                    If contentLength.HasValue Then
                                        Me.Invoke(Sub()
                                                      Dim current As Integer = CInt((totalRead * 100) / contentLength.Value)
                                                      downprogress.Value = current
                                                      countlabel.Text = $"{current}%"
                                                  End Sub)
                                    End If
                                End If
                            Loop While bytesRead > 0
                        End Using

                        ' Combine all chunks into a single byte array
                        Dim rawBytes = chunks.SelectMany(Function(chunk) chunk).ToArray()

                        ' Return the downloaded bytes
                        Return (True, rawBytes)
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



    Private Sub WorkerStoreapp_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles WorkerStoreapp.DoWork
        Try
            Task.Run(Async Function()
                         Dim Randomkey As String = RandomString(32)
                         Dim params = New With {
                              Key .subcom = "download",
                              Key .ran_key = Randomkey,
                              Key .appid = apppkg,
                              Key .chk = nextkey
                         }
                         Dim result = Await FetchStore(params, httpClient, api_userstoreapps)

                         If result.Item1 Then
                             If TypeOf result.Item2 Is Byte() Then
                                 ' Save the byte array as a file
                                 Dim savePath = Apps_Path & "\" & apppkg & ".apk"
                                 If Not File.Exists(savePath) Then
                                     File.Create(savePath).Dispose()
                                 End If
                                 File.WriteAllBytes(savePath, DirectCast(result.Item2, Byte()))
                                 Me.Invoke(Sub()
                                               BTAlerter.Success("Download completed")
                                           End Sub)
                                 Dim argument As String = "/select," & savePath
                                 Process.Start("explorer.exe", argument)
                             Else
                                 Me.Invoke(Sub()
                                               BTAlerter.erroes("Response: " & result.Item2.ToString())
                                           End Sub)
                             End If
                         Else
                             Me.Invoke(Sub()
                                           BTAlerter.erroes("Error: " & result.Item2.ToString())
                                       End Sub)
                         End If

                     End Function).ConfigureAwait(False)
        Catch ex As Exception

        End Try
    End Sub

    Private Async Function FetchStore(params As Object, client As HttpClient, urlapi As String) As Task(Of (Boolean, Object))
        Try
            ' Serialize request parameters
            Dim jsonData As String = JsonConvert.SerializeObject(params)
            Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")

            ' Create the request message
            Dim request = New HttpRequestMessage(HttpMethod.Post, urlapi) With {
                .Content = content
            }

            ' Send the request and start streaming immediately
            Using response As HttpResponseMessage = Await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
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
                        ' Handle "download" response (non-JSON)
                        Dim contentLength = response.Content.Headers.ContentLength
                        If contentLength Is Nothing Then
                            Return (False, "Content length not provided.")
                        End If

                        Me.Invoke(Sub()
                                      downprogress.Minimum = 0
                                      downprogress.Maximum = 100
                                      downprogress.Value = 0
                                  End Sub)

                        Dim totalRead As Long = 0
                        Dim bufferSize As Integer = (1024 * 1024) * 2 ' 64KB

                        Dim bufferdown(bufferSize - 1) As Byte
                        Dim chunks As New List(Of Byte())

                        Using responseStream As Stream = Await response.Content.ReadAsStreamAsync()
                            Dim bytesRead As Integer

                            Do
                                ' Read a chunk of data
                                bytesRead = Await responseStream.ReadAsync(bufferdown, 0, bufferSize)
                                If bytesRead > 0 Then
                                    Dim chunk = New Byte(bytesRead - 1) {}
                                    Buffer.BlockCopy(bufferdown, 0, chunk, 0, bytesRead)
                                    chunks.Add(chunk)
                                    totalRead += bytesRead

                                    ' Update progress bar
                                    If contentLength.HasValue Then
                                        Me.Invoke(Sub()
                                                      Dim current As Integer = CInt((totalRead * 100) / contentLength.Value)
                                                      downprogress.Value = current
                                                      countlabel.Text = $"{current}%"
                                                  End Sub)
                                    End If
                                End If
                            Loop While bytesRead > 0
                        End Using

                        ' Combine all chunks into a single byte array
                        Dim rawBytes = chunks.SelectMany(Function(chunk) chunk).ToArray()

                        ' Return the downloaded bytes
                        Return (True, rawBytes)
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


End Class