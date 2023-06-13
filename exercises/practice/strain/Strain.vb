Imports System
Imports System.Collections.Generic
Imports System.Runtime.CompilerServices

Public Module Strain
    <Extension()>
    Public Function Keep(Of T)(ByVal collection As IEnumerable(Of T), ByVal predicate As Func(Of T, Boolean)) As IEnumerable(Of T)
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    <Extension()>
    Public Function Discard(Of T)(ByVal collection As IEnumerable(Of T), ByVal predicate As Func(Of T, Boolean)) As IEnumerable(Of T)
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Module
