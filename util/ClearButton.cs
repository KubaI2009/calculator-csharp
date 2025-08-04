using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCSharp.util
{
    public class ClearButton : CalculatorButton
    {
        public ClearButton(string name, byte x, byte y, CalculatorForm master) : base(name, "C", x, y, master)
        {
            Click += BackspaceButton_OnClick;
        }

        private void BackspaceButton_OnClick(object? sender, EventArgs? e)
        {
            Master.Input.Text = "";
        }
    }
}
