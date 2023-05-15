//-----------------------------------------------------------------------
// <copyright file="AxisSaveData.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class used to serialize an a mathematical axis and grid for one dimension, combined in one class.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;
    using System.Windows.Media;

    [Serializable]
    public class AxisSaveData
    {
      
        public AxisSaveData(AxisData axis, AxisGridData grid)
        {
            this.AxisMin = axis.MinVisibleValue;
            this.AxisMax = axis.MaxVisibleValue;
            this.AxisLineColor = axis.AxisColor;
            this.AxisLineVisibility = axis.Visibility;

            this.GridIntervall = grid.IntervallBetweenLines;
            this.GridLineColor = grid.GridColor;
            this.GridVisibility = grid.Visibility;
        }

        public AxisSaveData()
        {

        }

        public double AxisMin { get; set; }

        public double AxisMax { get; set; }

        public Color AxisLineColor { get; set; }
        public bool AxisLineVisibility { get; set; }

        public double GridIntervall { get; set; }
        public Color GridLineColor { get; set; }
        public bool GridVisibility { get; set; }
    }
}