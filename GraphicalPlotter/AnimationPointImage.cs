//-----------------------------------------------------------------------
// <copyright file="AnimationPointImage.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used to save the information needed to animate one point of an image on a graph.
// </summary>
//-----------------------------------------------------------------------

namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    /// <summary>
    /// This class is used to save the information needed to animate one point of an image on a graph.
    /// </summary>
    public class AnimationPointImage
    {
        /// <summary>
        /// The field for the curvature the image should have at a specific point.
        /// </summary>
        private double degreeCurvatureOnPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimationPointImage" /> class. 
        /// </summary>
        /// <param name="pointOnCanvas"> The point at which the image will be placed on a canvas.</param>
        /// <param name="degreeCurvature"> The number of degrees the image should be rotated. Positive numbers will turn clockwise, negative ones counter clockwise.</param>
        /// <param name="visibiltyAtThatPoint"> A boolean value indicating whether or not the image is visible at that point.</param>
        public AnimationPointImage(CanvasPixel pointOnCanvas, double degreeCurvature, bool visibiltyAtThatPoint)
        {
            this.AnimationPointXY = pointOnCanvas;
            this.DegreeCurvatureOnPoint = degreeCurvature;
            this.VisibilityOnPoint = visibiltyAtThatPoint;
        }

        

        public double DegreeCurvatureOnPoint 
        {
            get 
            {
                return this.degreeCurvatureOnPoint;
            }

            set 
            {
                if (value > 90 || value < -90)
                {
                    throw new ArgumentOutOfRangeException("the Rotation data is only allowed the be 90 degress counterclockwise or up to 90 degress clockwise!");
                }

                this.degreeCurvatureOnPoint = value;
            }
        
        }

        public CanvasPixel AnimationPointXY { get; set; }

        public bool VisibilityOnPoint { get; set; }



    }
}
