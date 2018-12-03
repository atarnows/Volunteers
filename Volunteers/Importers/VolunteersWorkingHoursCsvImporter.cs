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
    class VolunteersWorkingHoursCsvImporter:IVolunteersWorkingHoursImporter
    {
        private readonly string _filePath;

        public VolunteersWorkingHoursCsvImporter(string filePath)
        {
            _filePath = filePath;
        }

        public List<VolunteerWorkingHoursData> GetVolunteersWorkingHours()
        {
            var resultList = new List<VolunteerWorkingHoursData>();
            var dataReader = new CsvDataReader();
            var csvResult = dataReader.ReadData(_filePath);
            var columnNames = csvResult.ColumnNames;
            var indexOfId = columnNames.ToList().IndexOf("Id");
            var indexOfDateFrom = columnNames.ToList().IndexOf("From");
            var indexOfDateTo = columnNames.ToList().IndexOf("To");
            
            foreach (var row in csvResult.Rows)
            {
                var volunteer = new VolunteerWorkingHoursData()
                {
                    Id = row[indexOfId],
                    
                    DateFrom = DateTime.Parse(row[indexOfDateFrom]),
                    DateTo = DateTime.Parse(row[indexOfDateTo])
                };
                resultList.Add(volunteer);
            }
            return resultList;
        }
    }
}
