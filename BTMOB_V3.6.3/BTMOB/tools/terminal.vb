Imports System.Net.Sockets
Imports DrakeUI.Framework

Public Class terminal
    Public BTcli As BTClient
    Public androidver As String = ""
    Private Async Sub terminal_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Await termview.EnsureCoreWebView2Async()

        termview.NavigateToString(My.Resources.terminal.Replace("Starting...", androidver))
        Dim term As New Jsterminal(Me)
        termview.CoreWebView2.AddHostObjectToScript("jsterminal", term)
        termview.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
        termview.CoreWebView2.Settings.AreDevToolsEnabled = False

        myico.Image = BTcli.wallpaper
        mytitle.Text = trminalstr
    End Sub
    Public Sub commandterminal(comstr As String)
        Dim chatData As New Dictionary(Of String, Object) From {
                                {"msg", "trm"},'terminal
                                {"cas", "e"},
                                {"extrs", ToBase64(comstr)}
        }
        BTEngine.commands(chatData, BTcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub
    Public Async Sub printterminal(result As String)
        Try
            'Dim safeResult = result.Replace("\"", " \\ ").Replace("'", "\'")
            Dim js = $"receiveCommandResult(`{result}`)"

            Await Me.termview.CoreWebView2.ExecuteScriptAsync(js)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub terminal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim chatData As New Dictionary(Of String, Object) From {
                               {"msg", "trm"},'terminal
                               {"cas", "c"}
       }
        BTEngine.commands(chatData, BTcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub
End Class