//-----------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class is the main view model used by the wpf app as a big interface for the model.
// </summary>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace GraphicalPlotter
{
    public class SteeringWheelStartAnimationEventArguments : EventArgs
    {
        public List<AnimationPointImage> AnimationPoints { get; }

        public SteeringWheelStartAnimationEventArguments(List<AnimationPointImage> animationPoints)
        {
            AnimationPoints = animationPoints;
        }
    }
}