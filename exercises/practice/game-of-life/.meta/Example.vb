Imports System
Imports System.Collections.Generic

Public Class GameOfLife
    Private _matrix As List(Of List(Of Integer))
    Private _rows As Integer
    Private _cols As Integer

    Public Sub New(ByVal matrix As List(Of List(Of Integer)))
        _matrix = matrix
        _rows = _matrix.Count
        If _rows > 0 Then
            _cols = _matrix(0).Count
        Else
            _cols = 0
        End If
    End Sub

    Public Function Tick()
        Dim newMatrix As New List(Of List(Of Integer))
        
        For row As Integer = 0 To _rows - 1
            Dim newRow As New List(Of Integer)
            For col As Integer = 0 To _cols - 1
                Dim liveNeighbors as Integer = 0
                For  nRow = Math.Max(0, row - 1) To Math.Min(_rows - 1, row + 1)
                    For nCol = Math.Max(0, col - 1) To Math.Min(_cols - 1, col + 1)
                        If nRow = row AndAlso nCol = col Then Continue For
                        liveNeighbors += _matrix(nRow)(nCol)
                    Next
                Next
                
                Dim currentCell As Integer = _matrix(row)(col)
                If currentCell = 1 Then
                    If liveNeighbors = 2 OrElse liveNeighbors = 3 Then
                        newRow.Add(1)
                    Else
                        newRow.Add(0)
                    End If
                Else
                    If liveNeighbors = 3 Then
                        newRow.Add(1)
                    Else
                        newRow.Add(0)
                    End If
                End If
            Next
            newMatrix.Add(newRow)
        Next
        
        _matrix = newMatrix
    End Function 

    Public Function Matrix() As List(Of List(Of Integer))
        Return _matrix
    End Function
End Class
