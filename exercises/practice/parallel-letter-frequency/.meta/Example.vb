Imports System.Collections.Generic
Imports System.Linq

Public Module ParallelLetterFrequency
    Public Function Calculate(ByVal texts As IEnumerable(Of String)) As Dictionary(Of Char, Integer)
        Return texts.AsParallel().Aggregate(New Dictionary(Of Char, Integer)(), New Func(Of Dictionary(Of Char, Integer), String, Dictionary(Of Char, Integer))(AddressOf AddCount))
    End Function

    Private Function AddCount(ByVal target As Dictionary(Of Char, Integer), ByVal text As String) As Dictionary(Of Char, Integer)
        For Each kv In text.ToLower().Where(New Func(Of Char, Boolean)(AddressOf Char.IsLetter)).GroupBy(Function(c) c)
            If target.ContainsKey(kv.Key) Then
                target(kv.Key) += kv.Count()
            Else
                target(kv.Key) = kv.Count()
            End If
        Next

        Return target
    End Function
End Module
