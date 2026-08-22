Imports Tomlyn
Imports Tomlyn.Model

Namespace Global.Exercism.VBNet.Generators
    Friend Module TestCasesConfiguration
        Friend Function RemoveExcludedTestCases(canonicalData As CanonicalData) As CanonicalData
            Return RemoveExcludedTestCases(canonicalData, File.ReadAllText(Paths.TestsTomlFile(canonicalData.Exercise)))
        End Function

        Friend Function RemoveExcludedTestCases(canonicalData As CanonicalData, testsToml As String) As CanonicalData
            Dim tables = TomlSerializer.Deserialize(Of TomlTable)(testsToml)

            If tables Is Nothing Then
                Throw New InvalidDataException($"Could not parse tests.toml for '{canonicalData.Exercise.Slug}'.")
            End If

            Dim explicitlyDisabled = ExplicitlyDisabledTestCaseIds(tables)
            Dim reimplemented = ReimplementedTestCaseIds(tables, canonicalData.TestCases)
            Dim includedTestCases = canonicalData.TestCases.
                Where(Function(testCase)
                          Dim uuid = TestCaseUuid(testCase)
                          Return Not explicitlyDisabled.Contains(uuid) AndAlso Not reimplemented.Contains(uuid)
                      End Function).
                ToArray()

            Return New CanonicalData(canonicalData.Exercise, includedTestCases)
        End Function

        Private Function ExplicitlyDisabledTestCaseIds(tables As TomlTable) As HashSet(Of String)
            Dim ids = New HashSet(Of String)(StringComparer.Ordinal)

            For Each pair In tables
                Dim table = TryCast(pair.Value, TomlTable)
                Dim includeValue As Object = Nothing

                If table IsNot Nothing AndAlso
                    table.TryGetValue("include", includeValue) AndAlso
                    TypeOf includeValue Is Boolean AndAlso
                    Not DirectCast(includeValue, Boolean) Then
                    ids.Add(pair.Key)
                End If
            Next

            Return ids
        End Function

        Private Function ReimplementedTestCaseIds(tables As TomlTable, testCases As IEnumerable(Of JsonNode)) As HashSet(Of String)
            Dim ids = New HashSet(Of String)(StringComparer.Ordinal)

            For Each pair In tables
                Dim table = TryCast(pair.Value, TomlTable)
                Dim reimplementsValue As Object = Nothing

                If table IsNot Nothing AndAlso
                    table.TryGetValue("reimplements", reimplementsValue) AndAlso
                    TypeOf reimplementsValue Is String Then
                    ids.Add(DirectCast(reimplementsValue, String))
                End If
            Next

            For Each testCase In testCases
                Dim reimplements = testCase("reimplements")

                If reimplements IsNot Nothing Then
                    ids.Add(reimplements.GetValue(Of String)())
                End If
            Next

            Return ids
        End Function

        Private Function TestCaseUuid(testCase As JsonNode) As String
            Dim uuid = testCase("uuid")

            If uuid Is Nothing Then
                Throw New InvalidDataException("A canonical test case does not have a UUID.")
            End If

            Return uuid.GetValue(Of String)()
        End Function
    End Module
End Namespace
