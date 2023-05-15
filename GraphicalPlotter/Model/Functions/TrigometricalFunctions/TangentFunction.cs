

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