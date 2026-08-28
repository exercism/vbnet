{{ func family_tree_entry
    ret "{" + (vb_string_literal $0) + ", " + (vb_literal $1) + "}"
end }}

{{ func expected_distance
    if $0 == null
        ret -1
    end

    ret $0
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim familyTree = New Dictionary(Of String, String()) From {
            {{- for person in test.input.familyTree | object.keys }}
            {{ family_tree_entry person test.input.familyTree[person] }}{{ if !for.last }},{{ end }}
            {{- end }}
        }
        Assert.Equal({{ test.expected | expected_distance }}, {{ testedClass }}.DegreesOfSeparation(familyTree, {{ test.input.personA | vb_string_literal }}, {{ test.input.personB | vb_string_literal }}))
    End Sub
    {{ end -}}
End Class
