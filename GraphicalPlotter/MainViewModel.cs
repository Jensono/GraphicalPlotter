using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;

namespace GraphicalPlotter
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public double TextBoxXAxisMin { get; set; }
        public double TextBoxXAxisMax {get;set;}
        public bool CheckBoxXAxisVisibility { get; set; }
        public Color ColorPickerXAxisColor { get; set; }


        public double TextboxXAxisGridIntervall { get; set; }
        public Color ColorPickerXAxisGridColor { get; set; }
        public bool CheckBoxXAxisGridVisibility { get; set; }


        public double TextBosYAxisMax { get; set; }
        public double TextBoxYAxisMin { get; set; }
        public bool CheckBoxYAxisVisibility { get; set; }
        public Color ColorPickerYAxisColor { get; set; }


        public double TextboxYAxisGridIntervall { get; set; }
        public Color ColorPickerYAxisGridColor { get; set; }

        public bool CheckBoxYAxisGridVisibility { get; set; }



        public TwoDimensionalGraphCanvas MainGraphCanvas {get;set;}

        public FunctionToCanvasFunctionConverter CanvasFunctionConverter { get; set; }

        public List<GraphicalFunction> CurrentGraphicalFunctions { get; set; }
        public MainViewModel()
        {
            var xAxisData = new AxisData(-10, 10, new Color(), true);
            var yAxisData = new AxisData(-10, 10, new Color(), true);
            var xAxisGrid = new AxisGridData(2, new Color(), true);
            var yAxisGrid = new AxisGridData(2, new Color(), true);

            this.MainGraphCanvas = new TwoDimensionalGraphCanvas(600, 400, xAxisData, yAxisData, xAxisGrid, yAxisGrid);
            this.CanvasFunctionConverter = new FunctionToCanvasFunctionConverter(this.MainGraphCanvas);

            this.CurrentGraphicalFunctions = new List<GraphicalFunction>();
            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new PolynomialComponent(2, 1) }, Color.FromArgb(100,100,100,100))); ;
            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new SineFunction(1, 1) }, Color.FromArgb(100, 100, 50, 50)));
            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new CosineFunction(1, 1) }, Color.FromArgb(100, 50, 50, 100)));
            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new TangentFunction(1, 1) }, Color.FromArgb(100, 50, 150, 100)));


            //here comes the complete logic for this application
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}