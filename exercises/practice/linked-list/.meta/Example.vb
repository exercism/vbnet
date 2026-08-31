Public Class Deque(Of T)
    Private head As Element
    Private tail As Element
    Private itemCount As Integer

    Public ReadOnly Property Count As Integer
        Get
            Return itemCount
        End Get
    End Property

    Public Sub Push(ByVal value As T)
        Dim element = New Element(value)

        If tail Is Nothing Then
            head = element
            tail = element
        Else
            element.Prev = tail
            tail.[Next] = element
            tail = element
        End If

        itemCount += 1
    End Sub

    Public Function Pop() As T
        Dim value = tail.Value

        If tail Is head Then
            head = Nothing
            tail = Nothing
        Else
            tail = tail.Prev
            tail.[Next] = Nothing
        End If

        itemCount -= 1
        Return value
    End Function

    Public Sub Unshift(ByVal value As T)
        Dim element = New Element(value)

        If head Is Nothing Then
            head = element
            tail = element
        Else
            element.[Next] = head
            head.Prev = element
            head = element
        End If

        itemCount += 1
    End Sub

    Public Function Shift() As T
        Dim value = head.Value

        If head Is tail Then
            head = Nothing
            tail = Nothing
        Else
            head = head.[Next]
            head.Prev = Nothing
        End If

        itemCount -= 1
        Return value
    End Function

    Public Sub Delete(ByVal value As T)
        Dim current = head

        While current IsNot Nothing
            If EqualityComparer(Of T).Default.Equals(current.Value, value) Then
                If current Is head Then
                    Shift()
                ElseIf current Is tail Then
                    Pop()
                Else
                    current.Prev.[Next] = current.[Next]
                    current.[Next].Prev = current.Prev
                    itemCount -= 1
                End If

                Return
            End If

            current = current.[Next]
        End While
    End Sub

    Private Class Element
        Public ReadOnly Value As T
        Public Property [Next] As Element
        Public Property Prev As Element

        Public Sub New(ByVal value As T)
            Me.Value = value
        End Sub
    End Class
End Class
