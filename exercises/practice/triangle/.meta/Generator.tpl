{{ func sides_literal
    literals = $0 | array.each @vb_double_literal
    ret (array.join literals ", ")
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Assert.{{ test.expected | vb_literal }}({{ testedClass }}.Is{{ test.testedMethod }}({{ test.input.sides | sides_literal }}))
    End Sub
    {{ end -}}
End Class
