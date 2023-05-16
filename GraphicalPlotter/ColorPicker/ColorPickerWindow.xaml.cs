//-----------------------------------------------------------------------
// <copyright file="ColorPickerWindow.xaml.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is the code behind for the ColorPickerWindow used to choose a color by the user
// </summary>
//-----------------------------------------------------------------------

namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    /// <summary>
    /// The partial class for the Color picker Window.
    /// </summary>
    public partial class ColorPickerWindow : Window
    {
        /// <summary>
        /// The field for ColorPickerViewModel that represents the color picker view model and holds all the color values.
        /// </summary>      
        private ColorPickerViewModel colorPickerViewModel = new ColorPickerViewModel(Color.FromRgb(127, 127, 127));

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPickerWindow" /> class.
        /// </summary>
        public ColorPickerWindow()
        {
            this.InitializeComponent();
            this.DataContext = this.colorPickerViewModel;
        }

        /// <summary>
        /// Gets or sets the SolidColorBrush for the ColorPickerWindow.
        /// </summary>
        /// <value> The current SolidColorBrush selected.</value>
        public SolidColorBrush SelectedColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the color has been picked.
        /// </summary>
        /// <value> The visibility of the grid.</value>
        public bool IsColorPicked { get; set; }

        /// <summary>
        /// This method is called when the button inside the Color Picker window is pressed. 
        /// </summary>
        /// <param name="sender"> The sender of the click event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.SelectedColor = this.colorPickerViewModel.SelectedColor;
            this.IsColorPicked = true;
            //// when using show, we also need to inform the window that there is a dialog result
            this.DialogResult = true;
            this.Close();
        }
    }
}