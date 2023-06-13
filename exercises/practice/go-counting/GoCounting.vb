Imports System
Imports System.Collections.Generic

Public Enum Owner
    None
    Black
    White
End Enum

Public Class GoCounting
    Public Sub New(ByVal input As String)
        Throw New NotImplementedException("You need to implement this function.")
    End Sub

    Public Function Territory(ByVal coord As (Integer, Integer)) As Tuple(Of Owner, HashSet(Of (Integer, Integer)))
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Territories() As Dictionary(Of Owner, HashSet(Of (Integer, Integer)))
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Class
