using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalPlotter
{
    public class SineFunction : TrigonometricFunctions
    {

        public SineFunction(int constantMultiplier, int degreeMultiplier) : base(constantMultiplier, degreeMultiplier) { }
        public override double CalculateItsOwnValue(double angle)
        {

            return this.ConstantMulitplier * Math.Sin(angle * this.DegreeMultilplier);
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


            returnstring += $"{this.ConstantMulitplier}*sin";
            if (DegreeMultilplier == 0)
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

