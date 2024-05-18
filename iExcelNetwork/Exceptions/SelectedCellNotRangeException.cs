using System;

namespace iExcelNetwork.Exceptions
{
    public class SelectedCellNotRangeException : Exception
    {
        public SelectedCellNotRangeException()
        {
        }

        public SelectedCellNotRangeException(string message) : base(message)
        {
        }

        public SelectedCellNotRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
