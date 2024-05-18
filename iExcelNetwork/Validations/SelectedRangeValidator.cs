// Ignore Spelling: Validator

using iExcelNetwork.Exceptions;
using Excel = Microsoft.Office.Interop.Excel;

namespace iExcelNetwork.Validations
{
    public static class SelectedRangeValidator
    {
        public static void ValidateRangeIsNotEmptyCell(Excel.Range selectedRange)
        {
            if (selectedRange.Value == null)
                throw new SelectedEmptyCellException(ExceptionMessage.SelectedEmptyCell());
        }

        public static void ValidateRangeIsNotCell(Excel.Range selectedRange)
        {
            if (selectedRange.Value.GetType() != typeof(object[,]))
                throw new SelectedCellNotRangeException(ExceptionMessage.SelectedCellNotRange());
        }

        public static void ValidateSelectedRangeIsNotNull(Excel.Range selectedRange)
        {
            if (selectedRange == null)
                throw new SelectedRangeIsNullException(ExceptionMessage.SelectedRangeIsNull());
 
        }
    }
}
