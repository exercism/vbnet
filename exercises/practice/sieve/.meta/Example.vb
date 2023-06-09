Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Class Sieve
    Public Shared Function Primes(ByVal limit As Integer) As Integer()
        Return Sieve.InitializePrimes(limit)
    End Function

    Private Shared Function InitializePrimes(ByVal limit As Integer) As Integer()
        If limit < 0 Then
            Throw New ArgumentOutOfRangeException(NameOf(limit))
        End If

        If limit = 0 OrElse limit = 1 Then Return Array.Empty(Of Integer)()
        Dim primes = New List(Of Integer)()

        Dim candidates = New Queue(Of Integer)(Enumerable.Range(2, limit - 1))
        Do
            Dim prime = candidates.Dequeue()
            primes.Add(prime)
            candidates = New Queue(Of Integer)(candidates.Where(Function(x) x Mod prime <> 0))
        Loop While candidates.Any()
        Return primes.ToArray()
    End Function
End Class
