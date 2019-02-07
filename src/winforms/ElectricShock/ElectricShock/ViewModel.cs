using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using ElectricShock.Models;
using Newtonsoft.Json;

namespace ElectricShock
{
    public class ViewModel
    {
        public BindingList<ApplicationModel> Applications => _applicationModels ?? (_applicationModels = new BindingList<ApplicationModel>());

        public void AddApplication(string name, string path)
        {
            if (!File.Exists(_configurationFilePath))
            {
                File.Create(_configurationFilePath);
            }

            Applications.Add(new ApplicationModel {Name = name, Path = path});

            var jsonObject = JsonConvert.SerializeObject(Applications);
            File.Delete(_configurationFilePath);
            File.WriteAllText(_configurationFilePath, jsonObject);
        }

        public void LoadApplications()
        {
            if (!File.Exists(_configurationFilePath))
            {
                return;
            }

            string fileText = File.ReadAllText(_configurationFilePath);
            var list = JsonConvert.DeserializeObject<List<ApplicationModel>>(fileText);

            Applications.Clear();

            foreach (var applicationModel in list)
            {
                Applications.Add(applicationModel);
            }
        }

        public void Start()
        {
            foreach (var applicationModel in Applications)
            {
                Process.Start(applicationModel.Path);
            }
        }

        private BindingList<ApplicationModel> _applicationModels;
        private readonly string _configurationFilePath = @"C:\config\electric-shock.json";
    }
}