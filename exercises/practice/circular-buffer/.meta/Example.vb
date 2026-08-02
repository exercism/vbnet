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
        items = items.Skip(1).ToList()
    End Sub
End Class
