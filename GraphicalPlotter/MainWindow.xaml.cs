using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraphicalPlotter
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>>
    public partial class MainWindow : Window
    {
        public event EventHandler<CanvasZoomEventArguments> OnCanvasZoomStart;

        public event EventHandler<CanvasZoomEventArguments> OnCanvasZoomEnd;

        public Point ZoomSelectionStartPoint;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        public void Canvas_ZoomStart(object sender, MouseButtonEventArgs eventArgs)
        {
            //// we check if the user is activly drawing open a window or not
            //// right now i believe this uses all mousebuttons so left and right, it could be adapted later on tho for the the only one that is wanted.
            if (eventArgs.ButtonState == MouseButtonState.Pressed)
            {
                //// send a event here to the mainviewmodel
                CanvasZoomEventArguments zoomStartEventArgs = new CanvasZoomEventArguments(eventArgs.GetPosition(PlotterCanvas));
                this.OnCanvasZoomStart(this, zoomStartEventArgs);

                //// start the window that shows the zoomselection so the user knows where he is
                this.ZoomSelectionStartPoint = eventArgs.GetPosition(PlotterCanvas);
                Canvas.SetLeft(this.ZoomSelectionRectangle, this.ZoomSelectionStartPoint.X);
                Canvas.SetTop(this.ZoomSelectionRectangle, this.ZoomSelectionStartPoint.Y);
                ZoomSelectionRectangle.Width = 0;
                ZoomSelectionRectangle.Height = 0;

                ZoomSelectionRectangle.Visibility = Visibility.Visible;

               
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentSelectionEndPointPosition = e.GetPosition(PlotterCanvas);
                double width = Math.Abs(currentSelectionEndPointPosition.X - this.ZoomSelectionStartPoint.X);
                double height = Math.Abs(currentSelectionEndPointPosition.Y - this.ZoomSelectionStartPoint.Y);
                double left = Math.Min(this.ZoomSelectionStartPoint.X, currentSelectionEndPointPosition.X);
                double top = Math.Min(this.ZoomSelectionStartPoint.Y, currentSelectionEndPointPosition.Y);
                ZoomSelectionRectangle.Width = width;
                ZoomSelectionRectangle.Height = height;
                Canvas.SetLeft(this.ZoomSelectionRectangle, left);
                Canvas.SetTop(this.ZoomSelectionRectangle, top);
            }
        }

        public void Canvas_ZoomEnd(object sender, MouseButtonEventArgs eventArgs)
        {
            CanvasZoomEventArguments zoomEndEventArgs = new CanvasZoomEventArguments(eventArgs.GetPosition(PlotterCanvas));
            this.OnCanvasZoomEnd(this, zoomEndEventArgs);
            ZoomSelectionRectangle.Visibility = Visibility.Hidden;
        }

    }
}