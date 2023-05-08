using System;
using System.Collections.Generic;

namespace GraphicalPlotter
{
    public class FunctionToCanvasFunctionConverter
    {
        public TwoDimensionalGraphCanvas GraphicalCanvas { get; set; }

        public FunctionToCanvasFunctionConverter(TwoDimensionalGraphCanvas graphCanvas)
        {
            this.GraphicalCanvas = graphCanvas;
        }

        // Prb need a lock here to read the information
        // List prp also needs to be a observerableCollection
        public List<FunctionDrawInformation> ConvertAllCurrentFunctionsIntoDrawData(List<GraphicalFunction> listOfFunctions)
        {
            List<FunctionDrawInformation> functionsDrawInformation = new List<FunctionDrawInformation>();
            foreach (GraphicalFunction function in listOfFunctions)
            {
                functionsDrawInformation.Add(this.ConvertFunctionIntoDrawInformation(function));
            }

            return functionsDrawInformation;
        }

        //PRIVATE ?
        public FunctionDrawInformation ConvertFunctionIntoDrawInformation(GraphicalFunction function)
        {
            int xPixels = this.GraphicalCanvas.WidthInPixel;
            int yPixels = this.GraphicalCanvas.HeightInPixel;
            double xMax = this.GraphicalCanvas.XAxisData.MaxVisibleValue;
            double xMin = this.GraphicalCanvas.XAxisData.MinVisibleValue;
            double yMax = this.GraphicalCanvas.YAxisData.MaxVisibleValue;
            double yMin = this.GraphicalCanvas.YAxisData.MinVisibleValue;

            List<CanvasPixel> PixelValuesForthisFunction = new List<CanvasPixel>();

            for (int xPixelPosition = 0; xPixelPosition < xPixels; xPixelPosition++)
            {
                double xCalculationIntervall = (xMax - xMin) / xPixels;
                double xValueForCurrentPixel = xMin + (xPixelPosition * xCalculationIntervall);
                double yValueForCurrentXValue = function.CalculateSumOfAllPartsForValue(xValueForCurrentPixel);

                int roundedYPixelPosition = this.CalculateYPixelPositionForYValue(yPixels, yValueForCurrentXValue, yMin, yMax);
                //only add the pixel if it is inside the y Axis

                //if (!(roundedYPixelPosition<0) &&  ! (roundedYPixelPosition>yPixels))
                //{
                PixelValuesForthisFunction.Add(new CanvasPixel(xPixelPosition, roundedYPixelPosition));
                //}

                //else
                //    PixelValuesForthisFunction.Add(new CanvasPixel(xPixelPosition, roundedYPixelPosition));
            }
            FunctionDrawInformation drawInformation = new FunctionDrawInformation(PixelValuesForthisFunction, function.FunctionColor);
            return drawInformation;
        }

        public int CalculateYPixelPositionForYValue(int yPixels, double yValue, double yMin, double yMax)
        {
            //it took me 2 hours to come up with this function, i fucking hope it works
            double yPixelPosition = yPixels - ((yValue - yMin) * yPixels / (yMax - yMin));

            //TODO change the exeption message
            // A function could, in theory have such a drastic change in the y axis that this problem could occur
            //TODO find a fix that just draws the first few lines of the functions.
            if (yPixelPosition < int.MinValue)
            {
                yPixelPosition = int.MinValue;
                //THIS IS just a hotfix for functions like tan , i just got an error in here before so im changing it to that
                //throw new ArgumentOutOfRangeException("Yo there is probably a problem in your function bro");
            }
            else if (yPixelPosition > int.MaxValue)
            {
                yPixelPosition = int.MaxValue;
            }

            //Why isnt there a explixit method that just rounds to int or long???
            return (int)Math.Round(yPixelPosition);
        }

        public List<FunctionDrawInformation> CreateFunctionDrawInformationForAxis()
        {
            List<FunctionDrawInformation> axisLines = new List<FunctionDrawInformation>();

            int xPixels = this.GraphicalCanvas.WidthInPixel;
            int yPixels = this.GraphicalCanvas.HeightInPixel;
            double xMax = this.GraphicalCanvas.XAxisData.MaxVisibleValue;
            double xMin = this.GraphicalCanvas.XAxisData.MinVisibleValue;
            double yMax = this.GraphicalCanvas.YAxisData.MaxVisibleValue;
            double yMin = this.GraphicalCanvas.YAxisData.MinVisibleValue;

            //First we add the x axis, obv the x-axis needs to go from the left most x pixel to the last one. For where it is placed on the y axis we just find that out by
            //using the function to calculate a y pixel for a y value, for the x-axis the y value is zero.

            int yPixelValueForXAxis = this.CalculateYPixelPositionForYValue(yPixels, 0, yMin, yMax);
            //only if the x-axis is visible we add it to be displayed
            if (yPixelValueForXAxis >= 0 && yPixelValueForXAxis <= yPixels)
            {
                List<CanvasPixel> axisPoints = new List<CanvasPixel>() { new CanvasPixel(0, yPixelValueForXAxis), new CanvasPixel(xPixels, yPixelValueForXAxis) };
                FunctionDrawInformation DrawInformationXAxis = new FunctionDrawInformation(axisPoints, this.GraphicalCanvas.XAxisData.AxisColor);
                axisLines.Add(DrawInformationXAxis);
            }

            int xPixelValueForYAxis = this.CalculateXPixelPositionForXValue(xPixels, 0, xMin, xMax);

            //only if the y-axis is visible we add it to be displayed
            int correctedXPixelValueForYAxis = xPixels - xPixelValueForYAxis;
            if (correctedXPixelValueForYAxis >= 0 && correctedXPixelValueForYAxis <= xPixels)
            {
                List<CanvasPixel> axisPoints = new List<CanvasPixel>() { new CanvasPixel(correctedXPixelValueForYAxis, 0), new CanvasPixel(correctedXPixelValueForYAxis, yPixels) };
                FunctionDrawInformation DrawInformationXAxis = new FunctionDrawInformation(axisPoints, this.GraphicalCanvas.XAxisData.AxisColor);
                axisLines.Add(DrawInformationXAxis);
            }
            return axisLines;
        }

        public List<FunctionDrawInformation> CreateGridDrawInformation()        
        {
            int xPixels = this.GraphicalCanvas.WidthInPixel;
            int yPixels = this.GraphicalCanvas.HeightInPixel;
            double xMax = this.GraphicalCanvas.XAxisData.MaxVisibleValue;
            double xMin = this.GraphicalCanvas.XAxisData.MinVisibleValue;
            double yMax = this.GraphicalCanvas.YAxisData.MaxVisibleValue;
            double yMin = this.GraphicalCanvas.YAxisData.MinVisibleValue;
            double xGridInterval = this.GraphicalCanvas.XAxisGridData.IntervallBetweenLines;
            double yGridInterval = this.GraphicalCanvas.YAxisGridData.IntervallBetweenLines;


            //for the grid lines lying on the x-axis

            double numberOfGridLinesForXAxis = (xMax - xMin) / xGridInterval;

            List<FunctionDrawInformation> gridLines = new List<FunctionDrawInformation>();
            if (numberOfGridLinesForXAxis > 0)
            {
               
                int roundingPosition = Math.lo 


            }




        }

        // TODO ; THIS CALCULATION IS MAYBE wrong AND I NEED TO ADD (xPixel- n) , n beeing the result i have right now at the end.
        public int CalculateXPixelPositionForXValue(int xPixels, double xValue, double xMin, double xMax)
        {
            double xPixelPosition = xPixels - ((xValue - xMin) * xPixels / (xMax - xMin)); //Changed minus to plus

            //TODO change the exeption message
            // A function could, in theory have such a drastic change in the y axis that this problem could occur
            //TODO find a fix that just draws the first few lines of the functions.
            if (xPixelPosition < int.MinValue || xPixelPosition > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException("Yo there is probably a problem in your function bro");
            }
            //Why isnt there a explixit method that just rounds to int or long???
            return (int)Math.Round(xPixelPosition);
        }
    }
}