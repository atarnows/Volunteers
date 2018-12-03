using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteers.DataModels;
using Volunteers.DataReaders;

namespace Volunteers.Importers
{
    class OrganizationsImporter : IOrganizationImporter
    {
        private readonly string _filePath;
        private const string _fileName = "RegisteredOrganizations.csv";
        public OrganizationsImporter(string importPath)
        {
            _filePath = Path.Combine(importPath, _fileName);
        }
        public List<OrganizationData> GetOrganizations()
        {
            var resultList = new List<OrganizationData>();
            var dataReader = new CsvDataReader();
            var csvResult = dataReader.ReadData(_filePath);
            var columnNames = csvResult.ColumnNames;
            var indexOfId = columnNames.ToList().IndexOf("Id");
            var indexOfName = columnNames.ToList().IndexOf("Name");
            var indexOfAddress = columnNames.ToList().IndexOf("Adress");
            var indexOfEmail = columnNames.ToList().IndexOf("Email");
            var indexOfContactPerson = columnNames.ToList().IndexOf("Contact Person");
            foreach (var row in csvResult.Rows)
            {
                var volunteer = new OrganizationData()
                {
                    Id = row[indexOfId],
                    Name = row[indexOfName],
                    Address = row[indexOfAddress],
                    Email = row[indexOfEmail],
                    ContactPerson = row[indexOfContactPerson]
                };
                resultList.Add(volunteer);
            }
            return resultList;
        }
    }
}
