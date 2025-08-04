using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorCSharp;

namespace CalculatorCSharp.util
{
    public class DecimalPlaceButton : CalculatorButton
    {
        private static readonly char s_dotSymbol = ',';

        public DecimalPlaceButton(string name, byte x, byte y, CalculatorForm master) : base(name, s_dotSymbol.ToString(), x, y, master)
        {
            Click += DigitButton_OnClick;
        }

        private void DigitButton_OnClick(object? sender, EventArgs? e)
        {
            Master.Input.Text += Master.Input.Text.Contains(s_dotSymbol) || Master.Input.Text.Length <= 0 ? "" : s_dotSymbol.ToString();
        }
    }
}
