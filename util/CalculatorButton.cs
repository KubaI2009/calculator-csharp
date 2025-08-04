using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorCSharp;
using CalculatorCSharp;

namespace CalculatorCSharp.util
{
    public abstract class CalculatorButton : Button
    {
        private CalculatorForm _master;

        public CalculatorForm Master
        {
            get { return _master; }
            private set { _master = value; }
        }
        
        protected CalculatorButton(string name, string text, byte x, byte y, CalculatorForm master) : base()
        {
            PlacementData placementData = master.PlacementDataForCell(x, y, 1, 1);

            Location = placementData.Location;
            Name = name;
            Text = text;
            Size = placementData.Size;
            Master = master;
            TabIndex = 0;
            UseVisualStyleBackColor = true;
            BackColor = Color.Gray;
        }
    }
}
