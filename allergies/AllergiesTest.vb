Imports NUnit.Framework

<TestFixture>
Public Class AllergiesTest
    <Test>
    Public Sub No_allergies_means_not_allergic()
        Dim allergies = New Allergies(0)
        Assert.That(allergies.AllergicTo("peanuts"), [Is].[False])
        Assert.That(allergies.AllergicTo("cats"), [Is].[False])
        Assert.That(allergies.AllergicTo("strawberries"), [Is].[False])
    End Sub

    <Ignore>
    <Test>
    Public Sub Allergic_to_eggs()
        Dim allergies = New Allergies(1)
        Assert.That(allergies.AllergicTo("eggs"), [Is].[True])
    End Sub

    <Ignore>
    <Test>
    Public Sub Allergic_to_eggs_in_addition_to_other_stuff()
        Dim allergies = New Allergies(5)
        Assert.That(allergies.AllergicTo("eggs"), [Is].[True])
        Assert.That(allergies.AllergicTo("shellfish"), [Is].[True])
        Assert.That(allergies.AllergicTo("strawberries"), [Is].[False])
    End Sub

    <Ignore>
    <Test>
    Public Sub No_allergies_at_all()
        Dim allergies = New Allergies(0)
        Assert.That(allergies.List(), [Is].Empty)
    End Sub

    <Ignore>
    <Test>
    Public Sub Allergic_to_just_eggs()
        Dim allergies = New Allergies(1)
        Assert.That(allergies.List(), [Is].EqualTo(New List(Of String) From {
            "eggs"
        }))
    End Sub

    <Ignore>
    <Test>
    Public Sub Allergic_to_just_peanuts()
        Dim allergies = New Allergies(2)
        Assert.That(allergies.List(), [Is].EqualTo(New List(Of String) From {
            "peanuts"
        }))
    End Sub

    <Ignore>
    <Test>
    Public Sub Allergic_to_eggs_and_peanuts()
        Dim allergies = New Allergies(3)
        Assert.That(allergies.List(), [Is].EqualTo(New List(Of String) From {
            "eggs",
            "peanuts"
        }))
    End Sub

    <Ignore>
    <Test>
    Public Sub Allergic_to_lots_of_stuff()
        Dim allergies = New Allergies(248)
        Assert.That(allergies.List(), [Is].EqualTo(New List(Of String)() From { _
            "strawberries", _
            "tomatoes", _
            "chocolate", _
            "pollen", _
            "cats" _
        }))
    End Sub

    <Ignore>
    <Test>
    Public Sub Allergic_to_everything()
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

    <Ignore>
    <Test>
    Public Sub Ignore_non_allergen_score_parts()
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
