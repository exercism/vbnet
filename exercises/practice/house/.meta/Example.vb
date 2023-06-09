Imports System.Linq

Public Module House
    Private ReadOnly Subjects As String() = {"house that Jack built", "malt", "rat", "cat", "dog", "cow with the crumpled horn", "maiden all forlorn", "man all tattered and torn", "priest all shaven and shorn", "rooster that crowed in the morn", "farmer sowing his corn", "horse and the hound and the horn"}

    Private ReadOnly Verbs As String() = {"lay in", "ate", "killed", "worried", "tossed", "milked", "kissed", "married", "woke", "kept", "belonged to", ""}

    Public Function Recite(ByVal verseNumber As Integer) As String
        Return Recite(verseNumber, verseNumber)
    End Function

    Public Function Recite(ByVal startVerse As Integer, ByVal endVerse As Integer) As String
        Dim numberOfVerses = endVerse - startVerse + 1
        Return String.Join(vbLf, Enumerable.Range(startVerse, numberOfVerses).[Select](New Func(Of Integer, String)(AddressOf Verse)))
    End Function

    Private Function Verse(ByVal number As Integer) As String
        Return String.Join(" ", Enumerable.Range(1, number).Reverse().[Select](Function(index) Line(number, index)))
    End Function

    Private Function Line(ByVal number As Integer, ByVal index As Integer) As String
        Dim subject = Subjects(index - 1)
        Dim verb = Verbs(index - 1)
        Dim ending = If(index = 1, ".", "")

        Return If(index = number, $"This is the {subject}{ending}", $"that {verb} the {subject}{ending}")
    End Function
End Module
