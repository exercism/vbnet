Imports System

Public Module Darts
    Public Function Score(ByVal x As Double, ByVal y As Double) As Integer
        Dim diff = Math.Pow(x, 2) + Math.Pow(y, 2)
        If diff > 100 Then Return 0 ' outside the radius 10 squared
        If diff <= 100 AndAlso diff > 25 Then Return 1 ' outer circle radius of 10 squared
        If diff <= 25 AndAlso diff > 1 Then Return 5 ' middle circle radius of 5 squared
        If diff <= 1 Then Return 10 ' in circle radius of 1 squared

        Return 0
    End Function
End Module
