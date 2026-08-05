Public Enum Plant
    Clover
    Grass
    Radishes
    Violets
End Enum

Public Class KindergartenGarden
    Public Sub New(ByVal diagram As String)
    End Sub

    Public Function Plants(ByVal student As String) As IEnumerable(Of Plant)
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Class
