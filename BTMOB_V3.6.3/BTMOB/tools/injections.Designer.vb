<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class injections
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.combojects = New DrakeUI.Framework.DrakeUIComboBox()
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'myscr
        '
        Me.myscr.Image = Global.BTMOB.My.Resources.Resources.ject_off
        Me.myscr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        '
        'pinbtn
        '
        Me.pinbtn.Location = New System.Drawing.Point(760, 5)
        '
        'minibtn
        '
        Me.minibtn.Location = New System.Drawing.Point(807, 5)
        '
        'closbtn
        '
        Me.closbtn.Location = New System.Drawing.Point(854, 5)
        '
        'mytitle
        '
        Me.mytitle.Size = New System.Drawing.Size(886, 18)
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(2, 120)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(896, 440)
        Me.TextBox1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Controls.Add(Me.combojects)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(2, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel2.Size = New System.Drawing.Size(896, 49)
        Me.Panel2.TabIndex = 40
        '
        'combojects
        '
        Me.combojects.Dock = System.Windows.Forms.DockStyle.Left
        Me.combojects.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.combojects.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.combojects.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.combojects.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.combojects.Location = New System.Drawing.Point(10, 10)
        Me.combojects.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.combojects.MinimumSize = New System.Drawing.Size(63, 0)
        Me.combojects.Name = "combojects"
        Me.combojects.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.combojects.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.combojects.RectColor = System.Drawing.Color.Gray
        Me.combojects.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.combojects.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.combojects.Size = New System.Drawing.Size(310, 25)
        Me.combojects.Style = DrakeUI.Framework.UIStyle.Custom
        Me.combojects.TabIndex = 1
        Me.combojects.Text = "Target"
        Me.combojects.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'injections
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 562)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "injections"
        Me.Text = "injections"
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.TextBox1, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents combojects As DrakeUI.Framework.DrakeUIComboBox
End Class
