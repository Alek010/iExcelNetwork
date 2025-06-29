// Ignore Spelling: App

using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelAddIn
{
    public class DataTableToExcel
    {
        private const string sheetName = "SampleData";

        private readonly Excel.Application _excelApp;
        private bool _pasteIntoNewSheet;
        private Excel.Workbook _workbook { get; set; }
        private Excel.Worksheet _worksheet { get; set; }


        public DataTableToExcel(Excel.Application excelApp, bool pasteIntoNewSheet = false)
        {
            _excelApp = excelApp ?? throw new ArgumentNullException(nameof(excelApp));
            _pasteIntoNewSheet = pasteIntoNewSheet;
        }

        public void PasteAsExcelTable(DataTable dataTable, string cellReference = null, Dictionary<string, string> columnValidationLists = null, string tableStyleName = "TableStyleMedium2")
        {
            _workbook = _excelApp.ActiveWorkbook;
            _worksheet = SetActiveExcelWorksheet();

            DataTableDimensions dtDimensions = new DataTableDimensions(dataTable);
            var dimensions = dtDimensions.GetDataTableDimensions();

            Excel.Range startCell = GetSelectedExcelRangeStartCell(cellReference);

            Range writeRange = WriteDataToExcelRange(startCell, dimensions);

            ListObject excelTable = ConvertExcelRangeToExcelTable(writeRange);

            ApplyStyleToExcelTable(tableStyleName, excelTable);

            ApplyDataValidationListsToExcelTable(dataTable, columnValidationLists, dimensions.rowCount + 1, dimensions.columnCount, startCell);
        }

        private Excel.Worksheet SetActiveExcelWorksheet()
        {
            if (_pasteIntoNewSheet)
            {
                if (WorksheetExists(_workbook, sheetName))
                {
                    return _workbook.Worksheets[sheetName];
                }
                else
                {
                    var newWorksheet = _workbook.Worksheets.Add();
                    newWorksheet.Name = sheetName;
                    return newWorksheet;
                }
            }
            else
            {
                return _workbook.ActiveSheet as Excel.Worksheet;
            }
        }

        private void ApplyDataValidationListsToExcelTable(DataTable dt, Dictionary<string, string> columnValidationLists, int rowCount, int colCount, Range startCell)
        {
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
                        AddDataValidationList(_worksheet, startCell, rowCount, excelColumn, allowedList);
                    }
                }
            }
        }

        private void ApplyStyleToExcelTable(string tableStyleName, ListObject excelTable)
        {
            excelTable.TableStyle = tableStyleName;
        }

        private ListObject ConvertExcelRangeToExcelTable(Range writeRange)
        {
            // Convert the written range into an Excel Table (ListObject).
            return _worksheet.ListObjects.Add(
                SourceType: XlListObjectSourceType.xlSrcRange,
                Source: writeRange,
                XlListObjectHasHeaders: XlYesNoGuess.xlYes);
        }

        private Range WriteDataToExcelRange(Range startCell, Dimensions dimensions)
        {
            ValidateStartCellIsNotNull(startCell);

            // Define the range to fill with the DataTable data.
            Excel.Range endCell = _worksheet.Cells[startCell.Row + dimensions.rowCount, startCell.Column + dimensions.columnCount - 1] as Excel.Range;
            Excel.Range writeRange = _worksheet.Range[startCell, endCell];

            // Write the array to the worksheet.
            writeRange.Value2 = dimensions.data;

            return writeRange;
        }

        private static void ValidateStartCellIsNotNull(Range startCell)
        {
            if (startCell == null)
            {
                // Stop further processing if no cell was selected.
                return;
            }
        }

        private Excel.Range GetSelectedExcelRangeStartCell(string cellReference)
        {
            if (cellReference == null)
            {
                return PromptForCell(_excelApp);
            }
            else
            {
                return _worksheet.Range[cellReference];
            }
        }

        private static bool WorksheetExists(Excel.Workbook workbook, string sheetName)
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
