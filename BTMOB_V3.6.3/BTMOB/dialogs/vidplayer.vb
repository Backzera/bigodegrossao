Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Newtonsoft.Json.Linq

Public Class vidplayer
    Private websockclient As WebSocketClient = Nothing
    Private targetfilepath As String = ""

    Private targetfilename As String = ""
    Private mobid As String = ""
    Private addressip As String = ""
    Private SecoundIDF As String = ""
    Sub New(Tpath As String, Tname As String, idmob As String, adrs As String, sidf As String)

        ' This call is required by the designer.
        InitializeComponent()
        targetfilepath = Tpath
        targetfilename = Tname
        mobid = idmob
        addressip = adrs
        SecoundIDF = sidf
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub vidplayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim callerthred As New Threading.Thread(Sub()
                                                    loadvideo()
                                                End Sub)
        callerthred.IsBackground = True
        callerthred.Start()
    End Sub

    Private Async Sub loadvideo()
        Try
            Dim datajoin As String = Await JoinServer(New With {
                               .case = "join",
                               .ping = "0",
                               .ismain = "0",
                               .chk = BTEngine.MainForm.Mainnextkey
                            }, BTEngine.MainForm.MainhttpClient)


            Dim socketidf As String = SecoundIDF

            Dim result As JObject = JObject.Parse(datajoin)
            If result("Success") IsNot Nothing Then
                Dim datastr As String = result("Success").ToString.Trim("""")
                Log_d("Cli IDF websock", datastr)
                'Main_IDF = datastr

                websockclient = New WebSocketClient(vidplerstr, addressip)

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
                        .subcommand = "V",
                        .newpth = targetfilepath,
                        .ply = "1",
                        .skidf = socketidf,
                        .fstate = "true"
                         }

            Dim commandstr As String = FormatCommand("files", data)
            Dim chatData As New Dictionary(Of String, Object) From {
            {"msg", wrk},
            {"cmnd", commandstr}
            }
            BTEngine.commands(chatData, mobid, websockclient)

        Catch ex As Exception
            MyMsg.Show("Error load vide", ex.Message, msgtype.errors, False)
            Me.Invoke(Sub()
                          Me.Close()
                      End Sub)
        End Try
    End Sub

    Private Sub vidplayer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If websockclient IsNot Nothing Then
            websockclient.Disconnect(vidplerstr, addressip)
            websockclient = Nothing
        End If
    End Sub
End Class