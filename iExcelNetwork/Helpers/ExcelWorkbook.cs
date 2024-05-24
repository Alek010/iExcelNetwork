using Excel = Microsoft.Office.Interop.Excel;

namespace iExcelNetwork.Helpers
{
    public static class ExcelWorkbook
    {
        public static bool SheetNameExists(Excel.Workbook workBook, string sheetName)
        {
            foreach (Excel.Worksheet sheet in workBook.Worksheets)
            {
                if (sheet.Name.Equals(sheetName))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
