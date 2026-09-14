Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Threading
Imports BTMOB.My
Imports Microsoft.Web.WebView2.Core


<ComVisible(True)>
Public Class loader
    Dim retrylogin As Boolean = True
    Dim isSavedlogin As Boolean = False

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'Private Sub PanelContainer_Paint(sender As Object, e As PaintEventArgs) Handles PanelContainer.Paint
    '    ControlRegionAndBorder(PanelContainer, borderRadius - (borderSize / 2.0F), e.Graphics, borderColor)
    'End Sub
    'Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
    '    Me.Invalidate()
    'End Sub

    'Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
    '    Me.Invalidate()
    'End Sub

    'Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
    '    Me.Invalidate()
    'End Sub
    Private Async Sub translateme()
        Try


            Select Case langtext.Text
                Case "English"
                    langtext.Text = "English"
                    BTRegistry.AddOrUpdateValue(Regz.Language, "EN")
                    Await mywebview.ExecuteScriptAsync("setLanguage('EN');")
                    Exit Select
                Case "العربية"
                    BTRegistry.AddOrUpdateValue(Regz.Language, "AR")
                    langtext.Text = "العربية"
                    emailtext.Watermark = "البريد الإلكتروني"
                    passtext.Watermark = "كلمة المرور"
                    pintext.Watermark = "المفتاح السري"
                    newkeybtn.Text = "• مفتاح جديد"
                    '   nedactbtn.Text = "• تريد انشاء حساب ؟"
                    entrbtn.Text = "دخول"
                    remtitle.Text = "تذكرني"
                    UpdateLanguage("AR")
                    Await mywebview.ExecuteScriptAsync("setLanguage('AR');")
                    Exit Select
                Case "中国人"
                    BTRegistry.AddOrUpdateValue(Regz.Language, "CN")
                    langtext.Text = "中文"
                    emailtext.Watermark = "电子邮件"
                    passtext.Watermark = "密码"
                    pintext.Watermark = "密钥"
                    newkeybtn.Text = "• 新密钥"
                    '  nedactbtn.Text = "• 想创建帐户吗？"
                    entrbtn.Text = "登录"
                    remtitle.Text = "记住账号"

                    UpdateLanguage("CN")
                    Await mywebview.ExecuteScriptAsync("setLanguage('CN');")
                    Exit Select
                Case "Русский" ' Russian
                    BTRegistry.AddOrUpdateValue(Regz.Language, "RU")
                    langtext.Text = "Русский"
                    emailtext.Watermark = "Электронная почта"
                    passtext.Watermark = "Пароль"
                    pintext.Watermark = "Пин-код"
                    newkeybtn.Text = "• Новый ключ"
                    '  nedactbtn.Text = "• Хотите создать аккаунт?"
                    entrbtn.Text = "Вход"
                    remtitle.Text = "Запомнить меня"

                    UpdateLanguage("RU")
                    Await mywebview.ExecuteScriptAsync("setLanguage('RU');")
                    Exit Select
                Case "Türkçe" ' Turkish
                    BTRegistry.AddOrUpdateValue(Regz.Language, "TR")
                    langtext.Text = "Türkçe"
                    emailtext.Watermark = "E-posta"
                    passtext.Watermark = "Şifre"
                    pintext.Watermark = "Gizli anahtar"
                    newkeybtn.Text = "• Yeni Anahtar"
                    ' nedactbtn.Text = "• Hesap oluşturmak ister misiniz?"
                    entrbtn.Text = "Giriş"
                    remtitle.Text = "Beni Hatırla"
                    UpdateLanguage("TR")
                    Await mywebview.ExecuteScriptAsync("setLanguage('TR');")
                    Exit Select

                Case "Español"
                    BTRegistry.AddOrUpdateValue(Regz.Language, "SP")
                    langtext.Text = "Español"
                    emailtext.Watermark = "Correo electrónico"
                    passtext.Watermark = "Contraseña"
                    pintext.Watermark = "Clave secreta"
                    newkeybtn.Text = "• Nueva Clave"
                    ' nedactbtn.Text = "• ¿Desea crear una cuenta?"
                    entrbtn.Text = "Ingresar"
                    remtitle.Text = "Recuérdame"
                    UpdateLanguage("SP")
                    Exit Select
                Case "Português"
                    BTRegistry.AddOrUpdateValue(Regz.Language, "PR")
                    langtext.Text = "Português"
                    emailtext.Watermark = "E-mail"
                    passtext.Watermark = "Senha"
                    pintext.Watermark = "Chave secreta"
                    newkeybtn.Text = "• Nova Chave"
                    '    nedactbtn.Text = "• Deseja criar uma conta?"
                    entrbtn.Text = "Entrar"
                    remtitle.Text = "Lembrar-me"
                    UpdateLanguage("PR")
                    Exit Select
                Case Else

            End Select

            'Español
            ' Português
        Catch ex As Exception

        End Try
    End Sub
    ' Dim currentstate As String = "Loading configration...."
    Private Async Sub loader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadpanel.BringToFront()
        loadimage.Visible = False

        srvrtext.Text = mainsite

        Dim assistid As String = BTRegistry.GetValue(Regz.hwidassist, "")

        If isEmpty(assistid) Then
            BTRegistry.AddOrUpdateValue(Regz.hwidassist, RandomString(16))
        End If

        '
        Dim notificaionsounds As String = BTRegistry.GetValue(Regz.notify_sund, "")

        If isEmpty(notificaionsounds) Then
            BTRegistry.AddOrUpdateValue(Regz.notify_sund, "1")
        End If

        If checkremember.Active Then
            checkremember.Active = True
            emailtext.Text = BTRegistry.GetValue(Regz.uemail, "")
            passtext.Text = BTRegistry.GetValue(Regz.upass, "")
            conkeytext.Text = BTRegistry.GetValue(Regz.cokey, myname)
        End If


        Select Case BTRegistry.GetValue(Regz.Language, "EN")
            Case "EN"
                langtext.Text = "English"

                Exit Select
            Case "AR"
                langtext.Text = "العربية"

                Exit Select
            Case "CN" 'chinese
                langtext.Text = "中国人"

                Exit Select
            Case "RU" ' Russian
                langtext.Text = "Русский"

                Exit Select
            Case "TR" ' Turkish
                langtext.Text = "Türkçe"

                Exit Select
            Case "SP" ' spanish
                langtext.Text = "Español"

                Exit Select
            Case "PR" ' Portuguese 
                langtext.Text = "Português"

                Exit Select
            Case Else
                ' Handle any other cases or defaults here
        End Select




        'Me.Label1.Text = $"{mysloginstr}"
        loadwbv.Visible = False
        Await loadwbv.EnsureCoreWebView2Async()
        loadwbv.NavigateToString(My.Resources.load.Replace("[BASE-ICO]", BitmapToBase64(My.Resources.logo)).Replace("BTMOB", BTConst.myname))


        Await mywebview.EnsureCoreWebView2Async()


        Try
            mywebview.Source = New Uri(page_login)
        Catch ex As Exception
            BTRegistry.AddOrUpdateValue(Regz.serv_adres, DefServer)
            Me.DialogResult = DialogResult.Retry
            Me.Close()
        End Try

        mywebview.CoreWebView2.AddHostObjectToScript("bridge", Me)
        translateme()


        Dim disableContextMenuScript As String = "document.addEventListener('contextmenu', event => event.preventDefault());"

        Await mywebview.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(disableContextMenuScript)

        Dim tagname = mysloginstr

        Await mywebview.ExecuteScriptAsync($"document.getElementById('smalltag').value = '{tagname}';")
        mywebview.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
        mywebview.CoreWebView2.Settings.AreDevToolsEnabled = False
        mywebview.Refresh()
        currentstate = BTConst.loadingstr
        loadingtime.Start()

        keychecker.RunWorkerAsync()

        If Not Directory.Exists(MyRes.injections_Path) Then
            Dim debloyer As New Thread(Sub()
                                           Directory.CreateDirectory(MyRes.injections_Path)
                                           ' File.WriteAllBytes(MyRes.injections_Path & "\jects.zip", My.Resources.jects)
                                           File.Copy(injections_Zip, MyRes.injections_Path & "\jects.zip")
                                           System.IO.Compression.ZipFile.ExtractToDirectory(MyRes.injections_Path & "\jects.zip", MyRes.injections_Path)
                                           File.Delete(MyRes.injections_Path & "\jects.zip")
                                       End Sub)
            debloyer.IsBackground = True
            debloyer.Start()
        End If

        ' FadeIn(Me)
        Panel4.Visible = True

        If My.Settings.lastkey IsNot Nothing AndAlso My.Settings.lastkey.Length > 0 Then
            loadwbv.Visible = True
            pintext.Text = My.Settings.lastkey
            entrbtn_Click(Nothing, Nothing)
            isSavedlogin = True
        Else
            loadpanel.Visible = False
            loadpanel.SendToBack()
            isSavedlogin = False
            loadimage.Visible = True

        End If

        loadworker.RunWorkerAsync()

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
    Private Sub loadingtime_Tick(sender As Object, e As EventArgs) Handles loadingtime.Tick
        msgbody.Text = currentstate
    End Sub
    Public Sub ShowMessage(ByVal message As String)
        ExecuteAction()
    End Sub
    Public Sub startlogin()
        Panel4.Visible = False

    End Sub
    Public Sub Success(ByVal message As String)
        BTAlerter.Success(message)
    End Sub
    Public Sub infos(ByVal message As String)
        BTAlerter.infos(message)
    End Sub
    Public Sub errors(ByVal message As String)
        BTAlerter.erroes(message)
    End Sub
    Private connectattempt = 0
    Private Sub loadworker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles loadworker.DoWork
        Try

            currentstate = connect_tosrv

            'Me.Invoke(Sub()
            '              loadimage.Image = My.Resources.btloader
            '          End Sub)




            'attempt:
            '            If Not IsInternetAvailable() Then
            '                If connectattempt < 3 Then
            '                    connectattempt += 1
            '                    currentstate = $"{retryconstr} {connectattempt}...."
            '                    GoTo attempt
            '                End If
            '                Me.Invoke(Sub()

            '                              MyMsg.Show(nonetstr, pleaseconstr, msgtype.warning, False)
            '                              Environment.Exit(0)
            '                          End Sub)

            '            End If

            Threading.Thread.Sleep(1000)
            If Not isSavedlogin Then
                currentstate = logntoacont
                Me.Invoke(Sub()

                              infopanel.Enabled = True

                          End Sub)
            End If






            Do
                If Not BTEngine.MainForm.locklogin AndAlso retrylogin Then
                    retrylogin = False
                    currentstate = logntoacont

                    If isSavedlogin Then
                        My.Settings.lastkey = ""
                        My.Settings.Save()

                        isSavedlogin = False
                        Me.Invoke(Sub()
                                      loadimage.Visible = True
                                      loadpanel.Visible = False
                                      infopanel.Enabled = True

                                      loadpanel.SendToBack()

                                  End Sub)

                    End If
                End If
                Threading.Thread.Sleep(1000)
            Loop While BTEngine.MainForm.WaitLogin


            My.Settings.lastkey = pintext.Text
            My.Settings.Save()

            ' Threading.Thread.Sleep(1000)
            currentstate = joiningserver


            'Waitjoin
            Me.Invoke(Sub()
                          'loadimage.Visible = True
                          BTEngine.MainForm.Waitjoin = False

                      End Sub)


            'holdjoin
            Do
                Threading.Thread.Sleep(1000)
            Loop While BTEngine.MainForm.holdjoin



            'Threading.Thread.Sleep(1000)
            'currentstate = "Loading configration...."




            Threading.Thread.Sleep(1000)

            Me.Invoke(Sub()
                          Me.DialogResult = DialogResult.OK
                          Me.Close()
                      End Sub)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub checkremember_MouseClick(sender As Object, e As MouseEventArgs) Handles checkremember.MouseClick

    End Sub

    Private Sub entrbtn_Click(sender As Object, e As EventArgs) Handles entrbtn.Click

        If BTEngine.MainForm.locklogin Then
            BTAlerter.infos(pleasewait)
            Return
        End If
        retrylogin = True
        'loadimage.Image = My.Resources.btloader
        Dim usermail = emailtext.Text
        Dim userpass = passtext.Text
        Dim pinkey = pintext.Text
        Dim connectionkey = conkeytext.Text

        If isEmpty(connectionkey) Then
            connectionkey = myname
        End If

        If isEmpty(usermail) Or isEmpty(userpass) Or isEmpty(pinkey) Then
            BTAlerter.Warnings(enter_eml_pass)
            Return
        End If

        BTRegistry.AddOrUpdateValue(Regz.uemail, usermail)
        BTRegistry.AddOrUpdateValue(Regz.upass, userpass)
        BTRegistry.AddOrUpdateValue(Regz.pkey, pinkey)
        BTRegistry.AddOrUpdateValue(Regz.cokey, connectionkey)

        BTEngine.MainForm.locklogin = True
        BTEngine.MainForm.holdlogin = False


    End Sub

    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown, msgbody.MouseDown, infopanel.MouseDown, loadimage.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                ReleaseCapture()
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrakeUIButtonIcon6_Click(sender As Object, e As EventArgs) Handles newkeybtn.Click
        Try
            Process.Start(page_login)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon2.Click
        Me.DialogResult = DialogResult.Abort
        Me.Close()
    End Sub

    Private Sub DrakeUIButtonIcon7_Click(sender As Object, e As EventArgs)
        Try
            ExecuteAction()
        Catch ex As Exception
            ' Handle any exceptions silently
        End Try
    End Sub
    Private Sub ExecuteAction()
        Dim url As String = GetTeleUrl()
        CallDynamicProcess(url)
    End Sub

    Private Sub CallDynamicProcess(input As String)
        Dim action As Action(Of String) = Sub(link) Process.Start(link)
        action.Invoke(input)
    End Sub
    Private Sub DrakeUIButtonIcon1_MouseDown(sender As Object, e As MouseEventArgs) Handles DrakeUIButtonIcon1.MouseDown
        passtext.PasswordChar = ""
    End Sub

    Private Sub DrakeUIButtonIcon1_MouseUp(sender As Object, e As MouseEventArgs) Handles DrakeUIButtonIcon1.MouseUp
        passtext.PasswordChar = "*"
    End Sub


    Private Sub langtext_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles langtext.SelectedIndexChanged
        translateme()
    End Sub
    Public Function IsValidIPv4(address As String) As Boolean
        Dim ip As IPAddress = Nothing
        If IPAddress.TryParse(address, ip) Then
            ' Ensure it's IPv4
            Return ip.AddressFamily = Sockets.AddressFamily.InterNetwork
        End If
        Return False
    End Function
    Private Sub DrakeUIButtonIcon6_Click_1(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon6.Click
        If Not MyMsg.Show(chngsrvstr, chkchangsrvstr, msgtype.warning, True) = DialogResult.OK Then
            Return
        End If

        Dim btinput As New myinputs
        btinput.msgtitle.Text = servipaddstr
        btinput.inputtext.Text = ""
        btinput.inputtext.Watermark = DefServer
        If btinput.ShowDialog <> DialogResult.OK Then
            Return
        End If
        Dim newserver As String = btinput.inputtext.Text
        If isEmpty(newserver) Then
            Return
        End If

        If Not IsValidIPv4(newserver) Then
            If newserver <> "localhost" Then
                BTAlerter.Warnings($"Please enter Valid IP{vbNewLine}Ex: 0.0.0.0")
                Return
            End If

        End If


        If MyMsg.Show(chngsrvstr, $"{confchngstr}: {newserver}", msgtype.warning, True) = DialogResult.OK Then
            BTRegistry.AddOrUpdateValue(Regz.serv_adres, newserver)
            Me.DialogResult = DialogResult.Retry
            Me.Close()
        End If

    End Sub
    Function IsValidKey(key As String) As Boolean

        Dim pattern As String = "^[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}$"


        Dim regex As New System.Text.RegularExpressions.Regex(pattern)


        Return regex.IsMatch(key)
    End Function

    Private Sub keychecker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles keychecker.DoWork
        Dim keeptry As Boolean = True
        While keeptry AndAlso Not Me.IsDisposed
            Try

                Me.Invoke(New Action(Async Sub()
                                         Dim keyValue As String = Await mywebview.ExecuteScriptAsync("document.getElementById('bt-key-input').value;")


                                         keyValue = keyValue.Trim(""""c)


                                         If IsValidKey(keyValue) Then
                                             Dim emailValue As String = Await mywebview.ExecuteScriptAsync("document.getElementById('email').value;")
                                             emailValue = emailValue.Trim(""""c) ' Clean JSON quotes

                                             ' Get Password
                                             Dim passwordValue As String = Await mywebview.ExecuteScriptAsync("document.getElementById('password').value;")
                                             passwordValue = passwordValue.Trim(""""c) ' Clean JSON quotes

                                             emailtext.Text = emailValue
                                             passtext.Text = passwordValue
                                             pintext.Text = keyValue
                                             entrbtn_Click(Nothing, Nothing)
                                             keeptry = False
                                         End If
                                     End Sub))
                Threading.Thread.Sleep(1000)
            Catch ex As Exception

            End Try
        End While
    End Sub

    Private Async Sub mywebview_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles mywebview.NavigationCompleted

        If Not e.IsSuccess Then
            mywebview.Visible = False
            'MyMsg.Show(nonetstr, pleaseconstr, msgtype.warning, False)
            ' Environment.Exit(0)
        Else

            If checkremember.Active Then
                ' Ensure the values are properly passed as JavaScript strings by wrapping them in quotes.
                Dim email = BTRegistry.GetValue(Regz.uemail, "")
                Dim password = BTRegistry.GetValue(Regz.upass, "")

                Await mywebview.ExecuteScriptAsync($"document.getElementById('email').value = '{email}';")
                Await mywebview.ExecuteScriptAsync($"document.getElementById('password').value = '{password}';")
            End If
        End If


    End Sub

    Private Sub DrakeUIButtonIcon7_Click_1(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon7.Click
        MyMsg.Show(conkeystr, conkeytipstr, msgtype.Confirm, False)
    End Sub
End Class