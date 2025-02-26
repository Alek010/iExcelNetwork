using System.Data;
using System.Windows.Forms;
using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelAddIn
{
    public static class ExcelRangeHelper
    {
        /// <summary>
        /// Converts an Excel.Range into a DataTable.
        /// Assumes the first row contains headers if hasHeader is true.
        /// </summary>
        /// <param name="selectedRange">The Excel range selected by the user.</param>
        /// <param name="hasHeader">Set to true if the first row is headers.</param>
        /// <returns>A DataTable populated with data from the selected range.</returns>
        public static DataTable GetDataTableFromRange(Excel.Range selectedRange, bool hasHeader = true)
        {
            DataTable dt = new DataTable();

            // If a single cell is selected, handle it separately.
            if (selectedRange.Cells.Count == 1)
            {
                if (hasHeader)
                {
                    dt.Columns.Add(selectedRange.Value2?.ToString() ?? "Column1");
                }
                else
                {
                    dt.Columns.Add("Column1");
                    DataRow row = dt.NewRow();
                    row[0] = selectedRange.Value2;
                    dt.Rows.Add(row);
                }
                return dt;
            }

            // Get all values from the range into a 2D array.
            object[,] values = selectedRange.Value2 as object[,];
            if (values == null)
            {
                MessageBox.Show("The selected range is empty.");
                return dt;
            }

            int rowCount = values.GetLength(0);
            int colCount = values.GetLength(1);
            int dataStartRow = hasHeader ? 2 : 1;

            // Create DataTable columns.
            for (int col = 1; col <= colCount; col++)
            {
                string columnName;
                if (hasHeader)
                {
                    columnName = values[1, col] != null ? values[1, col].ToString().ToLower().Trim() : $"Column{col}";
                }
                else
                {
                    columnName = $"Column{col}";
                }
                dt.Columns.Add(columnName);
            }

            // Populate DataTable rows.
            for (int row = dataStartRow; row <= rowCount; row++)
            {
                DataRow dataRow = dt.NewRow();
                for (int col = 1; col <= colCount; col++)
                {
                    dataRow[col - 1] = values[row, col] ?? DBNull.Value;
                }
                dt.Rows.Add(dataRow);
            }

            return dt;
        }
    }
}
