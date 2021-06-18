Public Class Binary
    Private ReadOnly value As String

    Public Sub New(value As String)
        Me.value = value
    End Sub

    Public Function ToDecimal() As Integer
        If IsNotValidBinary() Then
            Return 0
        End If

        Return value.Select(Function(c, i) Integer.Parse(c.ToString()) * TwoToThePowerOf(value.Length - i - 1)).Sum()
    End Function

    Private Function IsNotValidBinary() As Boolean
        Return Not value.All(Function(x) Char.IsDigit(x) AndAlso Integer.Parse(x.ToString()) < 2)
    End Function

    Private Shared Function TwoToThePowerOf(power As Integer) As Integer
        Return CInt(Math.Truncate(Math.Pow(2, power)))
    End Function
End Class
