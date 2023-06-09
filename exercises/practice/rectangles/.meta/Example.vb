Imports System
Imports System.Linq

Public Module Rectangles
    Public Function Count(ByVal rows As String()) As Integer
        Dim grid = ParseGrid(rows)
        Dim corners = FindCorners(grid)
        Return corners.Sum(Function(corner) RectangleForCorner(corner, corners, grid))
    End Function

    Private Function ParseGrid(ByVal rows As String()) As CellType()()
        Return rows.[Select](Function(row) row.[Select](New Func(Of Char, CellType)(AddressOf ParseCell)).ToArray()).ToArray()
    End Function

    Private Function ParseCell(ByVal cell As Char) As CellType
        Select Case cell
            Case "+"c
                Return CellType.Corner
            Case "-"c
                Return CellType.HorizontalLine
            Case "|"c
                Return CellType.VerticalLine
            Case " "c
                Return CellType.Empty
            Case Else
                Throw New ArgumentException()
        End Select
    End Function

    Private Function Rows(ByVal grid As CellType()()) As Integer
        Return grid.Length
    End Function

    Private Function Cols(ByVal grid As CellType()()) As Integer
        Return grid(0).Length
    End Function

    Private Function Cell(ByVal point As Tuple(Of Integer, Integer), ByVal grid As CellType()()) As CellType
        Return grid(point.Item2)(point.Item1)
    End Function

    Private Function FindCorners(ByVal grid As CellType()()) As Tuple(Of Integer, Integer)()
        Return Enumerable.Range(0, Rows(grid)).SelectMany(Function(y) Enumerable.Range(0, Cols(grid)).[Select](Function(x) New Tuple(Of Integer, Integer)(x, y))).Where(Function(point) Cell(point, grid) = CellType.Corner).ToArray()
    End Function

    Private Function ConnectsVertically(ByVal point As Tuple(Of Integer, Integer), ByVal grid As CellType()()) As Boolean
        Return Cell(point, grid) = CellType.VerticalLine OrElse Cell(point, grid) = CellType.Corner
    End Function

    Private Function ConnectedVertically(ByVal top As Tuple(Of Integer, Integer), ByVal bottom As Tuple(Of Integer, Integer), ByVal grid As CellType()()) As Boolean
        Return Enumerable.Range(top.Item2 + 1, bottom.Item2 - top.Item2 - 1).All(Function(y) ConnectsVertically(New Tuple(Of Integer, Integer)(top.Item1, y), grid))
    End Function

    Private Function ConnectsHorizontally(ByVal point As Tuple(Of Integer, Integer), ByVal grid As CellType()()) As Boolean
        Return Cell(point, grid) = CellType.HorizontalLine OrElse Cell(point, grid) = CellType.Corner
    End Function

    Private Function ConnectedHorizontally(ByVal left As Tuple(Of Integer, Integer), ByVal right As Tuple(Of Integer, Integer), ByVal grid As CellType()()) As Boolean
        Return Enumerable.Range(left.Item1 + 1, right.Item1 - left.Item1 - 1).All(Function(x) ConnectsHorizontally(New Tuple(Of Integer, Integer)(x, left.Item2), grid))
    End Function

    Private Function IsTopLineOfRectangle(ByVal topLeft As Tuple(Of Integer, Integer), ByVal topRight As Tuple(Of Integer, Integer), ByVal grid As CellType()()) As Boolean
        Return topRight.Item1 > topLeft.Item1 AndAlso topRight.Item2 = topLeft.Item2 AndAlso ConnectedHorizontally(topLeft, topRight, grid)
    End Function

    Private Function IsRightLineOfRectangle(ByVal topRight As Tuple(Of Integer, Integer), ByVal bottomRight As Tuple(Of Integer, Integer), ByVal grid As CellType()()) As Boolean
        Return bottomRight.Item1 = topRight.Item1 AndAlso bottomRight.Item2 > topRight.Item2 AndAlso ConnectedVertically(topRight, bottomRight, grid)
    End Function

    Private Function IsBottomLineOfRectangle(ByVal bottomLeft As Tuple(Of Integer, Integer), ByVal bottomRight As Tuple(Of Integer, Integer), ByVal grid As CellType()()) As Boolean
        Return bottomRight.Item1 > bottomLeft.Item1 AndAlso bottomRight.Item2 = bottomLeft.Item2 AndAlso ConnectedHorizontally(bottomLeft, bottomRight, grid)
    End Function

    Private Function IsLeftLineOfRectangle(ByVal topLeft As Tuple(Of Integer, Integer), ByVal bottomLeft As Tuple(Of Integer, Integer), ByVal grid As CellType()()) As Boolean
        Return bottomLeft.Item1 = topLeft.Item1 AndAlso bottomLeft.Item2 > topLeft.Item2 AndAlso ConnectedVertically(topLeft, bottomLeft, grid)
    End Function

    Private Function RectangleForCorner(ByVal topLeft As Tuple(Of Integer, Integer), ByVal corners As Tuple(Of Integer, Integer)(), ByVal grid As CellType()()) As Integer
        Return (From topRight In corners.Where(Function(corner) IsTopLineOfRectangle(topLeft, corner, grid)) From bottomLeft In corners.Where(Function(corner) IsLeftLineOfRectangle(topLeft, corner, grid)) From bottomRight In corners.Where(Function(corner) IsRightLineOfRectangle(topRight, corner, grid) AndAlso IsBottomLineOfRectangle(bottomLeft, corner, grid)) Select 1).Count()
    End Function

    Private Enum CellType
        Empty
        Corner
        HorizontalLine
        VerticalLine
    End Enum
End Module
