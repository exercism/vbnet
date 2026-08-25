Public Module LineUp
    Public Function Format(ByVal name As String, ByVal number As Integer) As String
        Return $"{name}, you are the {number}{Suffix(number)} customer we serve today. Thank you!"
    End Function

    Private Function Suffix(ByVal number As Integer) As String
        Dim lastTwoDigits = number Mod 100

        If lastTwoDigits >= 11 AndAlso lastTwoDigits <= 13 Then
            Return "th"
        End If

        Select Case number Mod 10
            Case 1
                Return "st"
            Case 2
                Return "nd"
            Case 3
                Return "rd"
            Case Else
                Return "th"
        End Select
    End Function
End Module
