Imports System
Imports System.Linq

Public Module Luhn
    Public Function IsValid(ByVal number As String) As Boolean
        number = number.Replace(" ", "")

        If number.Length < 2 OrElse number.Any(Function(c) c < "0"c OrElse c > "9"c) Then
            Return False
        End If

        Dim checksum = GenerateChecksum(number)

        Return checksum Mod 10 = 0
    End Function

    Private Function GenerateChecksum(ByVal number As String) As Integer
        Dim reversedIntArray = SplitToReversedIntArray(number)
        For i = 1 To reversedIntArray.Length - 1
            If i Mod 2 <> 0 Then reversedIntArray(i) = ConvertDigitForAddend(reversedIntArray(i))
        Next
        Array.Reverse(reversedIntArray)
        Return reversedIntArray.Sum()
    End Function

    Private Function SplitToReversedIntArray(ByVal value As String) As Integer()
        Return value.[Select](Function(c) Integer.Parse(c.ToString())).Reverse().ToArray()
    End Function

    Private Function ConvertDigitForAddend(ByVal value As Integer) As Integer
        Dim doubled = value * 2
        Return If(doubled < 10, doubled, doubled - 9)
    End Function
End Module
