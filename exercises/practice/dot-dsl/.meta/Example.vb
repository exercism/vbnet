Imports System.Collections
Imports System.Collections.Generic

Public Class Node
    Inherits Element
    Public Sub New(ByVal name As String)
        Me.Name = name
    End Sub

    Public ReadOnly Property Name As String

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If obj Is Nothing OrElse [GetType]() IsNot obj.GetType() Then Return False

        Return Equals(CType(obj, Node).Name, Name)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return Name.GetHashCode()
    End Function
End Class

Public Class Edge
    Inherits Element
    Public Sub New(ByVal node1 As String, ByVal node2 As String)
        Me.Node1 = node1
        Me.Node2 = node2
    End Sub

    Public ReadOnly Property Node1 As String
    Public ReadOnly Property Node2 As String

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If obj Is Nothing OrElse [GetType]() IsNot obj.GetType() Then Return False

        Return Equals(CType(obj, Edge).Node1, Node1) AndAlso Equals(CType(obj, Edge).Node2, Node2)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return Node1.GetHashCode() Xor Node2.GetHashCode()
    End Function
End Class


Public Class Attr
    Public Sub New(ByVal key As String, ByVal value As String)
        Me.Key = key
        Me.Value = value
    End Sub

    Public ReadOnly Property Key As String
    Public ReadOnly Property Value As String

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If obj Is Nothing OrElse [GetType]() IsNot obj.GetType() Then Return False

        Return Equals(CType(obj, Attr).Key, Key) AndAlso Equals(CType(obj, Attr).Value, Value)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return Key.GetHashCode() Xor Value.GetHashCode()
    End Function
End Class

Public Class Graph
    Inherits Element
    Private nodesField As List(Of Node) = New List(Of Node)()
    Private edgesField As List(Of Edge) = New List(Of Edge)()

    Public ReadOnly Property Nodes As IEnumerable(Of Node)
        Get
            Return nodesField
        End Get
    End Property
    Public ReadOnly Property Edges As IEnumerable(Of Edge)
        Get
            Return edgesField
        End Get
    End Property
    Public ReadOnly Property Attrs As IEnumerable(Of Attr)
        Get
            Return MyBase.attrs
        End Get
    End Property

    Public Sub Add(ByVal node As Node)
        nodesField.Add(node)
    End Sub
    Public Sub Add(ByVal edge As Edge)
        edgesField.Add(edge)
    End Sub
End Class

Public MustInherit Class Element
    Implements IEnumerable(Of Attr)
    Protected attrs As List(Of Attr) = New List(Of Attr)()

    Public Sub Add(ByVal key As String, ByVal value As String)
        attrs.Add(New Attr(key, value))
    End Sub

    Public Function GetEnumerator() As IEnumerator(Of Attr) Implements IEnumerable(Of Attr).GetEnumerator
        Return attrs.GetEnumerator()
    End Function
    Private Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
        Return GetEnumerator()
    End Function
End Class
