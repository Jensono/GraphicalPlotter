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

    public class PolynomialComponent : FunctionParts
    {
        // The degree for the exponent for x,eg. 2 would create x^2.
        private double exponentDegree;

        public PolynomialComponent(double exponentenDegree, double constantMultiplier) : base(constantMultiplier)
        {
            this.ExponentDegree = exponentenDegree;
        }

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

        // can this handle negativ exponents? x^-2 Maybe later used for diffrentiation. I hope x^0 works and just procudes 1.
        public override double CalculateItsOwnValue(double baseValue)
        {
            return this.ConstantMultiplier * Math.Pow(baseValue, this.ExponentDegree);
        }

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