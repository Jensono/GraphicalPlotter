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

namespace GraphicalPlotter
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ColorPickerWindow : Window
    {
        public SolidColorBrush SelectedColor { get; set; }
        public bool isColorPicked { get; set; }

        //need to change this to whatever color object is given TODO TODO
        ColorPickerViewModel colorPickerViewModel = new ColorPickerViewModel(Color.FromRgb(127,127,127));
        public ColorPickerWindow()
        {
            InitializeComponent();
            //maybe only set the datacontext for the colorpicker?
            DataContext = colorPickerViewModel;
        }

        
        private void OKButton_Click(object sender,RoutedEventArgs e)
        {
            SelectedColor = colorPickerViewModel.SelectedColor;
            isColorPicked = true;
            // when using show, we also need to inform the window that there is a dialog result
            DialogResult = true;
            Close();
        }
    }
}
