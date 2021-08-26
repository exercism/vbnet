Public Module Leap
    Public Function IsLeapYear(ByVal year As Integer) As Boolean
        Return year Mod 400 = 0 OrElse (year Mod 100 <> 0 AndAlso year Mod 4 = 0)
    End Function
End Module