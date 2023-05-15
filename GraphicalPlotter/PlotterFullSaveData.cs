﻿

namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class PlotterFullSaveData
    {
        public AxisSaveData XAxisSaveData { get; set; }
        public AxisSaveData YAxisSaveData { get; set; }
        public List<GraphicalFunctionDisplayNameForSerialization> SerializationFunctionList { get; set; }
        public bool HasUserChangedYAxis { get; set; }

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
    }
}