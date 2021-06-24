Imports XUnit


Public Class BinaryTest
    ' change Ignore to false to run test case or just remove 'Ignore = true'
    <Theory>
    <InLineData("1", Result:=1)>
    <InLineData("10", Result:=2, Ignore:=True)>
    <InLineData("11", Result:=3, Ignore:=True)>
    <InLineData("100", Result:=4, Ignore:=True)>
    <InLineData("1001", Result:=9, Ignore:=True)>
    <InLineData("11010", Result:=26, Ignore:=True)>
    <InLineData("10001101000", Result:=1128, Ignore:=True)>
    Public Function BinaryConvertsToDecimal(binary As String) As Integer
        Return New Binary(binary).ToDecimal()
    End Function

    <TestCase("carrot", Ignore:=True)>
    <TestCase("2", Ignore:=True)>
    <TestCase("5", Ignore:=True)>
    <TestCase("9", Ignore:=True)>
    <TestCase("134678", Ignore:=True)>
    <TestCase("abc10z", Ignore:=True)>
    Public Sub InvalidBinaryIsDecimal0(invalidValue As String)
        Assert.Equal(New Binary(invalidValue).ToDecimal(), 0)
    End Sub

<Fact(Skip := "Remove this Skip property to run this test")>
    Public Sub BinaryCanConvertFormattedStrings()
        Assert.Equal(New Binary("011").ToDecimal(), 3)
    End Sub
End Class
