using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalPlotter
{
    public class CanvasPixel
    {
        private int xAxisValue;
        public int XAxisValue
        {
            get
            {
                return this.xAxisValue;
            }
            set
            {
                //if (value < 0)
                //{
                //    throw new ArgumentOutOfRangeException($"The distance from the x-Axis , in particular the {nameof(XAxisValue)} must be positiv integer or zero to be displayed onto the canvas!");
                //}
                //else
                //{
                    this.xAxisValue = value;
                //}

            }
        }

        private int yAxisValue;
        public int YAxisValue
        {
            get
            {
                return this.yAxisValue;
            }
            set
            {
                //if (value < 0)
                //{
                //    throw new ArgumentOutOfRangeException($"The distance from the y-Axis , in particular the {nameof(YAxisValue)} must be positiv integer or zero to be displayed onto the canvas!");
                //}
                //else
                //{
                    this.yAxisValue = value;
                //}

            }
        }
        public CanvasPixel(int xAxisValue, int yAxisValue)
        {
            this.XAxisValue = xAxisValue;
            this.YAxisValue = yAxisValue;
        }


    }
}

