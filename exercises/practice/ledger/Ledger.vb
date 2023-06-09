Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq

Public Class LedgerEntry
    Public Sub New(ByVal [date] As Date, ByVal desc As String, ByVal chg As Decimal)
        Me.Date = [date]
        Me.Desc = desc
        Me.Chg = chg
    End Sub

    Public ReadOnly Property DateProp As Date
    Public ReadOnly Property Desc As String
    Public ReadOnly Property Chg As Decimal
End Class

Public Module Ledger
    Public Function CreateEntry(ByVal [date] As String, ByVal desc As String, ByVal chng As Integer) As LedgerEntry
        Return New LedgerEntry(Date.Parse([date], CultureInfo.InvariantCulture), desc, chng / 100.0D)
    End Function

    Private Function CreateCulture(ByVal cur As String, ByVal loc As String) As CultureInfo
        Dim curSymb As String = Nothing
        Dim curNeg = 0
        Dim datPat As String = Nothing

        If Not Equals(cur, "USD") AndAlso Not Equals(cur, "EUR") Then
            Throw New ArgumentException("Invalid currency")
        Else
            If Not Equals(loc, "nl-NL") AndAlso Not Equals(loc, "en-US") Then
                Throw New ArgumentException("Invalid currency")
            End If

            If Equals(cur, "USD") Then
                If Equals(loc, "en-US") Then
                    curSymb = "$"
                    datPat = "MM/dd/yyyy"
                ElseIf Equals(loc, "nl-NL") Then
                    curSymb = "$"
                    curNeg = 12
                    datPat = "dd/MM/yyyy"
                End If
            End If

            If Equals(cur, "EUR") Then
                If Equals(loc, "en-US") Then
                    curSymb = "€"
                    datPat = "MM/dd/yyyy"
                ElseIf Equals(loc, "nl-NL") Then
                    curSymb = "€"
                    curNeg = 12
                    datPat = "dd/MM/yyyy"
                End If
            End If
        End If

        Dim culture = New CultureInfo(loc)
        culture.NumberFormat.CurrencySymbol = curSymb
        culture.NumberFormat.CurrencyNegativePattern = curNeg
        culture.DateTimeFormat.ShortDatePattern = datPat
        Return culture
    End Function

    Private Function PrintHead(ByVal loc As String) As String
        If Equals(loc, "en-US") Then
            Return "Date       | Description               | Change       "
        Else
            If Equals(loc, "nl-NL") Then
                Return "Datum      | Omschrijving              | Verandering  "
            Else
                Throw New ArgumentException("Invalid locale")
            End If
        End If
    End Function

    Private Function [Date](ByVal culture As IFormatProvider, ByVal [date] As Date) As String
        Return [date].ToString("d", culture)
    End Function

    Private Function Description(ByVal desc As String) As String
        If desc.Length > 25 Then
            Dim trunc = desc.Substring(0, 22)
            trunc += "..."
            Return trunc
        End If

        Return desc
    End Function

    Private Function Change(ByVal culture As IFormatProvider, ByVal cgh As Decimal) As String
        Return If(cgh < 0.0D, cgh.ToString("C", culture), cgh.ToString("C", culture) & " ")
    End Function

    Private Function PrintEntry(ByVal culture As IFormatProvider, ByVal entry As LedgerEntry) As String
        Dim formatted = ""
        Dim [date] = Ledger.Date(culture, entry.Date)
        Dim description = Ledger.Description(entry.Desc)
        Dim change = Ledger.Change(culture, entry.Chg)

        formatted += [date]
        formatted += " | "
        formatted += String.Format("{0,-25}", description)
        formatted += " | "
        formatted += String.Format("{0,13}", change)

        Return formatted
    End Function


    Private Function sort(ByVal entries As LedgerEntry()) As IEnumerable(Of LedgerEntry)
        Dim neg = entries.Where(Function(e) e.Chg < 0).OrderBy(Function(x) x.Date.ToString() & "@" & x.Desc & "@" & x.Chg.ToString())
        Dim post = entries.Where(Function(e) e.Chg >= 0).OrderBy(Function(x) x.Date.ToString() & "@" & x.Desc & "@" & x.Chg.ToString())

        Dim result = New List(Of LedgerEntry)()
        result.AddRange(neg)
        result.AddRange(post)

        Return result
    End Function

    Public Function Format(ByVal currency As String, ByVal locale As String, ByVal entries As LedgerEntry()) As String
        Dim formatted = ""
        formatted += PrintHead(locale)

        Dim culture = CreateCulture(currency, locale)

        If entries.Length > 0 Then
            Dim entriesForOutput = sort(entries)

            For i = 0 To entriesForOutput.Count() - 1
                formatted += vbLf & PrintEntry(culture, entriesForOutput.Skip(i).First())
            Next
        End If

        Return formatted
    End Function
End Module
