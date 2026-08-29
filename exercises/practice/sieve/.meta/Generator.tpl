Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if (array.size test.expected) == 0 }}
        Assert.Empty({{ testedClass }}.{{ test.testedMethod }}({{ test.input.limit }}))
        {{- else }}
        Dim expected = {{ test.expected | vb_multiline_array_literal 2 14 }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.limit }}))
        {{- end }}
    End Sub
    {{ end }}
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub No_negative_numbers()
        Assert.Throws(Of ArgumentOutOfRangeException)(Function() {{ testedClass }}.Primes(-1))
    End Sub
End Class
