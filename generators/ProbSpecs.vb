Imports LibGit2Sharp

Namespace Global.Exercism.VBNet.Generators
    Friend Module ProbSpecs
        Private Const RepositoryUrl As String = "https://github.com/exercism/problem-specifications.git"

        Friend Sub Sync()
            Console.WriteLine("Syncing problem-specifications repo...")
            Clone()
            Pull()
        End Sub

        Private Sub Clone()
            If Not Directory.Exists(Paths.ProblemSpecificationsDirectory) Then
                Repository.Clone(RepositoryUrl, Paths.ProblemSpecificationsDirectory)
            End If
        End Sub

        Private Sub Pull()
            Using repository = New Repository(Paths.ProblemSpecificationsDirectory)
                Dim signature = New Signature("Exercism", "info@exercism.org", DateTimeOffset.Now)
                Commands.Pull(repository, signature, New PullOptions())
            End Using
        End Sub
    End Module
End Namespace
