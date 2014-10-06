Imports NUnit.Framework

<TestFixture>
Public Class BinaryTest
    ' change Ignore to false to run test case or just remove 'Ignore = true'
    <TestCase("1", Result:=1)>
    <TestCase("10", Result:=2, Ignore:=True)>
    <TestCase("11", Result:=3, Ignore:=True)>
    <TestCase("100", Result:=4, Ignore:=True)>
    <TestCase("1001", Result:=9, Ignore:=True)>
    <TestCase("11010", Result:=26, Ignore:=True)>
    <TestCase("10001101000", Result:=1128, Ignore:=True)>
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
        Assert.That(New Binary(invalidValue).ToDecimal(), [Is].EqualTo(0))
    End Sub

    <Ignore>
    <Test>
    Public Sub BinaryCanConvertFormattedStrings()
        Assert.That(New Binary("011").ToDecimal(), [Is].EqualTo(3))
    End Sub
End Class
