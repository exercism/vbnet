Imports System
Imports System.Linq
Imports System.Text

Public Module AffineCipher
    Private m As Integer = 26

    Public Function Encode(ByVal plainText As String, ByVal a As Integer, ByVal b As Integer) As String
        Dim inverse = FindInverse(a, m)

        Dim source = plainText.Where(Function(p) Char.IsLetterOrDigit(p)).[Select](Function(p) Encrypt(p, a, b)).ToList()

        Dim sb = New StringBuilder()

        For i = 0 To source.Count - 1
            If i > 0 AndAlso i Mod 5 = 0 Then
                sb.Append(" "c)
            End If

            sb.Append(source(i))
        Next

        Return sb.ToString()
    End Function

    Public Function Decode(ByVal cipheredText As String, ByVal a As Integer, ByVal b As Integer) As String
        Dim inv = FindInverse(a, m)

        Dim source = cipheredText.Where(Function(p) Char.IsLetterOrDigit(p)).[Select](Function(p) Decrypt(p, inv, b)).ToList()

        Dim sb = New StringBuilder()

        For i = 0 To source.Count - 1
            sb.Append(source(i))
        Next

        Return sb.ToString()
    End Function

    Private Function Decrypt(ByVal c As Char, ByVal a As Integer, ByVal b As Integer) As Char
        If Not Char.IsLetter(c) Then
            Return c
        End If

        If Char.IsUpper(c) Then
            c = Char.ToLower(c)
        End If


        Dim x As Integer = c - 97
        Dim [mod] = (x - b) * a Mod m

        If [mod] < 0 Then
            [mod] = [mod] + m
        End If

        Return Microsoft.VisualBasic.ChrW([mod] + 97)
    End Function

    Private Function Encrypt(ByVal c As Char, ByVal a As Integer, ByVal b As Integer) As Char
        If Not Char.IsLetter(c) Then
            Return c
        End If

        If Char.IsUpper(c) Then
            c = Char.ToLower(c)
        End If


        Dim x As Integer = c - 97
        Dim [mod] = (a * x + b) Mod m

        If [mod] < 0 Then
            [mod] = [mod] + m
        End If

        Return Microsoft.VisualBasic.ChrW([mod] + 97)
    End Function

    Private Function FindInverse(ByVal a As Integer, ByVal b As Integer) As Integer
        Dim x0 = 1
        Dim x1 = 0
        Dim y0 = 0
        Dim y1 = 1

        While a <> 0
            Dim q = b / a
            Dim tmp = b Mod a
            b = a
            a = tmp
            tmp = x0 - q * x1
            x0 = x1
            x1 = tmp
            tmp = y0 - q * y1
            y0 = y1
            y1 = tmp
        End While

        If b > 1 Then
            Throw New ArgumentException("a and m must be coprime.")
        End If

        Return y0
    End Function
End Module
