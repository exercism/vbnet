Imports CommandLine

Namespace Global.Exercism.VBNet.Generators
    Public Module Program
        Public Sub Main(args As String())
            Dim result = Parser.Default.ParseArguments(Of NewOptions, UpdateOptions, SyncOptions)(args)
            result.WithParsed(Of NewOptions)(AddressOf HandleNewCommand)
            result.WithParsed(Of UpdateOptions)(AddressOf HandleUpdateCommand)
            result.WithParsed(Of SyncOptions)(AddressOf HandleSyncCommand)
            result.WithNotParsed(AddressOf HandleErrors)
        End Sub

        Private Sub HandleNewCommand(options As NewOptions)
            Exercises.Untemplated(options.Exercise).ForEach(AddressOf TemplateGenerator.Generate)
        End Sub

        Private Sub HandleUpdateCommand(options As UpdateOptions)
            Exercises.Templated(options.Exercise).ForEach(AddressOf TestsGenerator.Generate)
        End Sub

        Private Sub HandleSyncCommand(options As SyncOptions)
            ProbSpecs.Sync()
        End Sub

        Private Sub HandleErrors(errors As IEnumerable(Of CommandLine.Error))
            For Each parseError In errors
                If Not IsInformational(parseError) Then
                    Console.Error.WriteLine(parseError)
                End If
            Next
        End Sub

        Private Function IsInformational(parseError As CommandLine.Error) As Boolean
            Return parseError.Tag = ErrorType.HelpRequestedError OrElse
                parseError.Tag = ErrorType.HelpVerbRequestedError OrElse
                parseError.Tag = ErrorType.VersionRequestedError
        End Function

        <Verb("new", HelpText:="Create a new exercise generator template file.")>
        Private NotInheritable Class NewOptions
            <OptionAttribute("e"c, "exercise", Required:=False, HelpText:="The exercise (slug) for which to generate a generator file.")>
            Public Property Exercise As String
        End Class

        <Verb("update", HelpText:="Update test files using each exercise's generator template file.")>
        Private NotInheritable Class UpdateOptions
            <OptionAttribute("e"c, "exercise", Required:=False, HelpText:="The exercise (slug) whose tests file should be generated.")>
            Public Property Exercise As String
        End Class

        <Verb("sync", HelpText:="Sync the problem-specifications repo.")>
        Private NotInheritable Class SyncOptions
        End Class
    End Module
End Namespace
