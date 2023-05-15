using System.Windows;

namespace GraphicalPlotter
{
    public class CanvasZoomEventArguments
    {
        private Point currentMouseLocationOnCanvas;

        public Point CurrentMouseLocationOnCanvas
        {
            get { return currentMouseLocationOnCanvas; }
            set
            {
                if (value != null)
                {
                    currentMouseLocationOnCanvas = value;
                }
            }
        }

        public CanvasZoomEventArguments(Point mouseLocation)
        {
            this.currentMouseLocationOnCanvas = mouseLocation;
        }
    }
}