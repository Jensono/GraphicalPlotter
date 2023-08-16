//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="FHWN">
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
    using System.Collections.Generic;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    /// <summary>
    /// Interaction logic for the main window.
    /// </summary>>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The field for point that was first selected when drawing open a window / zooming into the canvas.
        /// </summary>
        private Point zoomSelectionStartPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class. 
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            var viewModel = this.DataContext as MainViewModel;
            if (viewModel != null)
            {
                viewModel.AnimationPointsGenerated += this.OnStartSteeringWheelAnimation;
            }
        }

           


        /// <summary>
        /// The event for when the user starts the zooming process by pressing a mouse button inside the canvas.
        /// </summary>
        public event EventHandler<CanvasZoomEventArguments> OnCanvasZoomStart;

        /// <summary>
        /// The event for when the user ends the zooming process by releasing a mouse button inside the canvas.
        /// </summary>
        public event EventHandler<CanvasZoomEventArguments> OnCanvasZoomEnd;

        //// TODO right now when the user is zooming but moves out of the window to release the button, there is no zooming but the blue rectangle remains, 
        //// fix with events that reset selected point and stop visibility of the rectangle maybe
        
        /// <summary>
        /// This method that is called when the Event for the OnCanvasZoomStart is raised. It sends a event to the View model and sets the start point for the zoom.
        /// </summary>
        /// <param name="sender"> The sender of the event.</param>
        /// <param name="eventArgs"> The event arguments of the event.</param>
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

        //// TODO SPECIFY THE MOUSE BUTTON  FOR WHICH THE ZOOM should be available, for example left mouse button.

        /// <summary>
        /// This method is called when the mouse is being moved while the mouse button is pressed. Draws a Rectangle to show the user where he is currently zooming in.
        /// </summary>
        /// <param name="sender"> The sender of the event.</param>
        /// <param name="eventArgs"> The event arguments of the event.</param>
        private void Canvas_MouseMove(object sender, MouseEventArgs eventArgs)
        {
            if (eventArgs.LeftButton == MouseButtonState.Pressed || eventArgs.RightButton == MouseButtonState.Pressed || eventArgs.MiddleButton == MouseButtonState.Pressed)
            {
                Point currentSelectionEndPointPosition = eventArgs.GetPosition(PlotterCanvas);
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

        /// <summary>
        /// The event that is called then mouse button is released inside the Plotter Canvas. Sends a event to the view model to let it know the zoom window was drawn open.
        /// </summary>
        /// <param name="sender"> The sender of the event.</param>
        /// <param name="eventArgs"> The event arguments of the event.</param>
        private void Canvas_ZoomEnd(object sender, MouseButtonEventArgs eventArgs)
        {
            CanvasZoomEventArguments zoomEndEventArgs = new CanvasZoomEventArguments(eventArgs.GetPosition(PlotterCanvas));
            this.OnCanvasZoomEnd(this, zoomEndEventArgs);
            ZoomSelectionRectangle.Visibility = Visibility.Hidden;
        }

        public void OnStartSteeringWheelAnimation(object sender, SteeringWheelStartAnimationEventArguments eventArgs)
        {



            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(TranslateWheel.X, TranslateWheel.Y); // Assuming you start from the current position

            PolyLineSegment polyLineSegment = new PolyLineSegment();

            foreach (var point in eventArgs.AnimationPoints)
            {
                polyLineSegment.Points.Add(new Point(point.AnimationPointXY.XAxisValue, point.AnimationPointXY.YAxisValue));
            }

            pathFigure.Segments.Add(polyLineSegment);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(pathFigure);

            // Animate the TranslateWheel along the path
            MatrixTransform matrixTransform = new MatrixTransform();
            SteeringWheelImage.RenderTransform = matrixTransform;

            DoubleAnimationUsingPath matrixAnimation = new DoubleAnimationUsingPath();
            matrixAnimation.PathGeometry = pathGeometry;
            matrixAnimation.Duration = TimeSpan.FromMilliseconds(20000);
            matrixAnimation.Source = PathAnimationSource.Y; // Animate Y values; repeat for X values

            matrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, matrixAnimation);

            //int totalAnimationTimeInMilliseconds = 20000;
            //var animationPoints = eventArgs.AnimationPoints;

            //int delayPerPoint = totalAnimationTimeInMilliseconds / animationPoints.Count;



            //foreach (var point in eventArgs.AnimationPoints)
            //{
            //    TranslateWheel.X = point.AnimationPointXY.XAxisValue;
            //    TranslateWheel.Y = point.AnimationPointXY.YAxisValue;
            //    RotateWheel.Angle = point.DegreeCurvatureOnPoint;
            //    Visibility frameVisibility = Visibility.Hidden;
            //       if (point.VisibilityOnPoint)
            //        {
            //            frameVisibility = Visibility.Visible;
            //        }
            //    SteeringWheelImage.Visibility = frameVisibility;
            //    Thread.Sleep(100);
            //}

            //foreach (var point in animationPoints)
            //{
            //    DoubleAnimation xAnimation = new DoubleAnimation
            //    {
            //        From = TranslateWheel.X,
            //        To = point.AnimationPointXY.XAxisValue,
            //        BeginTime = TimeSpan.FromMilliseconds(currentTime),
            //        Duration = TimeSpan.FromMilliseconds(delayPerPoint)
            //    };
            //    Storyboard.SetTarget(xAnimation, TranslateWheel);
            //    Storyboard.SetTargetProperty(xAnimation, new PropertyPath(TranslateTransform.XProperty));
            //    storyboard.Children.Add(xAnimation);

            //    DoubleAnimation yAnimation = new DoubleAnimation
            //    {
            //        From = TranslateWheel.Y,
            //        To = point.AnimationPointXY.YAxisValue,
            //        BeginTime = TimeSpan.FromMilliseconds(currentTime),
            //        Duration = TimeSpan.FromMilliseconds(delayPerPoint)
            //    };
            //    Storyboard.SetTarget(yAnimation, TranslateWheel);
            //    Storyboard.SetTargetProperty(yAnimation, new PropertyPath(TranslateTransform.YProperty));
            //    storyboard.Children.Add(yAnimation);

            //    DoubleAnimation rotationAnimation = new DoubleAnimation
            //    {
            //        From = RotateWheel.Angle,
            //        To = point.DegreeCurvatureOnPoint,
            //        BeginTime = TimeSpan.FromMilliseconds(currentTime),
            //        Duration = TimeSpan.FromMilliseconds(delayPerPoint)
            //    };
            //    Storyboard.SetTarget(rotationAnimation, RotateWheel);
            //    Storyboard.SetTargetProperty(rotationAnimation, new PropertyPath(RotateTransform.AngleProperty));
            //    storyboard.Children.Add(rotationAnimation);

            //    ObjectAnimationUsingKeyFrames visibilityAnimation = new ObjectAnimationUsingKeyFrames
            //    {
            //        BeginTime = TimeSpan.FromMilliseconds(currentTime),
            //        Duration = TimeSpan.FromMilliseconds(delayPerPoint)
            //    };

            //    Visibility frameVisibility = Visibility.Hidden;
            //    if (point.VisibilityOnPoint)
            //    {
            //        frameVisibility = Visibility.Visible;
            //    }

            //    DiscreteObjectKeyFrame visibilityKeyFrame = new DiscreteObjectKeyFrame
            //    {
            //        KeyTime = KeyTime.FromPercent(0),
            //        Value = frameVisibility
            //    };
            //    visibilityAnimation.KeyFrames.Add(visibilityKeyFrame);

            //    // Setting the target and property for the visibility animation
            //    Storyboard.SetTarget(visibilityAnimation, SteeringWheelImage);
            //    Storyboard.SetTargetProperty(visibilityAnimation, new PropertyPath(UIElement.VisibilityProperty));
            //    storyboard.Children.Add(visibilityAnimation);

            //    currentTime += delayPerPoint;
            //}

            // Start the storyboard after all animations are added
            //storyboard.Begin();
        }


    }
}