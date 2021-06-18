Imports XUnit


Public Class AllergiesTest
    <Fact>
    Public Sub NoAllergiesMeansNotAllergic()
        Dim allergies = New Allergies(0)
        Assert.That(allergies.AllergicTo("peanuts"), [Is].[False])
        Assert.That(allergies.AllergicTo("cats"), [Is].[False])
        Assert.That(allergies.AllergicTo("strawberries"), [Is].[False])
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub AllergicToEggs()
        Dim allergies = New Allergies(1)
        Assert.That(allergies.AllergicTo("eggs"), [Is].[True])
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub AllergicToEggsInAdditionToOtherStuff()
        Dim allergies = New Allergies(5)
        Assert.That(allergies.AllergicTo("eggs"), [Is].[True])
        Assert.That(allergies.AllergicTo("shellfish"), [Is].[True])
        Assert.That(allergies.AllergicTo("strawberries"), [Is].[False])
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub NoAllergiesAtAll()
        Dim allergies = New Allergies(0)
        Assert.That(allergies.List(), [Is].Empty)
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub AllergicToJustEggs()
        Dim allergies = New Allergies(1)
        Assert.That(allergies.List(), [Is].EqualTo(New List(Of String) From {
            "eggs"
        }))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub AllergicToJustPeanuts()
        Dim allergies = New Allergies(2)
        Assert.That(allergies.List(), [Is].EqualTo(New List(Of String) From {
            "peanuts"
        }))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub AllergicToEggsAndPeanuts()
        Dim allergies = New Allergies(3)
        Assert.That(allergies.List(), [Is].EqualTo(New List(Of String) From {
            "eggs",
            "peanuts"
        }))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub AllergicToLotsOfStuff()
        Dim allergies = New Allergies(248)
        Assert.That(allergies.List(), [Is].EqualTo(New List(Of String)() From { _
            "strawberries", _
            "tomatoes", _
            "chocolate", _
            "pollen", _
            "cats" _
        }))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub AllergicToEverything()
        Dim allergies = New Allergies(255)
        Assert.That(allergies.List(), [Is].EqualTo(New List(Of String)() From { _
            "eggs", _
            "peanuts", _
            "shellfish", _
            "strawberries", _
            "tomatoes", _
            "chocolate", _
            "pollen", _
            "cats" _
        }))
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub IgnoreNonAllergenScoreParts()
        Dim allergies = New Allergies(509)
        Assert.That(allergies.List(), [Is].EqualTo(New List(Of String)() From { _
            "eggs", _
            "shellfish", _
            "strawberries", _
            "tomatoes", _
            "chocolate", _
            "pollen", _
            "cats" _
        }))
    End Sub
End Class
