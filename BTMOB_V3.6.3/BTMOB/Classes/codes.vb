Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.IO.Compression
Imports System.Management
Imports System.Net
Imports System.Net.Sockets
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports WMPLib

Module codes
    Public Function Translate(ByVal inputtext As String, ByVal fromlangid As String, ByVal tolangid As String) As String
        Try
            ' Replace new lines and properly encode the text for URL safety
            inputtext = Uri.EscapeDataString(inputtext.Replace(vbNewLine, "[]"))

            Dim step1 As New Net.WebClient
            step1.Encoding = Encoding.UTF8

            ' Build the API request URL
            Dim apiUrl As String = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl={tolangid}&hl={fromlangid}&dt=t&dt=bd&dj=1&source=icon&q={inputtext}"

            ' Fetch the translation response
            Dim step2 As String = step1.DownloadString(apiUrl)

            ' Parse the JSON response
            Dim step3 As Newtonsoft.Json.Linq.JObject = JObject.Parse(step2)
            Dim step4 As String = step3.SelectToken("sentences[0].trans").ToString()

            ' Replace placeholders and return the result
            Return step4.Replace("[]", vbNewLine)
        Catch ex As Exception
            ' Handle exceptions by logging or returning the original text
        End Try

        ' Return the original text if translation fails
        Return inputtext.Replace("[]", vbNewLine)
    End Function

    Public Function GetImageFromUrl(url As String) As Bitmap
        Try
            ' Initialize HttpClient

            Dim tClient As WebClient = New WebClient

            Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url)))
            Return tImage
        Catch ex As Exception
            Log_e("GetImageFromUrl", EXtoString(ex))
            ' Handle exceptions (e.g., network issues or invalid image data)
            'MessageBox.Show("Error fetching image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return My.Resources.btunkown
        End Try
    End Function
    Public Function EXtoString(ByVal ex As Exception) As String
        Dim timestamp As String = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss")
        Dim Splitter As String = vbNewLine & vbNewLine
        Dim ex0 As String = "ERROR:" & vbCrLf & Splitter & vbCrLf
        Dim ex1 As String = ""
        Dim ex2 As String = ""
        Dim ex3 As String = ""
        Dim ex4 As String = ""
        Dim ex5 As String = ""
        Try
            ex1 = ex.Message & vbCrLf & Splitter & vbCrLf
        Catch exc1 As Exception
        End Try
        Try
            ex2 = ex.StackTrace & vbCrLf & Splitter & vbCrLf
        Catch exc1 As Exception
        End Try
        Try
            ex3 = ex.InnerException.Message & vbCrLf & Splitter & vbCrLf
        Catch exc1 As Exception
        End Try
        Try
            ex4 = ex.InnerException.StackTrace & vbCrLf & Splitter & vbCrLf
        Catch exc1 As Exception
        End Try
        Try
            Dim DataStr As String = ""
            For i As Integer = 0 To ex.Data.Keys.Count
                Try
                    DataStr &= ex.Data.Item(ex.Data.Keys(i)) & vbCrLf
                Catch exc2 As Exception
                End Try
            Next
            ex5 = DataStr & vbCrLf & Splitter & vbCrLf
        Catch exc1 As Exception
        End Try

        Dim Result As String = $"[{timestamp}]" & vbNewLine & ex0 & ex1 & ex2 & ex3 & ex4 & ex5

        Return Result

    End Function
    Public Function TcpPing(ipAddress As String, port As Integer, timeoutMillis As Integer) As Long
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()

        Try
            Using tcpClient As New TcpClient()
                tcpClient.ReceiveTimeout = timeoutMillis
                tcpClient.SendTimeout = timeoutMillis
                tcpClient.Connect(ipAddress, port)
            End Using

            stopwatch.Stop()
            Return stopwatch.ElapsedMilliseconds ' Return the time in milliseconds
        Catch ex As Exception
            Return 0 ' Return 0 if the connection fails or times out
        End Try
    End Function

    Public Function ResizeImage(ByVal inputImage As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = False) As Image
        If inputImage.Width = size.Width AndAlso inputImage.Height = size.Height Then
            Return New Bitmap(inputImage) ' Early return if image dimensions match the desired size
        End If

        Dim newWidth As Integer = size.Width
        Dim newHeight As Integer = size.Height

        If preserveAspectRatio Then
            Dim originalWidth As Integer = inputImage.Width
            Dim originalHeight As Integer = inputImage.Height
            Dim percent As Single = Math.Min(size.Width / originalWidth, size.Height / originalHeight)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        End If

        Dim newImage As New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(inputImage, 0, 0, newWidth, newHeight)
        End Using

        Return newImage
    End Function

    Public Function IsPngImage(filePath As String) As Boolean
        Try
            Using image = System.Drawing.Image.FromFile(filePath)
                Return (image.RawFormat.Guid = System.Drawing.Imaging.ImageFormat.Png.Guid)
            End Using
        Catch ex As OutOfMemoryException
            ' The file is not a valid image or not supported by the GDI+ library.
            Return False
        Catch ex As FileNotFoundException
            ' The file does not exist.
            Return False
        Catch ex As Exception
            ' Other exceptions.
            Return False
        End Try
    End Function
    Public Function ToBase64(Str As String) As String
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(Str)

        Return Convert.ToBase64String(byt)
    End Function

    Public Function FromBase64(Str As String) As String
        Return Encoding.UTF8.GetString(Convert.FromBase64String(Str))
    End Function

    Private lasthwid As String = Nothing
    Function Base64ToImage(ByVal base64string As String) As System.Drawing.Image
        'Setup image and get data stream together


        Dim b64 As String = base64string.Replace(" ", "+")
        Dim b() As Byte


        'Converts the base64 encoded msg to image data
        b = Convert.FromBase64String(b64)
        Dim MS = New System.IO.MemoryStream(b)

        'creates image
        Dim img = System.Drawing.Image.FromStream(MS)
        MS.Dispose()

        Return img
    End Function

    Public Function CalculateBufferSize(totalBytes As Long) As Integer
        ' Example: adjust buffer size based on file size
        If totalBytes < 1024 * 1024 Then ' Files < 1MB
            Return 64 * 1024 ' 64KB buffer
        ElseIf totalBytes < 10 * 1024 * 1024 Then ' Files < 10MB
            Return 256 * 1024 ' 256KB buffer
        Else
            Return 1 * 1024 * 1024 ' 1MB buffer
        End If
    End Function

    Public Function CalculateMD5(filePath As String) As String
        Using md5 As MD5 = MD5.Create()
            Using stream As FileStream = File.OpenRead(filePath)
                Dim hash As Byte() = md5.ComputeHash(stream)
                Return BitConverter.ToString(hash).Replace("-", "").ToLower()
            End Using
        End Using
    End Function
    Public Function GetMD5Hash(filePath As String) As String
        Try
            Using md5 As MD5 = MD5.Create()
                Using stream As FileStream = File.OpenRead(filePath)
                    Dim hash As Byte() = md5.ComputeHash(stream)
                    Return BitConverter.ToString(hash).Replace("-", "").ToLower() ' Convert to hex string
                End Using
            End Using
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function
    Public Function isEmpty(str As String) As Boolean
        If String.IsNullOrEmpty(str) Or String.IsNullOrWhiteSpace(str) Then
            Return True
        End If
        Return False
    End Function
    Private r As Random = Nothing
    Public Function RandomString(maxlength As Integer)
        If r Is Nothing Then
            r = New Random
        End If
        Dim s As String = "PrhXKVYLt3UsfdmHicyG547WCbnwa19k2uBQADE0Flp8gzZToIT6SejJqvNMOx"

        Dim holder As String = ""
        Do
            holder += s.Chars(r.Next(0, s.Length)).ToString
        Loop While holder.Length < maxlength
        Return holder
    End Function
    Public Function StringToMD5(input As String) As String
        ' Create an MD5 instance
        Using md5 As MD5 = MD5.Create()
            ' Convert the input string to a byte array
            Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(input)

            ' Compute the MD5 hash of the input
            Dim hashBytes As Byte() = md5.ComputeHash(inputBytes)

            ' Convert hash bytes to a hexadecimal string
            Dim sb As New StringBuilder()
            For Each b As Byte In hashBytes
                sb.Append(b.ToString("x2"))  ' "x2" -> lower-case hex format
            Next

            Return sb.ToString()
        End Using
    End Function

    Function GetHWID() As String


        If lasthwid IsNot Nothing Then
            Return lasthwid
        End If

        Dim hwidBuilder As New StringBuilder()

        Try
            ' Get the volume serial number
            Dim sysDrive As String = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 1)
            Try
                Dim disk As New ManagementObject($"win32_logicaldisk.deviceid=""{sysDrive}:""")
                disk.Get()
                Dim volumeSerial As String = disk("VolumeSerialNumber")
                hwidBuilder.Append(If(volumeSerial IsNot Nothing, volumeSerial.ToString(), "VSVALID"))
            Catch ex As Exception
                hwidBuilder.Append("VSVALID")
            End Try

            ' Get the motherboard ID
            Try
                Using search As New ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard")
                    For Each info As ManagementObject In search.Get()
                        Dim serialNumber As String = info("SerialNumber")
                        hwidBuilder.Append(If(serialNumber IsNot Nothing, serialNumber.ToString(), "SNVALID"))

                    Next
                End Using
            Catch ex As Exception
                hwidBuilder.Append("SNVALID")
            End Try

            ' Get the processor ID
            Try
                Using search As New ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor")
                    For Each info As ManagementObject In search.Get()
                        Dim processorId As String = info("ProcessorId")
                        hwidBuilder.Append(If(processorId IsNot Nothing, processorId.ToString(), "PIVALID"))

                    Next
                End Using
            Catch ex As Exception
                hwidBuilder.Append("PIVALID")
            End Try

            lasthwid = hwidBuilder.ToString().Trim().Replace("+", "_")
            Return lasthwid

        Catch ex As Exception
            MsgBox("Error generating HWID")
            Environment.FailFast("Error generating HWID")
            Return String.Empty
        End Try
    End Function
    Public Function BytesConverter(ByVal bytes As Long) As Array
        Dim KB As Long = 1024
        Dim MB As Long = KB * KB
        Dim GB As Long = KB * KB * KB
        Dim TB As Long = KB * KB * KB * KB
        Dim returnVal As String = "0 Bytes"
        Select Case bytes
            Case Is < KB
                returnVal = bytes & " Bytes"
            Case Is > TB
                returnVal = (bytes / KB / KB / KB / KB).ToString("0.00") & " TB"
            Case Is > GB
                returnVal = (bytes / KB / KB / KB).ToString("0.00") & " GB"
            Case Is > MB
                returnVal = (bytes / KB / KB).ToString("0.00") & " MB"
            Case Is >= KB
                returnVal = (bytes / KB).ToString("0.00") & " KB"
        End Select
        Return {returnVal.ToString}
    End Function
    Public Function Base64ToBitmap(ByVal base64String As String) As Bitmap
        ' Convert Base64 string to byte array
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)

        ' Convert byte array to MemoryStream
        Using ms As New MemoryStream(imageBytes)
            ' Create Bitmap from MemoryStream
            Dim bitmap As New Bitmap(ms)
            Return bitmap
        End Using
    End Function
    Public Sub SaveVideothumb(thumbs As String, Filename As String, img As Image)
        Try
            If Not Directory.Exists(thumbs + "\" + Filename.Replace(".mp4", "").Replace(".mov", "")) Then
                Directory.CreateDirectory(thumbs + "\" + Filename.Replace(".mp4", "").Replace(".mov", ""))

            End If
            img.Save(thumbs + "\" + Filename.Replace(".mp4", "").Replace(".mov", "") + "\" + Filename.Replace(".mp4", CStr(System.DateTime.Now().Millisecond) + ".jpg").Replace(".mov", CStr(System.DateTime.Now().Millisecond) + ".jpg"))
        Catch ex As Exception

        End Try
    End Sub
    Public Function ReadBitmapFromFile(ByVal s_Path As String) As Bitmap
        Try
            Using i_Stream As FileStream = New FileStream(s_Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)

                Using i_Bmp As Bitmap = New Bitmap(i_Stream)
                    Return New Bitmap(i_Bmp)
                End Using
            End Using
        Catch ex As Exception
            Return New Bitmap(4, 4)
        End Try
    End Function
    Public Function RateConverter(ByVal Value As Integer, ByVal Totalsize As Integer) As Integer
        Try
            If Totalsize = 0 Then
                Return 0
            End If
            Return CInt(Math.Round(CDbl(((CDbl(Value) / CDbl(Totalsize)) * 100))))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function bytestotext(ByVal bytes As Long) As String
        Dim KB As Long = 1024
        Dim MB As Long = KB * KB
        Dim GB As Long = KB * KB * KB
        Dim TB As Long = KB * KB * KB * KB
        Dim returnVal As String = "0 Bytes"
        Select Case bytes
            Case Is < KB
                returnVal = bytes & " Bytes"
            Case Is > TB
                returnVal = (bytes / KB / KB / KB / KB).ToString("0.00") & " TB"
            Case Is > GB
                returnVal = (bytes / KB / KB / KB).ToString("0.00") & " GB"
            Case Is > MB
                returnVal = (bytes / KB / KB).ToString("0.00") & " MB"
            Case Is >= KB
                returnVal = (bytes / KB).ToString("0.00") & " KB"
        End Select
        Return returnVal.ToString
    End Function

    Public Function UploadDownload(ByVal ParametersLong0 As Long, ByVal ParametersLong1 As Long) As Array
        Try
            Static LastUpload As Long = ParametersLong0
            Static LastDownload As Long = ParametersLong1
            Dim Up = ParametersLong0 - LastUpload
            Dim Down = ParametersLong1 - LastDownload
            LastUpload = ParametersLong0
            LastDownload = ParametersLong1
            Return {codes.BytesConverter(If(Down < 0, 0, Down)).GetValue(0), codes.BytesConverter(If(Up < 0, 0, Up)).GetValue(0)}
        Catch ex As Exception
            Return {"n/a", "n/a"}
        End Try
    End Function
    Public Sub PlayNotificationSound()
        Try
            Dim notfyname As String = BTRegistry.GetValue(Regz.notify_sund, "1")
            Dim filePath As String = MyRes.Sounds_Path & "\" & notfyname & ".mp3"

            Dim player As New WindowsMediaPlayer()
            player.URL = filePath
            player.controls.play()

            ' Optional: Set player settings (e.g., volume)
            player.settings.volume = 100

        Catch ex As Exception
            MessageBox.Show("Error playing sound: " & ex.Message)
        End Try
    End Sub
    Public Sub SaveWavFile(buffers As List(Of Byte()), outputPath As String)
        Try

            Dim finalBuffer As Byte() = ConcatenateAudioBuffers(buffers)


            File.WriteAllBytes(outputPath, finalBuffer)

        Catch ex As Exception
            Log_e("SaveWavFile", EXtoString(ex))
            Console.WriteLine("Error saving audio: " & ex.Message)
        End Try
    End Sub
    Private Function ConcatenateAudioBuffers(buffers As List(Of Byte())) As Byte()
        Const HeaderSize As Integer = 44
        Dim totalLength As Integer = HeaderSize

        ' Calculate total length (subtract header size for chunks after the first)
        For i As Integer = 0 To buffers.Count - 1
            If i = 0 Then
                totalLength += buffers(i).Length
            Else
                totalLength += buffers(i).Length - HeaderSize
            End If
        Next

        ' Create the final buffer
        Dim result As Byte() = New Byte(totalLength - 1) {}
        Dim offset As Integer = 0

        ' Copy buffers
        For i As Integer = 0 To buffers.Count - 1
            Dim buffer As Byte() = buffers(i)
            If i = 0 Then
                ' Copy first chunk (with header)
                System.Buffer.BlockCopy(buffer, 0, result, offset, buffer.Length)
                offset += buffer.Length
            Else
                ' Copy subsequent chunks (without header)
                System.Buffer.BlockCopy(buffer, HeaderSize, result, offset, buffer.Length - HeaderSize)
                offset += buffer.Length - HeaderSize
            End If
        Next
        Dim chunkSize As Integer = totalLength - 8
        Dim subchunk2Size As Integer = totalLength - HeaderSize
        BitConverter.GetBytes(chunkSize).CopyTo(result, 4) ' ChunkSize
        BitConverter.GetBytes(subchunk2Size).CopyTo(result, 40) ' Subchunk2Size
        Return result
    End Function
    Public Sub SaveDGV(DGVNUMS As DataGridView, Clifolder As String, savetype As String)
        If DGVNUMS.Rows.Count > 0 Then

            Dim savefolder As String = Clifolder & "\" & savetype
            If Not Directory.Exists(savefolder) Then
                Directory.CreateDirectory(savefolder)
            End If
            Dim FileName As String = savetype + ".Html"
            FileName = savefolder & "\" & FileName.Replace(".Html", "_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".Html")
            File.WriteAllText(FileName, DataGridToHTML(DGVNUMS))

        End If
    End Sub
    Public Sub SaveJson(jsonstr As String, Clifolder As String, savetype As String, FilTag As String)
        Try
            Dim savefolder As String = Clifolder & "\" & savetype
            If Not Directory.Exists(savefolder) Then
                Directory.CreateDirectory(savefolder)
            End If
            Dim FileName As String = FilTag + ".txt"
            FileName = savefolder & "\" & FileName.Replace(".txt", "_" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") & ".txt")
            File.WriteAllText(FileName, jsonstr)
        Catch ex As Exception

        End Try
    End Sub

    Public Function DataGridToHTML(ByVal dg As DataGridView) As String
        ' Check if DataGridView is empty
        If dg Is Nothing OrElse dg.Rows.Count = 0 Then
            Return "<html><body><center><p>No data available</p></center></body></html>"
        End If

        Dim strB As New StringBuilder()

        ' Start building the HTML table
        strB.AppendLine("<html>")
        strB.AppendLine("<body>")
        strB.AppendLine("<center>")
        strB.AppendLine("<table border='1' cellpadding='5' cellspacing='0'>")

        ' Add header row
        strB.AppendLine("<thead>")
        strB.AppendLine("<tr>")
        For Each column As DataGridViewColumn In dg.Columns
            If column.Visible Then ' Only include visible columns
                strB.AppendLine($"<th align='center' valign='middle'>{System.Web.HttpUtility.HtmlEncode(column.HeaderText)}</th>")
            End If
        Next
        strB.AppendLine("</tr>")
        strB.AppendLine("</thead>")

        ' Add rows
        strB.AppendLine("<tbody>")
        For Each row As DataGridViewRow In dg.Rows
            ' Skip new row (if present)
            If row.IsNewRow Then Continue For

            strB.AppendLine("<tr>")
            For Each cell As DataGridViewCell In row.Cells
                If cell.Visible Then ' Only include visible cells
                    Dim cellValue As String = If(cell.Value IsNot Nothing, cell.Value.ToString(), String.Empty)
                    strB.AppendLine($"<td align='center' valign='middle'>{System.Web.HttpUtility.HtmlEncode(cellValue)}</td>")
                End If
            Next
            strB.AppendLine("</tr>")
        Next
        strB.AppendLine("</tbody>")

        ' Close the HTML table
        strB.AppendLine("</table>")
        strB.AppendLine("</center>")
        strB.AppendLine("</body>")
        strB.AppendLine("</html>")

        Return strB.ToString()
    End Function
    Public Function SafeCloneImage(src As Image) As Bitmap
        If src Is Nothing Then
            ' Create a 1x1 transparent bitmap
            Dim emptyBmp As New Bitmap(1, 1)
            emptyBmp.SetPixel(0, 0, Color.Transparent)
            Return emptyBmp
        End If
        Return DirectCast(src.Clone(), Bitmap)
    End Function


    Function ListZipFileNames(zipFilePath As String) As List(Of String)
        Dim fileNames As New List(Of String)

        ' Open the zip archive for reading
        Using zip As ZipArchive = ZipFile.OpenRead(zipFilePath)
            ' Loop through the entries in the zip file
            For Each entry As ZipArchiveEntry In zip.Entries
                fileNames.Add(entry.FullName) ' Add the file name to the list
            Next
        End Using

        Return fileNames
    End Function
    Public Sub CheckDefaultOptions()
        Try

            Dim currentJson As String = BTRegistry.GetValue(BTSettings.Defconfig, My.Resources.Deafult_mob_optns)
            Dim currentOptions As Dictionary(Of String, String) =
            JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(currentJson)


            Dim defaultJson As String = My.Resources.Deafult_mob_optns
            Dim defaultOptions As Dictionary(Of String, String) =
            JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(defaultJson)


            Dim updated As Boolean = False
            For Each kvp In defaultOptions
                If Not currentOptions.ContainsKey(kvp.Key) Then
                    currentOptions(kvp.Key) = kvp.Value
                    updated = True
                End If
            Next


            If updated Then
                Dim updatedJson As String = JsonConvert.SerializeObject(currentOptions, Formatting.None)
                BTRegistry.AddOrUpdateValue(BTSettings.Defconfig, updatedJson)
            End If

        Catch ex As Exception
            MsgBox("Failed to update registry options: " & ex.Message)
        End Try
    End Sub

    Public Function connectionicon(Str As String) As Bitmap
        Select Case Str
            Case "in"
                Return My.Resources.ok_con.Clone
            Case "out"
                Return My.Resources.no_con.Clone
            Case "block"
                Return My.Resources.block_con.Clone
            Case "info"
                Return My.Resources.info_blue.Clone
            Case "discon"
                Return My.Resources.disconect.Clone
            Case Else
                Return My.Resources.info_blue.Clone
        End Select
    End Function


    Function CleanFileName(name As String) As String
        ' Remove invalid characters
        Dim invalidChars As Char() = Path.GetInvalidFileNameChars()
        For Each ch In invalidChars
            name = name.Replace(ch, "")
        Next

        ' Remove reserved names
        Dim reservedNames As String() = {
        "CON", "PRN", "AUX", "NUL",
        "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
        "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
    }

        ' Trim and normalize whitespace
        name = Regex.Replace(name.Trim(), "\s+", " ")

        ' Remove trailing dot or space
        name = name.TrimEnd("."c, " "c)

        ' Cut length to 100 characters (adjust as needed)
        If name.Length > 100 Then
            name = name.Substring(0, 100)
        End If

        ' Check for reserved name (case-insensitive)
        If reservedNames.Contains(name.ToUpperInvariant()) Then
            name = name & "_file"
        End If

        Return name
    End Function
    Function loadjectors(path As String) As String
        If Not System.IO.Directory.Exists(path) Then
            Return "empty"
        End If

        Dim files() As String = System.IO.Directory.GetFiles(path, "*.zip")
        Dim names As New List(Of String)

        For Each file As String In files
            names.Add(System.IO.Path.GetFileNameWithoutExtension(file))
        Next
        If names.Count = 0 Then
            Return "empty"
        End If
        Return String.Join("<j>", names)
    End Function
    Public Function BitmapToBase64(bitmap As Bitmap) As String
        Using ms As New MemoryStream()

            bitmap.Save(ms, Imaging.ImageFormat.Png)

            Dim imageBytes As Byte() = ms.ToArray()
            Return Convert.ToBase64String(imageBytes)
        End Using
    End Function
    Public Function ExtractHtmlFromZip(zipFilePath As String) As String
        Using zip As ZipArchive = ZipFile.OpenRead(zipFilePath)
            For Each entry As ZipArchiveEntry In zip.Entries
                If entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase) Then
                    Using stream As Stream = entry.Open()
                        Using reader As New StreamReader(stream, Encoding.UTF8)
                            Return reader.ReadToEnd()
                        End Using
                    End Using
                End If
            Next
        End Using

        Return Nothing
    End Function
    Public Sub SetDoubleBuffered(ByVal control As Control)
        Dim dgvType As Type = control.[GetType]()
        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(control, True, Nothing)
    End Sub

    Public Sub ZipJectFile(sourceFilePath As String, destinationZipPath As String, zippedFileName As String)
        If Not File.Exists(sourceFilePath) Then
            Throw New FileNotFoundException("Source file not found.", sourceFilePath)
        End If

        If File.Exists(destinationZipPath) Then
            File.Delete(destinationZipPath) ' Overwrite if exists
        End If

        Using zipToOpen As FileStream = New FileStream(destinationZipPath, FileMode.Create)
            Using archive As ZipArchive = New ZipArchive(zipToOpen, ZipArchiveMode.Create)
                Dim entryName As String = If(String.IsNullOrEmpty(zippedFileName), Path.GetFileName(sourceFilePath), zippedFileName)
                archive.CreateEntryFromFile(sourceFilePath, entryName, CompressionLevel.Fastest)
            End Using
        End Using
    End Sub
    Public Function Createtemp(content As String) As String

        Dim tempFilePath As String = Path.GetTempFileName()


        File.WriteAllText(tempFilePath, content)


        Return tempFilePath
    End Function
    Function HtmlToBase64(html As String) As String
        ' Convert the HTML string to a UTF-8 byte array
        Dim utf8Bytes As Byte() = Encoding.UTF8.GetBytes(html)

        ' Convert the byte array to a Base64 string
        Dim base64String As String = Convert.ToBase64String(utf8Bytes)

        Return base64String
    End Function
    Public Function locallanguage() As String
        Select Case BTRegistry.GetValue(Regz.Language, "en")

            Case "AR"
                Return "ar"

            Case "CN" ' Chinese
                Return "zh"

            Case "RU" ' Russian
                Return "ru"

            Case "TR" ' Turkish
                Return "tr"

            Case "SP" ' Spanish
                Return "es"

            Case "PR" ' Brazilian Portuguese

                Return "pt"

            Case Else
                Return "en"
        End Select
    End Function
    Public Function SafeGetValue(arr As String(), index As Integer) As String
        If arr Is Nothing OrElse index < 0 OrElse index >= arr.Length OrElse String.IsNullOrEmpty(arr(index)) Then
            Return "N/A"
        End If
        Return arr(index)
    End Function
    Public Sub SaveSMSData(ByVal SMSdata() As String, ByVal outputFile As String)
        Dim SPL_ARRAY As String = "[>ARY<]" ' Replace with your actual delimiter

        Try
            Dim sb As New StringBuilder()
            sb.AppendLine("<html><head><meta charset='UTF-8'><title>SMS Export</title></head><body>")
            sb.AppendLine("<table border='1'><tr><th>Address</th><th>Name</th><th>Date</th><th>Tag</th><th>Message</th><th>Path</th><th>ID</th></tr>")

            For Each smsss As String In SMSdata
                Try
                    Dim singlesms() As String = smsss.ToString().Split(New String() {SPL_ARRAY}, StringSplitOptions.None)
                    If singlesms.Length > 1 Then
                        sb.AppendLine("<tr>")
                        For i As Integer = 0 To 6
                            sb.AppendLine("<td>" & WebUtility.HtmlEncode(SafeGetValue(singlesms, i)) & "</td>")
                        Next
                        sb.AppendLine("</tr>")
                    End If
                Catch ex As Exception
                    Log_e("Parsing SMS for HTML", EXtoString(ex))
                End Try
            Next

            sb.AppendLine("</table></body></html>")
            File.WriteAllText(outputFile, sb.ToString(), Encoding.UTF8)

        Catch ex As Exception
            Log_e("SaveSMSData", EXtoString(ex))
        End Try
    End Sub
    Private Function ParseVersion(versionString As String) As (Major As Integer, Minor As Integer, Patch As Integer)
        ' Remove trailing v or V
        versionString = versionString.Trim().TrimStart("v"c, "V"c)

        ' Split by .
        Dim parts = versionString.Split("."c)

        Dim major As Integer = If(parts.Length > 0 AndAlso Integer.TryParse(parts(0), major), major, 0)
        Dim minor As Integer = If(parts.Length > 1 AndAlso Integer.TryParse(parts(1), minor), minor, 0)
        Dim patch As Integer = If(parts.Length > 2 AndAlso Integer.TryParse(parts(2), patch), patch, 0)

        Return (major, minor, patch)
    End Function

    Public Function IsVersionGreater(versionString As String, compareTo As String) As Boolean
        Dim v1 = ParseVersion(versionString)
        Dim v2 = ParseVersion(compareTo)

        If v1.Major <> v2.Major Then
            Return v1.Major > v2.Major
        ElseIf v1.Minor <> v2.Minor Then
            Return v1.Minor > v2.Minor
        Else
            Return v1.Patch > v2.Patch
        End If
    End Function

End Module
