Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text.Json

Public Class User
    Public ReadOnly Property Name As String
    Public Property Owes As IDictionary(Of String, Double)
    Public Property OwedBy As IDictionary(Of String, Double)
    Public ReadOnly Property Balance As Double
        Get
            Return OwedBy.Sum(Function(x) x.Value) - Owes.Sum(Function(x) x.Value)
        End Get
    End Property

    Public Sub New(name As String)
        Me.Name = name
        Owes = New Dictionary(Of String, Double)()
        OwedBy = New Dictionary(Of String, Double)()
    End Sub

    Public Sub Lend(borrower As User, amount As Double)
        Dim remaining = amount
        If Owes.ContainsKey(borrower.Name) Then
            remaining = Owes(borrower.Name) - amount
            If remaining > 0 Then
                Owes(borrower.Name) = remaining
                Return
            End If

            Owes.Remove(borrower.Name)
            remaining *= -1
        End If

        If remaining > 0 Then
            If OwedBy.ContainsKey(borrower.Name) Then
                OwedBy(borrower.Name) += remaining
            Else
                OwedBy.Add(borrower.Name, remaining)
                OwedBy = OwedBy.OrderBy(Function(x) x.Key).ToDictionary(Function(x) x.Key, Function(x) x.Value)
            End If
        End If
    End Sub

    Public Sub Borrow(lender As User, amount As Double)
        Dim remaining = amount
        If OwedBy.ContainsKey(lender.Name) Then
            remaining = OwedBy(lender.Name) - amount
            If remaining > 0 Then
                OwedBy(lender.Name) = remaining
                Return
            End If

            OwedBy.Remove(lender.Name)
            remaining *= -1
        End If

        If remaining > 0 Then
            If Owes.ContainsKey(lender.Name) Then
                Owes(lender.Name) += remaining
            Else
                Owes.Add(lender.Name, remaining)
                Owes = Owes.OrderBy(Function(x) x.Key).ToDictionary(Function(x) x.Key, Function(x) x.Value)
            End If
        End If
    End Sub
End Class

Public Class RestApi
    Private ReadOnly users As IList(Of User)

    Public Sub New(database As String)
        users = JsonSerializer.Deserialize(Of List(Of User))(database)
    End Sub

    Public Function [Get](url As String, Optional payload As String = Nothing) As String
        If Not Equals(payload, Nothing) Then
            Dim values = JsonSerializer.Deserialize(Of Dictionary(Of String, IEnumerable(Of String)))(payload)
            Dim requestedUsers = values("users")
            Return JsonSerializer.Serialize(users.Where(Function(x) requestedUsers.Contains(x.Name)))
        End If

        Return If(url = "/users", JsonSerializer.Serialize(users), "[]")
    End Function

    Public Function Post(url As String, payload As String) As String
        If Equals(url, "/add") Then
            Dim values = JsonSerializer.Deserialize(Of Dictionary(Of String, String))(payload)
            Dim newUser = New User(values("user"))
            users.Add(newUser)
            Return JsonSerializer.Serialize(newUser)
        ElseIf Equals(url, "/iou") Then
            Dim values = JsonSerializer.Deserialize(Of Dictionary(Of String, Object))(payload)
            Dim lender = users.First(Function(x) x.Name.Equals(values("lender").ToString()))
            Dim borrower = users.First(Function(x) x.Name.Equals(values("borrower").ToString()))
            Dim amount = Double.Parse(values("amount").ToString())
            lender.Lend(borrower, amount)
            borrower.Borrow(lender, amount)

            Return JsonSerializer.Serialize({lender, borrower}.OrderBy(Function(x) x.Name))
        End If

        Return String.Empty
    End Function
End Class
