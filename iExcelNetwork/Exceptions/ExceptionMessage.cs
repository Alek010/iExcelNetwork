namespace iExcelNetwork.Exceptions
{
    public static class ExceptionMessage
    {
        public static string RangeIsNotSelected()
        {
            return "Range is not selected!";
        }

        public static string SelectedRangeIsNull()
        {
            return "Selected range is NULL!";
        }

        public static string RangeHasNoRecords()
        {
            return "Selected range, has only one row as column names. Please select more than one row.";
        }

        public static string RangeColumnNamesAreNotCorrect()
        {
            return "Column names are not correct. Change ColumnName1 = 'from', ColumnName2 = 'to'. Select Range again!";
        }

        public static string FromToNodesCountNotEqual()
        {
            return "From and To Edges count is not equal.";
        }

        public static string SelectedEmptyCell()
        {
            return "You have selected an empty cell. Select a range of cells!";
        }

        public static string SelectedCellNotRange()
        {
            return "You have selected a cell. Select a range of cells!";
        }
    }
}
