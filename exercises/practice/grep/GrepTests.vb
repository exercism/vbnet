Imports System.IO

Public Class GrepTests
    Implements IDisposable
    <Fact>
    Public Sub One_file_one_match_no_flags()
        Dim pattern = "Agamemnon"
        Dim flags = ""
        Dim files = {"iliad.txt"}
        Dim expected = String.Join(vbLf, {
            "Of Atreus, Agamemnon, King of men."
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_one_match_print_line_numbers_flag()
        Dim pattern = "Forbidden"
        Dim flags = "-n"
        Dim files = {"paradise-lost.txt"}
        Dim expected = String.Join(vbLf, {
            "2:Of that Forbidden Tree, whose mortal tast"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_one_match_case_insensitive_flag()
        Dim pattern = "FORBIDDEN"
        Dim flags = "-i"
        Dim files = {"paradise-lost.txt"}
        Dim expected = String.Join(vbLf, {
            "Of that Forbidden Tree, whose mortal tast"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_one_match_print_file_names_flag()
        Dim pattern = "Forbidden"
        Dim flags = "-l"
        Dim files = {"paradise-lost.txt"}
        Dim expected = String.Join(vbLf, {
            "paradise-lost.txt"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_one_match_match_entire_lines_flag()
        Dim pattern = "With loss of Eden, till one greater Man"
        Dim flags = "-x"
        Dim files = {"paradise-lost.txt"}
        Dim expected = String.Join(vbLf, {
            "With loss of Eden, till one greater Man"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_one_match_multiple_flags()
        Dim pattern = "OF ATREUS, Agamemnon, KIng of MEN."
        Dim flags = "-n -i -x"
        Dim files = {"iliad.txt"}
        Dim expected = String.Join(vbLf, {
            "9:Of Atreus, Agamemnon, King of men."
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_several_matches_no_flags()
        Dim pattern = "may"
        Dim flags = ""
        Dim files = {"midsummer-night.txt"}
        Dim expected = String.Join(vbLf, {
            "Nor how it may concern my modesty,",
            "But I beseech your grace that I may know",
            "The worst that may befall me in this case,"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_several_matches_print_line_numbers_flag()
        Dim pattern = "may"
        Dim flags = "-n"
        Dim files = {"midsummer-night.txt"}
        Dim expected = String.Join(vbLf, {
            "3:Nor how it may concern my modesty,",
            "5:But I beseech your grace that I may know",
            "6:The worst that may befall me in this case,"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_several_matches_match_entire_lines_flag()
        Dim pattern = "may"
        Dim flags = "-x"
        Dim files = {"midsummer-night.txt"}
        Dim expected = String.Join(vbLf, Array.Empty(Of String)())
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_several_matches_case_insensitive_flag()
        Dim pattern = "ACHILLES"
        Dim flags = "-i"
        Dim files = {"iliad.txt"}
        Dim expected = String.Join(vbLf, {
            "Achilles sing, O Goddess! Peleus' son;",
            "The noble Chief Achilles from the son"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_several_matches_inverted_flag()
        Dim pattern = "Of"
        Dim flags = "-v"
        Dim files = {"paradise-lost.txt"}
        Dim expected = String.Join(vbLf, {
            "Brought Death into the World, and all our woe,",
            "With loss of Eden, till one greater Man",
            "Restore us, and regain the blissful Seat,",
            "Sing Heav'nly Muse, that on the secret top",
            "That Shepherd, who first taught the chosen Seed"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_no_matches_various_flags()
        Dim pattern = "Gandalf"
        Dim flags = "-n -l -x -i"
        Dim files = {"iliad.txt"}
        Dim expected = String.Join(vbLf, Array.Empty(Of String)())
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_one_match_file_flag_takes_precedence_over_line_flag()
        Dim pattern = "ten"
        Dim flags = "-n -l"
        Dim files = {"iliad.txt"}
        Dim expected = String.Join(vbLf, {
            "iliad.txt"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_several_matches_inverted_and_match_entire_lines_flags()
        Dim pattern = "Illustrious into Ades premature,"
        Dim flags = "-x -v"
        Dim files = {"iliad.txt"}
        Dim expected = String.Join(vbLf, {
            "Achilles sing, O Goddess! Peleus' son;",
            "His wrath pernicious, who ten thousand woes",
            "Caused to Achaia's host, sent many a soul",
            "And Heroes gave (so stood the will of Jove)",
            "To dogs and to all ravening fowls a prey,",
            "When fierce dispute had separated once",
            "The noble Chief Achilles from the son",
            "Of Atreus, Agamemnon, King of men."
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_one_match_no_flags()
        Dim pattern = "Agamemnon"
        Dim flags = ""
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = String.Join(vbLf, {
            "iliad.txt:Of Atreus, Agamemnon, King of men."
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_several_matches_no_flags()
        Dim pattern = "may"
        Dim flags = ""
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = String.Join(vbLf, {
            "midsummer-night.txt:Nor how it may concern my modesty,",
            "midsummer-night.txt:But I beseech your grace that I may know",
            "midsummer-night.txt:The worst that may befall me in this case,"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_several_matches_print_line_numbers_flag()
        Dim pattern = "that"
        Dim flags = "-n"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = String.Join(vbLf, {
            "midsummer-night.txt:5:But I beseech your grace that I may know",
            "midsummer-night.txt:6:The worst that may befall me in this case,",
            "paradise-lost.txt:2:Of that Forbidden Tree, whose mortal tast",
            "paradise-lost.txt:6:Sing Heav'nly Muse, that on the secret top"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_one_match_print_file_names_flag()
        Dim pattern = "who"
        Dim flags = "-l"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = String.Join(vbLf, {
            "iliad.txt",
            "paradise-lost.txt"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_several_matches_case_insensitive_flag()
        Dim pattern = "TO"
        Dim flags = "-i"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = String.Join(vbLf, {
            "iliad.txt:Caused to Achaia's host, sent many a soul",
            "iliad.txt:Illustrious into Ades premature,",
            "iliad.txt:And Heroes gave (so stood the will of Jove)",
            "iliad.txt:To dogs and to all ravening fowls a prey,",
            "midsummer-night.txt:I do entreat your grace to pardon me.",
            "midsummer-night.txt:In such a presence here to plead my thoughts;",
            "midsummer-night.txt:If I refuse to wed Demetrius.",
            "paradise-lost.txt:Brought Death into the World, and all our woe,",
            "paradise-lost.txt:Restore us, and regain the blissful Seat,",
            "paradise-lost.txt:Sing Heav'nly Muse, that on the secret top"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_several_matches_inverted_flag()
        Dim pattern = "a"
        Dim flags = "-v"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = String.Join(vbLf, {
            "iliad.txt:Achilles sing, O Goddess! Peleus' son;",
            "iliad.txt:The noble Chief Achilles from the son",
            "midsummer-night.txt:If I refuse to wed Demetrius."
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_one_match_match_entire_lines_flag()
        Dim pattern = "But I beseech your grace that I may know"
        Dim flags = "-x"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = String.Join(vbLf, {
            "midsummer-night.txt:But I beseech your grace that I may know"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_one_match_multiple_flags()
        Dim pattern = "WITH LOSS OF EDEN, TILL ONE GREATER MAN"
        Dim flags = "-n -i -x"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = String.Join(vbLf, {
            "paradise-lost.txt:4:With loss of Eden, till one greater Man"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_no_matches_various_flags()
        Dim pattern = "Frodo"
        Dim flags = "-n -l -x -i"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = String.Join(vbLf, Array.Empty(Of String)())
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_several_matches_file_flag_takes_precedence_over_line_number_flag()
        Dim pattern = "who"
        Dim flags = "-n -l"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = String.Join(vbLf, {
            "iliad.txt",
            "paradise-lost.txt"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_several_matches_inverted_and_match_entire_lines_flags()
        Dim pattern = "Illustrious into Ades premature,"
        Dim flags = "-x -v"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = String.Join(vbLf, {
            "iliad.txt:Achilles sing, O Goddess! Peleus' son;",
            "iliad.txt:His wrath pernicious, who ten thousand woes",
            "iliad.txt:Caused to Achaia's host, sent many a soul",
            "iliad.txt:And Heroes gave (so stood the will of Jove)",
            "iliad.txt:To dogs and to all ravening fowls a prey,",
            "iliad.txt:When fierce dispute had separated once",
            "iliad.txt:The noble Chief Achilles from the son",
            "iliad.txt:Of Atreus, Agamemnon, King of men.",
            "midsummer-night.txt:I do entreat your grace to pardon me.",
            "midsummer-night.txt:I know not by what power I am made bold,",
            "midsummer-night.txt:Nor how it may concern my modesty,",
            "midsummer-night.txt:In such a presence here to plead my thoughts;",
            "midsummer-night.txt:But I beseech your grace that I may know",
            "midsummer-night.txt:The worst that may befall me in this case,",
            "midsummer-night.txt:If I refuse to wed Demetrius.",
            "paradise-lost.txt:Of Mans First Disobedience, and the Fruit",
            "paradise-lost.txt:Of that Forbidden Tree, whose mortal tast",
            "paradise-lost.txt:Brought Death into the World, and all our woe,",
            "paradise-lost.txt:With loss of Eden, till one greater Man",
            "paradise-lost.txt:Restore us, and regain the blissful Seat,",
            "paradise-lost.txt:Sing Heav'nly Muse, that on the secret top",
            "paradise-lost.txt:Of Oreb, or of Sinai, didst inspire",
            "paradise-lost.txt:That Shepherd, who first taught the chosen Seed"
        })
        Assert.Equal(expected, Grep.Match(pattern, flags, files))
    End Sub


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
