Imports System
Imports System.Collections.Generic

Public Enum Plant
    Violets
    Radishes
    Clover
    Grass
End Enum

Public Class KindergartenGarden
    Public Sub New(ByVal diagram As String)
    End Sub

    Public Function Plants(ByVal student As String) As IEnumerable(Of Plant)
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Class
