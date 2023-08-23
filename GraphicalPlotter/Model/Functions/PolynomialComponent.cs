//-----------------------------------------------------------------------
// <copyright file="PolynomialComponent.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used to represent a mathematical polynomial function.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;

    /// <summary>
    /// The class for a polynomial component. This component can look something like this : a0*x^a1 , in which the a0 and a1  can be double values for the x.
    /// </summary>
    public class PolynomialComponent : FunctionParts
    {
        //// The degree for the exponent for x,eg. 2 would create x^2.
        
        /// <summary>
        /// The field for the exponent degree of the polynomial function.
        /// </summary>
        private double exponentDegree;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialComponent" /> class.
        /// </summary>
        /// <param name="exponentenDegree"> The degree of the exponent for the x as a double.</param>
        /// <param name="constantMultiplier"> The multiplier for the x.</param>
        public PolynomialComponent(double exponentenDegree, double constantMultiplier) : base(constantMultiplier)
        {
            this.ExponentDegree = exponentenDegree;
        }

        /// <summary>
        /// Gets or sets the exponent degree for the polynomial function.
        /// </summary>
        /// <value> The exponent degree for the polynomial function.</value>
        public double ExponentDegree
        {
            get
            {
                return this.exponentDegree;
            }

            set
            {
                //// can this handle negativ exponents? x^-2 Maybe later used for diffrentiation..

                this.exponentDegree = value;
            }
        }

        //// can this handle negativ exponents? x^-2 Maybe later used for diffrentiation. I hope x^0 works and just procudes 1.

        /// <summary>
        /// This method calculates the y value for a given x in the function.
        /// </summary>
        /// <param name="baseValue"> The value for which to substitute the x. </param>
        /// <returns> The result when substituting x with the given value in the function. The y value for any given x value. </returns>
        public override double CalculateItsOwnValue(double baseValue)
        {
            return this.ConstantMultiplier * Math.Pow(baseValue, this.ExponentDegree);
        }

        public override FunctionParts GetDerivativeOfFunction()
        {
            if (this.ExponentDegree == 0)
            {
                return new PolynomialComponent(0, 0);
            }   
            
            if (this.ConstantMultiplier == 0)
            {
                return new PolynomialComponent(this.ExponentDegree - 1, this.ExponentDegree);
            }

            return new PolynomialComponent(this.ExponentDegree - 1, this.ConstantMultiplier * this.ExponentDegree);
        }

        /// <summary>
        /// This method returns a string that looks like a mathematical function for the model behind the function.
        /// </summary>
        /// <returns> The polynomials function writing as a string.</returns>
        public override string GetFunctionName()
        {
            string returnstring = string.Empty;

            if (this.ConstantMultiplier == 0)
            {
                return string.Empty;
            }
            else if (this.ConstantMultiplier == -1)
            {
                returnstring += "-";
            }
            else if (this.ConstantMultiplier == 1)
            {
                returnstring += "+";
            }
            else
            {
                if (this.ConstantMultiplier > 0)
                {
                    returnstring += "+";
                }

                returnstring += $"{this.ConstantMultiplier}";

                if (this.ExponentDegree != 0)
                {
                    returnstring += "*";
                }
            }

            if (this.ExponentDegree == 0)
            {
                returnstring += string.Empty;
            }
            else
            {
                if (this.ExponentDegree == 1)
                {
                    returnstring += "x";
                }
                else
                {
                    returnstring += $"x^{exponentDegree}";
                }
            }

            return returnstring;
        }
    }
}