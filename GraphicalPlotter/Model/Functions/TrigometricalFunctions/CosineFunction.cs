

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