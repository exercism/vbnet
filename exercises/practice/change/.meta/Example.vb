Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Module Change
    Public Function FindFewestCoins(ByVal coins As Integer(), ByVal target As Integer) As Integer()
        If target = 0 Then
            Return New List(Of Integer)().ToArray()
        End If

        If target < 0 OrElse target < coins.Min() Then
            Throw New ArgumentException()
        End If

        Dim fewestCoins = New Integer(target + 1 - 1)() {}
        fewestCoins(0) = Array.Empty(Of Integer)()

        For amount = 1 To target
            Dim change As IEnumerable(Of Integer) = coins.Where(Function(coin) coin <= amount).[Select](Function(coin) fewestCoins(amount - coin).Append(coin)).OrderBy(Function(x) x.Count()).FirstOrDefault(Function(y) y.Sum() = amount)

            If change Is Nothing Then
                fewestCoins(amount) = New List(Of Integer)().ToArray()
            Else
                fewestCoins(amount) = change.OrderBy(Function(coin) coin).ToArray()
            End If
        Next

        If fewestCoins(target).Count() > 0 Then
            Return fewestCoins(target)
        End If
        
        Throw New ArgumentException()
    End Function
End Module
