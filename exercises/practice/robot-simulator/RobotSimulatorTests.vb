Imports Xunit

Public Class RobotSimulatorTests
    <Fact>
    Public Sub Create_robot_at_origin_facing_north()
        Dim sut = New RobotSimulator(DirectionType.North, 0, 0)
        Assert.Equal(DirectionType.North, sut.Direction)
        Assert.Equal(0, sut.X)
        Assert.Equal(0, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Create_robot_at_negative_position_facing_south()
        Dim sut = New RobotSimulator(DirectionType.South, -1, -1)
        Assert.Equal(DirectionType.South, sut.Direction)
        Assert.Equal(-1, sut.X)
        Assert.Equal(-1, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotating_clockwise_changes_north_to_east()
        Dim sut = New RobotSimulator(DirectionType.North, 0, 0)
        sut.Move("R")
        Assert.Equal(DirectionType.East, sut.Direction)
        Assert.Equal(0, sut.X)
        Assert.Equal(0, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotating_clockwise_changes_east_to_south()
        Dim sut = New RobotSimulator(DirectionType.East, 0, 0)
        sut.Move("R")
        Assert.Equal(DirectionType.South, sut.Direction)
        Assert.Equal(0, sut.X)
        Assert.Equal(0, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotating_clockwise_changes_south_to_west()
        Dim sut = New RobotSimulator(DirectionType.South, 0, 0)
        sut.Move("R")
        Assert.Equal(DirectionType.West, sut.Direction)
        Assert.Equal(0, sut.X)
        Assert.Equal(0, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotating_clockwise_changes_west_to_north()
        Dim sut = New RobotSimulator(DirectionType.West, 0, 0)
        sut.Move("R")
        Assert.Equal(DirectionType.North, sut.Direction)
        Assert.Equal(0, sut.X)
        Assert.Equal(0, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotating_counter_clockwise_changes_north_to_west()
        Dim sut = New RobotSimulator(DirectionType.North, 0, 0)
        sut.Move("L")
        Assert.Equal(DirectionType.West, sut.Direction)
        Assert.Equal(0, sut.X)
        Assert.Equal(0, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotating_counter_clockwise_changes_west_to_south()
        Dim sut = New RobotSimulator(DirectionType.West, 0, 0)
        sut.Move("L")
        Assert.Equal(DirectionType.South, sut.Direction)
        Assert.Equal(0, sut.X)
        Assert.Equal(0, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotating_counter_clockwise_changes_south_to_east()
        Dim sut = New RobotSimulator(DirectionType.South, 0, 0)
        sut.Move("L")
        Assert.Equal(DirectionType.East, sut.Direction)
        Assert.Equal(0, sut.X)
        Assert.Equal(0, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Rotating_counter_clockwise_changes_east_to_north()
        Dim sut = New RobotSimulator(DirectionType.East, 0, 0)
        sut.Move("L")
        Assert.Equal(DirectionType.North, sut.Direction)
        Assert.Equal(0, sut.X)
        Assert.Equal(0, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Moving_forward_one_facing_north_increments_y()
        Dim sut = New RobotSimulator(DirectionType.North, 0, 0)
        sut.Move("A")
        Assert.Equal(DirectionType.North, sut.Direction)
        Assert.Equal(0, sut.X)
        Assert.Equal(1, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Moving_forward_one_facing_south_decrements_y()
        Dim sut = New RobotSimulator(DirectionType.South, 0, 0)
        sut.Move("A")
        Assert.Equal(DirectionType.South, sut.Direction)
        Assert.Equal(0, sut.X)
        Assert.Equal(-1, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Moving_forward_one_facing_east_increments_x()
        Dim sut = New RobotSimulator(DirectionType.East, 0, 0)
        sut.Move("A")
        Assert.Equal(DirectionType.East, sut.Direction)
        Assert.Equal(1, sut.X)
        Assert.Equal(0, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Moving_forward_one_facing_west_decrements_x()
        Dim sut = New RobotSimulator(DirectionType.West, 0, 0)
        sut.Move("A")
        Assert.Equal(DirectionType.West, sut.Direction)
        Assert.Equal(-1, sut.X)
        Assert.Equal(0, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Follow_series_of_instructions_moving_east_and_north_from_readme()
        Dim sut = New RobotSimulator(DirectionType.North, 7, 3)
        sut.Move("RAALAL")
        Assert.Equal(DirectionType.West, sut.Direction)
        Assert.Equal(9, sut.X)
        Assert.Equal(4, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Follow_series_of_instructions_moving_west_and_north()
        Dim sut = New RobotSimulator(DirectionType.North, 0, 0)
        sut.Move("LAAARALA")
        Assert.Equal(DirectionType.West, sut.Direction)
        Assert.Equal(-4, sut.X)
        Assert.Equal(1, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Follow_series_of_instructions_moving_west_and_south()
        Dim sut = New RobotSimulator(DirectionType.East, 2, -7)
        sut.Move("RRAAAAALA")
        Assert.Equal(DirectionType.South, sut.Direction)
        Assert.Equal(-3, sut.X)
        Assert.Equal(-8, sut.Y)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Follow_series_of_instructions_moving_east_and_north()
        Dim sut = New RobotSimulator(DirectionType.South, 8, 4)
        sut.Move("LAAARRRALLLL")
        Assert.Equal(DirectionType.North, sut.Direction)
        Assert.Equal(11, sut.X)
        Assert.Equal(5, sut.Y)
    End Sub
End Class
