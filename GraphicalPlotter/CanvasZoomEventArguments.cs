//-----------------------------------------------------------------------
// <copyright file="CanvasZoomEventArguments.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used as the event arguments for the Zoom event. That is triggered when a user zooms into the canvas.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System.Windows;
    public class CanvasZoomEventArguments
    {
        /// <summary>
        /// The field for the Point that is transfered by the event.
        /// </summary>
        private Point currentMouseLocationOnCanvas;

      

        public CanvasZoomEventArguments(Point mouseLocation)
        {
            this.currentMouseLocationOnCanvas = mouseLocation;
        }

        public Point CurrentMouseLocationOnCanvas
        {
            get 
            {
                return this.currentMouseLocationOnCanvas; 
            }

            set
            {
                if (value != null)
                {
                    this.currentMouseLocationOnCanvas = value;
                }
            }
        }
    }
}