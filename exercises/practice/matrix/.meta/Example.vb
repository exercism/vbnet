Imports System.Linq

Public Class Matrix
    Private ReadOnly _rows As Integer()()
    Private ReadOnly _cols As Integer()()

    Public Sub New(ByVal input As String)
        _rows = ParseRows(input)
        _cols = ParseCols(_rows)
    End Sub

    Public ReadOnly Property Rows As Integer
        Get
            Return _rows.Length
        End Get
    End Property
    Public ReadOnly Property Cols As Integer
        Get
            Return _cols.Length
        End Get
    End Property

    Public Function Row(ByVal pRow As Integer) As Integer()
        Return _rows(pRow - 1)
    End Function
    Public Function Column(ByVal col As Integer) As Integer()
        Return _cols(col - 1)
    End Function

    Private Shared Function ParseRows(ByVal input As String) As Integer()()
        Return input.Split(ChrW(10)).[Select](New Func(Of String, Integer())(AddressOf ParseRow)).ToArray()
    End Function

    Private Shared Function ParseRow(ByVal row As String) As Integer()
        Return row.Split(" "c).[Select](New Func(Of String, Integer)(AddressOf Integer.Parse)).ToArray()
    End Function

    Private Shared Function ParseCols(ByVal rows As Integer()()) As Integer()()
        Return Enumerable.Range(0, rows(0).Length).[Select](Function(y) ParseCol(rows, y)).ToArray()
    End Function

    Private Shared Function ParseCol(ByVal rows As Integer()(), ByVal y As Integer) As Integer()
        Return Enumerable.Range(0, rows.Length).[Select](Function(x) rows(x)(y)).ToArray()
    End Function
End Class
