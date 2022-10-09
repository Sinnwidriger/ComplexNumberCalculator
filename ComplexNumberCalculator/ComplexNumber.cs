using System.Runtime.InteropServices;

namespace ComplexNumberCalculator
{
    public class ComplexNumber
    {
        #region Constructor

        public ComplexNumber(double realPart, double imaginaryPart)
        {
            _realPart = realPart;
            _imaginaryPart = imaginaryPart;
            recalculateRadius();
            recalculateTheta();
        }

        public ComplexNumber(ComplexNumber copy)
        {
            this._realPart = copy._realPart;
            this._imaginaryPart = copy._imaginaryPart;
            this._radius = copy._radius;
            this._theta = copy._theta;
        }

        public ComplexNumber(string input)
        {
            try
            {
                Tuple<double, double> numberPair = parseComplexNumber(input);
                _realPart = numberPair.Item1;
                _imaginaryPart = numberPair.Item2;
                recalculateRadius();
                recalculateTheta();
            }
            catch
            {
                Console.WriteLine($"Number \"{input}\" cannot be parsed");
                Environment.Exit(0);
            }
        }

        #endregion Constructor

        #region Properties

        public static int Precision { get; set; } = 2;

        private double _realPart;

        public double RealPart
        {
            get
            {
                return _realPart;
            }
            set
            {
                _realPart = value;
                recalculateRadius();
                recalculateTheta();
            }
        }

        private double _imaginaryPart;

        public double ImaginaryPart
        {
            get
            {
                return _imaginaryPart;
            }
            set
            {
                _imaginaryPart = value;
                recalculateRadius();
                recalculateTheta();
            }
        }

        private double _radius;

        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
                recalculateRealAndImaginaryPart();
            }
        }

        private double _theta;

        public double Theta
        {
            get
            {
                return _theta;
            }
            set
            {
                _theta = value;
                recalculateRealAndImaginaryPart();
            }
        }

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
                (rhs.RealPart * rhs.RealPart + rhs.ImaginaryPart * rhs.ImaginaryPart);     // Real Part = (ac + bd) / (c^2 + d^2)
            double imaginaryPart =
                (this.ImaginaryPart * rhs.RealPart - this.RealPart * rhs.ImaginaryPart) /
                (rhs.RealPart * rhs.RealPart + rhs.ImaginaryPart * rhs.ImaginaryPart);     // Imaginary Part = (bc - ad) / (c^2 + d^2)

            return new ComplexNumber(realPart, imaginaryPart);
        }

        public ComplexNumber Pow(int n)
        {
            ComplexNumber cn = new ComplexNumber(this);
            cn.Radius = Math.Pow(cn.Radius, n);
            cn.Theta *= n;
            return cn;
        }

        public ComplexNumber Sqrt(int n)
        {
            ComplexNumber cn = new ComplexNumber(this);
            cn.Radius = Math.Pow(cn.Radius, 1.0 / n);
            cn.Theta /= n;
            return cn;
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

        public static ComplexNumber Pow(ComplexNumber lhs, int n)
        {
            return lhs.Pow(n);
        }

        public static ComplexNumber Sqrt(ComplexNumber lhs, int n)
        {
            return lhs.Sqrt(n);
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

        public static ComplexNumber operator ^(ComplexNumber lhs, double n)
        {
            if (n > 1)
                return lhs.Pow((int)n);
            else
                return lhs.Sqrt((int)(1 / n));
        }

        #endregion Overloaded Operators

        #region Overriden Methods

        public override string ToString()
        {
            string op = this.ImaginaryPart >= 0 ? "+" : "";

            return string.Format(
                $"{{0:F{Precision}}}{op}{{1:F{Precision}}}i",
                this.RealPart,
                this.ImaginaryPart
            );
        }

        #endregion Overriden Methods

        #region Private Methods

        private Tuple<double, double> parseComplexNumber(string input)
        {
            input = input.Replace(' ', '\0'); // Remove spaces for proper work
            input = input.Replace('i', '\0');
            int sign = input.Contains('-') ? -1 : 1;

            char[] separators = new char[] { '+', '-' };
            string[] splited = input.Split(separators, 2, StringSplitOptions.RemoveEmptyEntries);

            return new Tuple<double, double>(Double.Parse(splited[0]), sign * Double.Parse(splited[1]));
        }

        private void recalculateRadius()
        {
            _radius = Math.Sqrt(RealPart * RealPart + ImaginaryPart * ImaginaryPart);
        }

        private void recalculateTheta()
        {
            _theta = Math.Atan(ImaginaryPart / RealPart);
        }

        private void recalculateRealAndImaginaryPart()
        {
            _realPart = Math.Sqrt(                  // new Radius and old Theta
                (Radius * Radius) /                 // a = ( r^2 / (1 + tg(Theta)^2) )^1/2
                (1 + Math.Pow(Math.Tan(Theta), 2))  //
            );

            _imaginaryPart = RealPart * Math.Tan(Theta); // b = a * tg(Theta)
        }

        #endregion Private Methods
    }
}