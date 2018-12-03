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

            //Load grid views
            LoadVolunteersTab(VolunteerDataToViewConverter.Convert(volunteers));
            LoadClassTab();
            LoadOrganizationsTab(organizations);
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

        private void LoadClassTab()
        {
            var classProvider = new ClassViewDataTableProvider();
            this.dataGridView2.DataSource = classProvider.GetDataTable();
        }

        private void LoadOrganizationsTab(List<OrganizationData> organizations)
        {
            var organizationsProvider = new OrganizationsViewDataTableProvider();
            this.dataGridView3.DataSource = organizationsProvider.GetDataTable(organizations);
        }
        #endregion
    }
}
