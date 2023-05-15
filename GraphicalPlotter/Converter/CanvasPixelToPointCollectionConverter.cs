//-----------------------------------------------------------------------
// <copyright file="CanvasPixelToPointCollectionConverter.cs" company="FHWN">
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
    internal class CanvasPixelToPointCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<CanvasPixel> canvasPixels = (List<CanvasPixel>)value;
            PointCollection points = new PointCollection();
            foreach (CanvasPixel pixel in canvasPixels)
            {
                points.Add(new Point(pixel.XAxisValue, pixel.YAxisValue));
            }

            return points;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}