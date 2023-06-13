Imports System

Public Module ResistorColorTrio
    Private Const KiloOhms As Integer = 1_000
    Private ReadOnly AllColors As String() = {"black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"}
    Public Function Label(ByVal colors As String()) As String
        Dim value = GetValue(colors)
        Dim unit = GetUnit(value)
        If unit = "kiloohms" Then value \= 1_000
        Return String.Format("{0} {1}", value, unit)
    End Function    
    Private Function GetValue(ByVal colors As String()) As Integer
        Return (ResistorValue(colors(0)) * 10 + ResistorValue(colors(1))) * CInt(Math.Pow(10, ResistorValue(colors(2))))
    End Function
    Private Function GetUnit(ByVal value As Integer) As String
        Return If(value >= KiloOhms, "kilo", "") & "ohms"
    End Function
    Private Function ResistorValue(ByVal color As String) As Integer
        Return Array.IndexOf(AllColors, color)
    End Function

End Module
