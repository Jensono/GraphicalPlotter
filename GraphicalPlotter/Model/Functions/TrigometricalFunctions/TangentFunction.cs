using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalPlotter
{
    public class TangentFunction : TrigonometricFunctions
    {

        public TangentFunction(int constantMultiplier, int degreeMultiplier) : base(constantMultiplier, degreeMultiplier) { }
        public override double CalculateItsOwnValue(double angle)
        {
            return this.ConstantMulitplier * Math.Tan(angle * this.DegreeMultilplier);
        }
    }
}

