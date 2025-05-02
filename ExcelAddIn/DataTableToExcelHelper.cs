using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelAddIn
{
    public static class DataTableToExcelHelper
    {
        public static void PasteDataTableToExcel(DataTable dt,string cellReference = null, Dictionary<string, string> columnValidationLists = null, bool pasteIntoNewSheet = false, string tableStyleName = "TableStyleMedium2")
        {
            // Get the current Excel application and active worksheet.
            Excel.Application excelApp = Globals.ThisAddIn.Application;
            Excel.Workbook workbook = excelApp.ActiveWorkbook;

            // Create or use the worksheet based on pasteIntoNewSheet flag.
            Excel.Worksheet worksheet;
            if (pasteIntoNewSheet)
            {
                const string sheetName = "SampleData";
                if (WorksheetExists(workbook, sheetName))
                {
                    worksheet = workbook.Worksheets[sheetName];
                }
                else
                {
                    // Create a new worksheet.
                    worksheet = workbook.Worksheets.Add();
                    // Optionally, give the new sheet a unique name.
                    worksheet.Name = sheetName;
                }
            }
            else
            {
                worksheet = workbook.ActiveSheet as Excel.Worksheet;
            }

            // If the starting cell is not provided, prompt the user for a cell.
            Excel.Range startCell = GetExcelRange(cellReference, excelApp, worksheet);

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

            // Apply style
            excelTable.TableStyle = tableStyleName;

            // Apply data validation lists for specified columns.
            if (columnValidationLists != null)
            {
                for (int col = 0; col < colCount; col++)
                {
                    string columnName = dt.Columns[col].ColumnName;
                    if (columnValidationLists.ContainsKey(columnName))
                    {
                        string allowedList = columnValidationLists[columnName];
                        // Calculate the Excel column index for the current DataTable column.
                        int excelColumn = startCell.Column + col;
                        AddDataValidationList(worksheet, startCell, rowCount, excelColumn, allowedList);
                    }
                }
            }
        }

        private static Excel.Range GetExcelRange(string cellReference, Application excelApp, Worksheet worksheet)
        {
            if (cellReference == null)
            {
                return PromptForCell(excelApp);
            }
            else
            {
                return worksheet.Range[cellReference];
            }
        }

        public static bool WorksheetExists(Excel.Workbook workbook, string sheetName)
        {
            if (workbook == null)
                throw new ArgumentNullException(nameof(workbook));
            if (string.IsNullOrWhiteSpace(sheetName))
                throw new ArgumentException("Sheet name cannot be null or empty.", nameof(sheetName));

            foreach (Excel.Worksheet sheet in workbook.Worksheets)
            {
                if (string.Equals(sheet.Name, sheetName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
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

        /// <summary>
        /// Adds a data validation list to a specified column range.
        /// </summary>
        /// <param name="worksheet">The worksheet where the validation is added.</param>
        /// <param name="startCell">The starting cell of the pasted DataTable.</param>
        /// <param name="rowCount">The number of data rows (excluding the header).</param>
        /// <param name="columnIndex">The Excel column index to apply the validation to.</param>
        /// <param name="allowedList">A comma-separated string of allowed values.</param>
        private static void AddDataValidationList(Excel.Worksheet worksheet, Excel.Range startCell, int rowCount, int columnIndex, string allowedList)
        {
            // Remove any existing quotes to avoid duplicating them.
            allowedList = allowedList.Trim('\"');

            // Excel expects the validation formula to look like: ="Active,Inactive,Pending"
            string formula = "=" + "\"" + allowedList + "\"";

            // Determine the range for the data cells in the column (excluding the header).
            int dataStartRow = startCell.Row + 1;
            int dataEndRow = startCell.Row + rowCount;
            Excel.Range validationRange = worksheet.Range[
                worksheet.Cells[dataStartRow, columnIndex],
                worksheet.Cells[dataEndRow, columnIndex]
            ];

            // Remove any existing validation before adding new validation.
            validationRange.Validation.Delete();
            validationRange.Validation.Add(
                Excel.XlDVType.xlValidateList,
                Excel.XlDVAlertStyle.xlValidAlertStop,
                Excel.XlFormatConditionOperator.xlBetween,
                allowedList,
                Type.Missing);

            validationRange.Validation.ShowError = false;
        }
    }
}
