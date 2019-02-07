using System.ComponentModel;
using ElectricShock.Models;

namespace ElectricShock
{
    public class ViewModel
    {
        public BindingList<ApplicationModel> Applications => _applicationModels ?? (_applicationModels = new BindingList<ApplicationModel>());

        private BindingList<ApplicationModel> _applicationModels;
    }
}