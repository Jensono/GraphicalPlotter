

namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    /// <summary>
    ///
    /// </summary>
    public partial class ColorPickerWindow : Window
    {
                      
        private ColorPickerViewModel colorPickerViewModel = new ColorPickerViewModel(Color.FromRgb(127, 127, 127));

        public ColorPickerWindow()
        {
            this.InitializeComponent();
            this.DataContext = this.colorPickerViewModel;
        }

        public SolidColorBrush SelectedColor { get; set; }
        public bool IsColorPicked { get; set; }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.SelectedColor = this.colorPickerViewModel.SelectedColor;
            this.IsColorPicked = true;
            //// when using show, we also need to inform the window that there is a dialog result
            this.DialogResult = true;
            this.Close();
        }
    }
}