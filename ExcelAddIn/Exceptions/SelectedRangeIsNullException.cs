using System;

namespace ExcelAddIn.Exceptions
{
    class SelectedRangeIsNullException : Exception
    {
        public SelectedRangeIsNullException()
        {
        }

        public SelectedRangeIsNullException(string message) : base(message)
        {
        }

        public SelectedRangeIsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
