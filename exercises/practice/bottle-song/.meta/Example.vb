Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Module BottleSong
    Public Function Recite(ByVal startBottles As Integer, ByVal takeDown As Integer) As String
        Return String.Join(Environment.NewLine & Environment.NewLine, _
            Enumerable.Range(startBottles - takeDown + 1, takeDown) _
            .Reverse() _
            .Select(Function(n) String.Join(Environment.NewLine, Verse(n))))
    End Function

    Private Function Verse(ByVal number As Integer) As List(Of String)
        Dim bottles As String = If(number = 1, "bottle", "bottles")
        Dim nextBottles As String = If((number - 1) = 1, "bottle", "bottles")
        Dim currCount As String = DecimalToOrdinal(number)
        Dim nextCount As String = DecimalToOrdinal(number - 1)
        Return New List(Of String) From {
            $"{currCount} green {bottles} hanging on the wall,",
            $"{currCount} green {bottles} hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            $"There'll be {nextCount.ToLowerInvariant()} green {nextBottles} hanging on the wall."
        }
    End Function

    Private Function DecimalToOrdinal(ByVal number As Integer) As String
        Select Case number
            Case 0
                Return "No"
            Case 1
                Return "One"
            Case 2
                Return "Two" 
            Case 3
                Return "Three"
            Case 4
                Return "Four"
            Case 5
                Return "Five"
            Case 6
                Return "Six"
            Case 7
                Return "Seven"
            Case 8
                Return "Eight"
            Case 9
                Return "Nine"
            Case 10
                Return "Ten"
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module