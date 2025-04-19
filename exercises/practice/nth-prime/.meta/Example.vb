Imports System

Public Module NthPrime
    Public Function Prime(ByVal number As Integer)
        If number < 1 Then
            Throw New ArgumentOutOfRangeException(nameof(number), "There are no negative nth primes")
        End If

        Dim count = 0
        Dim candidate = 2

        While count < number
            If IsPrime(candidate) Then
                count += 1
                If count = number Then
                    Return candidate
                End If
            End If
            candidate += 1
        End While
    End Function

    Private Function IsPrime(ByVal num As Integer)
        If num <= 1 Then
            Return False
        End If
        If num = 2 Then
            Return True
        End If
        If num Mod 2 = 0 Then
            Return False
        End If

        Dim limit = Math.Floor(Math.Sqrt(num))

        For i = 3 To limit Step 2
            If num Mod i = 0 Then
                Return False
            End If
        Next

        Return True
    End Function
End Module
