Imports Xunit

Public Class MarkdownTests
    <Fact>
    Public Sub Parses_normal_text_as_a_paragraph()
        Dim markdown = "This will be a paragraph"
        Dim expected = "<p>This will be a paragraph</p>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub

    <Fact>
    Public Sub Parsing_italics()
        Dim markdown = "_This will be italic_"
        Dim expected = "<p><em>This will be italic</em></p>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub

    <Fact>
    Public Sub Parsing_bold_text()
        Dim markdown = "__This will be bold__"
        Dim expected = "<p><strong>This will be bold</strong></p>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub

    <Fact>
    Public Sub Mixed_normal_italics_and_bold_text()
        Dim markdown = "This will _be_ __mixed__"
        Dim expected = "<p>This will <em>be</em> <strong>mixed</strong></p>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub

    <Fact>
    Public Sub With_h1_header_level()
        Dim markdown = "# This will be an h1"
        Dim expected = "<h1>This will be an h1</h1>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub

    <Fact>
    Public Sub With_h2_header_level()
        Dim markdown = "## This will be an h2"
        Dim expected = "<h2>This will be an h2</h2>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub

    <Fact>
    Public Sub With_h3_header_level()
        Dim markdown = "### This will be an h3"
        Dim expected = "<h3>This will be an h3</h3>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub

    <Fact>
    Public Sub With_h4_header_level()
        Dim markdown = "#### This will be an h4"
        Dim expected = "<h4>This will be an h4</h4>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub

    <Fact>
    Public Sub With_h5_header_level()
        Dim markdown = "##### This will be an h5"
        Dim expected = "<h5>This will be an h5</h5>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub

    <Fact>
    Public Sub With_h6_header_level()
        Dim markdown = "###### This will be an h6"
        Dim expected = "<h6>This will be an h6</h6>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub

    <Fact>
    Public Sub H7_header_level_is_a_paragraph()
        Dim markdown = "####### This will not be an h7"
        Dim expected = "<p>####### This will not be an h7</p>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub

    <Fact>
    Public Sub Unordered_lists()
        Dim markdown = "* Item 1" & vbLf & "* Item 2"
        Dim expected = "<ul><li>Item 1</li><li>Item 2</li></ul>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub

    <Fact>
    Public Sub With_a_little_bit_of_everything()
        Dim markdown = "# Header!" & vbLf & "* __Bold Item__" & vbLf & "* _Italic Item_"
        Dim expected = "<h1>Header!</h1><ul><li><strong>Bold Item</strong></li><li><em>Italic Item</em></li></ul>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub

    <Fact>
    Public Sub With_markdown_symbols_in_the_header_text_that_should_not_be_interpreted()
        Dim markdown = "# This is a header with # and * in the text"
        Dim expected = "<h1>This is a header with # and * in the text</h1>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub

    <Fact>
    Public Sub With_markdown_symbols_in_the_list_item_text_that_should_not_be_interpreted()
        Dim markdown = "* Item 1 with a # in the text" & vbLf & "* Item 2 with * in the text"
        Dim expected = "<ul><li>Item 1 with a # in the text</li><li>Item 2 with * in the text</li></ul>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub

    <Fact>
    Public Sub With_markdown_symbols_in_the_paragraph_text_that_should_not_be_interpreted()
        Dim markdown = "This is a paragraph with # and * in the text"
        Dim expected = "<p>This is a paragraph with # and * in the text</p>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub

    <Fact>
    Public Sub Unordered_lists_close_properly_with_preceding_and_following_lines()
        Dim markdown = "# Start a list" & vbLf & "* Item 1" & vbLf & "* Item 2" & vbLf & "End a list"
        Dim expected = "<h1>Start a list</h1><ul><li>Item 1</li><li>Item 2</li></ul><p>End a list</p>"
        Assert.Equal(expected, Markdown.Parse(markdown))
    End Sub
End Class
