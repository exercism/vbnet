Imports System
Imports Xunit

Public Class WordyTests
    <Fact>
    Public Sub Just_a_number()
        Assert.Equal(5, Answer("What is 5?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Addition()
        Assert.Equal(2, Answer("What is 1 plus 1?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub More_addition()
        Assert.Equal(55, Answer("What is 53 plus 2?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Addition_with_negative_numbers()
        Assert.Equal(-11, Answer("What is -1 plus -10?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Large_addition()
        Assert.Equal(45801, Answer("What is 123 plus 45678?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtraction()
        Assert.Equal(16, Answer("What is 4 minus -12?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiplication()
        Assert.Equal(-75, Answer("What is -3 multiplied by 25?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Division()
        Assert.Equal(-11, Answer("What is 33 divided by -3?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_additions()
        Assert.Equal(3, Answer("What is 1 plus 1 plus 1?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Addition_and_subtraction()
        Assert.Equal(8, Answer("What is 1 plus 5 minus -2?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_subtraction()
        Assert.Equal(3, Answer("What is 20 minus 4 minus 13?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtraction_then_addition()
        Assert.Equal(14, Answer("What is 17 minus 6 plus 3?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_multiplication()
        Assert.Equal(-12, Answer("What is 2 multiplied by -2 multiplied by 3?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Addition_and_multiplication()
        Assert.Equal(-8, Answer("What is -3 plus 7 multiplied by -2?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_division()
        Assert.Equal(2, Answer("What is -12 divided by 2 divided by -3?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Unknown_operation()
        Assert.Throws(Of ArgumentException)(Function() Answer("What is 52 cubed?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Non_math_question()
        Assert.Throws(Of ArgumentException)(Function() Answer("Who is the President of the United States?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reject_problem_missing_an_operand()
        Assert.Throws(Of ArgumentException)(Function() Answer("What is 1 plus?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reject_problem_with_no_operands_or_operators()
        Assert.Throws(Of ArgumentException)(Function() Answer("What is?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reject_two_operations_in_a_row()
        Assert.Throws(Of ArgumentException)(Function() Answer("What is 1 plus plus 2?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reject_two_numbers_in_a_row()
        Assert.Throws(Of ArgumentException)(Function() Answer("What is 1 plus 2 1?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reject_postfix_notation()
        Assert.Throws(Of ArgumentException)(Function() Answer("What is 1 2 plus?"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reject_prefix_notation()
        Assert.Throws(Of ArgumentException)(Function() Answer("What is plus 1 2?"))
    End Sub
End Class
