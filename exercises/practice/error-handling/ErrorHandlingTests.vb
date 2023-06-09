Imports System
Imports Xunit

Public Class ErrorHandlingTests
    ' Read more about exception handling here:
    ' https://msdn.microsoft.com/en-us/library/ms173162.aspx?f=255&MSPPError=-2147217396
    <Fact>
    Public Sub ThrowException()
        Assert.Throws(Of Exception)(Sub() HandleErrorByThrowingException())
    End Sub

    ' Read more about nullable types here:
    ' https://msdn.microsoft.com/en-us/library/1t3y8s4s.aspx?f=255&MSPPError=-2147217396
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ReturnNullableType()
        Dim successfulResult = HandleErrorByReturningNullableType("1")
        Assert.Equal(1, successfulResult)

        Dim failureResult = HandleErrorByReturningNullableType("a")
        Assert.Null(failureResult)
    End Sub

    ' Read more about out parameters here:
    ' https://msdn.microsoft.com/en-us/library/t3c3bfhx.aspx?f=255&MSPPError=-2147217396
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub ReturnWithOutParameter()
        Dim result As Integer
        Dim successfulResult = HandleErrorWithOutParam("1", result)
        Assert.True(successfulResult)
        Assert.Equal(1, result)

        Dim failureResult = HandleErrorWithOutParam("a", result)
        Assert.False(failureResult)
        ' The value of result is meaningless here (it could be anything) so it shouldn't be used and it's not validated 
    End Sub

    Private Class DisposableResource
        Implements IDisposable
        Private _IsDisposed As Boolean

        Public Property IsDisposed As Boolean
            Get
                Return _IsDisposed
            End Get
            Private Set(ByVal value As Boolean)
                _IsDisposed = value
            End Set
        End Property

        Public Sub Dispose() Implements IDisposable.Dispose
            IsDisposed = True
        End Sub
    End Class

    ' Read more about IDisposable here:
    ' https://msdn.microsoft.com/en-us/library/system.idisposable(v=vs.110).aspx
    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub DisposableObjectsAreDisposedWhenThrowingAnException()
        Dim disposableResource = New DisposableResource()

        Assert.Throws(Of Exception)(Sub() DisposableResourcesAreDisposedWhenExceptionIsThrown(disposableResource))
        Assert.True(disposableResource.IsDisposed)
    End Sub
End Class
