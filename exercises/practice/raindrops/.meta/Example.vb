Public Module Raindrops
    Public Function Convert(ByVal number As Integer) As String
        Dim result = ""
        If number Mod 3 = 0 Then result += "Pling"
        If number Mod 5 = 0 Then result += "Plang"
        If number Mod 7 = 0 Then result += "Plong"
        If String.IsNullOrEmpty(result) Then result = number.ToString()
        Return result
    End Function
End Module
