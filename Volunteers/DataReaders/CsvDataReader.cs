using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Volunteers.DataReaders
{
    public class CsvDataReader
    {
        internal CSVResult ReadData(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var columnNames = lines[0].Split(';');
            var rows = new List<string[]>();

            for (int i = 1; i < lines.Length; i++)
            {
                var row = lines[i].Split(';');
                rows.Add(row);
            }
            var result = new CSVResult();
            result.ColumnNames = columnNames.ToList();
            result.Rows = rows;
            return result;
        }
    }
    public class CSVResult
    {
        public List<string> ColumnNames { get; set; }
        public List<string[]> Rows { get; set; }
    }

}
