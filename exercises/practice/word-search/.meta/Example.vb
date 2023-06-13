Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Class WordSearch
    Private ReadOnly rows As String()
    Private ReadOnly width As Integer
    Private ReadOnly height As Integer
    Private positionsField As (Integer, Integer)()

    Private Shared ReadOnly Directions As (Integer, Integer)() = {(1, 0), (0, 1), (-1, 0), (0, -1), (1, 1), (1, -1), (-1, 1), (-1, -1)}

    Public Sub New(ByVal puzzle As String)
        rows = puzzle.Split(ChrW(10))
        width = rows(0).Length
        height = rows.Length
        positionsField = Positions()
    End Sub

    Public Function Search(ByVal words As IEnumerable(Of String)) As Dictionary(Of String, ((Integer, Integer), (Integer, Integer))?)
        Return words.ToDictionary(Function(word) word, New Func(Of String, ((Integer, Integer), (Integer, Integer))?)(AddressOf Search))
    End Function

    Private Function Search(ByVal word As String) As ((Integer, Integer), (Integer, Integer))?
        Return Positions().SelectMany(Function(position) Directions.SelectMany(Function(direction) Find(word, position, direction))).FirstOrDefault()
    End Function

    Private Iterator Function Find(ByVal word As String, ByVal position As (Integer, Integer), ByVal direction As (Integer, Integer)) As IEnumerable(Of ((Integer, Integer), (Integer, Integer))?)
        Dim current = position

        For Each letter In word
            If FindChar(current) <> letter Then
                Return
            End If

            current = (current.Item1 + direction.Item1, current.Item2 + direction.Item2)
        Next

        Yield (position, (current.Item1 - direction.Item1, current.Item2 - direction.Item2))
    End Function

    Private Function FindChar(ByVal coordinate As (Integer, Integer)) As Char?
        If coordinate.Item1 > 0 AndAlso coordinate.Item1 <= width AndAlso coordinate.Item2 > 0 AndAlso coordinate.Item2 <= height Then
            Return rows(coordinate.Item2 - 1)(coordinate.Item1 - 1)
        End If

        Return Nothing
    End Function

    Private Function Positions() As (Integer, Integer)()
        Return Enumerable.Range(1, width).SelectMany(Function(x) Enumerable.Range(1, height).[Select](Function(y) (x, y))).ToArray()
    End Function
End Class
