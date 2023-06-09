Imports System
Imports Xunit

Public Class ProverbTests
    <Fact>
    Public Sub Zero_pieces()
        Dim strings = Array.Empty(Of String)()
        Dim expected = Array.Empty(Of String)()
        Assert.Equal(expected, Recite(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub One_piece()
        Dim strings = {"nail"}
        Dim expected = {"And all for the want of a nail."}
        Assert.Equal(expected, Recite(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_pieces()
        Dim strings = {"nail", "shoe"}
        Dim expected = {"For want of a nail the shoe was lost.", "And all for the want of a nail."}
        Assert.Equal(expected, Recite(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Three_pieces()
        Dim strings = {"nail", "shoe", "horse"}
        Dim expected = {"For want of a nail the shoe was lost.", "For want of a shoe the horse was lost.", "And all for the want of a nail."}
        Assert.Equal(expected, Recite(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_proverb()
        Dim strings = {"nail", "shoe", "horse", "rider", "message", "battle", "kingdom"}
        Dim expected = {"For want of a nail the shoe was lost.", "For want of a shoe the horse was lost.", "For want of a horse the rider was lost.", "For want of a rider the message was lost.", "For want of a message the battle was lost.", "For want of a battle the kingdom was lost.", "And all for the want of a nail."}
        Assert.Equal(expected, Recite(strings))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Four_pieces_modernized()
        Dim strings = {"pin", "gun", "soldier", "battle"}
        Dim expected = {"For want of a pin the gun was lost.", "For want of a gun the soldier was lost.", "For want of a soldier the battle was lost.", "And all for the want of a pin."}
        Assert.Equal(expected, Recite(strings))
    End Sub
End Class
