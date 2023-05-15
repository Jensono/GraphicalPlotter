﻿using System.Windows.Media;

namespace GraphicalPlotter
{
    public class AxisGridData
    {
        public double IntervallBetweenLines { get; set; }
        public Color GridColor { get; set; }
        public bool Visibility { get; set; }

        public AxisGridData(double intervallBetweenLines, Color gridColor, bool isVisible)
        {
            this.IntervallBetweenLines = intervallBetweenLines;
            this.GridColor = gridColor;
            this.Visibility = isVisible;
        }
    }
}