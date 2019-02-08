using System.Windows.Forms;

namespace ElectricShock.AppForms
{
    public partial class FormMain : Form
    {
        public FormMain(FormMainViewModel formMainViewModel)
        {
            _formMainViewModel = formMainViewModel;
            InitializeComponent();

            dgvApplications.DataSource = _formMainViewModel.Applications;

            tbxApplicationName.DataBindings.Add(nameof(tbxApplicationName.Text), _formMainViewModel, nameof(_formMainViewModel.ApplicationName));
            tbxApplicationPath.DataBindings.Add(nameof(tbxApplicationPath.Text), _formMainViewModel, nameof(_formMainViewModel.ApplicationPath));
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            _formMainViewModel.AddApplication();
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            _formMainViewModel.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formMainViewModel.Save();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            _formMainViewModel.LoadApplications();
        }

        private readonly FormMainViewModel _formMainViewModel;
    }
}