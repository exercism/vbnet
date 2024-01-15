Imports System
Imports System.Text.RegularExpressions

Public Module Wordy
    Private ReadOnly EquationRegex As Regex = New Regex("^What is (?<left>-?\d+)(?<operations> (?<operand>plus|minus|multiplied by|divided by) (?<right>-?\d+))*\?$", RegexOptions.Compiled)

    Public Function Answer(ByVal question As String) As Integer
        Return Solve(Parse(question))
    End Function

    Private Function Parse(ByVal question As String) As Match
        Return EquationRegex.Match(question)
    End Function

    Private Function Solve(ByVal parsedQuestion As Match) As Integer
        Dim left As Integer = Nothing
        If Not Integer.TryParse(parsedQuestion.Groups("left").Value, left) Then Throw New ArgumentException()
        Dim right As Integer = Nothing

        For i = 0 To parsedQuestion.Groups("operations").Captures.Count - 1
            Dim operand = parsedQuestion.Groups("operand").Captures(i).Value
            If Not Integer.TryParse(parsedQuestion.Groups("right").Captures(i).Value, right) Then Throw New ArgumentException()

            left = ApplyOperand(left, operand, right)
        Next

        Return left
    End Function

    Private Function ApplyOperand(ByVal left As Integer, ByVal operand As String, ByVal right As Integer) As Integer
        Select Case operand
            Case "plus"
                Return left + right
            Case "minus"
                Return left - right
            Case "multiplied by"
                Return left * right
            Case "divided by"
                Return left / right
            Case Else
                Throw New ArgumentException()
        End Select
    End Function
End Module
