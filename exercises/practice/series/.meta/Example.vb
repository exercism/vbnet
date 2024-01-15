Imports System
Imports System.Linq

Public Module Series
    Public Function Slices(ByVal numbers As String, ByVal sliceLength As Integer) As String()
        If numbers.Length = 0 OrElse sliceLength <= 0 OrElse sliceLength > numbers.Length Then Throw New ArgumentException()

        Return Enumerable.Range(0, numbers.Length - sliceLength + 1).[Select](Function(i) numbers.Substring(i, sliceLength)).ToArray()
    End Function
End Module
