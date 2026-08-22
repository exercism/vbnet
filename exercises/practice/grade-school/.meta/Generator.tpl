Public Class {{ testClass }}
    {{- for test in tests }}
    <Fact{{ if !for.first }}(Skip:="Remove this Skip property to run this test"){{ end }}>
    Public Sub {{ test.testMethod }}()
        Dim sut = New GradeSchool()
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
        Dim actual = sut.{{ test.testedMethod }}({{ test.input.desiredGrade }})
        Dim expected = {{ test.expected | vb_literal }}
        Assert.Equal(expected, actual)
        {{ end -}}
        {{ end -}}
    End Sub
    {{ end -}}
End Class
