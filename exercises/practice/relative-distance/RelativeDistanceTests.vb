Public Class RelativeDistanceTests
    <Fact>
    Public Sub Direct_parent_child_relation()
        Dim familyTree = New Dictionary(Of String, String()) From {
            {"Vera", {"Tomoko"}},
            {"Tomoko", {"Aditi"}}
        }
        Assert.Equal(1, RelativeDistance.DegreesOfSeparation(familyTree, "Vera", "Tomoko"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sibling_relationship()
        Dim familyTree = New Dictionary(Of String, String()) From {
            {"Dalia", {"Olga", "Yassin"}}
        }
        Assert.Equal(1, RelativeDistance.DegreesOfSeparation(familyTree, "Olga", "Yassin"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_degrees_of_separation_grandchild()
        Dim familyTree = New Dictionary(Of String, String()) From {
            {"Khadija", {"Mateo"}},
            {"Mateo", {"Rami"}}
        }
        Assert.Equal(2, RelativeDistance.DegreesOfSeparation(familyTree, "Khadija", "Rami"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Unrelated_individuals()
        Dim familyTree = New Dictionary(Of String, String()) From {
            {"Priya", {"Rami"}},
            {"Kaito", {"Elif"}}
        }
        Assert.Equal(-1, RelativeDistance.DegreesOfSeparation(familyTree, "Priya", "Kaito"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Complex_graph_cousins()
        Dim familyTree = New Dictionary(Of String, String()) From {
            {"Aiko", {"Bao", "Carlos"}},
            {"Bao", {"Dalia", "Elias"}},
            {"Carlos", {"Fatima", "Gustavo"}},
            {"Dalia", {"Hassan", "Isla"}},
            {"Elias", {"Javier"}},
            {"Fatima", {"Khadija", "Liam"}},
            {"Gustavo", {"Mina"}},
            {"Hassan", {"Noah", "Olga"}},
            {"Isla", {"Pedro"}},
            {"Javier", {"Quynh", "Ravi"}},
            {"Khadija", {"Sofia"}},
            {"Liam", {"Tariq", "Uma"}},
            {"Mina", {"Viktor", "Wang"}},
            {"Noah", {"Xiomara"}},
            {"Olga", {"Yuki"}},
            {"Pedro", {"Zane", "Aditi"}},
            {"Quynh", {"Boris"}},
            {"Ravi", {"Celine"}},
            {"Sofia", {"Diego", "Elif"}},
            {"Tariq", {"Farah"}},
            {"Uma", {"Giorgio"}},
            {"Viktor", {"Hana", "Ian"}},
            {"Wang", {"Jing"}},
            {"Xiomara", {"Kaito"}},
            {"Yuki", {"Leila"}},
            {"Zane", {"Mateo"}},
            {"Aditi", {"Nia"}},
            {"Boris", {"Oscar"}},
            {"Celine", {"Priya"}},
            {"Diego", {"Qi"}},
            {"Elif", {"Rami"}},
            {"Farah", {"Sven"}},
            {"Giorgio", {"Tomoko"}},
            {"Hana", {"Umar"}},
            {"Ian", {"Vera"}},
            {"Jing", {"Wyatt"}},
            {"Kaito", {"Xia"}},
            {"Leila", {"Yassin"}},
            {"Mateo", {"Zara"}},
            {"Nia", {"Antonio"}},
            {"Oscar", {"Bianca"}},
            {"Priya", {"Cai"}},
            {"Qi", {"Dimitri"}},
            {"Rami", {"Ewa"}},
            {"Sven", {"Fabio"}},
            {"Tomoko", {"Gabriela"}},
            {"Umar", {"Helena"}},
            {"Vera", {"Igor"}},
            {"Wyatt", {"Jun"}},
            {"Xia", {"Kim"}},
            {"Yassin", {"Lucia"}},
            {"Zara", {"Mohammed"}}
        }
        Assert.Equal(9, RelativeDistance.DegreesOfSeparation(familyTree, "Dimitri", "Fabio"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Complex_graph_no_shortcut_far_removed_nephew()
        Dim familyTree = New Dictionary(Of String, String()) From {
            {"Aiko", {"Bao", "Carlos"}},
            {"Bao", {"Dalia", "Elias"}},
            {"Carlos", {"Fatima", "Gustavo"}},
            {"Dalia", {"Hassan", "Isla"}},
            {"Elias", {"Javier"}},
            {"Fatima", {"Khadija", "Liam"}},
            {"Gustavo", {"Mina"}},
            {"Hassan", {"Noah", "Olga"}},
            {"Isla", {"Pedro"}},
            {"Javier", {"Quynh", "Ravi"}},
            {"Khadija", {"Sofia"}},
            {"Liam", {"Tariq", "Uma"}},
            {"Mina", {"Viktor", "Wang"}},
            {"Noah", {"Xiomara"}},
            {"Olga", {"Yuki"}},
            {"Pedro", {"Zane", "Aditi"}},
            {"Quynh", {"Boris"}},
            {"Ravi", {"Celine"}},
            {"Sofia", {"Diego", "Elif"}},
            {"Tariq", {"Farah"}},
            {"Uma", {"Giorgio"}},
            {"Viktor", {"Hana", "Ian"}},
            {"Wang", {"Jing"}},
            {"Xiomara", {"Kaito"}},
            {"Yuki", {"Leila"}},
            {"Zane", {"Mateo"}},
            {"Aditi", {"Nia"}},
            {"Boris", {"Oscar"}},
            {"Celine", {"Priya"}},
            {"Diego", {"Qi"}},
            {"Elif", {"Rami"}},
            {"Farah", {"Sven"}},
            {"Giorgio", {"Tomoko"}},
            {"Hana", {"Umar"}},
            {"Ian", {"Vera"}},
            {"Jing", {"Wyatt"}},
            {"Kaito", {"Xia"}},
            {"Leila", {"Yassin"}},
            {"Mateo", {"Zara"}},
            {"Nia", {"Antonio"}},
            {"Oscar", {"Bianca"}},
            {"Priya", {"Cai"}},
            {"Qi", {"Dimitri"}},
            {"Rami", {"Ewa"}},
            {"Sven", {"Fabio"}},
            {"Tomoko", {"Gabriela"}},
            {"Umar", {"Helena"}},
            {"Vera", {"Igor"}},
            {"Wyatt", {"Jun"}},
            {"Xia", {"Kim"}},
            {"Yassin", {"Lucia"}},
            {"Zara", {"Mohammed"}}
        }
        Assert.Equal(14, RelativeDistance.DegreesOfSeparation(familyTree, "Lucia", "Jun"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Complex_graph_some_shortcuts_cross_down_and_cross_up_cousins_several_times_removed_with_unrelated_family_tree()
        Dim familyTree = New Dictionary(Of String, String()) From {
            {"Aiko", {"Bao", "Carlos"}},
            {"Bao", {"Dalia"}},
            {"Carlos", {"Fatima", "Gustavo"}},
            {"Dalia", {"Hassan", "Isla"}},
            {"Fatima", {"Khadija", "Liam"}},
            {"Gustavo", {"Mina"}},
            {"Hassan", {"Noah", "Olga"}},
            {"Isla", {"Pedro"}},
            {"Javier", {"Quynh", "Ravi"}},
            {"Khadija", {"Sofia"}},
            {"Liam", {"Tariq", "Uma"}},
            {"Mina", {"Viktor", "Wang"}},
            {"Noah", {"Xiomara"}},
            {"Olga", {"Yuki"}},
            {"Pedro", {"Zane", "Aditi"}},
            {"Quynh", {"Boris"}},
            {"Ravi", {"Celine"}},
            {"Sofia", {"Diego", "Elif"}},
            {"Tariq", {"Farah"}},
            {"Uma", {"Giorgio"}},
            {"Viktor", {"Hana", "Ian"}},
            {"Wang", {"Jing"}},
            {"Xiomara", {"Kaito"}},
            {"Yuki", {"Leila"}},
            {"Zane", {"Mateo"}},
            {"Aditi", {"Nia"}},
            {"Boris", {"Oscar"}},
            {"Celine", {"Priya"}},
            {"Diego", {"Qi"}},
            {"Elif", {"Rami"}},
            {"Farah", {"Sven"}},
            {"Giorgio", {"Tomoko"}},
            {"Hana", {"Umar"}},
            {"Ian", {"Vera"}},
            {"Jing", {"Wyatt"}},
            {"Kaito", {"Xia"}},
            {"Leila", {"Yassin"}},
            {"Mateo", {"Zara"}},
            {"Nia", {"Antonio"}},
            {"Oscar", {"Bianca"}},
            {"Priya", {"Cai"}},
            {"Qi", {"Dimitri"}},
            {"Rami", {"Ewa"}},
            {"Sven", {"Fabio"}},
            {"Tomoko", {"Gabriela"}},
            {"Umar", {"Helena"}},
            {"Vera", {"Igor"}},
            {"Wyatt", {"Jun"}},
            {"Xia", {"Kim"}},
            {"Yassin", {"Lucia"}},
            {"Zara", {"Mohammed"}}
        }
        Assert.Equal(12, RelativeDistance.DegreesOfSeparation(familyTree, "Wyatt", "Xia"))
    End Sub
End Class
