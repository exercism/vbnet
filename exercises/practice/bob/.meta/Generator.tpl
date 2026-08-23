Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim sut = New {{ testedClass }}()
        Dim phrase = {{ test.input.heyBob | vb_string_literal }}
        Assert.Equal({{ test.expected | vb_string_literal }}, sut.Hey(phrase))
    End Sub
    {{ end -}}
End Class
