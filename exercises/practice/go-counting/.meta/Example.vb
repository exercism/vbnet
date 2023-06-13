Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Enum Owner
    None
    Black
    White
End Enum

Public Class GoCounting
    Private ReadOnly board As Owner()()

    Public Sub New(ByVal input As String)
        board = ParseBoard(input)
    End Sub

    Private Shared Function CharToPlayer(ByVal c As Char) As Owner
        Select Case c
            Case "B"c
                Return Owner.Black
            Case "W"c
                Return Owner.White
            Case Else
                Return Owner.None
        End Select
    End Function

    Private Shared Function ParseBoard(ByVal input As String) As Owner()()
        Dim split = input.Split(ChrW(10))
        Return split.[Select](Function(row) row.[Select](New Func(Of Char, Owner)(AddressOf CharToPlayer)).ToArray()).ToArray()
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

    Private Function IsValidCoordinate(ByVal coordinate As (Integer, Integer)) As Boolean
        Return coordinate.Item2 >= 0 AndAlso coordinate.Item2 < Rows AndAlso coordinate.Item1 >= 0 AndAlso coordinate.Item1 < Cols
    End Function

    Private Function GetPlayer(ByVal coordinate As (Integer, Integer)) As Owner
        Return board(coordinate.Item2)(coordinate.Item1)
    End Function

    Private Function IsEmpty(ByVal coordinate As (Integer, Integer)) As Boolean
        Return GetPlayer(coordinate) = Owner.None
    End Function
    Private Function IsTaken(ByVal coordinate As (Integer, Integer)) As Boolean
        Return Not IsEmpty(coordinate)
    End Function

    Private Function EmptyCoordinates() As IEnumerable(Of (Integer, Integer))
        Return Enumerable.Range(0, Cols).SelectMany(Function(col) Enumerable.Range(0, Rows).[Select](Function(row) (col, row))).Where(New Func(Of (col As Integer, row As Integer), Boolean)(AddressOf IsEmpty))
    End Function

    Private Function NeighborCoordinates(ByVal coordinate As (Integer, Integer)) As IEnumerable(Of (Integer, Integer))
        Dim row = coordinate.Item2
        Dim col = coordinate.Item1

        Dim coords = {(col, row - 1), (col - 1, row), (col + 1, row), (col, row + 1)}

        Return coords.Where(New Func(Of (Integer, Integer), Boolean)(AddressOf IsValidCoordinate))
    End Function

    Private Function TakenNeighborCoordinates(ByVal coordinate As (Integer, Integer)) As IEnumerable(Of (Integer, Integer))
        Return NeighborCoordinates(coordinate).Where(New Func(Of (Integer, Integer), Boolean)(AddressOf IsTaken))
    End Function

    Private Function EmptyNeighborCoordinates(ByVal coordinate As (Integer, Integer)) As IEnumerable(Of (Integer, Integer))
        Return NeighborCoordinates(coordinate).Where(New Func(Of (Integer, Integer), Boolean)(AddressOf IsEmpty))
    End Function

    Private Function TerritoryOwner(ByVal coords As IEnumerable(Of (Integer, Integer))) As Owner
        Dim neighborColors = coords.SelectMany(New Func(Of (Integer, Integer), IEnumerable(Of (Integer, Integer)))(AddressOf TakenNeighborCoordinates)).[Select](New Func(Of (Integer, Integer), Owner)(AddressOf GetPlayer))
        Dim uniqueNeighborColors = ToSet(neighborColors)

        If uniqueNeighborColors.Count = 1 Then Return uniqueNeighborColors.First()

        Return Owner.None
    End Function

    Private Function TerritoryHelper(ByVal remainder As HashSet(Of (Integer, Integer)), ByVal acc As HashSet(Of (Integer, Integer))) As HashSet(Of (Integer, Integer))
        If Not remainder.Any() Then Return acc

        Dim emptyNeighbors = New HashSet(Of (Integer, Integer))(remainder.SelectMany(New Func(Of (Integer, Integer), IEnumerable(Of (Integer, Integer)))(AddressOf EmptyNeighborCoordinates)))
        emptyNeighbors.ExceptWith(acc)

        Dim newAcc = ToSet(acc)
        newAcc.UnionWith(emptyNeighbors)
        Return TerritoryHelper(emptyNeighbors, newAcc)
    End Function

    Private Function TerritoryHelper(ByVal coordinate As (Integer, Integer)) As HashSet(Of (Integer, Integer))
        Return If(IsValidCoordinate(coordinate) AndAlso IsEmpty(coordinate), TerritoryHelper(ToSingletonSet(coordinate), ToSingletonSet(coordinate)), New HashSet(Of (Integer, Integer))())
    End Function

    Public Function Territory(ByVal coord As (Integer, Integer)) As ValueTuple(Of Owner, IEnumerable(Of (Integer, Integer)))
        If coord.Item1 < 0 OrElse coord.Item1 >= Rows OrElse coord.Item2 < 0 OrElse coord.Item2 >= Cols Then
            Throw New ArgumentException()
        End If

        Dim coords = TerritoryHelper(coord)
        If Not coords.Any() Then Return (Owner.None, Enumerable.Empty(Of (Integer, Integer))())

        Dim owner = TerritoryOwner(coords)
        Return (owner, coords.OrderBy(Function(x) x.Item1).ThenBy(Function(x) x.Item2).ToArray())
    End Function

    Private Function TerritoriesHelper(ByVal remainder As HashSet(Of (Integer, Integer)), ByVal acc As Dictionary(Of Owner, (Integer, Integer)())) As Dictionary(Of Owner, (Integer, Integer)())
        If Not remainder.Any() Then Return acc

        Dim coord = remainder.First()
        Dim coords = TerritoryHelper(coord)
        Dim owner = TerritoryOwner(coords)

        Dim newRemainder = ToSet(remainder)
        newRemainder.ExceptWith(coords)

        acc(owner) = acc(owner).Concat(coords).ToArray()
        Return TerritoriesHelper(newRemainder, acc)
    End Function

    Public Function Territories() As Dictionary(Of Owner, (Integer, Integer)())
        Dim emptyCoords = EmptyCoordinates()

        Dim lTerritories = New Dictionary(Of Owner, (Integer, Integer)()) From {
    {Owner.Black, Array.Empty(Of (Integer, Integer))()},
    {Owner.White, Array.Empty(Of (Integer, Integer))()},
    {Owner.None, Array.Empty(Of (Integer, Integer))()}
}

        Return TerritoriesHelper(ToSet(emptyCoords), lTerritories)
    End Function

    Private Shared Function ToSet(Of T)(ByVal value As IEnumerable(Of T)) As HashSet(Of T)
        Return New HashSet(Of T)(value)
    End Function
    Private Shared Function ToSingletonSet(Of T)(ByVal value As T) As HashSet(Of T)
        Return New HashSet(Of T) From {
            value
        }
    End Function
End Class
