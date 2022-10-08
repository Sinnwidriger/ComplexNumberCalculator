namespace ComplexNumberCalculator
{
    public class ComplexNumber
    {
        public ComplexNumber(double realPart, double imaginaryPart)
        {
            this.RealPart = realPart;
            this.ImaginaryPart = imaginaryPart;
        }

        public double RealPart { get; set; }
        public double ImaginaryPart { get; set; }

        public ComplexNumber Add(ComplexNumber rhs)
        {
            return new ComplexNumber(this.RealPart + rhs.RealPart, this.ImaginaryPart + rhs.ImaginaryPart);
        }

        public ComplexNumber Minus(ComplexNumber rhs)
        {
            return new ComplexNumber(this.RealPart - rhs.RealPart, this.ImaginaryPart - rhs.ImaginaryPart);
        }

        public ComplexNumber Multiply(ComplexNumber rhs)
        {
            return new ComplexNumber(
                this.RealPart * rhs.RealPart - this.ImaginaryPart * rhs.ImaginaryPart,  // Real Part = ac - bd
                this.RealPart * rhs.ImaginaryPart + this.ImaginaryPart * rhs.RealPart); // Imaginary Part = ad + bc
        }

        public ComplexNumber Divide(ComplexNumber rhs)
        {
            double realPart =
                (this.RealPart * rhs.RealPart - this.ImaginaryPart * rhs.ImaginaryPart) /
                (rhs.RealPart * rhs.RealPart + rhs.ImaginaryPart * rhs.ImaginaryPart); // Real Part = (ac + bd) / (c^2 + d^2)
            double imaginaryPart =
                (this.ImaginaryPart * rhs.RealPart - this.RealPart * rhs.ImaginaryPart) /
                (rhs.RealPart * rhs.RealPart + rhs.ImaginaryPart * rhs.ImaginaryPart); // Imaginary Part = (bc - ad) / (c^2 + d^2)

            return new ComplexNumber(realPart, imaginaryPart);
        }

        public override string ToString()
        {
            return $"{this.RealPart} + {this.ImaginaryPart}i";
        }
    }
}