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