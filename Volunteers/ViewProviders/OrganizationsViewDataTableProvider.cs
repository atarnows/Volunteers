using System;
using System.Data;

namespace Volunteers.ViewProviders
{
    class OrganizationsViewDataTableProvider
    {
        public DataTable GetDataTable()
        {
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
