Public Class {{ testClass }}
    {{- for test in tests }}
    <Fact{{ if !for.first }}(Skip:="Remove this Skip property to run this test"){{ end }}>
    Public Sub {{ test.testMethod }}()
        Assert.[{{ test.expected | vb_literal }}]({{ testedClass }}.{{ test.testedMethod }}({{ test.input.number }}))
    End Sub
    {{ end -}}
End Class
