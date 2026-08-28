Public Class CustomSet
    Implements IEquatable(Of CustomSet)

    Private ReadOnly values As Integer()

    Public Sub New(ParamArray values As Integer())
        Me.values = values.Distinct().Order().ToArray()
    End Sub

    Public Function Add(ByVal value As Integer) As CustomSet
        Return New CustomSet(values.Append(value).ToArray())
    End Function

    Public Function Empty() As Boolean
        Return values.Length = 0
    End Function

    Public Function Contains(ByVal value As Integer) As Boolean
        Return Array.BinarySearch(values, value) >= 0
    End Function

    Public Function Subset(ByVal other As CustomSet) As Boolean
        Return values.All(AddressOf other.Contains)
    End Function

    Public Function Disjoint(ByVal other As CustomSet) As Boolean
        Return Not values.Any(AddressOf other.Contains)
    End Function

    Public Function Intersection(ByVal other As CustomSet) As CustomSet
        Return New CustomSet(values.Where(AddressOf other.Contains).ToArray())
    End Function

    Public Function Difference(ByVal other As CustomSet) As CustomSet
        Return New CustomSet(values.Where(Function(value) Not other.Contains(value)).ToArray())
    End Function

    Public Function Union(ByVal other As CustomSet) As CustomSet
        Return New CustomSet(values.Concat(other.values).ToArray())
    End Function

    Public Overloads Function Equals(ByVal other As CustomSet) As Boolean Implements IEquatable(Of CustomSet).Equals
        Return other IsNot Nothing AndAlso values.SequenceEqual(other.values)
    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        Return Equals(TryCast(obj, CustomSet))
    End Function

    Public Overrides Function GetHashCode() As Integer
        Dim hash = New HashCode()

        For Each value In values
            hash.Add(value)
        Next

        Return hash.ToHashCode()
    End Function
End Class
