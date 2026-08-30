Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim sut = New {{ testedClass }}({{ test.input.bucketOne }}, {{ test.input.bucketTwo }}, {{ test.input.startBucket | enum "Bucket" }})
        {{- if test.expected.error }}
        Assert.Throws(Of ArgumentException)(Function() sut.Measure({{ test.input.goal }}))
        {{- else }}
        Dim actual = sut.Measure({{ test.input.goal }})

        Assert.Equal({{ test.expected.moves }}, actual.Moves)
        Assert.Equal({{ test.expected.otherBucket }}, actual.OtherBucket)
        Assert.Equal({{ test.expected.goalBucket | enum "Bucket" }}, actual.GoalBucket)
        {{- end }}
    End Sub
    {{ end -}}
End Class
