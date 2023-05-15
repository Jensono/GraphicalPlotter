//-----------------------------------------------------------------------
// <copyright file="TrigonometricFunctions.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is the parent class for all the fundamental trigonometric functions.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    public abstract class TrigonometricFunctions : FunctionParts
    {
        /// <summary>
        /// The field for the degree multiplier of the the trigometric function.
        /// </summary>
        private double degreeMultiplier;
      

        public TrigonometricFunctions(double constantMultiplier, double degreeMultiplier) : base(constantMultiplier)
        {
            this.DegreeMultiplier = degreeMultiplier;
        }

        /// <summary>
        /// Gets or sets the degree multiplier for the trigonometric function.
        /// </summary>
        /// <value> The degree multiplier for the trigonometric function.</value>
        public double DegreeMultiplier
        {
            get
            {
                return this.degreeMultiplier;
            }

            set
            {
                this.degreeMultiplier = value;
            }
        }

        public override string GetFunctionName()
        {
            string returnstring = string.Empty;

            if (this.ConstantMultiplier == 0)
            {
                return "+0 ";
            }
            else if (this.ConstantMultiplier == -1)
            {
                returnstring += $"-{this.GetFunctionCalling()}*";
            }
            else if (this.ConstantMultiplier == 1)
            {
                returnstring += $"+{this.GetFunctionCalling()}";
            }
            else if (this.ConstantMultiplier > 0)
            {
                returnstring += "+" + $"{this.ConstantMultiplier}*{this.GetFunctionCalling()}";
            }
            else
            {
                returnstring += $"{this.ConstantMultiplier}*{this.GetFunctionCalling()}";
            }

            if (this.DegreeMultiplier == 0)
            {
                returnstring += "(0)";
            }
            else if (this.DegreeMultiplier == 1)
            {
                returnstring += "(x)";
            }
            else if (this.DegreeMultiplier == -1)
            {
                returnstring += "(-x)";
            }
            else
            {
                returnstring += $"({DegreeMultiplier}*x)";
            }

            return returnstring;
        }

        public abstract string GetFunctionCalling();
    }
}