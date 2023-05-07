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

        public override string GetFunctionName()
        {
            string returnstring = string.Empty;
            if (this.ConstantMulitplier > 0)
            {
                returnstring += "+";
            }
            else if (this.ConstantMulitplier == 0)
            {
                return string.Empty;
            }


            returnstring += $"{this.ConstantMulitplier}*cos";
            if (DegreeMultilplier==0)
            {
                returnstring += "(0)";
            }
            else
            {
                returnstring += $"({DegreeMultilplier}*x)";
            }

            return returnstring;
        }
    }
}