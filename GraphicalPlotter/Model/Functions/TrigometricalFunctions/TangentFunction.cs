using System;

namespace GraphicalPlotter
{
    public class TangentFunction : TrigonometricFunctions
    {
        public TangentFunction(double constantMultiplier, double degreeMultiplier) : base(constantMultiplier, degreeMultiplier)
        {
        }

        public override double CalculateItsOwnValue(double angle)
        {
            return this.ConstantMulitplier * Math.Tan(angle * this.DegreeMultilplier);
        }

        public override string GetFunctionCalling()
        {
            return "tan";
        }
    }
}