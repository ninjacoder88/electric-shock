using System;
using System.Windows.Forms;

namespace ElectricShock.AppForms
{
    public partial class FormAdd : Form
    {
        public FormAdd(FormAddViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            tbxApplicationName.DataBindings.Add(nameof(tbxApplicationName.Text), _viewModel, nameof(_viewModel.ApplicationName));
            tbxApplicationPath.DataBindings.Add(nameof(tbxApplicationPath.Text), _viewModel, nameof(_viewModel.ApplicationPath));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Multiselect = false;
                dialog.CheckFileExists = true;
                _viewModel.ApplicationPath = dialog.FileName;
                _viewModel.ApplicationName = dialog.SafeFileName;
            }
        }

        private readonly FormAddViewModel _viewModel;
    }
}