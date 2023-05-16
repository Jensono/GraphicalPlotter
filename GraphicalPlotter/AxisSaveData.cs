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

    /// <summary>
    /// This class is used to serialize the AxisData and AxisGridData class combined in one class.
    /// </summary>
    [Serializable]    
    public class AxisSaveData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AxisSaveData" /> class.
        /// </summary>
        /// <param name="axis"> The AxisData for the AxisSaveData.</param>
        /// <param name="grid"> The grid for the AxisSaveData.</param>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="AxisSaveData" /> class.
        /// </summary>
        public AxisSaveData()
        {
        }

        /// <summary>
        /// Gets or sets the axis minimum value.
        /// </summary>
        /// <value> The double representing the axis minimum.</value>
        public double AxisMin { get; set; }

        /// <summary>
        /// Gets or sets the axis maximum value.
        /// </summary>
        /// <value> The double representing the axis maximum.</value>
        public double AxisMax { get; set; }

        /// <summary>
        /// Gets or sets the axis line color.
        /// </summary>
        /// <value> The color for the axis line.</value>
        public Color AxisLineColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the line for the axis is visible.
        /// </summary>
        /// <value> The visibility of the axis line.</value>
        public bool AxisLineVisibility { get; set; }

        /// <summary>
        /// Gets or sets a value the distance between grid lines.
        /// </summary>
        /// <value> The visibility of the grid.</value>
        public double GridIntervall { get; set; }

        /// <summary>
        /// Gets or sets the axis grid line color.
        /// </summary>
        /// <value> The color for the axis grid.</value>
        public Color GridLineColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the grid for the axis is visible.
        /// </summary>
        /// <value> The visibility of the grid.</value>
        public bool GridVisibility { get; set; }
    }
}