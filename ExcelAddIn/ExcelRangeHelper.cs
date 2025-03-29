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

            // Attempt to get only visible cells.
            Excel.Range visibleRange = null;
            try
            {
                visibleRange = selectedRange.SpecialCells(Excel.XlCellType.xlCellTypeVisible);
            }
            catch (Exception)
            {
                MessageBox.Show("The selected range is empty or has no visible cells.");
                return dt;
            }

            // Get the worksheet from the selectedRange.
            Excel.Worksheet worksheet = selectedRange.Worksheet as Excel.Worksheet;

            // Determine the starting row and column of the selected range.
            int startRow = selectedRange.Row;
            int startColumn = selectedRange.Column;
            int colCount = selectedRange.Columns.Count;

            // Create DataTable columns.
            if (hasHeader)
            {
                for (int col = 1; col <= colCount; col++)
                {
                    Excel.Range headerCell = selectedRange.Cells[1, col] as Excel.Range;
                    string columnName = headerCell?.Value2?.ToString();
                    if (string.IsNullOrWhiteSpace(columnName))
                        columnName = $"Column{col}";
                    else
                        columnName = columnName.ToLower().Trim().Replace(" ", "");
                    dt.Columns.Add(columnName);
                }
            }
            else
            {
                for (int col = 1; col <= colCount; col++)
                {
                    dt.Columns.Add($"Column{col}");
                }
            }

            // Iterate over each area in the visible range (if filtered, the visible cells might be discontinuous).
            foreach (Excel.Range area in visibleRange.Areas)
            {
                // Determine the area rows.
                int areaStartRow = area.Row;
                int areaEndRow = area.Row + area.Rows.Count - 1;

                for (int r = areaStartRow; r <= areaEndRow; r++)
                {
                    // If headers exist and this row is the header row, skip it.
                    if (hasHeader && r == startRow)
                        continue;

                    // Create a new DataRow.
                    DataRow dataRow = dt.NewRow();
                    for (int c = 1; c <= colCount; c++)
                    {
                        // Get the cell in the worksheet corresponding to the column in the selected range.
                        Excel.Range cell = worksheet.Cells[r, startColumn + c - 1] as Excel.Range;
                        dataRow[c - 1] = cell?.Value2 ?? DBNull.Value;
                    }
                    dt.Rows.Add(dataRow);
                }
            }

            return dt;
        }

    }
}
