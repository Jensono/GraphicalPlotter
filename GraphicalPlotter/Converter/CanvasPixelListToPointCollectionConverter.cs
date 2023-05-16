//-----------------------------------------------------------------------
// <copyright file="CanvasPixelListToPointCollectionConverter.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is a converter that takes a canvas pixel and converts it into a point that can be used by the WPF application.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;

    /// <summary>
    /// This class is used as an converter to convert from Canvas Pixel object to a Point object.
    /// </summary>
    public class CanvasPixelListToPointCollectionConverter : IValueConverter
    {
        /// <summary>
        /// This method Converts a list of CanvasPixel object into a PointCollection object that can be used by the polyline.
        /// </summary>
        /// <param name="value"> The value for the object that should be converted.</param>
        /// <param name="targetType"> The type of object the convert should happen to.</param>
        /// <param name="parameter"> The converter parameter for the conversion.</param>
        /// <param name="culture"> The culture info for the convert.</param>
        /// <returns> A point object that was generated from a CanvasPixel.</returns>
        /// <exception cref="ArgumentNullException"> Is raised if value was null.</exception>
        /// <exception cref="ArgumentException"> Is raised if value is not of Type <see cref="List{CanvasPixel}"/> .</exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{nameof(value)} can not be null");
            }

            if (value is List<CanvasPixel>)
            {               
                List<CanvasPixel> canvasPixels = (List<CanvasPixel>)value;
                PointCollection points = new PointCollection();
                foreach (CanvasPixel pixel in canvasPixels)
                {
                    points.Add(new Point(pixel.XAxisValue, pixel.YAxisValue));
                }

                return points;
            }
            else
            {
                throw new ArgumentException($"{nameof(value)} must be an object of {nameof(List<CanvasPixel>)}");
            }          
        }

        /// <summary>
        /// This method converts back from a PointCollection to a list of Canvas Pixel. IS NOT IMPLEMENTED AT THE MOMENT, because it is never used.
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