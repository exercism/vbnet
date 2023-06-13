Imports System
Imports System.Linq
Imports System.Text

Public Class SimpleCipher
    Private Const Alphabet As String = "abcdefghijklmnopqrstuvwxyz"

    Private Shared ReadOnly Rand As Random = New Random()

    Public ReadOnly Property KeyProp As String

    Public Sub New()
        Key = New String(Enumerable.Range(0, 100).[Select](Function(x) Alphabet(Rand.Next(Alphabet.Length))).ToArray())
    End Sub

    Public Sub New(ByVal key As String)
        Key = key
    End Sub

    Public Function EncodeMethod(ByVal plaintext As String) As String
        Dim ciphertext = New StringBuilder(plaintext.Length)

        For i = 0 To plaintext.Length - 1
            ciphertext.Append(EncodeCharacter(plaintext, i))
        Next

        Return ciphertext.ToString()
    End Function

    Private Function EncodeCharacter(ByVal plaintext As String, ByVal idx As Integer) As Char
        Dim alphabetIdx = Alphabet.IndexOf(plaintext(idx)) + Alphabet.IndexOf(Key(idx Mod Key.Length))
        If alphabetIdx >= Alphabet.Length Then alphabetIdx -= Alphabet.Length
        Return Alphabet(alphabetIdx)
    End Function

    Public Function DecodeMethod(ByVal ciphertext As String) As String
        Dim plaintext = New StringBuilder(ciphertext.Length)

        For i = 0 To ciphertext.Length - 1
            plaintext.Append(DecodeCharacter(ciphertext, i))
        Next

        Return plaintext.ToString()
    End Function

    Private Function DecodeCharacter(ByVal ciphertext As String, ByVal idx As Integer) As Char
        Dim alphabetIdx = Alphabet.IndexOf(ciphertext(idx)) - Alphabet.IndexOf(Key(idx Mod Key.Length))
        If alphabetIdx < 0 Then alphabetIdx += Alphabet.Length
        Return Alphabet(alphabetIdx)
    End Function
End Class
