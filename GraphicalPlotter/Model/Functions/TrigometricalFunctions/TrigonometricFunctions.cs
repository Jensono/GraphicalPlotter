using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalPlotter
{
    public abstract class TrigonometricFunctions : FunctionParts
    {
        public int DegreeMultilplier { get; set; }
        public TrigonometricFunctions(int constantMultiplier, int degreeMultiplier) : base(constantMultiplier)
        {

            this.DegreeMultilplier = degreeMultiplier;

        }


    }
}

