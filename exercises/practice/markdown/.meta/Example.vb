Imports System
Imports System.Linq
Imports System.Text.RegularExpressions
Imports System.Runtime.CompilerServices

Public Module Markdown
    Private Function OpeningTag(ByVal tag As String) As String
        Return $"<{tag}>"
    End Function
    Private Function ClosingTag(ByVal tag As String) As String
        Return $"</{tag}>"
    End Function
    <Extension()>
    Private Function WrapInTag(ByVal text As String, ByVal tag As String) As String
        Return $"{OpeningTag(tag)}{text}{ClosingTag(tag)}"
    End Function
    <Extension()>
    Private Function StartsWithTag(ByVal text As String, ByVal tag As String) As Boolean
        Return text.StartsWith(OpeningTag(tag))
    End Function

    Private Const HeaderMarkdown As String = "#"
    Private Const BoldMarkdown As String = "__"
    Private Const ItalicMarkdown As String = "_"
    Private Const ListItemMarkdown As String = "*"

    Private Const BoldTag As String = "strong"
    Private Const ItalicTag As String = "em"
    Private Const ParagraphTag As String = "p"
    Private Const ListTag As String = "ul"
    Private Const ListItemTag As String = "li"

    <Extension()>
    Private Function ParseDelimited(ByVal markdown As String, ByVal delimiter As String, ByVal tag As String) As String
        Dim pattern = $"{delimiter}(.+){delimiter}"
        Dim replacement = "$1".WrapInTag(tag)
        Return Regex.Replace(markdown, pattern, replacement)
    End Function

    <Extension()>
    Private Function ParseBold(ByVal markdown As String) As String
        Return markdown.ParseDelimited(Markdown.BoldMarkdown, Markdown.BoldTag)
    End Function
    <Extension()>
    Private Function ParseItalic(ByVal markdown As String) As String
        Return markdown.ParseDelimited(Markdown.ItalicMarkdown, Markdown.ItalicTag)
    End Function

    <Extension()>
    Private Function ParseText(ByVal markdown As String, ByVal list As Boolean) As String
        Dim textHtml = Markdown.ParseBold(markdown).ParseItalic()

        Return If(list, textHtml, textHtml.WrapInTag(Markdown.ParagraphTag))
    End Function

    <Extension()>
    Private Function ParseHeader(ByVal markdown As String, ByVal list As Boolean) As Tuple(Of Boolean, String)
        Dim headerNumber = markdown.TakeWhile(Function(c) c = Markdown.HeaderMarkdown(0)).Count()

        If headerNumber = 0 OrElse headerNumber > 6 Then Return Nothing

        Dim headerTag = $"h{headerNumber}"
        Dim headerHtml = markdown.Substring(headerNumber + 1).WrapInTag(headerTag)
        Dim html = If(list, Markdown.ClosingTag(Markdown.ListTag) & headerHtml, headerHtml)

        Return Tuple.Create(False, html)
    End Function

    <Extension()>
    Private Function ParseLineItem(ByVal markdown As String, ByVal list As Boolean) As Tuple(Of Boolean, String)
        If Not markdown.StartsWith(Markdown.ListItemMarkdown) Then Return Nothing

        Dim innerHtml = markdown.Substring(2).ParseText(True).WrapInTag(Markdown.ListItemTag)

        Dim html = If(list, innerHtml, Markdown.OpeningTag(Markdown.ListTag) & innerHtml)
        Return Tuple.Create(True, html)
    End Function

    <Extension()>
    Private Function ParseParagraph(ByVal markdown As String, ByVal list As Boolean) As Tuple(Of Boolean, String)
        If list Then Return Tuple.Create(False, Markdown.ClosingTag(Markdown.ListTag) & markdown.ParseText(False).ToString())

        Return Tuple.Create(False, markdown.ParseText(list))
    End Function

    Private Function ParseLine(ByVal accumulator As Tuple(Of Boolean, String), ByVal markdown As String) As Tuple(Of Boolean, String)
        Dim list = accumulator.Item1
        Dim html = accumulator.Item2

        Dim result = If(markdown.ParseHeader(list), If(markdown.ParseLineItem(list), markdown.ParseParagraph(list)))

        If result Is Nothing Then Throw New ArgumentException("Invalid markdown")

        Return Tuple.Create(result.Item1, html & result.Item2)
    End Function

    Public Function Parse(ByVal markdown As String) As String
        Dim lines = markdown.Split(ChrW(10))
        Dim result = lines.Aggregate(Tuple.Create(False, ""), New Func(Of Tuple(Of Boolean, String), String, Tuple(Of Boolean, String))(AddressOf Markdown.ParseLine))

        Dim list = result.Item1
        Dim html = result.Item2

        Return If(list, html & Markdown.ClosingTag(Markdown.ListTag), html)
    End Function
End Module
