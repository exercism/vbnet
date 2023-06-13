Imports System

Public Enum Bucket
    One
    Two
End Enum

Public Class TwoBucketResult
    Public Property Moves As Integer
    Public Property GoalBucket As Bucket
    Public Property OtherBucket As Integer
End Class

Public Class TwoBucket
    Public Sub New(ByVal bucketOne As Integer, ByVal bucketTwo As Integer, ByVal startBucket As Bucket)
        Throw New NotImplementedException("You need to implement this function.")
    End Sub

    Public Function Measure(ByVal goal As Integer) As TwoBucketResult
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Class
