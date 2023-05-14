using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;

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
                if (value != textBoxYAxisMax && value > this.TextBoxYAxisMin)
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

        private int pixelWidhtApp = 900;

        public int PixelWidhtApp
        {
            get { return this.pixelWidhtApp; }
            set
            {
                if (value > 0)
                {
                    pixelWidhtApp = value;
                    //900-630
                    this.PixelWidhtCanvas = value - 270;
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
                    //600-380
                    this.PixelHeightCanvas = value - 220;
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
        private ObservableCollection<GraphicalFunctionViewModel> currentGraphicalFunctions;

        public ObservableCollection<GraphicalFunctionViewModel> CurrentGraphicalFunctions
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
        public StringToFunctionConverter StringToFunctionConverter { get; set; }

        //just to give the user a hint how a correctly formated function looks.
        private string textBoxUserInputFunction = "5*x^2-sin(3x)+5";

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
                        if (this.StringToFunctionConverter.ConvertStringToGraphicalFunction(this.TextBoxUserInputFunction, out graphicalFunction))
                        {
                            GraphicalFunctionViewModel functionVM = new GraphicalFunctionViewModel(graphicalFunction);
                            this.AddFunctionToCurrentFunction(functionVM);

                            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CurrentGraphicalFunctions)));
                            this.UpdateDrawInformationForFunctions();
                        }
                    }

                    );
            }
        }

        private void AddFunctionToCurrentFunction(GraphicalFunctionViewModel functionVM)
        {
            this.CurrentGraphicalFunctions.Add(functionVM);

            functionVM.OnUserFunctionChanged += new EventHandler<UserInputFunctionChangedEventArgs>(this.UpdateDrawInformationForFunctions);
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
                        colorPickerWindow.ShowDialog();
                        // If a color is selected and the ok button is pressed
                        if (colorPickerWindow.isColorPicked == true)
                        {
                            //UNSAFE AS FUCK PLEASE FIX TODO TODO TODO
                            string propertyName = (string)obj;

                            //i know that i could use the propertyInfo for this, but im not sure if we are allowed to use it.
                            //PropertyInfo property = this.GetType().GetProperty(propertyName);
                            //if (property != null && property.CanWrite)
                            //{
                            //    property.SetValue(this, selectedColor.Color);
                            //}

                            // dumb design that i need to convert 2 times but not enough time to fix this TODO
                            Color selectedColor = colorPickerWindow.SelectedColor.Color;

                            switch (propertyName)
                            {
                                case "ColorPickerXAxisColor":
                                    this.ColorPickerXAxisColor = selectedColor;
                                    break;

                                case "ColorPickerYAxisColor":
                                    this.ColorPickerYAxisColor = selectedColor;
                                    break;

                                case "ColorPickerXAxisGridColor":
                                    this.ColorPickerXAxisGridColor = selectedColor;
                                    break;

                                case "ColorPickerYAxisGridColor":
                                    this.ColorPickerYAxisGridColor = selectedColor;
                                    break;

                                default:
                                    break;
                            }

                            // Set the selected color to the ColorPickerXAxisColor property in the main view model
                            //this.ColorPickerXAxisColor =  selectedColor.Color;
                        }
                    }

                    );
            }
        }

        public ICommand SaveFunctionsToFile
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
                        if (this.CurrentGraphicalFunctions.Count >= 1)
                        {
                            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<GraphicalFunctionDisplayNameForSerialization>));

                            List<GraphicalFunctionDisplayNameForSerialization> functionsForSerialization = this.CreateSerialiationObjectsFromCurrentFunctions();

                            //TODO TEST THIS SHIT
                            SaveFileDialog dialog = new SaveFileDialog();

                            dialog.Filter = "XML Files (*.xml)|*.xml";
                            dialog.FileName = "functions";

                            if (dialog.ShowDialog() == true)
                            {
                                using (FileStream fileStream = new FileStream(dialog.FileName, FileMode.Create))
                                {
                                    xmlSerializer.Serialize(fileStream, functionsForSerialization);
                                }
                            }
                        }
                    }

                    );
            }
        }

        private List<GraphicalFunctionDisplayNameForSerialization> CreateSerialiationObjectsFromCurrentFunctions()
        {
            List<GraphicalFunctionDisplayNameForSerialization> functionsForSerialization = new List<GraphicalFunctionDisplayNameForSerialization>();
            foreach (GraphicalFunctionViewModel functionVM in this.CurrentGraphicalFunctions)
            {
                functionsForSerialization.Add(new GraphicalFunctionDisplayNameForSerialization(functionVM));
            }
            return functionsForSerialization;
        }

        public ICommand InportFunctionsFromFile
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
                        List<GraphicalFunctionDisplayNameForSerialization> deserializedFunctions = new List<GraphicalFunctionDisplayNameForSerialization>();

                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<GraphicalFunctionDisplayNameForSerialization>));

                        //TODO TEST THIS SHIT
                        OpenFileDialog dialog = new OpenFileDialog();

                        dialog.Filter = "XML Files (*.xml)|*.xml";

                        if (dialog.ShowDialog() == true)
                        {
                            using (FileStream fileStream = new FileStream(dialog.FileName, FileMode.Open))
                            {
                                try
                                {
                                    // TODO I for sure need to check if this is even serializable or something else right? just the try catch block isnt the kind of panacea that i think it is.
                                    deserializedFunctions = (List<GraphicalFunctionDisplayNameForSerialization>)xmlSerializer.Deserialize(fileStream);
                                }
                                //TODO REMOVE , just for testing and finding out what can go wrong
                                catch (Exception e)
                                {
                                    throw e;
                                }
                            }

                            this.ReconstructFunctionsFromFileInport(deserializedFunctions);
                            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CurrentGraphicalFunctions)));
                            this.UpdateDrawInformationForFunctions();
                        }
                    }

                    );
            }
        }

        private void ReconstructFunctionsFromFileInport(List<GraphicalFunctionDisplayNameForSerialization> deserializedFunctions)
        {
            this.CurrentGraphicalFunctions = new ObservableCollection<GraphicalFunctionViewModel>();
            foreach (GraphicalFunctionDisplayNameForSerialization deserializedFunction in deserializedFunctions)
            {
                List<FunctionParts> functionParts;

                if (this.StringToFunctionConverter.TryParseStringToFunctionPartsList(deserializedFunction.FunctionName, out functionParts))
                {
                    GraphicalFunctionViewModel graphicalFunctionVM = new GraphicalFunctionViewModel(
                        functionParts,
                        deserializedFunction.FunctionColor,
                        deserializedFunction.UserSetNameForFunction,
                        deserializedFunction.FunctionName,
                        deserializedFunction.FunctionVisibility);

                    // TESTTING IF THIS WORKS WITHOUT;
                    //////graphicalFunctionVM.FunctionColor = deserializedFunction.FunctionColor;
                    //////graphicalFunctionVM.CustomUserSetName = deserializedFunction.UserSetNameForFunction;
                    //////graphicalFunctionVM.FunctionVisibility = deserializedFunction.FunctionVisibility;

                    this.AddFunctionToCurrentFunction(graphicalFunctionVM);
                }
            }
        }

        //FIELD todo
        public ApplicationStatusSaveDataHandler SaveDataHandler { get; set; }

        public bool isApplicationDataInitalized;

        public bool IsApplicationDataInitalized
        {
            get { return isApplicationDataInitalized; }
            set
            {
                if (value != isApplicationDataInitalized)
                {
                    isApplicationDataInitalized = value;
                }
            }
        }

        public MainViewModel()
        {
            //Application.Current.MainWindow.Closing better alternative??

            this.SaveDataHandler = new ApplicationStatusSaveDataHandler();

            this.StringToFunctionConverter = new StringToFunctionConverter();
            Application.Current.Exit += OnWindowClosing;

            this.TextBoxUserInputFunctionToolTip = "To Input a Function use the right format shown here. Using other formats will yield wrong inputs.\r\n PLEASE NOTE THAT THE NOTATION FOR DECIMALS IS BOUND TO YOUR LOCALICATION! \r\n Supported Functions are : sin,cos,tan and polynomial function up to a exponent degree of 10." +
                                                    "\r\n a3*x^3+a2*x^2+a1*x+c \r\n a*sin(b*x)+c \r\n a*cos(b*x)+c\r\n a*tan(b*x)+c";

            this.CurrentGraphicalFunctions = new ObservableCollection<GraphicalFunctionViewModel>();
            if (this.SaveDataHandler.TryToExtractBackupDataForApplication(out AxisData savedXAxisData, out AxisData savedYAxisData, out AxisGridData savedXAxisGrid, out AxisGridData savedYAxisGrid, out List<GraphicalFunctionDisplayNameForSerialization> savedFunctions))
            {
                this.ReconstructAxisAndGridData(savedXAxisData, savedYAxisData, savedXAxisGrid, savedYAxisGrid);
                this.IsApplicationDataInitalized = true;

                this.ReconstructFunctionsFromFileInport(savedFunctions);
            }
            this.IsApplicationDataInitalized = true;

            this.XAxisData = new AxisData(this.TextBoxXAxisMin, this.TextBoxXAxisMax, this.ColorPickerXAxisColor, this.CheckBoxXAxisVisibility);
            this.YAxisData = new AxisData(this.TextBoxYAxisMin, this.TextBoxYAxisMax, this.ColorPickerYAxisColor, this.CheckBoxYAxisVisibility);
            this.XAxisGrid = new AxisGridData(this.TextBoxXAxisGridIntervall, this.ColorPickerXAxisGridColor, this.CheckBoxXAxisGridVisibility);
            this.YAxisGrid = new AxisGridData(this.TextBoxYAxisGridIntervall, this.ColorPickerYAxisGridColor, this.CheckBoxYAxisGridVisibility);

            //Setting the properties to the start values, also binding them by refernc i hope, i could also try to first initialzie the properties and then make a grid of them

            this.MainGraphCanvas = new TwoDimensionalGraphCanvas(this.PixelWidhtCanvas, this.PixelHeightCanvas, this.XAxisData, this.YAxisData, this.XAxisGrid, this.YAxisGrid);
            this.CanvasFunctionConverter = new FunctionToCanvasFunctionConverter(this.MainGraphCanvas);

            this.UpdateDrawInformationForFunctions();
            this.UpdateDrawInformationForAxis();
            this.UpdateDrawInformationForGridLines();

            BindingOperations.EnableCollectionSynchronization(this.CurrentGraphicalFunctions, this.lockObjectFunctions);
            BindingOperations.EnableCollectionSynchronization(this.DrawInformationForAxis, this.lockObjectFunctions);
            BindingOperations.EnableCollectionSynchronization(this.DrawInformationForGridLines, this.lockObjectFunctions);

            this.PropertyChanged += UpdateCanvasAttributes;

            // I have no idea if this is good , or necessary to cast here, but i am going to do it becouse i couldnt get it to work otherwise
            try
            {
                MainWindow plotterWindowWithCanvas = (MainWindow)Application.Current.MainWindow;
                plotterWindowWithCanvas.OnCanvasZoomStart += this.UpdateStartPoint;
                plotterWindowWithCanvas.OnCanvasZoomEnd += this.ZoomIntoCanvas;
            }
            catch (Exception)
            {
            }
        }

        private void ZoomIntoCanvas(object sender, CanvasZoomEventArguments eventArgs)
        {
            if (this.ZoomStartPoint == null)
            {
            }
            else
            {
                Point endPoint = eventArgs.CurrentMouseLocationOnCanvas;
                // i should probably make a constructtor for that at this point
                CanvasPixel endPixel = new CanvasPixel((int)Math.Round(endPoint.X), (int)Math.Round(endPoint.Y));
                CanvasPixel startPixel = this.ZoomStartPoint;

                int biggerXPixelValue;
                int smallerXPixelValue;

                int biggerYPixelValue;
                int smallerYPixelValue;

                //in theory there could be scenario where the the x or y values are on the same pixel, to calculate the new x and y values i still need an intervall though so im changing up the values if they are indeed the same
                if (endPixel.XAxisValue == startPixel.XAxisValue)
                {
                    if (endPixel.XAxisValue < 0)
                    {
                        endPixel.XAxisValue -= 1;
                    }
                    else
                    {
                        endPixel.XAxisValue += 1;
                    }
                }
                // same but for the y axis
                if (endPixel.YAxisValue == startPixel.YAxisValue)
                {
                    if (endPixel.YAxisValue < 0)
                    {
                        endPixel.YAxisValue -= 1;
                    }
                    else
                    {
                        endPixel.YAxisValue += 1;
                    }
                }

                biggerXPixelValue = Math.Max(startPixel.XAxisValue, endPixel.XAxisValue);
                smallerXPixelValue = Math.Min(startPixel.XAxisValue, endPixel.XAxisValue);
                biggerYPixelValue = Math.Max(startPixel.YAxisValue, endPixel.YAxisValue);
                smallerYPixelValue = Math.Min(startPixel.YAxisValue, endPixel.YAxisValue);

                // A bigger pixelValue means closer a smaller value for the y axis and , a higher value for the x axis
                double newXAxisMin = this.CalculateXValueForXPixel(smallerXPixelValue);
                double newXAxisMax = this.CalculateXValueForXPixel(biggerXPixelValue);
                double newYAxisMin = this.CalculateYValueForYPixel(biggerYPixelValue);
                double newYAxisMax = this.CalculateYValueForYPixel(smallerYPixelValue);

                //WHAT IF new min is bigger than max or reversed, think about it

                //we will just write into the fields and update the canvas manually
                this.TextBoxXAxisMin = newXAxisMin;
                this.TextBoxXAxisMax = newXAxisMax;
                this.TextBoxYAxisMin = newYAxisMin;
                this.TextBoxYAxisMax = newYAxisMax;

                //reset the start point so that the user cant just release the mouse inside the canvas and the old point is taken as the startpoint
                this.zoomStartPoint = null;
                this.UpdateFullCanvas();
            }
        }

        private double CalculateYValueForYPixel(int yPixelValue)
        {
            return this.TextBoxYAxisMax - (((double)yPixelValue / (double)this.PixelHeightCanvas) * ((double)TextBoxYAxisMax - (double)this.TextBoxYAxisMin));
        }

        private double CalculateXValueForXPixel(int xPixelValue)
        {
            return ((((double)xPixelValue) * (this.TextBoxXAxisMax - this.TextBoxXAxisMin)) / this.PixelWidhtCanvas) + TextBoxXAxisMin;
        }

        private void UpdateStartPoint(object sender, CanvasZoomEventArguments eventArgs)
        {
            Point startPoint = eventArgs.CurrentMouseLocationOnCanvas;
            //TODO this could still be unsafe if there is some funky logic behind the Point or if someone opens the graphplotter on a 2000000K monitor or something lol.
            this.ZoomStartPoint = new CanvasPixel((int)Math.Round(startPoint.X), (int)Math.Round(startPoint.Y));
        }

        private CanvasPixel zoomStartPoint;

        public CanvasPixel ZoomStartPoint
        {
            get { return zoomStartPoint; }
            set
            {
                if (value != zoomStartPoint && value != null)
                {
                    zoomStartPoint = value;
                }
            }
        }

        private void ReconstructAxisAndGridData(AxisData savedXAxisData, AxisData savedYAxisData, AxisGridData savedXAxisGrid, AxisGridData savedYAxisGrid)
        {
            this.TextBoxXAxisMin = savedXAxisData.MinVisibleValue;
            this.TextBoxXAxisMax = savedXAxisData.MaxVisibleValue;
            this.ColorPickerXAxisColor = savedXAxisData.AxisColor;
            this.CheckBoxXAxisVisibility = savedXAxisData.Visibility;

            this.TextBoxYAxisMin = savedYAxisData.MinVisibleValue;
            this.TextBoxYAxisMax = savedYAxisData.MaxVisibleValue;
            this.ColorPickerYAxisColor = savedYAxisData.AxisColor;
            this.CheckBoxYAxisVisibility = savedYAxisData.Visibility;

            this.TextBoxXAxisGridIntervall = savedXAxisGrid.IntervallBetweenLines;
            this.ColorPickerXAxisGridColor = savedXAxisGrid.GridColor;
            this.CheckBoxXAxisGridVisibility = savedXAxisGrid.Visibility;

            this.TextBoxYAxisGridIntervall = savedYAxisGrid.IntervallBetweenLines;
            this.ColorPickerYAxisGridColor = savedYAxisGrid.GridColor;
            this.CheckBoxYAxisGridVisibility = savedYAxisGrid.Visibility;
        }

        public ICommand RestoreDefaultValuesForAxisAndGridData
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
                        this.IsApplicationDataInitalized = false;

                        this.TextBoxXAxisMin = -10;
                        this.TextBoxXAxisMax = 10;
                        this.ColorPickerXAxisColor = Colors.DarkSlateBlue;
                        this.CheckBoxXAxisVisibility = true;

                        this.TextBoxYAxisMin = -10;
                        this.TextBoxYAxisMax = 10;
                        this.ColorPickerYAxisColor = Colors.DarkSlateBlue;
                        this.CheckBoxYAxisVisibility = true;

                        this.TextBoxXAxisGridIntervall = 1;
                        this.ColorPickerXAxisGridColor = Colors.LightGray;
                        this.CheckBoxXAxisGridVisibility = true;

                        this.TextBoxYAxisGridIntervall = 1;
                        this.ColorPickerYAxisGridColor = Colors.LightGray;
                        this.CheckBoxYAxisGridVisibility = true;

                        this.IsApplicationDataInitalized = true;

                        this.UpdateFullCanvas();
                    });
            }
        }

        public ICommand DeleteAllCurrentFunctions
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
                        this.IsApplicationDataInitalized = false;

                        this.CurrentGraphicalFunctions = new ObservableCollection<GraphicalFunctionViewModel>();

                        this.IsApplicationDataInitalized = true;
                        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CurrentGraphicalFunctions)));
                        this.UpdateFullCanvas();
                    });
            }
        }

        private void OnWindowClosing(object sender, ExitEventArgs e)
        {
            this.SaveDataHandler.CreateApplicationSaveData(this.XAxisData, this.XAxisGrid, this.YAxisData, this.YAxisGrid, this.CreateSerialiationObjectsFromCurrentFunctions());
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
            if (this.IsApplicationDataInitalized)
            {
                List<FunctionDrawInformation> functionDrawInformation = new List<FunctionDrawInformation>();

                foreach (GraphicalFunctionViewModel functionVM in this.CurrentGraphicalFunctions)
                {
                    if (functionVM.FunctionVisibility == true)
                    {
                        // i need like a course in better naming conventions, but i hope it brings the point across.
                        List<FunctionDrawInformation> functionDrawInformationForPathsForThisMathematicalFunction = this.CanvasFunctionConverter.ConvertFunctionViewModelIntoDrawInformation(functionVM);
                        this.IntegrateListOfResultingDrawingFunctionsIntoListOfDrawingFunctions(functionDrawInformation, functionDrawInformationForPathsForThisMathematicalFunction);
                    }
                }

                this.DrawInformationForFunctions = functionDrawInformation;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DrawInformationForFunctions)));
            }
        }

        private void IntegrateListOfResultingDrawingFunctionsIntoListOfDrawingFunctions(List<FunctionDrawInformation> functionDrawInformation, List<FunctionDrawInformation> functionDrawInformationForPathsForThisMathematicalFunction)
        {
            foreach (FunctionDrawInformation partOfDrawPathForOneFunctions in functionDrawInformationForPathsForThisMathematicalFunction)
            {
                functionDrawInformation.Add(partOfDrawPathForOneFunctions);
            }

        }



        //yeah i know every function gets updated, but for now this is good enough
        //TODO fix, only the function that has changed needs updates to its information.
        public void UpdateDrawInformationForFunctions(object sender, UserInputFunctionChangedEventArgs e)
        {
            if (this.IsApplicationDataInitalized)
            {
                List<FunctionDrawInformation> functionDrawInformation = new List<FunctionDrawInformation>();

                foreach (GraphicalFunctionViewModel functionVM in this.CurrentGraphicalFunctions)
                {
                    if (functionVM.FunctionVisibility == true)
                    {
                        List<FunctionDrawInformation> functionDrawInformationForPathsForThisMathematicalFunction = this.CanvasFunctionConverter.ConvertFunctionViewModelIntoDrawInformation(functionVM);
                        this.IntegrateListOfResultingDrawingFunctionsIntoListOfDrawingFunctions(functionDrawInformation, functionDrawInformationForPathsForThisMathematicalFunction);
                    }
                }

                this.DrawInformationForFunctions = functionDrawInformation;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DrawInformationForFunctions)));
            }
        }

        public void UpdateDrawInformationForAxis()
        {
            if (this.IsApplicationDataInitalized)
            {
                List<FunctionDrawInformation> functionDrawInformation = this.CanvasFunctionConverter.CreateFunctionDrawInformationForAxis();

                this.DrawInformationForAxis = functionDrawInformation;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DrawInformationForAxis)));
            }
        }

        public void UpdateDrawInformationForGridLines()
        {
            if (this.IsApplicationDataInitalized)
            {
                List<FunctionDrawInformation> functionDrawInformation = this.CanvasFunctionConverter.CreateGridDrawInformation();

                this.DrawInformationForGridLines = functionDrawInformation;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DrawInformationForGridLines)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}