<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class terminal
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
        Me.termview = New Microsoft.Web.WebView2.WinForms.WebView2()
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.termview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pinbtn
        '
        Me.pinbtn.Location = New System.Drawing.Point(660, 5)
        '
        'minibtn
        '
        Me.minibtn.Location = New System.Drawing.Point(707, 5)
        '
        'closbtn
        '
        Me.closbtn.Location = New System.Drawing.Point(754, 5)
        '
        'mytitle
        '
        Me.mytitle.Size = New System.Drawing.Size(786, 18)
        '
        'termview
        '
        Me.termview.AllowExternalDrop = True
        Me.termview.CreationProperties = Nothing
        Me.termview.DefaultBackgroundColor = System.Drawing.Color.White
        Me.termview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.termview.Location = New System.Drawing.Point(2, 71)
        Me.termview.Name = "termview"
        Me.termview.Size = New System.Drawing.Size(796, 377)
        Me.termview.TabIndex = 40
        Me.termview.ZoomFactor = 1.0R
        '
        'terminal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.termview)
        Me.Name = "terminal"
        Me.Text = "terminal"
        Me.Controls.SetChildIndex(Me.termview, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.termview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents termview As Microsoft.Web.WebView2.WinForms.WebView2
End Class
