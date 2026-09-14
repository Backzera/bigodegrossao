<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Clipboard
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.mictoolbox = New System.Windows.Forms.TableLayoutPanel()
        Me.setbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.pausebtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.getbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.logclipboard = New System.Windows.Forms.RichTextBox()
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.mictoolbox.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'myscr
        '
        Me.myscr.Visible = False
        '
        'pinbtn
        '
        Me.pinbtn.Location = New System.Drawing.Point(410, 5)
        '
        'minibtn
        '
        Me.minibtn.Location = New System.Drawing.Point(457, 5)
        '
        'closbtn
        '
        Me.closbtn.Location = New System.Drawing.Point(504, 5)
        '
        'myico
        '
        Me.myico.Image = Global.BTMOB.My.Resources.Resources.clipico
        '
        'mytitle
        '
        Me.mytitle.Size = New System.Drawing.Size(536, 18)
        Me.mytitle.Text = "..."
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Panel3.Controls.Add(Me.mictoolbox)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(2, 306)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(546, 35)
        Me.Panel3.TabIndex = 40
        '
        'mictoolbox
        '
        Me.mictoolbox.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.mictoolbox.ColumnCount = 3
        Me.mictoolbox.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.mictoolbox.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.mictoolbox.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.mictoolbox.Controls.Add(Me.setbtn, 0, 0)
        Me.mictoolbox.Controls.Add(Me.pausebtn, 0, 0)
        Me.mictoolbox.Controls.Add(Me.getbtn, 0, 0)
        Me.mictoolbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mictoolbox.Location = New System.Drawing.Point(0, 0)
        Me.mictoolbox.Name = "mictoolbox"
        Me.mictoolbox.Padding = New System.Windows.Forms.Padding(5)
        Me.mictoolbox.RowCount = 1
        Me.mictoolbox.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.mictoolbox.Size = New System.Drawing.Size(546, 35)
        Me.mictoolbox.TabIndex = 50
        '
        'setbtn
        '
        Me.setbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.setbtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.setbtn.Enabled = False
        Me.setbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.setbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.setbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.setbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.setbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.setbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.setbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.setbtn.Location = New System.Drawing.Point(364, 8)
        Me.setbtn.Name = "setbtn"
        Me.setbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.setbtn.RectColor = System.Drawing.Color.Gray
        Me.setbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.setbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.setbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.setbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.setbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.setbtn.Size = New System.Drawing.Size(174, 19)
        Me.setbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.setbtn.Symbol = 61508
        Me.setbtn.TabIndex = 23
        Me.setbtn.Text = "Update"
        '
        'pausebtn
        '
        Me.pausebtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pausebtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pausebtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pausebtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pausebtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pausebtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pausebtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pausebtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pausebtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.pausebtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.pausebtn.Location = New System.Drawing.Point(186, 8)
        Me.pausebtn.Name = "pausebtn"
        Me.pausebtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.pausebtn.RectColor = System.Drawing.Color.Gray
        Me.pausebtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.pausebtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pausebtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pausebtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pausebtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None
        Me.pausebtn.Size = New System.Drawing.Size(172, 19)
        Me.pausebtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.pausebtn.Symbol = 0
        Me.pausebtn.TabIndex = 22
        '
        'getbtn
        '
        Me.getbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.getbtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.getbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.getbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.getbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.getbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.getbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.getbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.getbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.getbtn.Location = New System.Drawing.Point(8, 8)
        Me.getbtn.Name = "getbtn"
        Me.getbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.getbtn.RectColor = System.Drawing.Color.Gray
        Me.getbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.getbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.getbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.getbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.getbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.getbtn.Size = New System.Drawing.Size(172, 19)
        Me.getbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.getbtn.Symbol = 61473
        Me.getbtn.TabIndex = 21
        Me.getbtn.TagString = "0"
        Me.getbtn.Text = "Refresh"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.logclipboard)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(2, 71)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(546, 235)
        Me.Panel4.TabIndex = 41
        '
        'logclipboard
        '
        Me.logclipboard.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.logclipboard.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.logclipboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.logclipboard.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.logclipboard.ForeColor = System.Drawing.SystemColors.Control
        Me.logclipboard.Location = New System.Drawing.Point(0, 0)
        Me.logclipboard.Name = "logclipboard"
        Me.logclipboard.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.logclipboard.Size = New System.Drawing.Size(546, 235)
        Me.logclipboard.TabIndex = 3
        Me.logclipboard.Text = ""
        '
        'Clipboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 343)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.MaximumSize = New System.Drawing.Size(627, 406)
        Me.MinimumSize = New System.Drawing.Size(549, 326)
        Me.Name = "Clipboard"
        Me.Text = "Clipboard"
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.mictoolbox.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents logclipboard As RichTextBox
    Friend WithEvents mictoolbox As TableLayoutPanel
    Friend WithEvents setbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents pausebtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents getbtn As DrakeUI.Framework.DrakeUIButtonIcon
End Class
