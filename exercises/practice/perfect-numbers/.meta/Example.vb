Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Enum Classification
    Perfect
    Abundant
    Deficient
End Enum

Public Module PerfectNumbers
    Private Function Factors(ByVal number As Integer) As List(Of Integer)
        Dim lFactors As List(Of Integer) = New List(Of Integer)() From {
            1
        }

        For i = 2 To number / 2

            If number Mod i = 0 Then
                lFactors.Add(i)
            End If
        Next

        Return lFactors
    End Function

    Public Function Classify(ByVal number As Integer) As Classification
        If number <= 0 Then Throw New ArgumentOutOfRangeException()
        Dim classifiable = Factors(number).Sum()
        If classifiable < number OrElse classifiable = 1 Then Return Classification.Deficient
        If classifiable > number Then Return Classification.Abundant
        Return Classification.Perfect
    End Function
End Module
