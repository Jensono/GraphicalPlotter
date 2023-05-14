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

        public MainWindow()
        {
            InitializeComponent();

        }

        public void Canvas_ZoomStart(object sender,MouseButtonEventArgs eventArgs)
        {
            // we check if the user is activly drawing open a window or not
            if (eventArgs.ButtonState == MouseButtonState.Pressed)
            {
                CanvasZoomEventArguments zoomStartEventArgs = new CanvasZoomEventArguments(eventArgs.GetPosition(PlotterCanvas));
                this.OnCanvasZoomStart(this, zoomStartEventArgs);
                //send a event here to the mainviewmodel
            }

        }

        public void Canvas_ZoomEnd(object sender, MouseButtonEventArgs eventArgs)
        {
            CanvasZoomEventArguments zoomEndEventArgs = new CanvasZoomEventArguments(eventArgs.GetPosition(PlotterCanvas));
            this.OnCanvasZoomEnd(this, zoomEndEventArgs);
        }

        //TODO DELETE
      
    }
}
