<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Clientsupdater
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
        Me.WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.linktext = New DrakeUI.Framework.DrakeUITextBox()
        Me.DrakeWidth_W2 = New DrakeUI.Framework.DrakeWidth_W()
        Me.refbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W13 = New DrakeUI.Framework.DrakeWidth_W()
        Me.combotags = New DrakeUI.Framework.DrakeUIComboBox()
        Me.randver = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W3 = New DrakeUI.Framework.DrakeWidth_W()
        Me.upbtnall = New DrakeUI.Framework.DrakeUIButtonIcon()
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pinbtn
        '
        Me.pinbtn.Location = New System.Drawing.Point(1294, 5)
        '
        'minibtn
        '
        Me.minibtn.Location = New System.Drawing.Point(1341, 5)
        '
        'closbtn
        '
        Me.closbtn.Location = New System.Drawing.Point(1388, 5)
        '
        'myico
        '
        Me.myico.Image = Global.BTMOB.My.Resources.Resources.sync_1x_1_0s_417px_417px_removebg_preview
        '
        'mytitle
        '
        Me.mytitle.Size = New System.Drawing.Size(1420, 18)
        '
        'WebView21
        '
        Me.WebView21.AllowExternalDrop = True
        Me.WebView21.CreationProperties = Nothing
        Me.WebView21.DefaultBackgroundColor = System.Drawing.Color.White
        Me.WebView21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebView21.Location = New System.Drawing.Point(2, 116)
        Me.WebView21.Name = "WebView21"
        Me.WebView21.Size = New System.Drawing.Size(1430, 570)
        Me.WebView21.TabIndex = 40
        Me.WebView21.ZoomFactor = 1.0R
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Controls.Add(Me.linktext)
        Me.Panel2.Controls.Add(Me.DrakeWidth_W2)
        Me.Panel2.Controls.Add(Me.refbtn)
        Me.Panel2.Controls.Add(Me.DrakeWidth_W13)
        Me.Panel2.Controls.Add(Me.combotags)
        Me.Panel2.Controls.Add(Me.randver)
        Me.Panel2.Controls.Add(Me.DrakeWidth_W3)
        Me.Panel2.Controls.Add(Me.upbtnall)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(2, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel2.Size = New System.Drawing.Size(1430, 45)
        Me.Panel2.TabIndex = 41
        '
        'linktext
        '
        Me.linktext.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.linktext.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.linktext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.linktext.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.linktext.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.linktext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.linktext.ForeColor = System.Drawing.Color.White
        Me.linktext.Location = New System.Drawing.Point(354, 10)
        Me.linktext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.linktext.Maximum = 2147483647.0R
        Me.linktext.Minimum = -2147483648.0R
        Me.linktext.Name = "linktext"
        Me.linktext.Padding = New System.Windows.Forms.Padding(5)
        Me.linktext.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.linktext.RectColor = System.Drawing.Color.Gray
        Me.linktext.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.linktext.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.linktext.Size = New System.Drawing.Size(800, 25)
        Me.linktext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.linktext.TabIndex = 50
        Me.linktext.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.linktext.Watermark = "Update link, ex: mysite.com/app1"
        '
        'DrakeWidth_W2
        '
        Me.DrakeWidth_W2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W2.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W2.Location = New System.Drawing.Point(329, 10)
        Me.DrakeWidth_W2.Name = "DrakeWidth_W2"
        Me.DrakeWidth_W2.Size = New System.Drawing.Size(25, 25)
        Me.DrakeWidth_W2.TabIndex = 60
        '
        'refbtn
        '
        Me.refbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.refbtn.Dock = System.Windows.Forms.DockStyle.Left
        Me.refbtn.FillColor = System.Drawing.Color.Black
        Me.refbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.refbtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.refbtn.Location = New System.Drawing.Point(182, 10)
        Me.refbtn.Name = "refbtn"
        Me.refbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.refbtn.RectColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.refbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.refbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.refbtn.Size = New System.Drawing.Size(147, 25)
        Me.refbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.refbtn.Symbol = 61473
        Me.refbtn.SymbolSize = 20
        Me.refbtn.TabIndex = 59
        Me.refbtn.Text = "Refresh"
        '
        'DrakeWidth_W13
        '
        Me.DrakeWidth_W13.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W13.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W13.Location = New System.Drawing.Point(1154, 10)
        Me.DrakeWidth_W13.Name = "DrakeWidth_W13"
        Me.DrakeWidth_W13.Size = New System.Drawing.Size(25, 25)
        Me.DrakeWidth_W13.TabIndex = 58
        '
        'combotags
        '
        Me.combotags.Dock = System.Windows.Forms.DockStyle.Right
        Me.combotags.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.combotags.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.combotags.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.combotags.ForeColor = System.Drawing.Color.White
        Me.combotags.Location = New System.Drawing.Point(1179, 10)
        Me.combotags.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.combotags.MinimumSize = New System.Drawing.Size(63, 0)
        Me.combotags.Name = "combotags"
        Me.combotags.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.combotags.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.combotags.RectColor = System.Drawing.Color.DodgerBlue
        Me.combotags.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.combotags.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.combotags.Size = New System.Drawing.Size(196, 25)
        Me.combotags.Style = DrakeUI.Framework.UIStyle.Custom
        Me.combotags.StyleCustomMode = True
        Me.combotags.TabIndex = 51
        Me.combotags.Text = "Select Tag"
        Me.combotags.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.combotags.Watermark = "install type"
        '
        'randver
        '
        Me.randver.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.randver.Cursor = System.Windows.Forms.Cursors.Hand
        Me.randver.Dock = System.Windows.Forms.DockStyle.Right
        Me.randver.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.randver.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.randver.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.randver.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.randver.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.randver.ForeHoverColor = System.Drawing.Color.Gray
        Me.randver.Location = New System.Drawing.Point(1375, 10)
        Me.randver.Name = "randver"
        Me.randver.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.randver.RectColor = System.Drawing.Color.Gray
        Me.randver.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.randver.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.randver.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.randver.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.randver.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.randver.Size = New System.Drawing.Size(45, 25)
        Me.randver.Style = DrakeUI.Framework.UIStyle.Custom
        Me.randver.Symbol = 61529
        Me.randver.SymbolSize = 25
        Me.randver.TabIndex = 33
        '
        'DrakeWidth_W3
        '
        Me.DrakeWidth_W3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W3.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W3.Location = New System.Drawing.Point(157, 10)
        Me.DrakeWidth_W3.Name = "DrakeWidth_W3"
        Me.DrakeWidth_W3.Size = New System.Drawing.Size(25, 25)
        Me.DrakeWidth_W3.TabIndex = 61
        '
        'upbtnall
        '
        Me.upbtnall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.upbtnall.Dock = System.Windows.Forms.DockStyle.Left
        Me.upbtnall.FillColor = System.Drawing.Color.Black
        Me.upbtnall.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.upbtnall.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.upbtnall.Location = New System.Drawing.Point(10, 10)
        Me.upbtnall.Name = "upbtnall"
        Me.upbtnall.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.upbtnall.RectColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.upbtnall.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.upbtnall.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.upbtnall.Size = New System.Drawing.Size(147, 25)
        Me.upbtnall.Style = DrakeUI.Framework.UIStyle.Custom
        Me.upbtnall.Symbol = 61528
        Me.upbtnall.SymbolSize = 20
        Me.upbtnall.TabIndex = 62
        Me.upbtnall.Text = "Update all"
        '
        'Clientsupdater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1434, 688)
        Me.Controls.Add(Me.WebView21)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Clientsupdater"
        Me.Text = "Clientsupdater"
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.WebView21, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WebView21 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents Panel2 As Panel
    Friend WithEvents linktext As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents combotags As DrakeUI.Framework.DrakeUIComboBox
    Friend WithEvents randver As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W13 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W2 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents refbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W3 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents upbtnall As DrakeUI.Framework.DrakeUIButtonIcon
End Class
