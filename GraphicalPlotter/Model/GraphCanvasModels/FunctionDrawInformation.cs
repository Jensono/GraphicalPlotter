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

    public class FunctionDrawInformation
    {
        private List<CanvasPixel> canvasPixels;

        private Color functionColor;

        public FunctionDrawInformation(List<CanvasPixel> canvasPixel, Color functionColor)
        {
            this.FunctionColor = functionColor;
            this.CanvasPixels = canvasPixel;
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
    }
}