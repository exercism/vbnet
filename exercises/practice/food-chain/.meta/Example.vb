Imports System.Linq

Public Module FoodChain
    Private Const Verses As Integer = 8

    Private ReadOnly Subjects As String() = {"spider", "bird", "cat", "dog", "goat", "cow"}

    Private ReadOnly FollowUps As String() = {"It wriggled and jiggled and tickled inside her.", "How absurd to swallow a bird!", "Imagine that, to swallow a cat!", "What a hog, to swallow a dog!", "Just opened her throat and swallowed a goat!", "I don't know how she swallowed a cow!"}

    Private ReadOnly History As String() = {"I don't know how she swallowed a cow!", "She swallowed the cow to catch the goat.", "She swallowed the goat to catch the dog.", "She swallowed the dog to catch the cat.", "She swallowed the cat to catch the bird.", "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.", "She swallowed the spider to catch the fly.", "I don't know why she swallowed the fly. Perhaps she'll die."}

    Public Function Recite(ByVal verseNumber As Integer) As String
        Return Recite(verseNumber, verseNumber)
    End Function

    Public Function Recite(ByVal startVerse As Integer, ByVal endVerse As Integer) As String
        Return String.Join(vbLf & vbLf, Enumerable.Range(startVerse, endVerse - startVerse + 1).Select(Function(i) $"{VerseBegin(i)}
{VerseEnd(i)}"))
    End Function

    Private Function VerseBegin(ByVal number As Integer) As String
        If number = 1 Then
            Return "I know an old lady who swallowed a fly."
        End If

        If number = 8 Then
            Return "I know an old lady who swallowed a horse."
        End If

        Dim subject = Subjects(number - 2)
        Dim followUp = FollowUps(number - 2)
        Return $"I know an old lady who swallowed a {subject}.
{followUp}"
    End Function

    Private Function VerseEnd(ByVal number As Integer) As String
        If number = 8 Then
            Return "She's dead, of course!"
        End If

        Return String.Join(vbLf, History.Skip(History.Length - number).Take(number))
    End Function
End Module
