Imports System
Imports System.Collections.Generic

Public Class SgfTree
    Public Sub New(ByVal data As IDictionary(Of String, String()), ParamArray children As SgfTree())
        Me.Data = data
        Me.Children = children
    End Sub

    Public ReadOnly Property Data As IDictionary(Of String, String())
    Public ReadOnly Property Children As SgfTree()
End Class

Public Class SgfParser
    Public Function ParseTree(ByVal input As String) As SgfTree
        Throw New NotImplementedException()
    End Function
End Class
