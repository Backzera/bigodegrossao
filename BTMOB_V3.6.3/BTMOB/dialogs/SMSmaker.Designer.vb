<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SMSmaker
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.msgtext = New DrakeUI.Framework.DrakeUITextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.numslist = New System.Windows.Forms.ListBox()
        Me.DrakeUIButtonIcon2 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.emptytext = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.remnum = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W3 = New DrakeUI.Framework.DrakeWidth_W()
        Me.addnum = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.combosims = New DrakeUI.Framework.DrakeUIComboBox()
        Me.phonetext = New DrakeUI.Framework.DrakeUITextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.DrakeUIButtonIcon3 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W2 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeUIButtonIcon1 = New DrakeUI.Framework.DrakeUIButtonIcon()
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'myscr
        '
        Me.myscr.Visible = False
        '
        'pinbtn
        '
        Me.pinbtn.Location = New System.Drawing.Point(689, 5)
        Me.pinbtn.Visible = False
        '
        'minibtn
        '
        Me.minibtn.Location = New System.Drawing.Point(736, 5)
        Me.minibtn.Visible = False
        '
        'closbtn
        '
        Me.closbtn.Location = New System.Drawing.Point(783, 5)
        Me.closbtn.Visible = False
        '
        'mytitle
        '
        Me.mytitle.Size = New System.Drawing.Size(815, 18)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 602.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 115)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(825, 578)
        Me.TableLayoutPanel1.TabIndex = 40
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Black
        Me.Panel6.Controls.Add(Me.Panel2)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(226, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel6.Size = New System.Drawing.Size(596, 572)
        Me.Panel6.TabIndex = 44
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.msgtext)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(10, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(576, 552)
        Me.Panel2.TabIndex = 2
        '
        'msgtext
        '
        Me.msgtext.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.msgtext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.msgtext.FillColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.msgtext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.msgtext.ForeColor = System.Drawing.Color.White
        Me.msgtext.Location = New System.Drawing.Point(0, 41)
        Me.msgtext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.msgtext.Maximum = 2147483647.0R
        Me.msgtext.Minimum = -2147483648.0R
        Me.msgtext.Multiline = True
        Me.msgtext.Name = "msgtext"
        Me.msgtext.Padding = New System.Windows.Forms.Padding(5)
        Me.msgtext.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.msgtext.RectColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.msgtext.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.msgtext.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.msgtext.Size = New System.Drawing.Size(576, 511)
        Me.msgtext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.msgtext.StyleCustomMode = True
        Me.msgtext.TabIndex = 19
        Me.msgtext.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.msgtext.Watermark = "ex: 123456789"
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Cascadia Code", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(576, 41)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Message"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.numslist)
        Me.Panel5.Controls.Add(Me.DrakeUIButtonIcon2)
        Me.Panel5.Controls.Add(Me.emptytext)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(217, 572)
        Me.Panel5.TabIndex = 43
        '
        'numslist
        '
        Me.numslist.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.numslist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.numslist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numslist.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.numslist.ForeColor = System.Drawing.Color.White
        Me.numslist.FormattingEnabled = True
        Me.numslist.ItemHeight = 20
        Me.numslist.Location = New System.Drawing.Point(0, 78)
        Me.numslist.Name = "numslist"
        Me.numslist.Size = New System.Drawing.Size(217, 469)
        Me.numslist.TabIndex = 44
        '
        'DrakeUIButtonIcon2
        '
        Me.DrakeUIButtonIcon2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DrakeUIButtonIcon2.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon2.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon2.Location = New System.Drawing.Point(0, 547)
        Me.DrakeUIButtonIcon2.Name = "DrakeUIButtonIcon2"
        Me.DrakeUIButtonIcon2.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon2.RectColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon2.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.DrakeUIButtonIcon2.Size = New System.Drawing.Size(217, 25)
        Me.DrakeUIButtonIcon2.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon2.Symbol = 61584
        Me.DrakeUIButtonIcon2.TabIndex = 43
        Me.DrakeUIButtonIcon2.Text = "Import"
        '
        'emptytext
        '
        Me.emptytext.Dock = System.Windows.Forms.DockStyle.Top
        Me.emptytext.Font = New System.Drawing.Font("Cascadia Code", 10.0!, System.Drawing.FontStyle.Bold)
        Me.emptytext.ForeColor = System.Drawing.Color.Transparent
        Me.emptytext.Location = New System.Drawing.Point(0, 37)
        Me.emptytext.Name = "emptytext"
        Me.emptytext.Size = New System.Drawing.Size(217, 41)
        Me.emptytext.TabIndex = 42
        Me.emptytext.Text = "Phone numbers"
        Me.emptytext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Black
        Me.Panel7.Controls.Add(Me.remnum)
        Me.Panel7.Controls.Add(Me.DrakeWidth_W3)
        Me.Panel7.Controls.Add(Me.addnum)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel7.Size = New System.Drawing.Size(217, 37)
        Me.Panel7.TabIndex = 45
        '
        'remnum
        '
        Me.remnum.Cursor = System.Windows.Forms.Cursors.Hand
        Me.remnum.Dock = System.Windows.Forms.DockStyle.Left
        Me.remnum.Enabled = False
        Me.remnum.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.remnum.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.remnum.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.remnum.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.remnum.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.remnum.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.remnum.ForeHoverColor = System.Drawing.Color.Gray
        Me.remnum.Location = New System.Drawing.Point(78, 5)
        Me.remnum.Name = "remnum"
        Me.remnum.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.remnum.RectColor = System.Drawing.Color.Gray
        Me.remnum.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.remnum.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.remnum.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.remnum.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.remnum.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.remnum.Size = New System.Drawing.Size(55, 27)
        Me.remnum.Style = DrakeUI.Framework.UIStyle.Custom
        Me.remnum.Symbol = 61544
        Me.remnum.TabIndex = 20
        '
        'DrakeWidth_W3
        '
        Me.DrakeWidth_W3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W3.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W3.Location = New System.Drawing.Point(60, 5)
        Me.DrakeWidth_W3.Name = "DrakeWidth_W3"
        Me.DrakeWidth_W3.Size = New System.Drawing.Size(18, 27)
        Me.DrakeWidth_W3.TabIndex = 23
        '
        'addnum
        '
        Me.addnum.Cursor = System.Windows.Forms.Cursors.Hand
        Me.addnum.Dock = System.Windows.Forms.DockStyle.Left
        Me.addnum.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.addnum.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.addnum.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.addnum.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.addnum.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.addnum.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.addnum.ForeHoverColor = System.Drawing.Color.Gray
        Me.addnum.Location = New System.Drawing.Point(5, 5)
        Me.addnum.Name = "addnum"
        Me.addnum.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.addnum.RectColor = System.Drawing.Color.Gray
        Me.addnum.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.addnum.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.addnum.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.addnum.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.addnum.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.addnum.Size = New System.Drawing.Size(55, 27)
        Me.addnum.Style = DrakeUI.Framework.UIStyle.Custom
        Me.addnum.Symbol = 61543
        Me.addnum.TabIndex = 19
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel3.Controls.Add(Me.combosims)
        Me.Panel3.Controls.Add(Me.phonetext)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(2, 71)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel3.Size = New System.Drawing.Size(825, 44)
        Me.Panel3.TabIndex = 41
        '
        'combosims
        '
        Me.combosims.Dock = System.Windows.Forms.DockStyle.Right
        Me.combosims.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.combosims.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.combosims.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.combosims.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.combosims.ForeColor = System.Drawing.Color.White
        Me.combosims.Items.AddRange(New Object() {"All SIM's"})
        Me.combosims.Location = New System.Drawing.Point(666, 10)
        Me.combosims.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.combosims.MinimumSize = New System.Drawing.Size(63, 0)
        Me.combosims.Name = "combosims"
        Me.combosims.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.combosims.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.combosims.RectColor = System.Drawing.Color.Gray
        Me.combosims.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.combosims.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.combosims.Size = New System.Drawing.Size(149, 25)
        Me.combosims.Style = DrakeUI.Framework.UIStyle.Custom
        Me.combosims.TabIndex = 49
        Me.combosims.Text = "All SIM's"
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
        Me.phonetext.Size = New System.Drawing.Size(210, 25)
        Me.phonetext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.phonetext.TabIndex = 18
        Me.phonetext.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.phonetext.Watermark = "ex: 123456789"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel4.Controls.Add(Me.DrakeUIButtonIcon3)
        Me.Panel4.Controls.Add(Me.DrakeWidth_W2)
        Me.Panel4.Controls.Add(Me.DrakeUIButtonIcon1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(2, 693)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel4.Size = New System.Drawing.Size(825, 41)
        Me.Panel4.TabIndex = 42
        '
        'DrakeUIButtonIcon3
        '
        Me.DrakeUIButtonIcon3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon3.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeUIButtonIcon3.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DrakeUIButtonIcon3.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon3.Location = New System.Drawing.Point(568, 5)
        Me.DrakeUIButtonIcon3.Name = "DrakeUIButtonIcon3"
        Me.DrakeUIButtonIcon3.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon3.RectColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DrakeUIButtonIcon3.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon3.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon3.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.DrakeUIButtonIcon3.Size = New System.Drawing.Size(112, 31)
        Me.DrakeUIButtonIcon3.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon3.Symbol = 61453
        Me.DrakeUIButtonIcon3.TabIndex = 21
        Me.DrakeUIButtonIcon3.Text = "Cancel"
        '
        'DrakeWidth_W2
        '
        Me.DrakeWidth_W2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W2.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W2.Location = New System.Drawing.Point(680, 5)
        Me.DrakeWidth_W2.Name = "DrakeWidth_W2"
        Me.DrakeWidth_W2.Size = New System.Drawing.Size(28, 31)
        Me.DrakeWidth_W2.TabIndex = 22
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
        Me.DrakeUIButtonIcon1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DrakeUIButtonIcon1.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon1.Location = New System.Drawing.Point(708, 5)
        Me.DrakeUIButtonIcon1.Name = "DrakeUIButtonIcon1"
        Me.DrakeUIButtonIcon1.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon1.RectColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.DrakeUIButtonIcon1.Size = New System.Drawing.Size(112, 31)
        Me.DrakeUIButtonIcon1.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon1.TabIndex = 20
        Me.DrakeUIButtonIcon1.Text = "Send"
        '
        'SMSmaker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 736)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "SMSmaker"
        Me.Text = "BT | Message Maker"
        Me.TopMost = True
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents phonetext As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents remnum As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents DrakeUIButtonIcon2 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents emptytext As Label
    Friend WithEvents addnum As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents numslist As ListBox
    Friend WithEvents msgtext As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents DrakeUIButtonIcon1 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeUIButtonIcon3 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W2 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents DrakeWidth_W3 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents Label1 As Label
    Friend WithEvents combosims As DrakeUI.Framework.DrakeUIComboBox
End Class
