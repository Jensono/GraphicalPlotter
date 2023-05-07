using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;

namespace GraphicalPlotter
{
    public class MainViewModel : INotifyPropertyChanged
    {

        TwoDimensionalGraphCanvas MainGraphCanvas {get;set;} 

        FunctionToCanvasFunctionConverter CanvasFunctionConverter { get; set; }

        List<GraphicalFunction> CurrentGraphicalFunctions { get; set; }
        public MainViewModel()
        {
            var xAxisData = new AxisData(-10, 10, new Color(), true);
            var yAxisData = new AxisData(-10, 10, new Color(), true);
            var xAxisGrid = new AxisGridData(2, new Color(), true);
            var yAxisGrid = new AxisGridData(2, new Color(), true);

            this.MainGraphCanvas = new TwoDimensionalGraphCanvas(600, 400, xAxisData, yAxisData, xAxisGrid, yAxisGrid);
            this.CanvasFunctionConverter = new FunctionToCanvasFunctionConverter(this.MainGraphCanvas);

            this.CurrentGraphicalFunctions = new List<GraphicalFunction>();
            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new PolynomialComponent(2, 1) }, new Color()));
            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new SineFunction(1, 1) }, new Color()));
            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new CosineFunction(1, 1) }, new Color()));
            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new TangentFunction(1, 1) }, new Color()));


            //here comes the complete logic for this application
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}