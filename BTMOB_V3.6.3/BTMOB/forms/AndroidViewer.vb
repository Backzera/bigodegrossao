Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Web.UI.WebControls
Imports System.Xml

Public Class AndroidViewer
    Private minX As Integer = Integer.MaxValue
    Private minY As Integer = Integer.MaxValue
    Private maxX As Integer = Integer.MinValue
    Private maxY As Integer = Integer.MinValue
    <ComVisible(True)>
    Public Class mybridge
        Public mainform As AndroidViewer
        Sub New(minme As AndroidViewer)
            mainform = minme
        End Sub

        <DispId(1)>
        Public Sub printinfo(json As Object)
            Dim parsed = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(json)
            Dim fullAttrs = parsed("info")
            Dim lines = fullAttrs.Split(" "c)


            mainform.Invoke(Sub()
                                mainform.logtext.Text = ""
                                For Each line In lines
                                    If Not String.IsNullOrWhiteSpace(line) Then
                                        mainform.logtext.AppendText(line & Environment.NewLine)
                                    End If
                                Next
                                mainform.logtext.AppendText(Environment.NewLine)
                            End Sub)
            '  Log_d("AndroidViewer", "Full Node Info:" & vbCrLf & fullAttrs)
        End Sub
    End Class

    Private Sub FindMinimumBounds(xmlNode As XmlNode)
        If xmlNode.Name = "node" Then
            Dim bounds = xmlNode.Attributes("bounds")?.Value
            If bounds IsNot Nothing Then
                Dim coords = bounds.Replace("[", "").Replace("]", ",").Split(","c)
                If coords.Length >= 4 Then
                    Dim x = Integer.Parse(coords(0))
                    Dim y = Integer.Parse(coords(1))
                    If x < minX Then minX = x
                    If y < minY Then minY = y
                End If
            End If
        End If

        For Each child As XmlNode In xmlNode.ChildNodes
            FindMinimumBounds(child)
        Next
    End Sub

    Private Sub GenerateHtmlFromDump(xmlPath As String, htmlPath As String)
        Dim doc As New XmlDocument()
        doc.Load(xmlPath)

        ' Calculate bounds
        minX = Integer.MaxValue
        minY = Integer.MaxValue
        maxX = Integer.MinValue
        maxY = Integer.MinValue
        FindBounds(doc.DocumentElement)

        Dim layoutWidth = maxX - minX
        Dim layoutHeight = maxY - minY

        ' Start HTML
        Dim html As New System.Text.StringBuilder()
        html.AppendLine("<!DOCTYPE html><html><head><meta charset='UTF-8'><style>")
        html.AppendLine("html, body { margin: 0; padding: 0; background: #f0f0f0; overflow: hidden; height: 100%; width: 100%; }")
        html.AppendLine("#viewport { width: 100%; height: 100%; position: relative; overflow: hidden; }")
        html.AppendLine("#wrapper { position: absolute; top: 0; left: 0; width: " & layoutWidth & "px; height: " & layoutHeight & "px; transform-origin: top left; }")
        html.AppendLine(".node { position: absolute; border: 1px solid #333; background: rgba(0,123,255,0.1); font-size: 50px; overflow: hidden; word-wrap: break-word; padding: 2px; box-sizing: border-box; }")
        html.AppendLine("</style></head><body>")
        html.AppendLine("<div id='viewport'><div id='wrapper'>")

        ' Collect and sort nodes
        Dim visualNodes As New List(Of VisualNode)
        CollectVisualNodes(doc.DocumentElement, visualNodes)
        Dim sortedNodes = visualNodes.OrderByDescending(Function(vn) vn.Area).ToList()


        For Each vn In sortedNodes
            Dim node = vn.XmlNode
            Dim x = vn.X
            Dim y = vn.Y
            Dim width = vn.Width
            Dim height = vn.Height

            Dim text = node.Attributes("text")?.Value
            Dim resId = node.Attributes("resource-id")?.Value
            Dim className = node.Attributes("class")?.Value
            Dim contentDesc = node.Attributes("content-desc")?.Value

            Dim allAttributes As New List(Of String)
            For Each attr As XmlAttribute In node.Attributes
                allAttributes.Add($"{attr.Name}='{EscapeJs(attr.Value)}'")
            Next
            Dim fullAttrString As String = String.Join(" ", allAttributes)
            Dim infoObject As String = $"{{ info: '{EscapeJs(fullAttrString)}' }}"

            Dim tooltip = $"text: {text}" & vbLf & $"id: {resId}" & vbLf & $"class: {className}"

            html.AppendLine($"<div class='node' style='left:{x}px; top:{y}px; width:{width}px; height:{height}px;' " &
                        $"title='{System.Security.SecurityElement.Escape(tooltip)}' " &
                        $"onclick=""printvb({infoObject})"">")

            If Not String.IsNullOrWhiteSpace(text) Then
                html.AppendLine(System.Web.HttpUtility.HtmlEncode(text))
            End If

            html.AppendLine("</div>")
        Next

        html.AppendLine("</div></div>")
        html.AppendLine("<script>")
        html.AppendLine("function scaleLayout() {")
        html.AppendLine("  const wrapper = document.getElementById('wrapper');")
        html.AppendLine("  const scaleX = window.innerWidth / " & layoutWidth & ";")
        html.AppendLine("  const scaleY = window.innerHeight / " & layoutHeight & ";")
        html.AppendLine("  const scale = Math.min(scaleX, scaleY);")
        html.AppendLine("  wrapper.style.transform = 'scale(' + scale + ')';")
        html.AppendLine("}")
        html.AppendLine("window.addEventListener('load', scaleLayout);")
        html.AppendLine("window.addEventListener('resize', scaleLayout);")
        html.AppendLine(" async function printvb(infos) {")
        html.AppendLine("try {")
        html.AppendLine("await window.chrome.webview.hostObjects.sync.mybridge.printinfo(JSON.stringify(infos));")
        html.AppendLine("} catch (err) { alert(err.message); }")
        html.AppendLine("};")
        html.AppendLine("</script></body></html>")

        File.WriteAllText(htmlPath, html.ToString())
    End Sub


    Private Sub FindBounds(xmlNode As XmlNode)
        If xmlNode.Name = "node" Then
            Dim bounds = xmlNode.Attributes("bounds")?.Value
            If bounds IsNot Nothing Then
                Dim coords = bounds.Replace("[", "").Replace("]", ",").Split(","c)
                If coords.Length >= 4 Then
                    Dim x = Integer.Parse(coords(0))
                    Dim y = Integer.Parse(coords(1))
                    Dim x2 = Integer.Parse(coords(2))
                    Dim y2 = Integer.Parse(coords(3))

                    If x < minX Then minX = x
                    If y < minY Then minY = y
                    If x2 > maxX Then maxX = x2
                    If y2 > maxY Then maxY = y2
                End If
            End If
        End If

        For Each child As XmlNode In xmlNode.ChildNodes
            FindBounds(child)
        Next
    End Sub

    Private Function EscapeJs(value As String) As String
        If value Is Nothing Then Return ""
        Return value.Replace("\", "\\").Replace("'", "\'").Replace("""", "\""").Replace(Environment.NewLine, "\n")
    End Function

    Private Class VisualNode
        Public Property XmlNode As XmlNode
        Public Property X As Integer
        Public Property Y As Integer
        Public Property Width As Integer
        Public Property Height As Integer
        Public ReadOnly Property Area As Integer
            Get
                Return Width * Height
            End Get
        End Property
    End Class

    'Private visualNodes As New List(Of VisualNode)

    Private Sub CollectVisualNodes(xmlNode As XmlNode, list As List(Of VisualNode))
        If xmlNode.Name = "node" Then
            Dim bounds = xmlNode.Attributes("bounds")?.Value
            If bounds IsNot Nothing Then
                Dim coords = bounds.Replace("[", "").Replace("]", ",").Split(","c)
                If coords.Length >= 4 Then
                    Dim x = Integer.Parse(coords(0)) - minX
                    Dim y = Integer.Parse(coords(1)) - minY
                    Dim x2 = Integer.Parse(coords(2)) - minX
                    Dim y2 = Integer.Parse(coords(3)) - minY
                    Dim width = x2 - x
                    Dim height = y2 - y

                    list.Add(New VisualNode With {
                    .XmlNode = xmlNode,
                    .X = x,
                    .Y = y,
                    .Width = width,
                    .Height = height
                })
                End If
            End If
        End If

        For Each child As XmlNode In xmlNode.ChildNodes
            CollectVisualNodes(child, list)
        Next
    End Sub


    Private Sub ProcessNode(xmlNode As XmlNode, html As System.Text.StringBuilder)
        If xmlNode.Name = "node" Then
            Dim bounds = xmlNode.Attributes("bounds")?.Value
            If bounds IsNot Nothing Then
                Dim coords = bounds.Replace("[", "").Replace("]", ",").Split(","c)
                If coords.Length >= 4 Then
                    Dim x = Integer.Parse(coords(0)) - minX
                    Dim y = Integer.Parse(coords(1)) - minY
                    Dim x2 = Integer.Parse(coords(2)) - minX
                    Dim y2 = Integer.Parse(coords(3)) - minY
                    Dim width = x2 - x
                    Dim height = y2 - y

                    Dim text = xmlNode.Attributes("text")?.Value
                    Dim resId = xmlNode.Attributes("resource-id")?.Value
                    Dim className = xmlNode.Attributes("class")?.Value
                    Dim contentDesc = xmlNode.Attributes("content-desc")?.Value

                    Dim allAttributes As New List(Of String)
                    For Each attr As XmlAttribute In xmlNode.Attributes
                        Dim key = attr.Name
                        Dim val = EscapeJs(attr.Value)
                        allAttributes.Add($"{key}='{val}'")
                    Next

                    Dim fullAttrString As String = String.Join(" ", allAttributes)

                    Dim infoObject As String = $"{{ info: '{EscapeJs(fullAttrString)}' }}"

                    Dim tooltip = $"text: {text}" & vbLf & $"id: {resId}" & vbLf & $"class: {className}"

                    html.AppendLine($"<div class='node' style='left:{x}px; top:{y}px; width:{width}px; height:{height}px;' " &
                $"title='{System.Security.SecurityElement.Escape(tooltip)}' " &
                $"onclick=""printvb({infoObject})"">")


                    If Not String.IsNullOrWhiteSpace(text) Then
                        html.AppendLine(System.Web.HttpUtility.HtmlEncode(text))
                    End If

                    html.AppendLine("</div>")
                End If
            End If
        End If

        For Each child As XmlNode In xmlNode.ChildNodes
            ProcessNode(child, html)
        Next
    End Sub


    Private Function RunCommand(command As String, arguments As String) As String
        Try
            Dim process As New Process()
            process.StartInfo.FileName = command
            process.StartInfo.Arguments = arguments
            process.StartInfo.UseShellExecute = False
            process.StartInfo.RedirectStandardOutput = True
            process.StartInfo.RedirectStandardError = True
            process.StartInfo.CreateNoWindow = True

            process.Start()
            Dim output As String = process.StandardOutput.ReadToEnd()
            Dim errorOutput As String = process.StandardError.ReadToEnd()
            process.WaitForExit()

            Return output & If(String.IsNullOrWhiteSpace(errorOutput), "", vbCrLf & errorOutput)
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function

    Private Sub WebView_NavigationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs)
        Dim term As New mybridge(Me)
        WebView21.CoreWebView2.AddHostObjectToScript("mybridge", term)
    End Sub

    Dim deviceMap As New Dictionary(Of String, String)
    Private Async Sub AndroidViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Await WebView21.EnsureCoreWebView2Async()

        AddHandler WebView21.NavigationCompleted, AddressOf WebView_NavigationCompleted





        loadphones()
        'Dim xmlFile = "dump.xml"
        'Dim htmlFile = "view.html"
        'GenerateHtmlFromDump(xmlFile, htmlFile)
        ' Await FetchAndRenderViewAsync()
        'WebView21.Source = New Uri(Path.Combine(Application.StartupPath, htmlFile))
        'refresher.Start()
        logtext.AutoWordSelection = False
    End Sub
    Private Sub loadphones()
        If Not Directory.Exists(tools_Path) Then
            Directory.CreateDirectory(tools_Path)
        End If
        If Not File.Exists(adb_Path) Then
            File.WriteAllBytes(adb_Path, My.Resources.adb)

        End If
        If Not File.Exists(adb_lib1) Then
            File.WriteAllBytes(adb_lib1, My.Resources.AdbWinApi)
        End If
        If Not File.Exists(adb_libusb) Then
            File.WriteAllBytes(adb_libusb, My.Resources.AdbWinUsbApi)
        End If
        Dim adbOutput As String = RunCommand(adb_Path, "devices")
        Dim lines = adbOutput.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
        Combophones.Items.Clear()
        Dim deviceList As New List(Of String)
        For Each line In lines
            If line.EndsWith("device") AndAlso Not line.StartsWith("List of devices") Then
                Dim serial = line.Split(New Char() {vbTab, " "c}, StringSplitOptions.RemoveEmptyEntries)(0)

                ' Get model and manufacturer
                Dim model = RunCommand(adb_Path, $"-s {serial} shell getprop ro.product.model").Trim()
                Dim brand = RunCommand(adb_Path, $"-s {serial} shell getprop ro.product.manufacturer").Trim()
                Dim displayName = $"{brand} {model}"
                deviceList.Add($"{brand} {model}")
                deviceMap(displayName) = serial
                Combophones.Items.Add(displayName)
            End If
        Next
        Me.deviceMap = deviceMap

        If Combophones.Items.Count > 0 Then
            Combophones.SelectedIndex = 0 ' auto-select first
        End If
        If deviceList.Count = 0 Then
            '  MessageBox.Show("No connected devices found.", "ADB", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If MyMsg.Show("No connected devices found", $"1- go to phone settings >  Developer options{vbNewLine}2- Enable USB Debugging{vbNewLine}3- Connect mobile with usb.{vbNewLine}4- Click OK to scan again", msgtype.Confirm, True) <> DialogResult.OK Then
                Me.Close()
                Return
            End If
            loadphones()
        Else
            Dim result As String = "Connected Devices:" & vbCrLf & String.Join(vbCrLf, deviceList)
            'MessageBox.Show(result, "ADB Devices", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Async Function FetchAndRenderViewAsync() As Task

        If Combophones.SelectedItem Is Nothing Then
            BTAlerter.Warnings("No device selected.")
            Return
        End If

        Dim displayText = Combophones.SelectedItem.ToString()
        Dim serial = deviceMap(displayText) ' Look up actual serial from map


        ' Run for selected device
        Dim dumpResult = RunCommand(adb_Path, $"-s {serial} shell uiautomator dump")
        Log_d("Dump Result: ", dumpResult)

        'Await Task.Delay(1000)

        Dim pullResult = RunCommand(adb_Path, $"-s {serial} pull /storage/emulated/0/window_dump.xml dump.xml")
        Log_d("Pull Result: ", pullResult)

        If File.Exists("dump.xml") Then
            Dim htmlFile = "view.html"
            GenerateHtmlFromDump("dump.xml", htmlFile)
            WebView21.CoreWebView2.Navigate(New Uri(Path.Combine(Application.StartupPath, htmlFile)).AbsoluteUri)
            BTAlerter.Success("UI view updated successfully.")
        Else
            BTAlerter.erroes("Error: Failed to retrieve UI dump.")
        End If
    End Function
    Private Sub mytitle_MouseDown(sender As Object, e As MouseEventArgs) Handles mytitle.MouseDown, myico.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                ReleaseCapture()
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WebView21_Click(sender As Object, e As EventArgs) Handles WebView21.Click

    End Sub

    Private Async Sub srchbtn_Click(sender As Object, e As EventArgs) Handles srchbtn.Click

        Await FetchAndRenderViewAsync()
    End Sub


    Private Sub closbtn_Click_1(sender As Object, e As EventArgs) Handles closbtn.Click
        Me.Close()
    End Sub
    Dim keepmeto As Boolean = True
    Private Sub pinbtn_Click(sender As Object, e As EventArgs) Handles pinbtn.Click
        If keepmeto Then
            '  button1.Text = "yes on top"
            pinbtn.ForeColor = Color.DeepSkyBlue
            pinbtn.RectColor = Color.DeepSkyBlue
            Dim HwndTopmost As IntPtr = New IntPtr(-1)
            SetWindowPos(Me.Handle, HwndTopmost, 0, 0, 0, 0, TOPMOST_FLAGS)
            keepmeto = False
        Else
            '  button1.Text = "not on top"
            pinbtn.ForeColor = Color.White
            pinbtn.RectColor = Color.Gray
            Dim HwndTopmost As IntPtr = New IntPtr(-2)
            SetWindowPos(Me.Handle, HwndTopmost, 0, 0, 0, 0, TOPMOST_FLAGS)
            keepmeto = True
        End If
    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon1.Click
        logtext.Text = ""
    End Sub

    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon2.Click
        Try
            System.Windows.Forms.Clipboard.SetText(logtext.Text)
            BTAlerter.Success("Copy success")
        Catch ex As Exception

        End Try
    End Sub
End Class