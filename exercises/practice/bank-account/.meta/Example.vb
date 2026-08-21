Public Class BankAccount
    Private ReadOnly _lock As New Object()
    Private _isOpen As Boolean = False
    Private _balance As Decimal = 0D

    Public Sub Open()
        SyncLock _lock
            If _isOpen Then
                Throw New InvalidOperationException("account already open")
            End If

            _isOpen = True
            _balance = 0D
        End SyncLock
    End Sub

    Public Sub Close()
        SyncLock _lock
            If Not _isOpen Then
                Throw New InvalidOperationException("account not open")
            End If

            _isOpen = False
            _balance = 0D
        End SyncLock
    End Sub

    Public Sub Deposit(ByVal amount As Decimal)
        SyncLock _lock
            If Not _isOpen Then
                Throw New InvalidOperationException("account not open")
            End If

            If amount <= 0D Then
                Throw New InvalidOperationException("amount must be greater than 0")
            End If

            _balance += amount
        End SyncLock
    End Sub

    Public Sub Withdraw(ByVal amount As Decimal)
        SyncLock _lock
            If Not _isOpen Then
                Throw New InvalidOperationException("account not open")
            End If

            If amount <= 0D Then
                Throw New InvalidOperationException("amount must be greater than 0")
            End If

            If amount > _balance Then
                Throw New InvalidOperationException("amount must be less than balance")
            End If

            _balance -= amount
        End SyncLock
    End Sub

    Public ReadOnly Property Balance As Decimal
        Get
            SyncLock _lock
                If Not _isOpen Then
                    Throw New InvalidOperationException("account not open")
                End If

                Return _balance
            End SyncLock
        End Get
    End Property
End Class
