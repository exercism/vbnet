{{ func node(value, depth)
    if value == null
        ret "Nothing"
    end

    if value.left == null && value.right == null
        ret "Node(" + value.data + ")"
    end

    ret (vb_multiline_call "Node" [value.data, (node value.left (depth + 1)), (node value.right (depth + 1))] (depth + 2))
end }}

Public Class {{ testClass }}
    {{- for test in tests }}
    {{ test.factAttribute }}
    Public Sub {{ test.testMethod }}()
        Dim tree = TreeFrom({{ test.input.treeData | vb_integer_array_literal }})
        {{- if test.property == "data" }}
        Dim expected = {{ test.expected | node 0 }}
        AssertTree(tree, expected)
        {{- else }}
        Assert.Equal({{ test.expected | vb_integer_array_literal }}, tree.{{ test.testedMethod }}())
        {{- end }}
    End Sub
    {{ end }}

    Private Shared Function TreeFrom(values As Integer()) As {{ testedClass }}(Of Integer)
        Dim tree = New {{ testedClass }}(Of Integer)(values(0))

        For Each value In values.Skip(1)
            tree.Insert(value)
        Next

        Return tree
    End Function

    Private Shared Sub AssertTree(actual As {{ testedClass }}(Of Integer), expected As ExpectedNode)
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
