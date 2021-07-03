Imports System.Collections.Generic
Imports System.Linq

Public Module ResistorColor
    Private resistorColours = New Dictionary(Of String, Integer) From {
        {"black", 0},
        {"brown", 1},
        {"red", 2},
        {"orange", 3},
        {"yellow", 4},
        {"green", 5},
        {"blue", 6},
        {"violet", 7},
        {"grey", 8},
        {"white", 9}
    }

    Public Function ColorCode(ByVal color As String) As Integer
        Return resistorColours(color)
    End Function

    Public Function Colors() As String()
        Return resistorColours.Keys.ToArray()
    End Function
End Module
