Public Class Allergies
    Private ReadOnly score As Integer
    Private Shared ReadOnly AvailableAllergies As New Dictionary(Of String, Integer) From {
        {"eggs", 1},
        {"peanuts", 2},
        {"shellfish", 4},
        {"strawberries", 8},
        {"tomatoes", 16},
        {"chocolate", 32},
        {"pollen", 64},
        {"cats", 128}
    }

    Public Sub New(score As Integer)
        Me.score = score
    End Sub

    Public Function AllergicTo(allergy As String) As Boolean
        Return IsInAllergyScore(AvailableAllergies(allergy))
    End Function

    Public Function List() As IList(Of String)
        Return AvailableAllergies.Where(Function(x) IsInAllergyScore(x.Value)).Select(Function(x) x.Key).ToList()
    End Function

    Private Function IsInAllergyScore(allergyValue As Integer) As Boolean
        Return (score And allergyValue) = allergyValue
    End Function
End Class
