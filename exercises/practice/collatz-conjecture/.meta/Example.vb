Imports System

Public Module CollatzConjecture
    Private stepCount As Integer

    Private Sub Collatz(ByVal number As Integer)
        If number Mod 2 = 0 Then
            stepCount += 1
            Collatz(number / 2)
        Else

            If number > 1 Then
                stepCount += 1
                Collatz(number * 3 + 1)
            End If
        End If
    End Sub

    Public Function Steps(ByVal number As Integer) As Integer
        If number <= 0 Then
            Throw New ArgumentOutOfRangeException()
        End If

        stepCount = 0
        Collatz(number)
        Return stepCount
    End Function
End Module