{{ func argument
    if (object.typeof $0) == "number"
        ret $"New BigInteger({$0})"
    end

    ret $"{testedClass}.{string.capitalize $0}"
end }}

Imports System.Numerics

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        {{- if test.property == "privateKeyIsInRange" }}
        Dim p = New BigInteger(7919)
        For i = 0 To 999
            Dim privateKey = {{ testedClass }}.PrivateKey(p)
            Assert.InRange(privateKey, New BigInteger(1), p)
        Next
        {{- else if test.property == "privateKeyIsRandom" }}
        Dim p = New BigInteger(7919)
        Dim privateKeys = Enumerable.Range(0, 1000).[Select](Function(__) {{ testedClass }}.PrivateKey(p)).ToArray()
        Assert.InRange(privateKeys.Distinct().Count(), privateKeys.Length - 100, privateKeys.Length)
        {{- else if test.property == "keyExchange" }}
        {{- for key in test.input | object.keys }}
        Dim {{ key }} = {{ test.input[key] | argument }}
        {{- end }}
        Assert.Equal(secretA, secretB)
        {{- else }}
        {{- for key in test.input | object.keys }}
        Dim {{ key }} = {{ test.input[key] | argument }}
        {{- end }}
        Assert.Equal({{ test.expected | argument }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input | object.keys | array.join ", " }}))
        {{- end }}
    End Sub
    {{ end -}}
End Class
