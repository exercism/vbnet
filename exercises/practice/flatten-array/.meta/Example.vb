Imports System.Collections

Public Module FlattenArray
    Public Iterator Function Flatten(ByVal input As IEnumerable) As IEnumerable
        For Each element In input
            Dim enumerable = TryCast(element, IEnumerable)
            If enumerable IsNot Nothing Then
                For Each flattenedElement In Flatten(enumerable)
                    Yield flattenedElement
                Next
            ElseIf element IsNot Nothing Then
                Yield element
            End If
        Next
    End Function
End Module
