Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Module NthPrime
    Public Function Prime(ByVal nth As Integer) As Integer
        If nth < 1 Then Throw New ArgumentOutOfRangeException()

        Return Primes().Skip(nth - 1).First()
    End Function

    Private Iterator Function Primes() As IEnumerable(Of Integer)
        Yield 2
        Yield 3

        For Each prime In PossiblePrimes().Where(New Func(Of Integer, Boolean)(AddressOf IsPrime))
            Yield prime
        Next
    End Function

    Private Iterator Function PossiblePrimes() As IEnumerable(Of Integer)
        Dim n = 6

        While True
            Yield n - 1
            Yield n + 1

            n += 6
        End While
    End Function

    Private Function IsPrime(ByVal n As Integer) As Boolean
        Dim r = CInt(Math.Floor(Math.Sqrt(n)))

        Return r < 5 OrElse Enumerable.Range(5, r - 4).All(Function(x) n Mod x <> 0)
    End Function
End Module
