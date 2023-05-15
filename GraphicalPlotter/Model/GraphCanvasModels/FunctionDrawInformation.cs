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