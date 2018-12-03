using System;
using System.Data;

namespace Volunteers.ViewProviders
{
    class OrganizationsViewDataTableProvider
    {
        public DataTable GetDataTable(System.Collections.Generic.List<DataModels.OrganizationData> organizations)
        {
            DataTable dataTable = CreateEmptyDataTable();
            foreach (var org in organizations)
            {
                var row = dataTable.NewRow();
                row[0] = org.Id;
                row[1] = org.Name;
                row[2] = org.Address;
                row[3] = org.Email;
                row[4] = org.ContactPerson;
                dataTable.Rows.Add(row);
            }
            return dataTable;
            return CreateEmptyDataTable();
        }

        private DataTable CreateEmptyDataTable()
        {
            var currentDate = DateTime.Now;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(string));
            dataTable.Columns.Add("Nazwa", typeof(string));
            dataTable.Columns.Add("Adres", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Osoba do kontaktu", typeof(string));
            return dataTable;
        }
    }
}
