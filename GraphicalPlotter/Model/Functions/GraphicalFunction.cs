using System.Collections.Generic;
using System.Windows.Media;

namespace GraphicalPlotter
{
    public class GraphicalFunction
    {
        public string FunctionDisplayName { get; set; }

        // is a list than can hold a multitute of polynomial components eg.: 5x^3,2x^1,5, | that can then be used to struture a polynomial. Can also hold Trigonometric functions but then the list is only 1 long.
        public List<FunctionParts> FunctionComponentns { get; set; }

        // if a user can not just input a string then this will have to be generated when initzializing the class.
        // if you want to add a contant to any of the functions or the trig ones you need to add a polynom of order 0

        public Color FunctionColor { get; set; }

        public bool Visibility { get; set; }

        public GraphicalFunction(List<FunctionParts> functionParts, Color functionColor)
        {
            this.FunctionComponentns = functionParts;
            this.FunctionColor = functionColor;
            this.FunctionDisplayName = this.CreateFunctionFullName();
            this.Visibility = true;
        }

        public double CalculateSumOfAllPartsForValue(double value)
        {
            double sum = 0;
            foreach (FunctionParts part in this.FunctionComponentns)
            {
                sum += part.CalculateItsOwnValue(value);
            }
            return sum;
        }

        public string CreateFunctionFullName()
        {
            string returnstring = string.Empty;
            foreach (FunctionParts function in this.FunctionComponentns)
            {
                returnstring += function.GetFunctionName();
            }
            return returnstring;
        }

        // i dont know if it makes more sense that a function can compute itself or that it is cumputed by a diffrent part of the system. For now it calculates itself.
    }
}