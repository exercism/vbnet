Imports System

Public Module ArmstrongNumbers
    Public Function IsArmstrongNumber(ByVal number As Integer) As Boolean
        Dim numString = number.ToString()
        Dim length = numString.Length

        Dim total As Double = 0
        For i = 0 To length - 1
            total += Math.Pow(Integer.Parse(numString(i).ToString()), length)
        Next

        Return number = CInt(total)
    End Function
End Module
