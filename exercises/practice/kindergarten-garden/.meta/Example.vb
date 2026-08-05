Public Enum Plant
    Clover
    Grass
    Radishes
    Violets
End Enum

Public Class KindergartenGarden
    Private Shared ReadOnly Students = {
        "Alice",
        "Bob",
        "Charlie",
        "David",
        "Eve",
        "Fred",
        "Ginny",
        "Harriet",
        "Ileana",
        "Joseph",
        "Kincaid",
        "Larry"}
    Private ReadOnly _rows As String()

    Public Sub New(ByVal diagram As String)
        Me._rows = diagram.Split(vbLf)
    End Sub

    Public Function Plants(ByVal student As String) As IEnumerable(Of Plant)
        Dim cupIndex = Array.IndexOf(Students, student) * 2

        Return Me._rows.
            SelectMany(Function(row) row.Substring(cupIndex, 2)).
            Select(AddressOf ToPlant).
            ToArray()
    End Function

    Private Function ToPlant(ByVal plantCode As Char) As Plant
        Select Case plantCode
            Case "C"c
                Return Plant.Clover
            Case "G"c
                Return Plant.Grass
            Case "R"c
                Return Plant.Radishes
            Case Else
                Return Plant.Violets
        End Select
    End Function
End Class
