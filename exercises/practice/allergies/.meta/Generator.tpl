Public Class {{ testClass }}
    {{- for test in tests | property "allergicTo" }}
    <Fact{{ if !for.first }}(Skip:="Remove this Skip property to run this test"){{ end }}>
    Public Sub {{ test.testMethod }}()
        Dim allergies = New {{ testedClass }}({{ test.input.score }})
        Assert.[{{ test.expected | vb_literal }}](allergies.{{ test.testedMethod }}({{ test.input.item | vb_string_literal }}))
    End Sub
    {{ end }}

    {{- for test in tests | property "list" }}
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub {{ test.testMethod }}()
        Dim allergies = New {{ testedClass }}({{ test.input.score }})
        {{- if (array.size test.expected) == 0 }}
        Assert.Empty(allergies.{{ test.testedMethod }}())
        {{- else }}
        Dim expected As String() = {{ test.expected | vb_literal }}
        Assert.Equal(expected, allergies.{{ test.testedMethod }}())
        {{- end }}
    End Sub
    {{ end -}}
End Class
