//-----------------------------------------------------------------------
// <copyright file="GraphicalFunctionViewModel.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used as a viewmodel for the graphical functions to be displayed in the view.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Input;
    using System.Windows.Media;

    /// <summary>
    /// This class is the ViewModel for the GraphicalFunction. Inside it all the important attributes of the Function are saved. It also holds commands for the functions.
    /// </summary>
    public class GraphicalFunctionViewModel : INotifyPropertyChanged
    {
        //// This is so dumb i fucking hate events in C# WHY WHY do i need  a callback to call an event please microsoft
        
        /// <summary>
        /// The field indicating whether or not the GraphicalFunction is initialized and ready to be bound to events.
        /// </summary>
        private bool isInitialized = false;

        /// <summary>
        /// The field indicating whether or not the GraphicalFunction is visible.
        /// </summary>
        private bool functionVisibility = true;

        /// <summary>
        /// The field for the Color of the function.
        /// </summary>
        private Color functionColor;

        /// <summary>
        /// The field for the displayed name of the function.
        /// </summary>
        private string functionDisplayName;

        /// <summary>
        /// The field for the user set string that can be takes as the name of the function for example f(x).
        /// </summary>
        private string customUserSetName;

        /// <summary>
        /// The field for the List of Function Parts that comprise the function.
        /// </summary>
        private List<FunctionParts> functionParts;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicalFunctionViewModel" /> class.
        /// </summary>
        /// <param name="graphicalFunction"> The GraphicalFunction that should be converted to a function view model.</param>
        public GraphicalFunctionViewModel(GraphicalFunction graphicalFunction)
        {
            this.CustomUserSetName = string.Empty;
            this.FunctionColor = graphicalFunction.FunctionColor;
            this.FunctionDisplayName = graphicalFunction.FunctionDisplayName;
            this.FunctionParts = graphicalFunction.FunctionComponents;
            this.FunctionVisibility = graphicalFunction.Visibility;
            this.IsInitialized = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicalFunctionViewModel" /> class. 
        /// </summary>
        /// <param name="functionPartList"> The list of function parts for the view model.</param>
        /// <param name="functionColor"> The color in which the function should be drawn.</param>
        /// <param name="customUserSetName"> The string which the user set as a custom name for the function.</param>
        /// <param name="displayName"> The mathematical display name for the function.</param>
        /// <param name="visibility"> The Visibility of the function.</param>
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

        /// <summary>
        /// Gets a command for to open up a new window for a ColorPicker that can be used to set the color of an element in the WPF application.
        /// </summary>
        /// <value> A command to open up a new window for a ColorPicker that can be used to set the color of an element in the WPF application.</value>
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
                        if (colorPickerWindow.IsColorPicked == true)
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

        /// <summary>
        /// Gets or sets a value indicating whether or not the function is visible.
        /// </summary>
        /// <value> The visibility of the function.</value>
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

        /// <summary>
        /// Gets or sets the Color for the GraphicalFunctionViewModel.
        /// </summary>
        /// <value> The Color for the GraphicalFunctionViewModel.</value>
        public Color FunctionColor
        {
            get
            {
                return this.functionColor;
            }

            set
            {
                //// not nullable

                this.functionColor = value;

                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FunctionColor)));
            }
        }

        /// <summary>
        /// Gets or sets the list of function parts that make up the mathematical function for the View Model.
        /// </summary>
        /// <value> The list of function parts that make up the mathematical function for the View Model.</value>
        /// <example> <see cref="ArgumentNullException"/> is thrown if the given value was null. </example>
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

        /// <summary>
        /// Gets or sets the functions display name for the mathematical reading of the function.
        /// </summary>
        /// <value> The functions display name for the mathematical reading of the function.</value>
        /// <example> <see cref="ArgumentNullException"/> is thrown if the given value was null. </example>
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

        /// <summary>
        /// Gets or sets the custom user set string that represents the name for the function.
        /// </summary>
        /// <value> The custom user set string that represents the name for the function.</value>
        /// <example> <see cref="ArgumentNullException"/> is thrown if the given value was null. </example>
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

        /// <summary>
        /// Gets or sets a value indicating whether or not the function is already initialized. Used to first modify a function and then bind events on it.
        /// </summary>
        /// <value> A value indicating whether or not the function is already initialized. Used to first modify a function and then bind events on it.</value>
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

        //// yeah yeah i know i used them twice, but i dont want to put a whole ass graphicalfunction into this viewmodel too.

        /// <summary>
        /// This method calculates a y value for any given value x that is set into the function.
        /// </summary>
        /// <param name="value"> The value to which x should be set to.</param>
        /// <returns> A value representing the result y for a given x value.</returns>
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
        
        /// <summary>
        /// This method creates a display name for the mathematic function as a string.
        /// </summary>
        /// <returns> A string that could be used to represent the mathematical formula.</returns>
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