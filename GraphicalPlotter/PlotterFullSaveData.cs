namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class PlotterFullSaveData
    {
        private AxisSaveData xAxisSaveData;
        private AxisSaveData yAxisSaveData;
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

        public AxisSaveData XAxisSaveData
        {
            get { return this.xAxisSaveData; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.XAxisSaveData)} cannot be null!");
                }

                this.xAxisSaveData = value;
            }
        }

        public AxisSaveData YAxisSaveData
        {
            get { return this.yAxisSaveData; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.YAxisSaveData)} cannot be null!");
                }

                this.yAxisSaveData = value;
            }
        }

        public List<GraphicalFunctionDisplayNameForSerialization> SerializationFunctionList
        {
            get { return this.serializationFunctionList; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.SerializationFunctionList)} cannot be null!");
                }

                this.serializationFunctionList = value;
            }
        }

        public bool HasUserChangedYAxis { get; set; }
    }
}