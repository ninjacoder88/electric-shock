using System.Windows.Forms;

namespace ElectricShock
{
    public partial class MainForm : Form
    {
        public MainForm(ViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        private readonly ViewModel _viewModel;
    }
}