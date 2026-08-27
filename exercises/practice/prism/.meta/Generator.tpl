{{ func laser_literal
    x = vb_double_literal $0.x
    y = vb_double_literal $0.y
    angle = vb_double_literal $0.angle
    ret $"New LaserInfo({x}, {y}, {angle})"
end }}

{{ func prism_literal
    id = $0.id
    x = vb_double_literal $0.x
    y = vb_double_literal $0.y
    angle = vb_double_literal $0.angle
    ret $"New PrismInfo({id}, {x}, {y}, {angle})"
end }}

{{ func prisms_literal
    count = array.size $0
    if count == 0
        ret "Array.Empty(Of PrismInfo)()"
    end

    literals = $0 | array.each @prism_literal
    if count == 1
        ret "{" + literals[0] + "}"
    end

    item_indent = indent ($1 + 1)
    ret "{\n" + item_indent + (array.join literals (",\n" + item_indent)) + "\n" + (indent $1) + "}"
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim laser = {{ test.input.start | laser_literal }}
        Dim prisms = {{ test.input.prisms | prisms_literal 2 }}
        {{- if (array.size test.expected.sequence) == 0 }}
        Assert.Empty({{ testedClass }}.{{ test.testedMethod }}(laser, prisms))
        {{- else }}
        Dim expected = {{ test.expected.sequence | vb_multiline_array_literal 2 12 }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(laser, prisms))
        {{- end }}
    End Sub
    {{ end -}}
End Class
