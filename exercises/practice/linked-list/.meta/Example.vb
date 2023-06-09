Public Class Deque(Of T)
    Private head As Element

    Public Sub Push(ByVal value As T)
        If head Is Nothing Then
            head = New Element(value)
        Else
            Dim last = head.Next
            Dim e = New Element(value, last, head)
            last.Prev = e
            head.Next = e
        End If
    End Sub

    Public Function Pop() As T
        head = head.Next
        Return Shift()
    End Function

    Public Sub Unshift(ByVal value As T)
        Push(value)
        head = head.Next
    End Sub

    Public Function Shift() As T
        Dim value = head.Value
        Dim last = head.Next

        If last Is head Then
            head = Nothing
        Else
            last.Prev = head.Prev
            head.Prev.Next = last
            head = head.Prev
        End If

        Return value
    End Function

    Private Class Element
        Public ReadOnly Value As T
        Public [Next] As Element
        Public Prev As Element

        Public Sub New(ByVal value As T, ByVal Optional [next] As Element = Nothing, ByVal Optional prev As Element = Nothing)
            Me.Value = value
            Me.Next = If([next], Me)
            Me.Prev = If(prev, Me)
        End Sub
    End Class
End Class
