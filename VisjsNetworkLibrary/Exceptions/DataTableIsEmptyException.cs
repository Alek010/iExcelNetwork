// Ignore Spelling: Visjs

using System;
using System.Runtime.Serialization;


namespace VisjsNetworkLibrary.Exceptions
{
    public class DataTableIsEmptyException : Exception
    {
        public DataTableIsEmptyException()
        {
        }

        public DataTableIsEmptyException(string message) : base(message)
        {
        }

        public DataTableIsEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
