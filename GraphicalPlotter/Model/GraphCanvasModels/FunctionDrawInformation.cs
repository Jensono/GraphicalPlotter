//-----------------------------------------------------------------------
// <copyright file="FunctionDrawInformation.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class contains all the information that is needed to draw it onto a canvas (in wpf).
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;

    /// <summary>
    /// This class acts as a collection of attributes that can be used to draw a function inside a pixel canvas.
    /// </summary>
    public class FunctionDrawInformation
    {
        /// <summary>
        /// The field for the List of canvas Pixel that indicate how to draw the function.
        /// </summary>
        private List<CanvasPixel> canvasPixels;

        /// <summary>
        /// The field for the Color of the function.
        /// </summary>
        private Color functionColor;

        /// <summary>
        /// The field for the brush width of the function.
        /// </summary>
        private int brushWidth;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionDrawInformation" /> class.
        /// </summary>
        /// <param name="canvasPixels"> The list of canvas pixels for the draw information.</param>
        /// <param name="functionColor"> The color in which the function should be drawn.</param>
        /// <param name="brushWidth"> The brush width for the function.</param>
        public FunctionDrawInformation(List<CanvasPixel> canvasPixels, Color functionColor, int brushWidth)
        {
            this.FunctionColor = functionColor;
            this.CanvasPixels = canvasPixels;
            this.BrushWidth = brushWidth;
        }

        /// <summary>
        /// Gets or sets the color for the FunctionDrawInformation.
        /// </summary>
        /// <value> The color for the FunctionDrawInformation.</value>
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

        /// <summary>
        /// Gets or sets the list that was generated for the canvas pixel that make up this function.
        /// </summary>
        /// <value> The list that was generated for the canvas pixel that make up this function.</value>
        /// <example> <see cref="ArgumentNullException"/> is thrown if the given value was null. </example>
        public List<CanvasPixel> CanvasPixels
        {
            get
            {
                return this.canvasPixels;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.CanvasPixels)} can not be null!");
                }

                this.canvasPixels = value;
            }
        }

        public int BrushWidth
        {
            get
            {
                return this.brushWidth;
            }

            set
            {
                if (value > 0 && value < 100)
                {
                    this.brushWidth = value;
                }
               
            }
        }
    }
}