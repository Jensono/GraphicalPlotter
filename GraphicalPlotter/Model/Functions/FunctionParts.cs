namespace GraphicalPlotter

{
    /// <summary>
    /// Is the parent class to all other function classes, uses a constant multiplier to multiply whatever came before eg. with a multiplies of 3 a cos(x) functions looks like this: 3*cos(x).
    /// </summary>
    public abstract class FunctionParts
    {
        private double constantMultiplier;

        // right now the multiplier can also be null
        public FunctionParts(double constantMultiplier)
        {
            this.ConstantMultiplier = constantMultiplier;
        }

        public double ConstantMultiplier
        {
            get
            {
                return constantMultiplier;
            }
            set
            {
                constantMultiplier = value;
            }
        }

        public abstract double CalculateItsOwnValue(double x);

        public abstract string GetFunctionName();
    }
}