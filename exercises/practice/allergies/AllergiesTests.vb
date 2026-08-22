Public Class AllergiesTests
    <Fact>
    Public Sub Testing_for_eggs_allergy_not_allergic_to_anything()
        Dim allergies = New Allergies(0)
        Assert.[False](allergies.AllergicTo("eggs"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_eggs_allergy_allergic_only_to_eggs()
        Dim allergies = New Allergies(1)
        Assert.[True](allergies.AllergicTo("eggs"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_eggs_allergy_allergic_to_eggs_and_something_else()
        Dim allergies = New Allergies(3)
        Assert.[True](allergies.AllergicTo("eggs"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_eggs_allergy_allergic_to_something_but_not_eggs()
        Dim allergies = New Allergies(2)
        Assert.[False](allergies.AllergicTo("eggs"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_eggs_allergy_allergic_to_everything()
        Dim allergies = New Allergies(255)
        Assert.[True](allergies.AllergicTo("eggs"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_peanuts_allergy_not_allergic_to_anything()
        Dim allergies = New Allergies(0)
        Assert.[False](allergies.AllergicTo("peanuts"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_peanuts_allergy_allergic_only_to_peanuts()
        Dim allergies = New Allergies(2)
        Assert.[True](allergies.AllergicTo("peanuts"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_peanuts_allergy_allergic_to_peanuts_and_something_else()
        Dim allergies = New Allergies(7)
        Assert.[True](allergies.AllergicTo("peanuts"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_peanuts_allergy_allergic_to_something_but_not_peanuts()
        Dim allergies = New Allergies(5)
        Assert.[False](allergies.AllergicTo("peanuts"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_peanuts_allergy_allergic_to_everything()
        Dim allergies = New Allergies(255)
        Assert.[True](allergies.AllergicTo("peanuts"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_shellfish_allergy_not_allergic_to_anything()
        Dim allergies = New Allergies(0)
        Assert.[False](allergies.AllergicTo("shellfish"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_shellfish_allergy_allergic_only_to_shellfish()
        Dim allergies = New Allergies(4)
        Assert.[True](allergies.AllergicTo("shellfish"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_shellfish_allergy_allergic_to_shellfish_and_something_else()
        Dim allergies = New Allergies(14)
        Assert.[True](allergies.AllergicTo("shellfish"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_shellfish_allergy_allergic_to_something_but_not_shellfish()
        Dim allergies = New Allergies(10)
        Assert.[False](allergies.AllergicTo("shellfish"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_shellfish_allergy_allergic_to_everything()
        Dim allergies = New Allergies(255)
        Assert.[True](allergies.AllergicTo("shellfish"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_strawberries_allergy_not_allergic_to_anything()
        Dim allergies = New Allergies(0)
        Assert.[False](allergies.AllergicTo("strawberries"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_strawberries_allergy_allergic_only_to_strawberries()
        Dim allergies = New Allergies(8)
        Assert.[True](allergies.AllergicTo("strawberries"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_strawberries_allergy_allergic_to_strawberries_and_something_else()
        Dim allergies = New Allergies(28)
        Assert.[True](allergies.AllergicTo("strawberries"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_strawberries_allergy_allergic_to_something_but_not_strawberries()
        Dim allergies = New Allergies(20)
        Assert.[False](allergies.AllergicTo("strawberries"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_strawberries_allergy_allergic_to_everything()
        Dim allergies = New Allergies(255)
        Assert.[True](allergies.AllergicTo("strawberries"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_tomatoes_allergy_not_allergic_to_anything()
        Dim allergies = New Allergies(0)
        Assert.[False](allergies.AllergicTo("tomatoes"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_tomatoes_allergy_allergic_only_to_tomatoes()
        Dim allergies = New Allergies(16)
        Assert.[True](allergies.AllergicTo("tomatoes"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_tomatoes_allergy_allergic_to_tomatoes_and_something_else()
        Dim allergies = New Allergies(56)
        Assert.[True](allergies.AllergicTo("tomatoes"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_tomatoes_allergy_allergic_to_something_but_not_tomatoes()
        Dim allergies = New Allergies(40)
        Assert.[False](allergies.AllergicTo("tomatoes"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_tomatoes_allergy_allergic_to_everything()
        Dim allergies = New Allergies(255)
        Assert.[True](allergies.AllergicTo("tomatoes"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_chocolate_allergy_not_allergic_to_anything()
        Dim allergies = New Allergies(0)
        Assert.[False](allergies.AllergicTo("chocolate"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_chocolate_allergy_allergic_only_to_chocolate()
        Dim allergies = New Allergies(32)
        Assert.[True](allergies.AllergicTo("chocolate"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_chocolate_allergy_allergic_to_chocolate_and_something_else()
        Dim allergies = New Allergies(112)
        Assert.[True](allergies.AllergicTo("chocolate"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_chocolate_allergy_allergic_to_something_but_not_chocolate()
        Dim allergies = New Allergies(80)
        Assert.[False](allergies.AllergicTo("chocolate"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_chocolate_allergy_allergic_to_everything()
        Dim allergies = New Allergies(255)
        Assert.[True](allergies.AllergicTo("chocolate"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_pollen_allergy_not_allergic_to_anything()
        Dim allergies = New Allergies(0)
        Assert.[False](allergies.AllergicTo("pollen"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_pollen_allergy_allergic_only_to_pollen()
        Dim allergies = New Allergies(64)
        Assert.[True](allergies.AllergicTo("pollen"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_pollen_allergy_allergic_to_pollen_and_something_else()
        Dim allergies = New Allergies(224)
        Assert.[True](allergies.AllergicTo("pollen"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_pollen_allergy_allergic_to_something_but_not_pollen()
        Dim allergies = New Allergies(160)
        Assert.[False](allergies.AllergicTo("pollen"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_pollen_allergy_allergic_to_everything()
        Dim allergies = New Allergies(255)
        Assert.[True](allergies.AllergicTo("pollen"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_cats_allergy_not_allergic_to_anything()
        Dim allergies = New Allergies(0)
        Assert.[False](allergies.AllergicTo("cats"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_cats_allergy_allergic_only_to_cats()
        Dim allergies = New Allergies(128)
        Assert.[True](allergies.AllergicTo("cats"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_cats_allergy_allergic_to_cats_and_something_else()
        Dim allergies = New Allergies(192)
        Assert.[True](allergies.AllergicTo("cats"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_cats_allergy_allergic_to_something_but_not_cats()
        Dim allergies = New Allergies(64)
        Assert.[False](allergies.AllergicTo("cats"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Testing_for_cats_allergy_allergic_to_everything()
        Dim allergies = New Allergies(255)
        Assert.[True](allergies.AllergicTo("cats"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub List_when_no_allergies()
        Dim allergies = New Allergies(0)
        Assert.Empty(allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub List_when_just_eggs()
        Dim allergies = New Allergies(1)
        Dim expected As String() = {"eggs"}
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub List_when_just_peanuts()
        Dim allergies = New Allergies(2)
        Dim expected As String() = {"peanuts"}
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub List_when_just_strawberries()
        Dim allergies = New Allergies(8)
        Dim expected As String() = {"strawberries"}
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub List_when_eggs_and_peanuts()
        Dim allergies = New Allergies(3)
        Dim expected As String() = {"eggs", "peanuts"}
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub List_when_more_than_eggs_but_not_peanuts()
        Dim allergies = New Allergies(5)
        Dim expected As String() = {"eggs", "shellfish"}
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub List_when_lots_of_stuff()
        Dim allergies = New Allergies(248)
        Dim expected As String() = {"strawberries", "tomatoes", "chocolate", "pollen", "cats"}
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub List_when_everything()
        Dim allergies = New Allergies(255)
        Dim expected As String() = {"eggs", "peanuts", "shellfish", "strawberries", "tomatoes", "chocolate", "pollen", "cats"}
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub List_when_no_allergen_score_parts()
        Dim allergies = New Allergies(509)
        Dim expected As String() = {"eggs", "shellfish", "strawberries", "tomatoes", "chocolate", "pollen", "cats"}
        Assert.Equal(expected, allergies.List())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub List_when_no_allergen_score_parts_without_highest_valid_score()
        Dim allergies = New Allergies(257)
        Dim expected As String() = {"eggs"}
        Assert.Equal(expected, allergies.List())
    End Sub
End Class
