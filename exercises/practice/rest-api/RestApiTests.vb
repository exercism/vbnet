Imports Xunit

Public Class RestApiTests
    <Fact>
    Public Sub No_users()
        Dim url = "/users"
        Dim database = "[]"
        Dim sut = New RestApi(database)
        Dim actual = sut.Get(url)
        Dim expected = "[]"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Add_user()
        Dim url = "/add"
        Dim payload = "{""user"":""Adam""}"
        Dim database = "[]"
        Dim sut = New RestApi(database)
        Dim actual = sut.Post(url, payload)
        Dim expected = "{""name"":""Adam"",""owes"":{},""owed_by"":{},""balance"":0}"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Get_single_user()
        Dim url = "/users"
        Dim payload = "{""users"":[""Bob""]}"
        Dim database = "[{""name"":""Adam"",""owes"":{},""owed_by"":{},""balance"":0},{""name"":""Bob"",""owes"":{},""owed_by"":{},""balance"":0}]"
        Dim sut = New RestApi(database)
        Dim actual = sut.Get(url, payload)
        Dim expected = "[{""name"":""Bob"",""owes"":{},""owed_by"":{},""balance"":0}]"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Both_users_have_0_balance()
        Dim url = "/iou"
        Dim payload = "{""lender"":""Adam"",""borrower"":""Bob"",""amount"":3}"
        Dim database = "[{""name"":""Adam"",""owes"":{},""owed_by"":{},""balance"":0},{""name"":""Bob"",""owes"":{},""owed_by"":{},""balance"":0}]"
        Dim sut = New RestApi(database)
        Dim actual = sut.Post(url, payload)
        Dim expected = "[{""name"":""Adam"",""owes"":{},""owed_by"":{""Bob"":3},""balance"":3},{""name"":""Bob"",""owes"":{""Adam"":3},""owed_by"":{},""balance"":-3}]"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Borrower_has_negative_balance()
        Dim url = "/iou"
        Dim payload = "{""lender"":""Adam"",""borrower"":""Bob"",""amount"":3}"
        Dim database = "[{""name"":""Adam"",""owes"":{},""owed_by"":{},""balance"":0},{""name"":""Bob"",""owes"":{""Chuck"":3},""owed_by"":{},""balance"":-3},{""name"":""Chuck"",""owes"":{},""owed_by"":{""Bob"":3},""balance"":3}]"
        Dim sut = New RestApi(database)
        Dim actual = sut.Post(url, payload)
        Dim expected = "[{""name"":""Adam"",""owes"":{},""owed_by"":{""Bob"":3},""balance"":3},{""name"":""Bob"",""owes"":{""Adam"":3,""Chuck"":3},""owed_by"":{},""balance"":-6}]"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Lender_has_negative_balance()
        Dim url = "/iou"
        Dim payload = "{""lender"":""Bob"",""borrower"":""Adam"",""amount"":3}"
        Dim database = "[{""name"":""Adam"",""owes"":{},""owed_by"":{},""balance"":0},{""name"":""Bob"",""owes"":{""Chuck"":3},""owed_by"":{},""balance"":-3},{""name"":""Chuck"",""owes"":{},""owed_by"":{""Bob"":3},""balance"":3}]"
        Dim sut = New RestApi(database)
        Dim actual = sut.Post(url, payload)
        Dim expected = "[{""name"":""Adam"",""owes"":{""Bob"":3},""owed_by"":{},""balance"":-3},{""name"":""Bob"",""owes"":{""Chuck"":3},""owed_by"":{""Adam"":3},""balance"":0}]"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Lender_owes_borrower()
        Dim url = "/iou"
        Dim payload = "{""lender"":""Adam"",""borrower"":""Bob"",""amount"":2}"
        Dim database = "[{""name"":""Adam"",""owes"":{""Bob"":3},""owed_by"":{},""balance"":-3},{""name"":""Bob"",""owes"":{},""owed_by"":{""Adam"":3},""balance"":3}]"
        Dim sut = New RestApi(database)
        Dim actual = sut.Post(url, payload)
        Dim expected = "[{""name"":""Adam"",""owes"":{""Bob"":1},""owed_by"":{},""balance"":-1},{""name"":""Bob"",""owes"":{},""owed_by"":{""Adam"":1},""balance"":1}]"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Lender_owes_borrower_less_than_new_loan()
        Dim url = "/iou"
        Dim payload = "{""lender"":""Adam"",""borrower"":""Bob"",""amount"":4}"
        Dim database = "[{""name"":""Adam"",""owes"":{""Bob"":3},""owed_by"":{},""balance"":-3},{""name"":""Bob"",""owes"":{},""owed_by"":{""Adam"":3},""balance"":3}]"
        Dim sut = New RestApi(database)
        Dim actual = sut.Post(url, payload)
        Dim expected = "[{""name"":""Adam"",""owes"":{},""owed_by"":{""Bob"":1},""balance"":1},{""name"":""Bob"",""owes"":{""Adam"":1},""owed_by"":{},""balance"":-1}]"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Lender_owes_borrower_same_as_new_loan()
        Dim url = "/iou"
        Dim payload = "{""lender"":""Adam"",""borrower"":""Bob"",""amount"":3}"
        Dim database = "[{""name"":""Adam"",""owes"":{""Bob"":3},""owed_by"":{},""balance"":-3},{""name"":""Bob"",""owes"":{},""owed_by"":{""Adam"":3},""balance"":3}]"
        Dim sut = New RestApi(database)
        Dim actual = sut.Post(url, payload)
        Dim expected = "[{""name"":""Adam"",""owes"":{},""owed_by"":{},""balance"":0},{""name"":""Bob"",""owes"":{},""owed_by"":{},""balance"":0}]"
        Assert.Equal(expected, actual)
    End Sub
End Class
