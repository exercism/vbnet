
''' Cannot convert RecordDeclarationSyntax, CONVERSION ERROR: Conversion for RecordDeclaration not implemented, please report this issue in 'public record ComplexNumber...' at character 15
''' 
''' 
''' Input:
''' 
public record ComplexNumber(double R, double I)
{
    public double Real() => this.R;

    public double Imaginary() => this.I;

    public ComplexNumber Mul(ComplexNumber other) =>
        new(this.R * other.R - this.I * other.I, this.I * other.R + this.R * other.I);

    public ComplexNumber Add(ComplexNumber other) =>
        new(this.R + other.R, this.I + other.I);

    public ComplexNumber Sub(ComplexNumber other) =>
        new(this.R - other.R, this.I - other.I);

    public ComplexNumber Div(ComplexNumber other)
    {
        var numerator = this.Mul(other.Conjugate());
        var denominator = other.Mul(other.Conjugate());

        return new(numerator.R / denominator.R, numerator.I / denominator.R);
    }

    public ComplexNumber Exp()  =>
        new(System.Math.Exp(this.R) * System.Math.Cos(this.I), System.Math.Exp(this.R) * System.Math.Sin(this.I));

    public ComplexNumber Conjugate() => new(this.R, -this.I);

    public double Abs() => System.Math.Sqrt(System.Math.Pow(this.R, 2) + System.Math.Pow(this.I, 2));
    
    public static implicit operator ComplexNumber(double d) => new(d, 0.0);
}

''' 