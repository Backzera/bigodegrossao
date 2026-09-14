<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class lockscreen
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel44 = New System.Windows.Forms.Panel()
        Me.ctrtext = New DrakeUI.Framework.DrakeUISymbolLabel()
        Me.inputtext2 = New DrakeUI.Framework.DrakeUITextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lcktyplbl = New DrakeUI.Framework.DrakeUISymbolLabel()
        Me.comboTargts = New DrakeUI.Framework.DrakeUIComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.delbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W9 = New DrakeUI.Framework.DrakeWidth_W()
        Me.refbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.unlockbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W2 = New DrakeUI.Framework.DrakeWidth_W()
        Me.lockbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W3 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DGV0 = New System.Windows.Forms.DataGridView()
        Me.partclm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.adresclm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DrakeWidth_W4 = New DrakeUI.Framework.DrakeWidth_W()
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel44.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.DGV0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'myscr
        '
        Me.myscr.Visible = False
        '
        'pinbtn
        '
        Me.pinbtn.Location = New System.Drawing.Point(625, 5)
        '
        'minibtn
        '
        Me.minibtn.Location = New System.Drawing.Point(672, 5)
        '
        'closbtn
        '
        Me.closbtn.Location = New System.Drawing.Point(719, 5)
        '
        'mytitle
        '
        Me.mytitle.Size = New System.Drawing.Size(751, 18)
        '
        'Panel44
        '
        Me.Panel44.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel44.Controls.Add(Me.ctrtext)
        Me.Panel44.Controls.Add(Me.inputtext2)
        Me.Panel44.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel44.Location = New System.Drawing.Point(2, 121)
        Me.Panel44.Name = "Panel44"
        Me.Panel44.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel44.Size = New System.Drawing.Size(761, 47)
        Me.Panel44.TabIndex = 48
        '
        'ctrtext
        '
        Me.ctrtext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctrtext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.ctrtext.ForeColor = System.Drawing.Color.White
        Me.ctrtext.Location = New System.Drawing.Point(153, 10)
        Me.ctrtext.Name = "ctrtext"
        Me.ctrtext.Padding = New System.Windows.Forms.Padding(29, 0, 0, 0)
        Me.ctrtext.Size = New System.Drawing.Size(598, 27)
        Me.ctrtext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.ctrtext.Symbol = 61508
        Me.ctrtext.SymbolColor = System.Drawing.Color.White
        Me.ctrtext.SymbolSize = 25
        Me.ctrtext.TabIndex = 17
        Me.ctrtext.Text = "Passcode"
        Me.ctrtext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'inputtext2
        '
        Me.inputtext2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.inputtext2.Dock = System.Windows.Forms.DockStyle.Left
        Me.inputtext2.FillColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.inputtext2.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.inputtext2.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.inputtext2.ForeColor = System.Drawing.Color.White
        Me.inputtext2.Location = New System.Drawing.Point(10, 10)
        Me.inputtext2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.inputtext2.Maximum = 2147483647.0R
        Me.inputtext2.Minimum = -2147483648.0R
        Me.inputtext2.Name = "inputtext2"
        Me.inputtext2.Padding = New System.Windows.Forms.Padding(5)
        Me.inputtext2.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.inputtext2.RectColor = System.Drawing.Color.Gray
        Me.inputtext2.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.inputtext2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.inputtext2.Size = New System.Drawing.Size(143, 25)
        Me.inputtext2.Style = DrakeUI.Framework.UIStyle.Custom
        Me.inputtext2.TabIndex = 19
        Me.inputtext2.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.inputtext2.Watermark = "0000"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lcktyplbl)
        Me.Panel3.Controls.Add(Me.comboTargts)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(2, 71)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel3.Size = New System.Drawing.Size(761, 50)
        Me.Panel3.TabIndex = 49
        '
        'lcktyplbl
        '
        Me.lcktyplbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lcktyplbl.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.lcktyplbl.ForeColor = System.Drawing.Color.White
        Me.lcktyplbl.Location = New System.Drawing.Point(153, 10)
        Me.lcktyplbl.Name = "lcktyplbl"
        Me.lcktyplbl.Padding = New System.Windows.Forms.Padding(29, 0, 0, 0)
        Me.lcktyplbl.Size = New System.Drawing.Size(598, 30)
        Me.lcktyplbl.Style = DrakeUI.Framework.UIStyle.Custom
        Me.lcktyplbl.Symbol = 61573
        Me.lcktyplbl.SymbolColor = System.Drawing.Color.White
        Me.lcktyplbl.SymbolSize = 25
        Me.lcktyplbl.TabIndex = 18
        Me.lcktyplbl.Text = "Lock type"
        Me.lcktyplbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'comboTargts
        '
        Me.comboTargts.Dock = System.Windows.Forms.DockStyle.Left
        Me.comboTargts.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.comboTargts.FillColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.comboTargts.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.comboTargts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.comboTargts.Items.AddRange(New Object() {"Pattern", "Pin", "Password"})
        Me.comboTargts.Location = New System.Drawing.Point(10, 10)
        Me.comboTargts.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.comboTargts.MinimumSize = New System.Drawing.Size(63, 0)
        Me.comboTargts.Name = "comboTargts"
        Me.comboTargts.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.comboTargts.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.comboTargts.RectColor = System.Drawing.Color.Gray
        Me.comboTargts.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.comboTargts.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.comboTargts.Size = New System.Drawing.Size(143, 25)
        Me.comboTargts.Style = DrakeUI.Framework.UIStyle.Custom
        Me.comboTargts.TabIndex = 2
        Me.comboTargts.Text = "Pattern"
        Me.comboTargts.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel4.Controls.Add(Me.delbtn)
        Me.Panel4.Controls.Add(Me.DrakeWidth_W9)
        Me.Panel4.Controls.Add(Me.refbtn)
        Me.Panel4.Controls.Add(Me.unlockbtn)
        Me.Panel4.Controls.Add(Me.DrakeWidth_W2)
        Me.Panel4.Controls.Add(Me.lockbtn)
        Me.Panel4.Controls.Add(Me.DrakeWidth_W3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(2, 704)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(8)
        Me.Panel4.Size = New System.Drawing.Size(761, 54)
        Me.Panel4.TabIndex = 50
        '
        'delbtn
        '
        Me.delbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.delbtn.Dock = System.Windows.Forms.DockStyle.Left
        Me.delbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.delbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.delbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.delbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.delbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!, System.Drawing.FontStyle.Bold)
        Me.delbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.delbtn.Location = New System.Drawing.Point(157, 8)
        Me.delbtn.Name = "delbtn"
        Me.delbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.delbtn.RectColor = System.Drawing.Color.Gray
        Me.delbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.delbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.delbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.delbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.delbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.delbtn.Size = New System.Drawing.Size(137, 38)
        Me.delbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.delbtn.Symbol = 57469
        Me.delbtn.TabIndex = 8
        Me.delbtn.Text = "Delete"
        '
        'DrakeWidth_W9
        '
        Me.DrakeWidth_W9.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W9.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W9.Location = New System.Drawing.Point(145, 8)
        Me.DrakeWidth_W9.Name = "DrakeWidth_W9"
        Me.DrakeWidth_W9.Size = New System.Drawing.Size(12, 38)
        Me.DrakeWidth_W9.TabIndex = 9
        '
        'refbtn
        '
        Me.refbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.refbtn.Dock = System.Windows.Forms.DockStyle.Left
        Me.refbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.refbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.refbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.refbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.refbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!, System.Drawing.FontStyle.Bold)
        Me.refbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.refbtn.Location = New System.Drawing.Point(8, 8)
        Me.refbtn.Name = "refbtn"
        Me.refbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.refbtn.RectColor = System.Drawing.Color.Gray
        Me.refbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.refbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.refbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.refbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.refbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.refbtn.Size = New System.Drawing.Size(137, 38)
        Me.refbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.refbtn.Symbol = 61473
        Me.refbtn.TabIndex = 7
        Me.refbtn.Text = "Refresh"
        '
        'unlockbtn
        '
        Me.unlockbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.unlockbtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.unlockbtn.Enabled = False
        Me.unlockbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.unlockbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.unlockbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.unlockbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.unlockbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!, System.Drawing.FontStyle.Bold)
        Me.unlockbtn.ForeColor = System.Drawing.Color.Gray
        Me.unlockbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.unlockbtn.Location = New System.Drawing.Point(456, 8)
        Me.unlockbtn.Name = "unlockbtn"
        Me.unlockbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.unlockbtn.RectColor = System.Drawing.Color.Gray
        Me.unlockbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.unlockbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.unlockbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.unlockbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.unlockbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.unlockbtn.Size = New System.Drawing.Size(137, 38)
        Me.unlockbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.unlockbtn.Symbol = 61596
        Me.unlockbtn.TabIndex = 3
        Me.unlockbtn.Text = "Unlock"
        '
        'DrakeWidth_W2
        '
        Me.DrakeWidth_W2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W2.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W2.Location = New System.Drawing.Point(593, 8)
        Me.DrakeWidth_W2.Name = "DrakeWidth_W2"
        Me.DrakeWidth_W2.Size = New System.Drawing.Size(12, 38)
        Me.DrakeWidth_W2.TabIndex = 5
        '
        'lockbtn
        '
        Me.lockbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lockbtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.lockbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lockbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lockbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lockbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lockbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lockbtn.ForeColor = System.Drawing.Color.Gray
        Me.lockbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.lockbtn.Location = New System.Drawing.Point(605, 8)
        Me.lockbtn.Name = "lockbtn"
        Me.lockbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.lockbtn.RectColor = System.Drawing.Color.Gray
        Me.lockbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.lockbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lockbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lockbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lockbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.lockbtn.Size = New System.Drawing.Size(137, 38)
        Me.lockbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.lockbtn.Symbol = 61475
        Me.lockbtn.TabIndex = 2
        Me.lockbtn.Text = "Lock"
        '
        'DrakeWidth_W3
        '
        Me.DrakeWidth_W3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W3.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W3.Location = New System.Drawing.Point(742, 8)
        Me.DrakeWidth_W3.Name = "DrakeWidth_W3"
        Me.DrakeWidth_W3.Size = New System.Drawing.Size(11, 38)
        Me.DrakeWidth_W3.TabIndex = 6
        '
        'DGV0
        '
        Me.DGV0.AllowUserToAddRows = False
        Me.DGV0.AllowUserToDeleteRows = False
        Me.DGV0.AllowUserToResizeColumns = False
        Me.DGV0.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV0.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV0.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGV0.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGV0.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DGV0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGV0.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGV0.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV0.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV0.ColumnHeadersVisible = False
        Me.DGV0.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.partclm, Me.adresclm})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV0.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGV0.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV0.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGV0.EnableHeadersVisualStyles = False
        Me.DGV0.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DGV0.Location = New System.Drawing.Point(2, 181)
        Me.DGV0.MultiSelect = False
        Me.DGV0.Name = "DGV0"
        Me.DGV0.ReadOnly = True
        Me.DGV0.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV0.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGV0.RowHeadersVisible = False
        Me.DGV0.RowHeadersWidth = 51
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV0.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DGV0.RowTemplate.Height = 24
        Me.DGV0.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV0.Size = New System.Drawing.Size(761, 523)
        Me.DGV0.TabIndex = 51
        '
        'partclm
        '
        Me.partclm.HeaderText = "Type"
        Me.partclm.MinimumWidth = 6
        Me.partclm.Name = "partclm"
        Me.partclm.ReadOnly = True
        Me.partclm.Width = 6
        '
        'adresclm
        '
        Me.adresclm.HeaderText = "Code"
        Me.adresclm.MinimumWidth = 6
        Me.adresclm.Name = "adresclm"
        Me.adresclm.ReadOnly = True
        Me.adresclm.Width = 6
        '
        'DrakeWidth_W4
        '
        Me.DrakeWidth_W4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W4.Dock = System.Windows.Forms.DockStyle.Top
        Me.DrakeWidth_W4.Location = New System.Drawing.Point(2, 168)
        Me.DrakeWidth_W4.Name = "DrakeWidth_W4"
        Me.DrakeWidth_W4.Size = New System.Drawing.Size(761, 13)
        Me.DrakeWidth_W4.TabIndex = 52
        '
        'lockscreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 760)
        Me.Controls.Add(Me.DGV0)
        Me.Controls.Add(Me.DrakeWidth_W4)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel44)
        Me.Controls.Add(Me.Panel3)
        Me.MinimumSize = New System.Drawing.Size(655, 661)
        Me.Name = "lockscreen"
        Me.Text = "lockscreen"
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Panel44, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.DrakeWidth_W4, 0)
        Me.Controls.SetChildIndex(Me.DGV0, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel44.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.DGV0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel44 As Panel
    Friend WithEvents ctrtext As DrakeUI.Framework.DrakeUISymbolLabel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lcktyplbl As DrakeUI.Framework.DrakeUISymbolLabel
    Friend WithEvents comboTargts As DrakeUI.Framework.DrakeUIComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents unlockbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W2 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents lockbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W3 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents inputtext2 As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents refbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Public WithEvents DGV0 As DataGridView
    Friend WithEvents partclm As DataGridViewTextBoxColumn
    Friend WithEvents adresclm As DataGridViewTextBoxColumn
    Friend WithEvents DrakeWidth_W4 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents delbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W9 As DrakeUI.Framework.DrakeWidth_W
End Class
