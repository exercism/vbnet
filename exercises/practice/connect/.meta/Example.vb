Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text.RegularExpressions

Public Enum ConnectWinner
    White
    Black
    None
End Enum

Public Class Connect
    Private Enum Cell
        Empty
        White
        Black
    End Enum

    Private ReadOnly board As Cell()()

    Public Sub New(ByVal input As String())
        board = ParseBoard(input)
    End Sub

    Private Shared Function CharToCell(ByVal c As Char) As Cell
        Select Case c
            Case "O"c
                Return Cell.White
            Case "X"c
                Return Cell.Black
            Case Else
                Return Cell.Empty
        End Select
    End Function

    Private Shared Function ParseBoard(ByVal input As String()) As Cell()()
        Dim rows = input.Length
        Dim cols = input(0).Length
        Dim filtered = New List(Of String)()
        For Each str In input
            filtered.Add(Regex.Replace(str, "\s+", ""))
        Next
        Return filtered.[Select](Function(row) row.[Select](New Func(Of Char, Cell)(AddressOf CharToCell)).ToArray()).ToArray()
    End Function

    Private ReadOnly Property Cols As Integer
        Get
            Return board(0).Length
        End Get
    End Property
    Private ReadOnly Property Rows As Integer
        Get
            Return board.Length
        End Get
    End Property

    Private Function IsValidCoordinate(ByVal coordinate As Tuple(Of Integer, Integer)) As Boolean
        Return coordinate.Item2 >= 0 AndAlso coordinate.Item2 < Rows AndAlso coordinate.Item1 >= 0 AndAlso coordinate.Item1 < Cols
    End Function

    Private Function CellAtCoordinateEquals(ByVal cell As Cell, ByVal coordinate As Tuple(Of Integer, Integer)) As Boolean
        Return board(coordinate.Item2)(coordinate.Item1) = cell
    End Function

    Private Function Adjacent(ByVal cell As Cell, ByVal coordinate As Tuple(Of Integer, Integer)) As HashSet(Of Tuple(Of Integer, Integer))
        Dim row = coordinate.Item2
        Dim col = coordinate.Item1

        Dim coords = {New Tuple(Of Integer, Integer)(col + 1, row - 1), New Tuple(Of Integer, Integer)(col, row - 1), New Tuple(Of Integer, Integer)(col - 1, row), New Tuple(Of Integer, Integer)(col + 1, row), New Tuple(Of Integer, Integer)(col - 1, row + 1), New Tuple(Of Integer, Integer)(col, row + 1)}

        Return New HashSet(Of Tuple(Of Integer, Integer))(coords.Where(Function(coord) IsValidCoordinate(coord) AndAlso CellAtCoordinateEquals(cell, coord)))
    End Function

    Private Function ValidPath(ByVal cell As Cell, ByVal [stop] As Func(Of Cell()(), Tuple(Of Integer, Integer), Boolean), ByVal processed As HashSet(Of Tuple(Of Integer, Integer)), ByVal coordinate As Tuple(Of Integer, Integer)) As Boolean
        If [stop](board, coordinate) Then Return True

        Dim [next] = Adjacent(cell, coordinate)
        [next].ExceptWith(processed)

        If Not [next].Any() Then Return False

        Return [next].Any(Function(nextCoord)
                              Dim updatedProcessed = New HashSet(Of Tuple(Of Integer, Integer))(processed)
                              updatedProcessed.Add(nextCoord)

                              Return ValidPath(cell, [stop], updatedProcessed, nextCoord)
                          End Function)
    End Function

    Private Function IsWhiteStop(ByVal board As Cell()(), ByVal coordinate As Tuple(Of Integer, Integer)) As Boolean
        Return coordinate.Item2 = Rows - 1
    End Function
    Private Function IsBlackStop(ByVal board As Cell()(), ByVal coordinate As Tuple(Of Integer, Integer)) As Boolean
        Return coordinate.Item1 = Cols - 1
    End Function

    Private Function WhiteStart() As HashSet(Of Tuple(Of Integer, Integer))
        Return New HashSet(Of Tuple(Of Integer, Integer))(Enumerable.Range(0, Cols).[Select](Function(col) New Tuple(Of Integer, Integer)(col, 0)).Where(Function(coord) CellAtCoordinateEquals(Cell.White, coord)))
    End Function

    Private Function BlackStart() As HashSet(Of Tuple(Of Integer, Integer))
        Return New HashSet(Of Tuple(Of Integer, Integer))(Enumerable.Range(0, Rows).[Select](Function(row) New Tuple(Of Integer, Integer)(0, row)).Where(Function(coord) CellAtCoordinateEquals(Cell.Black, coord)))
    End Function

    Private Function ColorWins(ByVal cell As Cell, ByVal [stop] As Func(Of Cell()(), Tuple(Of Integer, Integer), Boolean), ByVal start As Func(Of HashSet(Of Tuple(Of Integer, Integer)))) As Boolean
        Return start().Any(Function(coordinate) ValidPath(cell, [stop], New HashSet(Of Tuple(Of Integer, Integer))(), coordinate))
    End Function

    Private Function WhiteWins() As Boolean
        Return ColorWins(Cell.White, New Func(Of Cell()(), Tuple(Of Integer, Integer), Boolean)(AddressOf IsWhiteStop), New Func(Of HashSet(Of Tuple(Of Integer, Integer)))(AddressOf WhiteStart))
    End Function
    Private Function BlackWins() As Boolean
        Return ColorWins(Cell.Black, New Func(Of Cell()(), Tuple(Of Integer, Integer), Boolean)(AddressOf IsBlackStop), New Func(Of HashSet(Of Tuple(Of Integer, Integer)))(AddressOf BlackStart))
    End Function

    Public Function Result() As ConnectWinner
        If WhiteWins() Then Return ConnectWinner.White

        If BlackWins() Then Return ConnectWinner.Black

        Return ConnectWinner.None
    End Function
End Class
