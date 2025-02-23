// Ignore Spelling: Visjs

using System;
using System.Runtime.Serialization;

namespace VisjsNetworkLibrary.Exceptions
{
    public class DataTableColumnsCountException : Exception
    {
        public DataTableColumnsCountException()
        {
        }

        public DataTableColumnsCountException(string message) : base(message)
        {
        }

        public DataTableColumnsCountException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
