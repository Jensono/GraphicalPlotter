using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalPlotter
{
    [Serializable]
    public class PlotterFullSaveData
    {

        public AxisSaveData XAxisSaveData { get; set; }
        public AxisSaveData YAxisSaveData { get; set; }
        public List<GraphicalFunctionDisplayNameForSerialization> SerializationFunctionList { get; set; }
        public PlotterFullSaveData( AxisSaveData xAxisSaveData, AxisSaveData yAxisSaveData, List<GraphicalFunctionDisplayNameForSerialization> functionList) 
        {
            this.XAxisSaveData = xAxisSaveData;
            this.YAxisSaveData = yAxisSaveData;
            this.SerializationFunctionList = functionList;
        
        }

        //empty construtor for serialization
        public PlotterFullSaveData() { }

       
    }
}
