Imports System

Public Class BankAccount
    Private ReadOnly _lock As Object = New Object()

    Private balanceField As Decimal
    Private isOpen As Boolean

    Public Sub Open()
        SyncLock _lock
            isOpen = True
        End SyncLock
    End Sub

    Public Sub Close()
        SyncLock _lock
            isOpen = False
        End SyncLock
    End Sub

    Public ReadOnly Property Balance As Decimal
        Get
            SyncLock _lock
                If Not isOpen Then
                    Throw New InvalidOperationException("Cannot get balance on an account that isn't open")
                End If

                Return balanceField
            End SyncLock
        End Get
    End Property

    Public Sub UpdateBalance(ByVal change As Decimal)
        SyncLock _lock
            If Not isOpen Then
                Throw New InvalidOperationException("Cannot update balance on an account that isn't open")
            End If

            balanceField += change
        End SyncLock
    End Sub
End Class
