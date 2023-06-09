Imports System.Collections.Generic
Imports System.Linq

Public Module SumOfMultiples
    Public Function Sum(ByVal multiples As IEnumerable(Of Integer), ByVal max As Integer) As Integer
        Return Enumerable.Where(Enumerable.Range(1, max - 1), Function(i) Enumerable.Any(multiples, Function(m) m <> 0 AndAlso i Mod m = 0)).Sum()
    End Function
End Module
