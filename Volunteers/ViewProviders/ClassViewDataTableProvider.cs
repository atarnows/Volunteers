using System;
using System.Data;

namespace Volunteers.ViewProviders
{
    class ClassViewDataTableProvider
    {
        public DataTable GetDataTable()
        {
            return CreateEmptyDataTable();
        }
            
        private DataTable CreateEmptyDataTable()
        {
            var currentDate = DateTime.Now;           
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Klasa", typeof(string));
            dataTable.Columns.Add("Godziny semestr",typeof(decimal));
            return dataTable;
        }
    }
}
