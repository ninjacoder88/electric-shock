using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ElectricShock.Models;
using Newtonsoft.Json;

namespace ElectricShock
{
    public class FormMainViewModel
    {
        public BindingList<ApplicationModel> Applications => _applicationModels ?? (_applicationModels = new BindingList<ApplicationModel>());

        public void AddApplication(string applicationName, string applicationPath)
        {
            if (string.IsNullOrEmpty(applicationName))
            {
                return;
            }

            if (string.IsNullOrEmpty(applicationPath))
            {
                return;
            }

            Applications.Add(new ApplicationModel {Name = applicationName, Path = applicationPath, Start = true});
        }

        public void LoadApplications()
        {
            if (!Directory.Exists(_configurationDirectory))
            {
                return;
            }

            string filePath = Path.Combine(_configurationDirectory, _configurationFileName);

            if (!File.Exists(filePath))
            {
                return;
            }

            string fileText = File.ReadAllText(filePath);
            var list = JsonConvert.DeserializeObject<List<ApplicationModel>>(fileText);

            Applications.Clear();

            foreach (var applicationModel in list)
            {
                Applications.Add(applicationModel);
            }
        }

        public void Remove(ApplicationModel model)
        {
            Applications.Remove(model);
        }

        public void Save()
        {
            if (!Directory.Exists(_configurationDirectory))
            {
                Directory.CreateDirectory(_configurationDirectory);
            }

            string filePath = Path.Combine(_configurationDirectory, _configurationFileName);

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            var jsonObject = JsonConvert.SerializeObject(Applications);

            File.Delete(filePath);

            File.WriteAllText(filePath, jsonObject);
        }

        public void Start()
        {
            foreach (var applicationModel in Applications.Where(x => x.Start))
            {
                if (!string.IsNullOrEmpty(applicationModel.Arguments))
                {
                    Process.Start(applicationModel.Path, applicationModel.Arguments);
                }
                else
                {
                    Process.Start(applicationModel.Path);
                }
            }
        }

        private BindingList<ApplicationModel> _applicationModels;
        private readonly string _configurationFileName = "electric-shock.json";
        private readonly string _configurationDirectory = @"C:\computer\config";
    }
}