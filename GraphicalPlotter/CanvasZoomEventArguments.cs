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
    using System;
    using System.Windows;

    /// <summary>
    /// This class is used as the Event Arguments for the Canvas zoom event.
    /// </summary>
    public class CanvasZoomEventArguments : EventArgs
    {
        /// <summary>
        /// The field for the Point that is transferred by the event.
        /// </summary>
        private Point currentMouseLocationOnCanvas;

        //TODO NULL CHECK

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasZoomEventArguments" /> class.
        /// </summary>
        /// <param name="mouseLocation"> The point that represent the current mouse location.</param>
        public CanvasZoomEventArguments(Point mouseLocation)
        {
            this.currentMouseLocationOnCanvas = mouseLocation;
        }

        /// <summary>
        /// Gets or sets the axis minimum value.
        /// </summary>
        /// <value> The double representing the axis minimum.</value>
        /// <example> <see cref="ArgumentNullException"/> is thrown if the given value was null. </example>
        public Point CurrentMouseLocationOnCanvas
        {
            get 
            {
                return this.currentMouseLocationOnCanvas; 
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.CurrentMouseLocationOnCanvas)} can not be null");
                }
                else
                {
                    this.currentMouseLocationOnCanvas = value;
                }
            }
        }
    }
}