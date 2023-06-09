Imports System.Linq

Public Module BeerSong
    Public Function Verse(ByVal number As Integer) As String
        Select Case number
            Case 0
                Return "No more bottles of beer on the wall, no more bottles of beer." & vbLf & "Go to the store and buy some more, 99 bottles of beer on the wall."
            Case 1
                Return "1 bottle of beer on the wall, 1 bottle of beer." & vbLf & "Take it down and pass it around, no more bottles of beer on the wall."
            Case 2
                Return "2 bottles of beer on the wall, 2 bottles of beer." & vbLf & "Take one down and pass it around, 1 bottle of beer on the wall."
            Case Else
                Return String.Format("{0} bottles of beer on the wall, {0} bottles of beer." & vbLf & "Take one down and pass it around, {1} bottles of beer on the wall.", number, number - 1)
        End Select
    End Function

    Public Function Recite(ByVal startBottles As Integer, ByVal takeDown As Integer) As String
        Return String.Join(vbLf & vbLf, Enumerable.Range(startBottles - takeDown + 1, takeDown).Reverse().[Select](New Func(Of Integer, String)(AddressOf Verse)))
    End Function
End Module
