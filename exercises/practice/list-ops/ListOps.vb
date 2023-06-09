Imports System
Imports System.Collections.Generic

Public Module ListOps
    Public Function Length(Of T)(ByVal input As List(Of T)) As Integer
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Reverse(Of T)(ByVal input As List(Of T)) As List(Of T)
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Map(Of TIn, TOut)(ByVal input As List(Of TIn), ByVal map As Func(Of TIn, TOut)) As List(Of TOut)
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Filter(Of T)(ByVal input As List(Of T), ByVal predicate As Func(Of T, Boolean)) As List(Of T)
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Foldl(Of TIn, TOut)(ByVal input As List(Of TIn), ByVal start As TOut, ByVal func As Func(Of TOut, TIn, TOut)) As TOut
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Foldr(Of TIn, TOut)(ByVal input As List(Of TIn), ByVal start As TOut, ByVal func As Func(Of TIn, TOut, TOut)) As TOut
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Concat(Of T)(ByVal input As List(Of List(Of T))) As List(Of T)
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Append(Of T)(ByVal left As List(Of T), ByVal right As List(Of T)) As List(Of T)
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Module
