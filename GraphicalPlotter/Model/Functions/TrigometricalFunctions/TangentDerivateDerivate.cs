//-----------------------------------------------------------------------
// <copyright file="TangentFunction.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used to represent a tangent function derivative derivate, this application was constructed to actually make derivatives of function so we end up with this mess.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;

    /// <summary>
    /// This class defines a mathematical tangent function.
    /// </summary>
    public class TangentDerivateDerivate : TrigonometricFunctions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TangentFunction" /> class.
        /// </summary>
        /// <param name="constantMultiplier"> The constant multiplier for the tan function.</param>
        /// <param name="degreeMultiplier"> The multiplier inside the brackets for the tan function.</param>
        public TangentDerivateDerivate(double constantMultiplier, double degreeMultiplier) : base(constantMultiplier, degreeMultiplier)
        {
        }

        /// <summary>
        /// This method calculates the y value for a given x in the function.
        /// </summary>
        /// <param name="angle"> The base angle of the function. </param>
        /// <returns> The result when substituting x with the given value in the function. The y value for any given x value. </returns>
        public override double CalculateItsOwnValue(double angle)
        {
            return (this.ConstantMultiplier * Math.Sin(this.DegreeMultiplier * angle)) / (Math.Cos(this.DegreeMultiplier * angle) * Math.Cos(this.DegreeMultiplier * angle) * Math.Cos(this.DegreeMultiplier * angle));
        }

        public override FunctionParts GetDerivativeOfFunction()
        {
            throw new NotImplementedException("Yeah this should never happen, the application was never build on the grounds of make derivates of functions so we have this mess now.");
        }

        /// <summary>
        /// Returns the mathematical symbol for the tangent function.
        /// </summary>
        /// <returns> The string containing the name of the function in mathematical writing.</returns>
        public override string GetFunctionCalling()
        {
            return "undefined";
        }


    }
}