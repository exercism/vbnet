Imports System
Imports System.Collections.Generic

Public Enum SublistType
    Equal
    Unequal
    Superlist
    Sublist
End Enum

Public Module Sublist
    Public Function Classify(Of T As IComparable)(ByVal list1 As List(Of T), ByVal list2 As List(Of T)) As SublistType
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Module
