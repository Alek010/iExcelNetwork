// Ignore Spelling: Json
using System;

namespace iExcelNetwork.Exceptions
{
    public class SelectedRangeJsonIsNullException : Exception
    {
        public SelectedRangeJsonIsNullException()
        {
        }

        public SelectedRangeJsonIsNullException(string message) : base(message)
        {
        }

        public SelectedRangeJsonIsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
