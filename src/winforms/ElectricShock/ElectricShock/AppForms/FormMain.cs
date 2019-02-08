using System.Windows.Forms;
using ElectricShock.Models;

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

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            var rows = dgvApplications.SelectedRows;

            if (rows.Count != 1)
            {
                return;
            }

            var selectedRow = rows[0];

            var model = selectedRow.DataBoundItem as ApplicationModel;

            if (model == null)
            {
                return;
            }

            _formMainViewModel.Remove(model);
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