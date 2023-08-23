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

        /// <summary>
        /// This method calculates the y value for a given x in the function.
        /// </summary>
        /// <param name="angle"> The base angle of the function. </param>
        /// <returns> The result when substituting x with the given value in the function. The y value for any given x value. </returns>
        public override double CalculateItsOwnValue(double angle)
        {
            return this.ConstantMultiplier * Math.Cos(angle * this.DegreeMultiplier);
        }


        /// <summary>
        /// This method returns the derivate of the cosinus function.
        /// </summary>
        /// <returns> The derivate of the function of the cosinus as a new sinus function.</returns>
        public override FunctionParts GetDerivativeOfFunction()
        {
            return new SineFunction(this.ConstantMultiplier * -1 * this.DegreeMultiplier, this.DegreeMultiplier);
        }

        /// <summary>
        /// Returns the mathematical symbol for the cosine function.
        /// </summary>
        /// <returns> The string containing the name of the function in mathematical writing.</returns>
        public override string GetFunctionCalling()
        {
            return "cos";
        }
    }
}