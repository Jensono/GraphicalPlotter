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

        /// <summary>
        /// This method calculates the y value for a given x in the function.
        /// </summary>
        /// <param name="angle"> The base angle of the function. </param>
        /// <returns> The result when substituting x with the given value in the function. The y value for any given x value. </returns>
        public override double CalculateItsOwnValue(double angle)
        {
            return this.ConstantMultiplier * Math.Sin(angle * this.DegreeMultiplier);
        }

        /// <summary>
        /// This method returns the derivate of the sinus function.
        /// </summary>
        /// <returns> The derivate of the function of the sinus as a new cosine function.</returns>
        public override FunctionParts GetDerivativeOfFunction()
        {
            return new CosineFunction(this.ConstantMultiplier * this.DegreeMultiplier, this.DegreeMultiplier);
        }

        /// <summary>
        /// Returns the mathematical symbol for the sine function.
        /// </summary>
        /// <returns> The string containing the name of the function in mathematical writing.</returns>
        public override string GetFunctionCalling()
        {
            return "sin";
        }
    }
}