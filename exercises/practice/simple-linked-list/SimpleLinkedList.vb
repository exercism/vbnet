Imports System

Public Class SimpleLinkedList(Of T)
    Public ReadOnly Property Count As Integer
        Get
            Return CSharpImpl.__Throw(Of Object)(New NotImplementedException("You need to implement this function."))
        End Get
    End Property

    Public Sub Push(ByVal value As T)
        Throw New NotImplementedException("You need to implement this function.")
    End Sub

    Public Function Pop() As T
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal throw statements")>
        Shared Function __Throw(Of T)(ByVal e As Exception) As T
            Throw e
        End Function
    End Class
End Class
