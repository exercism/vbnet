Imports System.Collections.Generic
Imports Xunit

Public Class SublistTests
    <Fact>
    Public Sub Empty_lists()
        Assert.Equal(SublistType.Equal, Classify(New List(Of Integer)(), New List(Of Integer)()))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Empty_list_within_non_empty_list()
        Assert.Equal(SublistType.Sublist, Classify(New List(Of Integer)(), New List(Of Integer) From {
            1,
            2,
            3
        }))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Non_empty_list_contains_empty_list()
        Assert.Equal(SublistType.Superlist, Classify(New List(Of Integer) From {
            1,
            2,
            3
        }, New List(Of Integer)()))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub List_equals_itself()
        Assert.Equal(SublistType.Equal, Classify(New List(Of Integer) From {
            1,
            2,
            3
        }, New List(Of Integer) From {
            1,
            2,
            3
        }))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Different_lists()
        Assert.Equal(SublistType.Unequal, Classify(New List(Of Integer) From {
            1,
            2,
            3
        }, New List(Of Integer) From {
            2,
            3,
            4
        }))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub False_start()
        Assert.Equal(SublistType.Sublist, Classify(New List(Of Integer) From {
            1,
            2,
            5
        }, New List(Of Integer) From {
            0,
            1,
            2,
            3,
            1,
            2,
            5,
            6
        }))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Consecutive()
        Assert.Equal(SublistType.Sublist, Classify(New List(Of Integer) From {
            1,
            1,
            2
        }, New List(Of Integer) From {
            0,
            1,
            1,
            1,
            2,
            1,
            2
        }))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sublist_at_start()
        Assert.Equal(SublistType.Sublist, Classify(New List(Of Integer) From {
            0,
            1,
            2
        }, New List(Of Integer) From {
            0,
            1,
            2,
            3,
            4,
            5
        }))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sublist_in_middle()
        Assert.Equal(SublistType.Sublist, Classify(New List(Of Integer) From {
            2,
            3,
            4
        }, New List(Of Integer) From {
            0,
            1,
            2,
            3,
            4,
            5
        }))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sublist_at_end()
        Assert.Equal(SublistType.Sublist, Classify(New List(Of Integer) From {
            3,
            4,
            5
        }, New List(Of Integer) From {
            0,
            1,
            2,
            3,
            4,
            5
        }))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub At_start_of_superlist()
        Assert.Equal(SublistType.Superlist, Classify(New List(Of Integer) From {
            0,
            1,
            2,
            3,
            4,
            5
        }, New List(Of Integer) From {
            0,
            1,
            2
        }))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub In_middle_of_superlist()
        Assert.Equal(SublistType.Superlist, Classify(New List(Of Integer) From {
            0,
            1,
            2,
            3,
            4,
            5
        }, New List(Of Integer) From {
            2,
            3
        }))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub At_end_of_superlist()
        Assert.Equal(SublistType.Superlist, Classify(New List(Of Integer) From {
            0,
            1,
            2,
            3,
            4,
            5
        }, New List(Of Integer) From {
            3,
            4,
            5
        }))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub First_list_missing_element_from_second_list()
        Assert.Equal(SublistType.Unequal, Classify(New List(Of Integer) From {
            1,
            3
        }, New List(Of Integer) From {
            1,
            2,
            3
        }))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Second_list_missing_element_from_first_list()
        Assert.Equal(SublistType.Unequal, Classify(New List(Of Integer) From {
            1,
            2,
            3
        }, New List(Of Integer) From {
            1,
            3
        }))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub First_list_missing_additional_digits_from_second_list()
        Assert.Equal(SublistType.Unequal, Classify(New List(Of Integer) From {
            1,
            2
        }, New List(Of Integer) From {
            1,
            22
        }))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Order_matters_to_a_list()
        Assert.Equal(SublistType.Unequal, Classify(New List(Of Integer) From {
            1,
            2,
            3
        }, New List(Of Integer) From {
            3,
            2,
            1
        }))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Same_digits_but_different_numbers()
        Assert.Equal(SublistType.Unequal, Classify(New List(Of Integer) From {
            1,
            0,
            1
        }, New List(Of Integer) From {
            10,
            1
        }))
    End Sub
End Class
