﻿//-----------------------------------------------------------------------
// <copyright file="ColorToSolidBrushConverter.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is a converter that takes a Color and converts it into a SolidBrush, used to draw inside the view.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    /// <summary>
    /// This class is used as a Converter for the WPF app that converts a Color to a SolidColorBrush.
    /// </summary>
    public class ColorToSolidBrushConverter : IValueConverter
    {
        /// <summary>
        /// This method Converts a Color into a SolidColorBrush object that can be used by the polyline.
        /// </summary>
        /// <param name="value"> The value for the object that should be converted.</param>
        /// <param name="targetType"> The type of object the convert should happen to.</param>
        /// <param name="parameter"> The converter parameter for the conversion.</param>
        /// <param name="culture"> The culture info for the convert.</param>
        /// <returns> A SolidColorBrush that was generated from the given Color. </returns>
        /// <exception cref="ArgumentNullException"> Is raised if value was null.</exception>
        /// <exception cref="ArgumentException"> Is raised if value is not of Type <see cref="Color"/>. </exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{nameof(value)} can not be null");
            }

            if (value is Color)
            {
                Color color = (Color)value;
                return new SolidColorBrush(color);
            }
            else
            {
                throw new ArgumentException($"{nameof(value)} must be an object of {nameof(Color)}");
            }                       
        }

        /// <summary>
        /// This method converts back from a SolidColorBrush to a Color. IS NOT IMPLEMENTED AT THE MOMENT, because it is never used.
        /// </summary>
        /// <param name="value"> The value for the object that should be converted.</param>
        /// <param name="targetType"> The type of object the convert should happen to.</param>
        /// <param name="parameter"> The converter parameter for the conversion.</param>
        /// <param name="culture"> The culture info for the convert.</param>
        /// <returns> A List of Canvas Points.</returns>
        [Obsolete]
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}