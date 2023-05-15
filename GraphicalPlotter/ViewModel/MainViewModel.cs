namespace GraphicalPlotter
{
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

    public class MainViewModel : INotifyPropertyChanged
    {
        // TODO add more checks to the properties

        private double textBoxXAxisMin = -10;

        public double TextBoxXAxisMin
        {
            get { return this.textBoxXAxisMin; }
            set
            {
                if (value != this.textBoxXAxisMin && value < this.TextBoxXAxisMax)
                {
                    this.textBoxXAxisMin = value;

                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxXAxisMin)));
                    this.UpdateFullCanvas();
                }
            }
        }

        private double textBoxXAxisMax = 10;

        public double TextBoxXAxisMax
        {
            get { return this.textBoxXAxisMax; }
            set
            {
                if (value != this.textBoxXAxisMax && value > this.TextBoxXAxisMin)
                {
                    this.textBoxXAxisMax = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxXAxisMax)));
                    this.UpdateFullCanvas();
                }
            }
        }

        public bool checkBoxXAxisVisibility = true;

        public bool CheckBoxXAxisVisibility
        {
            get { return this.checkBoxXAxisVisibility; }
            set
            {
                if (value != this.checkBoxXAxisVisibility)
                {
                    this.checkBoxXAxisVisibility = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CheckBoxXAxisVisibility)));
                    this.UpdateDrawInformationForAxis();
                }
            }
        }

        private Color colorPickerXAxisColor = Colors.DarkSlateBlue;

        public Color ColorPickerXAxisColor
        {
            get { return this.colorPickerXAxisColor; }
            set
            {
                if (value != this.colorPickerXAxisColor)
                {
                    this.colorPickerXAxisColor = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.ColorPickerXAxisColor)));
                    this.UpdateDrawInformationForAxis();
                }
            }
        }

        private double textBoxXAxisGridIntervall = 2;

        public double TextBoxXAxisGridIntervall
        {
            get { return this.textBoxXAxisGridIntervall; }
            set
            {
                // If the value is above 0 and when there arent more gridlines than the max amount , which is half of all the pixels
                if (value != this.textBoxXAxisGridIntervall && value > 0 && (((this.TextBoxXAxisMax - this.TextBoxXAxisMin) / value) < (this.PixelWidhtCanvas / 2)))
                {
                    this.textBoxXAxisGridIntervall = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxXAxisGridIntervall)));
                    this.UpdateDrawInformationForGridLines();
                }
            }
        }

        private Color colorPickerXAxisGridColor = Colors.LightGray;

        public Color ColorPickerXAxisGridColor
        {
            get { return this.colorPickerXAxisGridColor; }
            set
            {
                if (value != this.colorPickerXAxisGridColor)
                {
                    this.colorPickerXAxisGridColor = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.ColorPickerXAxisGridColor)));
                    this.UpdateDrawInformationForGridLines();
                }
            }
        }

        public bool checkBoxXAxisGridVisibility = true;

        public bool CheckBoxXAxisGridVisibility
        {
            get { return this.checkBoxXAxisGridVisibility; }
            set
            {
                if (value != this.checkBoxXAxisGridVisibility)
                {
                    this.checkBoxXAxisGridVisibility = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CheckBoxXAxisGridVisibility)));
                    this.UpdateDrawInformationForGridLines();
                }
            }
        }

        private double textBoxYAxisMin = -10;

        public double TextBoxYAxisMin
        {
            get { return this.textBoxYAxisMin; }
            set
            {
                if (value != this.textBoxYAxisMin && value < this.TextBoxYAxisMax)
                {
                    this.textBoxYAxisMin = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxYAxisMin)));
                    this.HasUserChangedYAxisSettings = true;
                    this.UpdateFullCanvas();
                }
            }
        }

        private double textBoxYAxisMax = 10;

        public double TextBoxYAxisMax
        {
            get { return this.textBoxYAxisMax; }
            set
            {
                if (value != this.textBoxYAxisMax && value > this.TextBoxYAxisMin)
                {
                    this.textBoxYAxisMax = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxYAxisMax)));
                    this.HasUserChangedYAxisSettings = true;
                    this.UpdateFullCanvas();
                }
            }
        }

        public bool checkBoxYAxisVisibility = true;

        public bool CheckBoxYAxisVisibility
        {
            get { return this.checkBoxYAxisVisibility; }
            set
            {
                if (value != this.checkBoxYAxisVisibility)
                {
                    this.checkBoxYAxisVisibility = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CheckBoxYAxisVisibility)));
                    this.UpdateDrawInformationForAxis();
                }
            }
        }

        private Color colorPickerYAxisColor = Colors.DarkSlateBlue;

        public Color ColorPickerYAxisColor
        {
            get { return this.colorPickerYAxisColor; }
            set
            {
                if (value != this.colorPickerYAxisColor)
                {
                    this.colorPickerYAxisColor = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.ColorPickerYAxisColor)));
                    this.UpdateDrawInformationForAxis();
                }
            }
        }

        private double textBoxYAxisGridIntervall = 2;

        public double TextBoxYAxisGridIntervall
        {
            get { return this.textBoxYAxisGridIntervall; }
            set
            {
                if (value != this.textBoxYAxisGridIntervall && value > 0 && (((this.TextBoxYAxisMax - this.TextBoxYAxisMin) / value) < (this.PixelHeightCanvas / 2)))
                {
                    this.textBoxYAxisGridIntervall = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxYAxisGridIntervall)));
                    this.UpdateDrawInformationForGridLines();
                }
            }
        }

        private Color colorPickerYAxisGridColor = Colors.LightGray;

        public Color ColorPickerYAxisGridColor
        {
            get { return this.colorPickerYAxisGridColor; }
            set
            {
                if (value != this.colorPickerYAxisGridColor)
                {
                    this.colorPickerYAxisGridColor = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.ColorPickerYAxisGridColor)));
                    this.UpdateDrawInformationForGridLines();
                }
            }
        }

        public bool checkBoxYAxisGridVisibility = true;

        public bool CheckBoxYAxisGridVisibility
        {
            get { return this.checkBoxYAxisGridVisibility; }
            set
            {
                if (value != this.checkBoxYAxisGridVisibility)
                {
                    this.checkBoxYAxisGridVisibility = value;
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
                    this.pixelWidhtApp = value;
                    //// 900-630
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
                    this.pixelHeightApp = value;
                    //// 600-380
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
                    this.pixelWidhtCanvas = value;
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
                    this.pixelHeightCanvas = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.PixelHeightCanvas)));
                    this.UpdateFullCanvas();
                }
            }
        }

        public TwoDimensionalGraphCanvas MainGraphCanvas { get; set; }

        public FunctionToCanvasFunctionConverter CanvasFunctionConverter { get; set; }

        //// TODO do i actually need the lock here???
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

        private string textBoxUserInputFunction = string.Empty;

        public string TextBoxUserInputFunction
        {
            get { return this.textBoxUserInputFunction; }
            set
            {
                if (value != this.textBoxUserInputFunction)
                {
                    this.textBoxUserInputFunction = value;

                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxUserInputFunction)));
                }
            }
        }

        public string TextBoxUserInputFunctionToolTip { get; set; }

        //FIELD todo
        public ApplicationStatusSaveDataHandler SaveDataHandler { get; set; }

        public bool isApplicationDataInitalized;

        public bool IsApplicationDataInitalized
        {
            get { return this.isApplicationDataInitalized; }
            set
            {
                if (value != this.isApplicationDataInitalized)
                {
                    this.isApplicationDataInitalized = value;
                }
            }
        }

        public bool HasUserChangedYAxisSettings { get; set; }

        private CanvasPixel zoomStartPoint;

        public CanvasPixel ZoomStartPoint
        {
            get { return this.zoomStartPoint; }
            set
            {
                if (value != this.zoomStartPoint && value != null)
                {
                    this.zoomStartPoint = value;
                }
            }
        }

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
                        if (this.StringToFunctionConverter.TryParseStringToGraphicalFunction(this.TextBoxUserInputFunction, out graphicalFunction))
                        {
                            GraphicalFunctionViewModel functionVM = new GraphicalFunctionViewModel(graphicalFunction);
                            this.AddFunctionToCurrentFunction(functionVM);

                            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CurrentGraphicalFunctions)));
                            this.UpdateFullCanvas();
                        }
                    });
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
                        colorPickerWindow.ShowDialog();
                        //// If a color is selected and the ok button is pressed
                        if (colorPickerWindow.isColorPicked == true)
                        {
                            //UNSAFE AS FUCK PLEASE FIX TODO TODO TODO
                            string propertyName = (string)obj;

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
                        }
                    });
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
                    });
            }
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

                        OpenFileDialog dialog = new OpenFileDialog();

                        dialog.Filter = "XML Files (*.xml)|*.xml";

                        if (dialog.ShowDialog() == true)
                        {
                            using (FileStream fileStream = new FileStream(dialog.FileName, FileMode.Open))
                            {
                                try
                                {
                                    //// TODO I for sure need to check if this is even serializable or something else right? just the try catch block isnt the kind of panacea that i think it is.
                                    deserializedFunctions = (List<GraphicalFunctionDisplayNameForSerialization>)xmlSerializer.Deserialize(fileStream);
                                }
                                catch (Exception)
                                {
                                }
                            }

                            this.ReconstructFunctionsFromFileInport(deserializedFunctions);
                            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CurrentGraphicalFunctions)));
                            this.UpdateDrawInformationForFunctions();
                        }
                    });
            }
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

                        this.HasUserChangedYAxisSettings = false;

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

        public ICommand ResetAutomaticScaling
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

                        this.HasUserChangedYAxisSettings = false;
                        if (this.AreAllCurrentFunctionsAutomaticlyScalable())
                        {
                            this.RescaleYMinAndMaxForRescalableFunctions();
                        }
                        this.IsApplicationDataInitalized = true;
                        this.UpdateFullCanvas();
                    });
            }
        }

        private void AddFunctionToCurrentFunction(GraphicalFunctionViewModel functionVM)
        {
            this.CurrentGraphicalFunctions.Add(functionVM);

            functionVM.OnUserFunctionChanged += new EventHandler<UserInputFunctionChangedEventArgs>(this.UpdateDrawInformationForFunctions);

            //// check if the user ever cahnged y-Axis Values, if not then autoscale the current Functions if they only are sin, cos and polynomials with exponent degree of zero ,
            //// but not incombination cos+sin or sin+sin , this would require a lot more code and it isnt in the requirement to begin with to be able to make a function like that so i hope that im good on that one
            if (!this.HasUserChangedYAxisSettings && this.IsFunctionScalable(functionVM))
            {
                this.RescaleYMinAndMaxForRescalableFunctions();
            }
            else
            {
                this.HasUserChangedYAxisSettings = true;
            }
        }

        public bool AreAllCurrentFunctionsAutomaticlyScalable()
        {
            foreach (var functionVM in this.CurrentGraphicalFunctions)
            {
                if (!this.IsFunctionScalable(functionVM))
                {
                    return false;
                }
            }
            return true;
        }

        //// this is requirement is just so unnessary
        private void RescaleYMinAndMaxForRescalableFunctions()
        {
            double biggestYValueOverall = double.MinValue;
            double smallestYValueOverall = double.MaxValue;

            //// since we now know that the function is scalabe it can only be one of theses possibilites : cos+c1+c2+c3...cn, sin+c1+c2+c3...cn or c1+c2+c3...cn we will move forward with this assumption
            foreach (GraphicalFunctionViewModel function in this.CurrentGraphicalFunctions)
            {
                double thisFunctionsSmallestYValue = this.FindSmallestYValue(function);
                double thisFunctionsBiggestYValue = this.FindBiggestYValue(function);

                if (thisFunctionsBiggestYValue > biggestYValueOverall)
                {
                    biggestYValueOverall = thisFunctionsBiggestYValue;
                }

                if (thisFunctionsSmallestYValue < smallestYValueOverall)
                {
                    smallestYValueOverall = thisFunctionsSmallestYValue;
                }
            }

            if (biggestYValueOverall < 1.5E-308 && smallestYValueOverall > 1.5E+308)
            {
                // we need this if there are no functions or somebody tried to rescale with functions that make no sense
            }
            else
            {
                this.isApplicationDataInitalized = false;

                this.textBoxYAxisMin = smallestYValueOverall;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxYAxisMin)));
                this.textBoxYAxisMax = biggestYValueOverall;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TextBoxYAxisMax)));

                this.IsApplicationDataInitalized = true;
                this.HasUserChangedYAxisSettings = false;
            }

            ////  we need to calculate the max and min values for the sum of all functions parts and then rescale the min and max of the y axis to fit that criteria, also we need to reset the hasUserChangedYAxis too false again after doing so.
        }

        private double FindBiggestYValue(GraphicalFunctionViewModel function)
        {
            //// since we now know that the function is scalabe it can only be one of theses possibilites : cos+c1+c2+c3...cn, sin+c1+c2+c3...cn or c1+c2+c3...cn we will move forward with this assumption
            double sumOfSmallestValues = 0;

            foreach (FunctionParts parts in function.FunctionParts)
            {
                bool sinusFlag = parts.GetType() == typeof(SineFunction);
                bool cosinusFlag = parts.GetType() == typeof(CosineFunction);

                if (cosinusFlag || sinusFlag)
                {
                    sumOfSmallestValues += Math.Abs(parts.ConstantMultiplier);
                }
                else
                {
                    //// must be polynomial of degree 0 meaning only the constant multiplier is added
                    sumOfSmallestValues += parts.ConstantMultiplier;
                }
            }
            return sumOfSmallestValues;
        }

        private double FindSmallestYValue(GraphicalFunctionViewModel function)
        {
            double sumOfBiggestValues = 0;

            foreach (FunctionParts parts in function.FunctionParts)
            {
                bool sinusFlag = parts.GetType() == typeof(SineFunction);
                bool cosinusFlag = parts.GetType() == typeof(CosineFunction);

                if (cosinusFlag || sinusFlag)
                {
                    sumOfBiggestValues += Math.Abs(parts.ConstantMultiplier) * -1;
                }
                else
                {
                    //// must be polynomial of degree 0 meaning only the constant multiplier is added
                    sumOfBiggestValues += parts.ConstantMultiplier;
                }
            }
            return sumOfBiggestValues;
        }

        private bool IsFunctionScalable(GraphicalFunctionViewModel functionVM)
        {
            //// we will count how often sinus and cosinus exist in the given function, the sum must be smaller than 2 , so there can only be one sin or one cos, else the calculation for the new max,min values
            //// would be way to hard for this model, and i dont have enough time to refracture that much code.
            int sinusCount = 0;
            int cosinusCount = 0;
            foreach (var currentFunctionPart in functionVM.FunctionParts)
            {
                bool sinusFlag = currentFunctionPart.GetType() == typeof(SineFunction);
                bool cosinusFlag = currentFunctionPart.GetType() == typeof(CosineFunction);
                bool polynomialFlag = currentFunctionPart.GetType() == typeof(PolynomialComponent);
                bool polynomialDegreeFlag = false;
                //// set the polynomialdegree flag depending on the degree of the polynomial, only 0 is allowed
                if (polynomialFlag)
                {
                    PolynomialComponent currentPolynomialFunctionPart = (PolynomialComponent)currentFunctionPart;
                    polynomialDegreeFlag = currentPolynomialFunctionPart.ExponentDegree == 0;
                }

                if (sinusFlag)
                {
                    sinusCount++;
                }
                if (cosinusFlag)
                {
                    cosinusCount++;
                }

                //// only if one of these 3 primary factors are true we can even rescale.
                if (sinusFlag || cosinusFlag || (polynomialFlag && polynomialDegreeFlag))
                {
                }
                else
                {
                    return false;
                }
            }

            if (sinusCount + cosinusCount > 1)
            {
                return false;
            }

            return true;
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

        public MainViewModel()
        {
            this.SaveDataHandler = new ApplicationStatusSaveDataHandler();

            this.StringToFunctionConverter = new StringToFunctionConverter();

            //// Application.Current.MainWindow.Closing better alternative??
            Application.Current.Exit += this.OnWindowClosing;

            this.TextBoxUserInputFunctionToolTip = "To Input a Function use the right format shown here. Using other formats may yield wrong inputs.\r\n PLEASE NOTE THAT THE NOTATION FOR DECIMALS IS BOUND TO YOUR LOCALICATION! \r\n Supported Functions are : sin,cos,tan and polynomial function up to a exponent degree of 10." +
                                                    "\r\n a3*x^3+a2*x^2+a1*x+c \r\n a*sin(b*x)+c \r\n a*cos(b*x)+c\r\n a*tan(b*x)+c" + "\r\n \r\n it is also possible to combine polynomial functions with sin cos and tan like this: \r\n " +
                                                    "5x^2+9x-8*cos(0,5x)";

            this.CurrentGraphicalFunctions = new ObservableCollection<GraphicalFunctionViewModel>();
            if (this.SaveDataHandler.TryToExtractBackupDataForApplication(
                out AxisData savedXAxisData,
                out AxisData savedYAxisData,
                out AxisGridData savedXAxisGrid,
                out AxisGridData savedYAxisGrid,
                out List<GraphicalFunctionDisplayNameForSerialization> savedFunctions,
                out bool hasUserChangedYAxisValues))
            {
                this.ReconstructAxisAndGridData(savedXAxisData, savedYAxisData, savedXAxisGrid, savedYAxisGrid, hasUserChangedYAxisValues);
                this.IsApplicationDataInitalized = true;

                this.ReconstructFunctionsFromFileInport(savedFunctions);
            }
            this.IsApplicationDataInitalized = true;

            this.XAxisData = new AxisData(this.TextBoxXAxisMin, this.TextBoxXAxisMax, this.ColorPickerXAxisColor, this.CheckBoxXAxisVisibility);
            this.YAxisData = new AxisData(this.TextBoxYAxisMin, this.TextBoxYAxisMax, this.ColorPickerYAxisColor, this.CheckBoxYAxisVisibility);
            this.XAxisGrid = new AxisGridData(this.TextBoxXAxisGridIntervall, this.ColorPickerXAxisGridColor, this.CheckBoxXAxisGridVisibility);
            this.YAxisGrid = new AxisGridData(this.TextBoxYAxisGridIntervall, this.ColorPickerYAxisGridColor, this.CheckBoxYAxisGridVisibility);

            //// Setting the properties to the start values, also binding them by refernc i hope, i could also try to first initialzie the properties and then make a grid of them

            this.MainGraphCanvas = new TwoDimensionalGraphCanvas(this.PixelWidhtCanvas, this.PixelHeightCanvas, this.XAxisData, this.YAxisData, this.XAxisGrid, this.YAxisGrid);
            this.CanvasFunctionConverter = new FunctionToCanvasFunctionConverter(this.MainGraphCanvas);

            this.UpdateDrawInformationForFunctions();
            this.UpdateDrawInformationForAxis();
            this.UpdateDrawInformationForGridLines();

            BindingOperations.EnableCollectionSynchronization(this.CurrentGraphicalFunctions, this.lockObjectFunctions);
            BindingOperations.EnableCollectionSynchronization(this.DrawInformationForAxis, this.lockObjectFunctions);
            BindingOperations.EnableCollectionSynchronization(this.DrawInformationForGridLines, this.lockObjectFunctions);

            this.PropertyChanged += this.UpdateCanvasAttributes;

            //// I have no idea if this is good , or necessary to cast here, but i am going to do it becouse i couldnt get it to work otherwise
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
                ////  i should probably make a constructtor for that at this point
                //// todo add an construtor to canvasPixel that just takes a WPF Point.
                CanvasPixel endPixel = new CanvasPixel((int)Math.Round(endPoint.X), (int)Math.Round(endPoint.Y));
                CanvasPixel startPixel = this.ZoomStartPoint;

                int biggerXPixelValue;
                int smallerXPixelValue;

                int biggerYPixelValue;
                int smallerYPixelValue;

                //// in theory there could be scenario where the the x or y values are on the same pixel, to calculate the new x and y values i still need an intervall though so im changing up the values if they are indeed the same
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
                //// same but for the y axis
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

                //// A bigger pixelValue means closer a smaller value for the y axis and , a higher value for the x axis
                double newXAxisMin = this.CalculateXValueForXPixel(smallerXPixelValue);
                double newXAxisMax = this.CalculateXValueForXPixel(biggerXPixelValue);
                double newYAxisMin = this.CalculateYValueForYPixel(biggerYPixelValue);
                double newYAxisMax = this.CalculateYValueForYPixel(smallerYPixelValue);

                //// WHAT IF new min is bigger than max or reversed, think about it
                //// cant happen because we always zoom IN so this is not a problem, if we would zoom out we would have to use the isInitialized flag to curcumvent the properties checks
                this.TextBoxXAxisMin = newXAxisMin;
                this.TextBoxXAxisMax = newXAxisMax;
                this.TextBoxYAxisMin = newYAxisMin;
                this.TextBoxYAxisMax = newYAxisMax;

                //// reset the start point so that the user cant just release the mouse inside the canvas and the old point is taken as the startpoint
                this.zoomStartPoint = null;
                this.UpdateFullCanvas();
            }
        }

        private double CalculateYValueForYPixel(int yPixelValue)
        {
            return this.TextBoxYAxisMax - (((double)yPixelValue / (double)this.PixelHeightCanvas) * ((double)this.TextBoxYAxisMax - (double)this.TextBoxYAxisMin));
        }

        private double CalculateXValueForXPixel(int xPixelValue)
        {
            return ((((double)xPixelValue) * (this.TextBoxXAxisMax - this.TextBoxXAxisMin)) / this.PixelWidhtCanvas) + this.TextBoxXAxisMin;
        }

        private void UpdateStartPoint(object sender, CanvasZoomEventArguments eventArgs)
        {
            Point startPoint = eventArgs.CurrentMouseLocationOnCanvas;
            //// TODO this could still be unsafe if there is some funky logic behind the Point or if someone opens the graphplotter on a 2000000K monitor or something lol.
            this.ZoomStartPoint = new CanvasPixel((int)Math.Round(startPoint.X), (int)Math.Round(startPoint.Y));
        }

        private void ReconstructAxisAndGridData(AxisData savedXAxisData, AxisData savedYAxisData, AxisGridData savedXAxisGrid, AxisGridData savedYAxisGrid, bool hasUserChangedYAxis)
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

            this.HasUserChangedYAxisSettings = hasUserChangedYAxis;
        }

        private void OnWindowClosing(object sender, ExitEventArgs e)
        {
            this.SaveDataHandler.CreateApplicationSaveData(this.XAxisData, this.XAxisGrid, this.YAxisData, this.YAxisGrid, this.CreateSerialiationObjectsFromCurrentFunctions(), this.HasUserChangedYAxisSettings);
        }

        ////  this is utterly retarded but i dont have enough time to think about a better solution
        //// omg this is like prp the worst code i have written to date, what else would you use?? Methods for each function?? somekind of Observer class? i dont know please help
        //// I thought that when i just use a reference for the grid and axis classes it would tranfer but apprently not
        private void UpdateCanvasAttributes(object sender, PropertyChangedEventArgs eventArgs)
        {
            switch (eventArgs.PropertyName)
            {
                //// for the x-axis itself
                case nameof(this.TextBoxXAxisMin):
                    this.XAxisData.MinVisibleValue = this.TextBoxXAxisMin;
                    break;

                case nameof(this.TextBoxXAxisMax):
                    this.XAxisData.MaxVisibleValue = this.TextBoxXAxisMax;
                    break;

                case nameof(this.CheckBoxXAxisVisibility):
                    this.XAxisData.Visibility = this.CheckBoxXAxisVisibility;
                    break;

                case nameof(this.ColorPickerXAxisColor):
                    this.XAxisData.AxisColor = this.ColorPickerXAxisColor;
                    break;

                //// for the y-axis itself
                case nameof(this.TextBoxYAxisMin):
                    this.YAxisData.MinVisibleValue = this.TextBoxYAxisMin;
                    break;

                case nameof(this.TextBoxYAxisMax):
                    this.YAxisData.MaxVisibleValue = this.TextBoxYAxisMax;
                    break;

                case nameof(this.CheckBoxYAxisVisibility):
                    this.YAxisData.Visibility = this.CheckBoxYAxisVisibility;
                    break;

                case nameof(this.ColorPickerYAxisColor):
                    this.YAxisData.AxisColor = this.ColorPickerYAxisColor;
                    break;

                //// for the x grid

                case nameof(this.TextBoxXAxisGridIntervall):
                    this.XAxisGrid.IntervallBetweenLines = this.TextBoxXAxisGridIntervall;
                    break;

                case nameof(this.ColorPickerXAxisGridColor):
                    this.XAxisGrid.GridColor = this.ColorPickerXAxisGridColor;
                    break;

                case nameof(this.CheckBoxXAxisGridVisibility):
                    this.XAxisGrid.Visibility = this.CheckBoxXAxisGridVisibility;
                    break;

                //// for the y grid

                case nameof(this.TextBoxYAxisGridIntervall):
                    this.YAxisGrid.IntervallBetweenLines = this.TextBoxYAxisGridIntervall;
                    break;

                case nameof(this.ColorPickerYAxisGridColor):
                    this.YAxisGrid.GridColor = this.ColorPickerYAxisGridColor;
                    break;

                case nameof(this.CheckBoxYAxisGridVisibility):
                    this.YAxisGrid.Visibility = this.CheckBoxYAxisGridVisibility;
                    break;

                //// For the canvas dimensions
                case nameof(this.PixelHeightCanvas):
                    this.MainGraphCanvas.HeightInPixel = this.PixelHeightCanvas;
                    break;

                case nameof(this.PixelWidhtCanvas):
                    this.MainGraphCanvas.WidthInPixel = this.PixelWidhtCanvas;
                    break;

                default:
                    break;
            }
        }

        public void UpdateFullCanvas()
        {
            this.UpdateDrawInformationForAxis();

            this.UpdateDrawInformationForFunctions();
            this.UpdateDrawInformationForGridLines();
        }

        private void IntegrateListOfResultingDrawingFunctionsIntoListOfDrawingFunctions(List<FunctionDrawInformation> functionDrawInformation, List<FunctionDrawInformation> functionDrawInformationForPathsForThisMathematicalFunction)
        {
            foreach (FunctionDrawInformation partOfDrawPathForOneFunctions in functionDrawInformationForPathsForThisMathematicalFunction)
            {
                functionDrawInformation.Add(partOfDrawPathForOneFunctions);
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

        //// yeah i know every function gets updated, but for now this is good enough
        //// TODO fix, only the function that has changed needs updates to its information.
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