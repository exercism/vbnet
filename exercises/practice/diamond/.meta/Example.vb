Imports System

Public Module Diamond
    Public Function Rows(ByVal letter As String) As String
        If letter = "A" Then
            Return "A"
        End If
        
        Dim startLetter = Asc("A")
        Dim endLetter = Asc(letter)
        Dim size = endLetter - startLetter + 1
        Dim diamond As New List(Of String)()
        
        For i = 0 To size - 1
            Dim outerSpaces = New String(" ", size - 1 - i)
            Dim current = Chr(startLetter + i)
            Dim line as String
            
            If i > 0 Then
                Dim innerSpaces = New String(" ", 2 * i - 1)
                line = outerSpaces & current & innerSpaces & current & outerSpaces
            Else
                line = outerSpaces & current & outerSpaces
            End if
            diamond.Add(line)
        Next
        
        For i = size - 2 To 0 Step -1
            diamond.Add(diamond(i))
        Next

        Return String.Join(vbCrLf, diamond)
    End Function
End Module
