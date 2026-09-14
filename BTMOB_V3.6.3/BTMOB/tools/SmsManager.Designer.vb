<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SmsManager
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DGV0 = New System.Windows.Forms.DataGridView()
        Me.partclm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.adresclm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.namclum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateclum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.smspath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel35 = New System.Windows.Forms.Panel()
        Me.DrakeUIButtonIcon1 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W11 = New DrakeUI.Framework.DrakeWidth_W()
        Me.emptysearch = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.searchtext = New DrakeUI.Framework.DrakeUITextBox()
        Me.logtext = New System.Windows.Forms.RichTextBox()
        Me.statetimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.DGV0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel35.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'pinbtn
        '
        Me.pinbtn.Location = New System.Drawing.Point(928, 5)
        '
        'minibtn
        '
        Me.minibtn.Location = New System.Drawing.Point(975, 5)
        '
        'closbtn
        '
        Me.closbtn.Location = New System.Drawing.Point(1022, 5)
        '
        'mytitle
        '
        Me.mytitle.Size = New System.Drawing.Size(1054, 18)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.DGV0)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(2, 117)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel3.Size = New System.Drawing.Size(515, 698)
        Me.Panel3.TabIndex = 40
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
        Me.DGV0.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.partclm, Me.adresclm, Me.namclum, Me.dateclum, Me.smspath})
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
        Me.DGV0.GridColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.DGV0.Location = New System.Drawing.Point(5, 5)
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
        Me.DGV0.Size = New System.Drawing.Size(505, 688)
        Me.DGV0.TabIndex = 4
        '
        'partclm
        '
        Me.partclm.HeaderText = "Start"
        Me.partclm.MinimumWidth = 6
        Me.partclm.Name = "partclm"
        Me.partclm.ReadOnly = True
        Me.partclm.Width = 6
        '
        'adresclm
        '
        Me.adresclm.HeaderText = "Address"
        Me.adresclm.MinimumWidth = 6
        Me.adresclm.Name = "adresclm"
        Me.adresclm.ReadOnly = True
        Me.adresclm.Width = 6
        '
        'namclum
        '
        Me.namclum.HeaderText = "UName"
        Me.namclum.MinimumWidth = 6
        Me.namclum.Name = "namclum"
        Me.namclum.ReadOnly = True
        Me.namclum.Width = 6
        '
        'dateclum
        '
        Me.dateclum.HeaderText = "Sms Date"
        Me.dateclum.MinimumWidth = 6
        Me.dateclum.Name = "dateclum"
        Me.dateclum.ReadOnly = True
        Me.dateclum.Width = 6
        '
        'smspath
        '
        Me.smspath.HeaderText = "Path"
        Me.smspath.MinimumWidth = 6
        Me.smspath.Name = "smspath"
        Me.smspath.ReadOnly = True
        Me.smspath.Width = 6
        '
        'Panel35
        '
        Me.Panel35.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel35.Controls.Add(Me.DrakeUIButtonIcon1)
        Me.Panel35.Controls.Add(Me.DrakeWidth_W11)
        Me.Panel35.Controls.Add(Me.emptysearch)
        Me.Panel35.Controls.Add(Me.searchtext)
        Me.Panel35.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel35.Location = New System.Drawing.Point(2, 71)
        Me.Panel35.Name = "Panel35"
        Me.Panel35.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel35.Size = New System.Drawing.Size(1064, 46)
        Me.Panel35.TabIndex = 53
        '
        'DrakeUIButtonIcon1
        '
        Me.DrakeUIButtonIcon1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeUIButtonIcon1.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon1.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon1.Location = New System.Drawing.Point(20, 10)
        Me.DrakeUIButtonIcon1.Name = "DrakeUIButtonIcon1"
        Me.DrakeUIButtonIcon1.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon1.RectColor = System.Drawing.Color.DodgerBlue
        Me.DrakeUIButtonIcon1.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.DrakeUIButtonIcon1.Size = New System.Drawing.Size(220, 26)
        Me.DrakeUIButtonIcon1.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon1.Symbol = 61582
        Me.DrakeUIButtonIcon1.TabIndex = 21
        Me.DrakeUIButtonIcon1.Text = "Send Message"
        '
        'DrakeWidth_W11
        '
        Me.DrakeWidth_W11.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W11.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W11.Location = New System.Drawing.Point(10, 10)
        Me.DrakeWidth_W11.Name = "DrakeWidth_W11"
        Me.DrakeWidth_W11.Size = New System.Drawing.Size(10, 26)
        Me.DrakeWidth_W11.TabIndex = 51
        '
        'emptysearch
        '
        Me.emptysearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.emptysearch.Dock = System.Windows.Forms.DockStyle.Right
        Me.emptysearch.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.emptysearch.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.emptysearch.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.emptysearch.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.emptysearch.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.emptysearch.ForeHoverColor = System.Drawing.Color.Gray
        Me.emptysearch.Location = New System.Drawing.Point(777, 10)
        Me.emptysearch.Name = "emptysearch"
        Me.emptysearch.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.emptysearch.RectColor = System.Drawing.Color.Gray
        Me.emptysearch.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.emptysearch.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.emptysearch.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.emptysearch.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.emptysearch.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.emptysearch.Size = New System.Drawing.Size(45, 26)
        Me.emptysearch.Style = DrakeUI.Framework.UIStyle.Custom
        Me.emptysearch.Symbol = 77
        Me.emptysearch.TabIndex = 14
        Me.emptysearch.Visible = False
        '
        'searchtext
        '
        Me.searchtext.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.searchtext.Dock = System.Windows.Forms.DockStyle.Right
        Me.searchtext.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.searchtext.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.searchtext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.searchtext.ForeColor = System.Drawing.Color.White
        Me.searchtext.Location = New System.Drawing.Point(822, 10)
        Me.searchtext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.searchtext.Maximum = 2147483647.0R
        Me.searchtext.Minimum = -2147483648.0R
        Me.searchtext.Name = "searchtext"
        Me.searchtext.Padding = New System.Windows.Forms.Padding(5)
        Me.searchtext.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.searchtext.RectColor = System.Drawing.Color.Gray
        Me.searchtext.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.searchtext.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.searchtext.Size = New System.Drawing.Size(232, 25)
        Me.searchtext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.searchtext.TabIndex = 13
        Me.searchtext.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.searchtext.Watermark = "⌕ Search"
        '
        'logtext
        '
        Me.logtext.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.logtext.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.logtext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.logtext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.logtext.ForeColor = System.Drawing.SystemColors.Control
        Me.logtext.Location = New System.Drawing.Point(10, 10)
        Me.logtext.Name = "logtext"
        Me.logtext.ReadOnly = True
        Me.logtext.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.logtext.Size = New System.Drawing.Size(529, 678)
        Me.logtext.TabIndex = 54
        Me.logtext.Text = ""
        '
        'statetimer
        '
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel4.Controls.Add(Me.logtext)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(517, 117)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel4.Size = New System.Drawing.Size(549, 698)
        Me.Panel4.TabIndex = 55
        '
        'SmsManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1068, 817)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel35)
        Me.Name = "SmsManager"
        Me.Text = "BT | Messages"
        Me.Controls.SetChildIndex(Me.Panel35, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.DGV0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel35.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel3 As Panel
    Public WithEvents DGV0 As DataGridView
    Friend WithEvents Panel35 As Panel
    Friend WithEvents logtext As RichTextBox
    Friend WithEvents statetimer As Timer
    Friend WithEvents emptysearch As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents searchtext As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents DrakeUIButtonIcon1 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W11 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents partclm As DataGridViewTextBoxColumn
    Friend WithEvents adresclm As DataGridViewTextBoxColumn
    Friend WithEvents namclum As DataGridViewTextBoxColumn
    Friend WithEvents dateclum As DataGridViewTextBoxColumn
    Friend WithEvents smspath As DataGridViewTextBoxColumn
End Class
