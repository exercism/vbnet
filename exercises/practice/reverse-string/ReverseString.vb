Public Module ReverseString
    Public Function Reverse(ByVal inputString As String) As String
        Const cstrEmpty As String = ""
        If (inputString.Length = 0) Then
            Return cstrEmpty
        Else
            Throw New NotImplementedException("Delete this statement and write your own implementation here")
        End If
    End Function
End Module
