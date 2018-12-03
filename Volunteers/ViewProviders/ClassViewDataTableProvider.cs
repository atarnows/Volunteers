using System;
using System.Collections.Generic;
using System.Data;
using Volunteers.DataModels;

namespace Volunteers.ViewProviders
{
    class ClassViewDataTableProvider
    {
        public DataTable GetDataTable(List<ClassView> classViewList)
        {
            DataTable dataTable = CreateEmptyDataTable();
            foreach (var el in classViewList )
            {
                var row = dataTable.NewRow();
                row[0] = el.Name;
                row[1] = el.WorkingHours;
                dataTable.Rows.Add(row);
            }
            return dataTable;
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
