<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vidplayer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(vidplayer))
        Me.viewimage = New System.Windows.Forms.PictureBox()
        Me.durprogress = New DrakeUI.Framework.DrakeUITrackBar()
        CType(Me.viewimage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'viewimage
        '
        Me.viewimage.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.viewimage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewimage.Image = Global.BTMOB.My.Resources.Resources.btloader
        Me.viewimage.Location = New System.Drawing.Point(0, 0)
        Me.viewimage.Name = "viewimage"
        Me.viewimage.Size = New System.Drawing.Size(514, 401)
        Me.viewimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.viewimage.TabIndex = 0
        Me.viewimage.TabStop = False
        '
        'durprogress
        '
        Me.durprogress.DisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.durprogress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.durprogress.Enabled = False
        Me.durprogress.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.durprogress.Font = New System.Drawing.Font("Cascadia Code", 12.0!)
        Me.durprogress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.durprogress.Location = New System.Drawing.Point(0, 401)
        Me.durprogress.Name = "durprogress"
        Me.durprogress.RectColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.durprogress.Size = New System.Drawing.Size(514, 16)
        Me.durprogress.Style = DrakeUI.Framework.UIStyle.Custom
        Me.durprogress.TabIndex = 44
        Me.durprogress.Text = "DrakeUITrackBar4"
        '
        'vidplayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(514, 417)
        Me.Controls.Add(Me.viewimage)
        Me.Controls.Add(Me.durprogress)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "vidplayer"
        Me.Text = "BT-Video Player"
        CType(Me.viewimage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents viewimage As PictureBox
    Friend WithEvents durprogress As DrakeUI.Framework.DrakeUITrackBar
End Class
