Module MyMsg
    Enum msgtype
        Confirm
        errors
        warning
    End Enum
    Public Function Show(title As String, msg As String, typ As msgtype, use_no As Boolean) As DialogResult
        Dim newbox As New MyMsgBox
        Select Case typ

            Case msgtype.warning
                newbox.toppanel.BackColor = Color.Orange
                newbox.msgtitle.ForeColor = Color.Orange
                newbox.okbtn.BackColor = Color.Orange
                newbox.okbtn.ForeColor = Color.Orange
                newbox.okbtn.RectColor = Color.Orange
                newbox.msgimg.Image = My.Resources.warning_img
            Case msgtype.errors
                newbox.toppanel.BackColor = Color.Red
                newbox.msgtitle.ForeColor = Color.Red
                newbox.okbtn.BackColor = Color.Red
                newbox.okbtn.ForeColor = Color.Red
                newbox.okbtn.RectColor = Color.Red

                newbox.msgimg.Image = My.Resources.error_img
            Case Else
                newbox.toppanel.BackColor = Color.DodgerBlue
                newbox.msgtitle.ForeColor = Color.DodgerBlue
                newbox.okbtn.RectColor = Color.DodgerBlue
                newbox.okbtn.ForeColor = Color.DodgerBlue
                newbox.msgimg.Image = My.Resources.ok
        End Select

        newbox.msgtitle.Text = title
        newbox.msgbody.Text = msg
        newbox.nobtn.Visible = use_no
        Return newbox.ShowDialog
    End Function
End Module
