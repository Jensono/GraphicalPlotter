namespace GraphicalPlotter
{
    public class CanvasPixel
    {
        private int xAxisValue;

        private int yAxisValue;

        public CanvasPixel(int xAxisValue, int yAxisValue)
        {
            this.XAxisValue = xAxisValue;
            this.YAxisValue = yAxisValue;
        }

        public int YAxisValue
        {
            get
            {
                return this.yAxisValue;
            }
            set
            {
                this.yAxisValue = value;
            }
        }

        public int XAxisValue
        {
            get
            {
                return this.xAxisValue;
            }
            set
            {
                this.xAxisValue = value;
            }
        }
    }
}