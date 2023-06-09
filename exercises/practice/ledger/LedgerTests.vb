Imports Xunit

Public Class LedgerTests
    <Fact>
    Public Sub Empty_ledger()
        Dim currency = "USD"
        Dim locale = "en-US"
        Dim entries = New LedgerEntry(-1) {}
        Dim expected = "Date       | Description               | Change       "

        Assert.Equal(expected, Format(currency, locale, entries))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_entry()
        Dim currency = "USD"
        Dim locale = "en-US"
        Dim entries = {CreateEntry("2015-01-01", "Buy present", -1000)}
        Dim expected = "Date       | Description               | Change       " & vbLf & "01/01/2015 | Buy present               |      ($10.00)"

        Assert.Equal(expected, Format(currency, locale, entries))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Credit_and_debit()
        Dim currency = "USD"
        Dim locale = "en-US"
        Dim entries = {CreateEntry("2015-01-02", "Get present", 1000), CreateEntry("2015-01-01", "Buy present", -1000)}
        Dim expected = "Date       | Description               | Change       " & vbLf & "01/01/2015 | Buy present               |      ($10.00)" & vbLf & "01/02/2015 | Get present               |       $10.00 "

        Assert.Equal(expected, Format(currency, locale, entries))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_entries_on_same_date_ordered_by_description()
        Dim currency = "USD"
        Dim locale = "en-US"
        Dim entries = {CreateEntry("2015-01-01", "Buy present", -1000), CreateEntry("2015-01-01", "Get present", 1000)}
        Dim expected = "Date       | Description               | Change       " & vbLf & "01/01/2015 | Buy present               |      ($10.00)" & vbLf & "01/01/2015 | Get present               |       $10.00 "

        Assert.Equal(expected, Format(currency, locale, entries))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Final_order_tie_breaker_is_change()
        Dim currency = "USD"
        Dim locale = "en-US"
        Dim entries = {CreateEntry("2015-01-01", "Something", 0), CreateEntry("2015-01-01", "Something", -1), CreateEntry("2015-01-01", "Something", 1)}
        Dim expected = "Date       | Description               | Change       " & vbLf & "01/01/2015 | Something                 |       ($0.01)" & vbLf & "01/01/2015 | Something                 |        $0.00 " & vbLf & "01/01/2015 | Something                 |        $0.01 "

        Assert.Equal(expected, Format(currency, locale, entries))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Overlong_descriptions()
        Dim currency = "USD"
        Dim locale = "en-US"
        Dim entries = {CreateEntry("2015-01-01", "Freude schoner Gotterfunken", -123456)}
        Dim expected = "Date       | Description               | Change       " & vbLf & "01/01/2015 | Freude schoner Gotterf... |   ($1,234.56)"

        Assert.Equal(expected, Format(currency, locale, entries))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Euros()
        Dim currency = "EUR"
        Dim locale = "en-US"
        Dim entries = {CreateEntry("2015-01-01", "Buy present", -1000)}
        Dim expected = "Date       | Description               | Change       " & vbLf & "01/01/2015 | Buy present               |      (€10.00)"

        Assert.Equal(expected, Format(currency, locale, entries))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Dutch_locale()
        Dim currency = "USD"
        Dim locale = "nl-NL"
        Dim entries = {CreateEntry("2015-03-12", "Buy present", 123456)}
        Dim expected = "Datum      | Omschrijving              | Verandering  " & vbLf & "12-03-2015 | Buy present               |   $ 1.234,56 "

        Assert.Equal(expected, Format(currency, locale, entries))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Dutch_negative_number_with_3_digits_before_decimal_point()
        Dim currency = "USD"
        Dim locale = "nl-NL"
        Dim entries = {CreateEntry("2015-03-12", "Buy present", -12345)}
        Dim expected = "Datum      | Omschrijving              | Verandering  " & vbLf & "12-03-2015 | Buy present               |     $ -123,45"

        Assert.Equal(expected, Format(currency, locale, entries))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub American_negative_number_with_3_digits_before_decimal_point()
        Dim currency = "USD"
        Dim locale = "en-US"
        Dim entries = {CreateEntry("2015-03-12", "Buy present", -12345)}
        Dim expected = "Date       | Description               | Change       " & vbLf & "03/12/2015 | Buy present               |     ($123.45)"

        Assert.Equal(expected, Format(currency, locale, entries))
    End Sub
End Class
