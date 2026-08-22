Namespace Global.Exercism.VBNet.Generators
    Friend NotInheritable Class Exercise
        Friend Sub New(slug As String, name As String)
            Me.Slug = slug
            Me.Name = name
        End Sub

        Friend ReadOnly Property Slug As String
        Friend ReadOnly Property Name As String
    End Class

    Friend Module Exercises
        Friend Function Templated(Optional slug As String = Nothing) As List(Of Exercise)
            Return Find(slug, desiredTemplateState:=True)
        End Function

        Friend Function Untemplated(Optional slug As String = Nothing) As List(Of Exercise)
            Return Find(slug, desiredTemplateState:=False)
        End Function

        Private Function Find(slug As String, desiredTemplateState As Boolean) As List(Of Exercise)
            Return Parse().
                Where(Function(exercise) slug Is Nothing OrElse exercise.Slug = slug).
                Where(AddressOf HasCanonicalData).
                Where(Function(exercise) desiredTemplateState = HasTemplate(exercise)).
                ToList()
        End Function

        Private Iterator Function Parse() As IEnumerable(Of Exercise)
            Using document = JsonDocument.Parse(File.ReadAllText(Paths.TrackConfigFile))
                Dim slugs = document.RootElement.
                    GetProperty("exercises").
                    GetProperty("practice").
                    EnumerateArray().
                    Select(Function(exercise) exercise.GetProperty("slug").GetString()).
                    Where(Function(slug) slug IsNot Nothing).
                    OrderBy(Function(slug) slug, StringComparer.Ordinal)

                For Each slug In slugs
                    Yield New Exercise(slug, slug.Dehumanize())
                Next
            End Using
        End Function

        Private Function HasCanonicalData(exercise As Exercise) As Boolean
            Return File.Exists(Paths.CanonicalDataFile(exercise))
        End Function

        Private Function HasTemplate(exercise As Exercise) As Boolean
            Return File.Exists(Paths.TemplateFile(exercise))
        End Function
    End Module
End Namespace
