Public Class BinarySearchTreeTests
    <Fact>
    Public Sub Data_Is_Retained()
        Dim tree = TreeFrom({4})

        AssertTree(tree, Node(4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Smaller_Number_At_Left_Node()
        Dim tree = TreeFrom({4, 2})

        AssertTree(tree, Node(4, Node(2)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Same_Number_At_Left_Node()
        Dim tree = TreeFrom({4, 4})

        AssertTree(tree, Node(4, Node(4)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Greater_Number_At_Right_Node()
        Dim tree = TreeFrom({4, 5})

        AssertTree(tree, Node(4, Nothing, Node(5)))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_Create_Complex_Tree()
        Dim tree = TreeFrom({4, 2, 6, 1, 3, 5, 7})

        AssertTree(
            tree,
            Node(
                4,
                Node(2, Node(1), Node(3)),
                Node(6, Node(5), Node(7))))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_Sort_Single_Number()
        Dim tree = TreeFrom({2})
        Dim expected = {2}

        Assert.Equal(expected, tree.SortedData())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_Sort_If_Second_Number_Is_Smaller_Than_First()
        Dim tree = TreeFrom({2, 1})
        Dim expected = {1, 2}

        Assert.Equal(expected, tree.SortedData())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_Sort_If_Second_Number_Is_Same_As_First()
        Dim tree = TreeFrom({2, 2})
        Dim expected = {2, 2}

        Assert.Equal(expected, tree.SortedData())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_Sort_If_Second_Number_Is_Greater_Than_First()
        Dim tree = TreeFrom({2, 3})
        Dim expected = {2, 3}

        Assert.Equal(expected, tree.SortedData())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_Sort_Complex_Tree()
        Dim tree = TreeFrom({2, 1, 3, 6, 7, 5})
        Dim expected = {1, 2, 3, 5, 6, 7}

        Assert.Equal(expected, tree.SortedData())
    End Sub

    Private Shared Function TreeFrom(ByVal values As Integer()) As BinarySearchTree(Of Integer)
        Dim tree = New BinarySearchTree(Of Integer)(values(0))

        For Each value In values.Skip(1)
            tree.Insert(value)
        Next

        Return tree
    End Function

    Private Shared Sub AssertTree(ByVal actual As BinarySearchTree(Of Integer), ByVal expected As ExpectedNode)
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
        ByVal data As Integer,
        Optional ByVal left As ExpectedNode = Nothing,
        Optional ByVal right As ExpectedNode = Nothing) As ExpectedNode

        Return New ExpectedNode(data, left, right)
    End Function

    Private Class ExpectedNode
        Public Sub New(
            ByVal data As Integer,
            ByVal left As ExpectedNode,
            ByVal right As ExpectedNode)

            Me.Data = data
            Me.Left = left
            Me.Right = right
        End Sub

        Public ReadOnly Property Data As Integer
        Public ReadOnly Property Left As ExpectedNode
        Public ReadOnly Property Right As ExpectedNode
    End Class
End Class
