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
        private double intervalBetweenLines;
        private Color gridColor;
        private bool visibility;

        public AxisGridData(double intervallBetweenLines, Color gridColor, bool isVisible)
        {
            this.IntervallBetweenLines = intervallBetweenLines;
            this.GridColor = gridColor;
            this.Visibility = isVisible;
        }

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