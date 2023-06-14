Imports System.IO
Imports System.Text
Imports Xunit

Public Class TournamentTests
    <Fact>
    Public Sub Just_the_header_if_no_input()
        Dim rows = ""
        Dim expected = "Team                           | MP |  W |  D |  L |  P"
        Assert.Equal(expected, RunTally(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_win_is_three_points_a_loss_is_zero_points()
        Dim rows = "Allegoric Alaskans;Blithering Badgers;win"
        Dim expected = "Team                           | MP |  W |  D |  L |  P" & vbLf & "Allegoric Alaskans             |  1 |  1 |  0 |  0 |  3" & vbLf & "Blithering Badgers             |  1 |  0 |  0 |  1 |  0"
        Assert.Equal(expected, RunTally(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_win_can_also_be_expressed_as_a_loss()
        Dim rows = "Blithering Badgers;Allegoric Alaskans;loss"
        Dim expected = "Team                           | MP |  W |  D |  L |  P" & vbLf & "Allegoric Alaskans             |  1 |  1 |  0 |  0 |  3" & vbLf & "Blithering Badgers             |  1 |  0 |  0 |  1 |  0"
        Assert.Equal(expected, RunTally(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_different_team_can_win()
        Dim rows = "Blithering Badgers;Allegoric Alaskans;win"
        Dim expected = "Team                           | MP |  W |  D |  L |  P" & vbLf & "Blithering Badgers             |  1 |  1 |  0 |  0 |  3" & vbLf & "Allegoric Alaskans             |  1 |  0 |  0 |  1 |  0"
        Assert.Equal(expected, RunTally(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub A_draw_is_one_point_each()
        Dim rows = "Allegoric Alaskans;Blithering Badgers;draw"
        Dim expected = "Team                           | MP |  W |  D |  L |  P" & vbLf & "Allegoric Alaskans             |  1 |  0 |  1 |  0 |  1" & vbLf & "Blithering Badgers             |  1 |  0 |  1 |  0 |  1"
        Assert.Equal(expected, RunTally(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub There_can_be_more_than_one_match()
        Dim rows = "Allegoric Alaskans;Blithering Badgers;win" & vbLf & "Allegoric Alaskans;Blithering Badgers;win"
        Dim expected = "Team                           | MP |  W |  D |  L |  P" & vbLf & "Allegoric Alaskans             |  2 |  2 |  0 |  0 |  6" & vbLf & "Blithering Badgers             |  2 |  0 |  0 |  2 |  0"
        Assert.Equal(expected, RunTally(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub There_can_be_more_than_one_winner()
        Dim rows = "Allegoric Alaskans;Blithering Badgers;loss" & vbLf & "Allegoric Alaskans;Blithering Badgers;win"
        Dim expected = "Team                           | MP |  W |  D |  L |  P" & vbLf & "Allegoric Alaskans             |  2 |  1 |  0 |  1 |  3" & vbLf & "Blithering Badgers             |  2 |  1 |  0 |  1 |  3"
        Assert.Equal(expected, RunTally(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub There_can_be_more_than_two_teams()
        Dim rows = "Allegoric Alaskans;Blithering Badgers;win" & vbLf & "Blithering Badgers;Courageous Californians;win" & vbLf & "Courageous Californians;Allegoric Alaskans;loss"
        Dim expected = "Team                           | MP |  W |  D |  L |  P" & vbLf & "Allegoric Alaskans             |  2 |  2 |  0 |  0 |  6" & vbLf & "Blithering Badgers             |  2 |  1 |  0 |  1 |  3" & vbLf & "Courageous Californians        |  2 |  0 |  0 |  2 |  0"
        Assert.Equal(expected, RunTally(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Typical_input()
        Dim rows = "Allegoric Alaskans;Blithering Badgers;win" & vbLf & "Devastating Donkeys;Courageous Californians;draw" & vbLf & "Devastating Donkeys;Allegoric Alaskans;win" & vbLf & "Courageous Californians;Blithering Badgers;loss" & vbLf & "Blithering Badgers;Devastating Donkeys;loss" & vbLf & "Allegoric Alaskans;Courageous Californians;win"
        Dim expected = "Team                           | MP |  W |  D |  L |  P" & vbLf & "Devastating Donkeys            |  3 |  2 |  1 |  0 |  7" & vbLf & "Allegoric Alaskans             |  3 |  2 |  0 |  1 |  6" & vbLf & "Blithering Badgers             |  3 |  1 |  0 |  2 |  3" & vbLf & "Courageous Californians        |  3 |  0 |  1 |  2 |  1"
        Assert.Equal(expected, RunTally(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Incomplete_competition_not_all_pairs_have_played_()
        Dim rows = "Allegoric Alaskans;Blithering Badgers;loss" & vbLf & "Devastating Donkeys;Allegoric Alaskans;loss" & vbLf & "Courageous Californians;Blithering Badgers;draw" & vbLf & "Allegoric Alaskans;Courageous Californians;win"
        Dim expected = "Team                           | MP |  W |  D |  L |  P" & vbLf & "Allegoric Alaskans             |  3 |  2 |  0 |  1 |  6" & vbLf & "Blithering Badgers             |  2 |  1 |  1 |  0 |  4" & vbLf & "Courageous Californians        |  2 |  0 |  1 |  1 |  1" & vbLf & "Devastating Donkeys            |  1 |  0 |  0 |  1 |  0"
        Assert.Equal(expected, RunTally(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ties_broken_alphabetically()
        Dim rows = "Courageous Californians;Devastating Donkeys;win" & vbLf & "Allegoric Alaskans;Blithering Badgers;win" & vbLf & "Devastating Donkeys;Allegoric Alaskans;loss" & vbLf & "Courageous Californians;Blithering Badgers;win" & vbLf & "Blithering Badgers;Devastating Donkeys;draw" & vbLf & "Allegoric Alaskans;Courageous Californians;draw"
        Dim expected = "Team                           | MP |  W |  D |  L |  P" & vbLf & "Allegoric Alaskans             |  3 |  2 |  1 |  0 |  7" & vbLf & "Courageous Californians        |  3 |  2 |  1 |  0 |  7" & vbLf & "Blithering Badgers             |  3 |  0 |  1 |  2 |  1" & vbLf & "Devastating Donkeys            |  3 |  0 |  1 |  2 |  1"
        Assert.Equal(expected, RunTally(rows))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Ensure_points_sorted_numerically()
        Dim rows = "Devastating Donkeys;Blithering Badgers;win" & vbLf & "Devastating Donkeys;Blithering Badgers;win" & vbLf & "Devastating Donkeys;Blithering Badgers;win" & vbLf & "Devastating Donkeys;Blithering Badgers;win" & vbLf & "Blithering Badgers;Devastating Donkeys;win"
        Dim expected = "Team                           | MP |  W |  D |  L |  P" & vbLf & "Devastating Donkeys            |  5 |  4 |  0 |  1 | 12" & vbLf & "Blithering Badgers             |  5 |  1 |  0 |  4 |  3"
        Assert.Equal(expected, RunTally(rows))
    End Sub

    Private Function RunTally(ByVal input As String) As String
        Dim encoding = New UTF8Encoding()
        Using inStream = New MemoryStream(encoding.GetBytes(input))
            Using outStream = New MemoryStream()
                Tournament.Tally(inStream, outStream)
                Return encoding.GetString(outStream.ToArray())
            End Using
        End Using
    End Function
End Class
