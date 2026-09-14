<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class myinputs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(myinputs))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.inputtext2 = New DrakeUI.Framework.DrakeUITextBox()
        Me.inputtext = New DrakeUI.Framework.DrakeUITextBox()
        Me.msgtitle = New DrakeUI.Framework.DrakeUILabel()
        Me.DrakeWidth_W4 = New DrakeUI.Framework.DrakeWidth_W()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.checkfolder = New DrakeUI.Framework.DrakeUICheckBox()
        Me.nobtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W1 = New DrakeUI.Framework.DrakeWidth_W()
        Me.okbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W3 = New DrakeUI.Framework.DrakeWidth_W()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.msgimg = New System.Windows.Forms.PictureBox()
        Me.toppanel = New System.Windows.Forms.Panel()
        Me.DrakeWidth_W5 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W7 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W8 = New DrakeUI.Framework.DrakeWidth_W()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.msgimg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.inputtext2)
        Me.Panel3.Controls.Add(Me.inputtext)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(1, 45)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(746, 156)
        Me.Panel3.TabIndex = 32
        '
        'inputtext2
        '
        Me.inputtext2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.inputtext2.FillColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.inputtext2.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.inputtext2.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.inputtext2.ForeColor = System.Drawing.Color.White
        Me.inputtext2.Location = New System.Drawing.Point(57, 80)
        Me.inputtext2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.inputtext2.Maximum = 2147483647.0R
        Me.inputtext2.Minimum = -2147483648.0R
        Me.inputtext2.Name = "inputtext2"
        Me.inputtext2.Padding = New System.Windows.Forms.Padding(5)
        Me.inputtext2.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.inputtext2.RectColor = System.Drawing.Color.Gray
        Me.inputtext2.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.inputtext2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.inputtext2.Size = New System.Drawing.Size(615, 25)
        Me.inputtext2.Style = DrakeUI.Framework.UIStyle.Custom
        Me.inputtext2.TabIndex = 18
        Me.inputtext2.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.inputtext2.Visible = False
        Me.inputtext2.Watermark = "..."
        '
        'inputtext
        '
        Me.inputtext.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.inputtext.FillColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.inputtext.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.inputtext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.inputtext.ForeColor = System.Drawing.Color.White
        Me.inputtext.Location = New System.Drawing.Point(57, 29)
        Me.inputtext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.inputtext.Maximum = 2147483647.0R
        Me.inputtext.Minimum = -2147483648.0R
        Me.inputtext.Name = "inputtext"
        Me.inputtext.Padding = New System.Windows.Forms.Padding(5)
        Me.inputtext.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.inputtext.RectColor = System.Drawing.Color.Gray
        Me.inputtext.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.inputtext.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.inputtext.Size = New System.Drawing.Size(615, 25)
        Me.inputtext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.inputtext.TabIndex = 17
        Me.inputtext.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.inputtext.Watermark = "..."
        '
        'msgtitle
        '
        Me.msgtitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.msgtitle.Font = New System.Drawing.Font("Cascadia Code", 12.0!, System.Drawing.FontStyle.Bold)
        Me.msgtitle.ForeColor = System.Drawing.Color.DodgerBlue
        Me.msgtitle.Location = New System.Drawing.Point(63, 0)
        Me.msgtitle.Name = "msgtitle"
        Me.msgtitle.Padding = New System.Windows.Forms.Padding(5)
        Me.msgtitle.Size = New System.Drawing.Size(683, 42)
        Me.msgtitle.Style = DrakeUI.Framework.UIStyle.Custom
        Me.msgtitle.TabIndex = 2
        Me.msgtitle.Text = "title message"
        Me.msgtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DrakeWidth_W4
        '
        Me.DrakeWidth_W4.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DrakeWidth_W4.Location = New System.Drawing.Point(1, 201)
        Me.DrakeWidth_W4.Name = "DrakeWidth_W4"
        Me.DrakeWidth_W4.Size = New System.Drawing.Size(746, 1)
        Me.DrakeWidth_W4.TabIndex = 33
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Controls.Add(Me.checkfolder)
        Me.Panel2.Controls.Add(Me.nobtn)
        Me.Panel2.Controls.Add(Me.DrakeWidth_W1)
        Me.Panel2.Controls.Add(Me.okbtn)
        Me.Panel2.Controls.Add(Me.DrakeWidth_W3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(1, 202)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel2.Size = New System.Drawing.Size(746, 44)
        Me.Panel2.TabIndex = 29
        '
        'checkfolder
        '
        Me.checkfolder.CheckBoxColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.checkfolder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.checkfolder.Dock = System.Windows.Forms.DockStyle.Left
        Me.checkfolder.Font = New System.Drawing.Font("Cascadia Code", 12.0!)
        Me.checkfolder.ForeColor = System.Drawing.Color.White
        Me.checkfolder.Location = New System.Drawing.Point(5, 5)
        Me.checkfolder.Name = "checkfolder"
        Me.checkfolder.Padding = New System.Windows.Forms.Padding(22, 0, 0, 0)
        Me.checkfolder.Size = New System.Drawing.Size(207, 34)
        Me.checkfolder.Style = DrakeUI.Framework.UIStyle.Custom
        Me.checkfolder.TabIndex = 18
        Me.checkfolder.Text = "Folder"
        Me.checkfolder.Visible = False
        '
        'nobtn
        '
        Me.nobtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.nobtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.nobtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nobtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nobtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nobtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nobtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!, System.Drawing.FontStyle.Bold)
        Me.nobtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.nobtn.Location = New System.Drawing.Point(480, 5)
        Me.nobtn.Name = "nobtn"
        Me.nobtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.nobtn.RectColor = System.Drawing.Color.Gray
        Me.nobtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.nobtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nobtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.nobtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.nobtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.nobtn.Size = New System.Drawing.Size(111, 34)
        Me.nobtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.nobtn.Symbol = 81
        Me.nobtn.TabIndex = 3
        Me.nobtn.Text = "NO"
        '
        'DrakeWidth_W1
        '
        Me.DrakeWidth_W1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W1.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W1.Location = New System.Drawing.Point(591, 5)
        Me.DrakeWidth_W1.Name = "DrakeWidth_W1"
        Me.DrakeWidth_W1.Size = New System.Drawing.Size(28, 34)
        Me.DrakeWidth_W1.TabIndex = 5
        '
        'okbtn
        '
        Me.okbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.okbtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.okbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.okbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.okbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.okbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.okbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!, System.Drawing.FontStyle.Bold)
        Me.okbtn.ForeColor = System.Drawing.Color.DodgerBlue
        Me.okbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.okbtn.Location = New System.Drawing.Point(619, 5)
        Me.okbtn.Name = "okbtn"
        Me.okbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.okbtn.RectColor = System.Drawing.Color.DodgerBlue
        Me.okbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.okbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.okbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.okbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.okbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.okbtn.Size = New System.Drawing.Size(111, 34)
        Me.okbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.okbtn.Symbol = 82
        Me.okbtn.TabIndex = 2
        Me.okbtn.Text = "OK"
        '
        'DrakeWidth_W3
        '
        Me.DrakeWidth_W3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W3.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W3.Location = New System.Drawing.Point(730, 5)
        Me.DrakeWidth_W3.Name = "DrakeWidth_W3"
        Me.DrakeWidth_W3.Size = New System.Drawing.Size(11, 34)
        Me.DrakeWidth_W3.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(1, 246)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(746, 10)
        Me.Panel1.TabIndex = 30
        '
        'msgimg
        '
        Me.msgimg.Dock = System.Windows.Forms.DockStyle.Left
        Me.msgimg.Image = CType(resources.GetObject("msgimg.Image"), System.Drawing.Image)
        Me.msgimg.Location = New System.Drawing.Point(0, 0)
        Me.msgimg.Name = "msgimg"
        Me.msgimg.Size = New System.Drawing.Size(63, 42)
        Me.msgimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.msgimg.TabIndex = 31
        Me.msgimg.TabStop = False
        '
        'toppanel
        '
        Me.toppanel.BackColor = System.Drawing.Color.DodgerBlue
        Me.toppanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.toppanel.Location = New System.Drawing.Point(1, 0)
        Me.toppanel.Name = "toppanel"
        Me.toppanel.Size = New System.Drawing.Size(746, 3)
        Me.toppanel.TabIndex = 28
        '
        'DrakeWidth_W5
        '
        Me.DrakeWidth_W5.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W5.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W5.Location = New System.Drawing.Point(747, 0)
        Me.DrakeWidth_W5.Name = "DrakeWidth_W5"
        Me.DrakeWidth_W5.Size = New System.Drawing.Size(1, 256)
        Me.DrakeWidth_W5.TabIndex = 36
        '
        'DrakeWidth_W7
        '
        Me.DrakeWidth_W7.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W7.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W7.Location = New System.Drawing.Point(0, 0)
        Me.DrakeWidth_W7.Name = "DrakeWidth_W7"
        Me.DrakeWidth_W7.Size = New System.Drawing.Size(1, 256)
        Me.DrakeWidth_W7.TabIndex = 38
        '
        'DrakeWidth_W8
        '
        Me.DrakeWidth_W8.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DrakeWidth_W8.Location = New System.Drawing.Point(0, 256)
        Me.DrakeWidth_W8.Name = "DrakeWidth_W8"
        Me.DrakeWidth_W8.Size = New System.Drawing.Size(748, 1)
        Me.DrakeWidth_W8.TabIndex = 37
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.msgtitle)
        Me.Panel4.Controls.Add(Me.msgimg)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(1, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(746, 42)
        Me.Panel4.TabIndex = 19
        '
        'myinputs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(748, 257)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.DrakeWidth_W4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.toppanel)
        Me.Controls.Add(Me.DrakeWidth_W5)
        Me.Controls.Add(Me.DrakeWidth_W7)
        Me.Controls.Add(Me.DrakeWidth_W8)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "myinputs"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "BT | input"
        Me.TopMost = True
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.msgimg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents msgtitle As DrakeUI.Framework.DrakeUILabel
    Friend WithEvents DrakeWidth_W4 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents Panel2 As Panel
    Friend WithEvents nobtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W1 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents okbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W3 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents Panel1 As Panel
    Friend WithEvents msgimg As PictureBox
    Friend WithEvents toppanel As Panel
    Friend WithEvents DrakeWidth_W5 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W7 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W8 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents inputtext As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents checkfolder As DrakeUI.Framework.DrakeUICheckBox
    Friend WithEvents inputtext2 As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents Panel4 As Panel
End Class
