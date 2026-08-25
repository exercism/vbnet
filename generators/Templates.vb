Imports System.Globalization

Imports Scriban
Imports Scriban.Runtime

Namespace Global.Exercism.VBNet.Generators
    Friend Module Templates
        Friend Function RenderTestsCode(canonicalData As CanonicalData) As String
            Dim templatePath = Paths.TemplateFile(canonicalData.Exercise)
            Return RenderTestsCode(canonicalData, File.ReadAllText(templatePath), templatePath)
        End Function

        Friend Function RenderTestsCode(canonicalData As CanonicalData, templateText As String, Optional templatePath As String = Nothing) As String
            Dim template = ParseTemplate(templateText, templatePath)
            Dim scriptObject = New ScriptObject()
            scriptObject.Import("indent", New Func(Of Integer, String)(AddressOf Indent))
            scriptObject.Import("pascalize", New Func(Of String, String)(Function(text) text.Pascalize()))
            scriptObject.Import("enum", New Func(Of String, String, String)(
                Function(text, enumType) $"{enumType.Pascalize()}.{text.Pascalize()}"))
            scriptObject.Import("property", New Func(Of ScriptArray, String, ScriptArray)(AddressOf FilterByProperty))
            scriptObject.Import("vb_integer_array_literal", New Func(Of ScriptArray, String)(AddressOf VbIntegerArrayLiteral))
            scriptObject.Import("vb_literal", New Func(Of Object, String)(AddressOf VbLiteral))
            scriptObject.Import("vb_multiline_array_literal", New Func(Of ScriptArray, Integer, Integer, String)(AddressOf VbMultilineArrayLiteral))
            scriptObject.Import("vb_multiline_call", New Func(Of String, ScriptArray, Integer, String)(AddressOf VbMultilineCall))
            scriptObject.Import("vb_object_array_literal", New Func(Of ScriptArray, Integer, String)(AddressOf VbObjectArrayLiteral))
            scriptObject.Import("vb_string_join", New Func(Of ScriptArray, String, Integer, String)(AddressOf VbStringJoin))
            scriptObject.Import("vb_string_literal", New Func(Of String, String)(AddressOf VbStringLiteral))
            scriptObject.Import(TemplateData(canonicalData))

            Dim context = New TemplateContext()
            context.PushGlobal(scriptObject)

            Try
                Return template.Render(context)
            Catch exception As Exception
                Dim source = If(templatePath, $"the template for '{canonicalData.Exercise.Slug}'")
                Throw New InvalidDataException($"Could not render {source}: {exception.Message}", exception)
            End Try
        End Function

        Friend Function VbStringLiteral(value As String) As String
            If value Is Nothing Then
                Return "Nothing"
            End If

            Dim parts = New List(Of String)()
            Dim text = New StringBuilder()
            Dim index = 0

            While index < value.Length
                Dim character = value(index)

                If character = ControlChars.Cr AndAlso index + 1 < value.Length AndAlso value(index + 1) = ControlChars.Lf Then
                    FlushText(parts, text)
                    parts.Add("vbCrLf")
                    index += 2
                    Continue While
                End If

                Select Case character
                    Case ControlChars.Cr
                        FlushText(parts, text)
                        parts.Add("vbCr")
                    Case ControlChars.Lf
                        FlushText(parts, text)
                        parts.Add("vbLf")
                    Case ControlChars.Tab
                        FlushText(parts, text)
                        parts.Add("vbTab")
                    Case Else
                        If Char.IsControl(character) Then
                            FlushText(parts, text)
                            parts.Add($"ChrW({AscW(character).ToString(CultureInfo.InvariantCulture)})")
                        Else
                            text.Append(character)
                        End If
                End Select

                index += 1
            End While

            FlushText(parts, text)

            If parts.Count = 0 Then
                Return Quote(String.Empty)
            End If

            Return String.Join(" & ", parts)
        End Function

        Friend Function VbLiteral(value As Object) As String
            If value Is Nothing Then
                Return "Nothing"
            End If

            If TypeOf value Is String Then
                Return VbStringLiteral(DirectCast(value, String))
            End If

            If TypeOf value Is Boolean Then
                Return If(DirectCast(value, Boolean), "True", "False")
            End If

            Dim values = TryCast(value, ScriptArray)

            If values IsNot Nothing Then
                Return "{" & String.Join(", ", values.Select(AddressOf VbLiteral)) & "}"
            End If

            Return Convert.ToString(value, CultureInfo.InvariantCulture)
        End Function

        Friend Function VbIntegerArrayLiteral(values As ScriptArray) As String
            Return "{" & String.Join(", ", values.Select(
                Function(value) Convert.ToInt32(value, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture))) & "}"
        End Function

        Friend Function VbMultilineArrayLiteral(values As ScriptArray, indentLevel As Integer, itemsPerLine As Integer) As String
            Dim items = values.Select(AddressOf VbLiteral).ToArray()

            If items.Length <= itemsPerLine Then
                Return "{" & String.Join(", ", items) & "}"
            End If

            Dim itemIndent = Indent(indentLevel + 1)
            Dim lines = items.
                Select(Function(item, index) New With {item, index}).
                GroupBy(Function(entry) entry.index \ itemsPerLine).
                Select(Function(group) String.Join(", ", group.Select(Function(entry) entry.item)))
            Return "{" & vbLf & itemIndent &
                String.Join("," & vbLf & itemIndent, lines) &
                vbLf & Indent(indentLevel) & "}"
        End Function

        Friend Function VbMultilineCall(name As String, arguments As ScriptArray, indentLevel As Integer) As String
            Dim argumentIndent = Indent(indentLevel + 1)
            Dim separator = "," & vbLf & argumentIndent
            Return name & "(" & vbLf & argumentIndent &
                String.Join(separator, arguments.Select(Function(argument) Convert.ToString(argument, CultureInfo.InvariantCulture))) &
                vbLf & Indent(indentLevel) & ")"
        End Function

        Friend Function VbObjectArrayLiteral(values As ScriptArray, indentLevel As Integer) As String
            If values.Count = 0 Then
                Return "System.Array.Empty(Of Object)()"
            End If

            Dim items = values.Select(
                Function(value)
                    Dim nestedValues = TryCast(value, ScriptArray)
                    Return If(
                        nestedValues Is Nothing,
                        VbLiteral(value),
                        VbObjectArrayLiteral(nestedValues, indentLevel + 1))
                End Function).
                ToArray()
            Dim singleLine = "New Object() {" & String.Join(", ", items) & "}"

            If Not singleLine.Contains(vbLf) AndAlso singleLine.Length <= 88 Then
                Return singleLine
            End If

            Dim itemIndent = Indent(indentLevel + 1)
            Return "New Object() {" & vbLf & itemIndent &
                String.Join("," & vbLf & itemIndent, items) &
                vbLf & Indent(indentLevel) & "}"
        End Function

        Friend Function VbStringJoin(values As ScriptArray, separator As String, indentLevel As Integer) As String
            If values.Count = 0 Then
                Return $"String.Join({separator}, Array.Empty(Of String)())"
            End If

            Dim itemIndent = Indent(indentLevel + 1)
            Dim items = values.Select(Function(value) VbStringLiteral(Convert.ToString(value, CultureInfo.InvariantCulture)))
            Return $"String.Join({separator}, {{" & vbLf & itemIndent &
                String.Join("," & vbLf & itemIndent, items) &
                vbLf & Indent(indentLevel) & "})"
        End Function

        Private Function ParseTemplate(templateText As String, templatePath As String) As Template
            Dim parsedTemplate As Template = Scriban.Template.Parse(templateText, templatePath)

            If parsedTemplate.HasErrors Then
                Dim source = If(templatePath, "the supplied template")
                Throw New InvalidDataException($"Could not parse {source}:{Environment.NewLine}{String.Join(Environment.NewLine, parsedTemplate.Messages)}")
            End If

            Return parsedTemplate
        End Function

        Private Function Indent(level As Integer) As String
            Return New String(" "c, level * 4)
        End Function

        Private Function FilterByProperty(testCases As ScriptArray, name As String) As ScriptArray
            Return New ScriptArray(testCases.
                Cast(Of ScriptObject)().
                Where(Function(testCase) testCase("property")?.ToString() = name))
        End Function

        Private Function TemplateData(canonicalData As CanonicalData) As JsonElement
            Return JsonSerializer.SerializeToElement(
                New With {
                    .testClass = $"{canonicalData.Exercise.Name}Tests".Pascalize(),
                    .testedClass = canonicalData.Exercise.Name.Pascalize(),
                    .tests = canonicalData.TestCases.Select(Function(testCase, index) AddCalculatedFields(testCase, index)).ToArray()
                })
        End Function

        Private Function AddCalculatedFields(testCase As JsonNode, index As Integer) As JsonElement
            testCase("factAttribute") = If(
                index = 0,
                "<Fact>",
                "<Fact(Skip:=""Remove this Skip property to run this test"")>")
            testCase("testMethod") = Naming.ToTestMethodName(
                testCase("path").AsArray().Select(Function(item) item.GetValue(Of String)()).ToArray())
            testCase("shortTestMethod") = Naming.ToTestMethodName(testCase("description").GetValue(Of String)())
            testCase("testedMethod") = Naming.ToMethodName(testCase("property").GetValue(Of String)())

            Return JsonSerializer.SerializeToElement(testCase)
        End Function

        Private Sub FlushText(parts As List(Of String), text As StringBuilder)
            If text.Length = 0 Then
                Return
            End If

            parts.Add(Quote(text.ToString()))
            text.Clear()
        End Sub

        Private Function Quote(value As String) As String
            Dim quotationMark = ChrW(34).ToString()
            Return quotationMark & value.Replace(quotationMark, quotationMark & quotationMark) & quotationMark
        End Function
    End Module
End Namespace
