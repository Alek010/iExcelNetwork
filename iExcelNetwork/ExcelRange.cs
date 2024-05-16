// Ignore Spelling: Json

using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace iExcelNetwork
{
    public static class ExcelRange
    {
        public static string ConvertToJson(Excel.Range range)
        {
            if (range == null)
                throw new ArgumentNullException(nameof(range));

            object[,] values = (object[,])range.Value;

            // Determine the number of rows and columns
            int rowCount = values.GetLength(0);
            int colCount = values.GetLength(1);

            // Get column names from the first row of the range
            string[] columnNames = new string[colCount];
            for (int col = 1; col <= colCount; col++)
            {
                columnNames[col - 1] = values[1, col]?.ToString().Trim() ?? $"Column{col}";
            }

            // Create a DataTable and populate it with data from Excel range
            DataTable dataTable = new DataTable();
            for (int col = 1; col <= colCount; col++)
            {
                DataColumn column = new DataColumn(columnNames[col - 1]);
                dataTable.Columns.Add(column);
            }

            // Populate DataTable with data from Excel range, starting from the second row
            for (int row = 2; row <= rowCount; row++)
            {
                DataRow dataRow = dataTable.NewRow();
                for (int col = 1; col <= colCount; col++)
                {
                    dataRow[col - 1] = values[row, col];
                }
                dataTable.Rows.Add(dataRow);
            }

            string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);

            return json;
        }

        public static void SaveAsJson(string json, string filePath)
        {
            // Check if JSON string is provided
            if (string.IsNullOrEmpty(json))
                throw new ArgumentException("JSON string cannot be null or empty.", nameof(json));

            // Check if file path is provided
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

            // Save JSON string to file
            File.WriteAllText(filePath, json);
        }
    }
}
