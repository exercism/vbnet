Imports System.Collections.Generic
Imports System.Linq

Public Class SecretHandshake
    Private Shared ReadOnly CommandValues As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String) From {
    {1, "wink"},
    {2, "double blink"},
    {4, "close your eyes"},
    {8, "jump"}
}

    Public Shared Function Commands(ByVal commandValue As Integer) As String()
        Dim lCommands = New List(Of String)()
        For Each value In SecretHandshake.CommandValues.OrderBy(Function(x) x.Key)
            If (commandValue And value.Key) <> 0 Then
                lCommands.Add(value.Value)
            End If
        Next

        If SecretHandshake.ShouldReverse(commandValue) Then
            Return lCommands.AsEnumerable().Reverse().ToArray()
        End If
        Return lCommands.ToArray()
    End Function

    Private Shared Function ShouldReverse(ByVal commandValue As Integer) As Boolean
        Return (commandValue And 16) <> 0
    End Function
End Class
