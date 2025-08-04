using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorTrue;

namespace CalculatorCSharp.util
{
    public class EqualsButton : CalculatorButton
    {
        public EqualsButton(string name, byte x, byte y, CalculatorWindow master) : base(name, "=", x, y, master)
        {
            BackColor = Color.YellowGreen;
        }
    }
}
