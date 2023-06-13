Imports System
Imports System.Collections.Generic

Public Class Tree
    Public Sub New(ByVal value As String, ParamArray children As Tree())
        Throw New NotImplementedException("You need to implement this function.")
    End Sub
End Class

Public Module Pov
    Public Function FromPov(ByVal tree As Tree, ByVal from As String) As Tree
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function PathTo(ByVal from As String, ByVal [to] As String, ByVal tree As Tree) As IEnumerable(Of String)
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Module
