using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
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
                    this.UpdateFullCanvas();
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
                    this.UpdateFullCanvas();
                }
            }
        }

        public bool checkBoxXAxisVisibility = true;

        public bool CheckBoxXAxisVisibility
        {
            get { return checkBoxXAxisVisibility; }
            set
            {
                if (value != checkBoxXAxisVisibility)
                {
                    checkBoxXAxisVisibility = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CheckBoxXAxisVisibility)));
                    this.UpdateDrawInformationForAxis();
                }
            }
        }

        //TDOD fields and such for colors after i figure out how to best do this
        private Color colorPickerXAxisColor = Colors.DarkSlateBlue;

        public Color ColorPickerXAxisColor
        {
            get { return colorPickerXAxisColor; }
            set
            {
                if (value != colorPickerXAxisColor)
                {
                    colorPickerXAxisColor = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.ColorPickerXAxisColor)));
                    this.UpdateDrawInformationForAxis();
                }
            }
        }

        private double textBoxXAxisGridIntervall = 2;

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
                    this.UpdateDrawInformationForGridLines();
                }
            }
        }

        private Color colorPickerXAxisGridColor = Colors.LightGray;

        public Color ColorPickerXAxisGridColor
        {
            get { return colorPickerXAxisGridColor; }
            set
            {
                if (value != colorPickerXAxisGridColor)
                {
                    colorPickerXAxisGridColor = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.ColorPickerXAxisGridColor)));
                    this.UpdateDrawInformationForGridLines();
                }
            }
        }

        public bool checkBoxXAxisGridVisibility = true;

        public bool CheckBoxXAxisGridVisibility
        {
            get { return checkBoxXAxisGridVisibility; }
            set
            {
                if (value != checkBoxXAxisGridVisibility)
                {
                    checkBoxXAxisGridVisibility = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CheckBoxXAxisGridVisibility)));
                    this.UpdateDrawInformationForGridLines();
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
                    this.UpdateFullCanvas();
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
                    this.UpdateFullCanvas();
                }
            }
        }

        public bool checkBoxYAxisVisibility = true;

        public bool CheckBoxYAxisVisibility
        {
            get { return checkBoxYAxisVisibility; }
            set
            {
                if (value != checkBoxYAxisVisibility)
                {
                    checkBoxYAxisVisibility = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CheckBoxYAxisVisibility)));
                    this.UpdateDrawInformationForAxis();
                }
            }
        }

        private Color colorPickerYAxisColor = Colors.DarkSlateBlue;

        public Color ColorPickerYAxisColor
        {
            get { return colorPickerYAxisColor; }
            set
            {
                if (value != colorPickerYAxisColor)
                {
                    colorPickerYAxisColor = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.ColorPickerYAxisColor)));
                    this.UpdateDrawInformationForAxis();
                }
            }
        }

        private double textBoxYAxisGridIntervall = 2;

        public double TextBoxYAxisGridIntervall
        {
            get { return textBoxYAxisGridIntervall; }
            set
            {
                if (value != textBoxYAxisGridIntervall && value > 0 && (((this.TextBoxYAxisMax - this.TextBoxYAxisMin) / value) < (this.PixelHeightCanvas / 2)))
                {
                    textBoxYAxisGridIntervall = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxYAxisGridIntervall)));
                    this.UpdateDrawInformationForGridLines();
                }
            }
        }

        private Color colorPickerYAxisGridColor = Colors.LightGray;

        public Color ColorPickerYAxisGridColor
        {
            get { return colorPickerYAxisGridColor; }
            set
            {
                if (value != colorPickerYAxisGridColor)
                {
                    colorPickerYAxisGridColor = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.ColorPickerYAxisGridColor)));
                    this.UpdateDrawInformationForGridLines();
                }
            }
        }

        public bool checkBoxYAxisGridVisibility = true;

        public bool CheckBoxYAxisGridVisibility
        {
            get { return checkBoxYAxisGridVisibility; }
            set
            {
                if (value != checkBoxYAxisGridVisibility)
                {
                    checkBoxYAxisGridVisibility = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CheckBoxYAxisGridVisibility)));
                    this.UpdateDrawInformationForGridLines();
                }
            }
        }

        private int pixelWidhtApp = 800;

        public int PixelWidhtApp
        {
            get { return this.pixelWidhtApp; }
            set
            {
                if (value > 0)
                {
                    pixelWidhtApp = value;
                    this.PixelWidhtCanvas = (int)Math.Round((630d / 800d) * value);
                    //630
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
                    this.PixelHeightCanvas = (int)Math.Round((380d / 600d) * value);
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
                    this.UpdateFullCanvas();
                }
            }
        }

        private int pixelHeightCanvas = 380;

        public int PixelHeightCanvas
        {
            get { return this.pixelHeightCanvas; }
            set
            {
                if (value > 0)
                {
                    pixelHeightCanvas = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.PixelHeightCanvas)));
                    this.UpdateFullCanvas();
                }
            }
        }

        public TwoDimensionalGraphCanvas MainGraphCanvas { get; set; }

        public FunctionToCanvasFunctionConverter CanvasFunctionConverter { get; set; }

        //TODO do i actually need the lock here???
        private ObservableCollection<GraphicalFunction> currentGraphicalFunctions;

        public ObservableCollection<GraphicalFunction> CurrentGraphicalFunctions
        {
            get
            {
                lock (this.lockObjectFunctions)
                {
                    return this.currentGraphicalFunctions;
                }
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException($"{nameof(CurrentGraphicalFunctions)} can not be null");
                }
                else
                {
                    lock (this.lockObjectFunctions)
                    {
                        this.currentGraphicalFunctions = value;
                    }
                }
            }
        }

        private List<FunctionDrawInformation> drawInformationForFunctions;

        public List<FunctionDrawInformation> DrawInformationForFunctions
        {
            get
            {
                lock (this.lockObjectFunctions)
                {
                    return this.drawInformationForFunctions;
                }
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException($"{nameof(DrawInformationForFunctions)} can not be null");
                }
                else
                {
                    lock (this.lockObjectFunctions)
                    {
                        this.drawInformationForFunctions = value;
                    }
                }
            }
        }

        private List<FunctionDrawInformation> drawInformationForAxis;

        public List<FunctionDrawInformation> DrawInformationForAxis
        {
            get
            {
                lock (this.lockObjectFunctions)
                {
                    return this.drawInformationForAxis;
                }
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException($"{nameof(DrawInformationForAxis)} can not be null");
                }
                else
                {
                    lock (this.lockObjectFunctions)
                    {
                        this.drawInformationForAxis = value;
                    }
                }
            }
        }

        private List<FunctionDrawInformation> drawInformationForGridLines;

        public List<FunctionDrawInformation> DrawInformationForGridLines
        {
            get
            {
                lock (this.lockObjectFunctions)
                {
                    return this.drawInformationForGridLines;
                }
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException($"{nameof(drawInformationForGridLines)} can not be null");
                }
                else
                {
                    lock (this.lockObjectFunctions)
                    {
                        this.drawInformationForGridLines = value;
                    }
                }
            }
        }

        private object lockObjectFunctions = new object();

        public AxisData XAxisData { get; set; }
        public AxisData YAxisData { get; set; }

        public AxisGridData XAxisGrid { get; set; }
        public AxisGridData YAxisGrid { get; set; }
        public StringToFunctionConverter UserInputFunctionConverter { get; set; }

        private string textBoxUserInputFunction = "5*x^2+5";

        public string TextBoxUserInputFunction
        {
            get { return textBoxUserInputFunction; }
            set
            {
                if (value != textBoxUserInputFunction)
                {
                    textBoxUserInputFunction = value;

                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxUserInputFunction)));
                }
            }
        }

        public string TextBoxUserInputFunctionToolTip { get; set; }

        public ICommand AddFunctionCommand
        {
            get
            {
                GraphicalFunction graphicalFunction;
                return new WindowCommand(
                    (obj) =>
                    {
                        return true;
                    },
                    (obj) =>
                    {
                        if (this.UserInputFunctionConverter.ConvertStringToGraphicalFunction(this.TextBoxUserInputFunction, out graphicalFunction))
                        {
                            this.CurrentGraphicalFunctions.Add(graphicalFunction);
                            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CurrentGraphicalFunctions)));
                            this.UpdateDrawInformationForFunctions();
                        }
                    }

                    );
            }
        }

        public ICommand OpenColorPicker
        {
            get
            {
                return new WindowCommand(
                    (obj) =>
                    {
                        return true;
                    },
                    (obj) =>
                    {
                    ColorPickerWindow colorPickerWindow = new ColorPickerWindow();
                    // If a color is selected and the ok button is pressed
                    //maybe add a result bool to the window or the colorpickerrgb
                    if (result == true)
                    {
                            Color selectedColor = colorPickerWindow.SelectedColor;

                        // Set the selected color to the ColorPickerXAxisColor property in the main view model
                        ColorPickerXAxisColor = selectedColor;
                    }

                    );
            }
        }

        public MainViewModel()
        {
            this.TextBoxUserInputFunctionToolTip = "To Input a Function use the right format shown here. Using other formats will yield wrong inputs.\r\n PLEASE NOTE THAT THE NOTATION FOR DECIMALS IS BOUND TO YOUR LOCALICATION! \r\n Supported Functions are : sin,cos,tan and polynomial function up to a exponent degree of 10." +
                                                    "\r\n a3*x^3+a2*x^2+a1*x+c \r\n a*sin(b*x)+c \r\n a*cos(b*x)+c\r\n a*tan(b*x)+c";

            this.XAxisData = new AxisData(this.textBoxXAxisMin, this.TextBoxXAxisMax, this.ColorPickerXAxisColor, this.CheckBoxXAxisVisibility);
            this.YAxisData = new AxisData(this.TextBoxYAxisMin, this.TextBoxYAxisMax, this.ColorPickerYAxisColor, this.CheckBoxYAxisVisibility);
            this.XAxisGrid = new AxisGridData(this.TextBoxXAxisGridIntervall, this.ColorPickerXAxisGridColor, this.CheckBoxXAxisGridVisibility);
            this.YAxisGrid = new AxisGridData(this.TextBoxYAxisGridIntervall, this.ColorPickerYAxisGridColor, this.CheckBoxYAxisGridVisibility);

            //Setting the properties to the start values, also binding them by refernc i hope, i could also try to first initialzie the properties and then make a grid of them

            this.MainGraphCanvas = new TwoDimensionalGraphCanvas(this.PixelWidhtCanvas, this.PixelHeightCanvas, this.XAxisData, this.YAxisData, this.XAxisGrid, this.YAxisGrid);
            this.CanvasFunctionConverter = new FunctionToCanvasFunctionConverter(this.MainGraphCanvas);
            this.UserInputFunctionConverter = new StringToFunctionConverter();

            this.CurrentGraphicalFunctions = new ObservableCollection<GraphicalFunction>();
            //x^2
            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new PolynomialComponent(2, 1) }, Colors.Aquamarine));
            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new PolynomialComponent(3, 1) }, Colors.Orange));

            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new PolynomialComponent(2.5846, -1) }, Colors.Purple));

            this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new PolynomialComponent(-2, 1) }, Colors.GreenYellow));
            //this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new SineFunction(1, 1) }, Colors.Black));
            //COS
            //this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new CosineFunction(1, 1) }, Colors.Red));
            //TAN
            //this.CurrentGraphicalFunctions.Add(new GraphicalFunction(new List<FunctionParts>() { new TangentFunction(1, 1) }, Colors.Green));

            this.UpdateDrawInformationForFunctions();
            this.UpdateDrawInformationForAxis();
            this.UpdateDrawInformationForGridLines();

            BindingOperations.EnableCollectionSynchronization(this.CurrentGraphicalFunctions, this.lockObjectFunctions);
            BindingOperations.EnableCollectionSynchronization(this.DrawInformationForAxis, this.lockObjectFunctions);
            BindingOperations.EnableCollectionSynchronization(this.DrawInformationForGridLines, this.lockObjectFunctions);

            this.PropertyChanged += UpdateCanvasAttributes;

            //here comes the complete logic for this application
        }

        public void UpdateFullCanvas()
        {
            this.UpdateDrawInformationForAxis();

            this.UpdateDrawInformationForFunctions();
            this.UpdateDrawInformationForGridLines();
        }

        // this is utterly retarded but i dont have enough time to think about a better solution
        //omg this is like prp the worst code i have written to date, what else would you use?? Methods for each function?? somekind of Observer class? i dont know please help
        private void UpdateCanvasAttributes(object sender, PropertyChangedEventArgs eventArgs)
        {
            switch (eventArgs.PropertyName)
            {
                // for the x-axis itself
                case nameof(TextBoxXAxisMin):
                    this.XAxisData.MinVisibleValue = this.TextBoxXAxisMin;
                    break;

                case nameof(TextBoxXAxisMax):
                    this.XAxisData.MaxVisibleValue = this.TextBoxXAxisMax;
                    break;

                case nameof(CheckBoxXAxisVisibility):
                    this.XAxisData.Visibility = this.CheckBoxXAxisVisibility;
                    break;

                case nameof(ColorPickerXAxisColor):
                    this.XAxisData.AxisColor = this.ColorPickerXAxisColor;
                    break;

                //for the y-axis itself
                case nameof(TextBoxYAxisMin):
                    this.YAxisData.MinVisibleValue = this.TextBoxYAxisMin;
                    break;

                case nameof(TextBoxYAxisMax):
                    this.YAxisData.MaxVisibleValue = this.TextBoxYAxisMax;
                    break;

                case nameof(CheckBoxYAxisVisibility):
                    this.YAxisData.Visibility = this.CheckBoxYAxisVisibility;
                    break;

                case nameof(ColorPickerYAxisColor):
                    this.YAxisData.AxisColor = this.ColorPickerYAxisColor;
                    break;

                // for the x grid

                case nameof(TextBoxXAxisGridIntervall):
                    this.XAxisGrid.IntervallBetweenLines = this.TextBoxXAxisGridIntervall;
                    break;

                case nameof(ColorPickerXAxisGridColor):
                    this.XAxisGrid.GridColor = this.ColorPickerXAxisGridColor;
                    break;

                case nameof(CheckBoxXAxisGridVisibility):
                    this.XAxisGrid.Visibility = this.CheckBoxXAxisGridVisibility;
                    break;

                // for the y grid

                case nameof(TextBoxYAxisGridIntervall):
                    this.YAxisGrid.IntervallBetweenLines = this.TextBoxYAxisGridIntervall;
                    break;

                case nameof(ColorPickerYAxisGridColor):
                    this.YAxisGrid.GridColor = this.ColorPickerYAxisGridColor;
                    break;

                case nameof(CheckBoxYAxisGridVisibility):
                    this.YAxisGrid.Visibility = this.CheckBoxYAxisGridVisibility;
                    break;

                //For the canvas dimensions
                case nameof(PixelHeightCanvas):
                    this.MainGraphCanvas.HeightInPixel = this.PixelHeightCanvas;
                    break;

                case nameof(PixelWidhtCanvas):
                    this.MainGraphCanvas.WidthInPixel = this.PixelWidhtCanvas;
                    break;

                default:
                    break;
            }
        }

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