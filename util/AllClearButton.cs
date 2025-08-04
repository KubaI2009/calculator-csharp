using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCSharp.util
{
    public class AllClearButton : CalculatorButton
    {
        public AllClearButton(string name, byte x, byte y, CalculatorForm master) : base(name, "AC", x, y, master)
        {
            Click += BackspaceButton_OnClick;
        }

        private void BackspaceButton_OnClick(object? sender, EventArgs? e)
        {
            Master.Output.Text = "";
            Master.Input.Text = "";
            Master.EqualsButton.SetCurrentOperation(null);
        }
    }
}
