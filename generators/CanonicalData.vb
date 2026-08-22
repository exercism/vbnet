Imports System.Collections.Immutable

Namespace Global.Exercism.VBNet.Generators
    Friend NotInheritable Class CanonicalData
        Friend Sub New(exercise As Exercise, testCases As JsonNode())
            Me.Exercise = exercise
            Me.TestCases = testCases
        End Sub

        Friend ReadOnly Property Exercise As Exercise
        Friend ReadOnly Property TestCases As JsonNode()
    End Class

    Friend Module CanonicalDataParser
        Friend Function Parse(exercise As Exercise) As CanonicalData
            Dim root = JsonNode.Parse(File.ReadAllText(Paths.CanonicalDataFile(exercise)))

            If root Is Nothing Then
                Throw New InvalidDataException($"Canonical data for '{exercise.Slug}' is empty.")
            End If

            Return New CanonicalData(exercise, ParseTestCases(root))
        End Function

        Friend Function ParseTestCases(root As JsonNode) As JsonNode()
            Return ParseTestCases(root, ImmutableQueue(Of String).Empty).ToArray()
        End Function

        Private Iterator Function ParseTestCases(node As JsonNode, path As ImmutableQueue(Of String)) As IEnumerable(Of JsonNode)
            Dim updatedPath = path
            Dim description = node("description")

            If description IsNot Nothing Then
                updatedPath = updatedPath.Enqueue(description.GetValue(Of String)())
            End If

            Dim cases = node("cases")

            If cases IsNot Nothing Then
                For Each child In cases.AsArray()
                    For Each testCase In ParseTestCases(child, updatedPath)
                        Yield testCase
                    Next
                Next
            Else
                node("path") = JsonSerializer.SerializeToNode(updatedPath)
                Yield node
            End If
        End Function
    End Module
End Namespace
