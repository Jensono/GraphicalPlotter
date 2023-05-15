//-----------------------------------------------------------------------
// <copyright file="GraphicalFunctionDisplayNameForSerialization.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is used for serialization of a function , to be later saved to a file. So the user can import the functions later on.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;
    using System.Windows.Media;

    [Serializable]
    public class GraphicalFunctionDisplayNameForSerialization
    {
        

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

        public string FunctionName { get; set; }
        public string UserSetNameForFunction { get; set; }
        public Color FunctionColor { get; set; }
        public bool FunctionVisibility { get; set; }
    }
}