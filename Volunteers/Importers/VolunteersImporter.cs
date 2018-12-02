using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Volunteers.DataModels;
using Volunteers.DataReaders;

namespace Volunteers.Importers
{
    class VolunteersImporter : IVolunteersImporter
    {
        private readonly string _volunteersFilePath;
        private const string _volunteersFileName = "RegisteredStudents.csv";

        public VolunteersImporter(string importFolder)
        {
            _volunteersFilePath = Path.Combine(importFolder,_volunteersFileName);
        }

        public List<VolunteerData> GetVolunteers()
        {
            var resultList = new List<VolunteerData>();
            var dataReader = new CsvDataReader();
            var csvResult = dataReader.ReadData(_volunteersFilePath);
            var columnNames = csvResult.ColumnNames;
            var indexOfId = columnNames.ToList().IndexOf("Id");
            var indexOfName = columnNames.ToList().IndexOf("Name");
            var indexOfSurname= columnNames.ToList().IndexOf("Surname");
            var indexOfStartDate = columnNames.ToList().IndexOf("RegDate");
            var indexOfClass = columnNames.ToList().IndexOf("Group");
            foreach (var row in csvResult.Rows)
            {
                var volunteer = new VolunteerData()
                {
                    Id = row[indexOfId],
                    Name = row[indexOfName],
                    Surname = row[indexOfSurname],
                    StartDate = DateTime.Parse(row[indexOfStartDate]),
                    ClassName = row[indexOfClass]
                };
                resultList.Add(volunteer);
            }
            return resultList;
        }
    }
}
