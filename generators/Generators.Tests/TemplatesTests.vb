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
        Public Sub Filtering_before_rendering_enables_the_first_selected_test()
            Dim canonicalData = Canonical("a", "b")
            Dim filtered = TestCasesConfiguration.RemoveExcludedTestCases(
                canonicalData,
                "[a]" & vbLf & "include = false" & vbLf & "[b]")
            Const template = "{{ for test in tests }}{{ test.uuid }}={{ for.first }}{{ end }}"

            Assert.Equal("b=true", Templates.RenderTestsCode(filtered, template))
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
