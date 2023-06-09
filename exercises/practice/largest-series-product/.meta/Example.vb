Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Module LargestSeriesProduct
    Public Function GetLargestProduct(ByVal digits As String, ByVal span As Integer) As Long
        Return GetSlices(ParseDigits(digits), span).Max(Function(l) GetProduct(l))
    End Function

    Private Function GetSlices(ByVal digits As Long(), ByVal span As Integer) As IEnumerable(Of IEnumerable(Of Long))
        If span < 0 OrElse span > digits.Length Then
            Throw New ArgumentException("Invalid span.")
        End If

        Return Enumerable.Range(0, GetNumberOfSlices(digits, span)).[Select](Function(i) digits.Skip(i).Take(span))
    End Function

    Private Function ParseDigits(ByVal digits As String) As Long()
        Return digits.ToCharArray().[Select](New Func(Of Char, Long)(AddressOf ParseDigit)).ToArray()
    End Function

    Private Function ParseDigit(ByVal c As Char) As Long
        If Not Char.IsDigit(c) Then
            Throw New ArgumentException("Invalid digit.")
        End If

        Return Long.Parse(c.ToString())
    End Function

    Private Function GetProduct(ByVal numbers As IEnumerable(Of Long)) As Long
        Return numbers.Aggregate(1L, Function(x, product) x * product)
    End Function

    Private Function GetNumberOfSlices(ByVal digits As Long(), ByVal span As Integer) As Integer
        Return digits.Length + 1 - span
    End Function
End Module
