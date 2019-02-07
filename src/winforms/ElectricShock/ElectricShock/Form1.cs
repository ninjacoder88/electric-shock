using System.Windows.Forms;

namespace ElectricShock
{
    public partial class Form1 : Form
    {
        public Form1(ViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        private readonly ViewModel _viewModel;
    }
}