Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim sut = New {{ testedClass }}({{ test.input.seconds }})
        Assert.Equal({{ test.expected | vb_double_literal }}, sut.On{{ test.input.planet }}(), precision:=2)
    End Sub
    {{ end -}}
End Class
