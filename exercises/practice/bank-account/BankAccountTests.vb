Imports System.Threading.Tasks
Imports Xunit

Public Class BankAccountTests

    <Fact>
    Public Sub Initial_balance_is_zero()
        Dim account As New BankAccount()

        account.Open()

        Assert.Equal(0D, account.Balance)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_deposit()
        Dim account As New BankAccount()

        account.Open()
        account.Deposit(100D)

        Assert.Equal(100D, account.Balance)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_deposit_multiple_times()
        Dim account As New BankAccount()

        account.Open()
        account.Deposit(100D)
        account.Deposit(50D)

        Assert.Equal(150D, account.Balance)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_withdraw()
        Dim account As New BankAccount()

        account.Open()
        account.Deposit(100D)
        account.Withdraw(75D)

        Assert.Equal(25D, account.Balance)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_withdraw_multiple_times()
        Dim account As New BankAccount()

        account.Open()
        account.Deposit(100D)
        account.Withdraw(80D)
        account.Withdraw(20D)

        Assert.Equal(0D, account.Balance)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_deposit_when_account_is_closed()
        Dim account As New BankAccount()
        account.Open()
        account.Close()
        Assert.Throws(Of InvalidOperationException)(
            Sub() account.Deposit(50D)
        )
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_deposit_into_unopened_account()
        Dim account As New BankAccount()
        Assert.Throws(Of InvalidOperationException)(
            Sub() account.Deposit(50D)
        )
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_withdraw_when_account_is_closed()
        Dim account As New BankAccount()
        account.Open()
        account.Close()
        Assert.Throws(Of InvalidOperationException)(
            Sub() account.Withdraw(50D)
        )
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_check_balance_when_account_is_closed()
        Dim account As New BankAccount()
        account.Open()
        account.Close()
        Assert.Throws(Of InvalidOperationException)(
            Sub()
                Dim unused = account.Balance
            End Sub
        )
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Can_perform_multiple_operations_sequentially()
        Dim account As New BankAccount()
        account.Open()
        account.Deposit(100D)
        account.Deposit(110D)
        account.Withdraw(200D)
        account.Deposit(60D)
        account.Withdraw(50D)
        Assert.Equal(20D, account.Balance)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_close_account_that_was_not_opened()
        Dim account As New BankAccount()
        Assert.Throws(Of InvalidOperationException)(
            Sub() account.Close()
        )
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_open_already_open_account()
        Dim account As New BankAccount()
        account.Open()
        Assert.Throws(Of InvalidOperationException)(
            Sub() account.Open()
        )
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Reopened_account_has_zero_balance()
        Dim account As New BankAccount()
        account.Open()
        account.Deposit(50D)
        account.Close()
        account.Open()
        Assert.Equal(0D, account.Balance)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_withdraw_more_than_deposited()
        Dim account As New BankAccount()
        account.Open()
        account.Deposit(25D)
        Assert.Throws(Of InvalidOperationException)(
            Sub() account.Withdraw(50D)
        )
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_withdraw_negative()
        Dim account As New BankAccount()
        account.Open()
        account.Deposit(100D)
        Assert.Throws(Of InvalidOperationException)(
            Sub() account.Withdraw(-50D)
        )
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cannot_deposit_negative()
        Dim account As New BankAccount()
        account.Open()
        Assert.Throws(Of InvalidOperationException)(
            Sub() account.Deposit(-50D)
        )
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Concurrent_transactions_leave_balance_unchanged()
        Dim account As New BankAccount()
        account.Open()
        Dim tasks As New List(Of Task)
        For i = 1 To 1000
            tasks.Add(Task.Run(
                Sub()
                    account.Deposit(1D)
                    account.Withdraw(1D)
                End Sub
            ))
        Next
        Task.WaitAll(tasks.ToArray())
        Assert.Equal(0D, account.Balance)
    End Sub
End Class
