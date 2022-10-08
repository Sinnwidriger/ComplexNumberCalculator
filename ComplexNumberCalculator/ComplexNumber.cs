namespace ComplexNumberCalculator
{
    public class ComplexNumber
    {
        #region Constructor

        public ComplexNumber(double realPart, double imaginaryPart)
        {
            this.RealPart = realPart;
            this.ImaginaryPart = imaginaryPart;
        }

        #endregion Constructor

        #region Properties

        public double RealPart { get; set; }
        public double ImaginaryPart { get; set; }

        #endregion Properties

        #region Extension Methods

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

        #endregion Extension Methods

        #region Static Methods

        public static ComplexNumber Add(ComplexNumber lhs, ComplexNumber rhs)
        {
            return lhs.Add(rhs);
        }

        public static ComplexNumber Minus(ComplexNumber lhs, ComplexNumber rhs)
        {
            return lhs.Minus(rhs);
        }

        public static ComplexNumber Multiply(ComplexNumber lhs, ComplexNumber rhs)
        {
            return lhs.Multiply(rhs);
        }

        public static ComplexNumber Divide(ComplexNumber lhs, ComplexNumber rhs)
        {
            return lhs.Divide(rhs);
        }

        #endregion Static Methods

        #region Overloaded Operators

        public static ComplexNumber operator +(ComplexNumber lhs, ComplexNumber rhs)
        {
            return lhs.Add(rhs);
        }

        public static ComplexNumber operator -(ComplexNumber lhs, ComplexNumber rhs)
        {
            return lhs.Minus(rhs);
        }

        public static ComplexNumber operator *(ComplexNumber lhs, ComplexNumber rhs)
        {
            return lhs.Multiply(rhs);
        }

        public static ComplexNumber operator /(ComplexNumber lhs, ComplexNumber rhs)
        {
            return lhs.Divide(rhs);
        }

        #endregion Overloaded Operators

        #region Overriden Methods

        public override string ToString()
        {
            return $"{this.RealPart} + {this.ImaginaryPart}i";
        }

        #endregion Overriden Methods
    }
}