Public Class CamiciaTests
    <Fact>
    Public Sub Two_cards_one_trick()
        Dim playerA = {"2"}
        Dim playerB = {"3"}
        Dim status = GameStatus.Finished
        Dim tricks = 1
        Dim cards = 2
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Three_cards_one_trick()
        Dim playerA = {"2", "4"}
        Dim playerB = {"3"}
        Dim status = GameStatus.Finished
        Dim tricks = 1
        Dim cards = 3
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Four_cards_one_trick()
        Dim playerA = {"2", "4"}
        Dim playerB = {"3", "5", "6"}
        Dim status = GameStatus.Finished
        Dim tricks = 1
        Dim cards = 4
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_ace_reigns_supreme()
        Dim playerA = {"2", "A"}
        Dim playerB = {"3", "4", "5", "6", "7"}
        Dim status = GameStatus.Finished
        Dim tricks = 1
        Dim cards = 7
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_king_beats_ace()
        Dim playerA = {"2", "A"}
        Dim playerB = {"3", "4", "5", "6", "K"}
        Dim status = GameStatus.Finished
        Dim tricks = 1
        Dim cards = 7
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_queen_seduces_the_king()
        Dim playerA = {"2", "A", "7", "8", "Q"}
        Dim playerB = {"3", "4", "5", "6", "K"}
        Dim status = GameStatus.Finished
        Dim tricks = 1
        Dim cards = 10
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_jack_betrays_the_queen()
        Dim playerA = {"2", "A", "7", "8", "Q"}
        Dim playerB = {"3", "4", "5", "6", "K", "9", "J"}
        Dim status = GameStatus.Finished
        Dim tricks = 1
        Dim cards = 12
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_Ten_just_wants_to_put_on_a_show()
        Dim playerA = {"2", "A", "7", "8", "Q", "10"}
        Dim playerB = {"3", "4", "5", "6", "K", "9", "J"}
        Dim status = GameStatus.Finished
        Dim tricks = 1
        Dim cards = 13
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Simple_loop_with_decks_of_3_cards()
        Dim playerA = {"J", "2", "3"}
        Dim playerB = {"4", "J", "5"}
        Dim status = GameStatus.[Loop]
        Dim tricks = 3
        Dim cards = 8
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub The_story_is_starting_to_get_a_bit_complicated()
        Dim playerA = {
            "2", "6", "6", "J", "4", "K", "Q", "10", "K", "J", "Q", "2",
            "3", "K", "5", "6", "Q", "Q", "A", "A", "6", "9", "K", "A",
            "8", "K", "2", "A", "9", "A", "Q", "4", "K", "K", "K", "3",
            "5", "K", "8", "Q", "3", "Q", "7", "J", "K", "J", "9", "J",
            "3", "3", "K", "K", "Q", "A", "K", "7", "10", "A", "Q", "7",
            "10", "J", "4", "5", "J", "9", "10", "Q", "J", "J", "K", "6",
            "10", "J", "6", "Q", "J", "5", "J", "Q", "Q", "8", "3", "8",
            "A", "2", "6", "9", "K", "7", "J", "K", "K", "8", "K", "Q",
            "6", "10", "J", "10", "J", "Q", "J", "10", "3", "8", "K", "A",
            "6", "9", "K", "2", "A", "A", "10", "J", "6", "A", "4", "J",
            "A", "J", "J", "6", "2", "J", "3", "K", "2", "5", "9", "J",
            "9", "6", "K", "A", "5", "Q", "J", "2", "Q", "K", "A", "3",
            "K", "J", "K", "2", "5", "6", "Q", "J", "Q", "Q", "J", "2",
            "J", "9", "Q", "7", "7", "A", "Q", "7", "Q", "J", "K", "J",
            "A", "7", "7", "8", "Q", "10", "J", "10", "J", "J", "9", "2",
            "A", "2"}
        Dim playerB = {
            "7", "2", "10", "K", "8", "2", "J", "9", "A", "5", "6", "J",
            "Q", "6", "K", "6", "5", "A", "4", "Q", "7", "J", "7", "10",
            "2", "Q", "8", "2", "2", "K", "J", "A", "5", "5", "A", "4",
            "Q", "6", "Q", "K", "10", "8", "Q", "2", "10", "J", "A", "Q",
            "8", "Q", "Q", "J", "J", "A", "A", "9", "10", "J", "K", "4",
            "Q", "10", "10", "J", "K", "10", "2", "J", "7", "A", "K", "K",
            "J", "A", "J", "10", "8", "K", "A", "7", "Q", "Q", "J", "3",
            "Q", "4", "A", "3", "A", "Q", "Q", "Q", "5", "4", "K", "J",
            "10", "A", "Q", "J", "6", "J", "A", "10", "A", "5", "8", "3",
            "K", "5", "9", "Q", "8", "7", "7", "J", "7", "Q", "Q", "Q",
            "A", "7", "8", "9", "A", "Q", "A", "K", "8", "A", "A", "J",
            "8", "4", "8", "K", "J", "A", "10", "Q", "8", "J", "8", "6",
            "10", "Q", "J", "J", "A", "A", "J", "5", "Q", "6", "J", "K",
            "Q", "8", "K", "4", "Q", "Q", "6", "J", "K", "4", "7", "J",
            "J", "9", "9", "A", "Q", "Q", "K", "A", "6", "5", "K"}
        Dim status = GameStatus.Finished
        Dim tricks = 1
        Dim cards = 361
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_tricks()
        Dim playerA = {"J"}
        Dim playerB = {"3", "J"}
        Dim status = GameStatus.Finished
        Dim tricks = 2
        Dim cards = 5
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub More_tricks()
        Dim playerA = {"J", "2", "4"}
        Dim playerB = {"3", "J", "A"}
        Dim status = GameStatus.Finished
        Dim tricks = 4
        Dim cards = 12
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Simple_loop_with_decks_of_4_cards()
        Dim playerA = {"2", "3", "J", "6"}
        Dim playerB = {"K", "5", "J", "7"}
        Dim status = GameStatus.[Loop]
        Dim tricks = 4
        Dim cards = 16
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Easy_card_combination()
        Dim playerA = {
            "4", "8", "7", "5", "4", "10", "3", "9", "7", "3", "10", "10",
            "6", "8", "2", "8", "5", "4", "5", "9", "6", "5", "2", "8",
            "10", "9"}
        Dim playerB = {
            "6", "9", "4", "7", "2", "2", "3", "6", "7", "3", "A", "A",
            "A", "A", "K", "K", "K", "K", "Q", "Q", "Q", "Q", "J", "J",
            "J", "J"}
        Dim status = GameStatus.Finished
        Dim tricks = 4
        Dim cards = 40
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Easy_card_combination_inverted_decks()
        Dim playerA = {
            "3", "3", "5", "7", "3", "2", "10", "7", "6", "7", "A", "A",
            "A", "A", "K", "K", "K", "K", "Q", "Q", "Q", "Q", "J", "J",
            "J", "J"}
        Dim playerB = {
            "5", "10", "8", "2", "6", "7", "2", "4", "9", "2", "6", "10",
            "10", "5", "4", "8", "4", "8", "6", "9", "8", "5", "9", "3",
            "4", "9"}
        Dim status = GameStatus.Finished
        Dim tricks = 4
        Dim cards = 40
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Mirrored_decks()
        Dim playerA = {
            "2", "A", "3", "A", "3", "K", "4", "K", "2", "Q", "2", "Q",
            "10", "J", "5", "J", "6", "10", "2", "9", "10", "7", "3", "9",
            "6", "9"}
        Dim playerB = {
            "6", "A", "4", "A", "7", "K", "4", "K", "7", "Q", "7", "Q",
            "5", "J", "8", "J", "4", "5", "8", "9", "10", "6", "8", "3",
            "8", "5"}
        Dim status = GameStatus.Finished
        Dim tricks = 4
        Dim cards = 59
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Opposite_decks()
        Dim playerA = {
            "4", "A", "9", "A", "4", "K", "9", "K", "6", "Q", "8", "Q",
            "8", "J", "10", "J", "9", "8", "4", "6", "3", "6", "5", "2",
            "4", "3"}
        Dim playerB = {
            "10", "7", "3", "2", "9", "2", "7", "8", "7", "5", "J", "7",
            "J", "10", "Q", "10", "Q", "3", "K", "5", "K", "6", "A", "2",
            "A", "5"}
        Dim status = GameStatus.Finished
        Dim tricks = 21
        Dim cards = 151
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Random_decks_1()
        Dim playerA = {
            "K", "10", "9", "8", "J", "8", "6", "9", "7", "A", "K", "5",
            "4", "4", "J", "5", "J", "4", "3", "5", "8", "6", "7", "7",
            "4", "9"}
        Dim playerB = {
            "6", "3", "K", "A", "Q", "10", "A", "2", "Q", "8", "2", "10",
            "10", "2", "Q", "3", "K", "9", "7", "A", "3", "Q", "5", "J",
            "2", "6"}
        Dim status = GameStatus.Finished
        Dim tricks = 76
        Dim cards = 542
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Random_decks_2()
        Dim playerA = {
            "8", "A", "4", "8", "5", "Q", "J", "2", "6", "2", "9", "7",
            "K", "A", "8", "10", "K", "8", "10", "9", "K", "6", "7", "3",
            "K", "9"}
        Dim playerB = {
            "10", "5", "2", "6", "Q", "J", "A", "9", "5", "5", "3", "7",
            "3", "J", "A", "2", "Q", "3", "J", "Q", "4", "10", "4", "7",
            "4", "6"}
        Dim status = GameStatus.Finished
        Dim tricks = 42
        Dim cards = 327
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Kleber_1999()
        Dim playerA = {
            "4", "8", "9", "J", "Q", "8", "5", "5", "K", "2", "A", "9",
            "8", "5", "10", "A", "4", "J", "3", "K", "6", "9", "2", "Q",
            "K", "7"}
        Dim playerB = {
            "10", "J", "3", "2", "4", "10", "4", "7", "5", "3", "6", "6",
            "7", "A", "J", "Q", "A", "7", "2", "10", "3", "K", "9", "6",
            "8", "Q"}
        Dim status = GameStatus.Finished
        Dim tricks = 805
        Dim cards = 5790
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Collins_2006()
        Dim playerA = {
            "A", "8", "Q", "K", "9", "10", "3", "7", "4", "2", "Q", "3",
            "2", "10", "9", "K", "A", "8", "7", "7", "4", "5", "J", "9",
            "2", "10"}
        Dim playerB = {
            "4", "J", "A", "K", "8", "5", "6", "6", "A", "6", "5", "Q",
            "4", "6", "10", "8", "J", "2", "5", "7", "Q", "J", "3", "3",
            "K", "9"}
        Dim status = GameStatus.Finished
        Dim tricks = 960
        Dim cards = 6913
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Mann_and_Wu_2007()
        Dim playerA = {
            "K", "2", "K", "K", "3", "3", "6", "10", "K", "6", "A", "2",
            "5", "5", "7", "9", "J", "A", "A", "3", "4", "Q", "4", "8",
            "J", "6"}
        Dim playerB = {
            "4", "5", "2", "Q", "7", "9", "9", "Q", "7", "J", "9", "8",
            "10", "3", "10", "J", "4", "10", "8", "6", "8", "7", "A", "Q",
            "5", "2"}
        Dim status = GameStatus.Finished
        Dim tricks = 1007
        Dim cards = 7157
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Nessler_2012()
        Dim playerA = {
            "10", "3", "6", "7", "Q", "2", "9", "8", "2", "8", "4", "A",
            "10", "6", "K", "2", "10", "A", "5", "A", "2", "4", "Q", "J",
            "K", "4"}
        Dim playerB = {
            "10", "Q", "4", "6", "J", "9", "3", "J", "9", "3", "3", "Q",
            "K", "5", "9", "5", "K", "6", "5", "7", "8", "J", "A", "7",
            "8", "7"}
        Dim status = GameStatus.Finished
        Dim tricks = 1015
        Dim cards = 7207
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Anderson_2013()
        Dim playerA = {
            "6", "7", "A", "3", "Q", "3", "5", "J", "3", "2", "J", "7",
            "4", "5", "Q", "10", "5", "A", "J", "2", "K", "8", "9", "9",
            "K", "3"}
        Dim playerB = {
            "4", "J", "6", "9", "8", "5", "10", "7", "9", "Q", "2", "7",
            "10", "8", "4", "10", "A", "6", "4", "A", "6", "8", "Q", "K",
            "K", "2"}
        Dim status = GameStatus.Finished
        Dim tricks = 1016
        Dim cards = 7225
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rucklidge_2014()
        Dim playerA = {
            "8", "J", "2", "9", "4", "4", "5", "8", "Q", "3", "9", "3",
            "6", "2", "8", "A", "A", "A", "9", "4", "7", "2", "5", "Q",
            "Q", "3"}
        Dim playerB = {
            "K", "7", "10", "6", "3", "J", "A", "7", "6", "5", "5", "8",
            "10", "9", "10", "4", "2", "7", "K", "Q", "10", "K", "6", "J",
            "J", "K"}
        Dim status = GameStatus.Finished
        Dim tricks = 1122
        Dim cards = 7959
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Nessler_2021()
        Dim playerA = {
            "7", "2", "3", "4", "K", "9", "6", "10", "A", "8", "9", "Q",
            "7", "A", "4", "8", "J", "J", "A", "4", "3", "2", "5", "6",
            "6", "J"}
        Dim playerB = {
            "3", "10", "8", "9", "8", "K", "K", "2", "5", "5", "7", "6",
            "4", "3", "5", "7", "A", "9", "J", "K", "2", "Q", "10", "Q",
            "10", "Q"}
        Dim status = GameStatus.Finished
        Dim tricks = 1106
        Dim cards = 7972
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Nessler_2022()
        Dim playerA = {
            "2", "10", "10", "A", "J", "3", "8", "Q", "2", "5", "5", "5",
            "9", "2", "4", "3", "10", "Q", "A", "K", "Q", "J", "J", "9",
            "Q", "K"}
        Dim playerB = {
            "10", "7", "6", "3", "6", "A", "8", "9", "4", "3", "K", "J",
            "6", "K", "4", "9", "7", "8", "5", "7", "8", "2", "A", "7",
            "4", "6"}
        Dim status = GameStatus.Finished
        Dim tricks = 1164
        Dim cards = 8344
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Casella_2024_first_infinite_game_found()
        Dim playerA = {
            "2", "8", "4", "K", "5", "2", "3", "Q", "6", "K", "Q", "A",
            "J", "3", "5", "9", "8", "3", "A", "A", "J", "4", "4", "J",
            "7", "5"}
        Dim playerB = {
            "7", "7", "8", "6", "10", "10", "6", "10", "7", "2", "Q", "6",
            "3", "2", "4", "K", "Q", "10", "J", "5", "9", "8", "9", "9",
            "K", "A"}
        Dim status = GameStatus.[Loop]
        Dim tricks = 66
        Dim cards = 474
        Dim expected = New GameResult(status, tricks, cards)

        Assert.Equal(expected, SimulateGame(playerA, playerB))
    End Sub
End Class
