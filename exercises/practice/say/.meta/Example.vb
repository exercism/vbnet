Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Module Say
    Public Function InEnglishMethod(ByVal number As Long) As String
        If number < 0L OrElse number >= 1000000000000L Then
            Throw New ArgumentOutOfRangeException("Number out of range.")
        End If

        If number = 0L Then
            Return "zero"
        End If

        Return String.Join(" ", Parts(number))
    End Function

    Private Function Parts(ByVal number As Long) As IEnumerable(Of String)
        Dim counts = Say.Counts(number)
        Dim billionsCount = counts.Item1
        Dim millionsCount = counts.Item2
        Dim thousandsCount = counts.Item3
        Dim remainder = counts.Item4

        Dim billions = Say.Billions(billionsCount)
        Dim millions = Say.Millions(millionsCount)
        Dim thousands = Say.Thousands(thousandsCount)
        Dim hundreds = Say.Hundreds(remainder)

        Return {billions, millions, thousands, hundreds}.Where(Function(x) Not Equals(x, Nothing))
    End Function

    Private Function Bases(ByVal number As Long) As String
        Dim values = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"}

        Return If(number > 0 AndAlso number <= values.Length, values(number - 1), Nothing)
    End Function

    Private Function Tens(ByVal number As Long) As String
        If number < 20L Then
            Return Say.Bases(number)
        End If

        Dim values = {"twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"}

        Dim count = number / 10L
        Dim remainder = number Mod 10L
        Dim bases = Say.Bases(remainder)

        Dim countStr = values(count - 2)
        Dim basesStr = If(Equals(bases, Nothing), "", $"-{bases}")

        Return $"{countStr}{basesStr}"
    End Function

    Private Function Hundreds(ByVal number As Long) As String
        If number < 100L Then
            Return Say.Tens(number)
        End If

        Dim count = number / 100L
        Dim remainder = number Mod 100L
        Dim bases = Say.Bases(count)
        Dim tens = Say.Tens(remainder)
        Dim tensStr = If(Equals(tens, Nothing), "", $" {tens}")

        Return $"{bases} hundred{tensStr}"
    End Function

    Private Function Chunk(ByVal str As String, ByVal number As Long) As String
        Dim hundreds = Say.Hundreds(number)
        Return If(Equals(hundreds, Nothing), Nothing, $"{hundreds} {str}")
    End Function

    Private Function Thousands(ByVal number As Long) As String
        Return Chunk("thousand", number)
    End Function
    Private Function Millions(ByVal number As Long) As String
        Return Chunk("million", number)
    End Function
    Private Function Billions(ByVal number As Long) As String
        Return Chunk("billion", number)
    End Function

    Private Function Counts(ByVal number As Long) As Tuple(Of Long, Long, Long, Long)
        Dim billionsCount = number / 1000000000L
        Dim billionsRemainder = number Mod 1000000000L

        Dim millionsCount = billionsRemainder / 1000000L
        Dim millionsRemainder = billionsRemainder Mod 1000000L

        Dim thousandsCount = millionsRemainder / 1000L
        Dim thousandsRemainder = millionsRemainder Mod 1000L

        Return Tuple.Create(billionsCount, millionsCount, thousandsCount, thousandsRemainder)
    End Function
End Module
