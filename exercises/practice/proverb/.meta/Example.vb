Imports System
Imports System.Linq

Public Module Proverb
    Public Function Recite(ByVal subjects As String()) As String()
        Dim line As Func(Of Integer, String) = Function(lineIndex)
                                                   If lineIndex = subjects.Length Then
                                                       Return $"And all for the want of a {subjects(0)}."
                                                   Else
                                                       Return $"For want of a {subjects(lineIndex - 1)} the {subjects(lineIndex)} was lost."
                                                   End If
                                               End Function

        Return Enumerable.Range(1, subjects.Length).[Select](line).ToArray()
    End Function
End Module
