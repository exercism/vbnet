Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq

Public Class LedgerEntry
    Public Sub New(ByVal [date] As Date, ByVal description As String, ByVal change As Decimal)
        Me.Date = [date]
        Me.Description = description
        Me.Change = change
    End Sub

    Public ReadOnly Property [Date] As Date
    Public ReadOnly Property Description As String
    Public ReadOnly Property Change As Decimal
End Class

Public Module Ledger
    Private Const TruncateLength As Integer = 25
    Private Const TruncateSuffix As String = "..."

    Public Function CreateEntry(ByVal [date] As String, ByVal description As String, ByVal change As Integer) As LedgerEntry
        Return New LedgerEntry(ParseDate([date]), description, ParseChange(change))
    End Function

    Private Function ParseDate(ByVal [date] As String) As Date
        Return Date.Parse([date], Globalization.CultureInfo.InvariantCulture)
    End Function

    Private Function ParseChange(ByVal change As Integer) As Decimal
        Return change / 100.0D
    End Function

    Private Function CultureInfo(ByVal locale As String) As CultureInfo
        Select Case locale
            Case "en-US"
                Return New CultureInfo("en-US")
            Case "nl-NL"
                Return New CultureInfo("nl-NL")
            Case Else
                Throw New ArgumentException("Invalid locale")
        End Select
    End Function

    Private Function CurrencySymbol(ByVal currency As String) As String
        Select Case currency
            Case "USD"
                Return "$"
            Case "EUR"
                Return "€"
            Case Else
                Throw New ArgumentException("Invalid currency")
        End Select
    End Function

    Private Function CurrencyNegativePattern(ByVal locale As String) As Integer
        Select Case locale
            Case "en-US"
                Return 0
            Case "nl-NL"
                Return 12
            Case Else
                Throw New ArgumentException("Invalid locale")
        End Select
    End Function

    Private Function ShortDateFormat(ByVal locale As String) As String
        Select Case locale
            Case "en-US"
                Return "MM/dd/yyyy"
            Case "nl-NL"
                Return "dd/MM/yyyy"
            Case Else
                Throw New ArgumentException("Invalid locale")
        End Select
    End Function

    Private Function getCulture(ByVal currency As String, ByVal locale As String) As CultureInfo
        Dim culture = CultureInfo(locale)
        culture.NumberFormat.CurrencySymbol = CurrencySymbol(currency)
        culture.NumberFormat.CurrencyNegativePattern = CurrencyNegativePattern(locale)
        culture.DateTimeFormat.ShortDatePattern = ShortDateFormat(locale)
        Return culture
    End Function

    Private Function FormatHeader(ByVal culture As CultureInfo) As String
        Select Case culture.Name
            Case "en-US"
                Return "Date       | Description               | Change       "
            Case "nl-NL"
                Return "Datum      | Omschrijving              | Verandering  "
            Case Else
                Throw New ArgumentException("Invalid locale")
        End Select
    End Function

    Private Function FormatDate(ByVal culture As IFormatProvider, ByVal [date] As Date) As String
        Return [date].ToString("d", culture)
    End Function

    Private Function FormatDescription(ByVal description As String) As String
        Return If(description.Length <= TruncateLength, description, description.Substring(0, TruncateLength - TruncateSuffix.Length) & TruncateSuffix)
    End Function

    Private Function FormatChange(ByVal culture As IFormatProvider, ByVal change As Decimal) As String
        Return If(change < 0.0D, change.ToString("C", culture), change.ToString("C", culture) & " ")
    End Function

    Private Function FormatEntry(ByVal culture As IFormatProvider, ByVal entry As LedgerEntry) As String
        Return String.Format("{0} | {1,-25} | {2,13}", FormatDate(culture, entry.Date), FormatDescription(entry.Description), FormatChange(culture, entry.Change))
    End Function

    Private Function OrderEntries(ByVal entries As LedgerEntry()) As IEnumerable(Of LedgerEntry)
        Return entries.OrderBy(Function(x) x.Date).ThenBy(Function(x) x.Description).ThenBy(Function(x) x.Change)
    End Function

    Public Function Format(ByVal currency As String, ByVal locale As String, ByVal entries As LedgerEntry()) As String
        Dim culture = getCulture(currency, locale)
        Dim header = FormatHeader(culture)
        Dim printedEntries = OrderEntries(entries).Select(Function(entry) FormatEntry(culture, entry))
        Dim lines = {header}.Concat(printedEntries)

        Return String.Join(vbLf, lines)
    End Function
End Module
