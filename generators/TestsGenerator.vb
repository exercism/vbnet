Namespace Global.Exercism.VBNet.Generators
    Friend Module TestsGenerator
        Friend Sub Generate(exercise As Exercise)
            Console.WriteLine($"{exercise.Slug}: generating tests...")

            Dim hasCanonicalData = File.Exists(Paths.CanonicalDataFile(exercise))
            Dim canonicalData = If(
                hasCanonicalData,
                CanonicalDataParser.Parse(exercise),
                New CanonicalData(exercise, Array.Empty(Of JsonNode)()))
            Dim filteredCanonicalData = If(
                hasCanonicalData,
                TestCasesConfiguration.RemoveExcludedTestCases(canonicalData),
                canonicalData)
            Dim templatePath = Paths.TemplateFile(exercise)
            GenerateTestsFile(
                filteredCanonicalData,
                File.ReadAllText(templatePath),
                Paths.TestsFile(exercise),
                templatePath)
        End Sub

        Friend Sub GenerateTestsFile(canonicalData As CanonicalData, templateText As String, outputPath As String, Optional templatePath As String = Nothing)
            Dim testCode = Templates.RenderTestsCode(canonicalData, templateText, templatePath)
            Dim formattedTestCode = Formatting.FormatCode(testCode)
            WriteIfChanged(outputPath, formattedTestCode)
        End Sub

        Private Sub WriteIfChanged(path As String, contents As String)
            If File.Exists(path) AndAlso File.ReadAllText(path) = contents Then
                Return
            End If

            File.WriteAllText(path, contents, New UTF8Encoding(encoderShouldEmitUTF8Identifier:=False))
        End Sub
    End Module
End Namespace
