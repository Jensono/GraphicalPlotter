//-----------------------------------------------------------------------
// <copyright file="TangentDerivative.cs" company="FHWN">
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
    /// This class defines a mathematical Tangent Derivative function.
    /// </summary>
    public class TangentDerivative : TrigonometricFunctions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TangentDerivative" /> class. This represents 1/cos^2.
        /// </summary>
        /// <param name="constantMultiplier"> The constant multiplier for the tan function.</param>
        /// <param name="degreeMultiplier"> The multiplier inside the brackets for the tan function.</param>
        public TangentDerivative(double constantMultiplier, double degreeMultiplier) : base(constantMultiplier, degreeMultiplier)
        {
        }

        /// <summary>
        /// This method calculates the y value for a given x in the function.
        /// </summary>
        /// <param name="angle"> The base angle of the function. </param>
        /// <returns> The result when substituting x with the given value in the function. The y value for any given x value. </returns>
        public override double CalculateItsOwnValue(double angle)
        {
            return this.ConstantMultiplier / (Math.Cos(this.DegreeMultiplier * angle) * Math.Cos(this.DegreeMultiplier * angle));
        }

        /// <summary>
        /// This method returns the derivate of the tangent derivate.
        /// </summary>
        /// <returns> A new tangent derivate derivate object, with which one calculate the derivate of the tangent derivate.</returns>
        public override FunctionParts GetDerivativeOfFunction()
        {
            return new TangentDerivateDerivate(2 * this.DegreeMultiplier * this.ConstantMultiplier, this.DegreeMultiplier);
        }

        // please dont use this right now it will fail to save the function in its whole

        /// <summary>
        /// Returns the mathematical symbol for the tangent function.
        /// </summary>
        /// <returns> The string containing the name of the function in mathematical writing.</returns>
        public override string GetFunctionCalling()
        {
            return "x/cos^2";
        }
    }
}