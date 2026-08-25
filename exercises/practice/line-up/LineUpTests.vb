Public Class LineUpTests
    <Fact>
    Public Sub Format_smallest_non_exceptional_ordinal_numeral_4()
        Dim expected = "Gianna, you are the 4th customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Gianna", 4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_greatest_single_digit_non_exceptional_ordinal_numeral_9()
        Dim expected = "Maarten, you are the 9th customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Maarten", 9))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_non_exceptional_ordinal_numeral_5()
        Dim expected = "Petronila, you are the 5th customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Petronila", 5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_non_exceptional_ordinal_numeral_6()
        Dim expected = "Attakullakulla, you are the 6th customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Attakullakulla", 6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_non_exceptional_ordinal_numeral_7()
        Dim expected = "Kate, you are the 7th customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Kate", 7))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_non_exceptional_ordinal_numeral_8()
        Dim expected = "Maximiliano, you are the 8th customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Maximiliano", 8))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_exceptional_ordinal_numeral_1()
        Dim expected = "Mary, you are the 1st customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Mary", 1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_exceptional_ordinal_numeral_2()
        Dim expected = "Haruto, you are the 2nd customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Haruto", 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_exceptional_ordinal_numeral_3()
        Dim expected = "Henriette, you are the 3rd customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Henriette", 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_smallest_two_digit_non_exceptional_ordinal_numeral_10()
        Dim expected = "Alvarez, you are the 10th customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Alvarez", 10))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_non_exceptional_ordinal_numeral_11()
        Dim expected = "Jacqueline, you are the 11th customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Jacqueline", 11))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_non_exceptional_ordinal_numeral_12()
        Dim expected = "Juan, you are the 12th customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Juan", 12))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_non_exceptional_ordinal_numeral_13()
        Dim expected = "Patricia, you are the 13th customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Patricia", 13))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_exceptional_ordinal_numeral_21()
        Dim expected = "Washi, you are the 21st customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Washi", 21))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_exceptional_ordinal_numeral_22_ending_in_nd_even_though_it_is_a_multiple_of_11()
        Dim expected = "Ingrid, you are the 22nd customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Ingrid", 22))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_exceptional_ordinal_numeral_33_ending_in_rd_even_though_it_is_a_multiple_of_11()
        Dim expected = "Mario, you are the 33rd customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Mario", 33))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_exceptional_ordinal_numeral_52_ending_in_nd_even_though_it_is_a_multiple_of_13()
        Dim expected = "Quentin, you are the 52nd customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Quentin", 52))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_exceptional_ordinal_numeral_62()
        Dim expected = "Nayra, you are the 62nd customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Nayra", 62))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_non_exceptional_ordinal_numeral_72_ending_in_nd_even_though_it_is_a_multiple_of_12()
        Dim expected = "Ugo, you are the 72nd customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Ugo", 72))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_exceptional_ordinal_numeral_91_ending_in_st_even_though_it_is_a_multiple_of_13()
        Dim expected = "Boris, you are the 91st customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Boris", 91))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_exceptional_ordinal_numeral_100()
        Dim expected = "John, you are the 100th customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("John", 100))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_exceptional_ordinal_numeral_101()
        Dim expected = "Zeinab, you are the 101st customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Zeinab", 101))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_non_exceptional_ordinal_numeral_112()
        Dim expected = "Knud, you are the 112th customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Knud", 112))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_exceptional_ordinal_numeral_123()
        Dim expected = "Yma, you are the 123rd customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Yma", 123))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Format_large_number_972_ending_in_nd_even_though_it_is_a_multiple_of_12()
        Dim expected = "Elias, you are the 972nd customer we serve today. Thank you!"
        Assert.Equal(expected, LineUp.Format("Elias", 972))
    End Sub
End Class
