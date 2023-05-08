using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;

namespace GraphicalPlotter
{
    public class MainViewModel : INotifyPropertyChanged
    {

        //add more checks to the properties

        private double textBoxXAxisMin;
        public double TextBoxXAxisMin
        {
            get { return textBoxXAxisMin; }
            set
            {
                if (value != textBoxXAxisMin && value < this.TextBoxXAxisMax)
                {
                    textBoxXAxisMin = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxXAxisMin)));
                }
            }
        }

        private double textBoxXAxisMax;
        public double TextBoxXAxisMax
        {
            get { return textBoxXAxisMax; }
            set
            {
                if (value != textBoxXAxisMax && value > this.TextBoxXAxisMin)
                {
                    textBoxXAxisMax = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxXAxisMax)));
                }
            }
        }
        public bool checkBoxXAxisVisibility;
        public bool CheckBoxXAxisVisibility {

            get { return checkBoxXAxisVisibility; }
            set
            {
                if (value != checkBoxXAxisVisibility)
                {
                    checkBoxXAxisVisibility = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CheckBoxXAxisVisibility)));
                }
            }
        }

        //TDOD fields and such for colors after i figure out how to best do this
        public Color ColorPickerXAxisColor { get; set; }



        private double textBoxXAxisGridIntervall;
        public double TextBoxXAxisGridIntervall
        {
            get { return textBoxXAxisGridIntervall; }
            set
            {
                if (value != textBoxXAxisGridIntervall && value > 0)
                {
                    textBoxXAxisGridIntervall = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxXAxisGridIntervall)));
                }
            }
        }
        
        public Color ColorPickerXAxisGridColor { get; set; }


        public bool checkBoxXAxisGridVisibility;
        public bool CheckBoxXAxisGridVisibility
        {
            get { return checkBoxXAxisGridVisibility; }
            set
            {
                if (value != checkBoxXAxisGridVisibility)
                {
                    checkBoxXAxisGridVisibility = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CheckBoxXAxisGridVisibility)));
                }
            }
        }

      
        private double textBoxYAxisMin;
        public double TextBoxYAxisMin
        {
            get { return textBoxYAxisMin; }
            set
            {
                if (value != textBoxYAxisMin && value < this.TextBoxYAxisMax)
                {
                    textBoxYAxisMin = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxYAxisMin)));
                }
            }
        }

        private double textBoxYAxisMax;
        public double TextBoxYAxisMax
        {
            get { return textBoxYAxisMax; }
            set
            {
                if (value != textBoxYAxisMax && value > this.TextBoxXAxisMin)
                {
                    textBoxYAxisMax = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxYAxisMax)));
                }
            }
        }

        public bool checkBoxYAxisVisibility;

        public bool CheckBoxYAxisVisibility {
            get { return checkBoxYAxisVisibility; }
            set
            {
                if (value != checkBoxYAxisVisibility)
                {
                    checkBoxYAxisVisibility = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CheckBoxYAxisVisibility)));
                }
            }
        }


        
        public Color ColorPickerYAxisColor { get; set; }




        private double textBoxYAxisGridIntervall;
        public double TextBoxYAxisGridIntervall
        {
            get { return textBoxYAxisGridIntervall; }
            set
            {
                if (value != textBoxYAxisGridIntervall && value > 0)
                {
                    textBoxYAxisGridIntervall = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxYAxisGridIntervall)));
                }
            }
        }



        public Color ColorPickerYAxisGridColor { get; set; }




        public bool checkBoxYAxisGridVisibility;

        public bool CheckBoxYAxisGridVisibility
        {
            get { return checkBoxYAxisGridVisibility; }
            set
            {
                if (value != checkBoxYAxisGridVisibility)
                {
                    checkBoxYAxisGridVisibility = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CheckBoxYAxisGridVisibility)));
                }
            }
        }



        public TwoDimensionalGraphCanvas MainGraphCanvas {get;set;}

        public FunctionToCanvasFunctionConverter CanvasFunctionConverter { get; set; }

        public List<GraphicalFunction> CurrentGraphicalFunctions { get; set; }

        public List<FunctionDrawInformation> DrawInformationForFunctions { get; set; }
        public MainViewModel()
        {

            // FOR THE X - AXIS
            this.TextBoxXAxisMin = -10;
            this.TextBoxXAxisMax = 10;
            this.ColorPickerXAxisColor = Color.FromRgb(150, 150, 150);
            this.CheckBoxXAxisVisibility = true;


            this.TextBoxXAxisGridIntervall = 2;
            this.ColorPickerXAxisGridColor = Color.FromRgb(150, 150, 150);
            this.CheckBoxXAxisGridVisibility = true;


            // FOR THE Y - AXIS
            this.TextBoxYAxisMin = -10;
            this.TextBoxYAxisMax = 10;
            this.ColorPickerYAxisColor = Color.FromRgb(150, 150, 150);
            this.CheckBoxYAxisVisibility = true;


            this.TextBoxYAxisGridIntervall = 2;
            this.ColorPickerYAxisGridColor = Color.FromRgb(150, 150, 150);
            this.CheckBoxYAxisGridVisibility = true;


            //maybe move them to properties and fields

            var xAxisData = new AxisData(this.TextBoxXAxisMin, this.TextBoxXAxisMax, this.ColorPickerXAxisColor, this.checkBoxXAxisVisibility);
            var yAxisData = new AxisData(this.TextBoxYAxisMin, this.TextBoxYAxisMax, this.ColorPickerYAxisColor, this.checkBoxYAxisVisibility);
            var xAxisGrid = new AxisGridData(this.TextBoxXAxisGridIntervall, this.ColorPickerXAxisGridColor, this.CheckBoxXAxisGridVisibility);
            var yAxisGrid = new AxisGridData(this.TextBoxYAxisGridIntervall, this.ColorPickerYAxisGridColor, this.CheckBoxYAxisGridVisibility);


            //Setting the properties to the start values, also binding them by refernc i hope, i could also try to first initialzie the properties and then make a grid of them

          






            this.MainGraphCanvas = new TwoDimensionalGraphCanvas(600, 400, xAxisData, yAxisData, xAxisGrid, yAxisGrid);
            this.CanvasFunctionConverter = new FunctionToCanvasFunctionConverter(this.MainGraphCanvas);

            this.CurrentGraphicalFunctions = new List<GraphicalFunction>();
            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new PolynomialComponent(2, 1) }, Color.FromArgb(100,100,100,100))); ;
            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new SineFunction(1, 1) }, Color.FromArgb(100, 100, 50, 50)));
            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new CosineFunction(1, 1) }, Color.FromArgb(100, 50, 50, 100)));
            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new TangentFunction(1, 1) }, Color.FromArgb(100, 50, 150, 100)));

            this.UpdateDrawInformationForFunctions();


            //here comes the complete logic for this application
        }
        //TODO
        //this method need to be called if ANY Changes for the grid or axis attributes occurs
        public void UpdateDrawInformationForFunctions() 
        {
            List<FunctionDrawInformation> functionDrawInformation = new List<FunctionDrawInformation>();

            foreach (GraphicalFunction function in this.CurrentGraphicalFunctions)
            {
                functionDrawInformation.Add(this.CanvasFunctionConverter.ConvertFunctionIntoDrawInformation(function));
            }

            this.DrawInformationForFunctions = functionDrawInformation;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DrawInformationForFunctions)));

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}