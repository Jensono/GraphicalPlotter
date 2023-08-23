

namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    /// <summary>
    /// This class is used to save the information needed to animate one point of an image on a graph
    /// </summary>
    public class AnimationPointImage
    {
        public AnimationPointImage(CanvasPixel pointOnCanvas, double degreeCurvature, bool visibiltyAtThatPoint)
        {
            this.AnimationPointXY = pointOnCanvas;
            this.DegreeCurvatureOnPoint = degreeCurvature;
            this.VisibilityOnPoint = visibiltyAtThatPoint;
        }

        public double degreeCurvatureOnPoint;

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
