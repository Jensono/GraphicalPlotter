//-----------------------------------------------------------------------
// <copyright file="TwoDimensionalGraphCanvas.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class contains all the information needed to draw or concept out a two dimensional Canvas used for graphing function.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;

    /// <summary>
    /// This class holds all the information for a two dimensional Canvas on which functions and other objects can be displayed.
    /// </summary>
    public class TwoDimensionalGraphCanvas
    {
        /// <summary>
        /// The field for the Pixel width of the canvas in pixel.
        /// </summary>
        private int widthInPixel;

        /// <summary>
        /// The field for the Pixel height of the canvas in pixel.
        /// </summary>
        private int heightInPixel;

        /// <summary>
        /// The field for Axis data for the x-axis.
        /// </summary>
        private AxisData xAxisData;

        /// <summary>
        /// The field for Axis data for the y-axis.
        /// </summary>
        private AxisData yAxisData;

        /// <summary>
        /// The field for Axis grid data for the x-axis.
        /// </summary>
        private AxisGridData xAxisGridData;

        /// <summary>
        /// The field for Axis grid data for the y-axis.
        /// </summary>
        private AxisGridData yAxisGridData;

        /// <summary>
        /// Initializes a new instance of the <see cref="TwoDimensionalGraphCanvas" /> class.
        /// </summary>
        /// <param name="widthPixel"> The width of the canvas in pixels.</param>
        /// <param name="heightPixel"> The height of the canvas in pixels.</param>
        /// <param name="xAxisData"> The AxisData for the x-axis.</param>
        /// <param name="yAxisData"> The AxisData for the y-axis.</param>
        /// <param name="xAxisGrid"> The AxisGridData for the x-axis.</param>
        /// <param name="yAxisGrid"> The AxisGridData for the y-axis.</param>
        public TwoDimensionalGraphCanvas(int widthPixel, int heightPixel, AxisData xAxisData, AxisData yAxisData, AxisGridData xAxisGrid, AxisGridData yAxisGrid)
        {
            this.WidthInPixel = widthPixel;
            this.HeightInPixel = heightPixel;
            this.XAxisData = xAxisData;
            this.YAxisData = yAxisData;
            this.XAxisGridData = xAxisGrid;
            this.YAxisGridData = yAxisGrid;
        }

        /// <summary>
        /// Gets or sets the Width in pixel for the Graph canvas.
        /// </summary>
        /// <value> The Width in pixel for the Graph canvas.</value>
        public int WidthInPixel
        {
            get { return this.widthInPixel; }
            set { this.widthInPixel = value; }
        }

        /// <summary>
        /// Gets or sets the Height in pixel for the Graph canvas.
        /// </summary>
        /// <value> The Height in pixel for the Graph canvas.</value>
        public int HeightInPixel
        {
            get { return this.heightInPixel; }
            set { this.heightInPixel = value; }
        }

        /// <summary>
        /// Gets or sets the AxisData used for the x-axis inside the two dimensional Canvas.
        /// </summary>
        /// <value> The AxisData used for the x-axis inside the two dimensional Canvas. </value>
        /// <example> <see cref="ArgumentNullException"/> is thrown if the given value was null. </example>
        public AxisData XAxisData
        {
            get
            {
                return this.xAxisData;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.XAxisData)} can not be null!");
                }

                this.xAxisData = value;
            }
        }

        /// <summary>
        /// Gets or sets the AxisData used for the y-axis inside the two dimensional Canvas.
        /// </summary>
        /// <value> The AxisData used for the y-axis inside the two dimensional Canvas. </value>
        /// <example> <see cref="ArgumentNullException"/> is thrown if the given value was null. </example>
        public AxisData YAxisData
        {
            get
            {
                return this.yAxisData;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.YAxisData)} cannot be null!");
                }

                this.yAxisData = value;
            }
        }

        /// <summary>
        /// Gets or sets the AxisGridData used for the x-axis inside the two dimensional Canvas.
        /// </summary>
        /// <value> The AxisGridData used for the x-axis inside the two dimensional Canvas. </value>
        /// <example> <see cref="ArgumentNullException"/> is thrown if the given value was null. </example>
        public AxisGridData XAxisGridData
        {
            get 
            {
                return this.xAxisGridData;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.XAxisGridData)} cannot be null!");
                }

                this.xAxisGridData = value;
            }
        }

        /// <summary>
        /// Gets or sets the AxisGridData used for the y-axis inside the two dimensional Canvas.
        /// </summary>
        /// <value> The AxisGridData used for the y-axis inside the two dimensional Canvas. </value>
        /// <example> <see cref="ArgumentNullException"/> is thrown if the given value was null. </example>
        public AxisGridData YAxisGridData
        {
            get 
            {
                return this.yAxisGridData;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.YAxisGridData)} cannot be null!");
                }

                this.yAxisGridData = value;
            }
        }
    }
}