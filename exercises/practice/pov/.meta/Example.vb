Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Class Tree
    Implements IEquatable(Of Tree)
    Public Sub New(ByVal value As String, ParamArray children As Tree())
        CSharpImpl.__Assign((Me.Value, Me.Children), (value, children))
    End Sub

    Public ReadOnly Property Value As String
    Public ReadOnly Property Children As Tree()

    Public Function Equals(ByVal other As Tree) As Boolean Implements IEquatable(Of Tree).Equals
        Return Value.Equals(other.Value) AndAlso Children.OrderBy(Function(child) child.Value).SequenceEqual(other.Children.OrderBy(Function(child) child.Value))
    End Function

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Class

Public Class TreeCrumb
    Public Sub New(ByVal value As String, ByVal left As IEnumerable(Of Tree), ByVal right As IEnumerable(Of Tree))
        CSharpImpl.__Assign((Me.Value, Me.Left, Me.Right), (value, left, right))
    End Sub

    Public ReadOnly Property Value As String
    Public ReadOnly Property Left As IEnumerable(Of Tree)
    Public ReadOnly Property Right As IEnumerable(Of Tree)

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Class

Public Class TreeZipper
    Public Sub New(ByVal focus As Tree, ByVal crumbs As IEnumerable(Of TreeCrumb))
        CSharpImpl.__Assign((Me.Focus, Me.Crumbs), (focus, crumbs))
    End Sub

    Public ReadOnly Property Focus As Tree
    Public ReadOnly Property Crumbs As IEnumerable(Of TreeCrumb)

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Class

Public Module Pov
    Public Function FromPov(ByVal graph As Tree, ByVal value As String) As Tree
        Dim zipper = FindNode(value, GraphToZipper(graph))
        If zipper Is Nothing Then Throw New ArgumentException()

        Return ChangeParent(zipper)
    End Function

    Public Function PathTo(ByVal value1 As String, ByVal value2 As String, ByVal graph As Tree) As IEnumerable(Of String)
        Dim zipper = FindNode(value2, GraphToZipper(FromPov(graph, value1)))
        If zipper Is Nothing Then Throw New ArgumentException()

        Return ZipperToPath(zipper)
    End Function

    Private Function GraphToZipper(ByVal graph As Tree) As TreeZipper
        If graph Is Nothing Then Return Nothing

        Return New TreeZipper(graph, Enumerable.Empty(Of TreeCrumb)())
    End Function

    Private Function ZipperToPath(ByVal zipper As TreeZipper) As IEnumerable(Of String)
        Return zipper?.Crumbs.[Select](Function(c) c.Value).Reverse().Concat({zipper.Focus.Value})
    End Function

    Private Function GoDown(ByVal zipper As TreeZipper) As TreeZipper
        If zipper Is Nothing OrElse Not zipper.Focus.Children.Any() Then Return Nothing

        Dim focus = zipper.Focus
        Dim children = focus.Children

        Dim newCrumb = New TreeCrumb(focus.Value, Array.Empty(Of Tree)(), children.Skip(1).ToArray())

        Return New TreeZipper(children.First(), {newCrumb}.Concat(zipper.Crumbs))
    End Function

    Private Function GoRight(ByVal zipper As TreeZipper) As TreeZipper
        If zipper Is Nothing OrElse Not zipper.Crumbs.Any() OrElse Not Enumerable.First(zipper.Crumbs).Right.Any() Then Return Nothing

        Dim crumbs = zipper.Crumbs
        Dim firstCrumb = crumbs.First()

        Dim newCrumb = New TreeCrumb(firstCrumb.Value, firstCrumb.Left.Concat({zipper.Focus}).ToArray(), firstCrumb.Right.Skip(1).ToArray())

        Return New TreeZipper(firstCrumb.Right.First(), {newCrumb}.Concat(crumbs.Skip(1)))
    End Function

    Private Function FindNode(ByVal value As String, ByVal zipper As TreeZipper) As TreeZipper
        If zipper Is Nothing OrElse zipper.Focus.Value.CompareTo(value) = 0 Then Return zipper

        Return If(FindNode(value, GoDown(zipper)), FindNode(value, GoRight(zipper)))
    End Function

    Private Function ChangeParent(ByVal zipper As TreeZipper) As Tree
        If zipper Is Nothing Then Return Nothing

        If Not zipper.Crumbs.Any() Then Return zipper.Focus

        Dim firstCrumb = zipper.Crumbs.First()
        Dim focus = zipper.Focus

        Dim newZipper = New TreeZipper(New Tree(firstCrumb.Value, firstCrumb.Left.Concat(firstCrumb.Right).ToArray()), zipper.Crumbs.Skip(1))
        Dim parentGraph = ChangeParent(newZipper)

        Dim ys = focus.Children.Concat({parentGraph}).ToArray()
        Return New Tree(focus.Value, ys)
    End Function
End Module
