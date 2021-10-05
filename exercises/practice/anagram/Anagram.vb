''' <summary>
''' Class that analyzes which words are anagrams of the word specified in the constructor.
''' </summary>
Public Class Anagram

    ''' <summary>
    ''' Constructs a new <see cref="Anagram"/> analyzer for the given <paramref name="word"/>. If <paramref name="word"/> is <see langword="Nothing"/>,
    ''' an <see cref="ArgumentNullException"/> is thrown. Empty strings and white-space are valid (but are going to result in empty anagram lists).
    ''' </summary>
    ''' <param name="word">The word against to check.</param>
    ''' <exception cref="ArgumentNullException">An ArgumentNullException is thrown if <paramref name="word"/> is <see langword="Nothing"/>.</exception>
    Public Sub New(word As String)
        Throw New NotImplementedException("It's up to you to implement this code...")
    End Sub

    ''' <summary>
    ''' Returns an array of string with all <paramref name="words"/> that are anagrams of <see cref="Word"/>. White-space before, within and
    ''' after the word is ignored, and also the casing (upper-/lower-case) does not matter to determine whether a word is an anagram or not,
    ''' but the word is always returned as it appeared in the input collection. If <paramref name="words"/> is <see langword="Nothing"/> or 
    ''' empty, an empty collection is returned (no exception thrown) and elements that are <see langword="Nothing"/> are ignored. The sort
    ''' order of the anagrams found is undefined.
    ''' </summary>
    ''' <param name="words">The words to check.</param>
    ''' <returns>A collection containing the words from '<paramref name="words"/>' that are anagrams of '<see cref="Word"/>'.</returns>
    Public Function Match(words As IEnumerable(Of String)) As IEnumerable(Of String)
        Throw New NotImplementedException("It's up to you to implement this code...")
    End Function

End Class