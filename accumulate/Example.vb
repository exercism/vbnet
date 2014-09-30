Imports System.Collections.Generic
Imports System.Runtime.CompilerServices

Module AccumulateExtensions
    <Extension()> _
    Public Iterator Function Accumulate(Of T)(collection As IEnumerable(Of T), func As Func(Of T, T)) As IEnumerable(Of T)
        For Each item In collection
            Yield func(item)
        Next
    End Function
End Module
