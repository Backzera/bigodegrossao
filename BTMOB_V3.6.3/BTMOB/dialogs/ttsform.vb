Imports System.Web.UI.WebControls

Public Class ttsform
    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")
            Case "AR"
                msgtitle.Text = "نص الى كلام" 'Text-To-Speech
                labeltext.Text = "الرسالة التي سيتم التحدث بها عبر الهاتف" 'message that will be spoken through phone
                Exit Select

            Case "CN" ' Chinese
                msgtitle.Text = "文字转语音"
                labeltext.Text = "将在电话中朗读的消息"
                Exit Select

            Case "RU" ' Russian
                msgtitle.Text = "Текст в речь"
                labeltext.Text = "Сообщение, которое будет озвучено по телефону"
                Exit Select

            Case "TR" ' Turkish
                msgtitle.Text = "Metinden Sese"
                labeltext.Text = "Telefonla okunacak mesaj"
                Exit Select

            Case "SP" ' Spanish
                msgtitle.Text = "Texto a voz"
                labeltext.Text = "Mensaje que se leerá por teléfono"
                Exit Select

            Case "PR" ' Brazilian Portuguese
                msgtitle.Text = "Texto para fala"
                labeltext.Text = "Mensagem que será falada por telefone"
                Exit Select

            Case Else
                ' Handle any other cases or defaults here
        End Select
    End Sub

    Private Sub okbtn_Click(sender As Object, e As EventArgs) Handles okbtn.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub nobtn_Click(sender As Object, e As EventArgs) Handles nobtn.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub

    Private Sub ttsform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        translateme()
    End Sub
End Class