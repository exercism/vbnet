Imports System
Imports System.Collections.Generic

Public Module RelativeDistance
    Public Function DegreesOfSeparation(
                                        ByVal familyTree As Dictionary(Of String, String()),
                                        ByVal personA As String,
                                        ByVal personB As String) As Integer
        
        Dim neighbors As New Dictionary(Of String, HashSet(Of String))()
        For Each kvp In familyTree
            Dim parent = kvp.Key
            Dim children = kvp.Value
            
            If Not neighbors.ContainsKey(parent) Then
                neighbors(parent) = New HashSet(Of String)()
            End If
            
            For Each child In children
                If Not neighbors.ContainsKey(child) Then
                    neighbors(child) = New HashSet(Of String)()
                End If
                neighbors(parent).Add(child)
                neighbors(child).Add(parent)
                
                For Each sibling In children
                    If child <> sibling Then
                        neighbors(child).Add(sibling)
                    End If
                Next
            Next
        Next
        
        If Not neighbors.ContainsKey(personA) OrElse Not neighbors.ContainsKey(personB) Then
            Return -1
        End If
        
        Dim queue As New Queue(Of (Person As String, Degree As Integer))()
        queue.Enqueue((personA, 0))
        Dim visited As New HashSet(Of String)() From {personA}
        
        While queue.Count > 0
            Dim current = queue.Dequeue()
            Dim currentPerson = current.Person
            Dim degree = current.Degree
            
            If currentPerson = personB Then
                Return degree
            End If
            
            Dim unvisited = neighbors(currentPerson).Except(visited)
            For Each neighbor In unvisited
                queue.Enqueue((Person:=neighbor, Degree:=degree + 1))
            Next
            visited.Union(unvisited)
        End While
        
        Return -1
    End Function
End Module
