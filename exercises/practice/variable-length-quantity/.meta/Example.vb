Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Module VariableLengthQuantity
    Private Const SevenBitsMask As UInteger = &H7fUI
    Private Const EightBitMask As UInteger = &H80UI

    Public Function Encode(ByVal numbers As UInteger()) As UInteger()
        Return numbers.SelectMany(New Func(Of UInteger, IEnumerable(Of UInteger))(AddressOf EncodeSingle)).ToArray()
    End Function

    Private Function EncodeSingle(ByVal number As UInteger) As IEnumerable(Of UInteger)
        If number = 0 Then
            Return {0UI}
        End If

        Dim bytes = New List(Of UInteger)(4)

        While number > 0
            Dim tmp = number And SevenBitsMask
            number >>= 7

            If bytes.Any() Then
                tmp = tmp Or EightBitMask
            End If

            bytes.Add(tmp)
        End While

        bytes.Reverse()
        Return bytes
    End Function

    Public Function Decode(ByVal bytes As UInteger()) As UInteger()
        Dim numbers = New List(Of UInteger)()
        Dim tmp = 0UI

        For index = 0 To bytes.Length - 1
            If (tmp And &Hfe000000UI) > 0 Then
                Throw New InvalidOperationException("Overflow exception.")
            End If

            Dim b = bytes(index)
            tmp = tmp << 7 Or b And &H7fUI

            If (b And &H80) = 0 Then
                numbers.Add(tmp)
                tmp = 0
            ElseIf index = bytes.Length - 1 Then
                Throw New InvalidOperationException("Incomplete byte sequence.")
            End If
        Next

        Return numbers.ToArray()
    End Function
End Module
