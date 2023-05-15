﻿namespace GraphicalPlotter
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