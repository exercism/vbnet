Imports System.Collections.Generic

Public Module MatchingBrackets
    Private ReadOnly closersOpeners As Dictionary(Of Char, Char)  From {
        {")"c, "("c},
        {"]"c, "["c},
        {"}"c, "{"c}
    }

    Public Function IsPaired(ByVal input As String) As Boolean
        Dim stack = New Stack(Of Char)

        For Each ch In input
            If closersOpeners.ContainsValue(ch) Then
                stack.Push(ch)
            ElseIf closersOpeners.ContainsKey(ch) Then

                If stack.Count > 0 AndAlso stack.Peek() = closersOpeners(ch) Then
                    stack.Pop()
                Else
                    Return False
                End If
            End If
        Next

        Return stack.Count = 0
    End Function
End Module