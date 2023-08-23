//-----------------------------------------------------------------------
// <copyright file="SteeringWheelAnimationPreparer.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used to prepare everything that needs to be made before the steering wheel animation can be executed.
// </summary>
//-----------------------------------------------------------------------

namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This class is used to prepare everything that needs to be made before the steering wheel animation can be executed.
    /// </summary>
    public class SteeringWheelAnimationPreparer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SteeringWheelAnimationPreparer" /> class. 
        /// </summary>
        /// <param name="steeringWheelPointsXY"> The list of function draw animation point onto which the steering wheel should move along on.</param>
        /// <param name="curvatureForPoints"> The list of curvature values the image should be rotated for.</param>
        /// <param name="maxWidthCanvas"> The max width of the canvas onto which the image should be displayed.</param>
        public SteeringWheelAnimationPreparer(List<FunctionDrawInformation> steeringWheelPointsXY, List<double> curvatureForPoints, int maxWidthCanvas) 
        {
            this.FunctionsDrawInfomration = steeringWheelPointsXY;
            this.CurvatureOnPoints = curvatureForPoints;
            this.MaxWidthCanvas = maxWidthCanvas;
        }

        /// <summary>
        /// Gets or sets the max width of the canvas for which to animate the steering wheel for.
        /// </summary>
        /// <value> The maxium width of the currently used canvas.</value>
        private int MaxWidthCanvas { get; set; }

        /// <summary>
        /// Gets or setsa list of Draw information that is used for identfing points for the animation.
        /// </summary>
        /// <value> The Draw information used for the animation.</value>
        private List<FunctionDrawInformation> FunctionsDrawInfomration { get; set; }

        /// <summary>
        /// Gets or sets the list of curvatures for the animation.
        /// </summary>
        /// <value> A List of values indicating the rotation of an image on certain points.</value>
        private List<double> CurvatureOnPoints { get; set; }

        /// <summary>
        /// This method Generates a new List of Canvas Pixel for the current function draw information. It does this by combining all the function draw information given.
        /// </summary>
        /// <returns> A combined list of canvas pixel for the function given.</returns>
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

        /// <summary>
        /// This method combines the points on which the image should be animated on which the list of curvates, that is given to rotate the image, to return a list of animation
        /// points that can be used to animate the steering wheel along the graph with the right rotation.
        /// </summary>
        /// <returns> A list of animation points that contain all the information needed to animate the steering wheel on the canvas.</returns>
        public List<AnimationPointImage> GenerateAnimationPointsWithCurvature()
        {
            List<AnimationPointImage> animationPoints = new List<AnimationPointImage>();
            List<CanvasPixel> fullListOfPixel = this.GenerateOneFunctionDrawInformation();
            List<double> degressTurnsPerPoint = this.GenerateNormalisedTurnsForCurvatureList(this.CurvatureOnPoints);
            // in theory the functiondrawinformation can only contain x values from 0 to how ever big the screen is at the present. In fact the list of double point must be the same size as the screen width. 
            // With this knowledge we can now combine these two list into one list; Points that will not be displayed on the canvas will be set to not visible , so that the animation will always be the same length:      
            for (int i = 0, counterForPixelList = 0; i < this.MaxWidthCanvas; i++)
            {
                if (counterForPixelList < fullListOfPixel.Count)
                {
                    if (fullListOfPixel[counterForPixelList].XAxisValue == i)
                    {
                        // we must move the curser for the pixel list as we found a value that was inside the list.
                        // when the last point was set to be at 0,0 and visiblity was false then the sterring wheel was moved out of bounds, becouse the point should not be visible, to
                        // avoid the currumstance that the animation will look choppy, eg the wheel will fly from the upper left corner to the new point i will
                        // add a fake point to the wheel that starts at the last point but sets the wheel to invisible so that the jump to the new line doesnt look so weird.
                        if (i > 0)
                        {


                            if (animationPoints[i - 1].AnimationPointXY.XAxisValue == 0 && animationPoints[i - 1].AnimationPointXY.YAxisValue == 0 && animationPoints[i - 1].VisibilityOnPoint == false)
                            {
                                animationPoints[i - 1].AnimationPointXY = fullListOfPixel[counterForPixelList];
                            }
                        }
                        animationPoints.Add(new AnimationPointImage(fullListOfPixel[counterForPixelList], degressTurnsPerPoint[i], true));
                        counterForPixelList++;

                    }
                    else
                    {
                        // we add a "fake" point for the animation, and also make the point not visible
                        animationPoints.Add(new AnimationPointImage(new CanvasPixel(0, 0), degressTurnsPerPoint[i], false));
                    }
                }
                else
                {
                    // when the point for x is inside the list the steering wheel has a normal position and is visible, else there is a point where the function is not displayed on the canvas.
                    // we add a "fake" point for the animation, and also make the point not visible
                    animationPoints.Add(new AnimationPointImage(new CanvasPixel(0, 0), degressTurnsPerPoint[i], false));
                }


            }
            // we add a last point for the wheel so it turns invisible after the animation was ended
            CanvasPixel lastPixelInAnimation = animationPoints[animationPoints.Count - 1].AnimationPointXY;
            animationPoints.Add(new AnimationPointImage(lastPixelInAnimation, 0, false));
            animationPoints.Add(new AnimationPointImage(new CanvasPixel(0, 0), 0, false));

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
    }
}
