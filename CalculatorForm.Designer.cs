using CalculatorCSharp.util;

namespace CalculatorCSharp
{
    partial class CalculatorForm
    {
        private static char?[] s_digits = { null, '0', null, '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public int Width
        {
            get;
            private set;
        }

        public int Height
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
            get { return (Height - PadY) / GridHeight - PadY; }
        }

        public int WidthOfSingleWidget
        {
            get { return (Width - PadX) / GridWidth - PadX; }
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
            ClientSize = new Size(Width, Height);
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
            List<DigitButton> digitButtons = new List<DigitButton>();

            for (byte i = 0; i < s_digits.Length; i++)
            {
                char? digit = s_digits[i];

                if (digit == null)
                {
                    continue;
                }

                DigitButton digitButton = new DigitButton($"btnDigit{s_digits[i]}", (char) digit, Convert.ToByte((i % 3) + 1), Convert.ToByte(GridHeight - (byte)(i / 3)), this);

                Controls.Add(digitButton);
            }

            //dot button
            DotButton dotButton = new DotButton("btnDot", 3, 7, this);

            Controls.Add(dotButton);

            //change sign button
            ChangeSignButton changeSignButton = new ChangeSignButton("btnChange", 1, 7, this);

            Controls.Add(changeSignButton);

            ResumeLayout(false);
        }

        public PlacementData PlacementDataForCell(byte column, byte row, byte columnSpan, byte rowSpan)
        {
            int x = PadX * column + WidthOfSingleWidget * (column - 1);
            int y = PadY * row + HeightOfSingleWidget * (row - 1);

            return new PlacementData(new Point(x, y), new Size(WidthOfSingleWidget * columnSpan + PadX * (columnSpan - 1), HeightOfSingleWidget * rowSpan + PadY * (rowSpan - 1)));
        }
    }
}
