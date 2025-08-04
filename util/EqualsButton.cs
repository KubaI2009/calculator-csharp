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
        private CalculatorForm.TwoArgOperationDelegate? _currentOperation;
        
        public EqualsButton(string name, byte x, byte y, CalculatorForm master) : base(name, "=", x, y, master)
        {
            _currentOperation = null;
            BackColor = Color.YellowGreen;
            Click += EqualsButton_OnClick;
        }

        private void EqualsButton_OnClick(object? sender, EventArgs? e)
        {
            if (Master.Input.Text.Length <= 0)
            {
                return;
            }

            if (Master.Input.Text[Master.Input.Text.Length - 1] == ',')
            {
                Master.Input.Text = Master.Input.Text.Substring(0, Master.Input.Text.Length - 1);
            }
            
            if (_currentOperation == null)
            {
                Reset();
                
                Master.Output.Text = NoDecimalIfPossible(Convert.ToDouble(Master.Input.Text));
                
                return;
            }
            
            Master.B = Convert.ToDouble(Master.Input.Text);

            string result = _currentOperation((double) Master.A, (double) Master.B);
            
            Master.Output.Text = result;
            Master.Input.Text = result;
            
            Reset();
        }

        public void SetCurrentOperation(CalculatorForm.TwoArgOperationDelegate operation)
        {
            _currentOperation = operation;
        }

        private void Reset()
        {
            _currentOperation = null;
            Master.A = null;
            Master.B = null;
        }

        private static string NoDecimalIfPossible(double d)
        {
            if (d % 1 == 0)
            {
                return ((int) d).ToString();
            }
            
            return d.ToString();
        }
    }
}
