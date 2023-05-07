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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicalPlotter
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();




            //List<double> testCases = new List<double>() { -3, -2, -1, 0, 1, 2, 3, Math.PI };
            //GraphicalFunction polyFunction = new GraphicalFunction(new List<FunctionParts>() { new PolynomialComponent(2, 1) }, new Color()); ;
            //GraphicalFunction sinFunction = new GraphicalFunction(new List<FunctionParts>() { new SineFunction(1, 1) }, new Color());
            //GraphicalFunction cosFunction = new GraphicalFunction(new List<FunctionParts>() { new CosineFunction(1, 1) }, new Color());
            //GraphicalFunction tanFunction = new GraphicalFunction(new List<FunctionParts>() { new TangentFunction(1, 1) }, new Color());
            //foreach (var item in testCases)
            //{
            //    double result = polyFunction.CalculateSumOfAllPartsForValue(item);
            //    double result2 = sinFunction.CalculateSumOfAllPartsForValue(item);
            //    double result3 = cosFunction.CalculateSumOfAllPartsForValue(item);
            //    double result4 = tanFunction.CalculateSumOfAllPartsForValue(item);

            //}

           

            //FunctionDrawInformation polyDraw = converter.ConvertFunctionIntoDrawInformation(polyFunction);
            //string poly = FunctionDrawInformationToString(polyDraw);
            //FunctionDrawInformation sinDraw = converter.ConvertFunctionIntoDrawInformation(sinFunction);
            //string sinString = FunctionDrawInformationToString(sinDraw);
            //FunctionDrawInformation cosDraw = converter.ConvertFunctionIntoDrawInformation(cosFunction);
            //FunctionDrawInformation tanDraw = converter.ConvertFunctionIntoDrawInformation(tanFunction);

            // write test for negativ exponents and all the trigometric functions
        }

        //public string FunctionDrawInformationToString(FunctionDrawInformation data)
        //{
        //    string returnString = "";
        //    foreach (CanvasPixel item in data.CanvasPixels)
        //    {
        //        returnString += "{"+$"{item.XAxisValue},{item.YAxisValue}"+"},";
        //    }
        //    return returnString;

        //}
    }
}
