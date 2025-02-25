// Ignore Spelling: Visjs

using System;
using System.Runtime.Serialization;

namespace VisjsNetworkLibrary.Exceptions
{
    public class DataTableNullException : Exception
    {
        public DataTableNullException()
        {
        }

        public DataTableNullException(string message) : base(message)
        {
        }

        public DataTableNullException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
