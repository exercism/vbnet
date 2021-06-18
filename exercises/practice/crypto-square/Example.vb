Imports System.Text

Public Class Crypto
    Property NormalizePlaintext As String
    Property Size As Integer

	Public Sub New(value As String)
        NormalizePlaintext = NormalizeText(value)
		Size = GetSquareSize(NormalizePlaintext)
	End Sub

	Private Shared Function NormalizeText(text As String) As String
		Return String.Concat(text.ToLower().Where(AddressOf Char.IsLetterOrDigit))
	End Function

	Private Shared Function GetSquareSize(text As String) As Integer
		Return CInt(Math.Truncate(Math.Ceiling(Math.Sqrt(text.Length))))
	End Function

	Public Function PlaintextSegments() As String()
		Return SegmentText(NormalizePlaintext, Size)
	End Function

	Private Shared Function SegmentText(text As String, size As Integer) As String()
		Dim segments = New List(Of String)()
		Dim idx = 0
		While idx < text.Length
			If idx + size < text.Length Then
				segments.Add(text.Substring(idx, size))
			Else
				segments.Add(text.Substring(idx))
			End If
			idx += size
		End While
		Return segments.ToArray()
	End Function

	Public Function Ciphertext() As String
		Dim ciphertext__1 = New StringBuilder(NormalizePlaintext.Length)

		For i As Integer = 0 To Size - 1
            For Each segment In PlaintextSegments()
                If i < segment.Length Then
                    ciphertext__1.Append(segment(i))
                End If
            Next
		Next
		Return ciphertext__1.ToString()
	End Function

	Public Function NormalizeCiphertext() As String
		Return String.Join(" ", SegmentText(Ciphertext(), 5))
	End Function
End Class
