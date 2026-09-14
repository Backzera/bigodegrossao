Imports System.IO
Imports System.Net.Http
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports DrakeUI.Framework
Imports Newtonsoft.Json.Linq

Public Class BTApps
    Private nextkey As String = "null"
    Private httpClient As HttpClient

    Private IamAlive As Boolean = True


    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                downbtn.Text = "تحميل"
                dellall.Text = "حذف"
                tabsapps.TabPages(0).Text = "المتجر"
                tabsapps.TabPages(1).Text = "مخصص"
                DrakeUIButtonIcon1.Text = "إنشاء تطبيق"
                Exit Select
            Case "CN" ' Chinese
                downbtn.Text = "下载"
                dellall.Text = "删除"
                tabsapps.TabPages(0).Text = "商店"
                tabsapps.TabPages(1).Text = "自定义"
                DrakeUIButtonIcon1.Text = "创建应用"
                Exit Select
            Case "RU" ' Russian
                downbtn.Text = "Скачать"
                dellall.Text = "Удалить"
                tabsapps.TabPages(0).Text = "Магазин"
                tabsapps.TabPages(1).Text = "Пользовательский"
                DrakeUIButtonIcon1.Text = "Создать приложение"
                Exit Select
            Case "TR" ' Turkish
                downbtn.Text = "İndir"
                dellall.Text = "Sil"
                tabsapps.TabPages(0).Text = "Mağaza"
                tabsapps.TabPages(1).Text = "Özel"
                DrakeUIButtonIcon1.Text = "Uygulama Oluştur"
                Exit Select
            Case "SP" ' Spanish
                downbtn.Text = "Descargar"
                dellall.Text = "Eliminar"
                tabsapps.TabPages(0).Text = "Tienda"
                tabsapps.TabPages(1).Text = "Privado"
                DrakeUIButtonIcon1.Text = "Crear Aplicación"
                Exit Select

            Case "PR" ' Brazilian Portuguese
                downbtn.Text = "Baixar"
                dellall.Text = "Excluir"
                tabsapps.TabPages(0).Text = "Loja"
                tabsapps.TabPages(1).Text = "Privado"
                DrakeUIButtonIcon1.Text = "Criar Aplicativo"
                Exit Select

            Case Else
                ' Handle any other cases or defaults here
        End Select
    End Sub

    Sub New(nk As String, htpcli As HttpClient)

        ' This call is required by the designer.
        InitializeComponent()
        nextkey = nk
        httpClient = htpcli
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub BTApps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Directory.Exists(StoreCash_Path) Then
            Directory.CreateDirectory(StoreCash_Path)
        End If
        Me.mytitle.Text = AppsManagerstr
        IamAlive = True
        translateme()
        FetchStoreWrkr.RunWorkerAsync()
        FetchCustomwrkr.RunWorkerAsync()
    End Sub

    Private Sub refpasses_Click(sender As Object, e As EventArgs) Handles downbtn.Click

        Dim downform As downloader = Nothing
        Dim appico As Bitmap = Nothing
        Dim apppkg As String = Nothing
        Dim appstate As String = Nothing

        Select Case tabsapps.SelectedTab.TabIndex
            Case 0
                If Not DGVSTORE.Rows.Count > 0 Then
                    BTAlerter.infos("No Apps found , try create new")
                    Return
                End If

                If Not DGVSTORE.SelectedRows.Count > 0 Then
                    BTAlerter.infos("Select app to download")
                    Return
                End If
                downform = New downloader
                downform.istore = True
                appico = DGVSTORE.SelectedRows(0).Cells(0).Value
                apppkg = DGVSTORE.SelectedRows(0).Cells(2).Value
                downform.mytitle.Text = Downloadingstr & " | " & storeappstr & " | " & apppkg

                appstate = DGVSTORE.SelectedRows(0).Cells(5).Value



            Case 1
                If Not DGVCUSTOM.Rows.Count > 0 Then
                    BTAlerter.infos("No Apps found , try create new")
                    Return
                End If

                If Not DGVCUSTOM.SelectedRows.Count > 0 Then
                    BTAlerter.infos("Select app to download")
                    Return
                End If
                downform = New downloader
                downform.istore = False
                appico = DGVCUSTOM.SelectedRows(0).Cells(0).Value
                apppkg = DGVCUSTOM.SelectedRows(0).Cells(2).Value
                downform.mytitle.Text = Downloadingstr & " | " & customappstr & " | " & apppkg

                appstate = DGVCUSTOM.SelectedRows(0).Cells(4).Value

            Case Else
                Exit Sub
        End Select

        If downform IsNot Nothing Then

            If appstate = "onbuild" Then
                BTAlerter.infos(buildnowstr)
                Return
            End If

            If appstate = "failed" Then
                BTAlerter.infos(buildfailstr)
                deleteapp()
                Return
            End If

            If appstate = "finished" Then
                downform.apppkg = apppkg
                downform.httpClient = httpClient
                downform.nextkey = nextkey
                downform.PictureBox1.Image = appico

                downform.Show()
            End If


        End If



    End Sub

    Private Sub dellall_Click(sender As Object, e As EventArgs) Handles dellall.Click
        deleteapp()
    End Sub
    Private Async Sub deleteapp()
        Dim apppkg As String = Nothing
        Dim istore As Boolean = Nothing

        Select Case tabsapps.SelectedTab.TabIndex
            Case 0
                If Not DGVSTORE.Rows.Count > 0 Then
                    BTAlerter.infos("No Apps found , try create new")
                    Return
                End If

                If Not DGVSTORE.SelectedRows.Count > 0 Then
                    BTAlerter.infos("Select app to download")
                    Return
                End If

                apppkg = DGVSTORE.SelectedRows(0).Cells(2).Value

                istore = True
            Case 1
                If Not DGVCUSTOM.Rows.Count > 0 Then
                    BTAlerter.infos("No Apps found , try create new")
                    Return
                End If

                If Not DGVCUSTOM.SelectedRows.Count > 0 Then
                    BTAlerter.infos("Select app to download")
                    Return
                End If
                apppkg = DGVCUSTOM.SelectedRows(0).Cells(2).Value
                istore = False
            Case Else
                Exit Sub
        End Select

        If apppkg IsNot Nothing Then
            Dim Randomkey As String = RandomString(32)
            Dim params = New With {
                 Key .subcom = "delete",
                 Key .ran_key = Randomkey,
                 Key .appid = apppkg,
                 Key .chk = nextkey
            }

            Dim result As (Boolean, Object)
            If istore Then
                result = Await FetchAppsAPI(params, httpClient)
            Else
                result = Await FetchCustomAPI(params, httpClient)
            End If
            If result.Item1 Then
                BTAlerter.Success(result.Item2)
                If istore Then
                    DGVSTORE.Rows.Remove(DGVSTORE.SelectedRows(0))
                Else
                    DGVCUSTOM.Rows.Remove(DGVCUSTOM.SelectedRows(0))
                End If
            Else
                BTAlerter.erroes(result.Item2)
            End If
        End If
    End Sub
    Private Async Sub fetchworker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles FetchStoreWrkr.DoWork
        Dim Randomkey As String = RandomString(32)
        Dim curntTabname As String = tabsapps.TabPages(0).Text
        While IamAlive
            Try

                Dim params = New With {
                     Key .subcom = "load",
                     Key .ran_key = Randomkey,
                     Key .chk = nextkey
                }


                Dim result = Await FetchAppsAPI(params, httpClient)


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
                            Dim rowsToAdd As New List(Of Tuple(Of Bitmap, String, String, String, String, String, String))

                            For Each row As JObject In jsonArray
                                Dim app_id As String = row("app_id").ToString()
                                Dim app_name As String = If(row("app_name")?.ToString(), "")
                                Dim app_size As String = If(row("app_size")?.ToString(), "")
                                Dim app_date As String = If(row("app_date")?.ToString(), "")
                                Dim app_folder As String = If(row("app_folder")?.ToString(), "")
                                ' Dim app_version As String = If(row("app_version")?.ToString(), "")
                                Dim app_ico_path As String = If(row("app_ico")?.ToString(), "")
                                Dim build_state As String = If(row("build_state")?.ToString(), "")
                                Dim app_ver As String = If(row("app_ver")?.ToString(), "")
                                Try
                                    Dim appicon As Bitmap = Nothing
                                    Dim cachedFilePath As String = Path.Combine(StoreCash_Path, app_id & ".png")

                                    ' Check if the image is already cached
                                    If File.Exists(cachedFilePath) Then

                                        appicon = ResizeImage(Image.FromFile(cachedFilePath), New Size(32, 32))

                                    Else
                                        appicon = ResizeImage(GetImageFromUrl(mainsite & app_ico_path), New Size(32, 32))
                                        appicon.Save(cachedFilePath)
                                    End If

                                    ' Add the data to the list
                                    rowsToAdd.Add(New Tuple(Of Bitmap, String, String, String, String, String, String)(appicon, app_name, app_id, app_date, app_size, build_state, app_ver))

                                Catch ex As Exception
                                    ' Handle exceptions if necessary
                                End Try
                            Next

                            ' Perform a single UI update after processing all rows
                            Me.Invoke(Sub()
                                          DGVSTORE.Rows.Clear()
                                          For Each row In rowsToAdd
                                              DGVSTORE.Rows.Add(row.Item1, row.Item2, row.Item3, row.Item4, row.Item5, row.Item6, row.Item7)
                                          Next
                                          dellall.Enabled = True
                                          storestate.Text = $"Store Apps: {DGVSTORE.Rows.Count.ToString()}"
                                          tabsapps.TabPages(0).Text = $"{DGVSTORE.Rows.Count} {curntTabname}"
                                      End Sub)
                        Else
                            Me.Invoke(Sub()
                                          storestate.Text = BTConst.smthngwrongstr
                                          tabsapps.TabPages(0).Text = $"{DGVSTORE.Rows.Count} {curntTabname}"
                                      End Sub)
                        End If


                    Else
                        'BTAlerter.infos(response, False)
                        Me.Invoke(Sub()
                                      storestate.Text = response
                                      tabsapps.TabPages(0).Text = $"{DGVSTORE.Rows.Count} {curntTabname}"
                                  End Sub)

                        Threading.Thread.Sleep(5000)


                    End If

                Else
                    Me.Invoke(Sub()
                                  BTAlerter.erroes(result.Item2)
                                  tabsapps.TabPages(0).Text = $"{DGVSTORE.Rows.Count} {curntTabname}"
                              End Sub)
                End If



            Catch ex As Exception
                Log_e("fetchworker", EXtoString(ex))
            End Try



            Threading.Thread.Sleep(10000)
            'we will check every 10 sec

        End While
    End Sub


    Private Sub BTApps_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        IamAlive = False
    End Sub

    Private Async Sub FetchCustomwrkr_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles FetchCustomwrkr.DoWork
        Dim Randomkey As String = RandomString(32)
        Dim curntTabname As String = tabsapps.TabPages(1).Text
        While IamAlive
            Try

                Dim params = New With {
                     Key .subcom = "load",
                     Key .ran_key = Randomkey,
                     Key .chk = nextkey
                }


                Dim result = Await FetchCustomAPI(params, httpClient)




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

                                'app_package,appname,app_ico,build_date,build_state

                                Dim app_id As String = row("app_package").ToString()
                                Dim app_name As String = If(row("appname")?.ToString(), "")
                                Dim app_ico_path As String = If(row("app_ico")?.ToString(), "")
                                Dim app_date As String = If(row("build_date")?.ToString(), "")
                                Dim build_state As String = If(row("build_state")?.ToString(), "")
                                Dim app_ver As String = If(row("app_ver")?.ToString(), "")




                                Try

                                    '"../user/storage/" + ico

                                    Dim appicon As Bitmap = Nothing
                                    Dim cachedFilePath As String = Path.Combine(StoreCash_Path, app_id & ".png")

                                    ' Check if the image is already cached
                                    If File.Exists(cachedFilePath) Then

                                        appicon = ResizeImage(Image.FromFile(cachedFilePath), New Size(32, 32))

                                    Else
                                        appicon = ResizeImage(GetImageFromUrl(rootdir_storage & app_ico_path), New Size(32, 32))
                                        appicon.Save(cachedFilePath)
                                    End If

                                    ' Add the data to the list
                                    rowsToAdd.Add(New Tuple(Of Bitmap, String, String, String, String, String)(appicon, app_name, app_id, app_date, build_state, app_ver))

                                Catch ex As Exception
                                    ' Handle exceptions if necessary
                                End Try
                            Next

                            ' Perform a single UI update after processing all rows
                            Me.Invoke(Sub()
                                          DGVCUSTOM.Rows.Clear()
                                          For Each row In rowsToAdd
                                              DGVCUSTOM.Rows.Add(row.Item1, row.Item2, row.Item3, row.Item4, row.Item5, row.Item6)
                                          Next

                                          dellall.Enabled = True
                                          customstate.Text = $"Custom Apps: {DGVCUSTOM.Rows.Count.ToString()}"

                                          tabsapps.TabPages(1).Text = $"{DGVCUSTOM.Rows.Count} {curntTabname}"
                                      End Sub)
                        Else
                            Me.Invoke(Sub()
                                          customstate.Text = BTConst.smthngwrongstr

                                          tabsapps.TabPages(1).Text = $"{DGVCUSTOM.Rows.Count} {curntTabname}"
                                      End Sub)
                        End If



                    Else
                        'BTAlerter.infos(response, False)
                        Me.Invoke(Sub()
                                      customstate.Text = response.Trim("""")

                                      tabsapps.TabPages(1).Text = $"{DGVCUSTOM.Rows.Count} {curntTabname}"
                                  End Sub)

                        Threading.Thread.Sleep(5000)


                    End If

                Else
                    Me.Invoke(Sub()
                                  BTAlerter.erroes(result.Item2)

                                  tabsapps.TabPages(1).Text = $"{DGVCUSTOM.Rows.Count} {curntTabname}"
                              End Sub)
                End If




            Catch ex As Exception
                Log_e("FetchCustomwrkr", EXtoString(ex))
            End Try

            Threading.Thread.Sleep(10000)
            'we will check every 10 sec

        End While
    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon1.Click
        Dim appmaker As New ApkMaker(nextkey, httpClient)
        appmaker.Show()

        Me.Close()
    End Sub
End Class