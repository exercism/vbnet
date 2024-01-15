Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Module ResistorColorDuo
    Public Function Value(ByVal colors As String()) As Integer
        Return concat(colors.Take(2).Select(Function(c) Array.IndexOf(AllColors, c)))
    End Function

    Private Function concat(ByVal numbers As IEnumerable(Of Integer)) As Integer
        Return Integer.Parse(numbers.Aggregate("", Function(acc, num) acc & num.ToString()))
    End Function

    Private ReadOnly AllColors As String() = {"black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"}
End Module

' An Alternative implementation that doesn't utilize LINQ
' public static class ResistorColorDuo
' {
'     public static int Value(string[] colors) => Value(colors[0]) * 10 + Value(colors[1]);
'     public static int Value(string color) => Array.IndexOf(AllColors, color);
'     private static readonly string[] AllColors = new[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
' }
