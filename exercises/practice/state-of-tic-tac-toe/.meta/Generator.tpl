Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim board = {{ test.input.board | vb_multiline_array_literal 2 1 }}
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentException)(Function() {{ testedClass }}.{{ test.testedMethod }}(board))
        {{- else }}
        Assert.Equal(State.{{ test.expected | pascalize }}, {{ testedClass }}.{{ test.testedMethod }}(board))
        {{- end }}
    End Sub
    {{ end -}}
End Class
