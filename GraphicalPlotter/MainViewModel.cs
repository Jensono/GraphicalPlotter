using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;

namespace GraphicalPlotter
{
    public class MainViewModel : INotifyPropertyChanged
    {

        //add more checks to the properties

        private double textBoxXAxisMin = -10;
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

        private double textBoxXAxisMax = 10;
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



        private double textBoxXAxisGridIntervall = 1;
        public double TextBoxXAxisGridIntervall
        {
            get { return textBoxXAxisGridIntervall; }
            set
            {
                // If the value is above 0 and when there arent more gridlines than the max amount , which is half of all the pixels
                if (value != textBoxXAxisGridIntervall && value > 0 && (((this.TextBoxXAxisMax - this.TextBoxXAxisMin) / value) < (this.PixelWidhtCanvas / 2)))
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

      
        private double textBoxYAxisMin = -10;
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

        private double textBoxYAxisMax = 10;
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




        private double textBoxYAxisGridIntervall = 1;
        public double TextBoxYAxisGridIntervall
        {
            get { return textBoxYAxisGridIntervall; }
            set
            {
                if (value != textBoxYAxisGridIntervall && value > 0 && (((this.TextBoxYAxisMax - this.TextBoxYAxisMin) / value) < (this.PixelHeightCanvas / 2)))
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




        private int pixelWidhtApp = 800;
        public int PixelWidhtApp
        {
            get { return this.PixelWidhtApp; }
            set
            {
                if (value > 0)
                {
                    pixelWidhtApp = value;
                    //this.xPixelWidhtCanvas = (int)Math.Round((680d / 800d) * value);
                    //680

                }
            }
        }

        private int pixelHeightApp = 600;
        public int PixelHeightApp
        {
            get { return this.pixelHeightApp; }
            set
            {
                if (value > 0)
                {
                    pixelHeightApp = value;
                    //380
                    //this.YPixelHeightCanvas = (int)Math.Round((380d / 600d) * value);

                }
            }
        }




        private int pixelWidhtCanvas = 630;
        public int PixelWidhtCanvas
        {
            get { return this.pixelWidhtCanvas; }
            set
            {
                if (value > 0)
                {
                    pixelWidhtCanvas = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.PixelWidhtCanvas)));
                }
            }
        }

        private int pixelHeightCanvas = 360;
        public int PixelHeightCanvas
        {
            get { return this.pixelHeightCanvas; }
            set
            {
                if (value > 0)
                {
                    pixelHeightCanvas = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.PixelHeightCanvas)));
                }
            }
        }

        public TwoDimensionalGraphCanvas MainGraphCanvas {get;set;}

        public FunctionToCanvasFunctionConverter CanvasFunctionConverter { get; set; }

        public List<GraphicalFunction> CurrentGraphicalFunctions { get; set; }

        public List<FunctionDrawInformation> DrawInformationForFunctions { get; set; }

        public List<FunctionDrawInformation> DrawInformationForAxis { get; set; }

        public List<FunctionDrawInformation> DrawInformationForGridLines { get; set; }
        public MainViewModel()
        {
            //these values need to be instanct before the grid intervalls or else grid lines will be zero
           

            // FOR THE X - AXIS
            this.TextBoxXAxisMax = 9;
            this.TextBoxXAxisMin = -9;
         
            this.ColorPickerXAxisColor = Colors.DarkSlateBlue;
            this.CheckBoxXAxisVisibility = true;


            this.TextBoxXAxisGridIntervall = Math.PI/2;
            this.ColorPickerXAxisGridColor = Colors.Black;
            this.CheckBoxXAxisGridVisibility = true;


            // FOR THE Y - AXIS
            this.TextBoxYAxisMax = 2;
            this.TextBoxYAxisMin = -2;
            
            this.ColorPickerYAxisColor = Colors.DarkSlateBlue;
            this.CheckBoxYAxisVisibility = true;


            this.TextBoxYAxisGridIntervall = 1;
            this.ColorPickerYAxisGridColor = Colors.Black;
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
            //x^2
            //this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new PolynomialComponent(2, 1) }, Colors.Aquamarine))  ;

            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new SineFunction(1, 1) }, Colors.Black));
            //COS
            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new CosineFunction(1, 1) }, Colors.Red));
            //TAN
            //this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new TangentFunction(1, 1) }, Colors.Green));

            this.UpdateDrawInformationForFunctions();
            this.UpdateDrawInformationForAxis();
            this.UpdateDrawInformationForGridLines();


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

        public void UpdateDrawInformationForAxis()
        {
            List<FunctionDrawInformation> functionDrawInformation = this.CanvasFunctionConverter.CreateFunctionDrawInformationForAxis();



            this.DrawInformationForAxis = functionDrawInformation;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DrawInformationForAxis)));


        }

        public void UpdateDrawInformationForGridLines()
        {
            List<FunctionDrawInformation> functionDrawInformation = this.CanvasFunctionConverter.CreateGridDrawInformation();



            this.DrawInformationForGridLines = functionDrawInformation;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DrawInformationForGridLines)));


        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}