Module BinarySearch
    Function Find(ByVal input As Integer(), ByVal target As Integer) As Integer
        If input.Length = 0 Then Return -1
        Return FindHelper(input, target, 0, input.Length - 1)
    End Function

    Private Function FindHelper(ByVal input As Integer(), ByVal target As Integer, ByVal minIndex As Integer, ByVal maxIndex As Integer) As Integer
        Dim middleIndex = (minIndex + maxIndex) / 2
        If input(middleIndex) = target Then Return middleIndex
        If middleIndex <= 0 OrElse middleIndex >= input.Length - 1 OrElse minIndex = maxIndex Then Return -1
        If input(middleIndex) > target Then Return FindHelper(input, target, minIndex, middleIndex - 1)
        Return FindHelper(input, target, middleIndex + 1, maxIndex)
    End Function
End Module
