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
    public class CosineFunction : TrigonometricFunctions
    {
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