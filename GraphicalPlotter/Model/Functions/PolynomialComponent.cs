using System;

namespace GraphicalPlotter
{
    public class PolynomialComponent : FunctionParts
    {
        // The degree for the exponent for x,eg. 2 would create x^2.
        public int exponentDegree;
        public int ExponentDegree
        {
            get
            {
                return this.exponentDegree;
            }
            set
            {
                // can this handle negativ exponents? x^-2 Maybe later used for diffrentiation..

                this.exponentDegree = value;

            }
        }

        public PolynomialComponent(int exponentenDegree, long constantMultiplier) : base(constantMultiplier)
        {
            this.ExponentDegree = exponentenDegree;
        }

        // can this handle negativ exponents? x^-2 Maybe later used for diffrentiation. I hope x^0 works and just procudes 1.
        public override double CalculateItsOwnValue(double baseValue)
        {
            return this.ConstantMulitplier * Math.Pow(baseValue, this.ExponentDegree);
        }
    }
}
