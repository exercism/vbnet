Public Class RaindropsTests
    <Fact>
    Public Sub The_sound_for_1_is_1()
        Assert.Equal("1", Raindrops.Convert(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_sound_for_3_is_pling()
        Assert.Equal("Pling", Raindrops.Convert(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_sound_for_5_is_plang()
        Assert.Equal("Plang", Raindrops.Convert(5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_sound_for_7_is_plong()
        Assert.Equal("Plong", Raindrops.Convert(7))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_sound_for_6_is_pling_as_it_has_a_factor_3()
        Assert.Equal("Pling", Raindrops.Convert(6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_to_the_power_3_does_not_make_a_raindrop_sound_as_3_is_the_exponent_not_the_base()
        Assert.Equal("8", Raindrops.Convert(8))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_sound_for_9_is_pling_as_it_has_a_factor_3()
        Assert.Equal("Pling", Raindrops.Convert(9))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_sound_for_10_is_plang_as_it_has_a_factor_5()
        Assert.Equal("Plang", Raindrops.Convert(10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_sound_for_14_is_plong_as_it_has_a_factor_of_7()
        Assert.Equal("Plong", Raindrops.Convert(14))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_sound_for_15_is_pling_plang_as_it_has_factors_3_and_5()
        Assert.Equal("PlingPlang", Raindrops.Convert(15))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_sound_for_21_is_pling_plong_as_it_has_factors_3_and_7()
        Assert.Equal("PlingPlong", Raindrops.Convert(21))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_sound_for_25_is_plang_as_it_has_a_factor_5()
        Assert.Equal("Plang", Raindrops.Convert(25))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_sound_for_27_is_pling_as_it_has_a_factor_3()
        Assert.Equal("Pling", Raindrops.Convert(27))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_sound_for_35_is_plang_plong_as_it_has_factors_5_and_7()
        Assert.Equal("PlangPlong", Raindrops.Convert(35))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_sound_for_49_is_plong_as_it_has_a_factor_7()
        Assert.Equal("Plong", Raindrops.Convert(49))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_sound_for_52_is_52()
        Assert.Equal("52", Raindrops.Convert(52))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_sound_for_105_is_pling_plang_plong_as_it_has_factors_3_5_and_7()
        Assert.Equal("PlingPlangPlong", Raindrops.Convert(105))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_sound_for_3125_is_plang_as_it_has_a_factor_5()
        Assert.Equal("Plang", Raindrops.Convert(3125))
    End Sub
End Class
