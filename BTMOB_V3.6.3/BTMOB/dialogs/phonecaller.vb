Imports System.Net.Sockets
Imports System.Runtime.InteropServices

Public Class phonecaller

    Public Btcli As BTClient


    <ComVisible(True)>
    Public Class mybridge
        Public mainform As phonecaller
        Sub New(minme As phonecaller)
            mainform = minme
        End Sub

        <DispId(1)>
        Public Function callit(thenum As String)
            ' MsgBox(clientid)
            mainform.Invoke(Sub()
                                mainform.callnumber(thenum)
                            End Sub)
            Return ""

        End Function
        <DispId(2)>
        Public Function alertit(thenum As String)
            ' MsgBox(clientid)
            mainform.Invoke(Sub()
                                mainform.alertit(thenum)
                            End Sub)
            Return ""

        End Function
        <DispId(3)>
        Public Function getClipboardText() As String
            Try
                Return System.Windows.Forms.Clipboard.GetText()
            Catch ex As Exception
                Return ""
            End Try
        End Function

    End Class

    Private Async Sub phonecaller_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await numview.EnsureCoreWebView2Async()


        AddHandler numview.NavigationCompleted, AddressOf WebView_NavigationCompleted


        numview.NavigateToString(My.Resources.dailer)

        Dim term As New mybridge(Me)
        numview.CoreWebView2.AddHostObjectToScript("mybridge", term)

        numview.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
        numview.CoreWebView2.Settings.AreDevToolsEnabled = False
        myico.Image = Btcli.wallpaper
        mytitle.Text = Btcli.name
    End Sub
    Private Sub WebView_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs)
        ' loadall()

    End Sub

    Public Sub callnumber(num As String)
        ' MsgBox("call " + num)
        Dim chatData As New Dictionary(Of String, Object) From {
                                 {"msg", "tols"},
                                 {"cas", "cp"},
                                 {"extrs", num}
        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

    End Sub
    Public Sub alertit(msg As String)
        BTAlerter.infos(msg)
    End Sub

    Private Sub closbtn_Click(sender As Object, e As EventArgs) Handles closbtn.Click
        Me.Close()
    End Sub
    Dim keepmeto As Boolean = True
    Private Sub pinbtn_Click(sender As Object, e As EventArgs) Handles pinbtn.Click
        If keepmeto Then
            '  button1.Text = "yes on top"
            pinbtn.ForeColor = Color.DeepSkyBlue
            pinbtn.RectColor = Color.DeepSkyBlue
            Dim HwndTopmost As IntPtr = New IntPtr(-1)
            SetWindowPos(Me.Handle, HwndTopmost, 0, 0, 0, 0, TOPMOST_FLAGS)
            keepmeto = False
        Else
            '  button1.Text = "not on top"
            pinbtn.ForeColor = Color.White
            pinbtn.RectColor = Color.Gray
            Dim HwndTopmost As IntPtr = New IntPtr(-2)
            SetWindowPos(Me.Handle, HwndTopmost, 0, 0, 0, 0, TOPMOST_FLAGS)
            keepmeto = True
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
End Class