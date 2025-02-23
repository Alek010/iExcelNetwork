// Ignore Spelling: Validator
using ExcelAddIn.Exceptions;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelAddIn.Validations
{
    public class SelectedRangeValidator
    {
        private Excel.Range _selectedRange;

        public SelectedRangeValidator(Excel.Range selectedRange)
        {
            _selectedRange = selectedRange;
        }

        public void ValidateRangeIsNotEmptyCell()
        {
            if (_selectedRange.Value == null)
                throw new SelectedEmptyCellException(SelectedRangeExceptionsMessages.SelectedEmptyCell());
        }

        public void ValidateRangeIsNotCell()
        {
            if (_selectedRange.Value.GetType() != typeof(object[,]))
                throw new SelectedCellNotRangeException(SelectedRangeExceptionsMessages.SelectedCellNotRange());
        }

        public void ValidateSelectedRangeIsNotNull()
        {
            if (_selectedRange == null)
                throw new SelectedRangeIsNullException(SelectedRangeExceptionsMessages.SelectedRangeIsNull());
        }
    }
}
