Imports System
Imports System.Collections.Generic

Public Module AllYourBase
    Public Function Rebase(ByVal inputBase As Integer, ByVal inputDigits As Integer(), ByVal outputBase As Integer) As Integer()
        If outputBase <= 1 OrElse inputBase <= 1 Then Throw New ArgumentException()
        Dim inputValue = 0
        Dim exponent = 0, place = inputDigits.Length - 1

        While exponent < inputDigits.Length
            If inputDigits(place) < 0 OrElse inputDigits(place) >= inputBase Then Throw New ArgumentException()
            inputValue += inputDigits(place) * CInt(Math.Pow(inputBase, exponent))
            exponent += 1
            place -= 1
        End While

        Dim outputList As List(Of Integer) = New List(Of Integer)()

        Do
            outputList.Insert(0, inputValue Mod outputBase)
            inputValue \= outputBase
        Loop While inputValue > 0

        Return outputList.ToArray()
    End Function
End Module