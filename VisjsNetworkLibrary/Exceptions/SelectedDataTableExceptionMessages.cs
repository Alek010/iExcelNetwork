// Ignore Spelling: Visjs

namespace VisjsNetworkLibrary.Exceptions
{
    public static class SelectedDataTableExceptionMessages
    {
        public static string SelectedDataTableIsNull()
        {
            return "Something went wrong. Selected table has null value.";
        }

        public static string SelectedDataTableHasNoRecords()
        {
            return "Selected data table has no records.";
        }

        public static string SelectedDataTableHasLessThanTwoColumns()
        {
            return "Selected data table has less than two columns.";
        }

        public static string NotMatchPattern()
        {
            return "Selected table column structure not match any pattern.";
        }

        public static string NotAllCountColumnValuesAreIntegers()
        {
            return "Not all count column values are integers.";
        }
    }
}
