Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Module ListOps
    Private Function Cons(Of T)(ByVal x As T, ByVal input As List(Of T)) As List(Of T)
        Dim list = New List(Of T)(input)
        list.Insert(0, x)

        Return list
    End Function

    Public Function Length(Of T)(ByVal input As List(Of T)) As Integer
        Return Foldl(input, 0, Function(acc, x) acc + 1)
    End Function

    Public Function Reverse(Of T)(ByVal input As List(Of T)) As List(Of T)
        Return Foldl(input, New List(Of T)(), Function(acc, x) Cons(x, acc))
    End Function

    Public Function Map(Of TIn, TOut)(ByVal input As List(Of TIn), ByVal pMap As Func(Of TIn, TOut)) As List(Of TOut)
        Return Foldr(input, New List(Of TOut)(), Function(x, acc) Cons(pMap(x), acc))
    End Function

    Public Function Filter(Of T)(ByVal input As List(Of T), ByVal predicate As Func(Of T, Boolean)) As List(Of T)
        Return Foldr(input, New List(Of T)(), Function(x, acc) If(predicate(x), Cons(x, acc), acc))
    End Function

    Public Function Foldl(Of TIn, TOut)(ByVal input As List(Of TIn), ByVal start As TOut, ByVal func As Func(Of TOut, TIn, TOut)) As TOut
        Dim acc = start

        For Each item In input
            acc = func(acc, item)
        Next

        Return acc
    End Function

    Public Function Foldr(Of TIn, TOut)(ByVal input As List(Of TIn), ByVal start As TOut, ByVal func As Func(Of TIn, TOut, TOut)) As TOut
        Dim acc = start

        For i = input.Count - 1 To 0 Step -1
            acc = func(input(i), acc)
        Next

        Return acc
    End Function

    Public Function Concat(Of T)(ByVal input As List(Of List(Of T))) As List(Of T)
        Dim concatenated = New List(Of T)()
        Dim sublist As List(Of T) = Nothing

        For Each list In input
            If CSharpImpl.__Assign(sublist, TryCast(list, List(Of T))) IsNot Nothing Then concatenated = Append(concatenated, sublist)
        Next


        Return concatenated
    End Function

    Public Function Append(Of T)(ByVal left As List(Of T), ByVal right As List(Of T)) As List(Of T)
        Dim appended = New T(left.Count + right.Count - 1) {}

        For i = 0 To left.Count - 1
            appended(i) = left(i)
        Next

        For j = 0 To right.Count - 1
            appended(left.Count + j) = right(j)
        Next

        Return appended.ToList()
    End Function

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Module
