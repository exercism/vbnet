Imports System.Text.RegularExpressions

Public Module IsbnVerifier
    Public Function IsValid(ByVal number As String) As Boolean
        number = number.Replace("-", "")

        If Not Regex.IsMatch(number, "^(\d{9}[\dX])$") Then
            Return False
        End If

        Dim sum = 0
        Dim weight = 10
        Dim digit = 0
        For i = 0 To number.Length - 1
            digit = If(number(i) = "X"c AndAlso i = 9, 10, CInt(Char.GetNumericValue(number(i))))

            sum += digit * weight
            weight -= 1
        Next
        Return sum Mod 11 = 0
    End Function
End Module
