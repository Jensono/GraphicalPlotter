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
    }
}

