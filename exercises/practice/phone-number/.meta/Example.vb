Imports System
Imports System.Text.RegularExpressions
Imports System.Linq

Public Class PhoneNumber
    Private Shared phoneNumberPattern As Regex = New Regex("[2-9]{1}\d{2}[2-9]{1}\d{2}\d{4}", RegexOptions.Compiled Or RegexOptions.CultureInvariant)

    Public Shared Function Clean(ByVal phoneNumber As String) As String
        Dim numericPhone = New [String](phoneNumber.Where(New Func(Of Char, Boolean)(AddressOf Char.IsDigit)).ToArray())

        If numericPhone.Length > 11 Then
            Throw New ArgumentException()
        End If

        If numericPhone.Length = 11 Then
            If numericPhone(0) <> "1"c Then
                Throw New ArgumentException()
            End If
            numericPhone = numericPhone.Substring(1)
        End If

        If Not phoneNumberPattern.IsMatch(numericPhone) Then
            Throw New ArgumentException()
        End If

        Return numericPhone
    End Function
End Class
