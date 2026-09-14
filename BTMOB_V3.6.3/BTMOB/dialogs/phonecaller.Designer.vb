<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class phonecaller
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(phonecaller))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.mytitle = New System.Windows.Forms.Label()
        Me.myico = New System.Windows.Forms.PictureBox()
        Me.pinbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.spl2 = New DrakeUI.Framework.DrakeWidth_W()
        Me.closbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.numview = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.DrakeWidth_W7 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W8 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W5 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W6 = New DrakeUI.Framework.DrakeWidth_W()
        Me.Panel1.SuspendLayout()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numview, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel1.Size = New System.Drawing.Size(569, 53)
        Me.Panel1.TabIndex = 1
        '
        'mytitle
        '
        Me.mytitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.mytitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mytitle.Font = New System.Drawing.Font("Cascadia Code", 8.0!)
        Me.mytitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.mytitle.Location = New System.Drawing.Point(64, 10)
        Me.mytitle.Name = "mytitle"
        Me.mytitle.Size = New System.Drawing.Size(411, 33)
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
        Me.pinbtn.Location = New System.Drawing.Point(475, 10)
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
        Me.spl2.Location = New System.Drawing.Point(512, 10)
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
        Me.closbtn.Location = New System.Drawing.Point(522, 10)
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
        'numview
        '
        Me.numview.AllowExternalDrop = True
        Me.numview.BackColor = System.Drawing.Color.Black
        Me.numview.CreationProperties = Nothing
        Me.numview.DefaultBackgroundColor = System.Drawing.Color.White
        Me.numview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numview.ForeColor = System.Drawing.Color.White
        Me.numview.Location = New System.Drawing.Point(2, 55)
        Me.numview.Name = "numview"
        Me.numview.Size = New System.Drawing.Size(569, 833)
        Me.numview.TabIndex = 2
        Me.numview.ZoomFactor = 1.0R
        '
        'DrakeWidth_W7
        '
        Me.DrakeWidth_W7.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W7.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.DrakeWidth_W7.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W7.Location = New System.Drawing.Point(571, 0)
        Me.DrakeWidth_W7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrakeWidth_W7.Name = "DrakeWidth_W7"
        Me.DrakeWidth_W7.Size = New System.Drawing.Size(2, 890)
        Me.DrakeWidth_W7.TabIndex = 35
        '
        'DrakeWidth_W8
        '
        Me.DrakeWidth_W8.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W8.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.DrakeWidth_W8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DrakeWidth_W8.Location = New System.Drawing.Point(2, 888)
        Me.DrakeWidth_W8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrakeWidth_W8.Name = "DrakeWidth_W8"
        Me.DrakeWidth_W8.Size = New System.Drawing.Size(569, 2)
        Me.DrakeWidth_W8.TabIndex = 37
        '
        'DrakeWidth_W5
        '
        Me.DrakeWidth_W5.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W5.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W5.Location = New System.Drawing.Point(0, 0)
        Me.DrakeWidth_W5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrakeWidth_W5.Name = "DrakeWidth_W5"
        Me.DrakeWidth_W5.Size = New System.Drawing.Size(2, 890)
        Me.DrakeWidth_W5.TabIndex = 38
        '
        'DrakeWidth_W6
        '
        Me.DrakeWidth_W6.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W6.Dock = System.Windows.Forms.DockStyle.Top
        Me.DrakeWidth_W6.Location = New System.Drawing.Point(2, 0)
        Me.DrakeWidth_W6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrakeWidth_W6.Name = "DrakeWidth_W6"
        Me.DrakeWidth_W6.Size = New System.Drawing.Size(569, 2)
        Me.DrakeWidth_W6.TabIndex = 39
        '
        'phonecaller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 890)
        Me.Controls.Add(Me.numview)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DrakeWidth_W6)
        Me.Controls.Add(Me.DrakeWidth_W8)
        Me.Controls.Add(Me.DrakeWidth_W7)
        Me.Controls.Add(Me.DrakeWidth_W5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "phonecaller"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "phonecaller"
        Me.Panel1.ResumeLayout(False)
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents numview As Microsoft.Web.WebView2.WinForms.WebView2
    Public WithEvents closbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents spl2 As DrakeUI.Framework.DrakeWidth_W
    Public WithEvents pinbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Public WithEvents myico As PictureBox
    Public WithEvents mytitle As Label
    Friend WithEvents DrakeWidth_W7 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W8 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W5 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W6 As DrakeUI.Framework.DrakeWidth_W
End Class
