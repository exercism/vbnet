Imports Xunit

Public Class MatrixTests
    <Fact>
    Public Sub Extract_row_from_one_number_matrix()
        Dim sut = New Matrix("1")
        Dim expected = {1}
        Dim result as IEnumerable(Of Integer) = sut.Row(1)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_extract_row()
        Dim sut = New Matrix("1 2" & vbLf & "3 4")
        Dim expected = {3, 4}
        Dim result as IEnumerable(Of Integer) = sut.Row(2)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Extract_row_where_numbers_have_different_widths()
        Dim sut = New Matrix("1 2" & vbLf & "10 20")
        Dim expected = {10, 20}
        Dim result as IEnumerable(Of Integer) = sut.Row(2)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_extract_row_from_non_square_matrix_with_no_corresponding_column()
        Dim sut = New Matrix("1 2 3" & vbLf & "4 5 6" & vbLf & "7 8 9" & vbLf & "8 7 6")
        Dim expected = {8, 7, 6}
        Dim result as IEnumerable(Of Integer) = sut.Row(4)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Extract_column_from_one_number_matrix()
        Dim sut = New Matrix("1")
        Dim expected = {1}
        Dim result as IEnumerable(Of Integer) = sut.Column(1)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_extract_column()
        Dim sut = New Matrix("1 2 3" & vbLf & "4 5 6" & vbLf & "7 8 9")
        Dim expected = {3, 6, 9}
        Dim result as IEnumerable(Of Integer) = sut.Column(3)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_extract_column_from_non_square_matrix_with_no_corresponding_row()
        Dim sut = New Matrix("1 2 3 4" & vbLf & "5 6 7 8" & vbLf & "9 8 7 6")
        Dim expected = {4, 8, 6}
        Dim result as IEnumerable(Of Integer) = sut.Column(4)
        Assert.Equal(expected, result)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Extract_column_where_numbers_have_different_widths()
        Dim sut = New Matrix("89 1903 3" & vbLf & "18 3 1" & vbLf & "9 4 800")
        Dim expected = {1903, 3, 4}
        Dim result as IEnumerable(Of Integer) = sut.Column(2)
        Assert.Equal(expected, result)
    End Sub
End Class
