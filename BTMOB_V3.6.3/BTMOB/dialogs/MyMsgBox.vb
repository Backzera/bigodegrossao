Public Class MyMsgBox
    Private Sub okbtn_Click(sender As Object, e As EventArgs) Handles okbtn.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub nobtn_Click(sender As Object, e As EventArgs) Handles nobtn.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub

    Private Sub msgbody_MouseDown(sender As Object, e As MouseEventArgs) Handles toppanel.MouseDown, Panel3.MouseDown, Panel2.MouseDown, Panel1.MouseDown, msgtitle.MouseDown, msgimg.MouseDown, msgbody.MouseDown, DrakeWidth_W4.MouseDown, DrakeWidth_W3.MouseDown, DrakeWidth_W2.MouseDown, DrakeWidth_W1.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                ReleaseCapture()
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class