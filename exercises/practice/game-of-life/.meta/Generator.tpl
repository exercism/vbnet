Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim matrix = {{ test.input.matrix | vb_nested_list_literal "Integer" 2 }}
        Dim sut = New {{ testedClass }}(matrix)
        sut.{{ test.testedMethod }}()
        Dim expected = {{ test.expected | vb_nested_list_literal "Integer" 2 }}
        Assert.Equal(expected, sut.Matrix())
    End Sub
    {{ end -}}
End Class
