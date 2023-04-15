Imports System.Security.Cryptography.X509Certificates

Public Module ReverseString
    Public Function Reverse(ByVal inputString As String) As String
        Const cstrEmpty As String = ""
        If (inputString.Length = 0) Then
            Return cstrEmpty
        Else
            Dim i As Int32
            Dim j As Int32 = inputString.Length
            Dim r As New Text.StringBuilder(j)
            For i = j To 1 Step -1
                r.Append(inputString.Chars(i - 1))
            Next
            Return r.ToString()
        End If
    End Function
End Module
