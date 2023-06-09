Imports Xunit

Public Class TwelveDaysTests
    <Fact>
    Public Sub First_day_a_partridge_in_a_pear_tree()
        Dim expected = "On the first day of Christmas my true love gave to me: a Partridge in a Pear Tree."
        Assert.Equal(expected, Recite(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Second_day_two_turtle_doves()
        Dim expected = "On the second day of Christmas my true love gave to me: two Turtle Doves, and a Partridge in a Pear Tree."
        Assert.Equal(expected, Recite(2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Third_day_three_french_hens()
        Dim expected = "On the third day of Christmas my true love gave to me: three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
        Assert.Equal(expected, Recite(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Fourth_day_four_calling_birds()
        Dim expected = "On the fourth day of Christmas my true love gave to me: four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
        Assert.Equal(expected, Recite(4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Fifth_day_five_gold_rings()
        Dim expected = "On the fifth day of Christmas my true love gave to me: five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
        Assert.Equal(expected, Recite(5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sixth_day_six_geese_a_laying()
        Dim expected = "On the sixth day of Christmas my true love gave to me: six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
        Assert.Equal(expected, Recite(6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Seventh_day_seven_swans_a_swimming()
        Dim expected = "On the seventh day of Christmas my true love gave to me: seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
        Assert.Equal(expected, Recite(7))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Eighth_day_eight_maids_a_milking()
        Dim expected = "On the eighth day of Christmas my true love gave to me: eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
        Assert.Equal(expected, Recite(8))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ninth_day_nine_ladies_dancing()
        Dim expected = "On the ninth day of Christmas my true love gave to me: nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
        Assert.Equal(expected, Recite(9))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Tenth_day_ten_lords_a_leaping()
        Dim expected = "On the tenth day of Christmas my true love gave to me: ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
        Assert.Equal(expected, Recite(10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Eleventh_day_eleven_pipers_piping()
        Dim expected = "On the eleventh day of Christmas my true love gave to me: eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
        Assert.Equal(expected, Recite(11))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Twelfth_day_twelve_drummers_drumming()
        Dim expected = "On the twelfth day of Christmas my true love gave to me: twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
        Assert.Equal(expected, Recite(12))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recites_first_three_verses_of_the_song()
        Dim expected = "On the first day of Christmas my true love gave to me: a Partridge in a Pear Tree." & vbLf & "On the second day of Christmas my true love gave to me: two Turtle Doves, and a Partridge in a Pear Tree." & vbLf & "On the third day of Christmas my true love gave to me: three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
        Assert.Equal(expected, Recite(1, 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recites_three_verses_from_the_middle_of_the_song()
        Dim expected = "On the fourth day of Christmas my true love gave to me: four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." & vbLf & "On the fifth day of Christmas my true love gave to me: five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." & vbLf & "On the sixth day of Christmas my true love gave to me: six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
        Assert.Equal(expected, Recite(4, 6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Recites_the_whole_song()
        Dim expected = "On the first day of Christmas my true love gave to me: a Partridge in a Pear Tree." & vbLf & "On the second day of Christmas my true love gave to me: two Turtle Doves, and a Partridge in a Pear Tree." & vbLf & "On the third day of Christmas my true love gave to me: three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." & vbLf & "On the fourth day of Christmas my true love gave to me: four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." & vbLf & "On the fifth day of Christmas my true love gave to me: five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." & vbLf & "On the sixth day of Christmas my true love gave to me: six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." & vbLf & "On the seventh day of Christmas my true love gave to me: seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." & vbLf & "On the eighth day of Christmas my true love gave to me: eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." & vbLf & "On the ninth day of Christmas my true love gave to me: nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." & vbLf & "On the tenth day of Christmas my true love gave to me: ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." & vbLf & "On the eleventh day of Christmas my true love gave to me: eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." & vbLf & "On the twelfth day of Christmas my true love gave to me: twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
        Assert.Equal(expected, Recite(1, 12))
    End Sub
End Class
