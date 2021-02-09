Public Module Atbash
    Private Const codeStrip As String = "0123456789abcdefghijklmnopqrstuvwxyz9876543210"
    Private ReadOnly endOfCodeStrip As Integer = Len(codeStrip)
    
    Public Function Encode(arg As String) As String
        arg = arg.ToLower()
        Dim result As String = ""
        Dim cnt = 0
        For Each stringChar As String In arg
            Dim locationOfStringChar = codeStrip.IndexOf(stringChar)
            If locationOfStringChar <> -1 Then
                result &= codeStrip.Substring(endOfCodeStrip - locationOfStringChar - 1, 1)
                cnt += 1
                If cnt Mod 5 = 0 Then
                    result &= " "
                    cnt = 0
                End If
            End If
        Next
        Return result.Trim()
    End Function

    Public Function Decode(arg As String) As String
        Dim result As String = ""
        For Each stringChar As String In arg
            Dim locationOfStringChar = codeStrip.IndexOf(stringChar)
            If locationOfStringChar <> -1  Then
                result &= codeStrip.Substring(endOfCodeStrip - locationOfStringChar - 1, 1)
            End If
        Next
        Return result
    End Function
End Module
