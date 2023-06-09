Imports System.Collections.Generic

Public Module PythagoreanTriplet

    Public Iterator Function TripletsWithSum(ByVal sum As Integer) As IEnumerable(Of (Integer, Integer, Integer))
        Dim triplets = New List(Of (Integer, Integer, Integer))()
        For c = sum / 2 To 2 Step -1
            Dim left = sum - c
            Dim a = 1, b As Integer = left - a

            While b > a
                If a * a + b * b = c * c Then Yield (a, b, c)
                a += 1
                b -= 1
            End While
        Next
    End Function

End Module
