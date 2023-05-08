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

                //it took me 2 hours to come up with this function, i fucking hope it works
                double yPixelPosition = yPixels - ((yValueForCurrentXValue - yMin) * yPixels / (yMax - yMin));

                //TODO change the exeption message

                if (yPixelPosition < int.MinValue || yPixelPosition > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("Yo there is probably a problem in your function bro");
                }
                //Why isnt there a explixit method that just rounds to long???
                int roundedYPixelPosition = (int)Math.Round(yPixelPosition);


                //only add the pixel if it is inside the y Axis
                if (!(roundedYPixelPosition<0) &&  ! (roundedYPixelPosition>yPixels))
                {
                    PixelValuesForthisFunction.Add(new CanvasPixel(xPixelPosition, roundedYPixelPosition));
                }
                //else
                //    PixelValuesForthisFunction.Add(new CanvasPixel(xPixelPosition, roundedYPixelPosition));
            }
            FunctionDrawInformation drawInformation = new FunctionDrawInformation(PixelValuesForthisFunction, function.FunctionColor);
            return drawInformation;
        }
    }
}