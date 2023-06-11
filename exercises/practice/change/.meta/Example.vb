Imports System
Imports System.Collections.Generic
Imports System.Linq

Module Change
    Function FindFewestCoins(ByVal coins As Integer(), ByVal target As Integer) As Integer()
        If target < 0 Then
            Throw New ArgumentException("Target amount cannot be negative.")
        End If

        If target > 0 AndAlso target < coins.Min() Then
            Throw New ArgumentException("Target amount cannot be less than minimal coin value.")
        End If

        Dim minimalCoinsMapSeed = New Dictionary(Of Integer, List(Of Integer))()
        minimalCoinsMapSeed(0) = New List(Of Integer)(0)
        Dim minimalCoinsMap = Enumerable.Range(1, target).Aggregate(minimalCoinsMapSeed, Function(current, subTarget) UpdateMinimalCoinsMap(coins, current, subTarget))
        Dim minimalCoins As List = Nothing
        If minimalCoinsMap.TryGetValue(target, minimalCoins) Then Return minimalCoins.OrderBy(Function(x) x).ToArray()
        Throw New ArgumentException()
    End Function

    Private Function UpdateMinimalCoinsMap(ByVal coins As Integer(), ByVal current As Dictionary(Of Integer, List(Of Integer)), ByVal subTarget As Integer) As Dictionary(Of Integer, List(Of Integer))
        Dim subTargetMinimalCoins = MinimalCoins(coins, current, subTarget)
        If subTargetMinimalCoins IsNot Nothing Then current.Add(subTarget, subTargetMinimalCoins)
        Return current
    End Function

    Private Function MinimalCoins(ByVal coins As Integer(), ByVal current As Dictionary(Of Integer, List(Of Integer)), ByVal subTarget As Integer) As List(Of Integer)
        Dim subTargetMinimalCoins As List = Nothing
        Return coins.Where(Function(coin) coin <= subTarget).[Select](Function(coin)
                                                                          Dim subTargetMinimalCoins As List = Nothing
                                                                          Return If(current.TryGetValue(subTarget - coin, subTargetMinimalCoins), subTargetMinimalCoins.Append(coin).ToList(), Nothing)
                                                                      End Function).Where(Function(subTargetMinimalCoins) subTargetMinimalCoins IsNot Nothing).OrderBy(Function(subTargetMinimalCoins) subTargetMinimalCoins.Count).FirstOrDefault()
    End Function
End Module
