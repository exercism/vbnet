Imports System

Public Module ResistorColorTrio
    Private ReadOnly AllColors As String() = {"black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"}

    Public Function Label(ByVal colors As String()) As String
        Dim value As Long = GetValue(colors)
        Dim unit = GetUnit(value)
        If unit = "kiloohms" Then
            value \= 1_000
        ElseIf unit = "megaohms" Then
            value \= 1_000_000
        ElseIf unit = "gigaohms" Then
            value \= 1_000_000_000
        End If
        Return String.Format("{0} {1}", value, unit)
    End Function

    Private Function GetValue(ByVal colors As String()) As Long
        Return (ResistorValue(colors(0)) * 10 + ResistorValue(colors(1))) * CLng(Math.Pow(10, ResistorValue(colors(2))))
    End Function

    Private Function GetUnit(ByVal value As Long) As String
        If value >= 1_000_000_000 Then
            Return "gigaohms"
        ElseIf value >= 1_000_000 Then
            Return "megaohms"
        ElseIf value >= 1_000 Then
            Return "kiloohms"
        Else
            Return "ohms"
        End If
    End Function

    Private Function ResistorValue(ByVal color As String) As Integer
        Return Array.IndexOf(AllColors, color)
    End Function
End Module
