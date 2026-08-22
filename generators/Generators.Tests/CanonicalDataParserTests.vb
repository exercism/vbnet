Namespace Global.Exercism.VBNet.Generators
    Public Class CanonicalDataParserTests
        <Fact>
        Public Sub Flattens_nested_cases_in_order_and_retains_the_description_path()
            Dim root = JsonNode.Parse(
                "{""description"":""outer"",""cases"":[" &
                "{""description"":""first"",""uuid"":""a"",""property"":""value"",""input"":{},""expected"":1}," &
                "{""description"":""inner"",""cases"":[" &
                "{""description"":""second"",""uuid"":""b"",""property"":""value"",""input"":{},""expected"":2}]}]}")

            Dim testCases = CanonicalDataParser.ParseTestCases(root)

            Assert.Equal({"a", "b"}, testCases.Select(Function(testCase) testCase("uuid").GetValue(Of String)()))
            Assert.Equal({"outer", "first"}, Path(testCases(0)))
            Assert.Equal({"outer", "inner", "second"}, Path(testCases(1)))
        End Sub

        Private Shared Function Path(testCase As JsonNode) As String()
            Return testCase("path").AsArray().Select(Function(item) item.GetValue(Of String)()).ToArray()
        End Function
    End Class
End Namespace
