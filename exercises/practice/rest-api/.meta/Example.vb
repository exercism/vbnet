Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text.Json

Public Class User
    Public ReadOnly Property name As String
    Public Property owes As IDictionary(Of String, Double)
    Public Property owed_by As IDictionary(Of String, Double)
    Public ReadOnly Property balance As Double
        Get
            Return owed_by.Sum(Function(x) x.Value) - owes.Sum(Function(x) x.Value)
        End Get
    End Property

    Public Sub New(ByVal name As String)
        Me.name = name
        owes = New Dictionary(Of String, Double)()
        owed_by = New Dictionary(Of String, Double)()
    End Sub

    Public Sub Lend(ByVal borrower As User, ByVal amount As Double)
        Dim remaining = amount
        If owes.ContainsKey(borrower.name) Then
            remaining = owes(borrower.name) - amount
            If remaining > 0 Then
                owes(borrower.name) = remaining
                Return
            End If

            owes.Remove(borrower.name)
            remaining *= -1
        End If

        If remaining > 0 Then
            If owed_by.ContainsKey(borrower.name) Then
                owed_by(borrower.name) += remaining
            Else
                owed_by.Add(borrower.name, remaining)
                owed_by = owed_by.OrderBy(Function(x) x.Key).ToDictionary(Function(x) x.Key, Function(x) x.Value)
            End If
        End If
    End Sub

    Public Sub Borrow(ByVal lender As User, ByVal amount As Double)
        Dim remaining = amount
        If owed_by.ContainsKey(lender.name) Then
            remaining = owed_by(lender.name) - amount
            If remaining > 0 Then
                owed_by(lender.name) = remaining
                Return
            End If

            owed_by.Remove(lender.name)
            remaining *= -1
        End If

        If remaining > 0 Then
            If owes.ContainsKey(lender.name) Then
                owes(lender.name) += remaining
            Else
                owes.Add(lender.name, remaining)
                owes = owes.OrderBy(Function(x) x.Key).ToDictionary(Function(x) x.Key, Function(x) x.Value)
            End If
        End If
    End Sub
End Class

Public Class RestApi
    Private users As IList(Of User)

    Public Sub New(ByVal database As String)
        users = JsonSerializer.Deserialize(Of List(Of User))(database)
    End Sub

    Public Function Get(ByVal url As String, ByVal Optional payload As String = Nothing) As String
        If Not Equals(payload, Nothing) Then
            Dim values = JsonSerializer.Deserialize(Of Dictionary(Of String, IEnumerable(Of String)))(payload)
            Dim requestedUsers = values("users")
            Return JsonSerializer.Serialize(users.Where(Function(x) requestedUsers.Contains(x.name)))
        End If

        Return JsonSerializer.Serialize(users)
    End Function

    Public Function Post(ByVal url As String, ByVal payload As String) As String
        If Equals(url, "/add") Then
            Dim values = JsonSerializer.Deserialize(Of Dictionary(Of String, String))(payload)
            Dim newUser = New User(values("user"))
            users.Add(newUser)
            Return JsonSerializer.Serialize(newUser)
        ElseIf Equals(url, "/iou") Then
            Dim values = JsonSerializer.Deserialize(Of Dictionary(Of String, Object))(payload)
            Dim lender = users.First(Function(x) x.name.Equals(values("lender").ToString()))
            Dim borrower = users.First(Function(x) x.name.Equals(values("borrower").ToString()))
            Dim amount = Double.Parse(values("amount").ToString())
            lender.Lend(borrower, amount)
            borrower.Borrow(lender, amount)

            Return JsonSerializer.Serialize({lender, borrower}.OrderBy(Function(x) x.name))
        End If

        Return String.Empty
    End Function
End Class
