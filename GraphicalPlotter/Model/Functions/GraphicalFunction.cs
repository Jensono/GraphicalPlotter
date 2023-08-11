//-----------------------------------------------------------------------
// <copyright file="GraphicalFunction.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used to represent a mathematical function made of multiple smaller FunctionParts.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;

    /// <summary>
    /// This class is used to describe a Mathematical function, with extra attributes like a name and a color.
    /// </summary>
    public class GraphicalFunction
    {
        /// <summary>
        /// The field for display name of the function as a string.
        /// </summary>
        private string functionDisplayName;

        //// is a list than can hold a multitute of polynomial components eg.: 5x^3,2x^1,5, | that can then be used to struture a polynomial. Can also hold Trigonometric functions but then the list is only 1 long.

        ////  if a user can not just input a string then this will have to be generated when initzializing the class.
        //// if you want to add a contant to any of the functions or the trig ones you need to add a polynom of order 0

        /// <summary>
        /// The field for the collection of function components for this graphical function.
        /// </summary>
        private List<FunctionParts> functionComponents = new List<FunctionParts>();

        /// <summary>
        /// The field for the color of the Graphical function.
        /// </summary>
        private Color functionColor;

        /// <summary>
        /// The field for the visibility of the function.
        /// </summary>
        private bool visibility;
        private int brushwidth;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicalFunction" /> class.
        /// </summary>
        /// <param name="functionParts"> The list of function parts that make up the whole of this Graphical Function.</param>
        /// <param name="functionColor"> The color for the function.</param>
        public GraphicalFunction(List<FunctionParts> functionParts, Color functionColor, int standartBrushWidth)
        {
            this.FunctionComponents = functionParts;
            this.FunctionColor = functionColor;
            this.FunctionDisplayName = this.CreateFunctionFullName();
            this.Visibility = true;
            this.BrushWidth = standartBrushWidth;
        }

        /// <summary>
        /// Gets or sets the display name of the function as a string.
        /// </summary>
        /// <value> The display name of the function as a string.</value>
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

        /// <summary>
        /// Gets or sets the collection of function components for this graphical function.
        /// </summary>
        /// <value> The collection of function components for this graphical function.</value>
        /// <example> <see cref="ArgumentNullException"/> is thrown if the given value was null. </example>
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

        /// <summary>
        /// Gets or sets the color of the function.
        /// </summary>
        /// <value> The  color of the function.</value>
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

        public int BrushWidth 
        {
            get
            {
                return this.brushwidth;
            }

            set
            {
                if (value>0 && value<100)
                {
                    this.brushwidth = value;
                }
                
            }

        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the the function is visible.
        /// </summary>
        /// <value> The visibility of the function.</value>
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

        /// <summary>
        /// This method calculates the sum of the resulting y value for all parts of the function.
        /// </summary>
        /// <param name="value"> The x value the functions should be set for.</param>
        /// <returns> The sum of the functions parts as a double.</returns>
        public double CalculateSumOfAllPartsForValue(double value)
        {
            double sum = 0;
            foreach (FunctionParts part in this.FunctionComponents)
            {
                sum += part.CalculateItsOwnValue(value);
            }

            return sum;
        }

        /// <summary>
        /// This method creates a full mathematical string for all function parts.
        /// </summary>
        /// <returns> The string with the mathematical writing for the function.</returns>
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