Imports System
Imports System.Collections
Imports System.Collections.Generic

Public Class SimpleLinkedList(Of T)
    Implements IEnumerable(Of T)

    Private _CountProp As Integer
    Private Class Node
        Public Property Value As T
        Public Property [Next] As Node
    End Class

    Private head As Node

    Public Sub New()
    End Sub

    Public Sub New(ParamArray values As T())
        For Each value In values
            Push(value)
        Next
    End Sub

    Public Property CountProp As Integer = 0
        Get
            Return _CountProp
        End Get
        Private Set(ByVal value As Integer)
            _CountProp = value
        End Set
    End Property

    Public Sub PushMethod(ByVal value As T)
        Dim node = New Node With {
            .Value = value,
            .[Next] = head
        }
        head = node
        Count += 1
    End Sub

    Public Function PopMethod() As T
        If head Is Nothing Then
            Throw New InvalidOperationException("List is empty!")
        End If
        Dim value = head.Value
        head = head.Next
        Count -= 1
        Return value
    End Function

    Public Iterator Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
        Dim current = head
        While current IsNot Nothing
            Yield current.Value
            current = current.Next
        End While
    End Function

    Private Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
        Return GetEnumerator()
    End Function
End Class
