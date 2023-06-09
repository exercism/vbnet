Imports System
Imports System.Collections.Generic
Imports Xunit

Public Class ListOpsTests
    <Fact>
    Public Sub Append_entries_to_a_list_and_return_the_new_list_empty_lists()
        Dim list1 = New List(Of Integer)()
        Dim list2 = New List(Of Integer)()
        Assert.Empty(Append(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Append_entries_to_a_list_and_return_the_new_list_list_to_empty_list()
        Dim list1 = New List(Of Integer)()
        Dim list2 = New List(Of Integer) From {
            1,
            2,
            3,
            4
        }
        Dim expected = New List(Of Integer) From {
            1,
            2,
            3,
            4
        }
        Assert.Equal(expected, Append(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Append_entries_to_a_list_and_return_the_new_list_empty_list_to_list()
        Dim list1 = New List(Of Integer) From {
            1,
            2,
            3,
            4
        }
        Dim list2 = New List(Of Integer)()
        Dim expected = New List(Of Integer) From {
            1,
            2,
            3,
            4
        }
        Assert.Equal(expected, Append(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Append_entries_to_a_list_and_return_the_new_list_non_empty_lists()
        Dim list1 = New List(Of Integer) From {
            1,
            2
        }
        Dim list2 = New List(Of Integer) From {
            2,
            3,
            4,
            5
        }
        Dim expected = New List(Of Integer) From {
            1,
            2,
            2,
            3,
            4,
            5
        }
        Assert.Equal(expected, Append(list1, list2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Concatenate_a_list_of_lists_empty_list()
        Dim lists = New List(Of List(Of Integer))()
        Assert.Empty(Concat(lists))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Concatenate_a_list_of_lists_list_of_lists()
        Dim lists = New List(Of List(Of Integer)) From {
            New List(Of Integer) From {
                1,
                2
            },
            New List(Of Integer) From {
                3
            },
            New List(Of Integer)(),
            New List(Of Integer) From {
                4,
                5,
                6
            }
        }
        Dim expected = New List(Of Integer) From {
            1,
            2,
            3,
            4,
            5,
            6
        }
        Assert.Equal(expected, Concat(lists))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Concatenate_a_list_of_lists_list_of_nested_lists()
        Dim lists = New List(Of List(Of List(Of Integer))) From {
            New List(Of List(Of Integer)) From {
                New List(Of Integer) From {
                    1
                },
                New List(Of Integer) From {
                    2
                }
            },
            New List(Of List(Of Integer)) From {
                New List(Of Integer) From {
                    3
                }
            },
            New List(Of List(Of Integer)) From {
                New List(Of Integer)()
            },
            New List(Of List(Of Integer)) From {
                New List(Of Integer) From {
                    4,
                    5,
                    6
                }
            }
        }
        Dim expected = New List(Of List(Of Integer)) From {
            New List(Of Integer) From {
                1
            },
            New List(Of Integer) From {
                2
            },
            New List(Of Integer) From {
                3
            },
            New List(Of Integer)(),
            New List(Of Integer) From {
                4,
                5,
                6
            }
        }
        Assert.Equal(expected, Concat(lists))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Filter_list_returning_only_values_that_satisfy_the_filter_function_empty_list()
        Dim list = New List(Of Integer)()
        Dim [function] = New Func(Of Integer, Boolean)(Function(x) x Mod 2 = 1)
        Assert.Empty(Filter(list, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Filter_list_returning_only_values_that_satisfy_the_filter_function_non_empty_list()
        Dim list = New List(Of Integer) From {
            1,
            2,
            3,
            5
        }
        Dim [function] = New Func(Of Integer, Boolean)(Function(x) x Mod 2 = 1)
        Dim expected = New List(Of Integer) From {
            1,
            3,
            5
        }
        Assert.Equal(expected, Filter(list, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Returns_the_length_of_a_list_empty_list()
        Dim list = New List(Of Integer)()
        Assert.Equal(0, Length(list))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Returns_the_length_of_a_list_non_empty_list()
        Dim list = New List(Of Integer) From {
            1,
            2,
            3,
            4
        }
        Assert.Equal(4, Length(list))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Return_a_list_of_elements_whose_values_equal_the_list_value_transformed_by_the_mapping_function_empty_list()
        Dim list = New List(Of Integer)()
        Dim [function] = New Func(Of Integer, Integer)(Function(x) x + 1)
        Assert.Empty(Map(list, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Return_a_list_of_elements_whose_values_equal_the_list_value_transformed_by_the_mapping_function_non_empty_list()
        Dim list = New List(Of Integer) From {
            1,
            3,
            5,
            7
        }
        Dim [function] = New Func(Of Integer, Integer)(Function(x) x + 1)
        Dim expected = New List(Of Integer) From {
            2,
            4,
            6,
            8
        }
        Assert.Equal(expected, Map(list, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Folds_reduces_the_given_list_from_the_left_with_a_function_direction_dependent_function_applied_to_non_empty_list()
        Dim list = New List(Of Integer) From {
            2,
            5
        }
        Dim initial = 5
        Dim [function] = New Func(Of Integer, Integer, Integer)(Function(x, y) x / y)
        Assert.Equal(0, Foldl(list, initial, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Folds_reduces_the_given_list_from_the_left_with_a_function_empty_list()
        Dim list = New List(Of Integer)()
        Dim initial = 2
        Dim [function] = New Func(Of Integer, Integer, Integer)(Function(acc, el) el * acc)
        Assert.Equal(2, Foldl(list, initial, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Folds_reduces_the_given_list_from_the_left_with_a_function_direction_independent_function_applied_to_non_empty_list()
        Dim list = New List(Of Integer) From {
            1,
            2,
            3,
            4
        }
        Dim initial = 5
        Dim [function] = New Func(Of Integer, Integer, Integer)(Function(acc, el) el + acc)
        Assert.Equal(15, Foldl(list, initial, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Folds_reduces_the_given_list_from_the_right_with_a_function_direction_dependent_function_applied_to_non_empty_list()
        Dim list = New List(Of Integer) From {
            2,
            5
        }
        Dim initial = 5
        Dim [function] = New Func(Of Integer, Integer, Integer)(Function(x, y) x / y)
        Assert.Equal(2, Foldr(list, initial, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Folds_reduces_the_given_list_from_the_right_with_a_function_empty_list()
        Dim list = New List(Of Integer)()
        Dim initial = 2
        Dim [function] = New Func(Of Integer, Integer, Integer)(Function(acc, el) el * acc)
        Assert.Equal(2, Foldr(list, initial, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Folds_reduces_the_given_list_from_the_right_with_a_function_direction_independent_function_applied_to_non_empty_list()
        Dim list = New List(Of Integer) From {
            1,
            2,
            3,
            4
        }
        Dim initial = 5
        Dim [function] = New Func(Of Integer, Integer, Integer)(Function(acc, el) el + acc)
        Assert.Equal(15, Foldr(list, initial, [function]))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reverse_the_elements_of_the_list_empty_list()
        Dim list = New List(Of Integer)()
        Assert.Empty(Reverse(list))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reverse_the_elements_of_the_list_non_empty_list()
        Dim list = New List(Of Integer) From {
            1,
            3,
            5,
            7
        }
        Dim expected = New List(Of Integer) From {
            7,
            5,
            3,
            1
        }
        Assert.Equal(expected, Reverse(list))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reverse_the_elements_of_the_list_list_of_lists_is_not_flattened()
        Dim list = New List(Of List(Of Integer)) From {
            New List(Of Integer) From {
                1,
                2
            },
            New List(Of Integer) From {
                3
            },
            New List(Of Integer)(),
            New List(Of Integer) From {
                4,
                5,
                6
            }
        }
        Dim expected = New List(Of List(Of Integer)) From {
            New List(Of Integer) From {
                4,
                5,
                6
            },
            New List(Of Integer)(),
            New List(Of Integer) From {
                3
            },
            New List(Of Integer) From {
                1,
                2
            }
        }
        Assert.Equal(expected, Reverse(list))
    End Sub
End Class
