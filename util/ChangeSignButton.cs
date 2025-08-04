using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorTrue;

namespace CalculatorCSharp.util
{
    public class ChangeSignButton : CalculatorButton
    {
        private static readonly char s_minusSymbol = '-';

        public ChangeSignButton(string name, byte x, byte y, CalculatorWindow master) : base(name, "+/-", x, y, master)
        {
            Click += ChangeSignButton_OnClick;
        }

        private void ChangeSignButton_OnClick(object? sender, EventArgs? e)
        {
            if (Master.Input.Text.Length <= 0)
            {
                return;
            }

            Master.Input.Text = Master.Input.Text[0] == s_minusSymbol ? Master.Input.Text.Substring(1) : $"{s_minusSymbol}{Master.Input.Text}";
        }
    }
}
