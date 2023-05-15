//-----------------------------------------------------------------------
// <copyright file="AxisGridData.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used to store information for a grid that is associated with an axis on a mathematical dimension.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System.Windows.Media;

    public class AxisGridData
    {
        /// <summary>
        /// The field for distance between two grid lines.
        /// </summary>
        private double intervalBetweenLines;

        /// <summary>
        /// The field for the color of the grid lines.
        /// </summary>
        private Color gridColor;

        /// <summary>
        /// The field indicating whether or not the grid lines are visible.
        /// </summary>
        private bool visibility;

        public AxisGridData(double intervallBetweenLines, Color gridColor, bool isVisible)
        {
            this.IntervallBetweenLines = intervallBetweenLines;
            this.GridColor = gridColor;
            this.Visibility = isVisible;
        }


        /// <summary>
        /// Gets or sets the intervall or distance between two grid lines on the orthogal axis.
        /// </summary>
        /// <value> The intervall or distance between two grid lines inside the grid.</value>
        public double IntervallBetweenLines
        {
            get
            {
                return this.intervalBetweenLines;
            }

            set
            {
                this.intervalBetweenLines = value;
            }
        }

        /// <summary>
        /// Gets or sets the Color for the grid lines.
        /// </summary>
        /// <value> The Color for the grid lines.</value>
        public Color GridColor
        {
            get
            {
                return this.gridColor;
            }

            set
            {
                this.gridColor = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the the grid lines are visible
        /// </summary>
        /// <value> The visbility of the grid.</value>
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