Imports System.Threading.Tasks

Public Class BankAccountTests
    <Fact>
    Public Sub Newly_opened_account_has_zero_balance()
        Dim account = New BankAccount()
        account.Open()
        Dim actual = account.Balance
        Dim expected = 0D
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Single_deposit()
        Dim account = New BankAccount()
        account.Open()
        account.Deposit(100D)
        Dim actual = account.Balance
        Dim expected = 100D
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_deposits()
        Dim account = New BankAccount()
        account.Open()
        account.Deposit(100D)
        account.Deposit(50D)
        Dim actual = account.Balance
        Dim expected = 150D
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Withdraw_once()
        Dim account = New BankAccount()
        account.Open()
        account.Deposit(100D)
        account.Withdraw(75D)
        Dim actual = account.Balance
        Dim expected = 25D
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Withdraw_twice()
        Dim account = New BankAccount()
        account.Open()
        account.Deposit(100D)
        account.Withdraw(80D)
        account.Withdraw(20D)
        Dim actual = account.Balance
        Dim expected = 0D
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_do_multiple_operations_sequentially()
        Dim account = New BankAccount()
        account.Open()
        account.Deposit(100D)
        account.Deposit(110D)
        account.Withdraw(200D)
        account.Deposit(60D)
        account.Withdraw(50D)
        Dim actual = account.Balance
        Dim expected = 20D
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_check_balance_of_closed_account()
        Dim account = New BankAccount()
        account.Open()
        account.Close()
        Assert.Throws(Of InvalidOperationException)(Function() account.Balance)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_deposit_into_closed_account()
        Dim account = New BankAccount()
        account.Open()
        account.Close()
        Assert.Throws(Of InvalidOperationException)(Sub() account.Deposit(50D))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_deposit_into_unopened_account()
        Dim account = New BankAccount()
        Assert.Throws(Of InvalidOperationException)(Sub() account.Deposit(50D))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_withdraw_from_closed_account()
        Dim account = New BankAccount()
        account.Open()
        account.Close()
        Assert.Throws(Of InvalidOperationException)(Sub() account.Withdraw(50D))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_close_an_account_that_was_not_opened()
        Dim account = New BankAccount()
        Assert.Throws(Of InvalidOperationException)(Sub() account.Close())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_open_an_already_opened_account()
        Dim account = New BankAccount()
        account.Open()
        Assert.Throws(Of InvalidOperationException)(Sub() account.Open())
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reopened_account_does_not_retain_balance()
        Dim account = New BankAccount()
        account.Open()
        account.Deposit(50D)
        account.Close()
        account.Open()
        Dim actual = account.Balance
        Dim expected = 0D
        Assert.Equal(expected, actual)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_withdraw_more_than_deposited()
        Dim account = New BankAccount()
        account.Open()
        account.Deposit(25D)
        Assert.Throws(Of InvalidOperationException)(Sub() account.Withdraw(50D))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_withdraw_negative()
        Dim account = New BankAccount()
        account.Open()
        account.Deposit(100D)
        Assert.Throws(Of InvalidOperationException)(Sub() account.Withdraw(-50D))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_deposit_negative()
        Dim account = New BankAccount()
        account.Open()
        Assert.Throws(Of InvalidOperationException)(Sub() account.Deposit(-50D))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_handle_concurrent_transactions()
        Dim account = New BankAccount()
        account.Open()
        Dim tasks As New List(Of Task)
        For i = 1 To 1000
            tasks.Add(Task.Run(
                Sub()
                    account.Deposit(1D)
                    account.Withdraw(1D)
                End Sub))
        Next
        Task.WaitAll(tasks.ToArray())
        Dim actual = account.Balance
        Dim expected = 0D
        Assert.Equal(expected, actual)
    End Sub
End Class
