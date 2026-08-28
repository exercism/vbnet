Namespace Global.Exercism.VBNet.Generators
    Public Class NamingTests
        <Fact>
        Public Sub Test_method_name_preserves_negative_numeric_sign()
            Const description = "ability modifier for score 3 is -4"

            Assert.Equal("Ability_modifier_for_score_3_is_negative_4", Naming.ToTestMethodName(description))
        End Sub

        <Fact>
        Public Sub Test_method_name_does_not_treat_hyphenated_words_as_negative_numbers()
            Const description = "non-exceptional ordinal numeral 4"

            Assert.Equal("Non_exceptional_ordinal_numeral_4", Naming.ToTestMethodName(description))
        End Sub

        <Fact>
        Public Sub Test_method_name_preserves_a_digit_prefixed_word()
            Const description = "1x1 square is counted"

            Assert.Equal("1x1_square_is_counted", Naming.ToTestMethodName(description))
        End Sub
    End Class
End Namespace
