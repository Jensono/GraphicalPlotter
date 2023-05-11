using System;

namespace GraphicalPlotter
{
    public class CosineFunction : TrigonometricFunctions
    {
        public CosineFunction(double constantMultiplier, double degreeMultiplier) : base(constantMultiplier, degreeMultiplier)
        {
        }

        public override double CalculateItsOwnValue(double angle)
        {
            return this.ConstantMulitplier * Math.Cos(angle * this.DegreeMultilplier);
        }

        public override string GetFunctionCalling()
        {
            return "cos";
        }
    }
}