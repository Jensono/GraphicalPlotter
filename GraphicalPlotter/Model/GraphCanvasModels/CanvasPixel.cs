//-----------------------------------------------------------------------
// <copyright file="CanvasPixel.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used to decribe a point or pixel on a two dimensional plane. 
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    public class CanvasPixel
    {
        private int xAxisValue;

        private int yAxisValue;

        public CanvasPixel(int xAxisValue, int yAxisValue)
        {
            this.XAxisValue = xAxisValue;
            this.YAxisValue = yAxisValue;
        }

        public int YAxisValue
        {
            get
            {
                return this.yAxisValue;
            }

            set
            {
                this.yAxisValue = value;
            }
        }

        public int XAxisValue
        {
            get
            {
                return this.xAxisValue;
            }

            set
            {
                this.xAxisValue = value;
            }
        }
    }
}