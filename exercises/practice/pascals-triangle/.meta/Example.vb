Public Module PascalsTriangle
    Public Function Calculate(ByVal rows As Integer) As IEnumerable(Of IEnumerable(Of Integer))
        If rows < 0 Then
            Throw New ArgumentOutOfRangeException(NameOf(rows))
        End If

        Dim triangle = New List(Of IEnumerable(Of Integer))()
        Dim previousRow = Array.Empty(Of Integer)()

        For rowIndex = 0 To rows - 1
            Dim row(rowIndex) As Integer
            row(0) = 1
            row(rowIndex) = 1

            For column = 1 To rowIndex - 1
                row(column) = previousRow(column - 1) + previousRow(column)
            Next

            triangle.Add(row)
            previousRow = row
        Next

        Return triangle
    End Function
End Module
