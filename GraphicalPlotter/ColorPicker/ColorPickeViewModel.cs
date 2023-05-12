using System.ComponentModel;
using System.Windows.Media;

namespace GraphicalPlotter
{
    public class ColorPickeViewModel
    {
        private byte greenValue = 128;
        private byte redValue = 128;
        private byte blueValue = 128;

        public event PropertyChangedEventHandler PropertyChanged;

        public byte RedValue 
        {
            get { return redValue; }
            set
            {
                redValue = value;
                OnPropertyChanged(nameof(SelectedColor));
            }
        }

        public byte GreenValue
        {
            get { return greenValue; }
            set
            {
                greenValue = value;
                OnPropertyChanged(nameof(SelectedColor));
            }
        }

        public byte BlueValue 
        {
            get { return blueValue; }
            set
            {
                blueValue = value;
                OnPropertyChanged(nameof(SelectedColor));
            }
        }
        
        public Color SelectedColor { 
            get 
            {
                return  Color.FromRgb(RedValue, GreenValue, BlueValue);
            }           
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}