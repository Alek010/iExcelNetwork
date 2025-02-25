namespace ExcelAddIn.Exceptions
{
    public static class SelectedRangeExceptionsMessages
    {
        public static string SelectedRangeIsNull()
        {
            return "Selected range is NULL!";
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
