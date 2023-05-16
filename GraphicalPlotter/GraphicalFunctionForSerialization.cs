//-----------------------------------------------------------------------
// <copyright file="GraphicalFunctionForSerialization.cs" company="FHWN">
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

    /// <summary>
    /// This class is used for as the serializing equivalent for the GraphicalFunction class.
    /// </summary>
    [Serializable]
    public class GraphicalFunctionForSerialization
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="GraphicalFunctionForSerialization" /> class.
        /// </summary>
        /// <param name="functionViewModel"> The GraphicalFunction that is used as the base for the serialization class.</param>
        public GraphicalFunctionForSerialization(GraphicalFunctionViewModel functionViewModel)
        {
            this.FunctionName = functionViewModel.FunctionDisplayName;
            this.FunctionColor = functionViewModel.FunctionColor;
            this.UserSetNameForFunction = functionViewModel.CustomUserSetName;
            this.FunctionVisibility = functionViewModel.FunctionVisibility;
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="GraphicalFunctionForSerialization" /> class. Used for Serialization.
        /// </summary>
        public GraphicalFunctionForSerialization()
        {
        }

        /// <summary>
        /// Gets or sets the string that is used to show the mathematical function.
        /// </summary>
        /// <value> The string that is used to show the mathematical function.</value>
        public string FunctionName { get; set; }

        /// <summary>
        /// Gets or sets the string that is set by the user to name the function.
        /// </summary>
        /// <value> The string  that is set by the user to name the function.</value>
        public string UserSetNameForFunction { get; set; }

        /// <summary>
        /// Gets or sets the Color of the Function.
        /// </summary>
        /// <value> The current color for the function.</value>
        public Color FunctionColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the function is visible.
        /// </summary>
        /// <value> The visibility of the function.</value>
        public bool FunctionVisibility { get; set; }
    }
}