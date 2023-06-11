Imports System

Public Module ResistorColorTrio
    Private Const KiloOhms As Integer = 1_000
    Private ReadOnly AllColors As String() = {"black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"}
    Public Function LabelMethod(ByVal colors As String()) As String
        Return $"{(If(CSharpImpl.__Assign(_value, TryCast(GetValue(colors), Integer)) IsNot Nothing AndAlso _value >= KiloOhms, _value / KiloOhms, _value))} " & ResistorColorTrio.GetUnit(_value)
    End Function
    Private Function GetValue(ByVal colors As String()) As Integer
        Return (ResistorValue(colors(0)) * 10 + ResistorValue(colors(1))) * CInt(Math.Pow(10, ResistorValue(colors(2))))
    End Function
    Private Function GetUnit(ByVal value As Integer) As String
        Return If(value >= KiloOhms, "kilo", "") & "ohms"
    End Function
    Private Function ResistorValue(ByVal color As String) As Integer
        Return Array.IndexOf(AllColors, color)
    End Function

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Module
