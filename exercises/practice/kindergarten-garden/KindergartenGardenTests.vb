Public Class KindergartenGardenTests
    <Fact>
    Public Sub Garden_With_Single_Student()
        Dim diagram = "RC" & vbLf & "GG"
        Dim expected = {Plant.Radishes, Plant.Clover, Plant.Grass, Plant.Grass}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Alice"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Different_Garden_With_Single_Student()
        Dim diagram = "VC" & vbLf & "RC"
        Dim expected = {Plant.Violets, Plant.Clover, Plant.Radishes, Plant.Clover}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Alice"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Garden_With_Two_Students()
        Dim diagram = "VVCG" & vbLf & "VVRC"
        Dim expected = {Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Clover}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Bob"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Second_Students_Garden()
        Dim diagram = "VVCCGG" & vbLf & "VVCCGG"
        Dim expected = {Plant.Clover, Plant.Clover, Plant.Clover, Plant.Clover}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Bob"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Third_Students_Garden()
        Dim diagram = "VVCCGG" & vbLf & "VVCCGG"
        Dim expected = {Plant.Grass, Plant.Grass, Plant.Grass, Plant.Grass}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Charlie"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_Alice_First_Students_Garden()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Violets, Plant.Radishes, Plant.Violets, Plant.Radishes}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Alice"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_Bob_Second_Students_Garden()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Clover, Plant.Grass, Plant.Clover, Plant.Clover}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Bob"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_Charlie()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Violets, Plant.Violets, Plant.Clover, Plant.Grass}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Charlie"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_David()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Radishes, Plant.Violets, Plant.Clover, Plant.Radishes}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("David"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_Eve()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Grass}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Eve"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_Fred()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Fred"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_Ginny()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Clover, Plant.Grass, Plant.Grass, Plant.Clover}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Ginny"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_Harriet()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Violets, Plant.Radishes, Plant.Radishes, Plant.Violets}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Harriet"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_Ileana()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Ileana"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_Joseph()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Violets, Plant.Clover, Plant.Violets, Plant.Grass}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Joseph"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_Kincaid_Second_To_Last_Students_Garden()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Grass, Plant.Clover, Plant.Clover, Plant.Grass}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Kincaid"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub For_Larry_Last_Students_Garden()
        Dim diagram = "VRCGVVRVCGGCCGVRGCVCGCGV" & vbLf & "VRCCCGCRRGVCGCRVVCVGCGCV"
        Dim expected = {Plant.Grass, Plant.Violets, Plant.Clover, Plant.Violets}

        Assert.Equal(expected, New KindergartenGarden(diagram).Plants("Larry"))
    End Sub
End Class
