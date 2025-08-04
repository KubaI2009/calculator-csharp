using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorCSharp;

namespace CalculatorCSharp.util
{
    public class EqualsButton : CalculatorButton
    {
        public EqualsButton(string name, byte x, byte y, CalculatorForm master) : base(name, "=", x, y, master)
        {
            BackColor = Color.YellowGreen;
        }
    }
}
