namespace CalculatorTrue
{
    public partial class CalculatorWindow : Form
    {
        public CalculatorWindow()
        {
            Width = 300;
            Height = 350;
            PadX = 3;
            PadY = 3;

            A = null;
            B = null;

            GridHeight = 7;
            GridWidth = 4;

            InitializeComponent();
        }
    }
}