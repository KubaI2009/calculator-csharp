using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorCSharp;

namespace CalculatorCSharp.util
{
    public class CalculatorLabel : Label
    {
        private static readonly int s_maxTextWidth = 33;

        public CalculatorLabel(string name, byte x, byte y, CalculatorForm master) : base() 
        {
            PlacementData placementData = master.PlacementDataForCell(x, y, 4, 1);

            Location = placementData.Location;
            Name = name;
            Size = placementData.Size;
            Text = "";
            TextAlign = ContentAlignment.MiddleRight;
            BackColor = Color.White;
        }
    }
}
