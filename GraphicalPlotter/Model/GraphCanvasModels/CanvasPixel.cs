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
    /// <summary>
    /// This class defines a point on a canvas by pixel values.
    /// </summary>
    public class CanvasPixel
    {
        /// <summary>
        /// The field for the x axis position of the canvas pixel measured from the left of the canvas.
        /// </summary>
        private int xAxisValue;

        /// <summary>
        /// The field for the y axis position of the canvas pixel measured from the top of the canvas.
        /// </summary>
        private int yAxisValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasPixel" /> class.
        /// </summary>
        /// <param name="xAxisValue"> The distance in pixel from the left of medium that can portray the pixel.</param>
        /// <param name="yAxisValue">The distance in pixel from the top of medium that can portray the pixel.</param>
        public CanvasPixel(int xAxisValue, int yAxisValue)
        {
            this.XAxisValue = xAxisValue;
            this.YAxisValue = yAxisValue;
        }

        /// <summary>
        /// Gets or sets the y axis value for the canvas pixel measured from the left of the canvas.
        /// </summary>
        /// <value> The  y axis value for the canvas pixel measured from the left of the canvas.</value>
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

        /// <summary>
        /// Gets or sets the x axis value for the canvas pixel measured from the top of the canvas.
        /// </summary>
        /// <value> The  x axis value for the canvas pixel measured from the top of the canvas.</value>
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