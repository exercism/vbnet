Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim sut = New {{ testedClass }}({{ test.input.direction | enum "DirectionType" }}, {{ test.input.position.x }}, {{ test.input.position.y }})
        {{- if test.testedMethod == "Move" }}
        sut.{{ test.testedMethod }}({{ test.input.instructions | vb_string_literal }})
        {{- end }}
        Assert.Equal({{ test.expected.direction | enum "DirectionType" }}, sut.Direction)
        Assert.Equal({{ test.expected.position.x }}, sut.X)
        Assert.Equal({{ test.expected.position.y }}, sut.Y)
    End Sub
    {{ end -}}
End Class
