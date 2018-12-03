using System;
using System.Collections.Generic;
using System.Data;
using Volunteers.DataModels;

namespace Volunteers.ViewProviders
{
    class VolunteersViewDataTableProvider
    {      
        public DataTable GetDataTable(List<VolunteerView>volunteers)
        {
            DataTable dataTable = CreateEmptyDataTable();
            foreach (var volunteer in volunteers)
            {
                var row = dataTable.NewRow();
                row[0] = volunteer.Id;
                row[1] = volunteer.FullName;
                row[2] = volunteer.StartDate;
                row[3] = volunteer.ClassName;
                row[4] = volunteer.WorkHours;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
        private DataTable CreateEmptyDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(string));
            dataTable.Columns.Add("Nazwisko i imię", typeof(string));
            dataTable.Columns.Add("Data rejestracji", typeof(DateTime));
            dataTable.Columns.Add("Klasa", typeof(string));
            dataTable.Columns.Add("Godziny semestr", typeof(double));
            return dataTable;
        }
    }
}