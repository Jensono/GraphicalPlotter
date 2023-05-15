//-----------------------------------------------------------------------
// <copyright file="AxisData.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used to store information for an mathemical axis of one dimension.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System.Windows.Media;

    public class AxisData
    {     
        /// <summary>
        /// The field for the maximum visible value on the axis.
        /// </summary>
        private double maxVisibleValue;

        /// <summary>
        /// The field for the minimum visible value on the axis.
        /// </summary>
        private double minVisibleValue;

        /// <summary>
        /// The field for the color of the axis line.
        /// </summary>
        private Color axisColor;

        /// <summary>
        /// The field for the boolflag 
        /// </summary>
        private bool visibility;

        public AxisData(double minValue, double maxValue, Color axisColor, bool isVisible)
        {
            this.MinVisibleValue = minValue;
            this.MaxVisibleValue = maxValue;
            this.AxisColor = axisColor;
            this.Visibility = isVisible;
        }

        // Empty constructor for serialization
        public AxisData()
        { }

        /// <summary>
        /// Gets or sets the max visible value for the axis data.
        /// </summary>
        /// <value> The max value that is visible on the axis.</value>
        public double MaxVisibleValue
        {
            get
            {
                return this.maxVisibleValue;
            }

            set
            {
                this.maxVisibleValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the min visible value for the axis data.
        /// </summary>
        /// <value> The min value that is visible on the axis.</value>
        public double MinVisibleValue
        {
            get
            {
                return this.minVisibleValue;
            }

            set
            {
                this.minVisibleValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the Color for the Axis line.
        /// </summary>
        /// <value> The Color for the Axis line.</value>
        public Color AxisColor
        {
            get
            {
                return this.axisColor;
            }

            set
            {
                this.axisColor = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the the axis line is visible.
        /// </summary>
        /// <value> The visbility of the axis line.</value>
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
    }
}