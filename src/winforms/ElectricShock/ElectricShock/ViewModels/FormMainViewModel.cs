﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using ElectricShock.Models;
using Newtonsoft.Json;

namespace ElectricShock
{
    public class FormMainViewModel
    {
        public BindingList<ApplicationModel> Applications => _applicationModels ?? (_applicationModels = new BindingList<ApplicationModel>());

        public void AddApplication(string applicationName, string applicationPath)
        {
            Applications.Add(new ApplicationModel {Name = applicationName, Path = applicationPath, Start = true});
        }

        public void LoadApplications()
        {
            if (!Directory.Exists(@"C:\config"))
            {
                return;
            }

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

        public void Save()
        {
            if (!Directory.Exists(@"C:\config"))
            {
                Directory.CreateDirectory(@"C:\config");
            }

            if (!File.Exists(_configurationFilePath))
            {
                File.WriteAllText(_configurationFilePath, "[]");
            }

            var jsonObject = JsonConvert.SerializeObject(Applications);

            File.Delete(_configurationFilePath);

            File.WriteAllText(_configurationFilePath, jsonObject);
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