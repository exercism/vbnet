
Public Module Gigasecond
    Public Function Add(ByVal moment As Date) As Date
        Return moment.AddSeconds(1000000000)
    End Function
End Module
