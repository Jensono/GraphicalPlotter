using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        private object currentPosition;

        public MainWindow()
        {
            InitializeComponent();

        }

        public void Canvas_ZoomStart(object sender,MouseButtonEventArgs eventArgs)
        {
            // we check if the user is activly drawing open a window or not
            //right now i believe this uses all mousebuttons so left and right, it could be adapted later on tho for the the only one that is wanted.
            if (eventArgs.ButtonState == MouseButtonState.Pressed)
            {
                CanvasZoomEventArguments zoomStartEventArgs = new CanvasZoomEventArguments(eventArgs.GetPosition(PlotterCanvas));
                this.OnCanvasZoomStart(this, zoomStartEventArgs);

                //start the window that show the zoomselection so the user knows where he is
                this.ZoomSelectionStartPoint = eventArgs.GetPosition(PlotterCanvas);
                Canvas.SetLeft(ZoomSelectionRectangle, ZoomSelectionStartPoint.X);
                Canvas.SetTop(ZoomSelectionRectangle, ZoomSelectionStartPoint.Y);
                ZoomSelectionRectangle.Width = 0;
                ZoomSelectionRectangle.Height = 0;

                ZoomSelectionRectangle.Visibility = Visibility.Visible;

                //send a event here to the mainviewmodel
            }

        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentSelectionEndPointPosition = e.GetPosition(PlotterCanvas);
                double width = Math.Abs(currentSelectionEndPointPosition.X - ZoomSelectionStartPoint.X);
                double height = Math.Abs(currentSelectionEndPointPosition.Y - ZoomSelectionStartPoint.Y);
                double left = Math.Min(ZoomSelectionStartPoint.X, currentSelectionEndPointPosition.X);
                double top = Math.Min(ZoomSelectionStartPoint.Y, currentSelectionEndPointPosition.Y);
                ZoomSelectionRectangle.Width = width;
                ZoomSelectionRectangle.Height = height;
                Canvas.SetLeft(ZoomSelectionRectangle, left);
                Canvas.SetTop(ZoomSelectionRectangle, top);
            }
        }

        public void Canvas_ZoomEnd(object sender, MouseButtonEventArgs eventArgs)
        {
            CanvasZoomEventArguments zoomEndEventArgs = new CanvasZoomEventArguments(eventArgs.GetPosition(PlotterCanvas));
            this.OnCanvasZoomEnd(this, zoomEndEventArgs);
            ZoomSelectionRectangle.Visibility = Visibility.Hidden;
        }

        //TODO DELETE
      
    }
}
