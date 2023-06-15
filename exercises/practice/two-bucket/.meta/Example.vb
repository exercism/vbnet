Imports System

Public Enum Bucket
    One
    Two
End Enum

Public Class TwoBucketResult
    Public Property Moves As Integer
    Public Property GoalBucket As Bucket
    Public Property OtherBucket As Integer

    Public Sub New (moves as Integer, goalBucket as Bucket, otherbucket as Integer)
        Me.Moves = moves
        Me.GoalBucket = goalBucket
        Me.Otherbucket = otherbucket
    End Sub
End Class

Public Class TwoBucket

    Private Class Pail
        Public Property Name As Bucket
        Public Property Size As Integer
        Public Property Level As Integer = 0

        Public Sub New(name As Bucket, size As Integer)
            Me.Name = name
            Me.Size = size
        End Sub

        Public Function Room() As Integer
            Return Size - Level
        End Function

        Public ReadOnly Property IsFull As Integer
            Get
                Return Level = Size
            End Get
        End Property

        Public ReadOnly Property IsEmpty As Integer
            Get
                Return Level = 0
            End Get
        End Property

        Public Sub Fill()
            Level = Size
        End Sub

        Public Sub Empty()
            Level = 0
        End Sub

        Public Sub PourInto(Other as Pail)
            Dim amount = Math.Min(Level, Other.Room)
            Level -= amount
            Other.Level += amount
        End Sub
    End Class

    Private ReadOnly start As Pail
    Private ReadOnly other As Pail

    Public Sub New(ByVal bucketOneCapacity As Integer, ByVal bucketTwoCapacity As Integer, ByVal startBucket As Bucket)
        If startBucket = Bucket.One Then
            start = New Pail(Bucket.One, bucketOneCapacity)
            other = New Pail(Bucket.Two, bucketTwoCapacity)
        Else
            start = New Pail(Bucket.Two, bucketTwoCapacity)
            other = New Pail(Bucket.One, bucketOneCapacity)
        End If
    End Sub


    Public Function Measure(goal As Integer) As TwoBucketResult
        If goal > Math.Max(start.Size, other.Size) Then Throw New ArgumentException(goal)
    
        If other.Size = goal Then Return New TwoBucketResult(2, other.Name, start.Size)
    
        Dim moves = 0

        While start.Level <> goal AndAlso other.Level <> goal
            If start.IsEmpty Then
                start.Fill()
            ElseIf other.IsFull Then
                other.Empty()
            Else
                start.PourInto(other)
            End If
    
            If start.IsFull AndAlso other.IsFull Then Throw New ArgumentException(goal)
    
            moves += 1
        End While
    
        If start.Level = goal Then
            Return New TwoBucketResult(moves, start.Name, other.Level)
        Else
            Return New TwoBucketResult(moves, other.Name, start.Level)
        End If
            
    End Function
End Class
