using System;
namespace GraphVisualizationLibrary.Exceptions
{
    public class ListOfIntegersAsStringsContainsNonIntegerValuesException : Exception
    {
        public ListOfIntegersAsStringsContainsNonIntegerValuesException()
        {
        }

        public ListOfIntegersAsStringsContainsNonIntegerValuesException(string message) : base(message)
        {
        }

        public ListOfIntegersAsStringsContainsNonIntegerValuesException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
