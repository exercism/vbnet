Imports System.Linq

Public Module Transpose
    Public Function Text(ByVal input As String) As String
        Dim rows = input.Split(ChrW(10))
        Dim maxLineLength = rows.Max(Function(x) x.Length)
        Dim transposed = New String(maxLineLength - 1) {}

        For i = 0 To rows.Length - 1
            For j = 0 To rows(i).Length - 1
                transposed(j) += rows(i)(j)
            Next

            Dim remainderRowsMaximumLength = rows.Skip(i).Max(Function(x) x.Length)
            For k = rows(i).Length To remainderRowsMaximumLength - 1
                transposed(k) += " "
            Next
        Next

        Return String.Join(vbLf, transposed).TrimEnd()
    End Function
End Module
