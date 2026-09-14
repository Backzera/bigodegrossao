<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MicMonitor
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
        Me.stopbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.startbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.progressbaradio = New DrakeUI.Framework.DrakeUITrackBar()
        Me.comboqultz = New DrakeUI.Framework.DrakeUIComboBox()
        Me.mictoolbox = New System.Windows.Forms.TableLayoutPanel()
        Me.continuebtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.pausebtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.recordbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.combosrces = New DrakeUI.Framework.DrakeUIComboBox()
        Me.statetimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DrakeWidth_W3 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W2 = New DrakeUI.Framework.DrakeWidth_W()
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mictoolbox.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pinbtn
        '
        Me.pinbtn.Location = New System.Drawing.Point(575, 5)
        '
        'minibtn
        '
        Me.minibtn.Location = New System.Drawing.Point(641, 5)
        '
        'closbtn
        '
        Me.closbtn.Location = New System.Drawing.Point(707, 5)
        '
        'mytitle
        '
        Me.mytitle.Size = New System.Drawing.Size(758, 24)
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
        Me.stopbtn.Location = New System.Drawing.Point(638, 10)
        Me.stopbtn.Name = "stopbtn"
        Me.stopbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.stopbtn.RectColor = System.Drawing.Color.Gray
        Me.stopbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.stopbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.stopbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.stopbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.stopbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.stopbtn.Size = New System.Drawing.Size(55, 57)
        Me.stopbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.stopbtn.Symbol = 61516
        Me.stopbtn.TabIndex = 41
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
        Me.startbtn.Location = New System.Drawing.Point(703, 10)
        Me.startbtn.Name = "startbtn"
        Me.startbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.startbtn.RectColor = System.Drawing.Color.Gray
        Me.startbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.startbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.startbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.startbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.startbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.startbtn.Size = New System.Drawing.Size(55, 57)
        Me.startbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.startbtn.Symbol = 61515
        Me.startbtn.TabIndex = 40
        '
        'progressbaradio
        '
        Me.progressbaradio.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.progressbaradio.DisableColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.progressbaradio.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.progressbaradio.Enabled = False
        Me.progressbaradio.FillColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.progressbaradio.Font = New System.Drawing.Font("Cascadia Code", 12.0!)
        Me.progressbaradio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.progressbaradio.Location = New System.Drawing.Point(2, 185)
        Me.progressbaradio.Name = "progressbaradio"
        Me.progressbaradio.RectColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.progressbaradio.Size = New System.Drawing.Size(768, 3)
        Me.progressbaradio.Style = DrakeUI.Framework.UIStyle.Custom
        Me.progressbaradio.TabIndex = 42
        Me.progressbaradio.Text = "DrakeUITrackBar4"
        '
        'comboqultz
        '
        Me.comboqultz.Dock = System.Windows.Forms.DockStyle.Left
        Me.comboqultz.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.comboqultz.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.comboqultz.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.comboqultz.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.comboqultz.Items.AddRange(New Object() {"8000 (Hz)", "11025 (Hz)", "16000 (Hz)", "22050 (Hz)", "32000 (Hz)", "44100 (Hz)"})
        Me.comboqultz.Location = New System.Drawing.Point(187, 10)
        Me.comboqultz.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.comboqultz.MinimumSize = New System.Drawing.Size(63, 0)
        Me.comboqultz.Name = "comboqultz"
        Me.comboqultz.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.comboqultz.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.comboqultz.RectColor = System.Drawing.Color.Gray
        Me.comboqultz.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.comboqultz.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.comboqultz.Size = New System.Drawing.Size(167, 25)
        Me.comboqultz.Style = DrakeUI.Framework.UIStyle.Custom
        Me.comboqultz.TabIndex = 43
        Me.comboqultz.Text = "Audio Quality"
        Me.comboqultz.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mictoolbox
        '
        Me.mictoolbox.ColumnCount = 3
        Me.mictoolbox.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.mictoolbox.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.mictoolbox.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.mictoolbox.Controls.Add(Me.continuebtn, 0, 0)
        Me.mictoolbox.Controls.Add(Me.pausebtn, 0, 0)
        Me.mictoolbox.Controls.Add(Me.recordbtn, 0, 0)
        Me.mictoolbox.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.mictoolbox.Enabled = False
        Me.mictoolbox.Location = New System.Drawing.Point(2, 154)
        Me.mictoolbox.Name = "mictoolbox"
        Me.mictoolbox.RowCount = 1
        Me.mictoolbox.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.mictoolbox.Size = New System.Drawing.Size(768, 31)
        Me.mictoolbox.TabIndex = 49
        '
        'continuebtn
        '
        Me.continuebtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.continuebtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.continuebtn.Enabled = False
        Me.continuebtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.continuebtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.continuebtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.continuebtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.continuebtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.continuebtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.continuebtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.continuebtn.Location = New System.Drawing.Point(515, 3)
        Me.continuebtn.Name = "continuebtn"
        Me.continuebtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.continuebtn.RectColor = System.Drawing.Color.Gray
        Me.continuebtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.continuebtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.continuebtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.continuebtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.continuebtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.continuebtn.Size = New System.Drawing.Size(250, 25)
        Me.continuebtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.continuebtn.Symbol = 57422
        Me.continuebtn.TabIndex = 23
        Me.continuebtn.Text = "Continue"
        '
        'pausebtn
        '
        Me.pausebtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pausebtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pausebtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pausebtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pausebtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pausebtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pausebtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pausebtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.pausebtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.pausebtn.Location = New System.Drawing.Point(259, 3)
        Me.pausebtn.Name = "pausebtn"
        Me.pausebtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.pausebtn.RectColor = System.Drawing.Color.Gray
        Me.pausebtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.pausebtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pausebtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pausebtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pausebtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.pausebtn.Size = New System.Drawing.Size(250, 25)
        Me.pausebtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.pausebtn.Symbol = 62091
        Me.pausebtn.TabIndex = 22
        Me.pausebtn.Text = "Pause"
        '
        'recordbtn
        '
        Me.recordbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.recordbtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.recordbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.recordbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.recordbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.recordbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.recordbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.recordbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.recordbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.recordbtn.Location = New System.Drawing.Point(3, 3)
        Me.recordbtn.Name = "recordbtn"
        Me.recordbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.recordbtn.RectColor = System.Drawing.Color.Gray
        Me.recordbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.recordbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.recordbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.recordbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.recordbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.recordbtn.Size = New System.Drawing.Size(250, 25)
        Me.recordbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.recordbtn.Symbol = 61744
        Me.recordbtn.TabIndex = 21
        Me.recordbtn.TagString = "0"
        Me.recordbtn.Text = "Record"
        '
        'combosrces
        '
        Me.combosrces.Dock = System.Windows.Forms.DockStyle.Left
        Me.combosrces.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.combosrces.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.combosrces.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.combosrces.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.combosrces.Items.AddRange(New Object() {"DEFAULT", "MIC", "RECOGNITION", "COMMUNICATION", "CAMCORDER"})
        Me.combosrces.Location = New System.Drawing.Point(10, 10)
        Me.combosrces.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.combosrces.MinimumSize = New System.Drawing.Size(63, 0)
        Me.combosrces.Name = "combosrces"
        Me.combosrces.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.combosrces.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.combosrces.RectColor = System.Drawing.Color.Gray
        Me.combosrces.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.combosrces.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.combosrces.Size = New System.Drawing.Size(167, 25)
        Me.combosrces.Style = DrakeUI.Framework.UIStyle.Custom
        Me.combosrces.TabIndex = 50
        Me.combosrces.Text = "DEFAULT"
        Me.combosrces.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'statetimer
        '
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel3.Controls.Add(Me.stopbtn)
        Me.Panel3.Controls.Add(Me.DrakeWidth_W3)
        Me.Panel3.Controls.Add(Me.startbtn)
        Me.Panel3.Controls.Add(Me.comboqultz)
        Me.Panel3.Controls.Add(Me.DrakeWidth_W2)
        Me.Panel3.Controls.Add(Me.combosrces)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(2, 77)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel3.Size = New System.Drawing.Size(768, 77)
        Me.Panel3.TabIndex = 51
        '
        'DrakeWidth_W3
        '
        Me.DrakeWidth_W3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W3.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W3.Location = New System.Drawing.Point(693, 10)
        Me.DrakeWidth_W3.Name = "DrakeWidth_W3"
        Me.DrakeWidth_W3.Size = New System.Drawing.Size(10, 57)
        Me.DrakeWidth_W3.TabIndex = 52
        '
        'DrakeWidth_W2
        '
        Me.DrakeWidth_W2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W2.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W2.Location = New System.Drawing.Point(177, 10)
        Me.DrakeWidth_W2.Name = "DrakeWidth_W2"
        Me.DrakeWidth_W2.Size = New System.Drawing.Size(10, 57)
        Me.DrakeWidth_W2.TabIndex = 51
        '
        'MicMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(772, 190)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.mictoolbox)
        Me.Controls.Add(Me.progressbaradio)
        Me.MaximumSize = New System.Drawing.Size(772, 190)
        Me.MinimumSize = New System.Drawing.Size(772, 190)
        Me.Name = "MicMonitor"
        Me.Text = "BT | Microphone"
        Me.Controls.SetChildIndex(Me.progressbaradio, 0)
        Me.Controls.SetChildIndex(Me.mictoolbox, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mictoolbox.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents stopbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents startbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents progressbaradio As DrakeUI.Framework.DrakeUITrackBar
    Friend WithEvents comboqultz As DrakeUI.Framework.DrakeUIComboBox
    Friend WithEvents mictoolbox As TableLayoutPanel
    Friend WithEvents continuebtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents pausebtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents recordbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents combosrces As DrakeUI.Framework.DrakeUIComboBox
    Friend WithEvents statetimer As Timer
    Friend WithEvents Panel3 As Panel
    Friend WithEvents DrakeWidth_W3 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W2 As DrakeUI.Framework.DrakeWidth_W
End Class
