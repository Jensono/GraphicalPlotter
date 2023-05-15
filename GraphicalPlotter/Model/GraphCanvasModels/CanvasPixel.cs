namespace GraphicalPlotter
{
    public class CanvasPixel
    {
        private int xAxisValue;

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

        private int yAxisValue;

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

        public CanvasPixel(int xAxisValue, int yAxisValue)
        {
            this.XAxisValue = xAxisValue;
            this.YAxisValue = yAxisValue;
        }
    }
}