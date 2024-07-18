// Ignore Spelling: Validator Json

using iExcelNetwork.Exceptions;
using Newtonsoft.Json.Linq;
using System.Linq;
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

        public static void ValidateSelectedRangeIsNotNull(string selectedRangeAsJson)
        {
            if (selectedRangeAsJson == null)
                throw new SelectedRangeIsNullException(ExceptionMessage.SelectedRangeIsNull());
        }

        public static void JsonStringHasData(string jsonString)
        {
            if (!HasRecords(jsonString))
                throw new SelectedRangeJsonHasNoRecordsException(ExceptionMessage.RangeHasNoRecords());
        }

        private static bool HasRecords(string jsonString)
        {
            return JArray.Parse(jsonString)
                         .OfType<JObject>()
                         .ToList()
                         .Count > 0;
        }
    }
}
