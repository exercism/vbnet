Public Class {{ testClass }}
    {{- for test in tests }}
    <Fact{{ if !for.first }}(Skip:="Remove this Skip property to run this test"){{ end }}>
    Public Sub {{ test.testMethod }}()
        Dim digits As Integer() = {{ test.input.digits | vb_literal }}
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() {{ test.testedMethod }}({{ test.input.inputBase }}, digits, {{ test.input.outputBase }}))
        {{- else }}
        Dim expected As Integer() = {{ test.expected | vb_literal }}
        Assert.Equal(expected, {{ test.testedMethod }}({{ test.input.inputBase }}, digits, {{ test.input.outputBase }}))
        {{- end }}
    End Sub
    {{ end -}}
End Class
