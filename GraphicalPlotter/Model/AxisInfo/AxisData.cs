using System.Windows.Media;

namespace GraphicalPlotter
{
    public class AxisData
    {
        // When min and max are set there need to some rules in which order they are set, or many they can only be set , maybe if one value is smaller then the other they just switch places?
        public double MaxVisibleValue { get; set; }

        public double MinVisibleValue { get; set; }
        public Color AxisColor { get; set; }

        public bool Visibility { get; set; }

        public AxisData(double minValue, double maxValue, Color axisColor, bool isVisible)
        {
            this.MinVisibleValue = minValue;
            this.MaxVisibleValue = maxValue;
            this.AxisColor = axisColor;
            this.Visibility = isVisible;
        }

        // Empty constructor for serialization
        public AxisData()
        { }
    }
}