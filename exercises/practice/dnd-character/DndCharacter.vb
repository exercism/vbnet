Imports System

Public Class DndCharacter
    Public ReadOnly Property StrengthProp As Integer
    Public ReadOnly Property DexterityProp As Integer
    Public ReadOnly Property ConstitutionProp As Integer
    Public ReadOnly Property IntelligenceProp As Integer
    Public ReadOnly Property WisdomProp As Integer
    Public ReadOnly Property CharismaProp As Integer
    Public ReadOnly Property HitpointsProp As Integer

    Public Shared Function Modifier(ByVal score As Integer) As Integer
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Shared Function Ability() As Integer
        Throw New NotImplementedException("You need to implement this function.")
    End Function

    Public Shared Function Generate() As DndCharacter
        Throw New NotImplementedException("You need to implement this function.")
    End Function
End Class
