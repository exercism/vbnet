{{ func api_user
    ret {
        Name: $0.name,
        Owes: $0.owes,
        OwedBy: $0.owed_by,
        Balance: $0.balance
    }
end }}

{{ func api_json
    ret (string.replace (object.to_json $0) ".0" "")
end }}

{{ func users_json
    users = $0 | array.each @api_user
    ret (api_json users)
end }}

{{ func response_json
    if $0.users != null
        ret (users_json $0.users)
    end

    ret (api_json (api_user $0))
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim url = {{ test.input.url | vb_string_literal }}
        {{- if test.input.payload }}
        Dim payload = {{ test.input.payload | api_json | vb_string_literal }}
        {{- end }}
        Dim database = {{ test.input.database.users | users_json | vb_string_literal }}
        Dim sut = New {{ testedClass }}(database)
        {{- if test.testedMethod == "Get" }}
        Dim actual = sut.[Get](url{{ if test.input.payload }}, payload{{ end }})
        {{- else }}
        Dim actual = sut.{{ test.testedMethod }}(url, payload)
        {{- end }}
        Dim expected = {{ test.expected | response_json | vb_string_literal }}
        Assert.Equal(expected, actual)
    End Sub
    {{ end -}}
End Class
