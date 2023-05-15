//-----------------------------------------------------------------------
// <copyright file="TwoDimensionalGraphCanvas.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class contains all the information needed to draw or concept out a two dimensional Canvas used for graphing function.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;

    public class TwoDimensionalGraphCanvas
    {
        private int widthInPixel;
        private int heightInPixel;
        private AxisData xAxisData;
        private AxisData yAxisData;
        private AxisGridData xAxisGridData;
        private AxisGridData yAxisGridData;

        public TwoDimensionalGraphCanvas(int widthPixel, int heightPixel, AxisData xAxisData, AxisData yAxisData, AxisGridData xAxisGrid, AxisGridData yAxisGrid)
        {
            this.WidthInPixel = widthPixel;
            this.HeightInPixel = heightPixel;
            this.XAxisData = xAxisData;
            this.YAxisData = yAxisData;
            this.XAxisGridData = xAxisGrid;
            this.YAxisGridData = yAxisGrid;
        }

        public int WidthInPixel
        {
            get { return this.widthInPixel; }
            set { this.widthInPixel = value; }
        }

        public int HeightInPixel
        {
            get { return this.heightInPixel; }
            set { this.heightInPixel = value; }
        }

        public AxisData XAxisData
        {
            get
            {
                return this.xAxisData;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.XAxisData)} can not be null!");
                }

                this.xAxisData = value;
            }
        }

        public AxisData YAxisData
        {
            get
            {
                return this.yAxisData;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.YAxisData)} cannot be null!");
                }

                this.yAxisData = value;
            }
        }

        public AxisGridData XAxisGridData
        {
            get 
            {
                return this.xAxisGridData;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.XAxisGridData)} cannot be null!");
                }

                this.xAxisGridData = value;
            }
        }

        public AxisGridData YAxisGridData
        {
            get 
            {
                return this.yAxisGridData;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(this.YAxisGridData)} cannot be null!");
                }

                this.yAxisGridData = value;
            }
        }
    }
}