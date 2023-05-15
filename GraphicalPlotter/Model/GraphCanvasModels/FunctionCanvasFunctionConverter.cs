//-----------------------------------------------------------------------
// <copyright file="FunctionCanvasFunctionConverter.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used to convert from a function or a function view model to a class that can be used for drawing a function on a canvas.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;

    public class FunctionToCanvasFunctionConverter
    {
        /// <summary>
        /// The field for the TwoDimensionalGraphCanvas for the Function converter.
        /// </summary>
        private TwoDimensionalGraphCanvas graphicalCanvas;

        public FunctionToCanvasFunctionConverter(TwoDimensionalGraphCanvas graphCanvas)
        {
            this.GraphicalCanvas = graphCanvas;
        }

        /// <summary>
        /// Gets or sets the graphical canvas used inside the function converter.
        /// </summary>
        /// <value> The graphical canvas used inside the function converter.</value>
        /// <example> <see cref="ArgumentNullException"/> is thrown if the given value was null. </example>
        public TwoDimensionalGraphCanvas GraphicalCanvas
        {
            get
            {
                return this.graphicalCanvas;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.GraphicalCanvas)} can not be null!");
                    
                }
                else
                {
                    this.graphicalCanvas = value;
                }
            }
        }

        public List<FunctionDrawInformation> ConvertAllCurrentFunctionsIntoDrawData(List<GraphicalFunction> listOfFunctions)
        {
            List<FunctionDrawInformation> functionsDrawInformation = new List<FunctionDrawInformation>();
            foreach (GraphicalFunction function in listOfFunctions)
            {
                functionsDrawInformation.Add(this.ConvertFunctionIntoDrawInformation(function));
            }

            return functionsDrawInformation;
        }

        public List<FunctionDrawInformation> ConvertFunctionViewModelIntoDrawInformation(GraphicalFunctionViewModel function)
        {
            int xPixels = this.GraphicalCanvas.WidthInPixel;
            int yPixels = this.GraphicalCanvas.HeightInPixel;
            double xMax = this.GraphicalCanvas.XAxisData.MaxVisibleValue;
            double xMin = this.GraphicalCanvas.XAxisData.MinVisibleValue;
            double yMax = this.GraphicalCanvas.YAxisData.MaxVisibleValue;
            double yMin = this.GraphicalCanvas.YAxisData.MinVisibleValue;

            int currentXPixel = 0;

            List<FunctionDrawInformation> drawingPathsForFunction = new List<FunctionDrawInformation>();

            CanvasPixel lastThrownAwayPixel = null;

            while (currentXPixel <= xPixels - 1)
            {
                List<CanvasPixel> pixelValuesForthisPartOfFunction = new List<CanvasPixel>();

                for (int xPixelPosition = currentXPixel; xPixelPosition < xPixels; xPixelPosition++)
                {
                    double xCalculationIntervall = (xMax - xMin) / xPixels;
                    double xValueForCurrentPixel = xMin + (xPixelPosition * xCalculationIntervall);
                    double yValueForCurrentXValue = function.CalculateSumOfAllPartsForValue(xValueForCurrentPixel);

                    int roundedYPixelPosition = this.CalculateYPixelPositionForYValue(yPixels, yValueForCurrentXValue, yMin, yMax);

                    //// if the currently calcualted pixel is not inside the canvas we start making a new drawinformation for that part
                    if (roundedYPixelPosition > yPixels || roundedYPixelPosition < 0)
                    {
                        /// /if this happens begin a new list item but start at the last x pixel for the next loop
                        pixelValuesForthisPartOfFunction.Add(new CanvasPixel(xPixelPosition, roundedYPixelPosition));

                        //// add the last point for this part of function and add the function to the list

                        currentXPixel++;
                        break;
                    }

                    if (lastThrownAwayPixel != null)
                    {
                        pixelValuesForthisPartOfFunction.Add(lastThrownAwayPixel);
                        lastThrownAwayPixel = null;
                    }

                    pixelValuesForthisPartOfFunction.Add(new CanvasPixel(xPixelPosition, roundedYPixelPosition));
                    currentXPixel++;
                }

                //// we will only land here if the function didnt have any values smaller or bigger than the yMax/yMin or if we have reached the last part of the function
                if (pixelValuesForthisPartOfFunction.Count > 1)
                {
                    drawingPathsForFunction.Add(new FunctionDrawInformation(pixelValuesForthisPartOfFunction, function.FunctionColor));
                    //// reset the lastpixel becouse the current functions was closed
                    lastThrownAwayPixel = null;
                }
                else
                {
                    lastThrownAwayPixel = pixelValuesForthisPartOfFunction[0];
                }
            }

            return drawingPathsForFunction;
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

            //// First we add the x axis, obv the x-axis needs to go from the left most x pixel to the last one. For where it is placed on the y axis we just find that out by
            //// using the function to calculate a y pixel for a y value, for the x-axis the y value is zero.
            //// only if the axis are visible we will calculate them , otherwise , weird things will happen

            if (yMax >= 0 && yMin <= 0 && xAxisVisbility)
            {
                int yPixelValueForXAxis = this.CalculateYPixelPositionForYValue(yPixels, 0, yMin, yMax);

                List<CanvasPixel> axisPoints = new List<CanvasPixel>() { new CanvasPixel(0, yPixelValueForXAxis), new CanvasPixel(xPixels, yPixelValueForXAxis) };
                FunctionDrawInformation drawInformationXAxis = new FunctionDrawInformation(axisPoints, this.GraphicalCanvas.XAxisData.AxisColor);
                axisLines.Add(drawInformationXAxis);
            }
            //// only if the axis are visible we will calculate them , otherwise , weird things will happen

            if (xMax >= 0 && xMin <= 0 && yAxisVisbility)
            {
                int xPixelValueForYAxis = this.CalculateXPixelPositionForXValue(xPixels, 0, xMin, xMax);

                List<CanvasPixel> axisPoints = new List<CanvasPixel>() { new CanvasPixel(xPixelValueForYAxis, 0), new CanvasPixel(xPixelValueForYAxis, yPixels) };
                FunctionDrawInformation drawInformationXAxis = new FunctionDrawInformation(axisPoints, this.GraphicalCanvas.YAxisData.AxisColor);
                axisLines.Add(drawInformationXAxis);
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

            //// for the grid lines that cross the x-axis

            double numberOfGridLinesForXAxis = (xMax - xMin) / xGridInterval;
            double numberOfGridLinesForYAxis = (yMax - yMin) / yGridInterval;

            List<FunctionDrawInformation> gridLines = new List<FunctionDrawInformation>();

            //// ONYL FOR THE Y AXIS GRID

            if (numberOfGridLinesForYAxis > 0 && numberOfGridLinesForYAxis < yPixels / 2 && yGridVisbility)
            {
                double howManyGridsAwayFromXAxis = yMin / yGridInterval;
                int yAxisGridStartIndex;

                //// if it is less then zero we still need to round up but to the next smaller number, so we use floor
                if (howManyGridsAwayFromXAxis < 0)
                {
                    //// we move one full number down
                    yAxisGridStartIndex = (int)Math.Floor(howManyGridsAwayFromXAxis);
                }
                else
                {
                    yAxisGridStartIndex = (int)Math.Ceiling(howManyGridsAwayFromXAxis);
                }

                //// as long as we havent reached yMax yet we still nee to add more intervalls
                for (double i = yAxisGridStartIndex; (i * yGridInterval) < yMax; i += 1)
                {
                    double currentYValue = i * yGridInterval;
                    int yPixelForThisGridLine = this.CalculateYPixelPositionForYValue(yPixels, currentYValue, yMin, yMax);
                    var topPixelThisGridLine = new CanvasPixel(0, yPixelForThisGridLine);
                    var bottomPixelThisGridLine = new CanvasPixel(xPixels, yPixelForThisGridLine);

                    gridLines.Add(new FunctionDrawInformation(new List<CanvasPixel>() { topPixelThisGridLine, bottomPixelThisGridLine }, yGridColor));
                }
            }

            //// ONYL FOR THE X AXIS GRID
            if (numberOfGridLinesForXAxis > 0 && numberOfGridLinesForXAxis < xPixels / 2 && xGridVisbility)
            {
                double howManyGridsAwayFromYAxis = xMin / xGridInterval;

                int xAxisGridStartIndex;

                //// if it is less then zero we still need to round up but to the next smaller number, so we use floor
                if (howManyGridsAwayFromYAxis < 0)
                {
                    //// we move one full number down
                    xAxisGridStartIndex = (int)Math.Floor(howManyGridsAwayFromYAxis);
                }
                else
                {
                    xAxisGridStartIndex = (int)Math.Ceiling(howManyGridsAwayFromYAxis);
                }
                //// if it is less then zero we still need to round up but to the next smaller number, so we use floor

                //// as long as we havent reached yMax yet we still nee to add more intervalls
                for (double i = xAxisGridStartIndex; (i * xGridInterval) < xMax; i += 1)
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

        [Obsolete]
        private double GetGridStartingPostionForGridIntervalAndMinValue(double minValue, double gridInterval, bool isMinAndMaxSmallerThanZero)
        {
            double logExponendForGridIntervall = Math.Log10(gridInterval);
            double roundedStartingValue;

            if (logExponendForGridIntervall >= 1)
            {
                //// log is bigger then zero
                double newGridLog = Math.Ceiling(logExponendForGridIntervall);
                double startingValueForXnotRounded = Math.Abs(minValue) / Math.Pow(10, newGridLog);
                roundedStartingValue = Math.Ceiling(startingValueForXnotRounded) * Math.Pow(10, newGridLog);
            }
            else if (logExponendForGridIntervall >= 0)
            {
                //// else if bigger then zero but smaller then one
                double newGridLog = 0;
                double startingValueForXnotRounded = Math.Abs(minValue) / Math.Pow(10, newGridLog);
                roundedStartingValue = Math.Ceiling(startingValueForXnotRounded) * Math.Pow(10, newGridLog);
            }
            else
            {
                //// if the log is negativ but smaller then -1
                int newGridLog = (int)Math.Ceiling(Math.Abs(logExponendForGridIntervall));
                roundedStartingValue = Math.Round(minValue, newGridLog);
            }

            if (minValue < 0 && !isMinAndMaxSmallerThanZero)
            {
                roundedStartingValue *= -1;
            }

            return roundedStartingValue;
        }

        private FunctionDrawInformation ConvertFunctionIntoDrawInformation(GraphicalFunction function)
        {
            int xPixels = this.GraphicalCanvas.WidthInPixel;
            int yPixels = this.GraphicalCanvas.HeightInPixel;
            double xMax = this.GraphicalCanvas.XAxisData.MaxVisibleValue;
            double xMin = this.GraphicalCanvas.XAxisData.MinVisibleValue;
            double yMax = this.GraphicalCanvas.YAxisData.MaxVisibleValue;
            double yMin = this.GraphicalCanvas.YAxisData.MinVisibleValue;

            List<CanvasPixel> pixelValuesForthisFunction = new List<CanvasPixel>();

            for (int xPixelPosition = 0; xPixelPosition < xPixels; xPixelPosition++)
            {
                double xCalculationIntervall = (xMax - xMin) / xPixels;
                double xValueForCurrentPixel = xMin + (xPixelPosition * xCalculationIntervall);
                double yValueForCurrentXValue = function.CalculateSumOfAllPartsForValue(xValueForCurrentPixel);

                int roundedYPixelPosition = this.CalculateYPixelPositionForYValue(yPixels, yValueForCurrentXValue, yMin, yMax);

                pixelValuesForthisFunction.Add(new CanvasPixel(xPixelPosition, roundedYPixelPosition));
            }

            FunctionDrawInformation drawInformation = new FunctionDrawInformation(pixelValuesForthisFunction, function.FunctionColor);
            return drawInformation;
        }

        private int CalculateYPixelPositionForYValue(int yPixels, double yValue, double yMin, double yMax)
        {
            /// /it took me 2 hours to come up with this function, i fucking hope it works

            double yPixelPosition = yPixels - ((yValue - yMin) * yPixels / (yMax - yMin));

            //// TODO find a better solution than this, if there is one
            //// A function could, in theory have such a drastic change in the y axis that this problem could occur
            if (yPixelPosition < int.MinValue)
            {
                yPixelPosition = int.MinValue;
            }
            else if (yPixelPosition > int.MaxValue)
            {
                yPixelPosition = int.MaxValue;
            }

            //// Why isnt there a explixit method that just rounds to int or long???
            return (int)Math.Round(yPixelPosition);
        }

        private int CalculateXPixelPositionForXValue(int xPixels, double xValue, double xMin, double xMax)
        {
            double xPixelPosition = xPixels - ((xValue - xMin) * xPixels / (xMax - xMin));

            //// TODO delete the execption message and copy the same thing i did for the y value calculation
            //// A function could, in theory have such a drastic change in the y axis that this problem could occur
            //// TODO find a fix that just draws the first few lines of the functions.
            if (xPixelPosition < int.MinValue || xPixelPosition > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException("Yo there is probably a problem in your function bro");
            }

            return xPixels - (int)Math.Round(xPixelPosition);
        }
    }
}