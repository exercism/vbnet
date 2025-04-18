Imports System

Public Module SquareRoot
    Public Function SquareRoot(ByVal radicand As Integer)
        If radicand = 1 Then
            Return 1
        End If

        Dim guess = Math.Floor(radicand / 2)

        Dim found = False
        for i = 0 to 10
            If radicand = guess * guess Then
                found = True
                Exit For
            End If

            guess = Math.Floor((guess + radicand / guess) / 2)
        Next

        if found Then
            Return guess
        End if

        Return Nothing
    End Function
End Module
