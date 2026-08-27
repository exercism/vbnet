Public Class KindergartenGardenTests
    <Fact>
    Public Sub Garden_with_single_student()
        Dim diagram = "RC" & vbLf & "GG"
        Dim expected = {Plant.Radishes, Plant.Clover, Plant.Grass, Plant.Grass}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Alice"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Different_garden_with_single_student()
        Dim diagram = "VC" & vbLf & "RC"
        Dim expected = {Plant.Violets, Plant.Clover, Plant.Radishes, Plant.Clover}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Alice"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Garden_with_two_students()
        Dim diagram = "VVCG" & vbLf & "VVRC"
        Dim expected = {Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Clover}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Bob"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Second_student_s_garden()
        Dim diagram = "VVCCGG" & vbLf & "VVCCGG"
        Dim expected = {Plant.Clover, Plant.Clover, Plant.Clover, Plant.Clover}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Bob"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Third_student_s_garden()
        Dim diagram = "VVCCGG" & vbLf & "VVCCGG"
        Dim expected = {Plant.Grass, Plant.Grass, Plant.Grass, Plant.Grass}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Charlie"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_alice_first_student_s_garden()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Violets, Plant.Radishes, Plant.Violets, Plant.Radishes}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Alice"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_bob_second_student_s_garden()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Clover, Plant.Grass, Plant.Clover, Plant.Clover}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Bob"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_charlie()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Violets, Plant.Violets, Plant.Clover, Plant.Grass}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Charlie"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_david()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Radishes, Plant.Violets, Plant.Clover, Plant.Radishes}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("David"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_eve()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Grass}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Eve"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_fred()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Fred"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_ginny()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Clover, Plant.Grass, Plant.Grass, Plant.Clover}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Ginny"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_harriet()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Violets, Plant.Radishes, Plant.Radishes, Plant.Violets}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Harriet"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_ileana()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Ileana"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_joseph()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Violets, Plant.Clover, Plant.Violets, Plant.Grass}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Joseph"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_kincaid_second_to_last_student_s_garden()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Grass, Plant.Clover, Plant.Clover, Plant.Grass}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Kincaid"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_larry_last_student_s_garden()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Grass, Plant.Violets, Plant.Clover, Plant.Violets}
        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Larry"))
    End Sub
End Class
