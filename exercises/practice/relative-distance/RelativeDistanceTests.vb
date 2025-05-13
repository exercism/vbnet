Imports Xunit
Imports System.Collections.Generic

Public Class RelativeDistanceTest
    <Fact>
    Public Sub Direct_parent_child_relation()
        Dim familyTree As New Dictionary(Of String, String()) From {
            {"Vera", {"Tomoko"}},
            {"Tomoko", {"Aditi"}}
        }
        Assert.Equal(1,  DegreesOfSeparation(familyTree, "Vera", "Tomoko"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Sibling_relationship()
        Dim familyTree As New Dictionary(Of String, String()) From {
            {"Dalia", {"Olga", "Yassin"}}
        }
        Assert.Equal(1, DegreesOfSeparation(familyTree, "Olga", "Yassin"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Two_degrees_of_separation_grandchild()
        Dim familyTree As New Dictionary(Of String, String()) From {
            {"Khadija", {"Mateo"}},
            {"Mateo", {"Rami"}}
        }
        Assert.Equal(2, DegreesOfSeparation(familyTree, "Khadija", "Rami"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Unrelated_individuals()
        Dim familyTree As New Dictionary(Of String, String()) From {
            {"Priya", {"Rami"}},
            {"Kaito", {"Elif"}}
        }
        Assert.Equal(-1, DegreesOfSeparation(familyTree, "Priya", "Kaito"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Complex_graph_cousins()
        Dim familyTree As New Dictionary(Of String, String()) From {
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
        Assert.Equal(9, DegreesOfSeparation(familyTree, "Dimitri", "Fabio"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Complex_graph_far_removed_nephew()
        Dim familyTree As New Dictionary(Of String, String()) From {
            {"Mina", {"Viktor", "Wang"}},
            {"Olga", {"Yuki"}},
            {"Javier", {"Quynh", "Ravi"}},
            {"Tariq", {"Farah"}},
            {"Viktor", {"Hana", "Ian"}},
            {"Diego", {"Qi"}},
            {"Carlos", {"Fatima", "Gustavo"}},
            {"Hana", {"Umar"}},
            {"Jing", {"Wyatt"}},
            {"Sven", {"Fabio"}},
            {"Zane", {"Mateo"}},
            {"Isla", {"Pedro"}},
            {"Quynh", {"Boris"}},
            {"Kaito", {"Xia"}},
            {"Liam", {"Tariq", "Uma"}},
            {"Priya", {"Cai"}},
            {"Qi", {"Dimitri"}},
            {"Wang", {"Jing"}},
            {"Yuki", {"Leila"}},
            {"Xia", {"Kim"}},
            {"Pedro", {"Zane", "Aditi"}},
            {"Uma", {"Giorgio"}},
            {"Giorgio", {"Tomoko"}},
            {"Gustavo", {"Mina"}},
            {"Sofia", {"Diego", "Elif"}},
            {"Leila", {"Yassin"}},
            {"Umar", {"Helena"}},
            {"Aiko", {"Bao", "Carlos"}},
            {"Fatima", {"Khadija", "Liam"}},
            {"Oscar", {"Bianca"}},
            {"Wyatt", {"Jun"}},
            {"Ian", {"Vera"}},
            {"Mateo", {"Zara"}},
            {"Noah", {"Xiomara"}},
            {"Celine", {"Priya"}},
            {"Xiomara", {"Kaito"}},
            {"Bao", {"Dalia", "Elias"}},
            {"Elif", {"Rami"}},
            {"Farah", {"Sven"}},
            {"Aditi", {"Nia"}},
            {"Vera", {"Igor"}},
            {"Boris", {"Oscar"}},
            {"Khadija", {"Sofia"}},
            {"Zara", {"Mohammed"}},
            {"Dalia", {"Hassan", "Isla"}},
            {"Ravi", {"Celine"}},
            {"Yassin", {"Lucia"}},
            {"Elias", {"Javier"}},
            {"Nia", {"Antonio"}},
            {"Rami", {"Ewa"}},
            {"Hassan", {"Noah", "Olga"}},
            {"Tomoko", {"Gabriela"}}
        }
        Assert.Equal(14, DegreesOfSeparation(familyTree, "Lucia", "Jun"))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Complex_graph_cousins_several_times_removed()
        Dim familyTree As New Dictionary(Of String, String()) From {
            {"Mina", {"Viktor", "Wang"}},
            {"Olga", {"Yuki"}},
            {"Javier", {"Quynh", "Ravi"}},
            {"Tariq", {"Farah"}},
            {"Viktor", {"Hana", "Ian"}},
            {"Diego", {"Qi"}},
            {"Carlos", {"Fatima", "Gustavo"}},
            {"Hana", {"Umar"}},
            {"Jing", {"Wyatt"}},
            {"Sven", {"Fabio"}},
            {"Zane", {"Mateo"}},
            {"Isla", {"Pedro"}},
            {"Quynh", {"Boris"}},
            {"Kaito", {"Xia"}},
            {"Liam", {"Tariq", "Uma"}},
            {"Priya", {"Cai"}},
            {"Qi", {"Dimitri"}},
            {"Wang", {"Jing"}},
            {"Yuki", {"Leila"}},
            {"Xia", {"Kim"}},
            {"Pedro", {"Zane", "Aditi"}},
            {"Uma", {"Giorgio"}},
            {"Giorgio", {"Tomoko"}},
            {"Gustavo", {"Mina"}},
            {"Sofia", {"Diego", "Elif"}},
            {"Leila", {"Yassin"}},
            {"Umar", {"Helena"}},
            {"Aiko", {"Bao", "Carlos"}},
            {"Fatima", {"Khadija", "Liam"}},
            {"Oscar", {"Bianca"}},
            {"Wyatt", {"Jun"}},
            {"Ian", {"Vera"}},
            {"Mateo", {"Zara"}},
            {"Noah", {"Xiomara"}},
            {"Celine", {"Priya"}},
            {"Xiomara", {"Kaito"}},
            {"Bao", {"Dalia"}},
            {"Elif", {"Rami"}},
            {"Farah", {"Sven"}},
            {"Aditi", {"Nia"}},
            {"Vera", {"Igor"}},
            {"Boris", {"Oscar"}},
            {"Khadija", {"Sofia"}},
            {"Zara", {"Mohammed"}},
            {"Dalia", {"Hassan", "Isla"}},
            {"Ravi", {"Celine"}},
            {"Yassin", {"Lucia"}},
            {"Nia", {"Antonio"}},
            {"Rami", {"Ewa"}},
            {"Hassan", {"Noah", "Olga"}},
            {"Tomoko", {"Gabriela"}}
        }
        Assert.Equal(12, DegreesOfSeparation(familyTree, "Wyatt", "Xia"))
    End Sub
End Class
