using System;
using System.Collections.Generic;
using System.Globalization;
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
        private const string _fileName = "HoursReport.csv";

        public VolunteersWorkingHoursCsvImporter(string folder)
        {
            _filePath = Path.Combine(folder, _fileName);
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
            var ci = new CultureInfo("pl-PL");
            foreach (var row in csvResult.Rows)
            {
                var volunteer = new VolunteerWorkingHoursData()
                {
                    Id = row[indexOfId],
                    DateFrom = DateTime.Parse(row[indexOfDateFrom],ci),
                    DateTo = DateTime.Parse(row[indexOfDateTo],ci)
                };
                resultList.Add(volunteer);
            }
            return resultList;
        }
    }
}
