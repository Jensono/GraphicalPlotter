using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalPlotter

{
    /// <summary>
    /// Is the parent class to all other function classes, uses a constant multiplier to multiply whatever came before eg. with a multiplies of 3 a cos(x) functions looks like this: 3*cos(x).
    /// </summary>
    public abstract class FunctionParts
    {
        public double ConstantMulitplier { get; set; }

        // right now the multiplier can also be null
        public FunctionParts(long constantMultiplier)
        {
            this.ConstantMulitplier = constantMultiplier;
        }

        public abstract double CalculateItsOwnValue(double x);

        public abstract string GetFunctionName();
    }
}

