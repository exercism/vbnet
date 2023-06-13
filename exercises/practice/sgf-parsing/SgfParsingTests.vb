Imports System
Imports System.Collections.Generic
Imports Xunit

Public Class SgfParsingTests
    <Fact>
    Public Sub Empty_input()
        Dim encoded = ""
        Assert.Throws(Of ArgumentException)(Function() SgfParser.ParseTree(encoded))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Tree_with_no_nodes()
        Dim encoded = "()"
        Assert.Throws(Of ArgumentException)(Function() SgfParser.ParseTree(encoded))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Node_without_tree()
        Dim encoded = ";"
        Assert.Throws(Of ArgumentException)(Function() SgfParser.ParseTree(encoded))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Node_without_properties()
        Dim encoded = "(;)"
        Dim expected = New SgfTree(New Dictionary(Of String, String())())
        Me.AssertEqual(expected, SgfParser.ParseTree(encoded))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Single_node_tree()
        Dim encoded = "(;A[B])"
        Dim expected = New SgfTree(New Dictionary(Of String, String()) From {
            {"A",
            {"B"}}
        })
        Me.AssertEqual(expected, SgfParser.ParseTree(encoded))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_properties()
        Dim encoded = "(;A[b]C[d])"
        Dim expected = New SgfTree(New Dictionary(Of String, String()) From {
            {"A",
            {"b"}},
            {"C",
            {"d"}}
        })
        Me.AssertEqual(expected, SgfParser.ParseTree(encoded))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Properties_without_delimiter()
        Dim encoded = "(;A)"
        Assert.Throws(Of ArgumentException)(Function() SgfParser.ParseTree(encoded))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub All_lowercase_property()
        Dim encoded = "(;a[b])"
        Assert.Throws(Of ArgumentException)(Function() SgfParser.ParseTree(encoded))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Upper_and_lowercase_property()
        Dim encoded = "(;Aa[b])"
        Assert.Throws(Of ArgumentException)(Function() SgfParser.ParseTree(encoded))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_nodes()
        Dim encoded = "(;A[B];B[C])"
        Dim expected = New SgfTree(New Dictionary(Of String, String()) From {
            {"A",
            {"B"}}
        }, New SgfTree(New Dictionary(Of String, String()) From {
            {"B",
            {"C"}}
        }))
        Me.AssertEqual(expected, SgfParser.ParseTree(encoded))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_child_trees()
        Dim encoded = "(;A[B](;B[C])(;C[D]))"
        Dim expected = New SgfTree(New Dictionary(Of String, String()) From {
            {"A",
            {"B"}}
        }, New SgfTree(New Dictionary(Of String, String()) From {
            {"B",
            {"C"}}
        }), New SgfTree(New Dictionary(Of String, String()) From {
            {"C",
            {"D"}}
        }))
        Me.AssertEqual(expected, SgfParser.ParseTree(encoded))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_property_values()
        Dim encoded = "(;A[b][c][d])"
        Dim expected = New SgfTree(New Dictionary(Of String, String()) From {
            {"A",
            {"b", "c", "d"}}
        })
        Me.AssertEqual(expected, SgfParser.ParseTree(encoded))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Semicolon_in_property_value_doesnt_need_to_be_escaped()
        Dim encoded = "(;A[a;b][foo]B[bar];C[baz])"
        Dim expected = New SgfTree(New Dictionary(Of String, String()) From {
            {"A",
            {"a;b", "foo"}},
            {"B",
            {"bar"}}
        }, New SgfTree(New Dictionary(Of String, String()) From {
            {"C",
            {"baz"}}
        }))
        Me.AssertEqual(expected, SgfParser.ParseTree(encoded))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Parentheses_in_property_value_dont_need_to_be_escaped()
        Dim encoded = "(;A[x(y)z][foo]B[bar];C[baz])"
        Dim expected = New SgfTree(New Dictionary(Of String, String()) From {
            {"A",
            {"x(y)z", "foo"}},
            {"B",
            {"bar"}}
        }, New SgfTree(New Dictionary(Of String, String()) From {
            {"C",
            {"baz"}}
        }))
        Me.AssertEqual(expected, SgfParser.ParseTree(encoded))
    End Sub

    Private Sub AssertEqual(ByVal expected As SgfTree, ByVal actual As SgfTree)
        Assert.Equal(expected.Data, actual.Data)
        Assert.Equal(expected.Children.Length, actual.Children.Length)
        For i = 0 To expected.Children.Length - 1
            AssertEqual(expected.Children(i), actual.Children(i))
        Next
    End Sub
End Class
