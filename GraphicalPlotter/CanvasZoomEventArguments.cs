

namespace GraphicalPlotter
{
    using System.Windows;
    public class CanvasZoomEventArguments
    {
        private Point currentMouseLocationOnCanvas;

        public Point CurrentMouseLocationOnCanvas
        {
            get { return this.currentMouseLocationOnCanvas; }
            set
            {
                if (value != null)
                {
                    this.currentMouseLocationOnCanvas = value;
                }
            }
        }

        public CanvasZoomEventArguments(Point mouseLocation)
        {
            this.currentMouseLocationOnCanvas = mouseLocation;
        }
    }
}