<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScreenReader
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.saveit = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.stopbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W3 = New DrakeUI.Framework.DrakeWidth_W()
        Me.startbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.viewimage = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DrakeUIButtonIcon11 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeUIButtonIcon10 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeUIButtonIcon9 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.inputtext = New DrakeUI.Framework.DrakeUITextBox()
        Me.statetimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.coloskeletonpick = New DrakeUI.Framework.DrakeUIColorPicker()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.zoom_out = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.Panel44 = New System.Windows.Forms.Panel()
        Me.zoom_in = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.savetimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.viewimage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel44.SuspendLayout()
        Me.SuspendLayout()
        '
        'myscr
        '
        Me.myscr.Image = Global.BTMOB.My.Resources.Resources.btloader
        Me.myscr.Visible = False
        '
        'pinbtn
        '
        Me.pinbtn.Location = New System.Drawing.Point(368, 5)
        '
        'minibtn
        '
        Me.minibtn.Location = New System.Drawing.Point(415, 5)
        '
        'closbtn
        '
        Me.closbtn.Location = New System.Drawing.Point(462, 5)
        '
        'mytitle
        '
        Me.mytitle.Size = New System.Drawing.Size(494, 18)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Controls.Add(Me.saveit)
        Me.Panel2.Controls.Add(Me.stopbtn)
        Me.Panel2.Controls.Add(Me.DrakeWidth_W3)
        Me.Panel2.Controls.Add(Me.startbtn)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(2, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel2.Size = New System.Drawing.Size(504, 45)
        Me.Panel2.TabIndex = 40
        '
        'saveit
        '
        Me.saveit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.saveit.Dock = System.Windows.Forms.DockStyle.Left
        Me.saveit.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.saveit.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.saveit.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.saveit.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.saveit.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.saveit.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.saveit.ForeHoverColor = System.Drawing.Color.Gray
        Me.saveit.Location = New System.Drawing.Point(10, 10)
        Me.saveit.Name = "saveit"
        Me.saveit.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.saveit.RectColor = System.Drawing.Color.Gray
        Me.saveit.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.saveit.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.saveit.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.saveit.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.saveit.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.saveit.Size = New System.Drawing.Size(41, 25)
        Me.saveit.Style = DrakeUI.Framework.UIStyle.Custom
        Me.saveit.Symbol = 57572
        Me.saveit.TabIndex = 37
        Me.saveit.Tag = "off"
        '
        'stopbtn
        '
        Me.stopbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.stopbtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.stopbtn.Enabled = False
        Me.stopbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stopbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stopbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stopbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stopbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stopbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.stopbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.stopbtn.Location = New System.Drawing.Point(374, 10)
        Me.stopbtn.Name = "stopbtn"
        Me.stopbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.stopbtn.RectColor = System.Drawing.Color.Gray
        Me.stopbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.stopbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stopbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.stopbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.stopbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.stopbtn.Size = New System.Drawing.Size(55, 25)
        Me.stopbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.stopbtn.Symbol = 61516
        Me.stopbtn.TabIndex = 6
        '
        'DrakeWidth_W3
        '
        Me.DrakeWidth_W3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W3.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W3.Location = New System.Drawing.Point(429, 10)
        Me.DrakeWidth_W3.Name = "DrakeWidth_W3"
        Me.DrakeWidth_W3.Size = New System.Drawing.Size(10, 25)
        Me.DrakeWidth_W3.TabIndex = 36
        '
        'startbtn
        '
        Me.startbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.startbtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.startbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.startbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.startbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.startbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.startbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.startbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.startbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.startbtn.Location = New System.Drawing.Point(439, 10)
        Me.startbtn.Name = "startbtn"
        Me.startbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.startbtn.RectColor = System.Drawing.Color.Gray
        Me.startbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.startbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.startbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.startbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.startbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.startbtn.Size = New System.Drawing.Size(55, 25)
        Me.startbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.startbtn.Symbol = 61515
        Me.startbtn.TabIndex = 5
        '
        'viewimage
        '
        Me.viewimage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewimage.Location = New System.Drawing.Point(61, 116)
        Me.viewimage.Name = "viewimage"
        Me.viewimage.Size = New System.Drawing.Size(445, 929)
        Me.viewimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.viewimage.TabIndex = 41
        Me.viewimage.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.DrakeUIButtonIcon11, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DrakeUIButtonIcon10, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DrakeUIButtonIcon9, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(61, 1045)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(445, 30)
        Me.TableLayoutPanel1.TabIndex = 49
        '
        'DrakeUIButtonIcon11
        '
        Me.DrakeUIButtonIcon11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DrakeUIButtonIcon11.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon11.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon11.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon11.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon11.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon11.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon11.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon11.Location = New System.Drawing.Point(299, 3)
        Me.DrakeUIButtonIcon11.Name = "DrakeUIButtonIcon11"
        Me.DrakeUIButtonIcon11.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon11.RectColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon11.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon11.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon11.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.DrakeUIButtonIcon11.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.DrakeUIButtonIcon11.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.DrakeUIButtonIcon11.Size = New System.Drawing.Size(143, 24)
        Me.DrakeUIButtonIcon11.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon11.Symbol = 61540
        Me.DrakeUIButtonIcon11.TabIndex = 23
        '
        'DrakeUIButtonIcon10
        '
        Me.DrakeUIButtonIcon10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DrakeUIButtonIcon10.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon10.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon10.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon10.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon10.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon10.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon10.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon10.Location = New System.Drawing.Point(151, 3)
        Me.DrakeUIButtonIcon10.Name = "DrakeUIButtonIcon10"
        Me.DrakeUIButtonIcon10.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon10.RectColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon10.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon10.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon10.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.DrakeUIButtonIcon10.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.DrakeUIButtonIcon10.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.DrakeUIButtonIcon10.Size = New System.Drawing.Size(142, 24)
        Me.DrakeUIButtonIcon10.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon10.Symbol = 57460
        Me.DrakeUIButtonIcon10.TabIndex = 22
        '
        'DrakeUIButtonIcon9
        '
        Me.DrakeUIButtonIcon9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DrakeUIButtonIcon9.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon9.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon9.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon9.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon9.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon9.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon9.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon9.Location = New System.Drawing.Point(3, 3)
        Me.DrakeUIButtonIcon9.Name = "DrakeUIButtonIcon9"
        Me.DrakeUIButtonIcon9.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon9.RectColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon9.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon9.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon9.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.DrakeUIButtonIcon9.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.DrakeUIButtonIcon9.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.DrakeUIButtonIcon9.Size = New System.Drawing.Size(142, 24)
        Me.DrakeUIButtonIcon9.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon9.Symbol = 61641
        Me.DrakeUIButtonIcon9.TabIndex = 21
        '
        'inputtext
        '
        Me.inputtext.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.inputtext.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.inputtext.FillColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.inputtext.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.inputtext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.inputtext.ForeColor = System.Drawing.Color.White
        Me.inputtext.Location = New System.Drawing.Point(61, 1075)
        Me.inputtext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.inputtext.Maximum = 2147483647.0R
        Me.inputtext.Minimum = -2147483648.0R
        Me.inputtext.Name = "inputtext"
        Me.inputtext.Padding = New System.Windows.Forms.Padding(5)
        Me.inputtext.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.inputtext.RectColor = System.Drawing.Color.Gray
        Me.inputtext.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.inputtext.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.inputtext.Size = New System.Drawing.Size(445, 25)
        Me.inputtext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.inputtext.TabIndex = 67
        Me.inputtext.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.inputtext.Watermark = "Send text"
        '
        'statetimer
        '
        Me.statetimer.Interval = 1000
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel3.Controls.Add(Me.coloskeletonpick)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Panel44)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(2, 116)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(59, 984)
        Me.Panel3.TabIndex = 68
        '
        'coloskeletonpick
        '
        Me.coloskeletonpick.Dock = System.Windows.Forms.DockStyle.Top
        Me.coloskeletonpick.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.coloskeletonpick.FillColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.coloskeletonpick.Font = New System.Drawing.Font("Cascadia Code", 12.0!)
        Me.coloskeletonpick.Location = New System.Drawing.Point(0, 130)
        Me.coloskeletonpick.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.coloskeletonpick.MinimumSize = New System.Drawing.Size(63, 0)
        Me.coloskeletonpick.Name = "coloskeletonpick"
        Me.coloskeletonpick.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.coloskeletonpick.Radius = 10
        Me.coloskeletonpick.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.coloskeletonpick.RectColor = System.Drawing.Color.Gray
        Me.coloskeletonpick.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.coloskeletonpick.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.coloskeletonpick.Size = New System.Drawing.Size(63, 31)
        Me.coloskeletonpick.Style = DrakeUI.Framework.UIStyle.Custom
        Me.coloskeletonpick.TabIndex = 52
        Me.coloskeletonpick.Text = "ColorPickers"
        Me.coloskeletonpick.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.coloskeletonpick.Value = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.coloskeletonpick.Watermark = ""
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.zoom_out)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 65)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(8)
        Me.Panel4.Size = New System.Drawing.Size(59, 65)
        Me.Panel4.TabIndex = 49
        '
        'zoom_out
        '
        Me.zoom_out.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.zoom_out.Cursor = System.Windows.Forms.Cursors.Hand
        Me.zoom_out.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zoom_out.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.zoom_out.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.zoom_out.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.zoom_out.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.zoom_out.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.zoom_out.ForeHoverColor = System.Drawing.Color.Gray
        Me.zoom_out.Location = New System.Drawing.Point(8, 8)
        Me.zoom_out.Name = "zoom_out"
        Me.zoom_out.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.zoom_out.RectColor = System.Drawing.Color.Gray
        Me.zoom_out.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.zoom_out.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.zoom_out.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.zoom_out.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.zoom_out.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.zoom_out.Size = New System.Drawing.Size(43, 49)
        Me.zoom_out.Style = DrakeUI.Framework.UIStyle.Custom
        Me.zoom_out.Symbol = 57427
        Me.zoom_out.SymbolSize = 30
        Me.zoom_out.TabIndex = 34
        Me.zoom_out.Tag = "0"
        '
        'Panel44
        '
        Me.Panel44.Controls.Add(Me.zoom_in)
        Me.Panel44.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel44.Location = New System.Drawing.Point(0, 0)
        Me.Panel44.Name = "Panel44"
        Me.Panel44.Padding = New System.Windows.Forms.Padding(8)
        Me.Panel44.Size = New System.Drawing.Size(59, 65)
        Me.Panel44.TabIndex = 48
        '
        'zoom_in
        '
        Me.zoom_in.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.zoom_in.Cursor = System.Windows.Forms.Cursors.Hand
        Me.zoom_in.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zoom_in.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.zoom_in.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.zoom_in.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.zoom_in.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.zoom_in.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.zoom_in.ForeHoverColor = System.Drawing.Color.Gray
        Me.zoom_in.Location = New System.Drawing.Point(8, 8)
        Me.zoom_in.Name = "zoom_in"
        Me.zoom_in.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.zoom_in.RectColor = System.Drawing.Color.Gray
        Me.zoom_in.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.zoom_in.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.zoom_in.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.zoom_in.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.zoom_in.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.zoom_in.Size = New System.Drawing.Size(43, 49)
        Me.zoom_in.Style = DrakeUI.Framework.UIStyle.Custom
        Me.zoom_in.Symbol = 57428
        Me.zoom_in.SymbolSize = 30
        Me.zoom_in.TabIndex = 34
        Me.zoom_in.Tag = "0"
        '
        'savetimer
        '
        '
        'ScreenReader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 1102)
        Me.Controls.Add(Me.viewimage)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.inputtext)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "ScreenReader"
        Me.Text = "ScreenReader"
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.inputtext, 0)
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        Me.Controls.SetChildIndex(Me.viewimage, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.viewimage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel44.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents stopbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W3 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents startbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents viewimage As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents DrakeUIButtonIcon11 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeUIButtonIcon10 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeUIButtonIcon9 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents inputtext As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents statetimer As Timer
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel44 As Panel
    Friend WithEvents zoom_in As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents Panel4 As Panel
    Friend WithEvents zoom_out As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents coloskeletonpick As DrakeUI.Framework.DrakeUIColorPicker
    Friend WithEvents saveit As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents savetimer As Timer
End Class
