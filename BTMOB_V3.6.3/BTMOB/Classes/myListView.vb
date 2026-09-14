Public Class MyListView
    Inherits ListView

    Public Sub New()
        ' Set control styles to reduce flickering
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    End Sub
End Class
