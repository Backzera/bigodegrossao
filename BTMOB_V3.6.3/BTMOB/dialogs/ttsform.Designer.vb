<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ttsform
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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.msgtitle = New DrakeUI.Framework.DrakeUILabel()
        Me.msgimg = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.nobtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W1 = New DrakeUI.Framework.DrakeWidth_W()
        Me.okbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W3 = New DrakeUI.Framework.DrakeWidth_W()
        Me.inputtext = New DrakeUI.Framework.DrakeUITextBox()
        Me.langtext = New DrakeUI.Framework.DrakeUIComboBox()
        Me.labeltext = New DrakeUI.Framework.DrakeUILabel()
        Me.toppanel = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4.SuspendLayout()
        CType(Me.msgimg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.msgtitle)
        Me.Panel4.Controls.Add(Me.msgimg)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(2, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(624, 42)
        Me.Panel4.TabIndex = 20
        '
        'msgtitle
        '
        Me.msgtitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.msgtitle.Font = New System.Drawing.Font("Cascadia Code", 12.0!, System.Drawing.FontStyle.Bold)
        Me.msgtitle.ForeColor = System.Drawing.Color.DodgerBlue
        Me.msgtitle.Location = New System.Drawing.Point(63, 0)
        Me.msgtitle.Name = "msgtitle"
        Me.msgtitle.Padding = New System.Windows.Forms.Padding(5)
        Me.msgtitle.Size = New System.Drawing.Size(561, 42)
        Me.msgtitle.Style = DrakeUI.Framework.UIStyle.Custom
        Me.msgtitle.TabIndex = 2
        Me.msgtitle.Text = "Text-To-Speech"
        Me.msgtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'msgimg
        '
        Me.msgimg.Dock = System.Windows.Forms.DockStyle.Left
        Me.msgimg.Image = Global.BTMOB.My.Resources.Resources.speech
        Me.msgimg.Location = New System.Drawing.Point(0, 0)
        Me.msgimg.Name = "msgimg"
        Me.msgimg.Size = New System.Drawing.Size(63, 42)
        Me.msgimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.msgimg.TabIndex = 31
        Me.msgimg.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Controls.Add(Me.nobtn)
        Me.Panel2.Controls.Add(Me.langtext)
        Me.Panel2.Controls.Add(Me.DrakeWidth_W1)
        Me.Panel2.Controls.Add(Me.okbtn)
        Me.Panel2.Controls.Add(Me.DrakeWidth_W3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(2, 248)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel2.Size = New System.Drawing.Size(624, 45)
        Me.Panel2.TabIndex = 30
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
        Me.nobtn.Location = New System.Drawing.Point(353, 10)
        Me.nobtn.Name = "nobtn"
        Me.nobtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.nobtn.RectColor = System.Drawing.Color.Gray
        Me.nobtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.nobtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nobtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.nobtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.nobtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.nobtn.Size = New System.Drawing.Size(111, 25)
        Me.nobtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.nobtn.Symbol = 81
        Me.nobtn.TabIndex = 3
        Me.nobtn.Text = "NO"
        '
        'DrakeWidth_W1
        '
        Me.DrakeWidth_W1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W1.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W1.Location = New System.Drawing.Point(464, 10)
        Me.DrakeWidth_W1.Name = "DrakeWidth_W1"
        Me.DrakeWidth_W1.Size = New System.Drawing.Size(28, 25)
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
        Me.okbtn.Location = New System.Drawing.Point(492, 10)
        Me.okbtn.Name = "okbtn"
        Me.okbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.okbtn.RectColor = System.Drawing.Color.DodgerBlue
        Me.okbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.okbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.okbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.okbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.okbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.okbtn.Size = New System.Drawing.Size(111, 25)
        Me.okbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.okbtn.Symbol = 82
        Me.okbtn.TabIndex = 2
        Me.okbtn.Text = "OK"
        '
        'DrakeWidth_W3
        '
        Me.DrakeWidth_W3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W3.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W3.Location = New System.Drawing.Point(603, 10)
        Me.DrakeWidth_W3.Name = "DrakeWidth_W3"
        Me.DrakeWidth_W3.Size = New System.Drawing.Size(11, 25)
        Me.DrakeWidth_W3.TabIndex = 6
        '
        'inputtext
        '
        Me.inputtext.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.inputtext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.inputtext.FillColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.inputtext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.inputtext.ForeColor = System.Drawing.Color.White
        Me.inputtext.Location = New System.Drawing.Point(2, 87)
        Me.inputtext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.inputtext.Maximum = 2147483647.0R
        Me.inputtext.Minimum = -2147483648.0R
        Me.inputtext.Multiline = True
        Me.inputtext.Name = "inputtext"
        Me.inputtext.Padding = New System.Windows.Forms.Padding(5)
        Me.inputtext.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.inputtext.RectColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.inputtext.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.inputtext.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.inputtext.Size = New System.Drawing.Size(624, 161)
        Me.inputtext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.inputtext.StyleCustomMode = True
        Me.inputtext.TabIndex = 31
        Me.inputtext.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.inputtext.Watermark = "..."
        '
        'langtext
        '
        Me.langtext.Dock = System.Windows.Forms.DockStyle.Left
        Me.langtext.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.langtext.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.langtext.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.langtext.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.langtext.ForeColor = System.Drawing.Color.White
        Me.langtext.Items.AddRange(New Object() {"English", "العربية", "中国人", "Русский", "Türkçe", "Español", "Português"})
        Me.langtext.Location = New System.Drawing.Point(10, 10)
        Me.langtext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.langtext.MinimumSize = New System.Drawing.Size(63, 0)
        Me.langtext.Name = "langtext"
        Me.langtext.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.langtext.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.langtext.RectColor = System.Drawing.Color.Gray
        Me.langtext.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.langtext.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.langtext.Size = New System.Drawing.Size(152, 25)
        Me.langtext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.langtext.TabIndex = 32
        Me.langtext.Text = "English"
        Me.langtext.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.langtext.Watermark = "Language"
        '
        'labeltext
        '
        Me.labeltext.Dock = System.Windows.Forms.DockStyle.Top
        Me.labeltext.Font = New System.Drawing.Font("Cascadia Code", 8.0!)
        Me.labeltext.ForeColor = System.Drawing.Color.White
        Me.labeltext.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.labeltext.Location = New System.Drawing.Point(2, 45)
        Me.labeltext.Name = "labeltext"
        Me.labeltext.Padding = New System.Windows.Forms.Padding(5)
        Me.labeltext.Size = New System.Drawing.Size(624, 42)
        Me.labeltext.Style = DrakeUI.Framework.UIStyle.Custom
        Me.labeltext.TabIndex = 33
        Me.labeltext.Text = "message that will be spoken through phone"
        Me.labeltext.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'toppanel
        '
        Me.toppanel.BackColor = System.Drawing.Color.DodgerBlue
        Me.toppanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.toppanel.Location = New System.Drawing.Point(2, 0)
        Me.toppanel.Name = "toppanel"
        Me.toppanel.Size = New System.Drawing.Size(624, 3)
        Me.toppanel.TabIndex = 32
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(2, 293)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(626, 2)
        Me.Panel1.TabIndex = 34
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(2, 295)
        Me.Panel3.TabIndex = 33
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(626, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(2, 293)
        Me.Panel5.TabIndex = 34
        '
        'ttsform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(628, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.inputtext)
        Me.Controls.Add(Me.labeltext)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.toppanel)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ttsform"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ttsform"
        Me.TopMost = True
        Me.Panel4.ResumeLayout(False)
        CType(Me.msgimg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents msgtitle As DrakeUI.Framework.DrakeUILabel
    Friend WithEvents msgimg As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents nobtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W1 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents okbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W3 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents inputtext As DrakeUI.Framework.DrakeUITextBox
    Friend WithEvents langtext As DrakeUI.Framework.DrakeUIComboBox
    Friend WithEvents labeltext As DrakeUI.Framework.DrakeUILabel
    Friend WithEvents toppanel As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
End Class
