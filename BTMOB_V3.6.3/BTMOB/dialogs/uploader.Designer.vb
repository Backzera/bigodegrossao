<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uploader
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.uploadprogress = New DrakeUI.Framework.DrakeUITrackBar()
        Me.uploadworker = New System.ComponentModel.BackgroundWorker()
        Me.fnametext = New System.Windows.Forms.Label()
        Me.totaltext = New System.Windows.Forms.Label()
        Me.senttext = New System.Windows.Forms.Label()
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'myscr
        '
        Me.myscr.Enabled = False
        Me.myscr.Visible = False
        '
        'pinbtn
        '
        Me.pinbtn.Location = New System.Drawing.Point(481, 5)
        '
        'minibtn
        '
        Me.minibtn.Location = New System.Drawing.Point(547, 5)
        '
        'closbtn
        '
        Me.closbtn.Location = New System.Drawing.Point(613, 5)
        '
        'mytitle
        '
        Me.mytitle.Size = New System.Drawing.Size(664, 24)
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.BTMOB.My.Resources.Resources.uploading
        Me.PictureBox1.Location = New System.Drawing.Point(576, 77)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 131)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        '
        'uploadprogress
        '
        Me.uploadprogress.DisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.uploadprogress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.uploadprogress.Enabled = False
        Me.uploadprogress.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.uploadprogress.Font = New System.Drawing.Font("Cascadia Code", 12.0!)
        Me.uploadprogress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.uploadprogress.Location = New System.Drawing.Point(2, 192)
        Me.uploadprogress.Name = "uploadprogress"
        Me.uploadprogress.ReadOnly = True
        Me.uploadprogress.RectColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.uploadprogress.Size = New System.Drawing.Size(574, 16)
        Me.uploadprogress.Style = DrakeUI.Framework.UIStyle.Custom
        Me.uploadprogress.TabIndex = 43
        Me.uploadprogress.Text = "DrakeUITrackBar4"
        '
        'uploadworker
        '
        '
        'fnametext
        '
        Me.fnametext.Dock = System.Windows.Forms.DockStyle.Top
        Me.fnametext.Font = New System.Drawing.Font("Cascadia Code", 9.0!, System.Drawing.FontStyle.Bold)
        Me.fnametext.ForeColor = System.Drawing.Color.Transparent
        Me.fnametext.Location = New System.Drawing.Point(2, 77)
        Me.fnametext.Name = "fnametext"
        Me.fnametext.Size = New System.Drawing.Size(574, 35)
        Me.fnametext.TabIndex = 44
        Me.fnametext.Text = "File Name: "
        Me.fnametext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'totaltext
        '
        Me.totaltext.Dock = System.Windows.Forms.DockStyle.Top
        Me.totaltext.Font = New System.Drawing.Font("Cascadia Code", 9.0!, System.Drawing.FontStyle.Bold)
        Me.totaltext.ForeColor = System.Drawing.Color.Transparent
        Me.totaltext.Location = New System.Drawing.Point(2, 112)
        Me.totaltext.Name = "totaltext"
        Me.totaltext.Size = New System.Drawing.Size(574, 35)
        Me.totaltext.TabIndex = 45
        Me.totaltext.Text = "Total Size : "
        Me.totaltext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'senttext
        '
        Me.senttext.Dock = System.Windows.Forms.DockStyle.Top
        Me.senttext.Font = New System.Drawing.Font("Cascadia Code", 9.0!, System.Drawing.FontStyle.Bold)
        Me.senttext.ForeColor = System.Drawing.Color.Transparent
        Me.senttext.Location = New System.Drawing.Point(2, 147)
        Me.senttext.Name = "senttext"
        Me.senttext.Size = New System.Drawing.Size(574, 35)
        Me.senttext.TabIndex = 46
        Me.senttext.Text = "Sent Size : "
        Me.senttext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'uploader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(678, 210)
        Me.Controls.Add(Me.senttext)
        Me.Controls.Add(Me.totaltext)
        Me.Controls.Add(Me.fnametext)
        Me.Controls.Add(Me.uploadprogress)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximumSize = New System.Drawing.Size(678, 210)
        Me.MinimumSize = New System.Drawing.Size(678, 210)
        Me.Name = "uploader"
        Me.ShowInTaskbar = False
        Me.Text = "BT | File Uploader"
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.uploadprogress, 0)
        Me.Controls.SetChildIndex(Me.fnametext, 0)
        Me.Controls.SetChildIndex(Me.totaltext, 0)
        Me.Controls.SetChildIndex(Me.senttext, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents uploadprogress As DrakeUI.Framework.DrakeUITrackBar
    Friend WithEvents uploadworker As System.ComponentModel.BackgroundWorker
    Friend WithEvents fnametext As Label
    Friend WithEvents totaltext As Label
    Friend WithEvents senttext As Label
End Class
