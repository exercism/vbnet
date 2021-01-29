Imports System.Linq

Public Module ReverseString
    Public Function Reverse(ByVal inputString As String) As String
        Return New String(inputString.ToCharArray().Reverse().ToArray())
    End Function
End Module