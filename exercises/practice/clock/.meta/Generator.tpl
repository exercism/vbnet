{{ func clock
    ret $"New {testedClass}({$0.hour}, {$0.minute})"
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if test.property == "equal" }}
        Assert.{{ test.expected ? "Equal" : "NotEqual" }}({{ test.input.clock1 | clock }}, {{ test.input.clock2 | clock }})
        {{- else }}
        Dim sut = {{ test.input | clock }}
        {{- if test.property == "create" }}
        Assert.Equal({{ test.expected | vb_string_literal }}, sut.ToString())
        {{- else }}
        Assert.Equal({{ test.expected | vb_string_literal }}, sut.{{ test.testedMethod }}({{ test.input.value }}).ToString())
        {{- end }}
        {{- end }}
    End Sub
    {{ end -}}

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Clocks_are_immutable()
        Dim sut = New {{ testedClass }}(0, 0)
        Dim before = sut.ToString()
        sut.Add(1)
        Assert.Equal(before, sut.ToString())
    End Sub
End Class
