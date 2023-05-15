

namespace GraphicalPlotter
{
    using System.Collections.Generic;
    using System.Windows.Media;

    public class FunctionDrawInformation
    {
        public List<CanvasPixel> CanvasPixels { get; set; }
        public Color FunctionColor { get; set; }

        public FunctionDrawInformation(List<CanvasPixel> canvasPixel, Color functionColor)
        {
            this.FunctionColor = functionColor;
            this.CanvasPixels = canvasPixel;
        }
    }
}