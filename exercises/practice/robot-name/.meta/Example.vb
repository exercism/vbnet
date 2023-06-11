Imports System
Imports System.Collections.Generic

Public Class Robot

    Private _NameProp As String
    Private Shared ReadOnly Random As Random = New Random()
    Private Shared ReadOnly names As HashSet(Of String) = New HashSet(Of String)()

    Public Property NameProp As String
        Get
            Return _NameProp
        End Get
        Private Set(ByVal value As String)
            _NameProp = value
        End Set
    End Property

    Public Sub New()
        Reset()
    End Sub

    Private Shared Function GenerateName() As String
        Dim name As String
        Do
            name = GetRandomCharacter() & GetRandomCharacter() & Random.Next(1000).ToString("000")
        Loop While names.Contains(name)

        names.Add(name)
        Return name
    End Function

    Private Shared Function GetRandomCharacter() As String
        Return Microsoft.VisualBasic.ChrW("A"c + Random.Next(CInt(26))).ToString()
    End Function

    Public Sub ResetMethod()
        Name = GenerateName()
    End Sub
End Class
