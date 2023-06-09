Imports System.Collections.Generic

Public Class PrimeFactors
    Public Shared Function Factors(ByVal number As Long) As Long()
        Dim primes = New List(Of Long)()
        Dim divisor = 2
        While number > 1
            While number Mod divisor = 0
                primes.Add(divisor)
                number /= divisor
            End While
            divisor += 1
        End While
        Return primes.ToArray()
    End Function
End Class
