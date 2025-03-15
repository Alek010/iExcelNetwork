using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelAddIn
{
    public static class DataTableToExcelHelper
    {
        public static void PasteDataTableToExcel(DataTable dt)
        {
            // Get the current Excel application and active worksheet.
            Excel.Application excelApp = Globals.ThisAddIn.Application;
            Excel.Workbook workbook = excelApp.ActiveWorkbook;
            Excel.Worksheet worksheet = workbook.ActiveSheet as Excel.Worksheet;

            // Set the starting cell (e.g., A1) where you want to paste the data.
            Excel.Range startCell = PromptForCell(excelApp);
            if (startCell == null)
            {
                // Stop further processing if no cell was selected.
                return;
            }

            // Determine dimensions for the array (include header row).
            int rowCount = dt.Rows.Count;
            int colCount = dt.Columns.Count;
            object[,] data = new object[rowCount + 1, colCount];

            // Add DataTable column headers to the first row.
            for (int col = 0; col < colCount; col++)
            {
                data[0, col] = dt.Columns[col].ColumnName;
            }

            // Add DataTable rows.
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    data[row + 1, col] = dt.Rows[row][col];
                }
            }

            // Define the range to fill with the DataTable data.
            Excel.Range endCell = worksheet.Cells[startCell.Row + rowCount, startCell.Column + colCount - 1] as Excel.Range;
            Excel.Range writeRange = worksheet.Range[startCell, endCell];

            // Write the array to the worksheet.
            writeRange.Value2 = data;

            // Convert the written range into an Excel Table (ListObject).
            Excel.ListObject excelTable = worksheet.ListObjects.Add(
                SourceType: XlListObjectSourceType.xlSrcRange,
                Source: writeRange,
                XlListObjectHasHeaders: XlYesNoGuess.xlYes);
        }

        private static Excel.Range PromptForCell(Excel.Application excelApp)
        {
            // Display the InputBox for cell selection (Type: 8 forces a Range selection).
            Excel.Range selectedCell = excelApp.InputBox(
                "Select the cell where you want to paste the DataTable:",
                "Select Paste Location",
                Default: excelApp.Selection.Address,
                Type: 8) as Excel.Range;
            return selectedCell;
        }
    }
}
