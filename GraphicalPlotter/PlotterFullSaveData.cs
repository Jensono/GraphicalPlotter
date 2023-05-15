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
        private List<GraphicalFunctionDisplayNameForSerialization> serializationFunctionList;

        public PlotterFullSaveData(AxisSaveData xAxisSaveData, AxisSaveData yAxisSaveData, List<GraphicalFunctionDisplayNameForSerialization> functionList, bool hasUserChangedYAxis)
        {
            this.XAxisSaveData = xAxisSaveData;
            this.YAxisSaveData = yAxisSaveData;
            this.SerializationFunctionList = functionList;
            this.HasUserChangedYAxis = hasUserChangedYAxis;
        }

        //// empty construtor for serialization
        public PlotterFullSaveData()
        { }

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
        public List<GraphicalFunctionDisplayNameForSerialization> SerializationFunctionList
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
        /// Gets or sets a value indicating whether or not the user has ever changed something in the y axis attributes, meaning there is no more autoscaling.
        /// </summary>
        /// <value> The boolflag used to find out, if the user has ever changed y-axis values.</value>
        public bool HasUserChangedYAxis { get; set; }
    }
}