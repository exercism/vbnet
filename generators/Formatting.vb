Imports Microsoft.CodeAnalysis
Imports Microsoft.CodeAnalysis.Formatting
Imports Microsoft.CodeAnalysis.VisualBasic

Namespace Global.Exercism.VBNet.Generators
    Friend Module Formatting
        Private ReadOnly Workspace As New AdhocWorkspace()

        Friend Function FormatCode(code As String) As String
            Dim syntaxTree = VisualBasicSyntaxTree.ParseText(code)
            Dim errors = syntaxTree.GetDiagnostics().
                Where(Function(diagnostic) diagnostic.Severity = DiagnosticSeverity.Error).
                ToArray()

            If errors.Length > 0 Then
                Throw New InvalidDataException($"Generated Visual Basic contains syntax errors:{Environment.NewLine}{String.Join(Environment.NewLine, errors.Select(Function(errorDiagnostic) errorDiagnostic.ToString()))}")
            End If

            Dim root = syntaxTree.GetRoot().WithoutLeadingTrivia()
            Dim formatted = Formatter.Format(root, Workspace).ToFullString()
            Return NormalizeLineEndings(formatted)
        End Function

        Private Function NormalizeLineEndings(value As String) As String
            Dim normalized = value.Replace(vbCrLf, vbLf).Replace(vbCr, vbLf)
            Return normalized.TrimEnd(ControlChars.Cr, ControlChars.Lf) & vbLf
        End Function
    End Module
End Namespace
