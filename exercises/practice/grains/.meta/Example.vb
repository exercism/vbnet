Imports System

Public Module Grains
    Public Function Square(ByVal n As Integer) As ULong
        If n <= 0 OrElse n > 64 Then
            Throw New ArgumentOutOfRangeException(NameOf(n))
        End If

        Return If(n = 1, 1, 2 * Square(n - 1))
    End Function

    Public Function Total() As ULong
        Dim lTotal As ULong = 0

        For i = 1 To 64
            lTotal += Square(i)
        Next

        Return lTotal
    End Function
End Module
