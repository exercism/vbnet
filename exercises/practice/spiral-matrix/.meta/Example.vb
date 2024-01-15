Public Module SpiralMatrix
    Public Function GetMatrix(ByVal size As Integer) As Integer(,)
        Dim spiral = New Integer(size - 1, size - 1) {}
        Dim numbersToPlace = size * size

        Dim currentSpiralValue = 1
        Dim firstPivot = 0, secondPivot = size - 1

        While currentSpiralValue <= numbersToPlace
            For i = firstPivot To secondPivot
                spiral(firstPivot, i) = Math.Min(Threading.Interlocked.Increment(currentSpiralValue), currentSpiralValue - 1)
            Next

            For j = firstPivot + 1 To secondPivot
                spiral(j, secondPivot) = Math.Min(Threading.Interlocked.Increment(currentSpiralValue), currentSpiralValue - 1)
            Next

            For i = secondPivot - 1 To firstPivot Step -1
                spiral(secondPivot, i) = Math.Min(Threading.Interlocked.Increment(currentSpiralValue), currentSpiralValue - 1)
            Next

            For j = secondPivot - 1 To firstPivot + 1 Step -1
                spiral(j, firstPivot) = Math.Min(Threading.Interlocked.Increment(currentSpiralValue), currentSpiralValue - 1)
            Next

            firstPivot += 1
            secondPivot -= 1
        End While

        Return spiral
    End Function
End Module
