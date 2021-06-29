Public Module Leap
    Public Function IsLeapYear(ByVal year As Integer) As Boolean
        Return year % 400 = 0 OrElse (year % 100 <> 0 AndAlso year % 4 = 0)
    End Function
End Module