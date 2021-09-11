Imports XUnit


Public Class AllergiesTest
    <Fact>
    Public Sub NoAllergiesMeansNotAllergic()
        Dim allergies = New Allergies(0)
        Assert.Equal(allergies.AllergicTo("peanuts"), False)
        Assert.Equal(allergies.AllergicTo("cats"), False)
        Assert.Equal(allergies.AllergicTo("strawberries"), False)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToEggs()
        Dim allergies = New Allergies(1)
        Assert.Equal(allergies.AllergicTo("eggs"), True)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToEggsInAdditionToOtherStuff()
        Dim allergies = New Allergies(5)
        Assert.Equal(allergies.AllergicTo("eggs"), True)
        Assert.Equal(allergies.AllergicTo("shellfish"), True)
        Assert.Equal(allergies.AllergicTo("strawberries"), False)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub NoAllergiesAtAll()
        Dim allergies = New Allergies(0)
        Assert.Equal(allergies.List().Count, 0)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToJustEggs()
        Dim allergies = New Allergies(1)
        Assert.Equal(allergies.List(), New List(Of String) From {
            "eggs"
        })
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToJustPeanuts()
        Dim allergies = New Allergies(2)
        Assert.Equal(allergies.List(), New List(Of String) From {
            "peanuts"
        })
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToEggsAndPeanuts()
        Dim allergies = New Allergies(3)
        Assert.Equal(allergies.List(), New List(Of String) From {
            "eggs",
            "peanuts"
        })
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToLotsOfStuff()
        Dim allergies = New Allergies(248)
        Assert.Equal(allergies.List(), New List(Of String)() From { _
            "strawberries", _
            "tomatoes", _
            "chocolate", _
            "pollen", _
            "cats" _
        })
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub AllergicToEverything()
        Dim allergies = New Allergies(255)
        Assert.Equal(allergies.List(), New List(Of String)() From { _
            "eggs", _
            "peanuts", _
            "shellfish", _
            "strawberries", _
            "tomatoes", _
            "chocolate", _
            "pollen", _
            "cats" _
        })
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub IgnoreNonAllergenScoreParts()
        Dim allergies = New Allergies(509)
        Assert.Equal(allergies.List(), New List(Of String)() From { _
            "eggs", _
            "shellfish", _
            "strawberries", _
            "tomatoes", _
            "chocolate", _
            "pollen", _
            "cats" _
        })
    End Sub
End Class
