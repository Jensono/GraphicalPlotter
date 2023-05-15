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
    public class TangentFunction : TrigonometricFunctions
    {
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