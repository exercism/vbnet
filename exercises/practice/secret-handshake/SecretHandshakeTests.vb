Imports Xunit

Public Class SecretHandshakeTests
    <Fact>
    Public Sub Wink_for_1()
        Assert.Equal({"wink"}, SecretHandshake.Commands(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Double_blink_for_10()
        Assert.Equal({"double blink"}, SecretHandshake.Commands(2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Close_your_eyes_for_100()
        Assert.Equal({"close your eyes"}, SecretHandshake.Commands(4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Jump_for_1000()
        Assert.Equal({"jump"}, SecretHandshake.Commands(8))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Combine_two_actions()
        Assert.Equal({"wink", "double blink"}, SecretHandshake.Commands(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reverse_two_actions()
        Assert.Equal({"double blink", "wink"}, SecretHandshake.Commands(19))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reversing_one_action_gives_the_same_action()
        Assert.Equal({"jump"}, SecretHandshake.Commands(24))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reversing_no_actions_still_gives_no_actions()
        Assert.Empty(SecretHandshake.Commands(16))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub All_possible_actions()
        Assert.Equal({"wink", "double blink", "close your eyes", "jump"}, SecretHandshake.Commands(15))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reverse_all_possible_actions()
        Assert.Equal({"jump", "close your eyes", "double blink", "wink"}, SecretHandshake.Commands(31))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Do_nothing_for_zero()
        Assert.Empty(SecretHandshake.Commands(0))
    End Sub
End Class
