Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim scores = {{ test.input.scores | vb_multiline_array_literal 2 4 }}.ToList()
        Dim sut = New {{ testedClass }}(scores)
        {{- if test.property == "latestAfterTopThree" }}
        sut.PersonalTopThree()
        Assert.Equal({{ test.expected }}, sut.Latest())
        {{- else if test.property == "scoresAfterTopThree" }}
        sut.PersonalTopThree()
        Dim expected = {{ test.expected | vb_multiline_array_literal 2 4 }}.ToList()
        Assert.Equal(expected, sut.Scores())
        {{- else if test.property == "latestAfterBest" }}
        sut.PersonalBest()
        Assert.Equal({{ test.expected }}, sut.Latest())
        {{- else if test.property == "scoresAfterBest" }}
        sut.PersonalBest()
        Dim expected = {{ test.expected | vb_multiline_array_literal 2 4 }}.ToList()
        Assert.Equal(expected, sut.Scores())
        {{- else if (object.typeof test.expected) == "array" }}
        Dim expected = {{ test.expected | vb_multiline_array_literal 2 4 }}.ToList()
        Assert.Equal(expected, sut.{{ test.testedMethod }}())
        {{- else }}
        Assert.Equal({{ test.expected }}, sut.{{ test.testedMethod }}())
        {{- end }}
    End Sub
    {{ end -}}
End Class
