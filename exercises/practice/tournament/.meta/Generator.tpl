Imports System.IO
Imports System.Text

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim rows = {{ test.input.rows | vb_string_join "vbLf" 2 }}
        Dim expected = {{ test.expected | vb_string_join "vbLf" 2 }}

        Assert.Equal(expected, RunTally(rows))
    End Sub
    {{ end }}
    Private Shared Function RunTally(ByVal input As String) As String
        Dim encoding = New UTF8Encoding()

        Using inputStream = New MemoryStream(encoding.GetBytes(input))
            Using outputStream = New MemoryStream()
                {{ testedClass }}.Tally(inputStream, outputStream)
                Return encoding.GetString(outputStream.ToArray())
            End Using
        End Using
    End Function
End Class
