Imports XUnit

Public Class AllergiesTest
    <Fact>
    Public Sub NotAllergicToAnythingEggs()
        Dim allergies = New Allergies(0)
        Assert.False(allergies.AllergicTo("eggs"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicOnlyToEggs()
        Dim allergies = New Allergies(1)
        Assert.True(allergies.AllergicTo("eggs"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToEggsAndSomethingElse()
        Dim allergies = New Allergies(3)
        Assert.True(allergies.AllergicTo("eggs"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToSomethingButNotEggs()
        Dim allergies = New Allergies(2)
        Assert.False(allergies.AllergicTo("eggs"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToEverythingEggs()
        Dim allergies = New Allergies(255)
        Assert.True(allergies.AllergicTo("eggs"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub NotAllergicToAnythingPeanuts()
        Dim allergies = New Allergies(0)
        Assert.False(allergies.AllergicTo("peanuts"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicOnlyToPeanuts()
        Dim allergies = New Allergies(2)
        Assert.True(allergies.AllergicTo("peanuts"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToPeanutsAndSomethingElse()
        Dim allergies = New Allergies(7)
        Assert.True(allergies.AllergicTo("peanuts"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToSomethingButNotPeanuts()
        Dim allergies = New Allergies(5)
        Assert.False(allergies.AllergicTo("peanuts"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToEverythingPeanuts()
        Dim allergies = New Allergies(255)
        Assert.True(allergies.AllergicTo("peanuts"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub NotAllergicToAnythingShellfish()
        Dim allergies = New Allergies(0)
        Assert.False(allergies.AllergicTo("shellfish"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicOnlyToShellfish()
        Dim allergies = New Allergies(4)
        Assert.True(allergies.AllergicTo("shellfish"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToShellfishAndSomethingElse()
        Dim allergies = New Allergies(14)
        Assert.True(allergies.AllergicTo("shellfish"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToSomethingButNotShellfish()
        Dim allergies = New Allergies(10)
        Assert.False(allergies.AllergicTo("shellfish"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToEverythingShellfish()
        Dim allergies = New Allergies(255)
        Assert.True(allergies.AllergicTo("shellfish"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub NotAllergicToAnythingStrawberries()
        Dim allergies = New Allergies(0)
        Assert.False(allergies.AllergicTo("strawberries"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicOnlyToStrawberries()
        Dim allergies = New Allergies(8)
        Assert.True(allergies.AllergicTo("strawberries"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToStrawberriesAndSomethingElse()
        Dim allergies = New Allergies(28)
        Assert.True(allergies.AllergicTo("strawberries"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToSomethingButNotStrawberries()
        Dim allergies = New Allergies(20)
        Assert.False(allergies.AllergicTo("strawberries"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToEverythingStrawberries()
        Dim allergies = New Allergies(255)
        Assert.True(allergies.AllergicTo("strawberries"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub NotAllergicToAnythingTomatoes()
        Dim allergies = New Allergies(0)
        Assert.False(allergies.AllergicTo("tomatoes"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicOnlyToTomatoes()
        Dim allergies = New Allergies(16)
        Assert.True(allergies.AllergicTo("tomatoes"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToTomatoesAndSomethingElse()
        Dim allergies = New Allergies(56)
        Assert.True(allergies.AllergicTo("tomatoes"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToSomethingButNotTomatoes()
        Dim allergies = New Allergies(40)
        Assert.False(allergies.AllergicTo("tomatoes"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToEverythingTomatoes()
        Dim allergies = New Allergies(255)
        Assert.True(allergies.AllergicTo("tomatoes"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub NotAllergicToAnythingChocolate()
        Dim allergies = New Allergies(0)
        Assert.False(allergies.AllergicTo("chocolate"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicOnlyToChocolate()
        Dim allergies = New Allergies(32)
        Assert.True(allergies.AllergicTo("chocolate"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToChocolateAndSomethingElse()
        Dim allergies = New Allergies(112)
        Assert.True(allergies.AllergicTo("chocolate"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToSomethingButNotChocolate()
        Dim allergies = New Allergies(80)
        Assert.False(allergies.AllergicTo("chocolate"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToEverythingChocolate()
        Dim allergies = New Allergies(255)
        Assert.True(allergies.AllergicTo("chocolate"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub NotAllergicToAnythingPollen()
        Dim allergies = New Allergies(0)
        Assert.False(allergies.AllergicTo("pollen"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicOnlyToPollen()
        Dim allergies = New Allergies(64)
        Assert.True(allergies.AllergicTo("pollen"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToPollenAndSomethingElse()
        Dim allergies = New Allergies(224)
        Assert.True(allergies.AllergicTo("pollen"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToSomethingButNotPollen()
        Dim allergies = New Allergies(160)
        Assert.False(allergies.AllergicTo("pollen"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToEverythingPollen()
        Dim allergies = New Allergies(255)
        Assert.True(allergies.AllergicTo("pollen"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub NotAllergicToAnythingCats()
        Dim allergies = New Allergies(0)
        Assert.False(allergies.AllergicTo("cats"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicOnlyToCats()
        Dim allergies = New Allergies(128)
        Assert.True(allergies.AllergicTo("cats"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToCatsAndSomethingElse()
        Dim allergies = New Allergies(192)
        Assert.True(allergies.AllergicTo("cats"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToSomethingButNotCats()
        Dim allergies = New Allergies(64)
        Assert.False(allergies.AllergicTo("cats"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToEverythingCats()
        Dim allergies = New Allergies(255)
        Assert.True(allergies.AllergicTo("cats"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub NoAllergies()
        Dim allergies = New Allergies(0)
        Dim expected = New List(Of String)
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub JustEggs()
        Dim allergies = New Allergies(1)
        Dim expected = New List(Of String) From {
            "eggs"
        }
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub JustPeanuts()
        Dim allergies = New Allergies(2)
        Dim expected = New List(Of String) From {
            "peanuts"
        }
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub JustStrawberries()
        Dim allergies = New Allergies(8)
        Dim expected = New List(Of String) From {
            "strawberries"
        }
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub EggsAndPeanuts()
        Dim allergies = New Allergies(3)
        Dim expected = New List(Of String) From {
            "eggs",
            "peanuts"
        }
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub MoreThanEggsButNotPeanuts()
        Dim allergies = New Allergies(5)
        Dim expected = New List(Of String) From {
            "eggs",
            "shellfish"
        }
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub LotsOfStuff()
        Dim allergies = New Allergies(248)
        Dim expected = New List(Of String) From {
            "strawberries",
            "tomatoes",
            "chocolate",
            "pollen",
            "cats"
        }
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Everything()
        Dim allergies = New Allergies(255)
        Dim expected = New List(Of String) From {
            "eggs",
            "peanuts",
            "shellfish",
            "strawberries",
            "tomatoes",
            "chocolate",
            "pollen",
            "cats"
        }
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub NoAllergenScoreParts()
        Dim allergies = New Allergies(509)
        Dim expected = New List(Of String) From {
            "eggs",
            "shellfish",
            "strawberries",
            "tomatoes",
            "chocolate",
            "pollen",
            "cats"
        }
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub NoAllergenScorePartsWithoutHighestValidScore()
        Dim allergies = New Allergies(257)
        Dim expected = New List(Of String) From {
            "eggs"
        }
        Assert.Equal(expected, allergies.List())
    End Sub
End Class
