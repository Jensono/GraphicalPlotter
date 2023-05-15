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
    public class SineFunction : TrigonometricFunctions
    {
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