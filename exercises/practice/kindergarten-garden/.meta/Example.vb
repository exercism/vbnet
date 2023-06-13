Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Enum Plant
    Violets
    Radishes
    Clover
    Grass
End Enum

Public Class KindergartenGarden
    Private Const PlantsPerChildPerRow As Integer = 2
    Private Const RowSeparator As Char = ChrW(10)

    Private Shared ReadOnly DefaultChildren As String() = {"Alice", "Bob", "Charlie", "David", "Eve", "Fred", "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry"}

    Private Shared ReadOnly PlantCodesToPlants As IDictionary(Of Char, Plant) = New Dictionary(Of Char, Plant) From {
    {"V"c, Plant.Violets},
    {"R"c, Plant.Radishes},
    {"C"c, Plant.Clover},
    {"G"c, Plant.Grass}
}

    Private ReadOnly plantsByChild As IDictionary(Of String, IEnumerable(Of Plant))

    Public Sub New(ByVal diagram As String)
        Me.New(diagram, DefaultChildren)
    End Sub

    Public Sub New(ByVal diagram As String, ByVal students As IEnumerable(Of String))
        Dim plantsPerChild = KindergartenGarden.PlantsPerChild(diagram)
        plantsByChild = students.OrderBy(Function(c) c).Zip(plantsPerChild, New Func(Of String, IEnumerable(Of Plant), Tuple(Of String, IEnumerable(Of Plant)))(AddressOf Tuple.Create)).ToDictionary(Function(kv) kv.Item1, Function(kv) kv.Item2)
    End Sub

    Public Function Plants(ByVal child As String) As IEnumerable(Of Plant)
        Return If(plantsByChild.ContainsKey(child), plantsByChild(child), Enumerable.Empty(Of Plant)())
    End Function

    Private Shared Function PlantFromCode(ByVal code As Char) As Plant
        Return PlantCodesToPlants(code)
    End Function

    Private Shared Function PlantsPerChild(ByVal windowSills As String) As IEnumerable(Of IEnumerable(Of Plant))
        Dim row = windowSills.Split(RowSeparator).[Select](New Func(Of String, IEnumerable(Of IEnumerable(Of Plant)))(AddressOf PlantsInRow)).ToArray()
        Return row(0).Zip(row(1), Function(row1Plants, row2Plants) row1Plants.Concat(row2Plants))
    End Function

    Private Shared Function PlantsInRow(ByVal row As String) As IEnumerable(Of IEnumerable(Of Plant))
        Return Partition(row.[Select](New Func(Of Char, Plant)(AddressOf PlantFromCode)), PlantsPerChildPerRow)
    End Function

    Private Shared Function Partition(Of T)(ByVal input As IEnumerable(Of T), ByVal partitionSize As Integer) As IEnumerable(Of IEnumerable(Of T))
        Return input.Select(Function(item, inx) New With {item, inx
                                        }).GroupBy(Function(x) x.inx / partitionSize).Select(Function(g) g.Select(Function(x) x.item))
    End Function
End Class
