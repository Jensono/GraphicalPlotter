using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalPlotter
{
    class SteeringWheelAnimationPreparer
    {

        public SteeringWheelAnimationPreparer(List<FunctionDrawInformation> steeringWheelPointsXY, List<double> curvatureForPoints,int maxWidthCanvas) 
        {
            this.FunctionsDrawInfomration = steeringWheelPointsXY;
            this.CurvatureOnPoints = curvatureForPoints;
            this.MaxWidthCanvas = maxWidthCanvas;
        }


        public List<AnimationPointImage> GenerateAnimationPointsWithCurvature() 
        {
            List<AnimationPointImage> animationPoints = new List<AnimationPointImage>();
            List<CanvasPixel> fullListOfPixel = this.GenerateOneFunctionDrawInformation();
            List<double> DegressTurnsPerPoint = this.GenerateNormalisedTurnsForCurvatureList(this.CurvatureOnPoints);
            // in theory the functiondrawinformation can only contain x values from 0 to how ever big the screen is at the present. In fact the list of double point must be the same size as the screen width. 
            // With this knowledge we can now combine these two list into one list; Points that will not be displayed on the canvas will be set to not visible , so that the animation will always be the same length:
      
            for (int i = 0, counterForPixelList= 0; i < this.MaxWidthCanvas; i++)
            {
                // when the point for x is inside the list the steering wheel has a normal position and is visible, else there is a point where the function is not displayed on the canvas.
                if (fullListOfPixel[counterForPixelList].XAxisValue==i)
                {
                    // we must move the curser for the pixel list as we found a value that was inside the list.
                    
                    animationPoints.Add(new AnimationPointImage(fullListOfPixel[counterForPixelList], DegressTurnsPerPoint[i], true));
                    counterForPixelList++;

                }
                else
                {
                    // we add a "fake" point for the animation, and also make the point not visible
                    animationPoints.Add(new AnimationPointImage(new CanvasPixel(0,0), DegressTurnsPerPoint[i], false)) ;
                }
                

            }
            return animationPoints;

        
        }

        private List<double> GenerateNormalisedTurnsForCurvatureList(List<double> curvatureOnPoints)
        {
            // first find the biggest value in the list, as an abosulte value , we will use this value as an anchor for the 90 degreee rotation.
            double maxCurvature = curvatureOnPoints.Max(Math.Abs);

            // if the biggest rotation is 0 there will be no rotation at all, eg a horizontal line, but we still need values and dont want to divide by zero.
            if (maxCurvature == 0)
            {
                return Enumerable.Repeat(0.0, curvatureOnPoints.Count).ToList();
            }

            List<double> normalizedTurns = curvatureOnPoints.Select(curvature => (curvature / maxCurvature) * 90).ToList();

            return normalizedTurns;

        }

        public List<CanvasPixel> GenerateOneFunctionDrawInformation() 
        {
            List<CanvasPixel> newFullCanvasPixelList = new List<CanvasPixel>();
            foreach (FunctionDrawInformation item in this.FunctionsDrawInfomration)
            {
                foreach (CanvasPixel pixel in item.CanvasPixels)
                {
                    newFullCanvasPixelList.Add(pixel);
                }
            }
            return newFullCanvasPixelList;
        
        }
        private int MaxWidthCanvas { get; set; }
        private List<FunctionDrawInformation> FunctionsDrawInfomration { get; set; }
        private List<double> CurvatureOnPoints { get; set; }
    }
}
