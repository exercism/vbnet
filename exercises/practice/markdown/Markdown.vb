Imports System
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices

Public Module Markdown
    Private Function Wrap(ByVal text As String, ByVal tag As String) As String
        Return "<" & tag & ">" & text & "</" & tag & ">"
    End Function

    Private Function IsTag(ByVal text As String, ByVal tag As String) As Boolean
        Return text.StartsWith("<" & tag & ">")
    End Function

    Private Function Parse(ByVal markdown As String, ByVal delimiter As String, ByVal tag As String) As String
        Dim pattern = delimiter & "(.+)" & delimiter
        Dim replacement = "<" & tag & ">$1</" & tag & ">"
        Return Regex.Replace(markdown, pattern, replacement)
    End Function

    Private Function Parse__(ByVal markdown As String) As String
        Return Markdown.Parse(markdown, "__", "strong")
    End Function

    Private Function Parse_(ByVal markdown As String) As String
        Return Markdown.Parse(markdown, "_", "em")
    End Function

    Private Function ParseText(ByVal markdown As String, ByVal list As Boolean) As String
        Dim parsedText = Markdown.Parse_(Markdown.Parse__(markdown))

        If list Then
            Return parsedText
        Else
            Return Markdown.Wrap(parsedText, "p")
        End If
    End Function

    Private Function ParseHeader(ByVal markdown As String, ByVal list As Boolean, <Out> ByRef inListAfter As Boolean) As String
        Dim count = 0

        For i = 0 To markdown.Length - 1
            If markdown(i) = "#"c Then
                count += 1
            Else
                Exit For
            End If
        Next

        If count = 0 OrElse count > 6 Then
            inListAfter = list
            Return Nothing
        End If

        Dim headerTag = "h" & count.ToString()
        Dim headerHtml = Markdown.Wrap(markdown.Substring(count + 1), headerTag)

        If list Then
            inListAfter = False
            Return "</ul>" & headerHtml
        Else
            inListAfter = False
            Return headerHtml
        End If
    End Function

    Private Function ParseLineItem(ByVal markdown As String, ByVal list As Boolean, <Out> ByRef inListAfter As Boolean) As String
        If markdown.StartsWith("*") Then
            Dim innerHtml = Markdown.Wrap(Markdown.ParseText(markdown.Substring(2), True), "li")

            If list Then
                inListAfter = True
                Return innerHtml
            Else
                inListAfter = True
                Return "<ul>" & innerHtml
            End If
        End If

        inListAfter = list
        Return Nothing
    End Function

    Private Function ParseParagraph(ByVal markdown As String, ByVal list As Boolean, <Out> ByRef inListAfter As Boolean) As String
        If Not list Then
            inListAfter = False
            Return Markdown.ParseText(markdown, False)
        Else
            inListAfter = False
            Return "</ul>" & Markdown.ParseText(markdown, False)
        End If
    End Function

    Private Function ParseLine(ByVal markdown As String, ByVal list As Boolean, <Out> ByRef inListAfter As Boolean) As String
        Dim result = Markdown.ParseHeader(markdown, list, inListAfter)

        If Equals(result, Nothing) Then
            result = Markdown.ParseLineItem(markdown, list, inListAfter)
        End If

        If Equals(result, Nothing) Then
            result = Markdown.ParseParagraph(markdown, list, inListAfter)
        End If

        If Equals(result, Nothing) Then
            Throw New ArgumentException("Invalid markdown")
        End If

        Return result
    End Function

    Public Function Parse(ByVal markdown As String) As String
        Dim lines = markdown.Split(ChrW(10))
        Dim result = ""
        Dim list = False

        For i = 0 To lines.Length - 1
            Dim lineResult = Markdown.ParseLine(lines(i), list, list)
            result += lineResult
        Next

        If list Then
            Return result & "</ul>"
        Else
            Return result
        End If
    End Function
End Module
