Public Class SimpleLinkedList(Of T)
    Private Class Node
        Public Sub New(ByVal value As T, ByVal nextNode As Node)
            Me.Value = value
            [Next] = nextNode
        End Sub

        Public ReadOnly Property Value As T
        Public Property [Next] As Node
    End Class

    Private head As Node
    Private countValue As Integer

    Public Sub New(ParamArray values As T())
        For Each value In values
            Push(value)
        Next
    End Sub

    Public ReadOnly Property Count As Integer
        Get
            Return countValue
        End Get
    End Property

    Public Sub Push(ByVal value As T)
        head = New Node(value, head)
        countValue += 1
    End Sub

    Public Function Pop() As T
        Dim value = Peek()
        head = head.Next
        countValue -= 1
        Return value
    End Function

    Public Function Peek() As T
        If head Is Nothing Then
            Throw New InvalidOperationException("The list is empty.")
        End If

        Return head.Value
    End Function

    Public Function ToList() As List(Of T)
        Dim values = New List(Of T)()
        Dim current = head

        While current IsNot Nothing
            values.Add(current.Value)
            current = current.Next
        End While

        Return values
    End Function

    Public Sub Reverse()
        Dim previous As Node = Nothing
        Dim current = head

        While current IsNot Nothing
            Dim following = current.Next
            current.Next = previous
            previous = current
            current = following
        End While

        head = previous
    End Sub
End Class
