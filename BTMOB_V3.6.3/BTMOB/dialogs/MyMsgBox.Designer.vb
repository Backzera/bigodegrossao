<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyMsgBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MyMsgBox))
        Me.toppanel = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.nobtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W1 = New DrakeUI.Framework.DrakeWidth_W()
        Me.okbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W3 = New DrakeUI.Framework.DrakeWidth_W()
        Me.msgtitle = New DrakeUI.Framework.DrakeUILabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.msgbody = New DrakeUI.Framework.DrakeUILabel()
        Me.DrakeWidth_W2 = New DrakeUI.Framework.DrakeWidth_W()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DrakeWidth_W4 = New DrakeUI.Framework.DrakeWidth_W()
        Me.msgimg = New System.Windows.Forms.PictureBox()
        Me.DrakeWidth_W5 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W7 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W8 = New DrakeUI.Framework.DrakeWidth_W()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.msgimg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'toppanel
        '
        Me.toppanel.BackColor = System.Drawing.Color.DodgerBlue
        Me.toppanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.toppanel.Location = New System.Drawing.Point(0, 0)
        Me.toppanel.Name = "toppanel"
        Me.toppanel.Size = New System.Drawing.Size(858, 3)
        Me.toppanel.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Controls.Add(Me.nobtn)
        Me.Panel2.Controls.Add(Me.DrakeWidth_W1)
        Me.Panel2.Controls.Add(Me.okbtn)
        Me.Panel2.Controls.Add(Me.DrakeWidth_W3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(11, 179)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel2.Size = New System.Drawing.Size(846, 50)
        Me.Panel2.TabIndex = 1
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
        Me.nobtn.Location = New System.Drawing.Point(580, 5)
        Me.nobtn.Name = "nobtn"
        Me.nobtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.nobtn.RectColor = System.Drawing.Color.Gray
        Me.nobtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.nobtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nobtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.nobtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.nobtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.nobtn.Size = New System.Drawing.Size(111, 40)
        Me.nobtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.nobtn.Symbol = 81
        Me.nobtn.TabIndex = 3
        Me.nobtn.Text = "NO"
        Me.nobtn.Visible = False
        '
        'DrakeWidth_W1
        '
        Me.DrakeWidth_W1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W1.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W1.Location = New System.Drawing.Point(691, 5)
        Me.DrakeWidth_W1.Name = "DrakeWidth_W1"
        Me.DrakeWidth_W1.Size = New System.Drawing.Size(28, 40)
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
        Me.okbtn.Location = New System.Drawing.Point(719, 5)
        Me.okbtn.Name = "okbtn"
        Me.okbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.okbtn.RectColor = System.Drawing.Color.DodgerBlue
        Me.okbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.okbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.okbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.okbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.okbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.okbtn.Size = New System.Drawing.Size(111, 40)
        Me.okbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.okbtn.Symbol = 82
        Me.okbtn.TabIndex = 2
        Me.okbtn.Text = "OK"
        '
        'DrakeWidth_W3
        '
        Me.DrakeWidth_W3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W3.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W3.Location = New System.Drawing.Point(830, 5)
        Me.DrakeWidth_W3.Name = "DrakeWidth_W3"
        Me.DrakeWidth_W3.Size = New System.Drawing.Size(11, 40)
        Me.DrakeWidth_W3.TabIndex = 6
        '
        'msgtitle
        '
        Me.msgtitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.msgtitle.Font = New System.Drawing.Font("Cascadia Code", 12.0!, System.Drawing.FontStyle.Bold)
        Me.msgtitle.ForeColor = System.Drawing.Color.DodgerBlue
        Me.msgtitle.Location = New System.Drawing.Point(90, 0)
        Me.msgtitle.Name = "msgtitle"
        Me.msgtitle.Padding = New System.Windows.Forms.Padding(5)
        Me.msgtitle.Size = New System.Drawing.Size(756, 42)
        Me.msgtitle.TabIndex = 2
        Me.msgtitle.Text = "title message"
        Me.msgtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.msgbody)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(11, 49)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(846, 129)
        Me.Panel3.TabIndex = 4
        '
        'msgbody
        '
        Me.msgbody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.msgbody.Font = New System.Drawing.Font("Cascadia Code", 10.5!)
        Me.msgbody.ForeColor = System.Drawing.Color.White
        Me.msgbody.Location = New System.Drawing.Point(0, 0)
        Me.msgbody.Name = "msgbody"
        Me.msgbody.Padding = New System.Windows.Forms.Padding(10)
        Me.msgbody.Size = New System.Drawing.Size(846, 129)
        Me.msgbody.TabIndex = 3
        Me.msgbody.Text = "message body"
        Me.msgbody.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DrakeWidth_W2
        '
        Me.DrakeWidth_W2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W2.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W2.Location = New System.Drawing.Point(1, 3)
        Me.DrakeWidth_W2.Name = "DrakeWidth_W2"
        Me.DrakeWidth_W2.Size = New System.Drawing.Size(10, 236)
        Me.DrakeWidth_W2.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(11, 229)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(846, 10)
        Me.Panel1.TabIndex = 1
        '
        'DrakeWidth_W4
        '
        Me.DrakeWidth_W4.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DrakeWidth_W4.Location = New System.Drawing.Point(11, 178)
        Me.DrakeWidth_W4.Name = "DrakeWidth_W4"
        Me.DrakeWidth_W4.Size = New System.Drawing.Size(846, 1)
        Me.DrakeWidth_W4.TabIndex = 4
        '
        'msgimg
        '
        Me.msgimg.Dock = System.Windows.Forms.DockStyle.Left
        Me.msgimg.Image = CType(resources.GetObject("msgimg.Image"), System.Drawing.Image)
        Me.msgimg.Location = New System.Drawing.Point(0, 0)
        Me.msgimg.Name = "msgimg"
        Me.msgimg.Size = New System.Drawing.Size(90, 46)
        Me.msgimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.msgimg.TabIndex = 3
        Me.msgimg.TabStop = False
        '
        'DrakeWidth_W5
        '
        Me.DrakeWidth_W5.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W5.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W5.Location = New System.Drawing.Point(857, 3)
        Me.DrakeWidth_W5.Name = "DrakeWidth_W5"
        Me.DrakeWidth_W5.Size = New System.Drawing.Size(1, 236)
        Me.DrakeWidth_W5.TabIndex = 26
        '
        'DrakeWidth_W7
        '
        Me.DrakeWidth_W7.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W7.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W7.Location = New System.Drawing.Point(0, 3)
        Me.DrakeWidth_W7.Name = "DrakeWidth_W7"
        Me.DrakeWidth_W7.Size = New System.Drawing.Size(1, 236)
        Me.DrakeWidth_W7.TabIndex = 27
        '
        'DrakeWidth_W8
        '
        Me.DrakeWidth_W8.BackColor = System.Drawing.Color.Gray
        Me.DrakeWidth_W8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DrakeWidth_W8.Location = New System.Drawing.Point(0, 239)
        Me.DrakeWidth_W8.Name = "DrakeWidth_W8"
        Me.DrakeWidth_W8.Size = New System.Drawing.Size(858, 1)
        Me.DrakeWidth_W8.TabIndex = 26
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.msgtitle)
        Me.Panel4.Controls.Add(Me.msgimg)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(11, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(846, 46)
        Me.Panel4.TabIndex = 4
        '
        'MyMsgBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(858, 240)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.DrakeWidth_W4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.DrakeWidth_W2)
        Me.Controls.Add(Me.DrakeWidth_W5)
        Me.Controls.Add(Me.DrakeWidth_W7)
        Me.Controls.Add(Me.DrakeWidth_W8)
        Me.Controls.Add(Me.toppanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MyMsgBox"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BT | MessageBox"
        Me.TopMost = True
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.msgimg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents toppanel As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents msgtitle As DrakeUI.Framework.DrakeUILabel
    Friend WithEvents nobtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents okbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents DrakeWidth_W1 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents msgimg As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents msgbody As DrakeUI.Framework.DrakeUILabel
    Friend WithEvents DrakeWidth_W2 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W3 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DrakeWidth_W4 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W5 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W7 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W8 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents Panel4 As Panel
End Class
