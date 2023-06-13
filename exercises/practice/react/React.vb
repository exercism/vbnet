Imports System
Imports System.Collections.Generic

Public Class Reactor
    Public Function CreateInputCell(ByVal value As Integer) As InputCell
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function CreateComputeCell(ByVal producers As IEnumerable(Of Cell), ByVal compute As Func(Of Integer(), Integer)) As ComputeCell
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Class

Public MustInherit Class Cell
End Class

Public Class InputCell
    Inherits Cell
End Class

Public Class ComputeCell
    Inherits Cell

End Class
