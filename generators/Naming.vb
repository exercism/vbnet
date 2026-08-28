Imports System.Text.RegularExpressions

Namespace Global.Exercism.VBNet.Generators
    Friend Module Naming
        Friend Function ToMethodName([property] As String) As String
            Return [property].Dehumanize()
        End Function

        Friend Function ToTestMethodName(ParamArray path As String()) As String
            Dim description = ExpandNegativeNumbers(String.Join(" ", path))
            Dim words = Regex.Split(description, "\W+").
                Where(Function(word) Not String.IsNullOrWhiteSpace(word)).
                Select(AddressOf Transform)

            Dim testMethodName = String.Join(" ", words).Underscore().Transform([To].SentenceCase)
            If Char.IsDigit(testMethodName(0)) Then
                Return $"_{testMethodName}"
            End If

            Return testMethodName
        End Function

        Private Function ExpandNegativeNumbers(value As String) As String
            Return Regex.Replace(value, "(?<!\w)-(?=\d)", " negative ")
        End Function

        Private Function Transform(word As String, index As Integer) As String
            Dim number As Integer

            If index = 0 AndAlso Integer.TryParse(word, number) Then
                Return number.ToWords()
            End If

            If index = 0 AndAlso Char.IsDigit(word(0)) Then
                Return word
            End If

            Return word.Dehumanize()
        End Function
    End Module
End Namespace
