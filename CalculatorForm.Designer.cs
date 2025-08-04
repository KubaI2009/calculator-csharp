using CalculatorCSharp.util;

namespace CalculatorCSharp
{
    partial class CalculatorForm
    {
        private static readonly char?[] s_digits = { null, '0', null, '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        
        public delegate string TwoArgOperationDelegate(double a, double b);
        
        private static readonly TwoArgOperationDelegate s_addition = (a, b) => NoDecimalIfPossible(a + b);
        private static readonly TwoArgOperationDelegate s_subtraction = (a, b) => NoDecimalIfPossible(a - b);
        private static readonly TwoArgOperationDelegate s_multiplication = (a, b) => NoDecimalIfPossible(a * b);
        private static readonly TwoArgOperationDelegate s_division = (a, b) => NoDecimalIfPossible(a / b);
        
        private static readonly Dictionary<string, TwoArgOperationDelegate> s_operations = new Dictionary<string, TwoArgOperationDelegate>()
        {
            {"Addition", s_addition},
            {"Subtraction", s_subtraction},
            {"Multiplication", s_multiplication},
            {"Division", s_division}
        };

        private static readonly Dictionary<TwoArgOperationDelegate, char> s_operationsSymbols = new Dictionary<TwoArgOperationDelegate, char>()
        { 
            { s_addition, '+' }, 
            { s_subtraction, '-' }, 
            { s_multiplication, '×' }, 
            { s_division, '÷' }
        };

        public int FormWidth
        {
            get;
            private set;
        }

        public int FormHeight
        {
            get;
            private set;
        }

        public int PadX
        {
            get;
            private set;
        }

        public int PadY
        {
            get;
            private set;
        }

        public CalculatorLabel Output
        {
            get;
            private set;
        }

        public CalculatorLabel Input
        {
            get;
            private set;
        }

        public EqualsButton? EqualsButton
        {
            get;
            set;
        }

        public double? A 
        {
            get;
            set;
        }
        public double? B 
        {
            get;
            set;
        }

        public byte GridHeight
        {
            get;
            private set;
        }

        public byte GridWidth
        {
            get;
            private set;
        }

        public int HeightOfSingleWidget
        {
            get { return (FormHeight - PadY) / GridHeight - PadY; }
        }

        public int WidthOfSingleWidget
        {
            get { return (FormWidth - PadX) / GridWidth - PadX; }
        }

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        ///  You ain't stopping me
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();

            //window
            AutoScaleDimensions = new SizeF(8f, 20f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(FormWidth, FormHeight);
            Name = "wfRoot";
            Text = "Calculator";
            BackColor = Color.DarkGray;

            //output label
            Output = new CalculatorLabel("lblOutput", 1, 1, this);

            Controls.Add(Output);

            //input label
            Input = new CalculatorLabel("lblInput", 1, 2, this);

            Controls.Add(Input);

            //equals button
            EqualsButton = new EqualsButton("btnEquals", 4, 3, this);

            Controls.Add(EqualsButton);

            //digit buttons
            for (byte i = 0; i < s_digits.Length; i++)
            {
                char? digit = s_digits[i];

                if (digit == null)
                {
                    continue;
                }

                DigitButton button = new DigitButton($"btnDigit{s_digits[i]}", (char) digit, Convert.ToByte((i % 3) + 1), Convert.ToByte(GridHeight - (byte)(i / 3)), this);

                Controls.Add(button);
            }

            //decimal place button
            DecimalPlaceButton decimalPlaceButton = new DecimalPlaceButton("btnDot", 3, 7, this);

            Controls.Add(decimalPlaceButton);

            //change sign button
            ChangeSignButton changeSignButton = new ChangeSignButton("btnChange", 1, 7, this);

            Controls.Add(changeSignButton);
            
            //all clear button
            AllClearButton allClearButton = new AllClearButton("btnAllClear", 1, 3, this);
            
            Controls.Add(allClearButton);
            
            //clear button
            ClearButton clearButton = new ClearButton("btnClear", 2, 3, this);
            
            Controls.Add(clearButton);
            
            //backspace button
            BackspaceButton backspaceButton = new BackspaceButton("btnBackspace", 3, 3, this);
            
            Controls.Add(backspaceButton);
            
            //operation button
            byte operationButtonIndex = 0;

            foreach ((string k, TwoArgOperationDelegate v) in s_operations)
            {
                OperationButton button = new OperationButton($"btn{k}", s_operationsSymbols[v].ToString(), 4, Convert.ToByte(4 + operationButtonIndex), v, this);
                
                Controls.Add(button);
                
                operationButtonIndex++;
            }

            ResumeLayout(false);
        }

        public PlacementData PlacementDataForCell(byte column, byte row, byte columnSpan, byte rowSpan)
        {
            int x = PadX * column + WidthOfSingleWidget * (column - 1);
            int y = PadY * row + HeightOfSingleWidget * (row - 1);

            return new PlacementData(new Point(x, y), new Size(WidthOfSingleWidget * columnSpan + PadX * (columnSpan - 1), HeightOfSingleWidget * rowSpan + PadY * (rowSpan - 1)));
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
