//-----------------------------------------------------------------------
// <copyright file="TangentFunction.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used to represent a tangent function.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;

    /// <summary>
    /// This class defines a mathematical tangent function.
    /// </summary>
    public class TangentFunction : TrigonometricFunctions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TangentFunction" /> class.
        /// </summary>
        /// <param name="constantMultiplier"> The constant multiplier for the tan function.</param>
        /// <param name="degreeMultiplier"> The multiplier inside the brackets for the tan function.</param>
        public TangentFunction(double constantMultiplier, double degreeMultiplier) : base(constantMultiplier, degreeMultiplier)
        {
        }

        public override double CalculateItsOwnValue(double angle)
        {
            return this.ConstantMultiplier * Math.Tan(angle * this.DegreeMultiplier);
        }

        public override string GetFunctionCalling()
        {
            return "tan";
        }
    }
}