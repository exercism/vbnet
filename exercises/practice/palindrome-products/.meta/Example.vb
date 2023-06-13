Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Module PalindromeProducts
    Public Function Smallest(ByVal minFactor As Integer, ByVal maxFactor As Integer) As (Integer, IEnumerable(Of (Integer, Integer)))
        If minFactor > maxFactor Then Throw New ArgumentException()

        Dim smallestPalindromeProduct = Integer.MaxValue
        Dim smallestPalindromeProductFactors = New List(Of (Integer, Integer))()

        For Each xY In Pairs(minFactor, maxFactor)
            Dim x = xY.Item1
            Dim y = xY.Item2
            Dim product = x * y

            If product > smallestPalindromeProduct OrElse Not IsPalindrome(product) Then            ''' Cannot convert ContinueStatementSyntax, System.ArgumentOutOfRangeException: Specified argument was out of the range of valid values.
''' Parameter name: kind
'''    at Microsoft.CodeAnalysis.VisualBasic.SyntaxFactory.VerifySyntaxKindOfToken(SyntaxKind kind)
'''    at Microsoft.CodeAnalysis.VisualBasic.SyntaxFactory.Token(SyntaxKind kind, String text)
'''    at ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitContinueStatement(ContinueStatementSyntax node) in /_/CodeConverter/VB/MethodBodyExecutableStatementVisitor.cs:line 605
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node) in /_/CodeConverter/VB/CommentConvertingMethodBodyVisitor.cs:line 16
''' 
''' Input:
'''                 continue;

''' 

            If product < smallestPalindromeProduct Then smallestPalindromeProductFactors.Clear()

            smallestPalindromeProductFactors.Add((x, y))
            smallestPalindromeProduct = product
        Next

        If smallestPalindromeProduct = Integer.MaxValue Then Throw New ArgumentException()

        Return (smallestPalindromeProduct, smallestPalindromeProductFactors)
    End Function

    Public Function Largest(ByVal minFactor As Integer, ByVal maxFactor As Integer) As (Integer, IEnumerable(Of (Integer, Integer)))
        If minFactor > maxFactor Then Throw New ArgumentException()

        Dim largestPalindromeProduct = Integer.MinValue
        Dim largestPalindromeProductFactors = New List(Of (Integer, Integer))()

        For Each xY In Pairs(minFactor, maxFactor).Reverse()
            Dim x = xY.Item1
            Dim y = xY.Item2
            Dim product = x * y

            If product < largestPalindromeProduct OrElse Not IsPalindrome(product) Then            ''' Cannot convert ContinueStatementSyntax, System.ArgumentOutOfRangeException: Specified argument was out of the range of valid values.
''' Parameter name: kind
'''    at Microsoft.CodeAnalysis.VisualBasic.SyntaxFactory.VerifySyntaxKindOfToken(SyntaxKind kind)
'''    at Microsoft.CodeAnalysis.VisualBasic.SyntaxFactory.Token(SyntaxKind kind, String text)
'''    at ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitContinueStatement(ContinueStatementSyntax node) in /_/CodeConverter/VB/MethodBodyExecutableStatementVisitor.cs:line 605
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node) in /_/CodeConverter/VB/CommentConvertingMethodBodyVisitor.cs:line 16
''' 
''' Input:
'''                 continue;

''' 

            If product > largestPalindromeProduct Then largestPalindromeProductFactors.Clear()

            largestPalindromeProductFactors.Add((x, y))
            largestPalindromeProduct = product
        Next

        If largestPalindromeProduct = Integer.MinValue Then Throw New ArgumentException()

        largestPalindromeProductFactors.Reverse()

        Return (largestPalindromeProduct, largestPalindromeProductFactors)
    End Function

    Private Function Pairs(ByVal minFactor As Integer, ByVal maxFactor As Integer) As IEnumerable(Of (Integer, Integer))
        Return From x In Enumerable.Range(minFactor, maxFactor + 1 - minFactor) From y In Enumerable.Range(x, maxFactor + 1 - x) Select (x, y)
    End Function

    Private Function IsPalindrome(ByVal num As Integer) As Boolean
        Dim n = num
        Dim rev = 0

        While num > 0
            Dim dig = num Mod 10
            rev = rev * 10 + dig
            num = num / 10
        End While

        Return n = rev
    End Function
End Module
