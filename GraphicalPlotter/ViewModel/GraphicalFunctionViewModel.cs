namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Input;
    using System.Windows.Media;

    public class GraphicalFunctionViewModel : INotifyPropertyChanged
    {
        //// This is so dumb i fucking hate events in C# WHY WHY do i need  a callback to call an event please microsoft
        private bool isInitialized = false;

        private bool functionVisibility = true;
        private Color functionColor;
        private string functionDisplayName;
        private string customUserSetName;
        private List<FunctionParts> functionParts;

        public GraphicalFunctionViewModel(GraphicalFunction graphicalFunction)
        {
            this.CustomUserSetName = string.Empty;
            this.FunctionColor = graphicalFunction.FunctionColor;
            this.FunctionDisplayName = graphicalFunction.FunctionDisplayName;
            this.FunctionParts = graphicalFunction.FunctionComponents;
            this.FunctionVisibility = graphicalFunction.Visibility;
            this.IsInitialized = true;
        }

        public GraphicalFunctionViewModel(List<FunctionParts> functionPartList, Color functionColor, string customUserSetName, string displayName, bool visibility)
        {
            this.CustomUserSetName = customUserSetName;
            this.FunctionColor = functionColor;
            this.FunctionDisplayName = displayName;
            this.FunctionParts = functionPartList;
            this.FunctionVisibility = visibility;
            this.IsInitialized = true;
        }

        public event EventHandler<UserInputFunctionChangedEventArgs> OnUserFunctionChanged;

        public event PropertyChangedEventHandler PropertyChanged;

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

                            ////i know that i could use the propertyInfo for this, but im not sure if we are allowed to use it.
                            ////PropertyInfo property = this.GetType().GetProperty(propertyName);
                            ////if (property != null && property.CanWrite)
                            ////{
                            ////    property.SetValue(this, selectedColor.Color);
                            ////}

                            //// dumb design that i need to convert 2 times but not enough time to fix this TODO
                            Color selectedColor = colorPickerWindow.SelectedColor.Color;

                            this.FunctionColor = selectedColor;
                            this.OnUserFunctionChanged(this, new UserInputFunctionChangedEventArgs());
                        }
                    });
            }
        }

        private bool IsInitialized
        {
            get
            {
                return this.isInitialized;
            }
            set
            {
                if (this.isInitialized != value)
                {
                    this.isInitialized = value;
                }
            }
        }

        public bool FunctionVisibility
        {
            get
            {
                return this.functionVisibility;
            }
            set
            {
                if (this.functionVisibility != value)
                {
                    this.functionVisibility = value;

                    if (this.IsInitialized)
                    {
                        this.OnUserFunctionChanged(this, new UserInputFunctionChangedEventArgs());
                    }

                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FunctionVisibility)));
                }
            }
        }

        public Color FunctionColor
        {
            get
            {
                return this.functionColor;
            }
            set
            {
                // not nullable

                this.functionColor = value;

                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FunctionColor)));
            }
        }

        public List<FunctionParts> FunctionParts
        {
            get
            {
                return this.functionParts;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.FunctionParts)} can not be null");
                }
                else
                {
                    this.functionParts = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FunctionParts)));
                }
            }
        }

        public string FunctionDisplayName
        {
            get
            {
                return this.functionDisplayName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.FunctionDisplayName)} can not be null");
                }
                else
                {
                    this.functionDisplayName = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FunctionDisplayName)));
                }
            }
        }

        public string CustomUserSetName
        {
            get
            {
                return this.customUserSetName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.CustomUserSetName)} can not be null");
                }
                else
                {
                    this.customUserSetName = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CustomUserSetName)));
                }
            }
        }

        //// yeah yeah i know i used them twice, but i dont want to put a whole ass graphicalfunction into this viewmodel too.

        public double CalculateSumOfAllPartsForValue(double value)
        {
            double sum = 0;
            foreach (FunctionParts part in this.FunctionParts)
            {
                sum += part.CalculateItsOwnValue(value);
            }
            return sum;
        }

        //// Todo no used right now - delete maybe
        public string CreateFunctionFullName()
        {
            string returnstring = string.Empty;
            foreach (FunctionParts function in this.FunctionParts)
            {
                returnstring += function.GetFunctionName();
            }
            return returnstring;
        }
    }
}