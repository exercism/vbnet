Imports System.Linq

Public Module RotationalCipher
    Private Const LowerCaseLetters As String = "abcdefghijklmnopqrstuvwxyz"
    Private Const UpperCaseLetters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    Public Function Rotate(ByVal text As String, ByVal shiftKey As Integer) As String
        Return New String(text.[Select](Function(letter) Rotate(letter, shiftKey)).ToArray())
    End Function

    Private Function Rotate(ByVal letter As Char, ByVal shiftKey As Integer) As Char
        If Not Char.IsLetter(letter) Then Return letter

        Return Rotate(letter, shiftKey, If(Char.IsLower(letter), LowerCaseLetters, UpperCaseLetters))
    End Function

    Private Function Rotate(ByVal letter As Char, ByVal shiftKey As Integer, ByVal key As String) As Char
        Return key((key.IndexOf(letter) + shiftKey) Mod key.Length)
    End Function
End Module
