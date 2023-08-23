//-----------------------------------------------------------------------
// <copyright file="SteeringWheelStartAnimationEventArguments.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class represents the Event arguments for when the steering wheel animation should be started inside the application.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class represents the Event arguments for when the steering wheel animation should be started inside the application.
    /// </summary>
    public class SteeringWheelStartAnimationEventArguments : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SteeringWheelStartAnimationEventArguments" /> class. 
        /// </summary>
        /// <param name="animationPoints"> The list of animation points that should be used for the animation of the steering wheel.</param>
        public SteeringWheelStartAnimationEventArguments(List<AnimationPointImage> animationPoints)
        {
            this.AnimationPoints = animationPoints;
        }

        /// <summary>
        /// Gets the List of Animation Points that are given with the event arguments for the animation.
        /// </summary>
        /// <value> The list of animation points inside the event arguments.</value>
        public List<AnimationPointImage> AnimationPoints { get; }
    }
}