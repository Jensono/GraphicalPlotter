using System;
using System.Windows.Media;

namespace GraphicalPlotter
{
    [Serializable]
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