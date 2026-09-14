<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Chat
    Inherits Form

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
        Me.statetimer = New System.Windows.Forms.Timer(Me.components)
        Me.Chatview = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.DrakeWidth_W5 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W8 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W6 = New DrakeUI.Framework.DrakeWidth_W()
        Me.DrakeWidth_W7 = New DrakeUI.Framework.DrakeWidth_W()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.mytitle = New System.Windows.Forms.Label()
        Me.myico = New System.Windows.Forms.PictureBox()
        Me.DrakeUIButtonIcon1 = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.DrakeWidth_W2 = New DrakeUI.Framework.DrakeWidth_W()
        Me.sndbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        CType(Me.Chatview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'statetimer
        '
        '
        'Chatview
        '
        Me.Chatview.AllowExternalDrop = True
        Me.Chatview.BackColor = System.Drawing.Color.Black
        Me.Chatview.CreationProperties = Nothing
        Me.Chatview.DefaultBackgroundColor = System.Drawing.Color.White
        Me.Chatview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Chatview.ForeColor = System.Drawing.Color.White
        Me.Chatview.Location = New System.Drawing.Point(2, 52)
        Me.Chatview.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Chatview.Name = "Chatview"
        Me.Chatview.Size = New System.Drawing.Size(448, 942)
        Me.Chatview.TabIndex = 41
        Me.Chatview.ZoomFactor = 1.0R
        '
        'DrakeWidth_W5
        '
        Me.DrakeWidth_W5.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.DrakeWidth_W5.Dock = System.Windows.Forms.DockStyle.Left
        Me.DrakeWidth_W5.Location = New System.Drawing.Point(0, 2)
        Me.DrakeWidth_W5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrakeWidth_W5.Name = "DrakeWidth_W5"
        Me.DrakeWidth_W5.Size = New System.Drawing.Size(2, 992)
        Me.DrakeWidth_W5.TabIndex = 45
        '
        'DrakeWidth_W8
        '
        Me.DrakeWidth_W8.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.DrakeWidth_W8.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.DrakeWidth_W8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DrakeWidth_W8.Location = New System.Drawing.Point(0, 994)
        Me.DrakeWidth_W8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrakeWidth_W8.Name = "DrakeWidth_W8"
        Me.DrakeWidth_W8.Size = New System.Drawing.Size(450, 2)
        Me.DrakeWidth_W8.TabIndex = 44
        '
        'DrakeWidth_W6
        '
        Me.DrakeWidth_W6.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.DrakeWidth_W6.Dock = System.Windows.Forms.DockStyle.Top
        Me.DrakeWidth_W6.Location = New System.Drawing.Point(0, 0)
        Me.DrakeWidth_W6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrakeWidth_W6.Name = "DrakeWidth_W6"
        Me.DrakeWidth_W6.Size = New System.Drawing.Size(450, 2)
        Me.DrakeWidth_W6.TabIndex = 43
        '
        'DrakeWidth_W7
        '
        Me.DrakeWidth_W7.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.DrakeWidth_W7.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.DrakeWidth_W7.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W7.Location = New System.Drawing.Point(450, 0)
        Me.DrakeWidth_W7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DrakeWidth_W7.Name = "DrakeWidth_W7"
        Me.DrakeWidth_W7.Size = New System.Drawing.Size(2, 996)
        Me.DrakeWidth_W7.TabIndex = 42
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.mytitle)
        Me.Panel1.Controls.Add(Me.myico)
        Me.Panel1.Controls.Add(Me.DrakeUIButtonIcon1)
        Me.Panel1.Controls.Add(Me.DrakeWidth_W2)
        Me.Panel1.Controls.Add(Me.sndbtn)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(448, 50)
        Me.Panel1.TabIndex = 47
        '
        'mytitle
        '
        Me.mytitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.mytitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mytitle.Font = New System.Drawing.Font("Cascadia Code", 8.0!)
        Me.mytitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.mytitle.Location = New System.Drawing.Point(53, 5)
        Me.mytitle.Name = "mytitle"
        Me.mytitle.Size = New System.Drawing.Size(272, 40)
        Me.mytitle.TabIndex = 50
        Me.mytitle.Text = "...."
        Me.mytitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'myico
        '
        Me.myico.Dock = System.Windows.Forms.DockStyle.Left
        Me.myico.Location = New System.Drawing.Point(5, 5)
        Me.myico.Name = "myico"
        Me.myico.Size = New System.Drawing.Size(48, 40)
        Me.myico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.myico.TabIndex = 48
        Me.myico.TabStop = False
        '
        'DrakeUIButtonIcon1
        '
        Me.DrakeUIButtonIcon1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
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
        Me.DrakeUIButtonIcon1.Location = New System.Drawing.Point(325, 5)
        Me.DrakeUIButtonIcon1.Name = "DrakeUIButtonIcon1"
        Me.DrakeUIButtonIcon1.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.DrakeUIButtonIcon1.RectColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeUIButtonIcon1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.DrakeUIButtonIcon1.Size = New System.Drawing.Size(54, 40)
        Me.DrakeUIButtonIcon1.Style = DrakeUI.Framework.UIStyle.Custom
        Me.DrakeUIButtonIcon1.Symbol = 61741
        Me.DrakeUIButtonIcon1.TabIndex = 48
        '
        'DrakeWidth_W2
        '
        Me.DrakeWidth_W2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DrakeWidth_W2.Dock = System.Windows.Forms.DockStyle.Right
        Me.DrakeWidth_W2.Location = New System.Drawing.Point(379, 5)
        Me.DrakeWidth_W2.Name = "DrakeWidth_W2"
        Me.DrakeWidth_W2.Size = New System.Drawing.Size(10, 40)
        Me.DrakeWidth_W2.TabIndex = 49
        '
        'sndbtn
        '
        Me.sndbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sndbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.sndbtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.sndbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sndbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sndbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sndbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sndbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sndbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.sndbtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.sndbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.sndbtn.Location = New System.Drawing.Point(389, 5)
        Me.sndbtn.Name = "sndbtn"
        Me.sndbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.sndbtn.RectColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.sndbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.sndbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sndbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sndbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sndbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.sndbtn.Size = New System.Drawing.Size(54, 40)
        Me.sndbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.sndbtn.Symbol = 61453
        Me.sndbtn.TabIndex = 47
        '
        'Chat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(452, 996)
        Me.Controls.Add(Me.Chatview)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DrakeWidth_W5)
        Me.Controls.Add(Me.DrakeWidth_W8)
        Me.Controls.Add(Me.DrakeWidth_W6)
        Me.Controls.Add(Me.DrakeWidth_W7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MinimumSize = New System.Drawing.Size(452, 47)
        Me.Name = "Chat"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chat"
        CType(Me.Chatview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents statetimer As Timer
    Friend WithEvents Chatview As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents DrakeWidth_W5 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W8 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W6 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents DrakeWidth_W7 As DrakeUI.Framework.DrakeWidth_W
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DrakeUIButtonIcon1 As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents sndbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents myico As PictureBox
    Friend WithEvents DrakeWidth_W2 As DrakeUI.Framework.DrakeWidth_W
    Public WithEvents mytitle As Label
End Class
