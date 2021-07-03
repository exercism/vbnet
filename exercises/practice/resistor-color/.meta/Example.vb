Imports System.Collections.Generic
Imports System.Linq

Public Module ResistorColor
    Private resistorColors = New Dictionary(Of String, Integer) From {
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
        Return resistorColors(color)
    End Function

    Public Function Colors() As String()
	    Dim keys(resistorColors.Count - 1) As String
	    resistorColors.Keys.CopyTo(keys, 0)
        Return keys
    End Function
End Module