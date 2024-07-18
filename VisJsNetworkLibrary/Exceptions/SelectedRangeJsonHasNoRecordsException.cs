// Ignore Spelling: Json
using System;

namespace VisJsNetworkLibrary.Exceptions
{
    public class SelectedRangeJsonHasNoRecordsException : Exception
    {
        public SelectedRangeJsonHasNoRecordsException()
        {
        }

        public SelectedRangeJsonHasNoRecordsException(string message) : base(message)
        {
        }

        public SelectedRangeJsonHasNoRecordsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
