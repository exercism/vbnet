Imports System
Imports System.Linq

Public Module DifferenceOfSquares
    Public Function CalculateSquareOfSum(ByVal max As Integer) As Integer
        Dim numbers = Enumerable.Range(1, max)
        Dim sum As Integer = numbers.Sum()
        Return sum * sum
    End Function

    Public Function CalculateSumOfSquares(ByVal max As Integer) As Integer
        Dim numbers = Enumerable.Range(1, max)
        Return Enumerable.Select(Of Integer, Global.System.Int32)(numbers, CType(Function(x) CInt(x * x), Func(Of Integer, Integer))).Sum()
    End Function

    Public Function CalculateDifferenceOfSquares(ByVal max As Integer) As Integer
        Return CalculateSquareOfSum(max) - CalculateSumOfSquares(max)
    End Function
End Module
