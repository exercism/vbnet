Imports Xunit

Public Class KindergartenGardenTests
    <Fact>
    Public Sub Partial_garden_garden_with_single_student()
        Dim sut = New KindergartenGarden("RC" & vbLf & "GG")
        Assert.Equal({Plant.Radishes, Plant.Clover, Plant.Grass, Plant.Grass}, sut.Plants("Alice"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Partial_garden_different_garden_with_single_student()
        Dim sut = New KindergartenGarden("VC" & vbLf & "RC")
        Assert.Equal({Plant.Violets, Plant.Clover, Plant.Radishes, Plant.Clover}, sut.Plants("Alice"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Partial_garden_garden_with_two_students()
        Dim sut = New KindergartenGarden("VVCG" & vbLf & "VVRC")
        Assert.Equal({Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Clover}, sut.Plants("Bob"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Partial_garden_multiple_students_for_the_same_garden_with_three_students_second_students_garden()
        Dim sut = New KindergartenGarden("VVCCGG" & vbLf & "VVCCGG")
        Assert.Equal({Plant.Clover, Plant.Clover, Plant.Clover, Plant.Clover}, sut.Plants("Bob"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Partial_garden_multiple_students_for_the_same_garden_with_three_students_third_students_garden()
        Dim sut = New KindergartenGarden("VVCCGG" & vbLf & "VVCCGG")
        Assert.Equal({Plant.Grass, Plant.Grass, Plant.Grass, Plant.Grass}, sut.Plants("Charlie"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_garden_for_alice_first_students_garden()
        Dim sut = New KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV")
        Assert.Equal({Plant.Violets, Plant.Radishes, Plant.Violets, Plant.Radishes}, sut.Plants("Alice"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_garden_for_bob_second_students_garden()
        Dim sut = New KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV")
        Assert.Equal({Plant.Clover, Plant.Grass, Plant.Clover, Plant.Clover}, sut.Plants("Bob"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_garden_for_charlie()
        Dim sut = New KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV")
        Assert.Equal({Plant.Violets, Plant.Violets, Plant.Clover, Plant.Grass}, sut.Plants("Charlie"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_garden_for_david()
        Dim sut = New KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV")
        Assert.Equal({Plant.Radishes, Plant.Violets, Plant.Clover, Plant.Radishes}, sut.Plants("David"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_garden_for_eve()
        Dim sut = New KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV")
        Assert.Equal({Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Grass}, sut.Plants("Eve"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_garden_for_fred()
        Dim sut = New KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV")
        Assert.Equal({Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover}, sut.Plants("Fred"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_garden_for_ginny()
        Dim sut = New KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV")
        Assert.Equal({Plant.Clover, Plant.Grass, Plant.Grass, Plant.Clover}, sut.Plants("Ginny"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_garden_for_harriet()
        Dim sut = New KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV")
        Assert.Equal({Plant.Violets, Plant.Radishes, Plant.Radishes, Plant.Violets}, sut.Plants("Harriet"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_garden_for_ileana()
        Dim sut = New KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV")
        Assert.Equal({Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover}, sut.Plants("Ileana"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_garden_for_joseph()
        Dim sut = New KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV")
        Assert.Equal({Plant.Violets, Plant.Clover, Plant.Violets, Plant.Grass}, sut.Plants("Joseph"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_garden_for_kincaid_second_to_last_students_garden()
        Dim sut = New KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV")
        Assert.Equal({Plant.Grass, Plant.Clover, Plant.Clover, Plant.Grass}, sut.Plants("Kincaid"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_garden_for_larry_last_students_garden()
        Dim sut = New KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV")
        Assert.Equal({Plant.Grass, Plant.Violets, Plant.Clover, Plant.Violets}, sut.Plants("Larry"))
    End Sub
End Class
