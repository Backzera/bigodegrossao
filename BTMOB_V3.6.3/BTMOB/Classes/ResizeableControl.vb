Public Class ResizeableControl

    Private WithEvents mControl As Control
    Private mMouseDown As Boolean = False
    Public mEdge As EdgeEnum = EdgeEnum.None
    Private mWidth As Integer = 4
    Private mOutlineDrawn As Boolean = False
    Public Property AllowedEdge As EdgeEnum = EdgeEnum.None


    Public Enum EdgeEnum
        None
        Right
        Left
        Top
        Bottom
        TopLeft
    End Enum

    Public Sub New(ByVal Control As Control)
        mControl = Control
    End Sub

    Private Sub mControl_MouseDown(ByVal sender As Object,
        ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles mControl.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Left Then
            mMouseDown = True
        End If
    End Sub

    Private Sub mControl_MouseUp(ByVal sender As Object,
        ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles mControl.MouseUp

        mMouseDown = False
    End Sub

    Private Sub mControl_MouseMove(ByVal sender As Object,
    ByVal e As System.Windows.Forms.MouseEventArgs) _
    Handles mControl.MouseMove

        Dim c As Control = CType(sender, Control)
        Dim g As Graphics = c.CreateGraphics
        Select Case mEdge
            Case EdgeEnum.TopLeft
                g.FillRectangle(Brushes.RoyalBlue,
            0, 0, mWidth * 4, mWidth * 4)
                mOutlineDrawn = True
            Case EdgeEnum.Left
                g.FillRectangle(Brushes.RoyalBlue,
            0, 0, mWidth, c.Height)
                mOutlineDrawn = True
            Case EdgeEnum.Right
                g.FillRectangle(Brushes.RoyalBlue,
            c.Width - mWidth, 0, c.Width, c.Height)
                mOutlineDrawn = True
            Case EdgeEnum.Top
                g.FillRectangle(Brushes.RoyalBlue,
            0, 0, c.Width, mWidth)
                mOutlineDrawn = True
            Case EdgeEnum.Bottom
                g.FillRectangle(Brushes.RoyalBlue,
            0, c.Height - mWidth, c.Width, mWidth)
                mOutlineDrawn = True
            Case EdgeEnum.None
                If mOutlineDrawn Then
                    c.Refresh()
                    mOutlineDrawn = False
                End If
        End Select

        If mMouseDown And mEdge <> EdgeEnum.None Then
            c.SuspendLayout()
            Select Case mEdge
                Case EdgeEnum.TopLeft
                    c.SetBounds(c.Left + e.X, c.Top + e.Y,
            c.Width, c.Height)
                Case EdgeEnum.Left
                    c.SetBounds(c.Left + e.X, c.Top,
            c.Width - e.X, c.Height)
                Case EdgeEnum.Right
                    c.SetBounds(c.Left, c.Top,
            c.Width - (c.Width - e.X), c.Height)
                Case EdgeEnum.Top
                    c.SetBounds(c.Left, c.Top + e.Y,
            c.Width, c.Height - e.Y)
                Case EdgeEnum.Bottom
                    c.SetBounds(c.Left, c.Top,
            c.Width, c.Height - (c.Height - e.Y))
            End Select
            c.ResumeLayout()
        Else
            Select Case True
                Case AllowedEdge = EdgeEnum.TopLeft AndAlso e.X <= (mWidth * 4) AndAlso e.Y <= (mWidth * 4)
                    c.Cursor = Cursors.SizeAll
                    mEdge = EdgeEnum.TopLeft
                Case AllowedEdge = EdgeEnum.Left AndAlso e.X <= mWidth
                    c.Cursor = Cursors.VSplit
                    mEdge = EdgeEnum.Left
                Case AllowedEdge = EdgeEnum.Right AndAlso e.X > c.Width - (mWidth + 1)
                    c.Cursor = Cursors.VSplit
                    mEdge = EdgeEnum.Right
                Case AllowedEdge = EdgeEnum.Top AndAlso e.Y <= mWidth
                    c.Cursor = Cursors.HSplit
                    mEdge = EdgeEnum.Top
                Case AllowedEdge = EdgeEnum.Bottom AndAlso e.Y > c.Height - (mWidth + 1)
                    c.Cursor = Cursors.HSplit
                    mEdge = EdgeEnum.Bottom
                Case Else
                    c.Cursor = Cursors.Default
                    mEdge = EdgeEnum.None
            End Select

        End If
    End Sub

    Private Sub mControl_MouseLeave(ByVal sender As Object,
        ByVal e As System.EventArgs) _
        Handles mControl.MouseLeave

        Dim c As Control = CType(sender, Control)
        mEdge = EdgeEnum.None
        c.Refresh()
    End Sub

End Class