Imports System.Collections.Generic
Imports System

Module PascalsTriangle
    Function Calculate(ByVal rows As Integer) As IEnumerable(Of IEnumerable(Of Integer))
        If rows < 0 Then Throw New ArgumentOutOfRangeException()
        Return IterateRows(rows)
    End Function

    Private Iterator Function IterateRows(ByVal rows As Integer) As IEnumerable(Of IEnumerable(Of Integer))
        For i = 1 To rows
            Yield Row(i)
        Next
    End Function

    Private Iterator Function Row(ByVal row As Integer) As IEnumerable(Of Integer)
        Yield 1
        Dim column = 1

        For j = 1 To row - 1
            column = column * (row - j) / j
            Yield column
        Next
    End Function
End Module
