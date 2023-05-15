using System.ComponentModel;
using System.Windows.Media;

namespace GraphicalPlotter
{
    public class ColorPickerViewModel : INotifyPropertyChanged
    {
        private byte greenValue;
        private byte redValue;
        private byte blueValue;

        public event PropertyChangedEventHandler PropertyChanged;

        public ColorPickerViewModel(Color color)
        {
            this.RedValue = color.R;
            this.GreenValue = color.G;
            this.BlueValue = color.B;
            this.SelectedColor = new SolidColorBrush(Color.FromRgb(RedValue, GreenValue, BlueValue));

            PropertyChanged += UpdateBrushColor;
        }

        private void UpdateBrushColor(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedColor))
            {
                this.SelectedColor = new SolidColorBrush(Color.FromRgb(RedValue, GreenValue, BlueValue));
            }
        }

        public byte RedValue
        {
            get { return redValue; }
            set
            {
                redValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedColor)));
            }
        }

        public byte GreenValue
        {
            get { return greenValue; }
            set
            {
                greenValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedColor)));
            }
        }

        public byte BlueValue
        {
            get { return blueValue; }
            set
            {
                blueValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedColor)));
            }
        }

        private SolidColorBrush selectedColor;

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
    }
}