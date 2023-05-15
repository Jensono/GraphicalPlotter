

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