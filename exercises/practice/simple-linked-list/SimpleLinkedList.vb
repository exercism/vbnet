Public Class SimpleLinkedList(Of T)
    Public Sub New(ParamArray values As T())
    End Sub

    Public ReadOnly Property Count As Integer
        Get
            Throw New NotImplementedException("You need to implement this property.")
        End Get
    End Property

    Public Sub Push(ByVal value As T)
        Throw New NotImplementedException("You need to implement this method.")
    End Sub

    Public Function Pop() As T
        Throw New NotImplementedException("You need to implement this method.")
    End Function

    Public Function Peek() As T
        Throw New NotImplementedException("You need to implement this method.")
    End Function

    Public Function ToList() As List(Of T)
        Throw New NotImplementedException("You need to implement this method.")
    End Function

    Public Sub Reverse()
        Throw New NotImplementedException("You need to implement this method.")
    End Sub
End Class
