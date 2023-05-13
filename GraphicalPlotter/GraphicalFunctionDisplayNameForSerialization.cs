using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GraphicalPlotter
{
    [Serializable]
    //TODO rename class
    public class GraphicalFunctionDisplayNameForSerialization
    {
        public string FunctionName { get; set; }
        public string UserSetNameForFunction { get; set; }
        public Color FunctionColor { get; set; }
        public bool FunctionVisibility { get; set; }
        public GraphicalFunctionDisplayNameForSerialization(GraphicalFunctionViewModel functionViewModel)
        {
            this.FunctionName = functionViewModel.FunctionDisplayName;
            this.FunctionColor = functionViewModel.FunctionColor;
            this.UserSetNameForFunction = functionViewModel.CustomUserSetName;
            this.FunctionVisibility = functionViewModel.FunctionVisibility;

                

        }
        public GraphicalFunctionDisplayNameForSerialization()
        {

        }
    }
}
