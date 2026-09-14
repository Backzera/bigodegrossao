<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AndroidViewer
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AndroidViewer))
        Me.WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.logtext = New System.Windows.Forms.RichTextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.DrakeUIButtonIcon2 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeUIButtonIcon1 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.srchbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.Combophones = New DrakeUI.Framework.DrakeUIComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.mytitle = New System.Windows.Forms.Label()
        Me.myico = New System.Windows.Forms.PictureBox()
        Me.pinbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.spl2 = New DrakeUI.Framework.DrakeWidth_W()
        Me.closbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W7 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W5 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W6 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W8 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeUIToolTip1 = New DrakeUI.Framework.DrakeUIToolTip(Me.components)
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WebView21
        '
        Me.WebView21.AllowExternalDrop = True
        Me.WebView21.BackColor = System.Drawing.Color.Black
        Me.WebView21.CreationProperties = Nothing
        Me.WebView21.DefaultBackgroundColor = System.Drawing.Color.White
        Me.WebView21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebView21.Location = New System.Drawing.Point(460, 99)
        Me.WebView21.Name = "WebView21"
        Me.WebView21.Size = New System.Drawing.Size(397, 726)
        Me.WebView21.TabIndex = 0
        Me.WebView21.ZoomFactor = 1.0R
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.logtext)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(2, 99)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(458, 726)
        Me.Panel1.TabIndex = 1
        '
        'logtext
        '
        Me.logtext.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.logtext.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.logtext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.logtext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.logtext.ForeColor = System.Drawing.SystemColors.Control
        Me.logtext.Location = New System.Drawing.Point(5, 59)
        Me.logtext.Name = "logtext"
        Me.logtext.ReadOnly = True
        Me.logtext.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.logtext.Size = New System.Drawing.Size(448, 662)
        Me.logtext.TabIndex = 4
        Me.logtext.Text = "• Click element in the view."
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.DrakeUIButtonIcon2)
        Me.Panel4.Controls.Add(Me.DrakeUIButtonIcon1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(5, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel4.Size = New System.Drawing.Size(448, 54)
        Me.Panel4.TabIndex = 5
        '
        'DrakeUIButtonIcon2
        '
        Me.DrakeUIButtonIcon2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon2.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeUIButtonIcon2.FillColor = System.Drawing.Color.Black
        Me.DrakeUIButtonIcon2.FillDisableColor = System.Drawing.Color.Black
        Me.DrakeUIButtonIcon2.FillHoverColor = System.Drawing.Color.Black
        Me.DrakeUIButtonIcon2.FillPressColor = System.Drawing.Color.Black
        Me.DrakeUIButtonIcon2.FillSelectedColor = System.Drawing.Color.Black
        Me.DrakeUIButtonIcon2.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.DrakeUIButtonIcon2.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon2.Location = New System.Drawing.Point(10, 10)
        Me.DrakeUIButtonIcon2.Name = "DrakeUIButtonIcon2"
        Me.DrakeUIButtonIcon2.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon2.RectColor = System.Drawing.Color.DodgerBlue
        Me.DrakeUIButtonIcon2.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.DrakeUIButtonIcon2.Size = New System.Drawing.Size(55, 34)
        Me.DrakeUIButtonIcon2.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon2.Symbol = 62162
        Me.DrakeUIButtonIcon2.TabIndex = 11
        Me.DrakeUIToolTip1.SetToolTip(Me.DrakeUIButtonIcon2, "Copy")
        '
        'DrakeUIButtonIcon1
        '
        Me.DrakeUIButtonIcon1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon1.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeUIButtonIcon1.FillColor = System.Drawing.Color.Black
        Me.DrakeUIButtonIcon1.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.DrakeUIButtonIcon1.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.DrakeUIButtonIcon1.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.DrakeUIButtonIcon1.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon1.Location = New System.Drawing.Point(383, 10)
        Me.DrakeUIButtonIcon1.Name = "DrakeUIButtonIcon1"
        Me.DrakeUIButtonIcon1.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon1.RectColor = System.Drawing.Color.DodgerBlue
        Me.DrakeUIButtonIcon1.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.DrakeUIButtonIcon1.Size = New System.Drawing.Size(55, 34)
        Me.DrakeUIButtonIcon1.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon1.Symbol = 61741
        Me.DrakeUIButtonIcon1.TabIndex = 10
        Me.DrakeUIToolTip1.SetToolTip(Me.DrakeUIButtonIcon1, "Clear")
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Controls.Add(Me.srchbtn)
        Me.Panel2.Controls.Add(Me.Combophones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(2, 55)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel2.Size = New System.Drawing.Size(855, 44)
        Me.Panel2.TabIndex = 2
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
        Me.srchbtn.Location = New System.Drawing.Point(722, 10)
        Me.srchbtn.Name = "srchbtn"
        Me.srchbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.srchbtn.RectColor = System.Drawing.Color.DodgerBlue
        Me.srchbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.srchbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.srchbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.srchbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.srchbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.srchbtn.Size = New System.Drawing.Size(123, 24)
        Me.srchbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.srchbtn.Symbol = 61473
        Me.srchbtn.TabIndex = 40
        Me.srchbtn.Text = "Refresh"
        '
        'Combophones
        '
        Me.Combophones.Dock = System.Windows.Forms.DockStyle.Left
        Me.Combophones.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.Combophones.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Combophones.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.Combophones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Combophones.Location = New System.Drawing.Point(10, 10)
        Me.Combophones.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Combophones.MinimumSize = New System.Drawing.Size(63, 0)
        Me.Combophones.Name = "Combophones"
        Me.Combophones.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.Combophones.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.Combophones.RectColor = System.Drawing.Color.Gray
        Me.Combophones.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Combophones.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.Combophones.Size = New System.Drawing.Size(209, 25)
        Me.Combophones.Style = DrakeUI.Framework.UIStyle.Custom
        Me.Combophones.TabIndex = 1
        Me.Combophones.Text = "Device"
        Me.Combophones.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Controls.Add(Me.mytitle)
        Me.Panel3.Controls.Add(Me.myico)
        Me.Panel3.Controls.Add(Me.pinbtn)
        Me.Panel3.Controls.Add(Me.spl2)
        Me.Panel3.Controls.Add(Me.closbtn)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.ForeColor = System.Drawing.Color.White
        Me.Panel3.Location = New System.Drawing.Point(2, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel3.Size = New System.Drawing.Size(855, 53)
        Me.Panel3.TabIndex = 5
        '
        'mytitle
        '
        Me.mytitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.mytitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mytitle.Font = New System.Drawing.Font("Cascadia Code", 9.0!, System.Drawing.FontStyle.Bold)
        Me.mytitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.mytitle.Location = New System.Drawing.Point(64, 10)
        Me.mytitle.Name = "mytitle"
        Me.mytitle.Size = New System.Drawing.Size(697, 33)
        Me.mytitle.TabIndex = 40
        Me.mytitle.Text = "Android UI Viewer"
        Me.mytitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'myico
        '
        Me.myico.Dock = System.Windows.Forms.DockStyle.Left
        Me.myico.Image = Global.BTMOB.My.Resources.Resources.screnrader1
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
        Me.pinbtn.Location = New System.Drawing.Point(761, 10)
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
        Me.spl2.Location = New System.Drawing.Point(798, 10)
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
        Me.closbtn.Location = New System.Drawing.Point(808, 10)
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
        'DrakeWidth_W7
        '
        Me.DrakeWidth_W7.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W7.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.DrakeWidth_W7.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W7.Location = New System.Drawing.Point(857, 0)
        Me.DrakeWidth_W7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrakeWidth_W7.Name = "DrakeWidth_W7"
        Me.DrakeWidth_W7.Size = New System.Drawing.Size(2, 827)
        Me.DrakeWidth_W7.TabIndex = 41
        '
        'DrakeWidth_W5
        '
        Me.DrakeWidth_W5.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W5.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W5.Location = New System.Drawing.Point(0, 0)
        Me.DrakeWidth_W5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrakeWidth_W5.Name = "DrakeWidth_W5"
        Me.DrakeWidth_W5.Size = New System.Drawing.Size(2, 827)
        Me.DrakeWidth_W5.TabIndex = 39
        '
        'DrakeWidth_W6
        '
        Me.DrakeWidth_W6.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W6.Dock = System.Windows.Forms.DockStyle.Top
        Me.DrakeWidth_W6.Location = New System.Drawing.Point(2, 0)
        Me.DrakeWidth_W6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrakeWidth_W6.Name = "DrakeWidth_W6"
        Me.DrakeWidth_W6.Size = New System.Drawing.Size(855, 2)
        Me.DrakeWidth_W6.TabIndex = 41
        '
        'DrakeWidth_W8
        '
        Me.DrakeWidth_W8.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W8.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.DrakeWidth_W8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DrakeWidth_W8.Location = New System.Drawing.Point(2, 825)
        Me.DrakeWidth_W8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrakeWidth_W8.Name = "DrakeWidth_W8"
        Me.DrakeWidth_W8.Size = New System.Drawing.Size(855, 2)
        Me.DrakeWidth_W8.TabIndex = 38
        '
        'DrakeUIToolTip1
        '
        Me.DrakeUIToolTip1.BackColor = System.Drawing.Color.Black
        Me.DrakeUIToolTip1.ForeColor = System.Drawing.Color.White
        Me.DrakeUIToolTip1.OwnerDraw = True
        Me.DrakeUIToolTip1.RectColor = System.Drawing.Color.DodgerBlue
        '
        'AndroidViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(859, 827)
        Me.ControlBox = False
        Me.Controls.Add(Me.WebView21)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.DrakeWidth_W8)
        Me.Controls.Add(Me.DrakeWidth_W6)
        Me.Controls.Add(Me.DrakeWidth_W5)
        Me.Controls.Add(Me.DrakeWidth_W7)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AndroidViewer"
        Me.Text = "Android Viewer"
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WebView21 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents Panel1 As Panel
    Friend WithEvents logtext As RichTextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Combophones As DrakeUI.Framework.DrakeUIComboBox
    Friend WithEvents srchbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents Panel3 As Panel
    Public WithEvents mytitle As Label
    Public WithEvents myico As PictureBox
    Public WithEvents pinbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents spl2 As DrakeUI.Framework.DrakeWidth_W
    Public WithEvents closbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W7 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W5 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W6 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W8 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents Panel4 As Panel
    Friend WithEvents DrakeUIButtonIcon1 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeUIButtonIcon2 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeUIToolTip1 As DrakeUI.Framework.DrakeUIToolTip
End Class
