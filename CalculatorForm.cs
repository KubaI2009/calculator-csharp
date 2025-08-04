namespace CalculatorCSharp
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            FormWidth = 300;
            FormHeight = 350;
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