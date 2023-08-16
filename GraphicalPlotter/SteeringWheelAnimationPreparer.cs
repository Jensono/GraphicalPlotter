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
                if (counterForPixelList<fullListOfPixel.Count)
                {
                    if (fullListOfPixel[counterForPixelList].XAxisValue == i)
                    {
                        // we must move the curser for the pixel list as we found a value that was inside the list.
                        // when the last point was set to be at 0,0 and visiblity was false then the sterring wheel was moved out of bounds, becouse the point should not be visible, to
                        // avoid the currumstance that the animation will look choppy, eg the wheel will fly from the upper left corner to the new point i will
                        // add a fake point to the wheel that starts at the last point but sets the wheel to invisible so that the jump to the new line doesnt look so weird.
                        if (i>0)
                        {

                        
                        if (animationPoints[i-1].AnimationPointXY.XAxisValue==0 && animationPoints[i - 1].AnimationPointXY.YAxisValue == 0 && animationPoints[i - 1].VisibilityOnPoint==false)
                        {
                            animationPoints[i - 1].AnimationPointXY = fullListOfPixel[counterForPixelList];
                        }
                        }
                        animationPoints.Add(new AnimationPointImage(fullListOfPixel[counterForPixelList], DegressTurnsPerPoint[i], true));
                        counterForPixelList++;

                    }
                    else
                    {
                        // we add a "fake" point for the animation, and also make the point not visible
                        animationPoints.Add(new AnimationPointImage(new CanvasPixel(0, 0), DegressTurnsPerPoint[i], false));
                    }
                }              // when the point for x is inside the list the steering wheel has a normal position and is visible, else there is a point where the function is not displayed on the canvas.
                else
                {
                    // we add a "fake" point for the animation, and also make the point not visible
                    animationPoints.Add(new AnimationPointImage(new CanvasPixel(0,0), DegressTurnsPerPoint[i], false)) ;
                }
                

            }
            // we add a last point for the wheel so it turns invisible after the animation was ended
            CanvasPixel lastPixelInAnimation = animationPoints[animationPoints.Count-1].AnimationPointXY;
            animationPoints.Add(new AnimationPointImage(lastPixelInAnimation, 0, false));
            animationPoints.Add(new AnimationPointImage(new CanvasPixel(0,0), 0, false));

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
