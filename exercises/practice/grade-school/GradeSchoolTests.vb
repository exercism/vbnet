Public Class GradeSchoolTests
    <Fact>
    Public Sub Roster_is_empty_when_no_student_is_added()
        Dim sut = New GradeSchool()
        Assert.Empty(sut.Roster())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_a_student()
        Dim sut = New GradeSchool()
        Assert.True(sut.Add("Aimee", 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Student_is_added_to_the_roster()
        Dim sut = New GradeSchool()
        sut.Add("Aimee", 2)
        Dim expected = {"Aimee"}
        Assert.Equal(expected, sut.Roster())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Adding_multiple_students_in_the_same_grade_in_the_roster()
        Dim sut = New GradeSchool()
        Assert.True(sut.Add("Blair", 2))
        Assert.True(sut.Add("James", 2))
        Assert.True(sut.Add("Paul", 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_students_in_the_same_grade_are_added_to_the_roster()
        Dim sut = New GradeSchool()
        sut.Add("Blair", 2)
        sut.Add("James", 2)
        sut.Add("Paul", 2)
        Dim expected = {"Blair", "James", "Paul"}
        Assert.Equal(expected, sut.Roster())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_add_student_to_same_grade_in_the_roster_more_than_once()
        Dim sut = New GradeSchool()
        Assert.True(sut.Add("Blair", 2))
        Assert.True(sut.Add("James", 2))
        Assert.False(sut.Add("James", 2))
        Assert.True(sut.Add("Paul", 2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Student_not_added_to_same_grade_in_the_roster_more_than_once()
        Dim sut = New GradeSchool()
        sut.Add("Blair", 2)
        sut.Add("James", 2)
        sut.Add("James", 2)
        sut.Add("Paul", 2)
        Dim expected = {"Blair", "James", "Paul"}
        Assert.Equal(expected, sut.Roster())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Adding_students_in_multiple_grades()
        Dim sut = New GradeSchool()
        Assert.True(sut.Add("Chelsea", 3))
        Assert.True(sut.Add("Logan", 7))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Students_in_multiple_grades_are_added_to_the_roster()
        Dim sut = New GradeSchool()
        sut.Add("Chelsea", 3)
        sut.Add("Logan", 7)
        Dim expected = {"Chelsea", "Logan"}
        Assert.Equal(expected, sut.Roster())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_add_same_student_to_multiple_grades_in_the_roster()
        Dim sut = New GradeSchool()
        Assert.True(sut.Add("Blair", 2))
        Assert.True(sut.Add("James", 2))
        Assert.False(sut.Add("James", 3))
        Assert.True(sut.Add("Paul", 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Student_not_added_to_multiple_grades_in_the_roster()
        Dim sut = New GradeSchool()
        sut.Add("Blair", 2)
        sut.Add("James", 2)
        sut.Add("James", 3)
        sut.Add("Paul", 3)
        Dim expected = {"Blair", "James", "Paul"}
        Assert.Equal(expected, sut.Roster())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Students_are_sorted_by_grades_in_the_roster()
        Dim sut = New GradeSchool()
        sut.Add("Jim", 3)
        sut.Add("Peter", 2)
        sut.Add("Anna", 1)
        Dim expected = {"Anna", "Peter", "Jim"}
        Assert.Equal(expected, sut.Roster())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Students_are_sorted_by_name_in_the_roster()
        Dim sut = New GradeSchool()
        sut.Add("Peter", 2)
        sut.Add("Zoe", 2)
        sut.Add("Alex", 2)
        Dim expected = {"Alex", "Peter", "Zoe"}
        Assert.Equal(expected, sut.Roster())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Students_are_sorted_by_grades_and_then_by_name_in_the_roster()
        Dim sut = New GradeSchool()
        sut.Add("Peter", 2)
        sut.Add("Anna", 1)
        sut.Add("Barb", 1)
        sut.Add("Zoe", 2)
        sut.Add("Alex", 2)
        sut.Add("Jim", 3)
        sut.Add("Charlie", 1)
        Dim expected = {"Anna", "Barb", "Charlie", "Alex", "Peter", "Zoe", "Jim"}
        Assert.Equal(expected, sut.Roster())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Grade_is_empty_if_no_students_in_the_roster()
        Dim sut = New GradeSchool()
        Assert.Empty(sut.Grade(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Grade_is_empty_if_no_students_in_that_grade()
        Dim sut = New GradeSchool()
        sut.Add("Peter", 2)
        sut.Add("Zoe", 2)
        sut.Add("Alex", 2)
        sut.Add("Jim", 3)
        Assert.Empty(sut.Grade(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Student_not_added_to_same_grade_more_than_once()
        Dim sut = New GradeSchool()
        sut.Add("Blair", 2)
        sut.Add("James", 2)
        sut.Add("James", 2)
        sut.Add("Paul", 2)
        Dim expected = {"Blair", "James", "Paul"}
        Assert.Equal(expected, sut.Grade(2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Student_not_added_to_multiple_grades()
        Dim sut = New GradeSchool()
        sut.Add("Blair", 2)
        sut.Add("James", 2)
        sut.Add("James", 3)
        sut.Add("Paul", 3)
        Dim expected = {"Blair", "James"}
        Assert.Equal(expected, sut.Grade(2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Student_not_added_to_other_grade_for_multiple_grades()
        Dim sut = New GradeSchool()
        sut.Add("Blair", 2)
        sut.Add("James", 2)
        sut.Add("James", 3)
        sut.Add("Paul", 3)
        Dim expected = {"Paul"}
        Assert.Equal(expected, sut.Grade(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Students_are_sorted_by_name_in_a_grade()
        Dim sut = New GradeSchool()
        sut.Add("Franklin", 5)
        sut.Add("Bradley", 5)
        sut.Add("Jeff", 1)
        Dim expected = {"Bradley", "Franklin"}
        Assert.Equal(expected, sut.Grade(5))
    End Sub
End Class
