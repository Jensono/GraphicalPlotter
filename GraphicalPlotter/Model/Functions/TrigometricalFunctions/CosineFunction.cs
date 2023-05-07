using System;

namespace GraphicalPlotter
{
    public class CosineFunction : TrigonometricFunctions
    {
        public CosineFunction(int constantMultiplier, int degreeMultiplier) : base(constantMultiplier, degreeMultiplier)
        {
        }

        public override double CalculateItsOwnValue(double angle)
        {
            return this.ConstantMulitplier * Math.Cos(angle * this.DegreeMultilplier);
        }
    }
}
