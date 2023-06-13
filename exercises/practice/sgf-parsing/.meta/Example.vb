Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports Sprache

Public Class SgfTree
    Implements IEquatable(Of SgfTree)
    Public ReadOnly Property Data As IDictionary(Of String, String())
    Public ReadOnly Property Children As SgfTree()

    Public Sub New(ByVal data As IDictionary(Of String, String()), ParamArray children As SgfTree())
        Me.Data = data
        Me.Children = children
    End Sub

    Public Function Equals(ByVal other As SgfTree) As Boolean Implements IEquatable(Of SgfTree).Equals
        Dim otherData = other.Data

        For Each d In Data
            If Not d.Value.SequenceEqual(otherData.Where(Function(od) Equals(od.Key, d.Key))?.FirstOrDefault(Of KeyValuePair(Of Global.System.[String], Global.System.[String]()))().Value) Then Return False
        Next

        If Children IsNot Nothing Then
            If Not Children.SequenceEqual(other.Children) Then Return False
        End If

        Return True
    End Function
End Class

Public Module SgfParser
    Private Function ToString(ByVal chars As IEnumerable(Of Char)) As String
        Return New String(chars.ToArray())
    End Function
    Private Function ToString(ByVal c As Char) As String
        Return c.ToString()
    End Function

    Private Function Unescape(ByVal c As Char) As Char
        Return If(c = "n"c, ChrW(10), If(c = "r"c OrElse c = "t"c, " "c, If(c = "]"c, "]"c, c)))
    End Function

    Private ReadOnly NormalChar As Parser(Of Char) = Parse.Char(Function(c) c <> "\"c AndAlso c <> "]"c, "Normal char")
    Private ReadOnly EscapedChar As Parser(Of Char) = Parse.Char("\"c).[Then](Function(__) Parse.AnyChar.[Select](New Func(Of Char, Char)(AddressOf SgfParser.Unescape)))
    Private ReadOnly CValueType As Parser(Of String) = SgfParser.EscapedChar.[Or](SgfParser.NormalChar).Many().[Select](New Func(Of IEnumerable(Of Char), String)(AddressOf SgfParser.ToString))

    Private Function Value() As Parser(Of String)
        Return SgfParser.CValueType.Contained(Parse.Char("["c), Parse.Char("]"c))
    End Function

    Private Function [Property]() As Parser(Of KeyValuePair(Of String, String()))
        Return From key In Parse.Upper.[Select](New Func(Of Char, String)(AddressOf SgfParser.ToString)) From values In SgfParser.Value().AtLeastOnce().[Select](Function(values) values.ToArray()) Select New KeyValuePair(Of String, String())(key, values)
    End Function

    Private Function Properties() As Parser(Of Dictionary(Of String, String()))
        Return From properties In SgfParser.Property().Many().[Select](Function(properties) properties.ToArray()) Select New Dictionary(Of String, String())(properties)
    End Function

    Private Function Node() As Parser(Of Dictionary(Of String, String()))
        Return From __ In Parse.Char(";"c) From properties In SgfParser.Properties() Select properties
    End Function

    Private Function Tree() As Parser(Of SgfTree)
        Return From open In Parse.Char("("c) From nodes In SgfParser.Node().Many() From children In SgfParser.Tree().Many() From close In Parse.Char(")"c) Select SgfParser.NodesToTree(nodes, children)
    End Function

    Public Function ParseTree(ByVal input As String) As SgfTree
        Try
            Return SgfParser.Tree().Parse(input)
        Catch e As Exception
            Throw New ArgumentException(NameOf(input), e)
        End Try
    End Function

    Private Function NodesToTree(ByVal properties As IEnumerable(Of IDictionary(Of String, String())), ByVal trees As IEnumerable(Of SgfTree)) As SgfTree
        Dim numberOfProperties = properties.Count()

        If numberOfProperties = 0 Then
            Throw New InvalidOperationException("Can only create tree from non-empty nodes list")
        End If

        If numberOfProperties = 1 Then
            Return New SgfTree(properties.First(), trees.ToArray())
        End If

        Return New SgfTree(properties.First(), SgfParser.NodesToTree(properties.Skip(1), trees))
    End Function
End Module
