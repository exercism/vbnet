Imports System.Collections.Generic

Public Class GradeSchool
    Private ReadOnly _roster As New SortedDictionary(Of Integer, List(Of String))


    Public Function Add(ByVal student As String, ByVal grade As Integer) As Boolean
        If Me._roster.Values.Any(Function(students) students.Contains(student)) Then Return False

        If Not Me._roster.TryAdd(grade, New List(Of String) From {
            student
        }) Then
            Me._roster(grade).Add(student)
            Me._roster(grade).Sort()
        End If

        Return True
    End Function

    Public Function Roster() As IEnumerable(Of String)
        Return Me._roster.Values.SelectMany(Function(grade) grade).ToList()
    End Function

    Public Function Grade(ByVal pGrade As Integer) As IEnumerable(Of String)
        Dim students As New List(Of String)()    
        Return If(Me._roster.TryGetValue(pGrade, students), students, New List(Of String)())
    End Function
End Class
