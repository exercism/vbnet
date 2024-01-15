Imports System.Collections.Generic

Public Module Etl
    Public Function Transform(ByVal old As Dictionary(Of Integer, String())) As Dictionary(Of String, Integer)
        Dim transformed = New Dictionary(Of String, Integer)()

        For Each pair In old
            For Each item In pair.Value
                transformed.Add(item.ToLower(), pair.Key)
            Next
        Next

        Return transformed
    End Function
End Module
