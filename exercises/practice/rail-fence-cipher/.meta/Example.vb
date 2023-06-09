Imports System
Imports System.Linq

Public Class RailFenceCipher
    Private ReadOnly _rails As Integer
    Private ReadOnly _size As Integer

    Public Sub New(ByVal rails As Integer)
        _rails = rails
        _size = rails * 2 - 2
    End Sub

    Public Function Encode(ByVal input As String) As String
        Return input.[Select](Function(c, i) Tuple.Create(Track(i), c)).GroupBy(Function(x) x.Item1).[Select](Function(x) New String(x.[Select](Function(y) y.Item2).ToArray())).Aggregate("", Function(acc, x) acc & x)
    End Function

    Public Function Decode(ByVal input As String) As String
        Return Enumerable.Range(0, input.Length).GroupBy(New Func(Of Integer, Integer)(AddressOf Track)).SelectMany(Function(x) x).Zip(input, New Func(Of Integer, Char, Tuple(Of Integer, Char))(AddressOf Tuple.Create)).OrderBy(Function(x) x.Item1).Aggregate("", Function(s, tuple) s & tuple.Item2.ToString())
    End Function

    Private Function Track(ByVal index As Integer) As Integer
        If IsCorrect(index) Then
            Return 0
        End If

        If IsCorrect(index - _rails + 1) Then
            Return _rails - 1
        End If

        Return Enumerable.Range(1, _rails - 1).First(Function(i) IsCorrect(index - i) OrElse IsCorrect(index - _size + i))
    End Function

    Private Function IsCorrect(ByVal index As Integer) As Boolean
        Return index Mod _size = 0
    End Function
End Class
