Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.CompilerServices

Public Module Alphametics
    Public Function Solve(ByVal equation As String) As IDictionary(Of Char, Integer)
        Return AlphameticsSolver.Solve(Parse(equation))
    End Function

    Private Function Parse(ByVal equation As String) As AlphameticsEquation
        Dim leftRight = Nothing
        leftRight = ParseOperands(equation)
        Return New AlphameticsEquation(left, right)
    End Function

    Private Function ParseOperands(ByVal equation As String) As (String(), String())
        Dim leftAndRightOperands = equation.Split(" == ")
        Dim left = leftAndRightOperands(0).Split(" + ")
        Dim right = leftAndRightOperands(1).Split(" + ")

        Return (left, right)
    End Function
End Module

Public Class AlphameticsEquation
    Public Sub New(ByVal left As String(), ByVal right As String())
        For Each leftSideOperand In left
            ProcessOperand(leftSideOperand, 1)
        Next

        For Each rightSideOperand In right
            ProcessOperand(rightSideOperand, -1)
        Next
    End Sub

    Public ReadOnly Property LettersWithCount As Dictionary(Of Char, Long) = New Dictionary(Of Char, Long)()
    Public ReadOnly Property NonZeroLetters As HashSet(Of Char) = New HashSet(Of Char)()

    Private Sub ProcessOperand(ByVal operand As String, ByVal multiplyCountBy As Long)
        Dim letterCount = multiplyCountBy
        Dim existingCount As Long = Nothing

        For i = operand.Length - 1 To 0 Step -1
            Dim letter = operand(i)

            If LettersWithCount.TryGetValue(letter, existingCount) Then
                LettersWithCount(letter) = existingCount + letterCount
            Else
                LettersWithCount(letter) = letterCount
            End If

            letterCount *= 10
        Next

        NonZeroLetters.Add(operand(0))
    End Sub
End Class

Public Module AlphameticsSolver
    Private _equation As AlphameticsEquation

    Public Function Solve(ByVal equation As AlphameticsEquation) As IDictionary(Of Char, Integer)
        _equation = equation
                ''' Cannot convert LocalDeclarationStatementSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax'.
'''    at ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration) in /_/CodeConverter/VB/CommonConversions.cs:line 474
'''    at ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node) in /_/CodeConverter/VB/MethodBodyExecutableStatementVisitor.cs:line 52
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node) in /_/CodeConverter/VB/CommentConvertingMethodBodyVisitor.cs:line 16
''' 
''' Input:
'''         
        var letterCount = AlphameticsSolver.LetterCountCombinations(equation).FirstOrDefault(AlphameticsSolver.IsSolution) ?? throw new System.ArgumentException();

''' 
        Return AlphameticsSolver.SolutionForLetterCount(letterCount)
    End Function

    Private Function LetterCountCombinations(ByVal equation As AlphameticsEquation) As IEnumerable(Of Integer())
        Return Enumerable.Range(0, 10).ToArray().Permutations(equation.LettersWithCount.Count)
    End Function

    Private Function IsSolution(ByVal letterCountCombination As Integer()) As Boolean
        If LetterCountHasInvalidNonZeroLetter() Then Return False

        Return Enumerable.Zip(Of Long, Global.System.Int32, Global.System.Int64)(_equation.LettersWithCount.Values, CType(letterCountCombination, IEnumerable(Of Integer)), CType(Function(count, solutionCount) CLng(count * solutionCount), Func(Of Long, Integer, Long))).Sum() = 0
                ''' Cannot convert LocalFunctionStatementSyntax, CONVERSION ERROR: Conversion for LocalFunctionStatement not implemented, please report this issue in 'bool LetterCountHasInvalidN...' at character 3209
''' 
''' 
''' Input:
''' 
        bool LetterCountHasInvalidNonZeroLetter()
        {
            var zeroLetterIndex = System.Array.IndexOf(letterCountCombination, 0);
            return zeroLetterIndex != -1 && AlphameticsSolver._equation.NonZeroLetters.Contains(AlphameticsSolver._equation.LettersWithCount.Keys.ElementAt(zeroLetterIndex));
        }

''' 
    End Function

    Private Function SolutionForLetterCount(ByVal letterCount As IEnumerable(Of Integer)) As Dictionary(Of Char, Integer)
        Return letterCount.Zip(_equation.LettersWithCount.Keys, Function(x, y) New KeyValuePair(Of Char, Integer)(y, x)).ToDictionary(Function(x) x.Key, Function(x) x.Value)
    End Function

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal throw statements")>
        Shared Function __Throw(Of T)(ByVal e As Exception) As T
            Throw e
        End Function
    End Class
End Module

Public Module EnumerableExtensions
    <Extension()>
    Public Function Permutations(Of T)(ByVal source As T(), ByVal length As Integer) As IEnumerable(Of T())
        If length = 1 Then Return source.[Select](Function(t) {t})

        Return source.Permutations(length - 1).SelectMany(Function(t) source.Where(Function(o) Not t.Contains(o)), Function(t1, t2) t1.Concat(New T() {t2}).ToArray())
    End Function
End Module
