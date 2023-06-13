Imports System
Imports System.Runtime.CompilerServices

Public Module RealNumberExtension
    <Extension()>
    Public Function Expreal(ByVal realNumber As Integer, ByVal r As RationalNumber) As Double
        Throw New NotImplementedException("You need to implement this extension method.")
    End Function
End Module

Public Structure RationalNumber
    Public Sub New(ByVal numerator As Integer, ByVal denominator As Integer)
    End Sub

    Public Operator +(ByVal r1 As RationalNumber, ByVal r2 As RationalNumber) As RationalNumber
        Throw New NotImplementedException("You need to implement this operator.")
    End Operator

    Public Operator -(ByVal r1 As RationalNumber, ByVal r2 As RationalNumber) As RationalNumber
        Throw New NotImplementedException("You need to implement this operator.")
    End Operator

    Public Operator *(ByVal r1 As RationalNumber, ByVal r2 As RationalNumber) As RationalNumber
        Throw New NotImplementedException("You need to implement this operator.")
    End Operator

    Public Operator /(ByVal r1 As RationalNumber, ByVal r2 As RationalNumber) As RationalNumber
        Throw New NotImplementedException("You need to implement this operator.")
    End Operator

    Public Function Abs() As RationalNumber
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Reduce() As RationalNumber
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Exprational(ByVal power As Integer) As RationalNumber
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Expreal(ByVal baseNumber As Integer) As Double
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Structure
