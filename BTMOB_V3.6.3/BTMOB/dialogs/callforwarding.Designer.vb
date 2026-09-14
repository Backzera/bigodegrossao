<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class callforwarding
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.mytitle = New System.Windows.Forms.Label()
        Me.myico = New System.Windows.Forms.PictureBox()
        Me.pinbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.spl2 = New DrakeUI.Framework.DrakeWidth_W()
        Me.closbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.disablebtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.enblebtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.checkbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.combosims = New DrakeUI.Framework.DrakeUIComboBox()
        Me.phonetext = New DrakeUI.Framework.DrakeUITextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.mytitle)
        Me.Panel1.Controls.Add(Me.myico)
        Me.Panel1.Controls.Add(Me.pinbtn)
        Me.Panel1.Controls.Add(Me.spl2)
        Me.Panel1.Controls.Add(Me.closbtn)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel1.Size = New System.Drawing.Size(630, 53)
        Me.Panel1.TabIndex = 2
        '
        'mytitle
        '
        Me.mytitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.mytitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mytitle.Font = New System.Drawing.Font("Cascadia Code", 8.0!)
        Me.mytitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.mytitle.Location = New System.Drawing.Point(64, 10)
        Me.mytitle.Name = "mytitle"
        Me.mytitle.Size = New System.Drawing.Size(472, 33)
        Me.mytitle.TabIndex = 40
        Me.mytitle.Text = "Client"
        Me.mytitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'myico
        '
        Me.myico.Dock = System.Windows.Forms.DockStyle.Left
        Me.myico.Location = New System.Drawing.Point(10, 10)
        Me.myico.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.myico.Name = "myico"
        Me.myico.Size = New System.Drawing.Size(54, 33)
        Me.myico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.myico.TabIndex = 39
        Me.myico.TabStop = False
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
        Me.pinbtn.Location = New System.Drawing.Point(536, 10)
        Me.pinbtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pinbtn.Name = "pinbtn"
        Me.pinbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.pinbtn.RectColor = System.Drawing.Color.Gray
        Me.pinbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pinbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pinbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pinbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pinbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.pinbtn.Size = New System.Drawing.Size(37, 33)
        Me.pinbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.pinbtn.Symbol = 57474
        Me.pinbtn.SymbolSize = 20
        Me.pinbtn.TabIndex = 38
        '
        'spl2
        '
        Me.spl2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.spl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.spl2.Location = New System.Drawing.Point(573, 10)
        Me.spl2.Name = "spl2"
        Me.spl2.Size = New System.Drawing.Size(10, 33)
        Me.spl2.TabIndex = 37
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
        Me.closbtn.Location = New System.Drawing.Point(583, 10)
        Me.closbtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.closbtn.Name = "closbtn"
        Me.closbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.closbtn.RectColor = System.Drawing.Color.Gray
        Me.closbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.closbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.closbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.closbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.closbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.closbtn.Size = New System.Drawing.Size(37, 33)
        Me.closbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.closbtn.Symbol = 61527
        Me.closbtn.SymbolSize = 20
        Me.closbtn.TabIndex = 5
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.disablebtn, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.enblebtn, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.checkbtn, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 104)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(630, 52)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'disablebtn
        '
        Me.disablebtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.disablebtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.disablebtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.disablebtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.disablebtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.disablebtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.disablebtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.disablebtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.disablebtn.ForeColor = System.Drawing.Color.Red
        Me.disablebtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.disablebtn.Location = New System.Drawing.Point(423, 3)
        Me.disablebtn.Name = "disablebtn"
        Me.disablebtn.Padding = New System.Windows.Forms.Padding(5)
        Me.disablebtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.disablebtn.RectColor = System.Drawing.Color.Gray
        Me.disablebtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.disablebtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.disablebtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.disablebtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.disablebtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.disablebtn.Size = New System.Drawing.Size(204, 46)
        Me.disablebtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.disablebtn.Symbol = 62091
        Me.disablebtn.TabIndex = 25
        Me.disablebtn.Text = "Disable"
        '
        'enblebtn
        '
        Me.enblebtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.enblebtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.enblebtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.enblebtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.enblebtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.enblebtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.enblebtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.enblebtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.enblebtn.ForeColor = System.Drawing.Color.LawnGreen
        Me.enblebtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.enblebtn.Location = New System.Drawing.Point(213, 3)
        Me.enblebtn.Name = "enblebtn"
        Me.enblebtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.enblebtn.RectColor = System.Drawing.Color.Gray
        Me.enblebtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.enblebtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.enblebtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.enblebtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.enblebtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.enblebtn.Size = New System.Drawing.Size(204, 46)
        Me.enblebtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.enblebtn.TabIndex = 24
        Me.enblebtn.Text = "Enable"
        '
        'checkbtn
        '
        Me.checkbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.checkbtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.checkbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.checkbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.checkbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.checkbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.checkbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.checkbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.checkbtn.ForeColor = System.Drawing.Color.DodgerBlue
        Me.checkbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.checkbtn.Location = New System.Drawing.Point(3, 3)
        Me.checkbtn.Name = "checkbtn"
        Me.checkbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.checkbtn.RectColor = System.Drawing.Color.Gray
        Me.checkbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.checkbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.checkbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.checkbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.checkbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.checkbtn.Size = New System.Drawing.Size(204, 46)
        Me.checkbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.checkbtn.Symbol = 61473
        Me.checkbtn.TabIndex = 23
        Me.checkbtn.Text = "Check"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel3.Controls.Add(Me.combosims)
        Me.Panel3.Controls.Add(Me.phonetext)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 53)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel3.Size = New System.Drawing.Size(630, 51)
        Me.Panel3.TabIndex = 42
        '
        'combosims
        '
        Me.combosims.Dock = System.Windows.Forms.DockStyle.Right
        Me.combosims.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.combosims.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.combosims.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.combosims.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.combosims.ForeColor = System.Drawing.Color.White
        Me.combosims.Items.AddRange(New Object() {"SIM 1"})
        Me.combosims.Location = New System.Drawing.Point(512, 10)
        Me.combosims.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.combosims.MinimumSize = New System.Drawing.Size(63, 0)
        Me.combosims.Name = "combosims"
        Me.combosims.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.combosims.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.combosims.RectColor = System.Drawing.Color.Gray
        Me.combosims.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.combosims.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.combosims.Size = New System.Drawing.Size(108, 25)
        Me.combosims.Style = DrakeUI.Framework.UIStyle.Custom
        Me.combosims.TabIndex = 49
        Me.combosims.Text = "SIM 1"
        Me.combosims.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.combosims.Watermark = "install type"
        '
        'phonetext
        '
        Me.phonetext.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.phonetext.Dock = System.Windows.Forms.DockStyle.Left
        Me.phonetext.FillColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.phonetext.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.phonetext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.phonetext.ForeColor = System.Drawing.Color.White
        Me.phonetext.Location = New System.Drawing.Point(10, 10)
        Me.phonetext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.phonetext.Maximum = 2147483647.0R
        Me.phonetext.Minimum = -2147483648.0R
        Me.phonetext.Name = "phonetext"
        Me.phonetext.Padding = New System.Windows.Forms.Padding(5)
        Me.phonetext.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.phonetext.RectColor = System.Drawing.Color.Gray
        Me.phonetext.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.phonetext.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.phonetext.Size = New System.Drawing.Size(494, 25)
        Me.phonetext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.phonetext.TabIndex = 18
        Me.phonetext.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.phonetext.Watermark = "Redirect number, ex: 0091111..."
        '
        'callforwarding
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(630, 156)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "callforwarding"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "callforwarding"
        Me.Panel1.ResumeLayout(False)
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Public WithEvents mytitle As Label
    Public WithEvents myico As PictureBox
    Public WithEvents pinbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents spl2 As DrakeUI.Framework.DrakeWidth_W
    Public WithEvents closbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents disablebtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents enblebtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents checkbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents Panel3 As Panel
    Friend WithEvents combosims As DrakeUI.Framework.DrakeUIComboBox
    Friend WithEvents phonetext As DrakeUI.Framework.DrakeUITextBox
End Class
