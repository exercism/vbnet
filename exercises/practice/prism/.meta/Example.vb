Public Structure LaserInfo
    Public Sub New(ByVal x As Double, ByVal y As Double, ByVal angle As Double)
        Me.X = x
        Me.Y = y
        Me.Angle = angle
    End Sub

    Public ReadOnly Property X As Double
    Public ReadOnly Property Y As Double
    Public ReadOnly Property Angle As Double
End Structure

Public Structure PrismInfo
    Public Sub New(ByVal id As Integer, ByVal x As Double, ByVal y As Double, ByVal angle As Double)
        Me.Id = id
        Me.X = x
        Me.Y = y
        Me.Angle = angle
    End Sub

    Public ReadOnly Property Id As Integer
    Public ReadOnly Property X As Double
    Public ReadOnly Property Y As Double
    Public ReadOnly Property Angle As Double
End Structure

Public Module Prism
    Private Const Epsilon = 0.000001

    Public Function FindSequence(ByVal laser As LaserInfo, ByVal prisms As PrismInfo()) As Integer()
        Dim x = laser.X
        Dim y = laser.Y
        Dim angle = laser.Angle
        Dim sequence As New List(Of Integer)

        While True
            Dim prism = FindNextPrism(x, y, angle, prisms)
            If Not prism.HasValue Then
                Return sequence.ToArray()
            End If

            Dim hit = prism.Value
            sequence.Add(hit.Id)
            x = hit.X
            y = hit.Y
            angle = (angle + hit.Angle) Mod 360.0
        End While

        Throw New InvalidOperationException("unreachable")
    End Function

    Private Function FindNextPrism(
        ByVal x As Double,
        ByVal y As Double,
        ByVal angle As Double,
        ByVal prisms As PrismInfo()) As PrismInfo?

        Dim radians = DegreesToRadians(angle)
        Dim directionX = Math.Cos(radians)
        Dim directionY = Math.Sin(radians)
        Dim nearest As PrismInfo? = Nothing
        Dim nearestDistance = Double.PositiveInfinity

        For Each prism In prisms
            Dim dx = prism.X - x
            Dim dy = prism.Y - y
            Dim distance = dx * directionX + dy * directionY

            If distance > Epsilon AndAlso
                IsOnRay(dx, dy, directionX, directionY, distance) AndAlso
                distance < nearestDistance Then

                nearest = prism
                nearestDistance = distance
            End If
        Next

        Return nearest
    End Function

    Private Function IsOnRay(
        ByVal dx As Double,
        ByVal dy As Double,
        ByVal directionX As Double,
        ByVal directionY As Double,
        ByVal distance As Double) As Boolean

        Dim offsetX = dx - distance * directionX
        Dim offsetY = dy - distance * directionY
        Dim offsetSquared = offsetX * offsetX + offsetY * offsetY
        Dim tolerance = Epsilon * Math.Max(1.0, distance * distance)

        Return offsetSquared < tolerance
    End Function

    Private Function DegreesToRadians(ByVal degrees As Double) As Double
        Return degrees * Math.PI / 180.0
    End Function
End Module
