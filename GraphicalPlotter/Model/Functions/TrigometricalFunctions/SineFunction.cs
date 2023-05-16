//-----------------------------------------------------------------------
// <copyright file="SineFunction.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used to represent a mathematical sine function.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;

    /// <summary>
    /// This class defines a mathematical sine function.
    /// </summary>
    public class SineFunction : TrigonometricFunctions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SineFunction" /> class.
        /// </summary>
        /// <param name="constantMultiplier"> The constant multiplier for the sine function.</param>
        /// <param name="degreeMultiplier"> The multiplier inside the brackets for the sine function.</param>
        public SineFunction(double constantMultiplier, double degreeMultiplier) : base(constantMultiplier, degreeMultiplier)
        {
        }

        public override double CalculateItsOwnValue(double angle)
        {
            return this.ConstantMultiplier * Math.Sin(angle * this.DegreeMultiplier);
        }

        public override string GetFunctionCalling()
        {
            return "sin";
        }
    }
}