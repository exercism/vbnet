Imports NUnit.Framework

<TestFixture>
Public Class AtbashTest
    ' change Ignore to false to run test case or just remove 'Ignore = true'
    <TestCase("no", Result:="ml")> _
    <TestCase("yes", Result:="bvh", Ignore:=True)> _
    <TestCase("OMG", Result:="lnt", Ignore:=True)> _
    <TestCase("mindblowingly", Result:="nrmwy oldrm tob", Ignore:=True)> _
    <TestCase("Testing, 1 2 3, testing.", Result:="gvhgr mt123 gvhgr mt", Ignore:=True)> _
    <TestCase("Truth is fiction.", Result:="gifgs rhurx grlm", Ignore:=True)> _
    <TestCase("The quick brown fox jumps over the lazy dog.", Result:="gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt", Ignore:=True)> _
    Public Function Encodes_words_using_atbash_cipher(words As String) As String
        Return Atbash.Encode(words)
    End Function
End Class
