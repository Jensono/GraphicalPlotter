//-----------------------------------------------------------------------
// <copyright file="PlotterFullSaveData.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used for Serializing the whole application status, including axis, grid and function information.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class is used compress all of the variables that the user can change into one class for easy serialization and deserialization.
    /// </summary>
    [Serializable]
    public class PlotterFullSaveData
    {
        /// <summary>
        /// The field for Axis grid save data for the x-axis.
        /// </summary>
        private AxisSaveData xAxisSaveData;

        /// <summary>
        /// The field for Axis grid save data for the y-axis.
        /// </summary>
        private AxisSaveData yAxisSaveData;

        /// <summary>
        /// The field for the list of Graphical functions that were made for serialization.
        /// </summary>
        private List<GraphicalFunctionForSerialization> serializationFunctionList;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlotterFullSaveData" /> class.
        /// </summary>
        /// <param name="xAxisSaveData"> The AxisSaveData for the x-axis of the Plotter Canvas. </param>
        /// <param name="yAxisSaveData"> The AxisSaveData for the y-axis of the Plotter Canvas.</param>
        /// <param name="functionList"> The list of functions that are currently saved inside the plotter application.</param>
        /// <param name="hasUserChangedYAxis"> The boolean value indicating whether or not the user has changed the y-axis parameters.</param>
        public PlotterFullSaveData(AxisSaveData xAxisSaveData, AxisSaveData yAxisSaveData, List<GraphicalFunctionForSerialization> functionList, bool hasUserChangedYAxis)
        {
            this.XAxisSaveData = xAxisSaveData;
            this.YAxisSaveData = yAxisSaveData;
            this.SerializationFunctionList = functionList;
            this.HasUserChangedYAxis = hasUserChangedYAxis;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlotterFullSaveData" /> class. Used for serialization.
        /// </summary>
        public PlotterFullSaveData()
        {
        }

        /// <summary>
        /// Gets or sets the AxisSaveData used for the x-axis.
        /// </summary>
        /// <value> The AxisSaveData used for the x-axis. </value>
        /// <example> <see cref="ArgumentNullException"/> is thrown if the given value was null. </example>
        public AxisSaveData XAxisSaveData
        {
            get 
            { 
                return this.xAxisSaveData;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.XAxisSaveData)} cannot be null!");
                }

                this.xAxisSaveData = value;
            }
        }

        /// <summary>
        /// Gets or sets the AxisSaveData used for the y-axis.
        /// </summary>
        /// <value> The AxisSaveData used for the y-axis. </value>
        /// <example> <see cref="ArgumentNullException"/> is thrown if the given value was null. </example>
        public AxisSaveData YAxisSaveData
        {
            get 
            { 
                return this.yAxisSaveData;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.YAxisSaveData)} cannot be null!");
                }

                this.yAxisSaveData = value;
            }
        }

        /// <summary>
        /// Gets or sets the List of functions that were generated for serialization.
        /// </summary>
        /// <value> The List of functions that were generated for serialization. </value>
        /// <example> <see cref="ArgumentNullException"/> is thrown if the given value was null. </example>
        public List<GraphicalFunctionForSerialization> SerializationFunctionList
        {
            get
            { 
                return this.serializationFunctionList; 
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.SerializationFunctionList)} cannot be null!");
                }

                this.serializationFunctionList = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the user has ever changed something in the y axis attributes, meaning there is no more auto-scaling.
        /// </summary>
        /// <value> The boolean flag used to find out, if the user has ever changed y-axis values.</value>
        public bool HasUserChangedYAxis { get; set; }
    }
}