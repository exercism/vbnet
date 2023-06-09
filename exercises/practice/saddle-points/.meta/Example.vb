Imports System.Collections.Generic
Imports System.Linq

Public Class SaddlePoints
    Public Shared Function Calculate(ByVal matrix As Integer(,)) As IEnumerable(Of (Integer, Integer))
        Dim rowCount = matrix.GetLength(0)
        Dim columnCount = matrix.GetLength(1)
        Dim maxRows = SaddlePoints.Rows(matrix, rowCount, columnCount).[Select](Function(r) r.Max()).ToArray()
        Dim minCols = SaddlePoints.Columns(matrix, columnCount, rowCount).[Select](Function(r) r.Min()).ToArray()
        Return SaddlePoints.Coordinates(rowCount, columnCount).Where(Function(x) SaddlePoints.IsSaddlePoint(x, maxRows, minCols, matrix)).[Select](Function(pair) (pair.Item1 + 1, pair.Item2 + 1)).ToArray()
    End Function

    Private Shared Function Coordinates(ByVal rowCount As Integer, ByVal columnCount As Integer) As IEnumerable(Of (Integer, Integer))
        Return Enumerable.Range(0, rowCount).SelectMany(Function(x) Enumerable.Range(0, columnCount).Select(Function(y) (x, y)))
    End Function

    Private Shared Function Columns(ByVal matrix As Integer(,), ByVal columnCount As Integer, ByVal rowCount As Integer) As IEnumerable(Of IEnumerable(Of Integer))
        Return Enumerable.Range(0, columnCount).Select(Function(y) Enumerable.Range(0, rowCount).Select(Function(x) matrix(x, y)))
    End Function

    Private Shared Function Rows(ByVal matrix As Integer(,), ByVal rowCount As Integer, ByVal columnCount As Integer) As IEnumerable(Of IEnumerable(Of Integer))
        Return Enumerable.Range(0, rowCount).Select(Function(x) Enumerable.Range(0, columnCount).Select(Function(y) matrix(x, y)))
    End Function

    Private Shared Function IsSaddlePoint(ByVal coordinate As (Integer, Integer), ByVal maxRows As Integer(), ByVal minCols As Integer(), ByVal matrix As Integer(,)) As Boolean
        Return maxRows(coordinate.Item1) = matrix(coordinate.Item1, coordinate.Item2) AndAlso minCols(coordinate.Item2) = matrix(coordinate.Item1, coordinate.Item2)
    End Function

End Class
