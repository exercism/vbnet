Public Class BinarySearchTreeTests
    <Fact>
    Public Sub Data_is_retained()
        Dim tree = TreeFrom({4})
        Dim expected = Node(4)
        AssertTree(tree, expected)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Insert_data_at_proper_node_smaller_number_at_left_node()
        Dim tree = TreeFrom({4, 2})
        Dim expected = Node(
            4,
            Node(2),
            Nothing
        )
        AssertTree(tree, expected)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Insert_data_at_proper_node_same_number_at_left_node()
        Dim tree = TreeFrom({4, 4})
        Dim expected = Node(
            4,
            Node(4),
            Nothing
        )
        AssertTree(tree, expected)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Insert_data_at_proper_node_greater_number_at_right_node()
        Dim tree = TreeFrom({4, 5})
        Dim expected = Node(
            4,
            Nothing,
            Node(5)
        )
        AssertTree(tree, expected)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_create_complex_tree()
        Dim tree = TreeFrom({4, 2, 6, 1, 3, 5, 7})
        Dim expected = Node(
            4,
            Node(
                2,
                Node(1),
                Node(3)
            ),
            Node(
                6,
                Node(5),
                Node(7)
            )
        )
        AssertTree(tree, expected)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_sort_data_can_sort_single_number()
        Dim tree = TreeFrom({2})
        Assert.Equal({2}, tree.SortedData())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_sort_data_can_sort_if_second_number_is_smaller_than_first()
        Dim tree = TreeFrom({2, 1})
        Assert.Equal({1, 2}, tree.SortedData())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_sort_data_can_sort_if_second_number_is_same_as_first()
        Dim tree = TreeFrom({2, 2})
        Assert.Equal({2, 2}, tree.SortedData())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_sort_data_can_sort_if_second_number_is_greater_than_first()
        Dim tree = TreeFrom({2, 3})
        Assert.Equal({2, 3}, tree.SortedData())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_sort_data_can_sort_complex_tree()
        Dim tree = TreeFrom({2, 1, 3, 6, 7, 5})
        Assert.Equal({1, 2, 3, 5, 6, 7}, tree.SortedData())
    End Sub


    Private Shared Function TreeFrom(values As Integer()) As BinarySearchTree(Of Integer)
        Dim tree = New BinarySearchTree(Of Integer)(values(0))

        For Each value In values.Skip(1)
            tree.Insert(value)
        Next

        Return tree
    End Function

    Private Shared Sub AssertTree(actual As BinarySearchTree(Of Integer), expected As ExpectedNode)
        If expected Is Nothing Then
            Assert.Null(actual)
            Return
        End If

        Assert.NotNull(actual)
        Assert.Equal(expected.Data, actual.Data)
        AssertTree(actual.Left, expected.Left)
        AssertTree(actual.Right, expected.Right)
    End Sub

    Private Shared Function Node(
        data As Integer,
        Optional left As ExpectedNode = Nothing,
        Optional right As ExpectedNode = Nothing) As ExpectedNode

        Return New ExpectedNode(data, left, right)
    End Function

    Private Class ExpectedNode
        Public Sub New(data As Integer, left As ExpectedNode, right As ExpectedNode)
            Me.Data = data
            Me.Left = left
            Me.Right = right
        End Sub

        Public ReadOnly Property Data As Integer
        Public ReadOnly Property Left As ExpectedNode
        Public ReadOnly Property Right As ExpectedNode
    End Class
End Class
