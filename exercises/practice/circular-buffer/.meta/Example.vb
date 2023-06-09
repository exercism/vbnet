Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Class CircularBuffer(Of T)
    Private ReadOnly capacity As Integer
    Private items As List(Of T)

    Public Sub New(ByVal capacity As Integer)
        Me.capacity = capacity
        items = New List(Of T)(capacity)
    End Sub

    Public Function Read() As T
        If items.Count = 0 Then
            Throw New InvalidOperationException("Cannot read from empty buffer")
        End If

        Dim value = items(0)

        DequeueHead()

        Return value
    End Function

    Public Sub Write(ByVal value As T)
        If items.Count = capacity Then
            Throw New InvalidOperationException("Cannot write to full buffer")
        End If

        items.Add(value)
    End Sub

    Public Sub Overwrite(ByVal value As T)
        If items.Count = capacity Then
            DequeueHead()
        End If

        Write(value)
    End Sub

    Public Sub Clear()
        items.Clear()
    End Sub

    Private Sub DequeueHead()
        CSharpImpl.__Assign(items, items.Skip(1).ToList())
    End Sub

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Class
