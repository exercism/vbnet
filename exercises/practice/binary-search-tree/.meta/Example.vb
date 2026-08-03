Public Class BinarySearchTree(Of T As IComparable(Of T))
    Public Sub New(ByVal data As T)
        Me.Data = data
    End Sub

    Public ReadOnly Property Data As T
    Public Property Left As BinarySearchTree(Of T)
    Public Property Right As BinarySearchTree(Of T)

    Public Sub Insert(ByVal value As T)
        If value.CompareTo(Data) <= 0 Then
            If Left Is Nothing Then
                Left = New BinarySearchTree(Of T)(value)
            Else
                Left.Insert(value)
            End If
        ElseIf Right Is Nothing Then
            Right = New BinarySearchTree(Of T)(value)
        Else
            Right.Insert(value)
        End If
    End Sub

    Public Function SortedData() As IEnumerable(Of T)
        Dim values As New List(Of T)

        AddSortedData(values)

        Return values
    End Function

    Private Sub AddSortedData(ByVal values As List(Of T))
        If Left IsNot Nothing Then
            Left.AddSortedData(values)
        End If

        values.Add(Data)

        If Right IsNot Nothing Then
            Right.AddSortedData(values)
        End If
    End Sub
End Class
