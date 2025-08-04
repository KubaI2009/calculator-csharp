namespace CalculatorCSharp.util;

public class OperationButton : CalculatorButton
{
    private CalculatorForm.TwoArgOperationDelegate _operation;
    
    public OperationButton(string name, string text, byte x, byte y, CalculatorForm.TwoArgOperationDelegate operation, CalculatorForm master) : base(name, text, x, y, master)
    {
        _operation = operation;
        Click += OperationButton_OnClick;
    }

    private void OperationButton_OnClick(object? sender, EventArgs? e)
    {
        if (Master.Input.Text.Length <= 0)
        {
            return;
        }

        if (Master.Input.Text[Master.Input.Text.Length - 1] == ',')
        {
            Master.Input.Text = Master.Input.Text.Substring(0, Master.Input.Text.Length - 1);
        }
        
        Master.A = Convert.ToDouble(Master.Input.Text);
        Master.EqualsButton.SetCurrentOperation(_operation);
        Master.Input.Text = "";
    }
}