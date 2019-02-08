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
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            var formAddViewModel = new FormAddViewModel();
            using (var form = new FormAdd(formAddViewModel))
            {
                form.ShowDialog();
            }

            _formMainViewModel.AddApplication(formAddViewModel.ApplicationName, formAddViewModel.ApplicationPath);
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            _formMainViewModel.Start();
            Close();
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