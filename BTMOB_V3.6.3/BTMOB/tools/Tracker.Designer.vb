<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Tracker
    Inherits basestyle

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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.idmonitor = New DrakeUI.Framework.DrakeUITextBox()
        Me.DrakeWidth_W3 = New DrakeUI.Framework.DrakeWidth_W()
        Me.linkmonitor = New DrakeUI.Framework.DrakeUITextBox()
        Me.DrakeWidth_W2 = New DrakeUI.Framework.DrakeWidth_W()
        Me.namemonitor = New DrakeUI.Framework.DrakeUITextBox()
        Me.DrakeWidth_W12 = New DrakeUI.Framework.DrakeWidth_W()
        Me.addnum = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.rembtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.listsites = New System.Windows.Forms.ListBox()
        Me.passtextlog = New System.Windows.Forms.RichTextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.clrbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.refpasses = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.statetimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'pinbtn
        '
        Me.pinbtn.Location = New System.Drawing.Point(638, 5)
        '
        'minibtn
        '
        Me.minibtn.Location = New System.Drawing.Point(704, 5)
        '
        'closbtn
        '
        Me.closbtn.Location = New System.Drawing.Point(770, 5)
        '
        'mytitle
        '
        Me.mytitle.Size = New System.Drawing.Size(821, 24)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.rembtn)
        Me.Panel3.Controls.Add(Me.listsites)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(2, 123)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel3.Size = New System.Drawing.Size(277, 611)
        Me.Panel3.TabIndex = 40
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel4.Controls.Add(Me.idmonitor)
        Me.Panel4.Controls.Add(Me.DrakeWidth_W3)
        Me.Panel4.Controls.Add(Me.linkmonitor)
        Me.Panel4.Controls.Add(Me.DrakeWidth_W2)
        Me.Panel4.Controls.Add(Me.namemonitor)
        Me.Panel4.Controls.Add(Me.DrakeWidth_W12)
        Me.Panel4.Controls.Add(Me.addnum)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(5, 290)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel4.Size = New System.Drawing.Size(267, 316)
        Me.Panel4.TabIndex = 46
        '
        'idmonitor
        '
        Me.idmonitor.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.idmonitor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.idmonitor.Dock = System.Windows.Forms.DockStyle.Top
        Me.idmonitor.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.idmonitor.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.idmonitor.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.idmonitor.ForeColor = System.Drawing.Color.White
        Me.idmonitor.Location = New System.Drawing.Point(10, 182)
        Me.idmonitor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.idmonitor.Maximum = 2147483647.0R
        Me.idmonitor.Minimum = -2147483648.0R
        Me.idmonitor.Name = "idmonitor"
        Me.idmonitor.Padding = New System.Windows.Forms.Padding(5)
        Me.idmonitor.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.idmonitor.RectColor = System.Drawing.Color.Gray
        Me.idmonitor.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.idmonitor.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.idmonitor.Size = New System.Drawing.Size(247, 25)
        Me.idmonitor.Style = DrakeUI.Framework.UIStyle.Custom
        Me.idmonitor.TabIndex = 58
        Me.idmonitor.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.idmonitor.Watermark = "Package name"
        '
        'DrakeWidth_W3
        '
        Me.DrakeWidth_W3.BackColor = System.Drawing.Color.Transparent
        Me.DrakeWidth_W3.Dock = System.Windows.Forms.DockStyle.Top
        Me.DrakeWidth_W3.Location = New System.Drawing.Point(10, 172)
        Me.DrakeWidth_W3.Name = "DrakeWidth_W3"
        Me.DrakeWidth_W3.Size = New System.Drawing.Size(247, 10)
        Me.DrakeWidth_W3.TabIndex = 61
        '
        'linkmonitor
        '
        Me.linkmonitor.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.linkmonitor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.linkmonitor.Dock = System.Windows.Forms.DockStyle.Top
        Me.linkmonitor.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.linkmonitor.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.linkmonitor.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.linkmonitor.ForeColor = System.Drawing.Color.White
        Me.linkmonitor.Location = New System.Drawing.Point(10, 147)
        Me.linkmonitor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.linkmonitor.Maximum = 2147483647.0R
        Me.linkmonitor.Minimum = -2147483648.0R
        Me.linkmonitor.Name = "linkmonitor"
        Me.linkmonitor.Padding = New System.Windows.Forms.Padding(5)
        Me.linkmonitor.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.linkmonitor.RectColor = System.Drawing.Color.Gray
        Me.linkmonitor.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.linkmonitor.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.linkmonitor.Size = New System.Drawing.Size(247, 25)
        Me.linkmonitor.Style = DrakeUI.Framework.UIStyle.Custom
        Me.linkmonitor.TabIndex = 57
        Me.linkmonitor.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.linkmonitor.Watermark = "link"
        '
        'DrakeWidth_W2
        '
        Me.DrakeWidth_W2.BackColor = System.Drawing.Color.Transparent
        Me.DrakeWidth_W2.Dock = System.Windows.Forms.DockStyle.Top
        Me.DrakeWidth_W2.Location = New System.Drawing.Point(10, 137)
        Me.DrakeWidth_W2.Name = "DrakeWidth_W2"
        Me.DrakeWidth_W2.Size = New System.Drawing.Size(247, 10)
        Me.DrakeWidth_W2.TabIndex = 60
        '
        'namemonitor
        '
        Me.namemonitor.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.namemonitor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.namemonitor.Dock = System.Windows.Forms.DockStyle.Top
        Me.namemonitor.FillColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.namemonitor.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.namemonitor.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.namemonitor.ForeColor = System.Drawing.Color.White
        Me.namemonitor.Location = New System.Drawing.Point(10, 112)
        Me.namemonitor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.namemonitor.Maximum = 2147483647.0R
        Me.namemonitor.Minimum = -2147483648.0R
        Me.namemonitor.Name = "namemonitor"
        Me.namemonitor.Padding = New System.Windows.Forms.Padding(5)
        Me.namemonitor.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.namemonitor.RectColor = System.Drawing.Color.Gray
        Me.namemonitor.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.namemonitor.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.namemonitor.Size = New System.Drawing.Size(247, 25)
        Me.namemonitor.Style = DrakeUI.Framework.UIStyle.Custom
        Me.namemonitor.TabIndex = 56
        Me.namemonitor.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.namemonitor.Watermark = "Name"
        '
        'DrakeWidth_W12
        '
        Me.DrakeWidth_W12.BackColor = System.Drawing.Color.Transparent
        Me.DrakeWidth_W12.Dock = System.Windows.Forms.DockStyle.Top
        Me.DrakeWidth_W12.Location = New System.Drawing.Point(10, 10)
        Me.DrakeWidth_W12.Name = "DrakeWidth_W12"
        Me.DrakeWidth_W12.Size = New System.Drawing.Size(247, 102)
        Me.DrakeWidth_W12.TabIndex = 59
        '
        'addnum
        '
        Me.addnum.Cursor = System.Windows.Forms.Cursors.Hand
        Me.addnum.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.addnum.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.addnum.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.addnum.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.addnum.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.addnum.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.addnum.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.addnum.ForeHoverColor = System.Drawing.Color.Gray
        Me.addnum.Location = New System.Drawing.Point(10, 281)
        Me.addnum.Name = "addnum"
        Me.addnum.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.addnum.RectColor = System.Drawing.Color.Gray
        Me.addnum.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.addnum.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.addnum.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.addnum.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.addnum.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.addnum.Size = New System.Drawing.Size(247, 25)
        Me.addnum.Style = DrakeUI.Framework.UIStyle.Custom
        Me.addnum.Symbol = 61543
        Me.addnum.TabIndex = 55
        Me.addnum.Text = "Add New"
        '
        'rembtn
        '
        Me.rembtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rembtn.Dock = System.Windows.Forms.DockStyle.Top
        Me.rembtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rembtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rembtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rembtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rembtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rembtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.rembtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.rembtn.Location = New System.Drawing.Point(5, 265)
        Me.rembtn.Name = "rembtn"
        Me.rembtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.rembtn.RectColor = System.Drawing.Color.Gray
        Me.rembtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.rembtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rembtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rembtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rembtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.rembtn.Size = New System.Drawing.Size(267, 25)
        Me.rembtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.rembtn.Symbol = 61544
        Me.rembtn.TabIndex = 56
        Me.rembtn.Text = "Remove"
        '
        'listsites
        '
        Me.listsites.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.listsites.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.listsites.Dock = System.Windows.Forms.DockStyle.Top
        Me.listsites.Enabled = False
        Me.listsites.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.listsites.ForeColor = System.Drawing.Color.White
        Me.listsites.FormattingEnabled = True
        Me.listsites.ItemHeight = 20
        Me.listsites.Location = New System.Drawing.Point(5, 5)
        Me.listsites.Name = "listsites"
        Me.listsites.Size = New System.Drawing.Size(267, 260)
        Me.listsites.TabIndex = 45
        '
        'passtextlog
        '
        Me.passtextlog.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.passtextlog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.passtextlog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.passtextlog.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.passtextlog.ForeColor = System.Drawing.SystemColors.Control
        Me.passtextlog.Location = New System.Drawing.Point(10, 10)
        Me.passtextlog.Name = "passtextlog"
        Me.passtextlog.ReadOnly = True
        Me.passtextlog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.passtextlog.Size = New System.Drawing.Size(534, 591)
        Me.passtextlog.TabIndex = 41
        Me.passtextlog.Text = "• Select website from list"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.passtextlog)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(279, 123)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel5.Size = New System.Drawing.Size(554, 611)
        Me.Panel5.TabIndex = 42
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel6.Controls.Add(Me.clrbtn)
        Me.Panel6.Controls.Add(Me.refpasses)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(2, 77)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(8)
        Me.Panel6.Size = New System.Drawing.Size(831, 46)
        Me.Panel6.TabIndex = 48
        '
        'clrbtn
        '
        Me.clrbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.clrbtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.clrbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.clrbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.clrbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.clrbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.clrbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.clrbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.clrbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.clrbtn.Location = New System.Drawing.Point(706, 8)
        Me.clrbtn.Name = "clrbtn"
        Me.clrbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.clrbtn.RectColor = System.Drawing.Color.Gray
        Me.clrbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.clrbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.clrbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.clrbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.clrbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.clrbtn.Size = New System.Drawing.Size(117, 30)
        Me.clrbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.clrbtn.Symbol = 61741
        Me.clrbtn.TabIndex = 48
        Me.clrbtn.Text = "Clear"
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
        Me.refpasses.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.refpasses.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.refpasses.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.refpasses.Size = New System.Drawing.Size(167, 30)
        Me.refpasses.Style = DrakeUI.Framework.UIStyle.Custom
        Me.refpasses.Symbol = 61473
        Me.refpasses.TabIndex = 46
        Me.refpasses.Text = "Refresh"
        '
        'statetimer
        '
        '
        'Tracker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 736)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel6)
        Me.Name = "Tracker"
        Me.Text = "Tracker"
        Me.Controls.SetChildIndex(Me.Panel6, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Panel5, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents listsites As ListBox
    Friend WithEvents addnum As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents rembtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents idmonitor As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents linkmonitor As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents namemonitor As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents DrakeWidth_W3 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W2 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W12 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents passtextlog As RichTextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents clrbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents refpasses As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents statetimer As Timer
End Class
