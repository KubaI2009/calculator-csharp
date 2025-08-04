using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorCSharp;

namespace CalculatorCSharp.util
{
    public class DigitButton : CalculatorButton
    {
        private static readonly char s_zero = '0';

        private char _digit;

        public char Digit
        {
            get { return _digit; }
            private set { _digit = value; }
        }

        public DigitButton(string name, char digit, byte x, byte y, CalculatorForm master) : base (name, digit.ToString(), x, y, master)
        {
            Digit = digit;
            Click += Digit == s_zero ? ZeroButton_OnClick : DigitButton_OnClick;
        }

        private void DigitButton_OnClick(object? sender, EventArgs? e)
        {
            Master.Input.Text += Digit.ToString();
        }

        private void ZeroButton_OnClick(object? sender, EventArgs? e)
        {
            Master.Input.Text += Master.Input.Text.Length > 0 ? Master.Input.Text[0] != 0 ? Digit.ToString() : "" : "";
        }
    }
}
