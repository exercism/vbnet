Imports System
Imports System.Runtime.InteropServices

Public Module ErrorHandling
    Public Sub HandleErrorByThrowingException()
        Throw New Exception("An error occured.")
    End Sub

    Public Function HandleErrorByReturningNullableType(ByVal input As String) As Integer?
        Dim result As Integer

        If Integer.TryParse(input, result) Then
            Return result
        End If

        Return Nothing
    End Function

    Public Function HandleErrorWithOutParam(ByVal input As String, <Out> ByRef result As Integer) As Boolean
        Return Integer.TryParse(input, result)
    End Function

    Public Sub DisposableResourcesAreDisposedWhenExceptionIsThrown(ByVal disposableObject As IDisposable)
        Using disposableObject
            Throw New Exception("An error occured.")
        End Using
    End Sub
End Module
