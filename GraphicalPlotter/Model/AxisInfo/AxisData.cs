namespace GraphicalPlotter
{
    using System.Windows.Media;

    public class AxisData
    {
        // When min and max are set there need to some rules in which order they are set, or many they can only be set , maybe if one value is smaller then the other they just switch places?
        // TODO  fields

        private double maxVisibleValue;
        private double minVisibleValue;
        private Color axisColor;
        private bool visibility;

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

        public double MaxVisibleValue
        {
            get
            {
                return this.maxVisibleValue;
            }
            set
            {
                this.maxVisibleValue = value;
            }
        }

        public double MinVisibleValue
        {
            get
            {
                return this.minVisibleValue;
            }
            set
            {
                this.minVisibleValue = value;
            }
        }

        public Color AxisColor
        {
            get
            {
                return this.axisColor;
            }
            set
            {
                this.axisColor = value;
            }
        }

        public bool Visibility
        {
            get
            {
                return this.visibility;
            }
            set
            {
                this.visibility = value;
            }
        }
    }
}