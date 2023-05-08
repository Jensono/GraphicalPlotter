using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace GraphicalPlotter
{
    class CanvasPixelToPointCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<CanvasPixel> canvasPixels = (List<CanvasPixel>)value;
            PointCollection points = new PointCollection();
            foreach (CanvasPixel pixel in canvasPixels)
            {
                points.Add(new Point(pixel.XAxisValue,pixel.YAxisValue));
            }
            return points;


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
