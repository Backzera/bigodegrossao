Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.IO.Compression
Imports System.Net.Http
Imports System.Text

Public Class updatewindow
    Public nextkey As String
    Public httpClient As HttpClient
    Private Async Sub updateworker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles updateworker.DoWork
        Try
            Threading.Thread.Sleep(1000)
            logtext("Connecting")
            Dim Randomkey As String = RandomString(32)
            Dim params = New With {
                 Key .subcom = "download",
                 Key .ran_key = Randomkey,
                 Key .chk = nextkey
            }
            Dim result = Await FetchUpdate(params, httpClient, api_updates)

            If result.Item1 Then
                If TypeOf result.Item2 Is Byte() Then

                    Me.Invoke(Sub()
                                  BTAlerter.Success("Download completed")
                              End Sub)
                    logtext("Extracting Data")
                    Dim updatebyts As Byte() = DirectCast(result.Item2, Byte())
                    'updatebyts is data for update.zip fetched from server
                    ' Define paths
                    Dim tempPath As String = Path.Combine(Path.GetTempPath(), "bt_update.zip")
                    Dim extractPath As String = Path.Combine(Path.GetTempPath(), "bt_update")

                    ' Save byte array to a zip file
                    File.WriteAllBytes(tempPath, updatebyts)

                    ' Ensure extraction folder exists
                    If Directory.Exists(extractPath) Then
                        Directory.Delete(extractPath, True)
                    End If
                    Directory.CreateDirectory(extractPath)

                    ' Extract zip contents
                    ZipFile.ExtractToDirectory(tempPath, extractPath)

                    ' Define the batch script path
                    Dim batchFilePath As String = Path.Combine(Path.GetTempPath(), "update_script.bat")

                    ' Get current application directory
                    Dim currentDir As String = AppDomain.CurrentDomain.BaseDirectory

                    ' Create batch script content
                    Dim batchContent As String = $"
            @echo off
            title {myname} Update
            echo.  
            echo.
            echo ================ {myname} Update ================
            echo.
            echo [INFO] starting update...
            timeout /t 5 /nobreak >nul
            echo [INFO] Copying updated files...
            xcopy ""{extractPath}\*"" ""{currentDir}"" /E /H /C /Y
            timeout /t 3 /nobreak >nul
            echo [INFO] Launching the application...
            start """" ""{currentDir}{Path.GetFileName(Application.ExecutablePath)}""
            timeout /t 2 /nobreak >nul
            exit
             "

                    ' Write the batch script file
                    File.WriteAllText(batchFilePath, batchContent)

                    ' Start the batch script
                    Dim processInfo As New ProcessStartInfo()
                    processInfo.FileName = batchFilePath
                    processInfo.CreateNoWindow = False

                    processInfo.UseShellExecute = True

                    logtext("Update complete")


                    For index = 4 To 1 Step -1
                        Threading.Thread.Sleep(1000)
                        logtext($"{myname} will restart after {index} Seconds.")
                    Next
                    Threading.Thread.Sleep(1000)
                    ' Exit the application after launching the update script
                    Process.Start(processInfo)
                    Environment.Exit(0)

                Else
                    'BTAlerter.erroes("Response: " & result.Item2.ToString())
                    logtext(result.Item2.ToString())
                End If
            Else
                'BTAlerter.erroes("Error: " & result.Item2.ToString())
                logtext(result.Item2.ToString())
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Async Function FetchUpdate(params As Object, client As HttpClient, urlapi As String) As Task(Of (Boolean, Object))
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
                        Dim bufferSize As Integer = 1024 * 1024 ' 1 MB buffer
                        Dim bufferdown(bufferSize - 1) As Byte
                        Dim chunks As New List(Of Byte())

                        logtext("Downloading")
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

    Private Sub updatewindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        logtext("Starting")
        updateworker.RunWorkerAsync()
    End Sub

    Private Sub logtext(str As String)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Sub()
                                     logtext(str)
                                 End Sub))
            Return
        Else
            loglabel.AppendText($"• {str} {vbNewLine}")
        End If

    End Sub

End Class