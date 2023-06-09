Imports System
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports Xunit

Public Class BankAccountTests
    <Fact>
    Public Sub Returns_empty_balance_after_opening()
        Dim account = New BankAccount()
        account.Open()

        Assert.Equal(0D, account.Balance)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Check_basic_balance()
        Dim account = New BankAccount()
        account.Open()

        Dim openingBalance = account.Balance

        account.UpdateBalance(10D)
        Dim updatedBalance = account.Balance

        Assert.Equal(0D, openingBalance)
        Assert.Equal(10D, updatedBalance)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Balance_can_increment_and_decrement()
        Dim account = New BankAccount()
        account.Open()
        Dim openingBalance = account.Balance

        account.UpdateBalance(10D)
        Dim addedBalance = account.Balance

        account.UpdateBalance(-15D)
        Dim subtractedBalance = account.Balance

        Assert.Equal(0D, openingBalance)
        Assert.Equal(10D, addedBalance)
        Assert.Equal(-5D, subtractedBalance)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Closed_account_throws_exception_when_checking_balance()
        Dim account = New BankAccount()
        account.Open()
        account.Close()

        Assert.Throws(Of InvalidOperationException)(Function() account.Balance)
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Change_account_balance_from_multiple_threads()
        Dim account = New BankAccount()
        Dim tasks = New List(Of Task)()

        Dim threads = 500
        Dim iterations = 100

        account.Open()
        For i = 0 To threads - 1
            tasks.Add(Task.Factory.StartNew(Sub()
                                                For j = 0 To iterations - 1
                                                    account.UpdateBalance(1D)
                                                    account.UpdateBalance(-1D)
                                                Next
                                            End Sub))
        Next
        Call Task.WaitAll(tasks.ToArray())

        Assert.Equal(0D, account.Balance)
    End Sub
End Class
