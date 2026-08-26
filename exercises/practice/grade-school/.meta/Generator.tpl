Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim sut = New {{ testedClass }}()
        {{- if test.property == "add" }}
        {{ for i in 0..((array.size test.input.students) - 1) -}}
        {{ student = test.input.students[i] -}}
        {{ assertion = test.expected[i] ? "True" : "False" -}}
        Assert.{{ assertion }}(sut.Add({{ student[0] | vb_string_literal }}, {{ student[1] }}))
        {{ end -}}
        {{- else }}
        {{ for student in test.input.students -}}
        sut.Add({{ student[0] | vb_string_literal }}, {{ student[1] }})
        {{ end -}}
        {{ if (array.size test.expected) == 0 -}}
        Assert.Empty(sut.{{ test.testedMethod }}({{ test.input.desiredGrade }}))
        {{ else -}}
        Dim expected = {{ test.expected | vb_literal }}
        Assert.Equal(expected, sut.{{ test.testedMethod }}({{ test.input.desiredGrade }}))
        {{ end -}}
        {{ end -}}
    End Sub
    {{ end -}}
End Class
