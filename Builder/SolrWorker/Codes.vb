

Imports System.IO
Imports System.IO.Compression
Imports System.Security.Cryptography
Imports System.Text
Imports System.Xml

Module Codes
    Function ToBase64(input As String) As String
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(input)
        Return Convert.ToBase64String(bytes)
    End Function
    Function GenerateRandomFolderName(nam As String) As String

        ''Dim tempPath As String = GetDrive()
        Dim tempPath As String = Path.GetTempPath


        Dim validChars As String = "qazQAZwsxWSXedcEDCrfvRFVtgbTGByhnYHNujmUJMikIKolOLpP"


        Dim folderNameLength As Integer = 5


        Dim random As New Random()
        Dim folderName As String = "app_" + nam + "_" & New String(Enumerable.Repeat(validChars, folderNameLength) _
                                    .Select(Function(s) s(random.Next(s.Length))).ToArray())


        Dim fullPath As String = Path.Combine(tempPath, folderName)


        Dim driv As String = GetDrive()
        While Directory.Exists(fullPath)

            folderName = driv & "app_" + nam + "_" & New String(Enumerable.Repeat(validChars, folderNameLength) _
                          .Select(Function(s) s(random.Next(s.Length))).ToArray())
            fullPath = Path.Combine(tempPath, folderName)
        End While


        Directory.CreateDirectory(fullPath)

        Return fullPath
    End Function
    Function Generatedrop(nam As String) As String

        Dim tempPath As String = GetDrive() & "drops" & "\"
        ''Dim tempPath As String = Path.GetTempPath


        Dim validChars As String = "qazQAZwsxWSXedcEDCrfvRFVtgbTGByhnYHNujmUJMikIKolOLpP"


        Dim folderNameLength As Integer = 5


        Dim random As New Random()
        Dim folderName As String = "app_" + nam + "_" & New String(Enumerable.Repeat(validChars, folderNameLength) _
                                    .Select(Function(s) s(random.Next(s.Length))).ToArray())


        Dim fullPath As String = Path.Combine(tempPath, folderName)


        Dim driv As String = GetDrive()
        While Directory.Exists(fullPath)

            folderName = driv & "app_" + nam + "_" & New String(Enumerable.Repeat(validChars, folderNameLength) _
                          .Select(Function(s) s(random.Next(s.Length))).ToArray())
            fullPath = Path.Combine(tempPath, folderName)
        End While


        Directory.CreateDirectory(fullPath)

        Return fullPath
    End Function
    Public Function FixStrings(ByVal str As String) As String


        Dim c0 As String = "&"
        Dim p0 As String = "&amp;"

        Dim c1 As String = "<"
        Dim p1 As String = "&lt;"

        Dim c2 As String = """"
        Dim p2 As String = "\"""

        Dim c3 As String = "'"
        Dim p3 As String = "\'"

        Dim c4 As String = "?"
        Dim p4 As String = "\?"

        Dim c5 As String = "@"
        Dim p5 As String = "\@"

        If str.Contains(c0) Then
            If Not str.Contains(p0) Then
                str = str.Replace(c0, p0)
            End If
        End If


        If str.Contains(c1) Then
            If Not str.Contains(p1) Then
                str = str.Replace(c1, p1)
            End If
        End If

        If str.Contains(c2) Then
            If Not str.Contains(p2) Then
                str = str.Replace(c2, p2)
            End If
        End If

        If str.Contains(c3) Then
            If Not str.Contains(p3) Then
                str = str.Replace(c3, p3)
            End If
        End If

        If str.Contains(c4) Then
            If Not str.Contains(p4) Then
                str = str.Replace(c4, p4)
            End If
        End If

        If str.Contains(c5) Then
            If Not str.Contains(p5) Then
                str = str.Replace(c5, p5)
            End If
        End If
        Return str

    End Function
    Public Function FileInUse(ByVal sFile As String) As Boolean
        Dim thisFileInUse As Boolean = False
        If System.IO.File.Exists(sFile) Then
            Try
                Using f As New IO.FileStream(sFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
                    ' thisFileInUse = False
                End Using
            Catch
                thisFileInUse = True
            End Try
        End If
        Return thisFileInUse
    End Function
    Public rshit As Random = Nothing
    Public usedalready As List(Of String) = New List(Of String)
    Public cou3 As Integer = 0
    Function RandommMad(minCharacters As Integer, maxCharacters As Integer)
again:
        Dim s As String = "qazwsxedcrfvtgbyhnujmikolp"
        Static r As New Random
        Dim chactersInString As Integer = r.Next(minCharacters, maxCharacters)
        Dim sb As New StringBuilder
        For i As Integer = 1 To chactersInString
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Dim result As String = sb.ToString()
        If usedalready.Contains(result) Then
            GoTo again
        End If
        usedalready.Add(result)
        Return result
    End Function
    Function UpdateVersions(inputXml As String) As String
        Dim doc As New XmlDocument()
        doc.LoadXml(inputXml)

        Dim manifestNode As XmlNode = doc.SelectSingleNode("/manifest")
        If manifestNode IsNot Nothing Then
            Dim compileSdkVersionAttr As XmlAttribute = manifestNode.Attributes("compileSdkVersion")
            Dim platformBuildVersionCodeAttr As XmlAttribute = manifestNode.Attributes("platformBuildVersionCode")

            If compileSdkVersionAttr IsNot Nothing Then
                Dim compileSdkVersionValue As Integer


                If Integer.TryParse(compileSdkVersionAttr.Value, compileSdkVersionValue) AndAlso compileSdkVersionValue > 29 Then
                    compileSdkVersionAttr.Value = "29"
                End If


            End If

            If platformBuildVersionCodeAttr IsNot Nothing Then

                Dim platformBuildVersionCodeValue As Integer


                If Integer.TryParse(platformBuildVersionCodeAttr.Value, platformBuildVersionCodeValue) AndAlso platformBuildVersionCodeValue > 29 Then
                    platformBuildVersionCodeAttr.Value = "29"
                End If
            End If
        End If

        Return doc.OuterXml
    End Function
    Public Function GetDrive() As String
        Try
            Dim f() As String = {"\"}
            Dim a() As String = AppDomain.CurrentDomain.BaseDirectory.Split(f, StringSplitOptions.RemoveEmptyEntries)
            Return a(0) & "\"
        Catch
            Return "C:\"
        End Try
    End Function
    Private cou As Integer = 0
    Function RandomSTR(minCharacters As Integer, maxCharacters As Integer)

        Dim s As String = "qazQAZwsxWSXedcEDCrfvRFVtgbTGByhnYHNujmUJMikIKolOLpP"

        Static r As New Random
        Dim chactersInString As Integer = r.Next(minCharacters, maxCharacters)
        Dim sb As New System.Text.StringBuilder
        For i As Integer = 1 To chactersInString
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))

        Next
        cou += 1
        Return sb.ToString().ToLower() & CStr(cou)
    End Function
    Public Function GenerateRandomNumber(ByVal m0 As Integer, ByVal m1 As Integer) As Integer
        Static Random_Number As New Random()
        Return Random_Number.Next(m0, m1)
    End Function


    Private ranmad As Random
    Public Function madladstr() As String
        Dim s As String = "QAZWSXEDCRFTGBYHNUJMIKOLP嘩骆姨毘矛檴丘萺膵掸纀豘侉蚩蕥寶鎳獖凙鈞蹼甞犈鐲瀿梲竆暀薽勵嗬訴棕qazwsxedcrfvtgbyhnujmikolpضشئصسءثيؤقرفللاغاىعتةهنخمح"
        If rshit Is Nothing Then
            rshit = New Random
        End If

        Dim sb As String = ""
        While sb.Length < 125
            sb += s(rshit.Next(0, s.Length - 1))
        End While

        cou3 += 1
        Return sb.ToString().ToLower & CStr(cou3)
    End Function

    'Public Sub File_zip_Decompress(zipPath As String, pathfolder As String)

    '    If Not System.IO.Directory.Exists(pathfolder) Then
    '        System.IO.Directory.CreateDirectory(pathfolder)
    '    End If
    '    'Using zip As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read(zipPath)
    '    '    zip.ExtractAll(pathfolder, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently)
    '    'End Using

    '    ZipFile.ExtractToDirectory(zipPath, pathfolder)

    'End Sub

    Public Sub CopyDirectoryContents(sourcePath As String, destinationPath As String)
        If Not Directory.Exists(sourcePath) Then
            Return
        End If

        If Not Directory.Exists(destinationPath) Then
            Directory.CreateDirectory(destinationPath)
        End If

        ' Copy all files
        For Each filePathString As String In Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories)
            Dim fileInfoItem As New FileInfo(filePathString)
            Dim newFilePath As String = Path.Combine(destinationPath, fileInfoItem.Name)
            If File.Exists(newFilePath) Then
                ' If file already exists in destination, replace it
                File.Delete(newFilePath)
            End If
            File.Copy(filePathString, newFilePath) ' Move file
        Next

        ' Now copy all directories (including subdirectories) except source
        For Each dirPath As String In Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories)
            Dim newDirPath As String = dirPath.Replace(sourcePath, destinationPath)
            If Not Directory.Exists(newDirPath) Then
                Directory.CreateDirectory(newDirPath)
            End If
            ' Copy directory's content except source directory
            For Each filePathString As String In Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories)
                Dim fileInfoItem As New FileInfo(filePathString)
                Dim newFilePath As String = Path.Combine(newDirPath, fileInfoItem.Name)
                If File.Exists(newFilePath) Then
                    ' If file already exists in destination, replace it
                    File.Delete(newFilePath)
                End If
                File.Copy(filePathString, newFilePath) ' Move file
            Next
        Next
    End Sub
    Public Sub DirectoryDeleteLong(ByVal directoryPath As String)
        Dim emptyDirectory = New DirectoryInfo(Path.GetTempPath() + "\TempEmptyDirectory-" + Guid.NewGuid().ToString)

        Try
            emptyDirectory.Create()

            Using process = New Process()
                process.StartInfo.FileName = "robocopy.exe"
                process.StartInfo.Arguments = """" & emptyDirectory.FullName & """ """ & directoryPath & """ /mir /r:1 /w:1 /np /xj /sl"
                process.StartInfo.UseShellExecute = False
                process.StartInfo.CreateNoWindow = True
                process.Start()
                process.WaitForExit()
            End Using

            emptyDirectory.Delete()
            If Directory.Exists(directoryPath) Then
                Dim x As New DirectoryInfo(directoryPath)
                x.Attributes = FileAttributes.Normal
                Directory.Delete(directoryPath)
            End If

        Catch __unusedIOException1__ As IOException
            ' MsgBox(__unusedIOException1__)
        End Try
    End Sub

    Public Function FromBase64(input As String) As String
        Dim bytes As Byte() = Convert.FromBase64String(input)
        Return Encoding.UTF8.GetString(bytes)
    End Function


    Private randmid As String() = New String() {
    "ahpla", "ateb", "ammag", "atled", "agemo",
    "elibom", "sloot", "oiduts", "aidem", "semag",
    "krowten", "eruces", "duolc", "cnys", "enigne",
    "cigol", "maerts", "metsys", "latrop", "tcennoc",
    "tegdiw", "resworb", "reyalp", "xirtam", "lortnoc",
    "elpmis", "trams", "kcart", "puorg", "sucof",
    "noisiv", "sbal", "dlrow", "tfos", "yrotcaf",
    "kraps", "evaw", "wolg", "emarf", "tlob",
    "rotcev", "lexip", "mutnauq", "knil", "niahc",
    "kcolb", "tnega", "mrof", "epocs", "eslup",
    "kcats", "tfihs", "egdirb", "atsiv", "eralf",
    "ohce", "egrof", "tfarc", "dnelb", "tniop",
    "kcilc", "mooz", "tinu", "etats", "dleif",
    "level", "erehps", "kced", "hcnual", "langis",
    "hsem", "ecart", "tfird", "nemul", "rednes",
    "repooL", "eldnah", "regnahc", "noitces", "retuor",
    "ssecca", "yranib", "rotcev", "otpyrC", "rehpcy",
    "tibro", "yxalag", "avon", "resal", "eludom",
    "lenrek", "yranoisiv", "cimanyd", "tobber", "eludom",
    "cimetsys", "yfitnauq", "rallets", "noitom", "tekcap",
    "edocne", "yolped", "suxen", "nevird", "citats",
    "redner", "neercs", "balkcigol", "dnekcab", "dnetnorf",
    "xredner", "emitpu", "egarots", "draugefas", "tpyrcne",
    "rotinom", "dnammoc", "daolyap", "retsulc", "retpada",
    "yawetag", "elipmoc", "repparw", "lautriv", "lennahc",
    "tsacdaorb", "tig id", "ygrenes", "esufni", "thgisni",
    "noisuf", "hctilg", "remaerts", "xelipmoc", "rohnca",
    "sessenisub", "ekorts", "desserpmoc", "gnithgil", "esabataD",
    "gnikrowten", "rotinummoc", "erawdrah", "esab", "rotinom",
    "tropsnart", "rewopes", "noitacol", "gnimmargorp", "resu",
    "gnidoc", "gnitset", "gnimmargorp", "redaolpu", "daolnwod",
    "retlif", "ssalc", "revres", "gnikcolc", "tpmorp",
    "tuptuo", "niamod", "edoc", "reyal", "metsys",
    "enilno", "yrellag", "emanelif", "noitarugifnoc", "edom"
}

    Public Function Random_Word()
        Static Rnd As New Random
        Return randmid(Rnd.Next(0, randmid.Length - 1))
    End Function
    Public Function Encoding() As System.Text.Encoding
        Dim i As System.Text.Encoding = System.Text.Encoding.UTF8
        Return i
    End Function

    Function InsertZWNJ(ByVal input As String, Optional ByVal position As Integer = -1) As String
        ' U+200C = Zero Width Non-Joiner
        Dim zwnj As String = ChrW(&H200C)

        ' Default position: middle of the string
        If position < 0 Or position > input.Length Then
            position = input.Length \ 2
        End If

        ' Insert ZWNJ
        Return input.Substring(0, position) & zwnj & input.Substring(position)
    End Function

End Module
