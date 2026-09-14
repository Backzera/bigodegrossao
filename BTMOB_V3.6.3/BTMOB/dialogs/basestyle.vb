Public Class basestyle
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, myscr.MouseDown, myico.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                ReleaseCapture()
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Dim Mx As Integer
    Dim Sw As Integer
    Dim movX As Boolean
    Private Sub DrakeWidth_W7_MouseDown(sender As Object, e As MouseEventArgs) Handles DrakeWidth_W7.MouseDown
        movX = True
        Mx = MousePosition.X
        Sw = Width
    End Sub

    Private Sub DrakeWidth_W7_MouseMove(sender As Object, e As MouseEventArgs) Handles DrakeWidth_W7.MouseMove
        If movX = True Then
            Width = MousePosition.X - Mx + Sw

        End If
    End Sub

    Private Sub DrakeWidth_W7_MouseUp(sender As Object, e As MouseEventArgs) Handles DrakeWidth_W7.MouseUp
        movX = False

    End Sub
    Dim Myyy As Integer
    Dim Sh As Integer
    Dim movY As Boolean
    Private Sub DrakeWidth_W8_MouseDown(sender As Object, e As MouseEventArgs) Handles DrakeWidth_W8.MouseDown
        movY = True
        Myyy = MousePosition.Y
        Sh = Height
    End Sub

    Private Sub DrakeWidth_W8_MouseMove(sender As Object, e As MouseEventArgs) Handles DrakeWidth_W8.MouseMove
        If movY = True Then
            Height = MousePosition.Y - Myyy + Sh
        End If
    End Sub

    Private Sub DrakeWidth_W8_MouseUp(sender As Object, e As MouseEventArgs) Handles DrakeWidth_W8.MouseUp
        movY = False

    End Sub

    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles closbtn.Click
        Me.Close()
    End Sub

    Private Sub DrakeUIButtonIcon6_Click(sender As Object, e As EventArgs) Handles minibtn.Click
        Me.WindowState = WindowState.Minimized
    End Sub


    Dim keepmeto As Boolean = True
    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles pinbtn.Click
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

    Private Sub basestyle_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If myscr.Image IsNot Nothing Then
            myscr.Image = Nothing
        End If

        If myico.Image IsNot Nothing Then
            myico.Image = Nothing
        End If
    End Sub
End Class