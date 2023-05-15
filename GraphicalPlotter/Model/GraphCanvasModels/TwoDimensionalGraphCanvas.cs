namespace GraphicalPlotter
{
    public class TwoDimensionalGraphCanvas
    {
        public int WidthInPixel { get; set; }
        public int HeightInPixel { get; set; }

        public AxisData XAxisData { get; set; }
        public AxisData YAxisData { get; set; }

        public AxisGridData XAxisGridData { get; set; }

        public AxisGridData YAxisGridData { get; set; }

        public TwoDimensionalGraphCanvas(int widthPixel, int heightPixel, AxisData xAxisData, AxisData yAxisData, AxisGridData xAxisGrid, AxisGridData yAxisGrid)
        {
            this.WidthInPixel = widthPixel;
            this.HeightInPixel = heightPixel;
            this.XAxisData = xAxisData;
            this.YAxisData = yAxisData;
            this.XAxisGridData = xAxisGrid;
            this.YAxisGridData = yAxisGrid;
        }
    }
}