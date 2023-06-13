Imports System

Public Structure ComplexNumberType
    Public Sub New(ByVal real As Double, ByVal imaginary As Double)
    End Sub

    Public Function Real() As Double
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Imaginary() As Double
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Mul(ByVal other As ComplexNumber) As ComplexNumber
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Add(ByVal other As ComplexNumber) As ComplexNumber
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function [Sub](ByVal other As ComplexNumber) As ComplexNumber
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Div(ByVal other As ComplexNumber) As ComplexNumber
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Abs() As Double
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Conjugate() As ComplexNumber
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Function Exp() As ComplexNumber
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Structure
