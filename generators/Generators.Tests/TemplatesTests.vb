Namespace Global.Exercism.VBNet.Generators
    Public Class TemplatesTests
        <Fact>
        Public Sub String_literal_escapes_quotes_and_control_characters()
            Dim quote = ChrW(34).ToString()
            Dim value = "before" & quote & "after" & vbCrLf & vbTab
            Dim expected = quote & "before" & quote & quote & "after" & quote & " & vbCrLf & vbTab"

            Assert.Equal(expected, Templates.VbStringLiteral(value))
        End Sub

        <Fact>
        Public Sub Literal_renders_nested_arrays_and_vb_primitive_names()
            Dim nested = New Scriban.Runtime.ScriptArray From {
                New Scriban.Runtime.ScriptArray From {"one", True},
                Nothing
            }

            Assert.Equal("{{""one"", True}, Nothing}", Templates.VbLiteral(nested))
        End Sub

        <Fact>
        Public Sub Indent_uses_four_spaces_per_level()
            Dim canonicalData = Canonical("a")

            Assert.Equal("        value", Templates.RenderTestsCode(canonicalData, "{{ indent 2 }}value"))
        End Sub

        <Fact>
        Public Sub Integer_array_literal_converts_numeric_strings()
            Dim values = New Scriban.Runtime.ScriptArray From {"4", "2", "6"}

            Assert.Equal("{4, 2, 6}", Templates.VbIntegerArrayLiteral(values))
        End Sub

        <Fact>
        Public Sub String_array_literal_renders_an_empty_array()
            Dim values = New Scriban.Runtime.ScriptArray()

            Assert.Equal("Array.Empty(Of String)()", Templates.VbStringArrayLiteral(values, 2, 1))
        End Sub

        <Fact>
        Public Sub String_array_literal_renders_multiple_rows()
            Dim values = New Scriban.Runtime.ScriptArray From {"one", "two"}
            Const expected = "{" & vbLf &
                "            ""one""," & vbLf &
                "            ""two""" & vbLf &
                "        }"

            Assert.Equal(expected, Templates.VbStringArrayLiteral(values, 2, 1))
        End Sub

        <Fact>
        Public Sub Multiline_array_literal_wraps_and_indents_long_arrays()
            Dim values = New Scriban.Runtime.ScriptArray From {"one", "two", "three"}
            Const expected = "{" & vbLf &
                "            ""one"", ""two""," & vbLf &
                "            ""three""" & vbLf &
                "        }"

            Assert.Equal(expected, Templates.VbMultilineArrayLiteral(values, 2, 2))
        End Sub

        <Fact>
        Public Sub Multiline_call_indents_arguments_and_closing_parenthesis()
            Dim arguments = New Scriban.Runtime.ScriptArray From {"4", "Node(2)", "Nothing"}
            Const expected = "Node(" & vbLf &
                "            4," & vbLf &
                "            Node(2)," & vbLf &
                "            Nothing" & vbLf &
                "        )"

            Assert.Equal(expected, Templates.VbMultilineCall("Node", arguments, 2))
        End Sub

        <Fact>
        Public Sub Object_array_literal_renders_nested_arrays()
            Dim nested = New Scriban.Runtime.ScriptArray From {2, 3, 4, 5, 6, 7}
            Dim values = New Scriban.Runtime.ScriptArray From {1, nested, 8}
            Const expected = "New Object() {1, New Object() {2, 3, 4, 5, 6, 7}, 8}"

            Assert.Equal(expected, Templates.VbObjectArrayLiteral(values, 2))
        End Sub

        <Fact>
        Public Sub Nested_list_literal_renders_and_indents_rows()
            Dim values = New Scriban.Runtime.ScriptArray From {
                New Scriban.Runtime.ScriptArray From {1, 2},
                New Scriban.Runtime.ScriptArray From {3, 4}
            }
            Const expected = "{" & vbLf &
                "            {1, 2}.ToList()," & vbLf &
                "            {3, 4}.ToList()" & vbLf &
                "        }.ToList()"

            Assert.Equal(expected, Templates.VbNestedListLiteral(values, "Integer", 2))
        End Sub

        <Fact>
        Public Sub Nested_list_literal_renders_an_empty_row()
            Dim values = New Scriban.Runtime.ScriptArray From {
                New Scriban.Runtime.ScriptArray()
            }
            Const expected = "{" & vbLf &
                "            New List(Of Integer)()" & vbLf &
                "        }.ToList()"

            Assert.Equal(expected, Templates.VbNestedListLiteral(values, "Integer", 2))
        End Sub

        <Fact>
        Public Sub Nested_list_literal_renders_an_empty_list()
            Dim values = New Scriban.Runtime.ScriptArray()

            Assert.Equal("New List(Of List(Of Integer))()", Templates.VbNestedListLiteral(values, "Integer", 2))
        End Sub

        <Fact>
        Public Sub String_join_renders_an_indented_string_array()
            Dim values = New Scriban.Runtime.ScriptArray From {"one", "two"}
            Const expected = "String.Join(vbLf, {" & vbLf &
                "            ""one""," & vbLf &
                "            ""two""" & vbLf &
                "        })"

            Assert.Equal(expected, Templates.VbStringJoin(values, "vbLf", 2))
        End Sub

        <Fact>
        Public Sub Filtering_before_rendering_enables_the_first_selected_test()
            Dim canonicalData = Canonical("a", "b")
            Dim filtered = TestCasesConfiguration.RemoveExcludedTestCases(
                canonicalData,
                "[a]" & vbLf & "include = false" & vbLf & "[b]")
            Const template = "{{ for test in tests }}{{ test.uuid }}={{ for.first }}{{ end }}"

            Assert.Equal("b=true", Templates.RenderTestsCode(filtered, template))
        End Sub

        <Fact>
        Public Sub Fact_attribute_enables_only_the_first_test()
            Dim canonicalData = Canonical("a", "b")
            Const template = "{{ for test in tests }}{{ test.factAttribute }}{{ end }}"
            Const expected = "<Fact><Fact(Skip:=""Remove this Skip property to run this test"")>"

            Assert.Equal(expected, Templates.RenderTestsCode(canonicalData, template))
        End Sub

        <Fact>
        Public Sub Literal_custom_test_is_rendered_unchanged()
            Dim canonicalData = Canonical("a")
            Const customTest = "<Fact(Skip:=""Remove this Skip property to run this test"")>" & vbLf &
                "Public Sub Track_specific_test()" & vbLf &
                "End Sub"
            Dim template = "{{ for test in tests }}{{ test.uuid }}{{ end }}" & vbLf & customTest

            Dim rendered = Templates.RenderTestsCode(canonicalData, template)

            Assert.Contains("a", rendered)
            Assert.Contains(customTest, rendered)
        End Sub

        <Fact>
        Public Sub Malformed_template_does_not_overwrite_an_existing_test_file()
            Dim outputPath = Path.GetTempFileName()
            File.WriteAllText(outputPath, "sentinel")

            Try
                Assert.Throws(Of InvalidDataException)(
                    Sub() TestsGenerator.GenerateTestsFile(Canonical("a"), "{{ if", outputPath, "Generator.tpl"))
                Assert.Equal("sentinel", File.ReadAllText(outputPath))
            Finally
                File.Delete(outputPath)
            End Try
        End Sub

        <Fact>
        Public Sub Formatting_rejects_invalid_visual_basic()
            Assert.Throws(Of InvalidDataException)(Function() Formatting.FormatCode("Public Class"))
        End Sub

        <Fact>
        Public Sub Formatting_is_deterministic_and_uses_lf()
            Const source = "Public Class Example" & vbLf & "Public Sub Test()" & vbLf & "End Sub" & vbLf & "End Class"

            Dim once = Formatting.FormatCode(source)
            Dim twice = Formatting.FormatCode(once)

            Assert.Equal(once, twice)
            Assert.DoesNotContain(vbCr, once)
            Assert.EndsWith(vbLf, once)
        End Sub

        Private Shared Function Canonical(ParamArray uuids As String()) As CanonicalData
            Dim testCases = uuids.Select(AddressOf TestCase).Cast(Of JsonNode)().ToArray()
            Return New CanonicalData(New Exercise("test-exercise", "TestExercise"), testCases)
        End Function

        Private Shared Function TestCase(uuid As String) As JsonObject
            Dim testCaseNode = New JsonObject()
            testCaseNode("uuid") = uuid
            testCaseNode("description") = uuid
            testCaseNode("property") = "value"
            testCaseNode("input") = New JsonObject()
            testCaseNode("expected") = uuid
            testCaseNode("path") = New JsonArray(JsonValue.Create(uuid))
            Return testCaseNode
        End Function
    End Class
End Namespace
