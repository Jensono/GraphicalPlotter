using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalPlotter
{
    public class SineFunction : TrigonometricFunctions
    {

        public SineFunction(double constantMultiplier, double degreeMultiplier) : base(constantMultiplier, degreeMultiplier) { }
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

