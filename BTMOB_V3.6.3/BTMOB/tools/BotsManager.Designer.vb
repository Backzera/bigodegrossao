<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BotsManager
    Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BotsManager))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BotsView = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.srchbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DGVC = New System.Windows.Forms.DataGridView()
        Me.slctclum = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.apicoclm = New System.Windows.Forms.DataGridViewImageColumn()
        Me.numnamclm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clistat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.abortclumn = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.refresher = New System.ComponentModel.BackgroundWorker()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pinbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W1 = New DrakeUI.Framework.DrakeWidth_W()
        Me.minibtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.spl2 = New DrakeUI.Framework.DrakeWidth_W()
        Me.closbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.bottitle = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DrakeWidth_W5 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W8 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W6 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W7 = New DrakeUI.Framework.DrakeWidth_W()
        Me.Panel1.SuspendLayout()
        CType(Me.BotsView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DGVC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Controls.Add(Me.BotsView)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(434, 67)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1200, 710)
        Me.Panel1.TabIndex = 0
        '
        'BotsView
        '
        Me.BotsView.AllowExternalDrop = True
        Me.BotsView.BackColor = System.Drawing.Color.Black
        Me.BotsView.CreationProperties = Nothing
        Me.BotsView.DefaultBackgroundColor = System.Drawing.Color.White
        Me.BotsView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BotsView.ForeColor = System.Drawing.Color.White
        Me.BotsView.Location = New System.Drawing.Point(0, 39)
        Me.BotsView.Name = "BotsView"
        Me.BotsView.Size = New System.Drawing.Size(1200, 671)
        Me.BotsView.TabIndex = 0
        Me.BotsView.ZoomFactor = 1.0R
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Black
        Me.Panel5.Controls.Add(Me.srchbtn)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel5.Size = New System.Drawing.Size(1200, 39)
        Me.Panel5.TabIndex = 1
        '
        'srchbtn
        '
        Me.srchbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.srchbtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.srchbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.srchbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.srchbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.srchbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.srchbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.srchbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.srchbtn.ForeColor = System.Drawing.Color.DodgerBlue
        Me.srchbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.srchbtn.Location = New System.Drawing.Point(996, 5)
        Me.srchbtn.Name = "srchbtn"
        Me.srchbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.srchbtn.RectColor = System.Drawing.Color.DodgerBlue
        Me.srchbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.srchbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.srchbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.srchbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.srchbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.srchbtn.Size = New System.Drawing.Size(199, 29)
        Me.srchbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.srchbtn.Symbol = 61641
        Me.srchbtn.TabIndex = 41
        Me.srchbtn.Text = "Android Viewer"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlText
        Me.Panel2.Controls.Add(Me.DGVC)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(2, 67)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(8)
        Me.Panel2.Size = New System.Drawing.Size(432, 710)
        Me.Panel2.TabIndex = 1
        '
        'DGVC
        '
        Me.DGVC.AllowUserToAddRows = False
        Me.DGVC.AllowUserToDeleteRows = False
        Me.DGVC.AllowUserToResizeColumns = False
        Me.DGVC.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVC.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGVC.BackgroundColor = System.Drawing.Color.Black
        Me.DGVC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGVC.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGVC.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.DGVC.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGVC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.slctclum, Me.apicoclm, Me.numnamclm, Me.clistat, Me.abortclumn})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGVC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVC.EnableHeadersVisualStyles = False
        Me.DGVC.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DGVC.Location = New System.Drawing.Point(8, 39)
        Me.DGVC.MultiSelect = False
        Me.DGVC.Name = "DGVC"
        Me.DGVC.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGVC.RowHeadersVisible = False
        Me.DGVC.RowHeadersWidth = 51
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVC.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DGVC.RowTemplate.Height = 24
        Me.DGVC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVC.ShowCellErrors = False
        Me.DGVC.ShowEditingIcon = False
        Me.DGVC.ShowRowErrors = False
        Me.DGVC.Size = New System.Drawing.Size(416, 663)
        Me.DGVC.TabIndex = 43
        '
        'slctclum
        '
        Me.slctclum.FillWeight = 25.0!
        Me.slctclum.HeaderText = ""
        Me.slctclum.MinimumWidth = 6
        Me.slctclum.Name = "slctclum"
        '
        'apicoclm
        '
        Me.apicoclm.FillWeight = 35.0!
        Me.apicoclm.HeaderText = ""
        Me.apicoclm.MinimumWidth = 6
        Me.apicoclm.Name = "apicoclm"
        Me.apicoclm.ReadOnly = True
        '
        'numnamclm
        '
        Me.numnamclm.HeaderText = ""
        Me.numnamclm.MinimumWidth = 6
        Me.numnamclm.Name = "numnamclm"
        Me.numnamclm.ReadOnly = True
        '
        'clistat
        '
        Me.clistat.HeaderText = ""
        Me.clistat.MinimumWidth = 6
        Me.clistat.Name = "clistat"
        Me.clistat.ReadOnly = True
        '
        'abortclumn
        '
        Me.abortclumn.FillWeight = 18.0!
        Me.abortclumn.HeaderText = ""
        Me.abortclumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.abortclumn.MinimumWidth = 6
        Me.abortclumn.Name = "abortclumn"
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Cascadia Code", 8.5!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(5)
        Me.Label2.Size = New System.Drawing.Size(416, 31)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Active clients"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'refresher
        '
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.bottitle)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(2, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel3.Size = New System.Drawing.Size(1632, 65)
        Me.Panel3.TabIndex = 44
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.pinbtn)
        Me.Panel4.Controls.Add(Me.DrakeWidth_W1)
        Me.Panel4.Controls.Add(Me.minibtn)
        Me.Panel4.Controls.Add(Me.spl2)
        Me.Panel4.Controls.Add(Me.closbtn)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(432, 10)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1190, 28)
        Me.Panel4.TabIndex = 2
        '
        'pinbtn
        '
        Me.pinbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.pinbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pinbtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.pinbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pinbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pinbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.pinbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pinbtn.Font = New System.Drawing.Font("Cascadia Code", 12.0!)
        Me.pinbtn.Location = New System.Drawing.Point(1059, 0)
        Me.pinbtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pinbtn.Name = "pinbtn"
        Me.pinbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.pinbtn.RectColor = System.Drawing.Color.Gray
        Me.pinbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pinbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pinbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pinbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pinbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.pinbtn.Size = New System.Drawing.Size(37, 28)
        Me.pinbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.pinbtn.Symbol = 57474
        Me.pinbtn.SymbolSize = 20
        Me.pinbtn.TabIndex = 41
        '
        'DrakeWidth_W1
        '
        Me.DrakeWidth_W1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W1.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W1.Location = New System.Drawing.Point(1096, 0)
        Me.DrakeWidth_W1.Name = "DrakeWidth_W1"
        Me.DrakeWidth_W1.Size = New System.Drawing.Size(10, 28)
        Me.DrakeWidth_W1.TabIndex = 43
        '
        'minibtn
        '
        Me.minibtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.minibtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.minibtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.minibtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.minibtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.minibtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.minibtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.minibtn.Font = New System.Drawing.Font("Cascadia Code", 12.0!)
        Me.minibtn.Location = New System.Drawing.Point(1106, 0)
        Me.minibtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.minibtn.Name = "minibtn"
        Me.minibtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.minibtn.RectColor = System.Drawing.Color.Gray
        Me.minibtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.minibtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.minibtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.minibtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.minibtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.minibtn.Size = New System.Drawing.Size(37, 28)
        Me.minibtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.minibtn.Symbol = 61526
        Me.minibtn.SymbolSize = 20
        Me.minibtn.TabIndex = 42
        '
        'spl2
        '
        Me.spl2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.spl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.spl2.Location = New System.Drawing.Point(1143, 0)
        Me.spl2.Name = "spl2"
        Me.spl2.Size = New System.Drawing.Size(10, 28)
        Me.spl2.TabIndex = 40
        '
        'closbtn
        '
        Me.closbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.closbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.closbtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.closbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.closbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.closbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.closbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.closbtn.Font = New System.Drawing.Font("Cascadia Code", 12.0!)
        Me.closbtn.ForeColor = System.Drawing.Color.Red
        Me.closbtn.Location = New System.Drawing.Point(1153, 0)
        Me.closbtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.closbtn.Name = "closbtn"
        Me.closbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.closbtn.RectColor = System.Drawing.Color.Red
        Me.closbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.closbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.closbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.closbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.closbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.closbtn.Size = New System.Drawing.Size(37, 28)
        Me.closbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.closbtn.Symbol = 61527
        Me.closbtn.SymbolSize = 20
        Me.closbtn.TabIndex = 39
        '
        'bottitle
        '
        Me.bottitle.Dock = System.Windows.Forms.DockStyle.Left
        Me.bottitle.Font = New System.Drawing.Font("Cascadia Code", 14.0!, System.Drawing.FontStyle.Bold)
        Me.bottitle.ForeColor = System.Drawing.Color.DodgerBlue
        Me.bottitle.Location = New System.Drawing.Point(62, 10)
        Me.bottitle.Name = "bottitle"
        Me.bottitle.Padding = New System.Windows.Forms.Padding(5)
        Me.bottitle.Size = New System.Drawing.Size(370, 45)
        Me.bottitle.TabIndex = 1
        Me.bottitle.Text = "Bots Manager"
        Me.bottitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.BTMOB.My.Resources.Resources.robot_filled
        Me.PictureBox1.Location = New System.Drawing.Point(10, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(52, 45)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'DrakeWidth_W5
        '
        Me.DrakeWidth_W5.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W5.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W5.Location = New System.Drawing.Point(0, 2)
        Me.DrakeWidth_W5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrakeWidth_W5.Name = "DrakeWidth_W5"
        Me.DrakeWidth_W5.Size = New System.Drawing.Size(2, 775)
        Me.DrakeWidth_W5.TabIndex = 44
        '
        'DrakeWidth_W8
        '
        Me.DrakeWidth_W8.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W8.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.DrakeWidth_W8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DrakeWidth_W8.Location = New System.Drawing.Point(0, 777)
        Me.DrakeWidth_W8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrakeWidth_W8.Name = "DrakeWidth_W8"
        Me.DrakeWidth_W8.Size = New System.Drawing.Size(1634, 2)
        Me.DrakeWidth_W8.TabIndex = 44
        '
        'DrakeWidth_W6
        '
        Me.DrakeWidth_W6.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W6.Dock = System.Windows.Forms.DockStyle.Top
        Me.DrakeWidth_W6.Location = New System.Drawing.Point(0, 0)
        Me.DrakeWidth_W6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrakeWidth_W6.Name = "DrakeWidth_W6"
        Me.DrakeWidth_W6.Size = New System.Drawing.Size(1634, 2)
        Me.DrakeWidth_W6.TabIndex = 44
        '
        'DrakeWidth_W7
        '
        Me.DrakeWidth_W7.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W7.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.DrakeWidth_W7.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W7.Location = New System.Drawing.Point(1634, 0)
        Me.DrakeWidth_W7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrakeWidth_W7.Name = "DrakeWidth_W7"
        Me.DrakeWidth_W7.Size = New System.Drawing.Size(2, 779)
        Me.DrakeWidth_W7.TabIndex = 44
        '
        'BotsManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1636, 779)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.DrakeWidth_W5)
        Me.Controls.Add(Me.DrakeWidth_W8)
        Me.Controls.Add(Me.DrakeWidth_W6)
        Me.Controls.Add(Me.DrakeWidth_W7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BotsManager"
        Me.Text = "BotsManager"
        Me.Panel1.ResumeLayout(False)
        CType(Me.BotsView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.DGVC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BotsView As Microsoft.Web.WebView2.WinForms.WebView2
    Public WithEvents DGVC As DataGridView
    Friend WithEvents refresher As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents bottitle As Label
    Friend WithEvents Panel4 As Panel
    Public WithEvents pinbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents spl2 As DrakeUI.Framework.DrakeWidth_W
    Public WithEvents closbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W1 As DrakeUI.Framework.DrakeWidth_W
    Public WithEvents minibtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W5 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W8 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W6 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W7 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents Panel5 As Panel
    Friend WithEvents srchbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents Label2 As Label
    Friend WithEvents slctclum As DataGridViewCheckBoxColumn
    Friend WithEvents apicoclm As DataGridViewImageColumn
    Friend WithEvents numnamclm As DataGridViewTextBoxColumn
    Friend WithEvents clistat As DataGridViewTextBoxColumn
    Friend WithEvents abortclumn As DataGridViewImageColumn
End Class
