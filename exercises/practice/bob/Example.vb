Public Class Bob
	Public Function Hey(statement As String) As String

		If IsSilence(statement) Then
			Return "Fine. Be that way!"
		End If
		If IsYelling(statement) Then
			Return "Whoa, chill out!"
		End If
		If IsQuestion(statement) Then
			Return "Sure."
		Else
			Return "Whatever."
		End If

	End Function

	Private Function IsSilence(statement As String) As Boolean
		Return statement.Trim() = ""
	End Function

	Private Function IsYelling(statement As String) As Boolean
		Return statement.ToUpper() = statement AndAlso System.Text.RegularExpressions.Regex.IsMatch(statement, "[a-zA-Z]+")
	End Function

	Private Function IsQuestion(statement As String) As Boolean
		Return statement.EndsWith("?")
	End Function

End Class
