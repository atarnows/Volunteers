using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using Volunteers.Converter;
using Volunteers.DataModels;
using Volunteers.Importers;
using Volunteers.ViewProviders;

namespace Volunteers
{
    public partial class Form1 : Form
    {       
        public Form1()
        {
            InitializeComponent();
            
            //Settings
            var appSettings = new AppSettingsReader();
            var importDir = (string)appSettings.GetValue("pathToImportDir", typeof(string));

            //Get data from files
            var volunteers = GetVolunteers(importDir);
            var organizations = GetOrganisations(importDir);
            var volunteersHours = GetVolunteersWorkingHours(importDir);            // Views
            var volunteersView = VolunteerDataToViewConverter.Convert(volunteers,volunteersHours);
            var classView = VolunteerToClassConventer.Convert(volunteersView);
            //Load grid views
            LoadVolunteersTab(volunteersView);
            LoadClassTab(classView);
            LoadOrganizationsTab(organizations);
        }
        private List<VolunteerWorkingHoursData> GetVolunteersWorkingHours(string importDir)
        {
            var dirsList = Directory.GetDirectories(importDir);
            var currentDate = DateTime.Now;
            var fullList = new List<VolunteerWorkingHoursData>();
            foreach (var dir in dirsList)
            {
                
                if (dir.Contains($"{currentDate.Year}-{currentDate.AddMonths(-1).Month}")
                    || dir.Contains($"{currentDate.Year}-{currentDate.AddMonths(-2).Month}")
                    || dir.Contains($"{currentDate.Year}-{currentDate.AddMonths(-3).Month}"))
                {
                    IVolunteersWorkingHoursImporter imp = new VolunteersWorkingHoursCsvImporter(Path.Combine(dir,"HoursReport.csv"));
                    var list = imp.GetVolunteersWorkingHours();
                    fullList.AddRange(list);
                }
            }
            return fullList;
        }
        #region Methods for loading data
        private List<VolunteerData> GetVolunteers(string importDir)
        {
            IVolunteersImporter volunteersImporter = new VolunteersImporter(importDir);
            List<VolunteerData> volunteers = volunteersImporter.GetVolunteers();
            return volunteers;
        }
        private List<OrganizationData> GetOrganisations(string importDir)
        {
            IOrganizationImporter importer = new OrganizationsImporter(importDir);
            List<OrganizationData> organizations = importer.GetOrganizations();
            return organizations;
        }
        #endregion

        #region Methods for loading grid view
        private void LoadVolunteersTab(List<VolunteerView> volunteers)
        {
            var volunteersProvider = new VolunteersViewDataTableProvider();
            this.dataGridView1.DataSource = volunteersProvider.GetDataTable(volunteers);
        }

        private void LoadClassTab(List<ClassView> classView)
        {
            var classProvider = new ClassViewDataTableProvider();
            this.dataGridView2.DataSource = classProvider.GetDataTable(classView);
        }

        private void LoadOrganizationsTab(List<OrganizationData> organizations)
        {
            var organizationsProvider = new OrganizationsViewDataTableProvider();
            this.dataGridView3.DataSource = organizationsProvider.GetDataTable(organizations);
        }
        #endregion
    }
}
