Imports System.IO

Public Class {{ testClass }}
    Implements IDisposable

    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.shortTestMethod }}()
        Dim pattern = {{ test.input.pattern | vb_string_literal }}
        Dim flags = {{ test.input.flags | array.join " " | vb_string_literal }}
        Dim files = {{ test.input.files | vb_literal }}
        Dim expected = {{ test.expected | vb_string_join "vbLf" 2 }}
        Assert.Equal(expected, {{ testedClass }}.Match(pattern, flags, files))
    End Sub
    {{ end }}

    Private Const IliadFileName = "iliad.txt"
    Private Shared ReadOnly IliadContents = String.Join(vbLf, {
        "Achilles sing, O Goddess! Peleus' son;",
        "His wrath pernicious, who ten thousand woes",
        "Caused to Achaia's host, sent many a soul",
        "Illustrious into Ades premature,",
        "And Heroes gave (so stood the will of Jove)",
        "To dogs and to all ravening fowls a prey,",
        "When fierce dispute had separated once",
        "The noble Chief Achilles from the son",
        "Of Atreus, Agamemnon, King of men."
    }) & vbLf

    Private Const MidsummerNightFileName = "midsummer-night.txt"
    Private Shared ReadOnly MidsummerNightContents = String.Join(vbLf, {
        "I do entreat your grace to pardon me.",
        "I know not by what power I am made bold,",
        "Nor how it may concern my modesty,",
        "In such a presence here to plead my thoughts;",
        "But I beseech your grace that I may know",
        "The worst that may befall me in this case,",
        "If I refuse to wed Demetrius."
    }) & vbLf

    Private Const ParadiseLostFileName = "paradise-lost.txt"
    Private Shared ReadOnly ParadiseLostContents = String.Join(vbLf, {
        "Of Mans First Disobedience, and the Fruit",
        "Of that Forbidden Tree, whose mortal tast",
        "Brought Death into the World, and all our woe,",
        "With loss of Eden, till one greater Man",
        "Restore us, and regain the blissful Seat,",
        "Sing Heav'nly Muse, that on the secret top",
        "Of Oreb, or of Sinai, didst inspire",
        "That Shepherd, who first taught the chosen Seed"
    }) & vbLf

    Public Sub New()
        Directory.SetCurrentDirectory(Path.GetTempPath())
        File.WriteAllText(IliadFileName, IliadContents)
        File.WriteAllText(MidsummerNightFileName, MidsummerNightContents)
        File.WriteAllText(ParadiseLostFileName, ParadiseLostContents)
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Directory.SetCurrentDirectory(Path.GetTempPath())
        File.Delete(IliadFileName)
        File.Delete(MidsummerNightFileName)
        File.Delete(ParadiseLostFileName)
    End Sub
End Class
