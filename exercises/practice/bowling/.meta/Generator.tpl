{{ func rolls_literal
    if (array.size $0) == 0
        ret "System.Array.Empty(Of Integer)()"
    end

    ret (vb_literal $0)
end }}

{{ func error_call
    if $0.property == "roll"
        ret "Sub() sut.Roll(" + $0.input.roll + ")"
    end

    ret "Function() sut.Score()"
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim sut = New BowlingGame()
        Dim previousRolls = {{ test.input.previousRolls | rolls_literal }}
        For Each roll In previousRolls
            sut.Roll(roll)
        Next
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentException)({{ test | error_call }})
        {{- else }}
        Assert.Equal({{ test.expected }}, sut.Score())
        {{- end }}
    End Sub
    {{ end -}}
End Class
