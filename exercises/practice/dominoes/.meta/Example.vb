Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.CompilerServices

Public Module Dominoes
    Public Function CanChain(ByVal dominoes As IEnumerable(Of (Integer, Integer))) As Boolean
        If Not dominoes.Any() Then
            Return True
        End If

        Dim domino = dominoes.First()

        If dominoes.Count() = 1 Then
            Return domino.Item1 = domino.Item2
        End If

        Return dominoes.Skip(1).Rotate().Any(Function(sublist) Dominoes.PossibleChains(domino, sublist).Any(New Func(Of (Integer, Integer)(), Boolean)(AddressOf Dominoes.CanChain)))
    End Function

    Public Iterator Function PossibleChains(ByVal domino As (Integer, Integer), ByVal remainder As IEnumerable(Of (Integer, Integer))) As IEnumerable(Of (Integer, Integer)())
        Dim head = remainder.First()

        If domino.Item2 = head.Item1 Then
            Yield {(domino.Item1, head.Item2)}.Concat(remainder.Skip(1)).ToArray()
        ElseIf domino.Item2 = head.Item2 Then
            Yield {(domino.Item1, head.Item1)}.Concat(remainder.Skip(1)).ToArray()
        End If
    End Function

    <Extension()>
    Private Function Rotate(Of T)(ByVal input As IEnumerable(Of T)) As IEnumerable(Of IEnumerable(Of T))
        Return Enumerable.Range(0, input.Count()).[Select](Function(i) input.Skip(i).Take(input.Count() - i).Concat(input.Take(i)))
    End Function
End Module
