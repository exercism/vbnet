Namespace Global.Exercism.VBNet.Generators
    Public Class TestCasesConfigurationTests
        <Fact>
        Public Sub Omitted_include_is_included()
            Dim result = Filter(Canonical("a"), "[a]" & vbLf & "description = ""A""")

            Assert.Equal({"a"}, Uuids(result))
        End Sub

        <Fact>
        Public Sub Include_false_is_excluded()
            Dim result = Filter(Canonical("a", "b"),
                "[a]" & vbLf &
                "include = false" & vbLf &
                "[b]")

            Assert.Equal({"b"}, Uuids(result))
        End Sub

        <Fact>
        Public Sub Reimplemented_original_is_excluded_and_replacement_is_included()
            Dim result = Filter(Canonical("a", "b"),
                "[a]" & vbLf &
                "[b]" & vbLf &
                "reimplements = ""a""")

            Assert.Equal({"b"}, Uuids(result))
        End Sub

        <Fact>
        Public Sub Replacement_chain_includes_only_the_enabled_terminal_case()
            Dim result = Filter(Canonical("a", "b", "c"),
                "[a]" & vbLf &
                "include = false" & vbLf &
                "[b]" & vbLf &
                "include = false" & vbLf &
                "reimplements = ""a""" & vbLf &
                "[c]" & vbLf &
                "reimplements = ""b""")

            Assert.Equal({"c"}, Uuids(result))
        End Sub

        <Fact>
        Public Sub Disabled_terminal_replacement_does_not_revive_an_older_case()
            Dim result = Filter(Canonical("a", "b", "c"),
                "[a]" & vbLf &
                "[b]" & vbLf &
                "reimplements = ""a""" & vbLf &
                "[c]" & vbLf &
                "include = false" & vbLf &
                "reimplements = ""b""")

            Assert.Empty(Uuids(result))
        End Sub

        <Fact>
        Public Sub Multiple_terminal_replacements_are_included_in_canonical_order()
            Dim result = Filter(Canonical("a", "b", "c"),
                "[a]" & vbLf &
                "[b]" & vbLf &
                "reimplements = ""a""" & vbLf &
                "[c]" & vbLf &
                "reimplements = ""a""")

            Assert.Equal({"b", "c"}, Uuids(result))
        End Sub

        <Fact>
        Public Sub Canonical_reimplementation_is_honored_when_tests_toml_is_stale()
            Dim canonicalData = Canonical("a", "b")
            DirectCast(canonicalData.TestCases(1), JsonObject)("reimplements") = "a"

            Dim result = Filter(canonicalData, "[a]")

            Assert.Equal({"b"}, Uuids(result))
        End Sub

        Private Shared Function Filter(canonicalData As CanonicalData, testsToml As String) As CanonicalData
            Return TestCasesConfiguration.RemoveExcludedTestCases(canonicalData, testsToml)
        End Function

        Private Shared Function Canonical(ParamArray uuids As String()) As CanonicalData
            Dim testCases = uuids.Select(AddressOf TestCase).Cast(Of JsonNode)().ToArray()
            Return New CanonicalData(New Exercise("test-exercise", "TestExercise"), testCases)
        End Function

        Private Shared Function TestCase(uuid As String) As JsonObject
            Dim testCaseNode = New JsonObject()
            testCaseNode("uuid") = uuid
            Return testCaseNode
        End Function

        Private Shared Function Uuids(canonicalData As CanonicalData) As String()
            Return canonicalData.TestCases.Select(Function(testCase) testCase("uuid").GetValue(Of String)()).ToArray()
        End Function
    End Class
End Namespace
