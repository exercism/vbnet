Imports System

Public Module EliudsEggs
    Public Function EggCount(ByVal number As Integer) As Integer
        If number = 1 Then
            Return 0
        End If
        
        Dim count = 0
        While number > 0
            If (number And 1) = 1 Then
                count += 1
            End If
            
            number = number >> 1
        End While
        
        Return count
    End Function
End Module
