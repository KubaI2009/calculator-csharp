using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorTrue;

namespace CalculatorCSharp.util
{
    public abstract class CalculatorButton : Button
    {
        private CalculatorWindow _master;

        public CalculatorWindow Master
        {
            get { return _master; }
            private set { _master = value; }
        }
        
        protected CalculatorButton(string name, string text, byte x, byte y, CalculatorWindow master) : base()
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
