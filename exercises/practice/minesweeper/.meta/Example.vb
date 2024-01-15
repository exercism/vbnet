Imports System
Imports System.Collections.Generic

Public Class Minesweeper
    Public Shared Function Annotate(ByVal input As String()) As String()
        Dim results = New List(Of String)()

        Dim board = input

        For i = 0 To board.Length - 1
            Dim result = String.Empty

            For j = 0 To board(0).Length - 1
                If board(i)(j) = "*"c Then
                    result += "*"c
                Else
                    Dim numMines = Minesweeper.GetCountForSquare(board, i, j)
                    result += If(numMines = 0, " ", numMines.ToString())
                End If
            Next

            results.Add(result)
        Next

        Return results.ToArray()
    End Function

    Private Shared Function GetCountForSquare(ByVal board As String(), ByVal x As Integer, ByVal y As Integer) As Integer
        Dim result = 0

        For i = -1 To 1
            For j = -1 To 1
                Try
                    If board(x + i)(y + j) = "*"c Then
                        result += 1
                    End If
                Catch __unusedIndexOutOfRangeException1__ As IndexOutOfRangeException
                End Try
            Next
        Next

        Return result
    End Function
End Class
