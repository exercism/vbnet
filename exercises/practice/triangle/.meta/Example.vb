Imports System
Imports System.Linq

Public Enum TriangleKind
    Equilateral
    Isosceles
    Scalene
    Invalid
End Enum

Module Triangle
    Function IsScalene(ByVal side1 As Double, ByVal side2 As Double, ByVal side3 As Double) As Boolean
        Return Kind(side1, side2, side3) = TriangleKind.Scalene
    End Function

    Function IsIsosceles(ByVal side1 As Double, ByVal side2 As Double, ByVal side3 As Double) As Boolean
        Dim triangle = Kind(side1, side2, side3)
        Return triangle = TriangleKind.Isosceles OrElse triangle = TriangleKind.Equilateral
    End Function

    Function IsEquilateral(ByVal side1 As Double, ByVal side2 As Double, ByVal side3 As Double) As Boolean
        Return Kind(side1, side2, side3) = TriangleKind.Equilateral
    End Function

    Private Function Kind(ByVal side1 As Double, ByVal side2 As Double, ByVal side3 As Double) As TriangleKind
        If AllSidesAreZero(side1, side2, side3) OrElse HasImpossibleSides(side1, side2, side3) OrElse ViolatesTriangleInequality(side1, side2, side3) Then
            Return TriangleKind.Invalid
        End If

        Dim uniqueSides As Integer = UniqueSides(side1, side2, side3)
        If uniqueSides = 1 Then Return TriangleKind.Equilateral
        If uniqueSides = 2 Then Return TriangleKind.Isosceles
        Return TriangleKind.Scalene
    End Function

    Private Function AllSidesAreZero(ByVal side1 As Double, ByVal side2 As Double, ByVal side3 As Double) As Boolean
        Return side1 = 0 AndAlso side2 = 0 AndAlso side3 = 0
    End Function

    Private Function HasImpossibleSides(ByVal side1 As Double, ByVal side2 As Double, ByVal side3 As Double) As Boolean
        Return side1 < 0 OrElse side2 < 0 OrElse side3 < 0
    End Function

    Private Function ViolatesTriangleInequality(ByVal side1 As Double, ByVal side2 As Double, ByVal side3 As Double) As Boolean
        Return side1 + side2 <= side3 OrElse side1 + side3 <= side2 OrElse side2 + side3 <= side1
    End Function

    Private Function UniqueSides(ByVal side1 As Double, ByVal side2 As Double, ByVal side3 As Double) As Integer
        Dim sides As Double() = {side1, side2, side3}
        Return sides.Distinct().Count()
    End Function
End Module
