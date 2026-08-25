Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        {{- if test.property == "ability" }}
        For i = 0 To 9
            Assert.InRange({{ testedClass }}.Ability(), 3, 18)
        Next
        {{- else if test.property == "character" && (test.scenarios | array.contains "random") }}
        For i = 0 To 9
            Dim sut = {{ testedClass }}.Generate()
            Assert.InRange(sut.Strength, 3, 18)
            Assert.InRange(sut.Dexterity, 3, 18)
            Assert.InRange(sut.Constitution, 3, 18)
            Assert.InRange(sut.Intelligence, 3, 18)
            Assert.InRange(sut.Wisdom, 3, 18)
            Assert.InRange(sut.Charisma, 3, 18)
            Assert.Equal(10 + {{ testedClass }}.Modifier(sut.Constitution), sut.Hitpoints)
        Next
        {{- else if test.property == "character" }}
        For i = 0 To 9
            Dim sut = {{ testedClass }}.Generate()
            Assert.Equal(sut.Strength, sut.Strength)
            Assert.Equal(sut.Dexterity, sut.Dexterity)
            Assert.Equal(sut.Constitution, sut.Constitution)
            Assert.Equal(sut.Intelligence, sut.Intelligence)
            Assert.Equal(sut.Wisdom, sut.Wisdom)
            Assert.Equal(sut.Charisma, sut.Charisma)
        Next
        {{- else }}
        Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.score }}))
        {{- end }}
    End Sub
    {{ end }}
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Random_ability_is_distributed_correctly()
        Dim abilities = Enumerable.Range(1, 10000).Select(Function(roll) {{ testedClass }}.Ability()).ToArray()
        Assert.All(abilities, Sub(ability) Assert.InRange(ability, 3, 18))

        Dim average = abilities.Average()
        Assert.InRange(average, 11.84, 12.64)
    End Sub
End Class
