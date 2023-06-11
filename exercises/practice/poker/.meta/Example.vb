Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text.RegularExpressions

Public Module Poker
    Private combinations As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer) From {
   {"1,1", 0},
   {"2,1", 1},
   {"2,2", 2},
   {"3,1", 3},
   {"3,2", 6},
   {"4,1", 7}
}

    Public Function BestHands(ByVal hands As IEnumerable(Of String)) As IEnumerable(Of String)
        Dim rankingHands = hands.[Select](Function(card) New With {
            card,
            .Rank = HandRank(card)
                                }).ToArray()
        Dim maxRank = rankingHands.Max(Function(hand) hand.Rank)
        Return rankingHands.Where(Function(pair) pair.Rank.Equals(maxRank)).[Select](Function(pair) pair.Card).ToArray()
    End Function

    Private Function HandRank(ByVal hand As String) As Tuple(Of Integer, Integer)
        Dim cards = hand.Split().[Select](Function(card) New Card(card)).ToArray()
        Dim ranks = HandRanks(cards)
        Dim results = ranks.GroupBy(Function(z) z).[Select](Function(gr) New With {
.Rank = gr.Key,
.Count = gr.Count()
                         }).OrderByDescending(Function(x) x.Count).ThenByDescending(Function(x) x.Rank).ToArray()
        Dim combination = String.Join(",", results.Take(2).[Select](Function(x) x.Count))
        Dim rest = results.[Select](Function(x) x.Rank).Aggregate(Function(acc, x) acc * 14 + x)
        Dim first = combinations(combination)
        If IsFlash(cards) Then first += 5

        If IsStraight(ranks) Then first += 4

        Return Tuple.Create(first, rest)
    End Function

    Private Function IsStraight(ByVal ranks As Integer()) As Boolean
        Return New HashSet(Of Integer)(ranks).Count = 5 AndAlso ranks.Max() - ranks.Min() = 4
    End Function

    Private Function IsFlash(ByVal cards As Card()) As Boolean
        Return New HashSet(Of String)(CType(Enumerable.Select(Of Card, Global.System.[String])(cards, CType(Function(card) CStr(card.Suit), Func(Of Card, String))), IEnumerable(Of String))).Count = 1
    End Function

    Private Function HandRanks(ByVal cards As Card()) As Integer()
        Dim ranks = cards.[Select](Function(card) card.Rank).OrderByDescending(Function(x) x).ToArray()
        If ranks.SequenceEqual({14, 5, 4, 3, 2}) Then Return {1, 2, 3, 4, 5}
        Return ranks
    End Function

    Private Function Rank(ByVal rankChar As Char) As Integer
        Return "--23456789TJQKA".IndexOf(rankChar)
    End Function

    Private Class Card
        Private Shared cardPattern As Regex = New Regex("(?<rank>\d+|[JQKA])(?<suit>[HSCD])")

        Public Property Rank As Integer
        Public Property Suit As String

        Public Sub New(ByVal card As String)
            Dim match = cardPattern.Match(card)
            If Not match.Success Then Throw New ArgumentOutOfRangeException("Wrong card {0}", card)

            Dim rank = match.Groups("rank").Value
            Dim result As Integer = Nothing
            Me.Rank = If(Integer.TryParse(rank, result), result, "--23456789TJQKA".IndexOf(rank))
            Suit = match.Groups("suit").Value
        End Sub

        Public Overrides Function ToString() As String
            Return $"Rank = {Rank}, Suit = {Suit}"
        End Function
    End Class
End Module
