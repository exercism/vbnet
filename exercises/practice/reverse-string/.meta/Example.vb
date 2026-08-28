Public Module ReverseString
    Public Function Reverse(ByVal inputString As String) As String
        Dim elements = New List(Of String)()
        Dim enumerator = Globalization.StringInfo.GetTextElementEnumerator(inputString)

        While enumerator.MoveNext()
            elements.Add(enumerator.GetTextElement())
        End While

        elements.Reverse()
        Return String.Concat(elements)
    End Function
End Module
