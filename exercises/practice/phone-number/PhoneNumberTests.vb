Public Class PhoneNumberTests
    <Fact>
    Public Sub Cleans_the_number()
        Dim phrase = "(223) 456-7890"
        Assert.Equal("2234567890", PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cleans_numbers_with_dots()
        Dim phrase = "223.456.7890"
        Assert.Equal("2234567890", PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cleans_numbers_with_multiple_spaces()
        Dim phrase = "223 456   7890   "
        Assert.Equal("2234567890", PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_when_9_digits()
        Dim phrase = "123456789"
        Assert.Throws(Of ArgumentException)(Function() PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_when_11_digits_does_not_start_with_a_1()
        Dim phrase = "22234567890"
        Assert.Throws(Of ArgumentException)(Function() PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valid_when_11_digits_and_starting_with_1()
        Dim phrase = "12234567890"
        Assert.Equal("2234567890", PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Valid_when_11_digits_and_starting_with_1_even_with_punctuation()
        Dim phrase = "+1 (223) 456-7890"
        Assert.Equal("2234567890", PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_when_more_than_11_digits()
        Dim phrase = "321234567890"
        Assert.Throws(Of ArgumentException)(Function() PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_with_letters()
        Dim phrase = "523-abc-7890"
        Assert.Throws(Of ArgumentException)(Function() PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_with_punctuations()
        Dim phrase = "523-@:!-7890"
        Assert.Throws(Of ArgumentException)(Function() PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_if_area_code_starts_with_0()
        Dim phrase = "(023) 456-7890"
        Assert.Throws(Of ArgumentException)(Function() PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_if_area_code_starts_with_1()
        Dim phrase = "(123) 456-7890"
        Assert.Throws(Of ArgumentException)(Function() PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_if_exchange_code_starts_with_0()
        Dim phrase = "(223) 056-7890"
        Assert.Throws(Of ArgumentException)(Function() PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_if_exchange_code_starts_with_1()
        Dim phrase = "(223) 156-7890"
        Assert.Throws(Of ArgumentException)(Function() PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_if_area_code_starts_with_0_on_valid_11_digit_number()
        Dim phrase = "1 (023) 456-7890"
        Assert.Throws(Of ArgumentException)(Function() PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_if_area_code_starts_with_1_on_valid_11_digit_number()
        Dim phrase = "1 (123) 456-7890"
        Assert.Throws(Of ArgumentException)(Function() PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_if_exchange_code_starts_with_0_on_valid_11_digit_number()
        Dim phrase = "1 (223) 056-7890"
        Assert.Throws(Of ArgumentException)(Function() PhoneNumber.Clean(phrase))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Invalid_if_exchange_code_starts_with_1_on_valid_11_digit_number()
        Dim phrase = "1 (223) 156-7890"
        Assert.Throws(Of ArgumentException)(Function() PhoneNumber.Clean(phrase))
    End Sub
End Class
