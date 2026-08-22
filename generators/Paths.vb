Namespace Global.Exercism.VBNet.Generators
    Friend Module Paths
        Private ReadOnly RootDirectory As String = FindRootDirectory()
        Friend ReadOnly ProblemSpecificationsDirectory As String = Path.Join(RootDirectory, ".problem-specifications")
        Private ReadOnly ProblemSpecificationsExercisesDirectory As String = Path.Join(ProblemSpecificationsDirectory, "exercises")
        Friend ReadOnly PracticeExercisesDirectory As String = Path.Join(RootDirectory, "exercises", "practice")
        Friend ReadOnly TrackConfigFile As String = Path.Join(RootDirectory, "config.json")

        Friend Function ExerciseDirectory(exercise As Exercise) As String
            Return Path.Join(PracticeExercisesDirectory, exercise.Slug)
        End Function

        Friend Function TestsFile(exercise As Exercise) As String
            Return Path.Join(ExerciseDirectory(exercise), $"{exercise.Name}Tests.vb")
        End Function

        Friend Function TestsTomlFile(exercise As Exercise) As String
            Return Path.Join(ExerciseDirectory(exercise), ".meta", "tests.toml")
        End Function

        Friend Function TemplateFile(exercise As Exercise) As String
            Return Path.Join(ExerciseDirectory(exercise), ".meta", "Generator.tpl")
        End Function

        Friend Function CanonicalDataFile(exercise As Exercise) As String
            Return Path.Join(ProblemSpecificationsExercisesDirectory, exercise.Slug, "canonical-data.json")
        End Function

        Private Function FindRootDirectory() As String
            Dim currentDirectory = Environment.CurrentDirectory

            While currentDirectory IsNot Nothing AndAlso Not File.Exists(Path.Join(currentDirectory, "LICENSE"))
                currentDirectory = Path.GetDirectoryName(currentDirectory)
            End While

            If currentDirectory Is Nothing Then
                Throw New DirectoryNotFoundException("Could not find the repository root containing LICENSE.")
            End If

            Return currentDirectory
        End Function
    End Module
End Namespace
