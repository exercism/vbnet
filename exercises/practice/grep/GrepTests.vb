Imports System
Imports System.IO
Imports Xunit

Public Class GrepTests
    Implements IDisposable
    <Fact>
    Public Sub One_file_one_match_no_flags()
        Dim pattern = "Agamemnon"
        Dim flags = ""
        Dim files = {"iliad.txt"}
        Dim expected = "Of Atreus, Agamemnon, King of men."
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_one_match_print_line_numbers_flag()
        Dim pattern = "Forbidden"
        Dim flags = "-n"
        Dim files = {"paradise-lost.txt"}
        Dim expected = "2:Of that Forbidden Tree, whose mortal tast"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_one_match_case_insensitive_flag()
        Dim pattern = "FORBIDDEN"
        Dim flags = "-i"
        Dim files = {"paradise-lost.txt"}
        Dim expected = "Of that Forbidden Tree, whose mortal tast"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_one_match_print_file_names_flag()
        Dim pattern = "Forbidden"
        Dim flags = "-l"
        Dim files = {"paradise-lost.txt"}
        Dim expected = "paradise-lost.txt"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_one_match_match_entire_lines_flag()
        Dim pattern = "With loss of Eden, till one greater Man"
        Dim flags = "-x"
        Dim files = {"paradise-lost.txt"}
        Dim expected = "With loss of Eden, till one greater Man"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_one_match_multiple_flags()
        Dim pattern = "OF ATREUS, Agamemnon, KIng of MEN."
        Dim flags = "-n -i -x"
        Dim files = {"iliad.txt"}
        Dim expected = "9:Of Atreus, Agamemnon, King of men."
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_several_matches_no_flags()
        Dim pattern = "may"
        Dim flags = ""
        Dim files = {"midsummer-night.txt"}
        Dim expected = "Nor how it may concern my modesty," & vbLf & "But I beseech your grace that I may know" & vbLf & "The worst that may befall me in this case,"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_several_matches_print_line_numbers_flag()
        Dim pattern = "may"
        Dim flags = "-n"
        Dim files = {"midsummer-night.txt"}
        Dim expected = "3:Nor how it may concern my modesty," & vbLf & "5:But I beseech your grace that I may know" & vbLf & "6:The worst that may befall me in this case,"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_several_matches_match_entire_lines_flag()
        Dim pattern = "may"
        Dim flags = "-x"
        Dim files = {"midsummer-night.txt"}
        Dim expected = ""
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_several_matches_case_insensitive_flag()
        Dim pattern = "ACHILLES"
        Dim flags = "-i"
        Dim files = {"iliad.txt"}
        Dim expected = "Achilles sing, O Goddess! Peleus' son;" & vbLf & "The noble Chief Achilles from the son"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_several_matches_inverted_flag()
        Dim pattern = "Of"
        Dim flags = "-v"
        Dim files = {"paradise-lost.txt"}
        Dim expected = "Brought Death into the World, and all our woe," & vbLf & "With loss of Eden, till one greater Man" & vbLf & "Restore us, and regain the blissful Seat," & vbLf & "Sing Heav'nly Muse, that on the secret top" & vbLf & "That Shepherd, who first taught the chosen Seed"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_no_matches_various_flags()
        Dim pattern = "Gandalf"
        Dim flags = "-n -l -x -i"
        Dim files = {"iliad.txt"}
        Dim expected = ""
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_one_match_file_flag_takes_precedence_over_line_flag()
        Dim pattern = "ten"
        Dim flags = "-n -l"
        Dim files = {"iliad.txt"}
        Dim expected = "iliad.txt"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_file_several_matches_inverted_and_match_entire_lines_flags()
        Dim pattern = "Illustrious into Ades premature,"
        Dim flags = "-x -v"
        Dim files = {"iliad.txt"}
        Dim expected = "Achilles sing, O Goddess! Peleus' son;" & vbLf & "His wrath pernicious, who ten thousand woes" & vbLf & "Caused to Achaia's host, sent many a soul" & vbLf & "And Heroes gave (so stood the will of Jove)" & vbLf & "To dogs and to all ravening fowls a prey," & vbLf & "When fierce dispute had separated once" & vbLf & "The noble Chief Achilles from the son" & vbLf & "Of Atreus, Agamemnon, King of men."
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_one_match_no_flags()
        Dim pattern = "Agamemnon"
        Dim flags = ""
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = "iliad.txt:Of Atreus, Agamemnon, King of men."
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_several_matches_no_flags()
        Dim pattern = "may"
        Dim flags = ""
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = "midsummer-night.txt:Nor how it may concern my modesty," & vbLf & "midsummer-night.txt:But I beseech your grace that I may know" & vbLf & "midsummer-night.txt:The worst that may befall me in this case,"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_several_matches_print_line_numbers_flag()
        Dim pattern = "that"
        Dim flags = "-n"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = "midsummer-night.txt:5:But I beseech your grace that I may know" & vbLf & "midsummer-night.txt:6:The worst that may befall me in this case," & vbLf & "paradise-lost.txt:2:Of that Forbidden Tree, whose mortal tast" & vbLf & "paradise-lost.txt:6:Sing Heav'nly Muse, that on the secret top"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_one_match_print_file_names_flag()
        Dim pattern = "who"
        Dim flags = "-l"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = "iliad.txt" & vbLf & "paradise-lost.txt"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_several_matches_case_insensitive_flag()
        Dim pattern = "TO"
        Dim flags = "-i"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = "iliad.txt:Caused to Achaia's host, sent many a soul" & vbLf & "iliad.txt:Illustrious into Ades premature," & vbLf & "iliad.txt:And Heroes gave (so stood the will of Jove)" & vbLf & "iliad.txt:To dogs and to all ravening fowls a prey," & vbLf & "midsummer-night.txt:I do entreat your grace to pardon me." & vbLf & "midsummer-night.txt:In such a presence here to plead my thoughts;" & vbLf & "midsummer-night.txt:If I refuse to wed Demetrius." & vbLf & "paradise-lost.txt:Brought Death into the World, and all our woe," & vbLf & "paradise-lost.txt:Restore us, and regain the blissful Seat," & vbLf & "paradise-lost.txt:Sing Heav'nly Muse, that on the secret top"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_several_matches_inverted_flag()
        Dim pattern = "a"
        Dim flags = "-v"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = "iliad.txt:Achilles sing, O Goddess! Peleus' son;" & vbLf & "iliad.txt:The noble Chief Achilles from the son" & vbLf & "midsummer-night.txt:If I refuse to wed Demetrius."
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_one_match_match_entire_lines_flag()
        Dim pattern = "But I beseech your grace that I may know"
        Dim flags = "-x"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = "midsummer-night.txt:But I beseech your grace that I may know"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_one_match_multiple_flags()
        Dim pattern = "WITH LOSS OF EDEN, TILL ONE GREATER MAN"
        Dim flags = "-n -i -x"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = "paradise-lost.txt:4:With loss of Eden, till one greater Man"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_no_matches_various_flags()
        Dim pattern = "Frodo"
        Dim flags = "-n -l -x -i"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = ""
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_several_matches_file_flag_takes_precedence_over_line_number_flag()
        Dim pattern = "who"
        Dim flags = "-n -l"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = "iliad.txt" & vbLf & "paradise-lost.txt"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_files_several_matches_inverted_and_match_entire_lines_flags()
        Dim pattern = "Illustrious into Ades premature,"
        Dim flags = "-x -v"
        Dim files = {"iliad.txt", "midsummer-night.txt", "paradise-lost.txt"}
        Dim expected = "iliad.txt:Achilles sing, O Goddess! Peleus' son;" & vbLf & "iliad.txt:His wrath pernicious, who ten thousand woes" & vbLf & "iliad.txt:Caused to Achaia's host, sent many a soul" & vbLf & "iliad.txt:And Heroes gave (so stood the will of Jove)" & vbLf & "iliad.txt:To dogs and to all ravening fowls a prey," & vbLf & "iliad.txt:When fierce dispute had separated once" & vbLf & "iliad.txt:The noble Chief Achilles from the son" & vbLf & "iliad.txt:Of Atreus, Agamemnon, King of men." & vbLf & "midsummer-night.txt:I do entreat your grace to pardon me." & vbLf & "midsummer-night.txt:I know not by what power I am made bold," & vbLf & "midsummer-night.txt:Nor how it may concern my modesty," & vbLf & "midsummer-night.txt:In such a presence here to plead my thoughts;" & vbLf & "midsummer-night.txt:But I beseech your grace that I may know" & vbLf & "midsummer-night.txt:The worst that may befall me in this case," & vbLf & "midsummer-night.txt:If I refuse to wed Demetrius." & vbLf & "paradise-lost.txt:Of Mans First Disobedience, and the Fruit" & vbLf & "paradise-lost.txt:Of that Forbidden Tree, whose mortal tast" & vbLf & "paradise-lost.txt:Brought Death into the World, and all our woe," & vbLf & "paradise-lost.txt:With loss of Eden, till one greater Man" & vbLf & "paradise-lost.txt:Restore us, and regain the blissful Seat," & vbLf & "paradise-lost.txt:Sing Heav'nly Muse, that on the secret top" & vbLf & "paradise-lost.txt:Of Oreb, or of Sinai, didst inspire" & vbLf & "paradise-lost.txt:That Shepherd, who first taught the chosen Seed"
        Assert.Equal(expected, Match(pattern, flags, files))
    End Sub

    Private Const IliadFileName As String = "iliad.txt"
    Private Const IliadContents As String = "Achilles sing, O Goddess! Peleus' son;" & vbLf & "His wrath pernicious, who ten thousand woes" & vbLf & "Caused to Achaia's host, sent many a soul" & vbLf & "Illustrious into Ades premature," & vbLf & "And Heroes gave (so stood the will of Jove)" & vbLf & "To dogs and to all ravening fowls a prey," & vbLf & "When fierce dispute had separated once" & vbLf & "The noble Chief Achilles from the son" & vbLf & "Of Atreus, Agamemnon, King of men." & vbLf

    Private Const MidsummerNightFileName As String = "midsummer-night.txt"
    Private Const MidsummerNightContents As String = "I do entreat your grace to pardon me." & vbLf & "I know not by what power I am made bold," & vbLf & "Nor how it may concern my modesty," & vbLf & "In such a presence here to plead my thoughts;" & vbLf & "But I beseech your grace that I may know" & vbLf & "The worst that may befall me in this case," & vbLf & "If I refuse to wed Demetrius." & vbLf

    Private Const ParadiseLostFileName As String = "paradise-lost.txt"
    Private Const ParadiseLostContents As String = "Of Mans First Disobedience, and the Fruit" & vbLf & "Of that Forbidden Tree, whose mortal tast" & vbLf & "Brought Death into the World, and all our woe," & vbLf & "With loss of Eden, till one greater Man" & vbLf & "Restore us, and regain the blissful Seat," & vbLf & "Sing Heav'nly Muse, that on the secret top" & vbLf & "Of Oreb, or of Sinai, didst inspire" & vbLf & "That Shepherd, who first taught the chosen Seed" & vbLf

    Public Sub New()
        Call Directory.SetCurrentDirectory(Path.GetTempPath())
        File.WriteAllText(IliadFileName, IliadContents)
        File.WriteAllText(MidsummerNightFileName, MidsummerNightContents)
        File.WriteAllText(ParadiseLostFileName, ParadiseLostContents)
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Call Directory.SetCurrentDirectory(Path.GetTempPath())
        File.Delete(IliadFileName)
        File.Delete(MidsummerNightFileName)
        File.Delete(ParadiseLostFileName)
    End Sub
End Class
