//-----------------------------------------------------------------------
// <copyright file="CosineFunction.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used to represent a mathematical cosine function.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;

    /// <summary>
    /// This class defines a mathematical cosine function.
    /// </summary>
    public class CosineFunction : TrigonometricFunctions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CosineFunction" /> class.
        /// </summary>
        /// <param name="constantMultiplier"> The constant multiplier for the cosine function.</param>
        /// <param name="degreeMultiplier"> The multiplier inside the brackets for the cosine function.</param>
        public CosineFunction(double constantMultiplier, double degreeMultiplier) : base(constantMultiplier, degreeMultiplier)
        {
        }

        public override double CalculateItsOwnValue(double angle)
        {
            return this.ConstantMultiplier * Math.Cos(angle * this.DegreeMultiplier);
        }

        public override string GetFunctionCalling()
        {
            return "cos";
        }
    }
}