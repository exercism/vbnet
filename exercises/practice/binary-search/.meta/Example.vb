Module BinarySearch
    Function Find(ByVal input As Integer(), ByVal target As Integer) As Integer
        If input.Length = 0 Then Return -1
        Return FindHelper(input, target, 0, input.Length - 1)
    End Function

    Private Function FindHelper(ByVal input As Integer(), ByVal target As Integer, ByVal minIndex As Integer, ByVal maxIndex As Integer) As Integer
        Dim middleIndex = minIndex + ((maxIndex - minIndex) \ 2)
        Dim look = input(middleIndex)
        If look = target Then Return middleIndex
        If minIndex >= maxIndex Then Return -1
        If target < look Then Return FindHelper(input, target, minIndex, middleIndex - 1)
        Return FindHelper(input, target, middleIndex + 1, maxIndex)
    End Function
End Module
