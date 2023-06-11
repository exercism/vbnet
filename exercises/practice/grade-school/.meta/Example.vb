Imports System.Collections.Generic

Public Class GradeSchool
        ''' Cannot convert FieldDeclarationSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax'.
'''    at ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration) in /_/CodeConverter/VB/CommonConversions.cs:line 474
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitFieldDeclaration(FieldDeclarationSyntax node) in /_/CodeConverter/VB/NodesVisitor.cs:line 326
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping) in /_/CodeConverter/VB/CommentConvertingVisitorWrapper.cs:line 20
''' 
''' Input:
'''     private readonly System.Collections.Generic.SortedDictionary<int, System.Collections.Generic.List<string>> _roster = new();

''' 

    Public Function Add(ByVal student As String, ByVal grade As Integer) As Boolean
        If Me._roster.Values.Any(Function(students) students.Contains(student)) Then Return False

        If Not Me._roster.TryAdd(grade, New List(Of String) From {
            student
        }) Then
            Me._roster(grade).Add(student)
            Me._roster(grade).Sort()
        End If

        Return True
    End Function

    Public Function Roster() As IEnumerable(Of String)
        Return Me._roster.Values.SelectMany(Function(grade) grade).ToList()
    End Function

    Public Function Grade(ByVal pGrade As Integer) As IEnumerable(Of String)
        Return If(Me._roster.TryGetValue(pGrade, students), students, New List(Of String)())
    End Function
End Class
