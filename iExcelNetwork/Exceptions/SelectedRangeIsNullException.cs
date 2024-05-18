// Ignore Spelling: Json
using System;

namespace iExcelNetwork.Exceptions
{
    public class SelectedRangeIsNullException : Exception
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
