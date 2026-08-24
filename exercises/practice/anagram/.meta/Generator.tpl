{{ func expected_literal
    if (object.typeof $0) == "array"
        if (array.size $0) == 0
            ret "Array.Empty(Of String)()"
        end

        ret (vb_literal (array.sort $0))
    end

    ret (vb_literal [$0])
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim detector = New {{ testedClass }}({{ test.input.subject | vb_string_literal }})
        Dim words = {{ test.input.candidates | vb_literal }}
        Dim expected = {{ test.expected | expected_literal }}
        Assert.Equal(expected, detector.Match(words))
    End Sub
    {{ end -}}
End Class
