Public Structure LaserInfo
    Public Sub New(ByVal x As Double, ByVal y As Double, ByVal angle As Double)
        Me.X = x
        Me.Y = y
        Me.Angle = angle
    End Sub

    Public ReadOnly Property X As Double
    Public ReadOnly Property Y As Double
    Public ReadOnly Property Angle As Double
End Structure

Public Structure PrismInfo
    Public Sub New(ByVal id As Integer, ByVal x As Double, ByVal y As Double, ByVal angle As Double)
        Me.Id = id
        Me.X = x
        Me.Y = y
        Me.Angle = angle
    End Sub

    Public ReadOnly Property Id As Integer
    Public ReadOnly Property X As Double
    Public ReadOnly Property Y As Double
    Public ReadOnly Property Angle As Double
End Structure

Public Module Prism
    Public Function FindSequence(ByVal laser As LaserInfo, ByVal prisms As PrismInfo()) As Integer()
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Module
