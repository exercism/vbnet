{{ func accumulator
    case $0
        when '(x) => x * x'
            ret 'Function(x) x * x'
        when '(x) => upcase(x)'
            ret 'Function(x) x.ToUpper()'
        when '(x) => reverse(x)'
            ret 'Function(x) New String(x.Reverse().ToArray())'
        when '(x) => accumulate(["1", "2", "3"], (y) => x + y)'
            ret 'Function(x) String.Join(" ", New String() {"1", "2", "3"}.Accumulate(Function(y) x & y))'
        else
            ret $0
    end
end }}

{{ func array_type
    ret (object.typeof (array.first $0)) == "string" ? "String()" : "Integer()"
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    <Fact{{ if !for.first }}(Skip:="Remove this Skip property to run this test"){{ end }}>
    Public Sub {{ test.testMethod }}()
        Dim input As {{ test.input.list | array_type }} = {{ test.input.list | vb_literal }}
        {{- if (object.typeof (array.first test.expected)) == "array" }}
        Dim expected As {{ test.input.list | array_type }} = {
            {{~ for row in test.expected ~}}
            {{ row | array.join " " | vb_string_literal }}{{ if !for.last }},{{ end }}
            {{~ end ~}}
        }
        {{- else }}
        Dim expected As {{ test.expected | array_type }} = {{ test.expected | vb_literal }}
        {{- end }}
        Assert.Equal(expected, input.{{ test.testedMethod }}({{ test.input.accumulator | accumulator }}))
    End Sub
    {{ end ~}}

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Accumulate_is_lazy()
        Dim counter = 0
        Dim accumulation = New Integer() {1, 2, 3}.Accumulate(
            Function(x)
                counter += 1
                Return x
            End Function)

        Assert.Equal(0, counter)
        accumulation.ToList()
        Assert.Equal(3, counter)
    End Sub
End Class
