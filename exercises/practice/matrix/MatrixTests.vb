Imports Xunit

Public Class MatrixTests
    <Fact>
    Public Sub Extract_row_from_one_number_matrix()
        Dim sut = New Matrix("1")
        Assert.Equal({1}, sut.Row(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_extract_row()
        Dim sut = New Matrix("1 2" & vbLf & "3 4")
        Assert.Equal({3, 4}, sut.Row(2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Extract_row_where_numbers_have_different_widths()
        Dim sut = New Matrix("1 2" & vbLf & "10 20")
        Assert.Equal({10, 20}, sut.Row(2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_extract_row_from_non_square_matrix_with_no_corresponding_column()
        Dim sut = New Matrix("1 2 3" & vbLf & "4 5 6" & vbLf & "7 8 9" & vbLf & "8 7 6")
        Assert.Equal({8, 7, 6}, sut.Row(4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Extract_column_from_one_number_matrix()
        Dim sut = New Matrix("1")
        Assert.Equal({1}, sut.Column(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_extract_column()
        Dim sut = New Matrix("1 2 3" & vbLf & "4 5 6" & vbLf & "7 8 9")
        Assert.Equal({3, 6, 9}, sut.Column(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_extract_column_from_non_square_matrix_with_no_corresponding_row()
        Dim sut = New Matrix("1 2 3 4" & vbLf & "5 6 7 8" & vbLf & "9 8 7 6")
        Assert.Equal({4, 8, 6}, sut.Column(4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Extract_column_where_numbers_have_different_widths()
        Dim sut = New Matrix("89 1903 3" & vbLf & "18 3 1" & vbLf & "9 4 800")
        Assert.Equal({1903, 3, 4}, sut.Column(2))
    End Sub
End Class
