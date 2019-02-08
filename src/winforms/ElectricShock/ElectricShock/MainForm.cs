using System.Windows.Forms;
using ElectricShock.Models;

namespace ElectricShock
{
    public partial class MainForm : Form
    {
        public MainForm(ViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();

            clbApplications.DataSource = _viewModel.Applications;
            clbApplications.DisplayMember = nameof(ApplicationModel.Name);
            clbApplications.ValueMember = nameof(ApplicationModel.IsSelected);

            tbxApplicationName.DataBindings.Add(nameof(tbxApplicationName.Text), _viewModel, nameof(_viewModel.ApplicationName));
            tbxApplicationPath.DataBindings.Add(nameof(tbxApplicationPath.Text), _viewModel, nameof(_viewModel.ApplicationPath));
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            _viewModel.LoadApplications();
        }

        private readonly ViewModel _viewModel;

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            _viewModel.Start();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            _viewModel.AddApplication();
        }
    }
}