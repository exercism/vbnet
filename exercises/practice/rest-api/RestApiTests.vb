Public Class RestApiTests
    <Fact>
    Public Sub No_users()
        Dim url = "/users"
        Dim database = "[]"
        Dim sut = New RestApi(database)
        Dim actual = sut.[Get](url)
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
        Dim expected = "{""Name"":""Adam"",""Owes"":{},""OwedBy"":{},""Balance"":0}"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Get_single_user()
        Dim url = "/users"
        Dim payload = "{""users"":[""Bob""]}"
        Dim database = "[{""Name"":""Adam"",""Owes"":{},""OwedBy"":{},""Balance"":0},{""Name"":""Bob"",""Owes"":{},""OwedBy"":{},""Balance"":0}]"
        Dim sut = New RestApi(database)
        Dim actual = sut.[Get](url, payload)
        Dim expected = "[{""Name"":""Bob"",""Owes"":{},""OwedBy"":{},""Balance"":0}]"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Both_users_have_0_balance()
        Dim url = "/iou"
        Dim payload = "{""lender"":""Adam"",""borrower"":""Bob"",""amount"":3}"
        Dim database = "[{""Name"":""Adam"",""Owes"":{},""OwedBy"":{},""Balance"":0},{""Name"":""Bob"",""Owes"":{},""OwedBy"":{},""Balance"":0}]"
        Dim sut = New RestApi(database)
        Dim actual = sut.Post(url, payload)
        Dim expected = "[{""Name"":""Adam"",""Owes"":{},""OwedBy"":{""Bob"":3},""Balance"":3},{""Name"":""Bob"",""Owes"":{""Adam"":3},""OwedBy"":{},""Balance"":-3}]"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Borrower_has_negative_balance()
        Dim url = "/iou"
        Dim payload = "{""lender"":""Adam"",""borrower"":""Bob"",""amount"":3}"
        Dim database = "[{""Name"":""Adam"",""Owes"":{},""OwedBy"":{},""Balance"":0},{""Name"":""Bob"",""Owes"":{""Chuck"":3},""OwedBy"":{},""Balance"":-3},{""Name"":""Chuck"",""Owes"":{},""OwedBy"":{""Bob"":3},""Balance"":3}]"
        Dim sut = New RestApi(database)
        Dim actual = sut.Post(url, payload)
        Dim expected = "[{""Name"":""Adam"",""Owes"":{},""OwedBy"":{""Bob"":3},""Balance"":3},{""Name"":""Bob"",""Owes"":{""Adam"":3,""Chuck"":3},""OwedBy"":{},""Balance"":-6}]"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Lender_has_negative_balance()
        Dim url = "/iou"
        Dim payload = "{""lender"":""Bob"",""borrower"":""Adam"",""amount"":3}"
        Dim database = "[{""Name"":""Adam"",""Owes"":{},""OwedBy"":{},""Balance"":0},{""Name"":""Bob"",""Owes"":{""Chuck"":3},""OwedBy"":{},""Balance"":-3},{""Name"":""Chuck"",""Owes"":{},""OwedBy"":{""Bob"":3},""Balance"":3}]"
        Dim sut = New RestApi(database)
        Dim actual = sut.Post(url, payload)
        Dim expected = "[{""Name"":""Adam"",""Owes"":{""Bob"":3},""OwedBy"":{},""Balance"":-3},{""Name"":""Bob"",""Owes"":{""Chuck"":3},""OwedBy"":{""Adam"":3},""Balance"":0}]"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Lender_owes_borrower()
        Dim url = "/iou"
        Dim payload = "{""lender"":""Adam"",""borrower"":""Bob"",""amount"":2}"
        Dim database = "[{""Name"":""Adam"",""Owes"":{""Bob"":3},""OwedBy"":{},""Balance"":-3},{""Name"":""Bob"",""Owes"":{},""OwedBy"":{""Adam"":3},""Balance"":3}]"
        Dim sut = New RestApi(database)
        Dim actual = sut.Post(url, payload)
        Dim expected = "[{""Name"":""Adam"",""Owes"":{""Bob"":1},""OwedBy"":{},""Balance"":-1},{""Name"":""Bob"",""Owes"":{},""OwedBy"":{""Adam"":1},""Balance"":1}]"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Lender_owes_borrower_less_than_new_loan()
        Dim url = "/iou"
        Dim payload = "{""lender"":""Adam"",""borrower"":""Bob"",""amount"":4}"
        Dim database = "[{""Name"":""Adam"",""Owes"":{""Bob"":3},""OwedBy"":{},""Balance"":-3},{""Name"":""Bob"",""Owes"":{},""OwedBy"":{""Adam"":3},""Balance"":3}]"
        Dim sut = New RestApi(database)
        Dim actual = sut.Post(url, payload)
        Dim expected = "[{""Name"":""Adam"",""Owes"":{},""OwedBy"":{""Bob"":1},""Balance"":1},{""Name"":""Bob"",""Owes"":{""Adam"":1},""OwedBy"":{},""Balance"":-1}]"
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Lender_owes_borrower_same_as_new_loan()
        Dim url = "/iou"
        Dim payload = "{""lender"":""Adam"",""borrower"":""Bob"",""amount"":3}"
        Dim database = "[{""Name"":""Adam"",""Owes"":{""Bob"":3},""OwedBy"":{},""Balance"":-3},{""Name"":""Bob"",""Owes"":{},""OwedBy"":{""Adam"":3},""Balance"":3}]"
        Dim sut = New RestApi(database)
        Dim actual = sut.Post(url, payload)
        Dim expected = "[{""Name"":""Adam"",""Owes"":{},""OwedBy"":{},""Balance"":0},{""Name"":""Bob"",""Owes"":{},""OwedBy"":{},""Balance"":0}]"
        Assert.Equal(expected, actual)
    End Sub
End Class
