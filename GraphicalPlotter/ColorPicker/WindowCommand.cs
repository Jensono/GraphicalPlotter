//-----------------------------------------------------------------------
// <copyright file="WindowCommand.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class i used as the base for all the Commands that can be used inside the application.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// This class is used as the base for all the Commands that can be used inside the application.
    /// </summary>
    public class WindowCommand : ICommand
    {
        /// <summary>
        /// The field for the function that determines if it is executable.
        /// </summary>
        private Func<object, bool> canExecute;

        /// <summary>
        /// The field for the Action that should be performed.
        /// </summary>
        private Action<object> onExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowCommand"/> class.
        /// This class checks if a function can be executed.
        /// </summary>
        /// <param name="canExecute"> Function describing if the command can be executed.</param>
        /// <param name="onExecute"> The action that can should be executed.</param>
        public WindowCommand(Func<object, bool> canExecute, Action<object> onExecute)
        {
            this.CanExecuteFunction = canExecute;
            this.OnExecute = onExecute;
        }

        /// <summary>
        /// The event that is raised if the ability of the window Command to execute a function has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Gets the function for the window command.
        /// </summary>
        /// <value> The function that is used for the window command.</value>
        public Func<object, bool> CanExecuteFunction
        {
            get
            {
                return this.canExecute;
            }

            private set
            {
                this.canExecute = value;
            }
        }

        /// <summary>
        /// Gets the Action for the Window command that should be executed when the command is triggered.
        /// </summary>
        /// <value> Returns the Action that should be executed.</value>
        public Action<object> OnExecute
        {
            get
            {
                return this.onExecute;
            }

            private set
            {
                this.onExecute = value;
            }
        }

        /// <summary>
        /// This method returns a boolean value depending on the ability of the command to execute.
        /// </summary>
        /// <param name="parameter"> The object that should be checked for execution.</param>
        /// <returns> A boolean value indicating whether or not the function can be executed.</returns>
        public bool CanExecute(object parameter)
        {
            ////var useless = new EventArgs();
            ////this.CanExecuteChanged(this, useless);
            return this.CanExecuteFunction(parameter);
        }

        /// <summary>
        /// This method sends a Event for when the object starts execution.
        /// </summary>
        /// <param name="parameter"> The object that should be executed.</param>
        public void Execute(object parameter)
        {
            this.OnExecute(parameter);
        }
    }
}