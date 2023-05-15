using System;

namespace GraphicalPlotter
{
    public class SineFunction : TrigonometricFunctions
    {
        public SineFunction(double constantMultiplier, double degreeMultiplier) : base(constantMultiplier, degreeMultiplier)
        {
        }

        public override double CalculateItsOwnValue(double angle)
        {
            return this.ConstantMulitplier * Math.Sin(angle * this.DegreeMultilplier);
        }

        public override string GetFunctionCalling()
        {
            return "sin";
        }
    }
}