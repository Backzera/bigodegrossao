<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CameraMonitor
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
        Me.viewimage = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DrakeWidth_W4 = New DrakeUI.Framework.DrakeWidth_W()
        Me.combosizes = New DrakeUI.Framework.DrakeUIComboBox()
        Me.DrakeWidth_W2 = New DrakeUI.Framework.DrakeWidth_W()
        Me.comboTargts = New DrakeUI.Framework.DrakeUIComboBox()
        Me.qualitydrop = New DrakeUI.Framework.DrakeUIComboBox()
        Me.stopbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W3 = New DrakeUI.Framework.DrakeWidth_W()
        Me.startbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.mainstatelabel = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.flashbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W9 = New DrakeUI.Framework.DrakeWidth_W()
        Me.Button3 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W11 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeUIButtonIcon1 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.savetimer = New System.Windows.Forms.Timer(Me.components)
        Me.statetimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DrakeWidth_W12 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W10 = New DrakeUI.Framework.DrakeWidth_W()
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.viewimage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pinbtn
        '
        Me.pinbtn.Location = New System.Drawing.Point(347, 5)
        '
        'minibtn
        '
        Me.minibtn.Location = New System.Drawing.Point(394, 5)
        '
        'closbtn
        '
        Me.closbtn.Location = New System.Drawing.Point(441, 5)
        '
        'mytitle
        '
        Me.mytitle.Size = New System.Drawing.Size(473, 18)
        '
        'viewimage
        '
        Me.viewimage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewimage.Location = New System.Drawing.Point(2, 110)
        Me.viewimage.Name = "viewimage"
        Me.viewimage.Size = New System.Drawing.Size(401, 308)
        Me.viewimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.viewimage.TabIndex = 40
        Me.viewimage.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel3.Controls.Add(Me.DrakeWidth_W4)
        Me.Panel3.Controls.Add(Me.combosizes)
        Me.Panel3.Controls.Add(Me.DrakeWidth_W2)
        Me.Panel3.Controls.Add(Me.comboTargts)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(2, 71)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel3.Size = New System.Drawing.Size(401, 39)
        Me.Panel3.TabIndex = 41
        '
        'DrakeWidth_W4
        '
        Me.DrakeWidth_W4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W4.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W4.Location = New System.Drawing.Point(330, 10)
        Me.DrakeWidth_W4.Name = "DrakeWidth_W4"
        Me.DrakeWidth_W4.Size = New System.Drawing.Size(10, 19)
        Me.DrakeWidth_W4.TabIndex = 13
        '
        'combosizes
        '
        Me.combosizes.Dock = System.Windows.Forms.DockStyle.Left
        Me.combosizes.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.combosizes.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.combosizes.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.combosizes.ForeColor = System.Drawing.Color.White
        Me.combosizes.Location = New System.Drawing.Point(175, 10)
        Me.combosizes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.combosizes.MinimumSize = New System.Drawing.Size(63, 0)
        Me.combosizes.Name = "combosizes"
        Me.combosizes.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.combosizes.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.combosizes.RectColor = System.Drawing.Color.Gray
        Me.combosizes.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.combosizes.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.combosizes.Size = New System.Drawing.Size(155, 25)
        Me.combosizes.Style = DrakeUI.Framework.UIStyle.Custom
        Me.combosizes.StyleCustomMode = True
        Me.combosizes.TabIndex = 10
        Me.combosizes.Text = "Resolution"
        Me.combosizes.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DrakeWidth_W2
        '
        Me.DrakeWidth_W2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W2.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W2.Location = New System.Drawing.Point(165, 10)
        Me.DrakeWidth_W2.Name = "DrakeWidth_W2"
        Me.DrakeWidth_W2.Size = New System.Drawing.Size(10, 19)
        Me.DrakeWidth_W2.TabIndex = 15
        '
        'comboTargts
        '
        Me.comboTargts.Dock = System.Windows.Forms.DockStyle.Left
        Me.comboTargts.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.comboTargts.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.comboTargts.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.comboTargts.ForeColor = System.Drawing.Color.White
        Me.comboTargts.Items.AddRange(New Object() {"Front Camera", "Back Camera"})
        Me.comboTargts.Location = New System.Drawing.Point(10, 10)
        Me.comboTargts.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.comboTargts.MinimumSize = New System.Drawing.Size(63, 0)
        Me.comboTargts.Name = "comboTargts"
        Me.comboTargts.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.comboTargts.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.comboTargts.RectColor = System.Drawing.Color.Gray
        Me.comboTargts.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.comboTargts.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.comboTargts.Size = New System.Drawing.Size(155, 25)
        Me.comboTargts.Style = DrakeUI.Framework.UIStyle.Custom
        Me.comboTargts.StyleCustomMode = True
        Me.comboTargts.TabIndex = 9
        Me.comboTargts.Text = "Front Camera"
        Me.comboTargts.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'qualitydrop
        '
        Me.qualitydrop.Dock = System.Windows.Forms.DockStyle.Top
        Me.qualitydrop.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.qualitydrop.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.qualitydrop.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.qualitydrop.ForeColor = System.Drawing.Color.White
        Me.qualitydrop.Items.AddRange(New Object() {"5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60", "65", "70", "75", "80", "85", "90"})
        Me.qualitydrop.Location = New System.Drawing.Point(10, 90)
        Me.qualitydrop.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.qualitydrop.MinimumSize = New System.Drawing.Size(63, 0)
        Me.qualitydrop.Name = "qualitydrop"
        Me.qualitydrop.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.qualitydrop.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.qualitydrop.RectColor = System.Drawing.Color.Gray
        Me.qualitydrop.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.qualitydrop.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.qualitydrop.Size = New System.Drawing.Size(63, 25)
        Me.qualitydrop.Style = DrakeUI.Framework.UIStyle.Custom
        Me.qualitydrop.StyleCustomMode = True
        Me.qualitydrop.TabIndex = 14
        Me.qualitydrop.Text = "30"
        Me.qualitydrop.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stopbtn
        '
        Me.stopbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.stopbtn.Dock = System.Windows.Forms.DockStyle.Top
        Me.stopbtn.Enabled = False
        Me.stopbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stopbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stopbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stopbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stopbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stopbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.stopbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.stopbtn.Location = New System.Drawing.Point(10, 50)
        Me.stopbtn.Name = "stopbtn"
        Me.stopbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.stopbtn.RectColor = System.Drawing.Color.Gray
        Me.stopbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.stopbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stopbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.stopbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.stopbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.stopbtn.Size = New System.Drawing.Size(62, 25)
        Me.stopbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.stopbtn.Symbol = 61516
        Me.stopbtn.TabIndex = 8
        '
        'DrakeWidth_W3
        '
        Me.DrakeWidth_W3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W3.Dock = System.Windows.Forms.DockStyle.Top
        Me.DrakeWidth_W3.Location = New System.Drawing.Point(10, 35)
        Me.DrakeWidth_W3.Name = "DrakeWidth_W3"
        Me.DrakeWidth_W3.Size = New System.Drawing.Size(62, 15)
        Me.DrakeWidth_W3.TabIndex = 12
        '
        'startbtn
        '
        Me.startbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.startbtn.Dock = System.Windows.Forms.DockStyle.Top
        Me.startbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.startbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.startbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.startbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.startbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.startbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.startbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.startbtn.Location = New System.Drawing.Point(10, 10)
        Me.startbtn.Name = "startbtn"
        Me.startbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.startbtn.RectColor = System.Drawing.Color.Gray
        Me.startbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.startbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.startbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.startbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.startbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.startbtn.Size = New System.Drawing.Size(62, 25)
        Me.startbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.startbtn.Symbol = 61515
        Me.startbtn.TabIndex = 7
        '
        'mainstatelabel
        '
        Me.mainstatelabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.mainstatelabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mainstatelabel.Font = New System.Drawing.Font("Cascadia Code", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainstatelabel.ForeColor = System.Drawing.Color.White
        Me.mainstatelabel.Location = New System.Drawing.Point(5, 5)
        Me.mainstatelabel.Name = "mainstatelabel"
        Me.mainstatelabel.Size = New System.Drawing.Size(391, 24)
        Me.mainstatelabel.TabIndex = 1
        Me.mainstatelabel.Text = "..."
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel4.Controls.Add(Me.mainstatelabel)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(2, 418)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel4.Size = New System.Drawing.Size(401, 34)
        Me.Panel4.TabIndex = 50
        '
        'flashbtn
        '
        Me.flashbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flashbtn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flashbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.flashbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.flashbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.flashbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.flashbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.flashbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.flashbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.flashbtn.Location = New System.Drawing.Point(10, 229)
        Me.flashbtn.Name = "flashbtn"
        Me.flashbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.flashbtn.RectColor = System.Drawing.Color.Gray
        Me.flashbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.flashbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.flashbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.flashbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.flashbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.flashbtn.Size = New System.Drawing.Size(62, 28)
        Me.flashbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.flashbtn.Symbol = 61671
        Me.flashbtn.SymbolSize = 21
        Me.flashbtn.TabIndex = 13
        Me.flashbtn.Tag = "off"
        '
        'DrakeWidth_W9
        '
        Me.DrakeWidth_W9.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DrakeWidth_W9.Location = New System.Drawing.Point(10, 257)
        Me.DrakeWidth_W9.Name = "DrakeWidth_W9"
        Me.DrakeWidth_W9.Size = New System.Drawing.Size(62, 24)
        Me.DrakeWidth_W9.TabIndex = 12
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Button3.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button3.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button3.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button3.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button3.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button3.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.Button3.ForeHoverColor = System.Drawing.Color.Gray
        Me.Button3.Location = New System.Drawing.Point(10, 281)
        Me.Button3.Name = "Button3"
        Me.Button3.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.Button3.RectColor = System.Drawing.Color.Gray
        Me.Button3.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Button3.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button3.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Button3.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Button3.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.Button3.Size = New System.Drawing.Size(62, 28)
        Me.Button3.Style = DrakeUI.Framework.UIStyle.Custom
        Me.Button3.Symbol = 57572
        Me.Button3.SymbolSize = 21
        Me.Button3.TabIndex = 11
        Me.Button3.Tag = "off"
        '
        'DrakeWidth_W11
        '
        Me.DrakeWidth_W11.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DrakeWidth_W11.Location = New System.Drawing.Point(10, 309)
        Me.DrakeWidth_W11.Name = "DrakeWidth_W11"
        Me.DrakeWidth_W11.Size = New System.Drawing.Size(62, 24)
        Me.DrakeWidth_W11.TabIndex = 10
        '
        'DrakeUIButtonIcon1
        '
        Me.DrakeUIButtonIcon1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DrakeUIButtonIcon1.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon1.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon1.Location = New System.Drawing.Point(10, 333)
        Me.DrakeUIButtonIcon1.Name = "DrakeUIButtonIcon1"
        Me.DrakeUIButtonIcon1.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon1.RectColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon1.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.DrakeUIButtonIcon1.Size = New System.Drawing.Size(62, 28)
        Me.DrakeUIButtonIcon1.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon1.Symbol = 61470
        Me.DrakeUIButtonIcon1.SymbolSize = 21
        Me.DrakeUIButtonIcon1.TabIndex = 9
        '
        'savetimer
        '
        Me.savetimer.Interval = 1
        '
        'statetimer
        '
        Me.statetimer.Interval = 1000
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Controls.Add(Me.qualitydrop)
        Me.Panel2.Controls.Add(Me.DrakeWidth_W12)
        Me.Panel2.Controls.Add(Me.stopbtn)
        Me.Panel2.Controls.Add(Me.DrakeWidth_W3)
        Me.Panel2.Controls.Add(Me.startbtn)
        Me.Panel2.Controls.Add(Me.flashbtn)
        Me.Panel2.Controls.Add(Me.DrakeWidth_W9)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.DrakeWidth_W11)
        Me.Panel2.Controls.Add(Me.DrakeUIButtonIcon1)
        Me.Panel2.Controls.Add(Me.DrakeWidth_W10)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(403, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel2.Size = New System.Drawing.Size(82, 381)
        Me.Panel2.TabIndex = 51
        '
        'DrakeWidth_W12
        '
        Me.DrakeWidth_W12.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W12.Dock = System.Windows.Forms.DockStyle.Top
        Me.DrakeWidth_W12.Location = New System.Drawing.Point(10, 75)
        Me.DrakeWidth_W12.Name = "DrakeWidth_W12"
        Me.DrakeWidth_W12.Size = New System.Drawing.Size(62, 15)
        Me.DrakeWidth_W12.TabIndex = 15
        '
        'DrakeWidth_W10
        '
        Me.DrakeWidth_W10.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DrakeWidth_W10.Location = New System.Drawing.Point(10, 361)
        Me.DrakeWidth_W10.Name = "DrakeWidth_W10"
        Me.DrakeWidth_W10.Size = New System.Drawing.Size(62, 10)
        Me.DrakeWidth_W10.TabIndex = 14
        '
        'CameraMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 454)
        Me.Controls.Add(Me.viewimage)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.MinimumSize = New System.Drawing.Size(432, 402)
        Me.Name = "CameraMonitor"
        Me.Text = "BT | Camera"
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.viewimage, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.viewimage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents viewimage As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents stopbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents startbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents comboTargts As DrakeUI.Framework.DrakeUIComboBox
    Friend WithEvents mainstatelabel As Label
    Friend WithEvents combosizes As DrakeUI.Framework.DrakeUIComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents DrakeUIButtonIcon1 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents Button3 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W11 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents savetimer As Timer
    Friend WithEvents statetimer As Timer
    Friend WithEvents DrakeWidth_W3 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents qualitydrop As DrakeUI.Framework.DrakeUIComboBox
    Friend WithEvents DrakeWidth_W4 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents flashbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W9 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DrakeWidth_W10 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W2 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W12 As DrakeUI.Framework.DrakeWidth_W
End Class
