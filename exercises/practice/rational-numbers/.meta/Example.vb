Imports System.Runtime.CompilerServices

''' Cannot convert RecordDeclarationSyntax, CONVERSION ERROR: Conversion for RecordDeclaration not implemented, please report this issue in 'public record RationalNumbe...' at character 0
''' 
''' 
''' Input:
''' public record RationalNumberType(int Numerator, int Denominator)
{
    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator).Reduce();

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator).Reduce();

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator).Reduce();

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(r1.Numerator * r2.Denominator, r2.Numerator * r1.Denominator).Reduce();

    public RationalNumber Abs() => new RationalNumber((System.Int32)(System.Math.Abs((System.Int32)(this.Numerator))), (System.Int32)(System.Math.Abs((System.Int32)(this.Denominator)))).Reduce();

    public RationalNumber Reduce()
    {
        var divisor = Math.Gcd(System.Math.Abs(this.Numerator), System.Math.Abs(this.Denominator));
        return this.Denominator >= 0
            ? new RationalNumber(this.Numerator / divisor, this.Denominator / divisor)
            : new RationalNumber(this.Numerator * -1 / divisor, this.Denominator * -1 / divisor);
    }
    public RationalNumber Exprational(int power) =>
        power >= 0
            ? new RationalNumber((System.Int32)((int)System.Math.Pow((System.Double)(this.Numerator), (System.Double)(power))), (System.Int32)((int)System.Math.Pow((System.Double)(this.Denominator), (System.Double)(power)))).Reduce()
            : new RationalNumber((System.Int32)((int)System.Math.Pow((System.Double)(this.Denominator), (System.Double)(System.Math.Abs((System.Int32)(power))))), (System.Int32)((int)System.Math.Pow((System.Double)(this.Numerator), (System.Double)(System.Math.Abs((System.Int32)(power)))))).Reduce();

    public double Expreal(int baseNumber) => Math.NthRoot(System.Math.Pow(baseNumber, this.Numerator), this.Denominator, 1e-9);
}

''' 

Public Module IntExtensions
    <Extension()>
    Public Function Expreal(ByVal realNumber As Integer, ByVal r As RationalNumber) As Double
        Return r.Expreal(realNumber)
    End Function
End Module

Public Module Math
    Public Function Gcd(ByVal x As Integer, ByVal y As Integer) As Integer
        Return If(y = 0, x, Gcd(y, x Mod y))
    End Function

    Public Function NthRoot(ByVal A As Double, ByVal n As Double, ByVal p As Double) As Double
        Dim x = New Double(1) {}
        x(0) = A
        x(1) = A / n
        While System.Math.Abs(x(0) - x(1)) > p
            x(1) = x(0)
            x(0) = 1 / n * ((n - 1) * x(1) + A / System.Math.Pow(x(1), n - 1))
        End While
        Return x(0)
    End Function
End Module
