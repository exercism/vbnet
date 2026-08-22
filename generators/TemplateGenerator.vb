Namespace Global.Exercism.VBNet.Generators
    Friend Module TemplateGenerator
        Friend Sub Generate(exercise As Exercise)
            Console.WriteLine($"{exercise.Slug}: generating template...")

            Dim canonicalData = CanonicalDataParser.Parse(exercise)
            Dim filteredCanonicalData = TestCasesConfiguration.RemoveExcludedTestCases(canonicalData)
            Dim template = RenderTemplate(filteredCanonicalData)
            File.WriteAllText(Paths.TemplateFile(exercise), template, New UTF8Encoding(encoderShouldEmitUTF8Identifier:=False))
        End Sub

        Friend Function RenderTemplate(canonicalData As CanonicalData) As String
            Dim representativeTestCase = canonicalData.TestCases.FirstOrDefault(Function(testCase) Not ExpectsError(testCase))

            If representativeTestCase Is Nothing Then
                Throw New InvalidDataException($"'{canonicalData.Exercise.Slug}' has no included non-error test case from which to create a template.")
            End If

            Dim hasError = canonicalData.TestCases.Any(AddressOf ExpectsError)
            Dim lines = New List(Of String) From {
                "Public Class {{ testClass }}",
                "    {{- for test in tests }}",
                "    <Fact{{ if !for.first }}(Skip:=""Remove this Skip property to run this test""){{ end }}>",
                "    Public Sub {{ test.testMethod }}()"
            }

            If hasError Then
                lines.Add("        {{ if test.expected.error }}")
                lines.Add($"        {AssertThrows(representativeTestCase)}")
                lines.Add("        {{ else }}")
                lines.Add($"        {Assertion(representativeTestCase)}")
                lines.Add("        {{ end }}")
            Else
                lines.Add($"        {Assertion(representativeTestCase)}")
            End If

            lines.Add("    End Sub")
            lines.Add("    {{ end -}}")
            lines.Add("End Class")

            Return String.Join(vbLf, lines) & vbLf
        End Function

        Private Function Value(field As String, testCase As JsonNode) As String
            If testCase IsNot Nothing AndAlso testCase.GetValueKind() = JsonValueKind.String Then
                Return "{{ " & field & " | vb_string_literal }}"
            End If

            Return "{{ " & field & " }}"
        End Function

        Private Function Expected(testCase As JsonNode) As String
            Return Value("test.expected", testCase("expected"))
        End Function

        Private Function Assertion(testCase As JsonNode) As String
            Select Case testCase("expected").GetValueKind()
                Case JsonValueKind.False, JsonValueKind.True
                    Return AssertBoolean(TestedMethodCall(testCase))
                Case Else
                    Return $"Assert.Equal({Expected(testCase)}, {TestedMethodCall(testCase)})"
            End Select
        End Function

        Private Function TestedMethodArguments(testCase As JsonNode) As String
            Return String.Join(", ", testCase("input").AsObject().
                Select(Function(pair) Value($"test.input.{pair.Key}", pair.Value)))
        End Function

        Private Function TestedMethodCall(testCase As JsonNode) As String
            Return "{{ test.testedMethod }}(" & TestedMethodArguments(testCase) & ")"
        End Function

        Private Function AssertBoolean(methodCall As String) As String
            Return "Assert.{{ test.expected ? ""True"" : ""False"" }}(" & methodCall & ")"
        End Function

        Private Function AssertThrows(testCase As JsonNode) As String
            Return "Assert.Throws(Of ArgumentException)(Function() " & TestedMethodCall(testCase) & ")"
        End Function

        Private Function ExpectsError(testCase As JsonNode) As Boolean
            Dim expected = TryCast(testCase("expected"), JsonObject)
            Return expected IsNot Nothing AndAlso expected.ContainsKey("error")
        End Function
    End Module
End Namespace
