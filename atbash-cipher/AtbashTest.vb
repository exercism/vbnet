Imports NUnit.Framework

<TestFixture>
Public Class AtbashTest
    ' change Ignore to false to run test case or just remove 'Ignore = true'
    <TestCase("no", Result:="ml")>
    <TestCase("yes", Result:="bvh", Ignore:=True)>
    <TestCase("OMG", Result:="lnt", Ignore:=True)>
    <TestCase("mindblowingly", Result:="nrmwy oldrm tob", Ignore:=True)>
    <TestCase("Testing, 1 2 3, testing.", Result:="gvhgr mt123 gvhgr mt", Ignore:=True)>
    <TestCase("Truth is fiction.", Result:="gifgs rhurx grlm", Ignore:=True)>
    <TestCase("The quick brown fox jumps over the lazy dog.", Result:="gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt", Ignore:=True)>
    Public Function EncodesWordsUsingAtbashCipher(words As String) As String
        Return Atbash.Encode(words)
    End Function
End Class
