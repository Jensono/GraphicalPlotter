//-----------------------------------------------------------------------
// <copyright file="MainWindow.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used the main interface between the view and the model.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interactionlogic for the main window.
    /// </summary>>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The field for point that was first selected when drawing open a window / zooming into the canvas.
        /// </summary>
        private Point zoomSelectionStartPoint;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        public event EventHandler<CanvasZoomEventArguments> OnCanvasZoomStart;

        public event EventHandler<CanvasZoomEventArguments> OnCanvasZoomEnd;

        //// TODO right now when the user is zooming but moves out of the window to release the button, there is no zooming but the blue rectangle remains, fix with events that reset selected point and stop visibility of the rectangle maybe
        private void Canvas_ZoomStart(object sender, MouseButtonEventArgs eventArgs)
        {
            //// we check if the user is activly drawing open a window or not
            //// right now i believe this uses all mousebuttons so left and right, it could be adapted later on tho for the the only one that is wanted.
            if (eventArgs.ButtonState == MouseButtonState.Pressed)
            {
                //// send a event here to the mainviewmodel
                CanvasZoomEventArguments zoomStartEventArgs = new CanvasZoomEventArguments(eventArgs.GetPosition(PlotterCanvas));
                this.OnCanvasZoomStart(this, zoomStartEventArgs);

                //// start the window that shows the zoomselection so the user knows where he is
                this.zoomSelectionStartPoint = eventArgs.GetPosition(this.PlotterCanvas);
                Canvas.SetLeft(this.ZoomSelectionRectangle, this.zoomSelectionStartPoint.X);
                Canvas.SetTop(this.ZoomSelectionRectangle, this.zoomSelectionStartPoint.Y);
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
                double width = Math.Abs(currentSelectionEndPointPosition.X - this.zoomSelectionStartPoint.X);
                double height = Math.Abs(currentSelectionEndPointPosition.Y - this.zoomSelectionStartPoint.Y);
                double left = Math.Min(this.zoomSelectionStartPoint.X, currentSelectionEndPointPosition.X);
                double top = Math.Min(this.zoomSelectionStartPoint.Y, currentSelectionEndPointPosition.Y);
                ZoomSelectionRectangle.Width = width;
                ZoomSelectionRectangle.Height = height;
                Canvas.SetLeft(this.ZoomSelectionRectangle, left);
                Canvas.SetTop(this.ZoomSelectionRectangle, top);
            }
        }

        private void Canvas_ZoomEnd(object sender, MouseButtonEventArgs eventArgs)
        {
            CanvasZoomEventArguments zoomEndEventArgs = new CanvasZoomEventArguments(eventArgs.GetPosition(PlotterCanvas));
            this.OnCanvasZoomEnd(this, zoomEndEventArgs);
            ZoomSelectionRectangle.Visibility = Visibility.Hidden;
        }

    }
}