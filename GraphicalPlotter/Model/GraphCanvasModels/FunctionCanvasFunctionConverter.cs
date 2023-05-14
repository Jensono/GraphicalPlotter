using System;
using System.Collections.Generic;
using System.Windows.Media;

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

        //PRIVATE 
        // 
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

        public FunctionDrawInformation ConvertFunctionViewModelIntoDrawInformation(GraphicalFunctionViewModel function)
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
            bool xAxisVisbility = this.GraphicalCanvas.XAxisData.Visibility;
            bool yAxisVisbility = this.GraphicalCanvas.YAxisData.Visibility;

            //First we add the x axis, obv the x-axis needs to go from the left most x pixel to the last one. For where it is placed on the y axis we just find that out by
            //using the function to calculate a y pixel for a y value, for the x-axis the y value is zero.
            //only if the axis are visible we will calculate them , otherwise , weird things will happen

            if (yMax >= 0 && yMin <= 0 && xAxisVisbility)
            {
                int yPixelValueForXAxis = this.CalculateYPixelPositionForYValue(yPixels, 0, yMin, yMax);
                //only if the x-axis is visible we add it to be displayed
                //if (yPixelValueForXAxis >= 0 && yPixelValueForXAxis <= yPixels)
                //{
                List<CanvasPixel> axisPoints = new List<CanvasPixel>() { new CanvasPixel(0, yPixelValueForXAxis), new CanvasPixel(xPixels, yPixelValueForXAxis) };
                FunctionDrawInformation DrawInformationXAxis = new FunctionDrawInformation(axisPoints, this.GraphicalCanvas.XAxisData.AxisColor);
                axisLines.Add(DrawInformationXAxis);
                //}
            }
            //only if the axis are visible we will calculate them , otherwise , weird things will happen

            if (xMax >= 0 && xMin <= 0  && yAxisVisbility)
            {
                int xPixelValueForYAxis = this.CalculateXPixelPositionForXValue(xPixels, 0, xMin, xMax);
                //only if the y-axis is visible we add it to be displayed

                //if (correctedXPixelValueForYAxis >= 0 && correctedXPixelValueForYAxis <= xPixels)
                //{
                List<CanvasPixel> axisPoints = new List<CanvasPixel>() { new CanvasPixel(xPixelValueForYAxis, 0), new CanvasPixel(xPixelValueForYAxis, yPixels) };
                FunctionDrawInformation DrawInformationXAxis = new FunctionDrawInformation(axisPoints, this.GraphicalCanvas.YAxisData.AxisColor);
                axisLines.Add(DrawInformationXAxis);
                //}
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
            Color xGridColor = this.GraphicalCanvas.XAxisGridData.GridColor;
            Color yGridColor = this.GraphicalCanvas.YAxisGridData.GridColor;
            bool xGridVisbility = this.GraphicalCanvas.XAxisGridData.Visibility;
            bool yGridVisbility = this.GraphicalCanvas.YAxisGridData.Visibility;

            //for the grid lines lying on the x-axis

            double numberOfGridLinesForXAxis = (xMax - xMin) / xGridInterval;
            double numberOfGridLinesForYAxis = (yMax - yMin) / yGridInterval;

            List<FunctionDrawInformation> gridLines = new List<FunctionDrawInformation>();

            // ONYL FOR THE Y AXIS GRID
            //maybe need to flip the visbility paramters
            if (numberOfGridLinesForYAxis > 0 && numberOfGridLinesForYAxis < yPixels / 2 && yGridVisbility )
            {
                

                double howManyGridsAwayFromXAxis = yMin / yGridInterval;
                int yAxisGridStartIndex;

                //if it is less then zero we still need to round up but to the next smaller number, so we use floor
                if (howManyGridsAwayFromXAxis < 0)
                {
                    //we move one full number down
                    yAxisGridStartIndex = (int)Math.Floor(howManyGridsAwayFromXAxis);
                }
                else
                {
                    yAxisGridStartIndex = (int)Math.Ceiling(howManyGridsAwayFromXAxis);
                }
                



                //as long as we havent reached yMax yet we still nee to add more intervalls
                for (double i = yAxisGridStartIndex; (i * yGridInterval) < yMax; i+=1)
                {
                    double currentYValue = i * yGridInterval;
                    int yPixelForThisGridLine = this.CalculateYPixelPositionForYValue(yPixels, currentYValue, yMin, yMax);
                    var topPixelThisGridLine = new CanvasPixel(0, yPixelForThisGridLine);
                    var bottomPixelThisGridLine = new CanvasPixel(xPixels, yPixelForThisGridLine);

                    gridLines.Add(new FunctionDrawInformation(new List<CanvasPixel>() { topPixelThisGridLine, bottomPixelThisGridLine }, yGridColor));
                }
            }

            // ONYL FOR THE X AXIS GRID
            if (numberOfGridLinesForXAxis > 0 && numberOfGridLinesForXAxis < xPixels / 2 && xGridVisbility)
            {
                




                double howManyGridsAwayFromYAxis = xMin / xGridInterval;

                int xAxisGridStartIndex;

                //if it is less then zero we still need to round up but to the next smaller number, so we use floor
                if (howManyGridsAwayFromYAxis < 0)
                {
                    //we move one full number down
                    xAxisGridStartIndex = (int)Math.Floor(howManyGridsAwayFromYAxis);
                }
                else
                {
                    xAxisGridStartIndex = (int)Math.Ceiling(howManyGridsAwayFromYAxis);
                }
                //if it is less then zero we still need to round up but to the next smaller number, so we use floor

                //as long as we havent reached yMax yet we still nee to add more intervalls
                for (double i = xAxisGridStartIndex; (i * xGridInterval) < xMax; i+=1)
                {
                    double currentXValue = i * xGridInterval;
                    int xPixelForThisGridLine = this.CalculateXPixelPositionForXValue(xPixels, currentXValue, xMin, xMax);
                    var topPixelThisGridLine = new CanvasPixel(xPixelForThisGridLine, 0);
                    var bottomPixelThisGridLine = new CanvasPixel(xPixelForThisGridLine, yPixels);

                    gridLines.Add(new FunctionDrawInformation(new List<CanvasPixel>() { topPixelThisGridLine, bottomPixelThisGridLine }, xGridColor));
                }
            }
            return gridLines;


        }

        

        private double GetGridStartingPostionForGridIntervalAndMinValue(double MinValue, double GridInterval, bool isMinAndMaxSmallerThanZero)
        {
            double logExponendForGridIntervall = Math.Log10(GridInterval);
            double roundedStartingValue;

            //log is bigger then zero
            if (logExponendForGridIntervall >= 1)
            {
                double newGridLog = Math.Ceiling(logExponendForGridIntervall);
                double startingValueForXnotRounded = Math.Abs(MinValue) / Math.Pow(10, newGridLog);
                roundedStartingValue = Math.Ceiling(startingValueForXnotRounded) * Math.Pow(10, newGridLog);
            }
            //else if bigger then zero but smaller then one
            else if (logExponendForGridIntervall >= 0)
            {
                double newGridLog = 0;
                double startingValueForXnotRounded = Math.Abs(MinValue) / Math.Pow(10, newGridLog);
                roundedStartingValue = Math.Ceiling(startingValueForXnotRounded) * Math.Pow(10, newGridLog);
            }
            //if the log is negativ but smaller then -1
            else
            {
                int newGridLog = (int)Math.Ceiling(Math.Abs(logExponendForGridIntervall));
                roundedStartingValue = Math.Round(MinValue, newGridLog);
            }

            if (MinValue < 0 && !isMinAndMaxSmallerThanZero)
            {
                roundedStartingValue *= -1;
            }
            return roundedStartingValue;
        }

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

            return xPixels - (int)Math.Round(xPixelPosition);
        }
    }
}