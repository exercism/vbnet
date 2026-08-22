Public Class {{ testClass }}
    {{- for test in tests }}
    <Fact{{ if !for.first }}(Skip:="Remove this Skip property to run this test"){{ end }}>
    Public Sub {{ test.testMethod }}()
        Assert.Equal({{ test.expected | vb_string_literal }}, {{ test.testedMethod }}({{ test.input.phrase | vb_string_literal }}))
    End Sub
    {{ end -}}
End Class
