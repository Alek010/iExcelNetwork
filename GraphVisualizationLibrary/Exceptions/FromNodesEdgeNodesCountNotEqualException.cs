using System;

namespace GraphVisualizationLibrary.Exceptions
{
    public class FromNodesEdgeNodesCountNotEqualException : Exception
    {
        public FromNodesEdgeNodesCountNotEqualException()
        {
        }

        public FromNodesEdgeNodesCountNotEqualException(string message) : base(message)
        {
        }

        public FromNodesEdgeNodesCountNotEqualException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
