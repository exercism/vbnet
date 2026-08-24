Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim playerA = {{ test.input.playerA | vb_multiline_array_literal 2 12 }}
        Dim playerB = {{ test.input.playerB | vb_multiline_array_literal 2 12 }}
        Dim status = GameStatus.[{{ test.expected.status | pascalize }}]
        Dim tricks = {{ test.expected.tricks }}
        Dim cards = {{ test.expected.cards }}
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(playerA, playerB))
    End Sub
    {{ end -}}
End Class
