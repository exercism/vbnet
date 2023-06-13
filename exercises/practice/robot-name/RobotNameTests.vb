Imports System.Linq
Imports System.Collections.Generic
Imports Xunit

Public Class RobotNameTests
    Private ReadOnly robot As Robot = New Robot()

    <Fact>
    Public Sub Robot_has_a_name()
        Assert.Matches("^[A-Z]{2}\d{3}$", robot.Name)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Name_is_the_same_each_time()
        Assert.Equal(robot.Name, robot.Name)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Different_robots_have_different_names()
        Dim robot2 = New Robot()
        Assert.NotEqual(robot2.Name, robot.Name)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_reset_the_name()
        Dim originalName = robot.Name
        robot.Reset()
        Assert.NotEqual(originalName, robot.Name)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub After_reset_the_name_is_valid()
        robot.Reset()
        Assert.Matches("^[A-Z]{2}\d{3}$", robot.Name)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Robot_names_are_unique()
        Const robotsCount = 10_000
        Dim robots = New List(Of Robot)(robotsCount) ' Needed to keep a reference to the robots as IDs of recycled robots may be re-issued
        Dim names = New HashSet(Of String)(robotsCount)
        For i = 0 To robotsCount - 1
            Dim robot = New Robot()
            robots.Add(robot)
            Assert.True(names.Add(robot.Name))
            Assert.Matches("^[A-Z]{2}\d{3}$", robot.Name)
        Next
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Robot_names_should_generate_edge_case_a()
        Const robotsCount = 10_000
        Dim robots = Enumerable.Range(0, robotsCount).[Select](Function(x) New Robot())
        Assert.Contains(robots, Function(robot) robot.Name.Contains("A"c))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Robot_names_should_generate_edge_case_z()
        Const robotsCount = 10_000
        Dim robots = Enumerable.Range(0, robotsCount).[Select](Function(x) New Robot())
        Assert.Contains(robots, Function(robot) robot.Name.Contains("Z"c))
    End Sub
End Class
