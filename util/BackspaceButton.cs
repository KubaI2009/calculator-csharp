using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCSharp.util
{
    public class BackspaceButton : CalculatorButton
    {
        public BackspaceButton(string name, byte x, byte y, CalculatorForm master) : base(name, "<-", x, y, master)
        {
            
        }
    }
}
