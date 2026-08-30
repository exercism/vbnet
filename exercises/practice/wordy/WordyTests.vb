Public Class WordyTests
    <Fact>
    Public Sub Just_a_number()
        Dim question = "What is 5?"
        Assert.Equal(5, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Just_a_zero()
        Dim question = "What is 0?"
        Assert.Equal(0, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Just_a_negative_number()
        Dim question = "What is -123?"
        Assert.Equal(-123, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Addition()
        Dim question = "What is 1 plus 1?"
        Assert.Equal(2, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Addition_with_a_left_hand_zero()
        Dim question = "What is 0 plus 2?"
        Assert.Equal(2, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Addition_with_a_right_hand_zero()
        Dim question = "What is 3 plus 0?"
        Assert.Equal(3, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub More_addition()
        Dim question = "What is 53 plus 2?"
        Assert.Equal(55, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Addition_with_negative_numbers()
        Dim question = "What is -1 plus -10?"
        Assert.Equal(-11, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Large_addition()
        Dim question = "What is 123 plus 45678?"
        Assert.Equal(45801, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtraction()
        Dim question = "What is 4 minus -12?"
        Assert.Equal(16, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiplication()
        Dim question = "What is -3 multiplied by 25?"
        Assert.Equal(-75, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Division()
        Dim question = "What is 33 divided by -3?"
        Assert.Equal(-11, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_additions()
        Dim question = "What is 1 plus 1 plus 1?"
        Assert.Equal(3, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Addition_and_subtraction()
        Dim question = "What is 1 plus 5 minus -2?"
        Assert.Equal(8, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_subtraction()
        Dim question = "What is 20 minus 4 minus 13?"
        Assert.Equal(3, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Subtraction_then_addition()
        Dim question = "What is 17 minus 6 plus 3?"
        Assert.Equal(14, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_multiplication()
        Dim question = "What is 2 multiplied by -2 multiplied by 3?"
        Assert.Equal(-12, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Addition_and_multiplication()
        Dim question = "What is -3 plus 7 multiplied by -2?"
        Assert.Equal(-8, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_division()
        Dim question = "What is -12 divided by 2 divided by -3?"
        Assert.Equal(2, Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Unknown_operation()
        Dim question = "What is 52 cubed?"
        Assert.Throws(Of ArgumentException)(Function() Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Non_math_question()
        Dim question = "Who is the President of the United States?"
        Assert.Throws(Of ArgumentException)(Function() Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reject_problem_missing_an_operand()
        Dim question = "What is 1 plus?"
        Assert.Throws(Of ArgumentException)(Function() Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reject_problem_with_no_operands_or_operators()
        Dim question = "What is?"
        Assert.Throws(Of ArgumentException)(Function() Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reject_two_operations_in_a_row()
        Dim question = "What is 1 plus plus 2?"
        Assert.Throws(Of ArgumentException)(Function() Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reject_two_numbers_in_a_row()
        Dim question = "What is 1 plus 2 1?"
        Assert.Throws(Of ArgumentException)(Function() Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reject_postfix_notation()
        Dim question = "What is 1 2 plus?"
        Assert.Throws(Of ArgumentException)(Function() Wordy.Answer(question))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reject_prefix_notation()
        Dim question = "What is plus 1 2?"
        Assert.Throws(Of ArgumentException)(Function() Wordy.Answer(question))
    End Sub
End Class
