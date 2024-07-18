// Ignore Spelling: Json
using System;

namespace iExcelNetwork.VisJsNetwork.Exceptions
{
    public class JsonStringIsNullException : Exception
    {
        public JsonStringIsNullException()
        {
        }

        public JsonStringIsNullException(string message) : base(message)
        {
        }

        public JsonStringIsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
