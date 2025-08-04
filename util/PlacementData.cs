using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCSharp.util
{
    public struct PlacementData
    {
        public Point Location
        {
            get;
            private set;
        }

        public Size Size
        {
            get;
            private set;
        }

        public PlacementData(Point location, Size size)
        {
            Location = location;
            Size = size;
        }
    }
}
