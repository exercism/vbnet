{{ func count_entry
    ret "{" + (vb_string_literal $0) + "c, " + $1 + "}"
end }}

{{ func text_literal
    lines = string.split $0 "\n"
    if (array.size lines) == 1
        ret (vb_string_literal $0)
    end
~}}
String.Join(vbLf, {
{{~ for line in lines ~}}
{{ indent ($1 + 1) }}{{ line | vb_string_literal }}{{ if !for.last }},{{ end }}
{{~ end ~}}
{{ indent $1 }}})
{{~ end }}

{{ func texts_literal
    has_multiline_text = false
    for text in $0
        if string.contains text "\n"
            has_multiline_text = true
        end
    end

    if !has_multiline_text
        ret (vb_string_array_literal $0 $1 1)
    end
~}}
{
{{~ for text in $0 ~}}
{{ indent ($1 + 1) }}{{ text_literal text ($1 + 1) }}{{ if !for.last }},{{ end }}
{{~ end ~}}
{{ indent $1 }}
}
{{~ end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim texts = {{ test.input.texts | texts_literal 2 }}
        {{- keys = test.expected | object.keys }}
        {{- if (array.size keys) == 0 }}
        Dim expected = New Dictionary(Of Char, Integer)()
        {{- else }}
        Dim expected = New Dictionary(Of Char, Integer) From {
            {{- for key in keys }}
            {{ count_entry key test.expected[key] }}{{ if !for.last }},{{ end }}
            {{- end }}
        }
        {{- end }}
        Assert.Equal(expected, {{ testedClass }}.Calculate(texts))
    End Sub
    {{ end -}}
End Class
