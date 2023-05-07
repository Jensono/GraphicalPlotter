namespace GraphicalPlotter
{
    public abstract class TrigonometricFunctions : FunctionParts
    {
        public int DegreeMultilplier { get; set; }

        public TrigonometricFunctions(int constantMultiplier, int degreeMultiplier) : base(constantMultiplier)
        {
            this.DegreeMultilplier = degreeMultiplier;
        }

        public override string GetFunctionName()
        {
            string returnstring = string.Empty;

            if (this.ConstantMulitplier == 0)
            {
                return "+0 ";
            }

                      
            else if (this.ConstantMulitplier == -1)
            {
                returnstring += $"-{this.GetFunctionCalling()}*";
            }
            else if (this.ConstantMulitplier == 1)
            {
                returnstring += $"+{this.GetFunctionCalling()}";
            }
            else if (this.ConstantMulitplier > 0)
            {
                returnstring += "+";
            }
            else
            {
                returnstring += $"{this.ConstantMulitplier}*{this.GetFunctionCalling()}";
            }


            if (this.DegreeMultilplier == 0)
            {
                returnstring += "(0)";
            }
            else if (this.DegreeMultilplier == 1)
            {
                returnstring += "(x)";
            }
            else if (this.DegreeMultilplier == -1)
            {
                returnstring += "(-x)";
            }
            else
            {
                returnstring += $"({DegreeMultilplier}*x)";
            }

            return returnstring;
        }

        public abstract string GetFunctionCalling();
    }
}