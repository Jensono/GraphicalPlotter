namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;

    public class GraphicalFunction
    {
        private string functionDisplayName;

        // is a list than can hold a multitute of polynomial components eg.: 5x^3,2x^1,5, | that can then be used to struture a polynomial. Can also hold Trigonometric functions but then the list is only 1 long.

        // if a user can not just input a string then this will have to be generated when initzializing the class.
        // if you want to add a contant to any of the functions or the trig ones you need to add a polynom of order 0

        private List<FunctionParts> functionComponents = new List<FunctionParts>();

        private Color functionColor;

        private bool visibility;

        public GraphicalFunction(List<FunctionParts> functionParts, Color functionColor)
        {
            this.FunctionComponents = functionParts;
            this.FunctionColor = functionColor;
            this.FunctionDisplayName = this.CreateFunctionFullName();
            this.Visibility = true;
        }

        public string FunctionDisplayName
        {
            get
            {
                return this.functionDisplayName;
            }
            set
            {
                this.functionDisplayName = value;
            }
        }

        public List<FunctionParts> FunctionComponents
        {
            get
            {
                return this.functionComponents;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.FunctionComponents)} can not be null.");
                }
                this.functionComponents = value;
            }
        }

        public Color FunctionColor
        {
            get
            {
                return this.functionColor;
            }
            set
            {
                this.functionColor = value;
            }
        }

        public bool Visibility
        {
            get
            {
                return this.visibility;
            }
            set
            {
                this.visibility = value;
            }
        }

        public double CalculateSumOfAllPartsForValue(double value)
        {
            double sum = 0;
            foreach (FunctionParts part in this.FunctionComponents)
            {
                sum += part.CalculateItsOwnValue(value);
            }
            return sum;
        }

        public string CreateFunctionFullName()
        {
            string returnstring = string.Empty;
            foreach (FunctionParts function in this.FunctionComponents)
            {
                returnstring += function.GetFunctionName();
            }
            return returnstring;
        }

        // i dont know if it makes more sense that a function can compute itself or that it is cumputed by a diffrent part of the system. For now it calculates itself.
    }
}