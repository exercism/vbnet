Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Module Forth
    Private defines As Dictionary(Of String, String()) = New Dictionary(Of String, String())()
    Public Function Evaluate(ByVal instructions As String()) As String
        If Not instructions.Any() Then Return String.Empty
        Dim input = New Stack(Of String)(String.Join(" ", instructions).ToUpper().Split(" ").Reverse())
        Dim output = New Stack(Of Integer)()
        defines = New Dictionary(Of String, String())()
        Dim number As Integer = Nothing
        While input.Any()
                        ''' Cannot convert SwitchStatementSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.CaseClauseSyntax'.
'''    at System.Linq.Enumerable.<CastIterator>d__97`1.MoveNext()
'''    at Microsoft.CodeAnalysis.VisualBasic.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
'''    at ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.ConvertSwitchSection(SwitchSectionSyntax section) in /_/CodeConverter/VB/MethodBodyExecutableStatementVisitor.cs:line 226
'''    at System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
'''    at System.Linq.Buffer`1..ctor(IEnumerable`1 source)
'''    at System.Linq.Enumerable.ToArray[TSource](IEnumerable`1 source)
'''    at ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitSwitchStatement(SwitchStatementSyntax node) in /_/CodeConverter/VB/MethodBodyExecutableStatementVisitor.cs:line 197
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node) in /_/CodeConverter/VB/CommentConvertingMethodBodyVisitor.cs:line 16
''' 
''' Input:
'''             switch (input.Pop())
            {
                case var st when int.TryParse(st, out int number):
                    output.Push(number);
                    break;
                case var st when Forth.defines.ContainsKey(st):
                    foreach (var define in Forth.defines[st].Reverse())
                        input.Push(define);
                    break;
                case "+":
                    output.Push(Forth.Add(output.Pop(), output.Pop()));
                    break;
                case "-":
                    output.Push(Forth.Sub(output.Pop(), output.Pop()));
                    break;
                case "*":
                    output.Push(Forth.Mul(output.Pop(), output.Pop()));
                    break;
                case "/":
                    output.Push(Forth.Div(output.Pop(), output.Pop()));
                    break;
                case "DUP":
                    output.Push(output.Peek());
                    break;
                case "DROP":
                    output.Pop();
                    break;
                case "SWAP":
                    foreach (var item in new[] { output.Pop(), output.Pop() })
                        output.Push(item);
                    break;
                case "OVER":
                    foreach (var item in new[] { output.Pop(), output.Peek() })
                        output.Push(item);
                    break;
                case ":":
                    Forth.Define(ref input);
                    break;
                default:
                    throw new System.InvalidOperationException();
            }

''' 
        End While
        Return String.Join(" ", output.Reverse())
    End Function
    Private Function Add(ByVal x As Integer, ByVal y As Integer) As Integer
        Return y + x
    End Function
    Private Function [Sub](ByVal x As Integer, ByVal y As Integer) As Integer
        Return y - x
    End Function
    Private Function Mul(ByVal x As Integer, ByVal y As Integer) As Integer
        Return y * x
    End Function
    Private Function Div(ByVal x As Integer, ByVal y As Integer) As Integer
        Return If(x = 0, CSharpImpl.__Throw(Of Integer)(New DivideByZeroException()), y / x)
    End Function
    Private Sub Define(ByRef input As Stack(Of String))
        Dim key = input.Pop()
        Dim num As Integer = Nothing
        If Integer.TryParse(key, num) Then Throw New InvalidOperationException()
        Dim values = New List(Of String)()
        Dim value = input.Pop()
        While Not value.Equals(";")
            values.Add(value)
            value = input.Pop()
        End While
        defines(key) = values.SelectMany(Function(k) If(defines.ContainsKey(k), defines(k), {k})).ToArray()
    End Sub

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal throw statements")>
        Shared Function __Throw(Of T)(ByVal e As Exception) As T
            Throw e
        End Function
    End Class
End Module
