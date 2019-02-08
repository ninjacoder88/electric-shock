using System.Windows.Forms;

namespace ElectricShock.AppForms
{
    public partial class MainForm : Form
    {
        public MainForm(ViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();

            dgvApplications.DataSource = _viewModel.Applications;

            tbxApplicationName.DataBindings.Add(nameof(tbxApplicationName.Text), _viewModel, nameof(_viewModel.ApplicationName));
            tbxApplicationPath.DataBindings.Add(nameof(tbxApplicationPath.Text), _viewModel, nameof(_viewModel.ApplicationPath));
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            _viewModel.AddApplication();
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            _viewModel.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _viewModel.Save();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            _viewModel.LoadApplications();
        }

        private readonly ViewModel _viewModel;
    }
}