Imports System
Imports Xunit

Public Class GameOfLifeTests
    <Fact>
    Public Sub Empty_matrix()
        Dim matrix As New List(Of List(Of Integer))
        Dim game As New GameOfLife(matrix)
        game.Tick()
        Dim expected As New List(Of List(Of Integer))
        Assert.Equal(expected, game.Matrix())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Live_cells_with_zero_live_neighbors_die()
        Dim matrix As New List(Of List(Of Integer)) From {
            New List(Of Integer) From {0, 0, 0},
            New List(Of Integer) From {0, 1, 0},
            New List(Of Integer) From {0, 0, 0}
        }
        Dim game As New GameOfLife(matrix)
        game.Tick()
        Dim expected As New List(Of List(Of Integer)) From {
            New List(Of Integer) From {0, 0, 0},
            New List(Of Integer) From {0, 0, 0},
            New List(Of Integer) From {0, 0, 0}
        }
        Assert.Equal(expected, game.Matrix())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Live_cells_with_only_one_live_neighbor_die()
        Dim matrix As New List(Of List(Of Integer)) From {
            New List(Of Integer) From {0, 0, 0},
            New List(Of Integer) From {0, 1, 0},
            New List(Of Integer) From {0, 1, 0}
        }
        Dim game As New GameOfLife(matrix)
        game.Tick()
        Dim expected As New List(Of List(Of Integer)) From {
            New List(Of Integer) From {0, 0, 0},
            New List(Of Integer) From {0, 0, 0},
            New List(Of Integer) From {0, 0, 0}
        }
        Assert.Equal(expected, game.Matrix())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Live_cells_with_two_live_neighbors_stay_alive()
        Dim matrix As New List(Of List(Of Integer)) From {
            New List(Of Integer) From {1, 0, 1},
            New List(Of Integer) From {1, 0, 1},
            New List(Of Integer) From {1, 0, 1}
        }
        Dim game As New GameOfLife(matrix)
        game.Tick()
        Dim expected As New List(Of List(Of Integer)) From {
            New List(Of Integer) From {0, 0, 0},
            New List(Of Integer) From {1, 0, 1},
            New List(Of Integer) From {0, 0, 0}
        }
        Assert.Equal(expected, game.Matrix())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Live_cells_with_three_live_neighbors_stay_alive()
        Dim matrix As New List(Of List(Of Integer)) From {
            New List(Of Integer) From {0, 1, 0},
            New List(Of Integer) From {1, 0, 0},
            New List(Of Integer) From {1, 1, 0}
        }
        Dim game As New GameOfLife(matrix)
        game.Tick()
        Dim expected As New List(Of List(Of Integer)) From {
            New List(Of Integer) From {0, 0, 0},
            New List(Of Integer) From {1, 0, 0},
            New List(Of Integer) From {1, 1, 0}
        }
        Assert.Equal(expected, game.Matrix())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Dead_cells_with_three_live_neighbors_become_alive()
        Dim matrix As New List(Of List(Of Integer)) From {
            New List(Of Integer) From {1, 1, 0},
            New List(Of Integer) From {0, 0, 0},
            New List(Of Integer) From {1, 0, 0}
        }
        Dim game As New GameOfLife(matrix)
        game.Tick()
        Dim expected As New List(Of List(Of Integer)) From {
            New List(Of Integer) From {0, 0, 0},
            New List(Of Integer) From {1, 1, 0},
            New List(Of Integer) From {0, 0, 0}
        }
        Assert.Equal(expected, game.Matrix())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Live_cells_with_four_or_more_neighbors_die()
        Dim matrix As New List(Of List(Of Integer)) From {
            New List(Of Integer) From {1, 1, 1},
            New List(Of Integer) From {1, 1, 1},
            New List(Of Integer) From {1, 1, 1}
        }
        Dim game As New GameOfLife(matrix)
        game.Tick()
        Dim expected As New List(Of List(Of Integer)) From {
            New List(Of Integer) From {1, 0, 1},
            New List(Of Integer) From {0, 0, 0},
            New List(Of Integer) From {1, 0, 1}
        }
        Assert.Equal(expected, game.Matrix())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Bigger_matrix()
        Dim matrix As New List(Of List(Of Integer)) From {
            New List(Of Integer) From {1, 1, 0, 1, 1, 0, 0, 0},
            New List(Of Integer) From {1, 0, 1, 1, 0, 0, 0, 0},
            New List(Of Integer) From {1, 1, 1, 0, 0, 1, 1, 1},
            New List(Of Integer) From {0, 0, 0, 0, 0, 1, 1, 0},
            New List(Of Integer) From {1, 0, 0, 0, 1, 1, 0, 0},
            New List(Of Integer) From {1, 1, 0, 0, 0, 1, 1, 1},
            New List(Of Integer) From {0, 0, 1, 0, 1, 0, 0, 1},
            New List(Of Integer) From {1, 0, 0, 0, 0, 0, 1, 1}
        }
        Dim game As New GameOfLife(matrix)
        game.Tick()
        Dim expected As New List(Of List(Of Integer)) From {
            New List(Of Integer) From {1, 1, 0, 1, 1, 0, 0, 0},
            New List(Of Integer) From {0, 0, 0, 0, 0, 1, 1, 0},
            New List(Of Integer) From {1, 0, 1, 1, 1, 1, 0, 1},
            New List(Of Integer) From {1, 0, 0, 0, 0, 0, 0, 1},
            New List(Of Integer) From {1, 1, 0, 0, 1, 0, 0, 1},
            New List(Of Integer) From {1, 1, 0, 1, 0, 0, 0, 1},
            New List(Of Integer) From {1, 0, 0, 0, 0, 0, 0, 0},
            New List(Of Integer) From {0, 0, 0, 0, 0, 0, 1, 1}
        }
        Assert.Equal(expected, game.Matrix())
    End Sub
End Class
