Imports System.Linq
Imports System.Text

Public Module TwelveDays
    Public Function Recite(ByVal verseNumber As Integer) As String
        Select Case verseNumber
            Case 1
                Return "On the first day of Christmas my true love gave to me: a Partridge in a Pear Tree."
            Case 2
                Return "On the second day of Christmas my true love gave to me: two Turtle Doves, and a Partridge in a Pear Tree."
            Case 3
                Return "On the third day of Christmas my true love gave to me: three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
            Case 4
                Return "On the fourth day of Christmas my true love gave to me: four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
            Case 5
                Return "On the fifth day of Christmas my true love gave to me: five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
            Case 6
                Return "On the sixth day of Christmas my true love gave to me: six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
            Case 7
                Return "On the seventh day of Christmas my true love gave to me: seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
            Case 8
                Return "On the eighth day of Christmas my true love gave to me: eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
            Case 9
                Return "On the ninth day of Christmas my true love gave to me: nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
            Case 10
                Return "On the tenth day of Christmas my true love gave to me: ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
            Case 11
                Return "On the eleventh day of Christmas my true love gave to me: eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
            Case 12
                Return "On the twelfth day of Christmas my true love gave to me: twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."
            Case Else
                Return ""
        End Select
    End Function

    Public Function Recite(ByVal start As Integer, ByVal [end] As Integer) As String
        Dim stringBuilder = New StringBuilder()

        Enumerable.ToList(Enumerable.Range(start, [end] - start + 1)).ForEach(Sub(i) stringBuilder.Append(Recite(i)).Append(vbLf))

        Return stringBuilder.ToString().Trim()
    End Function
End Module
