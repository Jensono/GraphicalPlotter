

namespace GraphicalPlotter
{
    using System;
    using System.Windows.Media;

    [Serializable]
    public class AxisSaveData
    {

        //TODO fields but i dont need any nullchecks, min smaller then max maybe
        public double AxisMin { get; set; }
        public double AxisMax { get; set; }

        public Color AxisLineColor { get; set; }
        public bool AxisLineVisibility { get; set; }

        public double GridIntervall { get; set; }
        public Color GridLineColor { get; set; }
        public bool GridVisibility { get; set; }

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
        { }
    }
}