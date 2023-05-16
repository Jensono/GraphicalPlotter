//-----------------------------------------------------------------------
// <copyright file="ColorPickerViewModel.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used as the viewmodel for the color picker window in which a user can choose a color for an element of the WPF application.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System.ComponentModel;
    using System.Windows.Media;

    /// <summary>
    /// This class is used as the view model for the color picker window.
    /// </summary>
    public class ColorPickerViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The field for the green value part of a color.
        /// </summary>
        private byte greenValue;

        /// <summary>
        /// The field for the red value part of a color.
        /// </summary>
        private byte redValue;

        /// <summary>
        /// The field for the blue value part of a color.
        /// </summary>
        private byte blueValue;

        /// <summary>
        /// The field for the selected color as a SolidColorBrush.
        /// </summary>
        private SolidColorBrush selectedColor;


        /// <summary>
        ///  Initializes a new instance of the <see cref="ColorPickerViewModel" /> class.
        /// </summary>
        /// <param name="color"> The Color that is the starting initial state for the Color Picker. </param>
        public ColorPickerViewModel(Color color)
        {
            this.RedValue = color.R;
            this.GreenValue = color.G;
            this.BlueValue = color.B;
            this.SelectedColor = new SolidColorBrush(Color.FromRgb(this.RedValue, this.GreenValue, this.BlueValue));

            this.PropertyChanged += this.UpdateBrushColor;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the red byte value for the color.
        /// </summary>
        /// <value> The current amount of red for the color.</value>
        public byte RedValue
        {
            get 
            {
                return this.redValue; 
            }

            set
            {
                this.redValue = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SelectedColor)));
            }
        }

        /// <summary>
        /// Gets or sets the green byte value for the color.
        /// </summary>
        /// <value> The current amount of green for the color.</value>
        public byte GreenValue
        {
            get 
            {
                return this.greenValue; 
            }

            set
            {
                this.greenValue = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SelectedColor)));
            }
        }

        /// <summary>
        /// Gets or sets the blue byte value for the color.
        /// </summary>
        /// <value> The current amount of blue for the color.</value>
        public byte BlueValue
        {
            get 
            { 
                return this.blueValue; 
            }

            set
            {
                this.blueValue = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SelectedColor)));
            }
        }


        /// <summary>
        /// Gets or sets the SolidColorBrush for the ColorPickerViewModel.
        /// </summary>
        /// <value> The current SolidColorBrush selected.</value>
        public SolidColorBrush SelectedColor
        {
            get
            {
                return this.selectedColor;
            }
            //// todo right object check and null check
            set
            {
                this.selectedColor = value;
            }
        }

        private void UpdateBrushColor(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.SelectedColor))
            {
                this.SelectedColor = new SolidColorBrush(Color.FromRgb(this.RedValue, this.GreenValue, this.BlueValue));
            }
        }
    }
}