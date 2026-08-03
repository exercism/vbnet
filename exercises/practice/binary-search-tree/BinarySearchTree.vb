Public Class BinarySearchTree(Of T As IComparable(Of T))
    Public Sub New(ByVal data As T)
        Throw New NotImplementedException("You need to implement this function.")
    End Sub

    Public ReadOnly Property Data As T
    Public Property Left As BinarySearchTree(Of T)
    Public Property Right As BinarySearchTree(Of T)

    Public Sub Insert(ByVal value As T)
        Throw New NotImplementedException("You need to implement this function.")
    End Sub

    Public Function SortedData() As IEnumerable(Of T)
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Class
