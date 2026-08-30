Public Class ZebraPuzzleTests
    <Fact>
    Public Sub Resident_who_drinks_water()
        Assert.Equal(Nationality.Norwegian, ZebraPuzzle.DrinksWater())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Resident_who_owns_zebra()
        Assert.Equal(Nationality.Japanese, ZebraPuzzle.OwnsZebra())
    End Sub
End Class
