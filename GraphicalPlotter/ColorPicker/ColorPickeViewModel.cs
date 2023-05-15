
namespace GraphicalPlotter
{
    using System.ComponentModel;
    using System.Windows.Media;

    public class ColorPickerViewModel : INotifyPropertyChanged
    {
        private byte greenValue;
        private byte redValue;
        private byte blueValue;
        private SolidColorBrush selectedColor;

        

        public ColorPickerViewModel(Color color)
        {
            this.RedValue = color.R;
            this.GreenValue = color.G;
            this.BlueValue = color.B;
            this.SelectedColor = new SolidColorBrush(Color.FromRgb(this.RedValue, this.GreenValue, this.BlueValue));

            this.PropertyChanged += this.UpdateBrushColor;
        }

        public event PropertyChangedEventHandler PropertyChanged;


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