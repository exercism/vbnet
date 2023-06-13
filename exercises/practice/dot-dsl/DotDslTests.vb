Imports System
Imports System.Collections.Generic
Imports Xunit

Public Class DotDslTests
    <Fact>
    Public Sub Empty_graph()
        Dim g = New Graph()

        Assert.Empty(g.Nodes)
        Assert.Empty(g.Edges)
        Assert.Empty(g.Attrs)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Graph_with_one_node()
        Dim g = New Graph From {
    New Node("a")
}

        Assert.Equal({New Node("a")}, g.Nodes)
        Assert.Empty(g.Edges)
        Assert.Empty(g.Attrs)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Graph_with_one_node_with_keywords()
        Dim g = New Graph From {
    New Node("a") From {
        {"color", "green"}
    }
}

        Assert.Equal({New Node("a") From {
            {"color", "green"}
        }}, g.Nodes)
        Assert.Empty(g.Edges)
        Assert.Empty(g.Attrs)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Graph_with_one_edge()
        Dim g = New Graph From {
    New Edge("a", "b")
}

        Assert.Empty(g.Nodes)
        Assert.Equal({New Edge("a", "b")}, g.Edges)
        Assert.Empty(g.Attrs)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Graph_with_one_attribute()
        Dim g = New Graph From {
    {"foo", "1"}
}

        Assert.Empty(g.Nodes)
        Assert.Empty(g.Edges)
        Assert.Equal({New Attr("foo", "1")}, g.Attrs)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Graph_with_attributes()
        Dim g = New Graph From {
    {"foo", "1"},
    {"title", "Testing Attrs"},
    New Node("a") From {
        {"color", "green"}
    },
    New Node("c"),
    New Node("b") From {
        {"label", "Beta!"}
    },
    New Edge("b", "c"),
    New Edge("a", "b") From {
        {"color", "blue"}
    },
    {"bar", "true"}
}

        Assert.Equal({New Node("a") From {
            {"color", "green"}
        }, New Node("b") From {
            {"label", "Beta!"}
        }, New Node("c")}, g.Nodes, EnumerableEqualityComparer(Of Node).Instance)
        Assert.Equal({New Edge("a", "b") From {
            {"color", "blue"}
        }, New Edge("b", "c")}, g.Edges, EnumerableEqualityComparer(Of Edge).Instance)
        Assert.Equal({New Attr("bar", "true"), New Attr("foo", "1"), New Attr("title", "Testing Attrs")}, g.Attrs, EnumerableEqualityComparer(Of Attr).Instance)
    End Sub

    Private Class EnumerableEqualityComparer(Of T)
        Implements IEqualityComparer(Of IEnumerable(Of T))
        Public ReadOnly Instance As EnumerableEqualityComparer(Of T) = New EnumerableEqualityComparer(Of T)()

        Public Function Equals(ByVal x As IEnumerable(Of T), ByVal y As IEnumerable(Of T)) As Boolean Implements IEqualityComparer(Of IEnumerable(Of T)).Equals
            Return New HashSet(Of T)(x).SetEquals(y)
        End Function

        Public Function GetHashCode(ByVal obj As IEnumerable(Of T)) As Integer Implements IEqualityComparer(Of IEnumerable(Of T)).GetHashCode
            Throw New NotImplementedException()
        End Function
    End Class
End Class
