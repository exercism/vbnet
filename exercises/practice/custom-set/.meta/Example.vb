Imports System.Collections.Generic
Imports System.Linq

Public Class CustomSet
    Private ReadOnly items As SortedDictionary(Of Integer, Integer) = New SortedDictionary(Of Integer, Integer)()

    Public Sub New(ParamArray values As Integer())
        For Each value In values.Where(Function(value) Not items.ContainsKey(value.GetHashCode()))
            items.Add(value.GetHashCode(), value)
        Next
    End Sub

    Public Function Add(ByVal value As Integer) As CustomSet
        Return New CustomSet(items.Values.Append(value).ToArray())
    End Function

    Public Function Empty() As Boolean
        Return items.Count = 0
    End Function

    Public Function Contains(ByVal value As Integer) As Boolean
        Return items.ContainsKey(value.GetHashCode())
    End Function

    Public Function Subset(ByVal right As CustomSet) As Boolean
        Return items.Keys.All(Function(key) right.items.ContainsKey(key))
    End Function

    Public Function Disjoint(ByVal right As CustomSet) As Boolean
        Return Not items.Keys.Any(Function(key) right.items.ContainsKey(key))
    End Function

    Public Function Intersection(ByVal right As CustomSet) As CustomSet
        Dim intersectionKeys = items.Keys.Intersect(right.items.Keys)
        Return New CustomSet(GetValuesFromKeys(intersectionKeys))
    End Function

    Public Function Difference(ByVal right As CustomSet) As CustomSet
        Dim differenceKeys = items.Keys.Except(right.items.Keys)
        Return New CustomSet(GetValuesFromKeys(differenceKeys))
    End Function

    Public Function Union(ByVal right As CustomSet) As CustomSet
        Return New CustomSet(items.Values.Concat(right.items.Values).ToArray())
    End Function

    Private Function GetValuesFromKeys(ByVal keys As IEnumerable(Of Integer)) As Integer()
        Return keys.[Select](Function(key) items(key)).ToArray()
    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        Dim other As CustomSet = Nothing

        If Not (CSharpImpl.__Assign(other, TryCast(obj, CustomSet)) IsNot Nothing) Then
            Return False
        End If

        Return items.Keys.SequenceEqual(other.items.Keys)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return items.GetHashCode()
    End Function

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Class
