Imports Xunit

Public Class HouseTests
    <Fact>
    Public Sub Verse_one_the_house_that_jack_built()
        Dim expected = "This is the house that Jack built."
        Assert.Equal(expected, Recite(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Verse_two_the_malt_that_lay()
        Dim expected = "This is the malt that lay in the house that Jack built."
        Assert.Equal(expected, Recite(2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Verse_three_the_rat_that_ate()
        Dim expected = "This is the rat that ate the malt that lay in the house that Jack built."
        Assert.Equal(expected, Recite(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Verse_four_the_cat_that_killed()
        Dim expected = "This is the cat that killed the rat that ate the malt that lay in the house that Jack built."
        Assert.Equal(expected, Recite(4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Verse_five_the_dog_that_worried()
        Dim expected = "This is the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."
        Assert.Equal(expected, Recite(5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Verse_six_the_cow_with_the_crumpled_horn()
        Dim expected = "This is the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."
        Assert.Equal(expected, Recite(6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Verse_seven_the_maiden_all_forlorn()
        Dim expected = "This is the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."
        Assert.Equal(expected, Recite(7))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Verse_eight_the_man_all_tattered_and_torn()
        Dim expected = "This is the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."
        Assert.Equal(expected, Recite(8))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Verse_nine_the_priest_all_shaven_and_shorn()
        Dim expected = "This is the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."
        Assert.Equal(expected, Recite(9))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Verse_10_the_rooster_that_crowed_in_the_morn()
        Dim expected = "This is the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."
        Assert.Equal(expected, Recite(10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Verse_11_the_farmer_sowing_his_corn()
        Dim expected = "This is the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."
        Assert.Equal(expected, Recite(11))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Verse_12_the_horse_and_the_hound_and_the_horn()
        Dim expected = "This is the horse and the hound and the horn that belonged to the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."
        Assert.Equal(expected, Recite(12))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_verses()
        Dim expected = "This is the cat that killed the rat that ate the malt that lay in the house that Jack built." & vbLf & "This is the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built." & vbLf & "This is the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built." & vbLf & "This is the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built." & vbLf & "This is the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."
        Assert.Equal(expected, Recite(4, 8))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_rhyme()
        Dim expected = "This is the house that Jack built." & vbLf & "This is the malt that lay in the house that Jack built." & vbLf & "This is the rat that ate the malt that lay in the house that Jack built." & vbLf & "This is the cat that killed the rat that ate the malt that lay in the house that Jack built." & vbLf & "This is the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built." & vbLf & "This is the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built." & vbLf & "This is the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built." & vbLf & "This is the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built." & vbLf & "This is the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built." & vbLf & "This is the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built." & vbLf & "This is the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built." & vbLf & "This is the horse and the hound and the horn that belonged to the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."
        Assert.Equal(expected, Recite(1, 12))
    End Sub
End Class
