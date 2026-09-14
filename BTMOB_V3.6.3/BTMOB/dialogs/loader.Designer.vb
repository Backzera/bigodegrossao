<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class loader
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(loader))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.infopanel = New System.Windows.Forms.Panel()
        Me.mywebview = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.conkeytext = New DrakeUI.Framework.DrakeUITextBox()
        Me.DrakeUIButtonIcon7 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.srvrtext = New DrakeUI.Framework.DrakeUITextBox()
        Me.DrakeUIButtonIcon6 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.langtext = New DrakeUI.Framework.DrakeUIComboBox()
        Me.DrakeUIButtonIcon4 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.newkeybtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeUIButtonIcon5 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.pintext = New DrakeUI.Framework.DrakeUITextBox()
        Me.remtitle = New System.Windows.Forms.Label()
        Me.checkremember = New DrakeUI.Framework.DrakeUIOSSwitch()
        Me.DrakeUIButtonIcon1 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.passtext = New DrakeUI.Framework.DrakeUITextBox()
        Me.DrakeUIButtonIcon3 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.emailtext = New DrakeUI.Framework.DrakeUITextBox()
        Me.DrakeWidth_W2 = New DrakeUI.Framework.DrakeWidth_W()
        Me.entrbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.loadpanel = New System.Windows.Forms.Panel()
        Me.loadwbv = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DrakeUIButtonIcon2 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.loadimage = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.msgbody = New DrakeUI.Framework.DrakeUILabel()
        Me.loadingtime = New System.Windows.Forms.Timer(Me.components)
        Me.loadworker = New System.ComponentModel.BackgroundWorker()
        Me.DrakeWidth_W3 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W4 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W5 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W6 = New DrakeUI.Framework.DrakeWidth_W()
        Me.keychecker = New System.ComponentModel.BackgroundWorker()
        Me.Panel3.SuspendLayout()
        Me.infopanel.SuspendLayout()
        CType(Me.mywebview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.loadpanel.SuspendLayout()
        CType(Me.loadwbv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.loadimage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.infopanel)
        Me.Panel3.Controls.Add(Me.loadpanel)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(768, 782)
        Me.Panel3.TabIndex = 5
        '
        'infopanel
        '
        Me.infopanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.infopanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.infopanel.Controls.Add(Me.mywebview)
        Me.infopanel.Controls.Add(Me.Panel4)
        Me.infopanel.Controls.Add(Me.newkeybtn)
        Me.infopanel.Controls.Add(Me.DrakeUIButtonIcon5)
        Me.infopanel.Controls.Add(Me.pintext)
        Me.infopanel.Controls.Add(Me.remtitle)
        Me.infopanel.Controls.Add(Me.checkremember)
        Me.infopanel.Controls.Add(Me.DrakeUIButtonIcon1)
        Me.infopanel.Controls.Add(Me.passtext)
        Me.infopanel.Controls.Add(Me.DrakeUIButtonIcon3)
        Me.infopanel.Controls.Add(Me.emailtext)
        Me.infopanel.Controls.Add(Me.DrakeWidth_W2)
        Me.infopanel.Controls.Add(Me.entrbtn)
        Me.infopanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.infopanel.Enabled = False
        Me.infopanel.Location = New System.Drawing.Point(0, 53)
        Me.infopanel.Name = "infopanel"
        Me.infopanel.Size = New System.Drawing.Size(768, 691)
        Me.infopanel.TabIndex = 4
        '
        'mywebview
        '
        Me.mywebview.AllowExternalDrop = True
        Me.mywebview.CreationProperties = Nothing
        Me.mywebview.DefaultBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.mywebview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mywebview.Location = New System.Drawing.Point(0, 1)
        Me.mywebview.Name = "mywebview"
        Me.mywebview.Size = New System.Drawing.Size(768, 612)
        Me.mywebview.TabIndex = 26
        Me.mywebview.ZoomFactor = 1.0R
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.conkeytext)
        Me.Panel4.Controls.Add(Me.DrakeUIButtonIcon7)
        Me.Panel4.Controls.Add(Me.srvrtext)
        Me.Panel4.Controls.Add(Me.DrakeUIButtonIcon6)
        Me.Panel4.Controls.Add(Me.langtext)
        Me.Panel4.Controls.Add(Me.DrakeUIButtonIcon4)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 613)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(768, 78)
        Me.Panel4.TabIndex = 27
        Me.Panel4.Visible = False
        '
        'conkeytext
        '
        Me.conkeytext.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.conkeytext.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.conkeytext.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.conkeytext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.conkeytext.ForeColor = System.Drawing.Color.White
        Me.conkeytext.ForeDisableColor = System.Drawing.Color.White
        Me.conkeytext.Location = New System.Drawing.Point(58, 45)
        Me.conkeytext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.conkeytext.Maximum = 2147483647.0R
        Me.conkeytext.Minimum = -2147483648.0R
        Me.conkeytext.Name = "conkeytext"
        Me.conkeytext.Padding = New System.Windows.Forms.Padding(5)
        Me.conkeytext.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.conkeytext.RectColor = System.Drawing.Color.Gray
        Me.conkeytext.RectDisableColor = System.Drawing.Color.Gray
        Me.conkeytext.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.conkeytext.Size = New System.Drawing.Size(311, 25)
        Me.conkeytext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.conkeytext.TabIndex = 26
        Me.conkeytext.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.conkeytext.Watermark = "Connection Key"
        '
        'DrakeUIButtonIcon7
        '
        Me.DrakeUIButtonIcon7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon7.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon7.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon7.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon7.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon7.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon7.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon7.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon7.Location = New System.Drawing.Point(6, 45)
        Me.DrakeUIButtonIcon7.Name = "DrakeUIButtonIcon7"
        Me.DrakeUIButtonIcon7.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon7.RectColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon7.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon7.RectHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon7.RectPressColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon7.RectSelectedColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon7.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.DrakeUIButtonIcon7.Size = New System.Drawing.Size(45, 25)
        Me.DrakeUIButtonIcon7.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon7.Symbol = 57454
        Me.DrakeUIButtonIcon7.SymbolSize = 20
        Me.DrakeUIButtonIcon7.TabIndex = 27
        '
        'srvrtext
        '
        Me.srvrtext.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.srvrtext.Enabled = False
        Me.srvrtext.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.srvrtext.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.srvrtext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.srvrtext.ForeColor = System.Drawing.Color.White
        Me.srvrtext.ForeDisableColor = System.Drawing.Color.White
        Me.srvrtext.Location = New System.Drawing.Point(58, 8)
        Me.srvrtext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.srvrtext.Maximum = 2147483647.0R
        Me.srvrtext.Minimum = -2147483648.0R
        Me.srvrtext.Name = "srvrtext"
        Me.srvrtext.Padding = New System.Windows.Forms.Padding(5)
        Me.srvrtext.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.srvrtext.RectColor = System.Drawing.Color.Gray
        Me.srvrtext.RectDisableColor = System.Drawing.Color.Gray
        Me.srvrtext.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.srvrtext.Size = New System.Drawing.Size(311, 25)
        Me.srvrtext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.srvrtext.TabIndex = 24
        Me.srvrtext.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.srvrtext.Watermark = "Server"
        '
        'DrakeUIButtonIcon6
        '
        Me.DrakeUIButtonIcon6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon6.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon6.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon6.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon6.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon6.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon6.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon6.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon6.Location = New System.Drawing.Point(6, 8)
        Me.DrakeUIButtonIcon6.Name = "DrakeUIButtonIcon6"
        Me.DrakeUIButtonIcon6.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon6.RectColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon6.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon6.RectHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon6.RectPressColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon6.RectSelectedColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon6.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.DrakeUIButtonIcon6.Size = New System.Drawing.Size(45, 25)
        Me.DrakeUIButtonIcon6.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon6.Symbol = 61504
        Me.DrakeUIButtonIcon6.SymbolSize = 20
        Me.DrakeUIButtonIcon6.TabIndex = 25
        '
        'langtext
        '
        Me.langtext.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.langtext.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.langtext.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.langtext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.langtext.ForeColor = System.Drawing.Color.White
        Me.langtext.Items.AddRange(New Object() {"English", "العربية", "中国人", "Русский", "Türkçe", "Español", "Português"})
        Me.langtext.Location = New System.Drawing.Point(569, 8)
        Me.langtext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.langtext.MinimumSize = New System.Drawing.Size(63, 0)
        Me.langtext.Name = "langtext"
        Me.langtext.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.langtext.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.langtext.RectColor = System.Drawing.Color.Gray
        Me.langtext.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.langtext.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.langtext.Size = New System.Drawing.Size(189, 25)
        Me.langtext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.langtext.TabIndex = 12
        Me.langtext.Text = "Select Language"
        Me.langtext.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.langtext.Watermark = "Language"
        '
        'DrakeUIButtonIcon4
        '
        Me.DrakeUIButtonIcon4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon4.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon4.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon4.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon4.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon4.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon4.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon4.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon4.Location = New System.Drawing.Point(517, 8)
        Me.DrakeUIButtonIcon4.Name = "DrakeUIButtonIcon4"
        Me.DrakeUIButtonIcon4.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon4.RectColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon4.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon4.RectHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon4.RectPressColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon4.RectSelectedColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon4.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.DrakeUIButtonIcon4.Size = New System.Drawing.Size(45, 25)
        Me.DrakeUIButtonIcon4.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon4.Symbol = 57571
        Me.DrakeUIButtonIcon4.TabIndex = 13
        '
        'newkeybtn
        '
        Me.newkeybtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.newkeybtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.newkeybtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.newkeybtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.newkeybtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.newkeybtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.newkeybtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.newkeybtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.newkeybtn.Location = New System.Drawing.Point(809, 333)
        Me.newkeybtn.Name = "newkeybtn"
        Me.newkeybtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.newkeybtn.RectColor = System.Drawing.Color.Gray
        Me.newkeybtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.newkeybtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.newkeybtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.newkeybtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.newkeybtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.newkeybtn.Size = New System.Drawing.Size(160, 26)
        Me.newkeybtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.newkeybtn.Symbol = 0
        Me.newkeybtn.TabIndex = 18
        Me.newkeybtn.Text = "• New Key"
        Me.newkeybtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DrakeUIButtonIcon5
        '
        Me.DrakeUIButtonIcon5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon5.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon5.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon5.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon5.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon5.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon5.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon5.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon5.Location = New System.Drawing.Point(757, 300)
        Me.DrakeUIButtonIcon5.Name = "DrakeUIButtonIcon5"
        Me.DrakeUIButtonIcon5.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon5.RectColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon5.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon5.RectHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon5.RectPressColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon5.RectSelectedColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon5.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.DrakeUIButtonIcon5.Size = New System.Drawing.Size(45, 25)
        Me.DrakeUIButtonIcon5.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon5.Symbol = 61758
        Me.DrakeUIButtonIcon5.SymbolSize = 20
        Me.DrakeUIButtonIcon5.TabIndex = 17
        '
        'pintext
        '
        Me.pintext.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.pintext.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pintext.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pintext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.pintext.ForeColor = System.Drawing.Color.White
        Me.pintext.Location = New System.Drawing.Point(809, 300)
        Me.pintext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pintext.Maximum = 2147483647.0R
        Me.pintext.Minimum = -2147483648.0R
        Me.pintext.Name = "pintext"
        Me.pintext.Padding = New System.Windows.Forms.Padding(5)
        Me.pintext.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.pintext.RectColor = System.Drawing.Color.Gray
        Me.pintext.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.pintext.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.pintext.Size = New System.Drawing.Size(417, 25)
        Me.pintext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.pintext.TabIndex = 16
        Me.pintext.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.pintext.Watermark = "Secret key"
        '
        'remtitle
        '
        Me.remtitle.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.remtitle.ForeColor = System.Drawing.Color.White
        Me.remtitle.Location = New System.Drawing.Point(864, 234)
        Me.remtitle.Name = "remtitle"
        Me.remtitle.Size = New System.Drawing.Size(181, 46)
        Me.remtitle.TabIndex = 15
        Me.remtitle.Text = "Remember me"
        Me.remtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'checkremember
        '
        Me.checkremember.Active = True
        Me.checkremember.ActiveColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.checkremember.ActiveText = ""
        Me.checkremember.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.checkremember.Font = New System.Drawing.Font("Cascadia Code", 12.0!)
        Me.checkremember.InActiveText = ""
        Me.checkremember.Location = New System.Drawing.Point(814, 248)
        Me.checkremember.Name = "checkremember"
        Me.checkremember.Size = New System.Drawing.Size(44, 17)
        Me.checkremember.Style = DrakeUI.Framework.UIStyle.Custom
        Me.checkremember.TabIndex = 14
        Me.checkremember.Text = "DrakeUIOSSwitch1"
        '
        'DrakeUIButtonIcon1
        '
        Me.DrakeUIButtonIcon1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon1.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon1.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon1.Location = New System.Drawing.Point(757, 204)
        Me.DrakeUIButtonIcon1.Name = "DrakeUIButtonIcon1"
        Me.DrakeUIButtonIcon1.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon1.RectColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon1.RectPressColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon1.RectSelectedColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.DrakeUIButtonIcon1.Size = New System.Drawing.Size(45, 25)
        Me.DrakeUIButtonIcon1.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon1.Symbol = 57345
        Me.DrakeUIButtonIcon1.SymbolSize = 20
        Me.DrakeUIButtonIcon1.TabIndex = 11
        '
        'passtext
        '
        Me.passtext.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.passtext.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.passtext.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.passtext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.passtext.ForeColor = System.Drawing.Color.White
        Me.passtext.Location = New System.Drawing.Point(809, 204)
        Me.passtext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.passtext.Maximum = 2147483647.0R
        Me.passtext.Minimum = -2147483648.0R
        Me.passtext.Name = "passtext"
        Me.passtext.Padding = New System.Windows.Forms.Padding(5)
        Me.passtext.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passtext.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.passtext.RectColor = System.Drawing.Color.Gray
        Me.passtext.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.passtext.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.passtext.Size = New System.Drawing.Size(417, 25)
        Me.passtext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.passtext.TabIndex = 10
        Me.passtext.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.passtext.Watermark = "Password"
        '
        'DrakeUIButtonIcon3
        '
        Me.DrakeUIButtonIcon3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon3.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon3.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon3.Location = New System.Drawing.Point(757, 169)
        Me.DrakeUIButtonIcon3.Name = "DrakeUIButtonIcon3"
        Me.DrakeUIButtonIcon3.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon3.RectColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon3.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.DrakeUIButtonIcon3.Size = New System.Drawing.Size(45, 25)
        Me.DrakeUIButtonIcon3.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon3.Symbol = 62142
        Me.DrakeUIButtonIcon3.SymbolSize = 20
        Me.DrakeUIButtonIcon3.TabIndex = 9
        '
        'emailtext
        '
        Me.emailtext.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.emailtext.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.emailtext.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.emailtext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.emailtext.ForeColor = System.Drawing.Color.White
        Me.emailtext.Location = New System.Drawing.Point(809, 169)
        Me.emailtext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.emailtext.Maximum = 2147483647.0R
        Me.emailtext.Minimum = -2147483648.0R
        Me.emailtext.Name = "emailtext"
        Me.emailtext.Padding = New System.Windows.Forms.Padding(5)
        Me.emailtext.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.emailtext.RectColor = System.Drawing.Color.Gray
        Me.emailtext.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.emailtext.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.emailtext.Size = New System.Drawing.Size(417, 25)
        Me.emailtext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.emailtext.TabIndex = 8
        Me.emailtext.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.emailtext.Watermark = "Email Address"
        '
        'DrakeWidth_W2
        '
        Me.DrakeWidth_W2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W2.Dock = System.Windows.Forms.DockStyle.Top
        Me.DrakeWidth_W2.Location = New System.Drawing.Point(0, 0)
        Me.DrakeWidth_W2.Name = "DrakeWidth_W2"
        Me.DrakeWidth_W2.Size = New System.Drawing.Size(768, 1)
        Me.DrakeWidth_W2.TabIndex = 7
        '
        'entrbtn
        '
        Me.entrbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.entrbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.entrbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.entrbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.entrbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.entrbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.entrbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.entrbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.entrbtn.Location = New System.Drawing.Point(1071, 377)
        Me.entrbtn.Name = "entrbtn"
        Me.entrbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.entrbtn.RectColor = System.Drawing.Color.Gray
        Me.entrbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.entrbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.entrbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.entrbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.entrbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.entrbtn.Size = New System.Drawing.Size(126, 26)
        Me.entrbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.entrbtn.Symbol = 78
        Me.entrbtn.TabIndex = 4
        Me.entrbtn.Text = "Enter"
        '
        'loadpanel
        '
        Me.loadpanel.Controls.Add(Me.loadwbv)
        Me.loadpanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.loadpanel.Location = New System.Drawing.Point(0, 53)
        Me.loadpanel.Name = "loadpanel"
        Me.loadpanel.Size = New System.Drawing.Size(768, 691)
        Me.loadpanel.TabIndex = 29
        '
        'loadwbv
        '
        Me.loadwbv.AllowExternalDrop = True
        Me.loadwbv.CreationProperties = Nothing
        Me.loadwbv.DefaultBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.loadwbv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.loadwbv.Location = New System.Drawing.Point(0, 0)
        Me.loadwbv.Name = "loadwbv"
        Me.loadwbv.Size = New System.Drawing.Size(768, 691)
        Me.loadwbv.TabIndex = 28
        Me.loadwbv.ZoomFactor = 1.0R
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Controls.Add(Me.DrakeUIButtonIcon2)
        Me.Panel2.Controls.Add(Me.loadimage)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.ForeColor = System.Drawing.Color.White
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel2.Size = New System.Drawing.Size(768, 53)
        Me.Panel2.TabIndex = 6
        '
        'DrakeUIButtonIcon2
        '
        Me.DrakeUIButtonIcon2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon2.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeUIButtonIcon2.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.Font = New System.Drawing.Font("Cascadia Code", 12.0!)
        Me.DrakeUIButtonIcon2.Location = New System.Drawing.Point(713, 5)
        Me.DrakeUIButtonIcon2.Name = "DrakeUIButtonIcon2"
        Me.DrakeUIButtonIcon2.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon2.RectColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.DrakeUIButtonIcon2.Size = New System.Drawing.Size(50, 43)
        Me.DrakeUIButtonIcon2.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon2.Symbol = 61453
        Me.DrakeUIButtonIcon2.SymbolSize = 26
        Me.DrakeUIButtonIcon2.TabIndex = 2
        '
        'loadimage
        '
        Me.loadimage.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.loadimage.Dock = System.Windows.Forms.DockStyle.Left
        Me.loadimage.Image = Global.BTMOB.My.Resources.Resources.logo
        Me.loadimage.Location = New System.Drawing.Point(5, 5)
        Me.loadimage.Name = "loadimage"
        Me.loadimage.Size = New System.Drawing.Size(74, 43)
        Me.loadimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.loadimage.TabIndex = 0
        Me.loadimage.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.msgbody)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 744)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(768, 38)
        Me.Panel1.TabIndex = 6
        '
        'msgbody
        '
        Me.msgbody.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.msgbody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.msgbody.Font = New System.Drawing.Font("Cascadia Code", 7.0!)
        Me.msgbody.ForeColor = System.Drawing.Color.White
        Me.msgbody.Location = New System.Drawing.Point(0, 0)
        Me.msgbody.Name = "msgbody"
        Me.msgbody.Padding = New System.Windows.Forms.Padding(10)
        Me.msgbody.Size = New System.Drawing.Size(768, 38)
        Me.msgbody.Style = DrakeUI.Framework.UIStyle.Custom
        Me.msgbody.TabIndex = 3
        Me.msgbody.Text = "..."
        Me.msgbody.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'loadingtime
        '
        Me.loadingtime.Interval = 1
        '
        'loadworker
        '
        '
        'DrakeWidth_W3
        '
        Me.DrakeWidth_W3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W3.Dock = System.Windows.Forms.DockStyle.Top
        Me.DrakeWidth_W3.Location = New System.Drawing.Point(1, 0)
        Me.DrakeWidth_W3.Name = "DrakeWidth_W3"
        Me.DrakeWidth_W3.Size = New System.Drawing.Size(767, 1)
        Me.DrakeWidth_W3.TabIndex = 23
        '
        'DrakeWidth_W4
        '
        Me.DrakeWidth_W4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W4.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W4.Location = New System.Drawing.Point(0, 0)
        Me.DrakeWidth_W4.Name = "DrakeWidth_W4"
        Me.DrakeWidth_W4.Size = New System.Drawing.Size(1, 781)
        Me.DrakeWidth_W4.TabIndex = 24
        '
        'DrakeWidth_W5
        '
        Me.DrakeWidth_W5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W5.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W5.Location = New System.Drawing.Point(767, 1)
        Me.DrakeWidth_W5.Name = "DrakeWidth_W5"
        Me.DrakeWidth_W5.Size = New System.Drawing.Size(1, 780)
        Me.DrakeWidth_W5.TabIndex = 25
        '
        'DrakeWidth_W6
        '
        Me.DrakeWidth_W6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DrakeWidth_W6.Location = New System.Drawing.Point(0, 781)
        Me.DrakeWidth_W6.Name = "DrakeWidth_W6"
        Me.DrakeWidth_W6.Size = New System.Drawing.Size(768, 1)
        Me.DrakeWidth_W6.TabIndex = 25
        '
        'keychecker
        '
        '
        'loader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(768, 782)
        Me.ControlBox = False
        Me.Controls.Add(Me.DrakeWidth_W5)
        Me.Controls.Add(Me.DrakeWidth_W3)
        Me.Controls.Add(Me.DrakeWidth_W4)
        Me.Controls.Add(Me.DrakeWidth_W6)
        Me.Controls.Add(Me.Panel3)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "loader"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "BT-Login"
        Me.Panel3.ResumeLayout(False)
        Me.infopanel.ResumeLayout(False)
        CType(Me.mywebview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.loadpanel.ResumeLayout(False)
        CType(Me.loadwbv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.loadimage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As Panel
    Friend WithEvents msgbody As DrakeUI.Framework.DrakeUILabel
    Friend WithEvents loadingtime As Timer
    Friend WithEvents loadworker As System.ComponentModel.BackgroundWorker
    Friend WithEvents infopanel As Panel
    Friend WithEvents entrbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DrakeUIButtonIcon2 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents emailtext As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents DrakeWidth_W2 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents langtext As DrakeUI.Framework.DrakeUIComboBox
    Friend WithEvents DrakeUIButtonIcon1 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents passtext As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents DrakeUIButtonIcon3 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeUIButtonIcon4 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents checkremember As DrakeUI.Framework.DrakeUIOSSwitch
    Friend WithEvents remtitle As Label
    Friend WithEvents DrakeUIButtonIcon5 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents pintext As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents newkeybtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents loadimage As PictureBox
    Friend WithEvents DrakeWidth_W3 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W4 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W5 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W6 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeUIButtonIcon6 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents srvrtext As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents mywebview As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents keychecker As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel4 As Panel
    Friend WithEvents conkeytext As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents DrakeUIButtonIcon7 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents loadwbv As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents loadpanel As Panel
End Class
