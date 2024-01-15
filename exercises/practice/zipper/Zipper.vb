Imports System

Public Class BinTree
    Public Sub New(ByVal value As Integer, ByVal left As BinTree, ByVal right As BinTree)
        Throw New NotImplementedException("You need to implement this function.")
    End Sub

    Public ReadOnly Property Value As Integer
    Public ReadOnly Property Left As BinTree
    Public ReadOnly Property Right As BinTree
End Class

Public Class Zipper
    Public Function Value() As Integer
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function SetValue(ByVal newValue As Integer) As Zipper
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function SetLeft(ByVal binTree As BinTree) As Zipper
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function SetRight(ByVal binTree As BinTree) As Zipper
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Left() As Zipper
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Right() As Zipper
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Up() As Zipper
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function ToTree() As BinTree
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function FromTree(ByVal tree As BinTree) As Zipper
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Class
