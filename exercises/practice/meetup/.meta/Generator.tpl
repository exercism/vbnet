{{ func date_literal
    parts = string.split $0 "-"
    ret $"New Date({parts[0]}, {parts[1]}, {parts[2]})"
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim sut = New {{ testedClass }}({{ test.input.month }}, {{ test.input.year }})
        Dim expected = {{ test.expected | date_literal }}
        Assert.Equal(expected, sut.Day({{ test.input.dayofweek | enum "DayOfWeek" }}, {{ test.input.week | enum "Schedule" }}))
    End Sub
    {{ end -}}
End Class
