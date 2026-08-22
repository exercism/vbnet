{{ func expected_value
    if $0 == null
        ret 0
    end

    ret $0
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim sut = New {{ testedClass }}({{ test.input.binary | vb_string_literal }})
        Assert.Equal({{ test.expected | expected_value }}, sut.To{{ test.testedMethod }}())
    End Sub
    {{ end -}}
End Class
