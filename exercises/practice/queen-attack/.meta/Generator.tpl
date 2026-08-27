Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if test.testedMethod == "Create" }}
        {{- position = test.input.queen.position }}
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() {{ testedClass }}.{{ test.testedMethod }}({{ position.row }}, {{ position.column }}))
        {{- else }}
        Assert.NotNull({{ testedClass }}.{{ test.testedMethod }}({{ position.row }}, {{ position.column }}))
        {{- end }}
        {{- else }}
        Dim whiteQueen = {{ testedClass }}.Create({{ test.input.white_queen.position.row }}, {{ test.input.white_queen.position.column }})
        Dim blackQueen = {{ testedClass }}.Create({{ test.input.black_queen.position.row }}, {{ test.input.black_queen.position.column }})
        Assert.{{ test.expected | vb_literal }}({{ testedClass }}.{{ test.testedMethod }}(whiteQueen, blackQueen))
        {{- end }}
    End Sub
    {{ end -}}
End Class
