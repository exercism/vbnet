Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.CompilerServices

Module RomanNumeralExtension
    Private ReadOnly ArabicToRomanConversions As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String) From {
        {1000, "M"},
        {900, "CM"},
        {500, "D"},
        {400, "CD"},
        {100, "C"},
        {90, "XC"},
        {50, "L"},
        {40, "XL"},
        {10, "X"},
        {9, "IX"},
        {5, "V"},
        {4, "IV"},
        {1, "I"}
    }

    <Extension()>
    Function ToRoman(ByVal value As Integer) As String
        Dim result = New StringBuilder()

        For Each conversion In ArabicToRomanConversions

            While value / conversion.Key > 0
                value -= conversion.Key
                result.Append(conversion.Value)
            End While
        Next

        Return result.ToString()
    End Function
End Module
