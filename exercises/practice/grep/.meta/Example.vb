Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text.RegularExpressions

Public Module Grep
    Private Class Line
        Public Property Number As Integer
        Public Property Text As String
        Public Property File As String
    End Class

    <Flags>
    Private Enum Flags
        None = 0
        PrintLineNumbers = 1
        PrintFileNames = 2
        CaseInsensitive = 4
        Invert = 8
        MatchEntireLines = 16
    End Enum

    Public Function Match(ByVal pattern As String, ByVal flags As String, ByVal files As String()) As String
        Dim parsedFlags = ParseFlags(flags)

        If parsedFlags.HasFlag(Grep.Flags.PrintFileNames) Then
            Return FormatMatchingFiles(pattern, parsedFlags, files)
        End If

        Return FormatMatchingLines(pattern, parsedFlags, files)
    End Function

    Private Function ParseFlags(ByVal flags As String) As Flags
        Return flags.Split(" "c).Aggregate(Grep.Flags.None, Function(acc, flag) acc Or ParseFlag(flag))
    End Function

    Private Function ParseFlag(ByVal flag As String) As Flags
        Select Case flag
            Case "-n"
                Return Flags.PrintLineNumbers
            Case "-l"
                Return Flags.PrintFileNames
            Case "-i"
                Return Flags.CaseInsensitive
            Case "-v"
                Return Flags.Invert
            Case "-x"
                Return Flags.MatchEntireLines
            Case Else
                Return Flags.None
        End Select
    End Function

    Private Function IsMatch(ByVal pattern As String, ByVal flags As Flags) As Func(Of Line, Boolean)
        Dim matchPattern = If(flags.HasFlag(Flags.MatchEntireLines), $"^{pattern}$", pattern)
        Dim options = If(flags.HasFlag(Flags.CaseInsensitive), RegexOptions.IgnoreCase, RegexOptions.None)
        Dim regex = New Regex(matchPattern, options)

        Return Function(line) regex.IsMatch(line.Text) <> flags.HasFlag(Flags.Invert)
    End Function

    Private Function FindMatchingLines(ByVal pattern As String, ByVal flags As Flags, ByVal file As String) As IEnumerable(Of Line)
        Dim isMatch = Grep.IsMatch(pattern, flags)

        Return IO.File.ReadAllLines(file).Select(Function(line, index) CreateLine(file, index, line)).Where(isMatch)
    End Function

    Private Function CreateLine(ByVal file As String, ByVal index As Integer, ByVal text As String) As Line
        Return New Line With {
            .File = file,
            .Number = index + 1,
            .Text = text
        }
    End Function

    Private Function FormatMatchingFile(ByVal file As String) As String
        Return $"{file}"
    End Function

    Private Function FormatMatchingFiles(ByVal pattern As String, ByVal flags As Flags, ByVal files As String()) As String
        Dim matchingFiles = files.Where(Function(file) FindMatchingLines(pattern, flags, file).Any()).[Select](New Func(Of String, String)(AddressOf FormatMatchingFile))

        Return String.Join(vbLf, matchingFiles)
    End Function

    Private Function FormatMatchingLine(ByVal flags As Flags, ByVal files As String(), ByVal line As Line) As String
        Dim printLineNumbers = flags.HasFlag(Flags.PrintLineNumbers)
        Dim printFileName = files.Length > 1

        If printLineNumbers AndAlso printFileName Then
            Return $"{line.File}:{line.Number}:{line.Text}"
        End If
        If printLineNumbers AndAlso Not printFileName Then
            Return $"{line.Number}:{line.Text}"
        End If
        If Not printLineNumbers AndAlso printFileName Then
            Return $"{line.File}:{line.Text}"
        End If

        Return $"{line.Text}"
    End Function

    Private Function FormatMatchingLines(ByVal pattern As String, ByVal flags As Flags, ByVal files As String()) As String
        Dim matchingFiles = files.SelectMany(Function(file) FindMatchingLines(pattern, flags, file)).Select(Function(line) FormatMatchingLine(flags, files, line))

        Return String.Join(vbLf, matchingFiles)
    End Function
End Module
