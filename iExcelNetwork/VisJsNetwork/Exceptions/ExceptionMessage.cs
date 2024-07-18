namespace iExcelNetwork.VisJsNetwork.Exceptions
{
    public static class ExceptionMessage
    {
        public static string RangeIsNotSelected()
        {
            return "Range is not selected!";
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

        public static string NotAllValuesAreIntegersInCountColumn()
        {
            return "Selected Count column has non integers values! All values should to be whole numbers.";
        }
    }
}
