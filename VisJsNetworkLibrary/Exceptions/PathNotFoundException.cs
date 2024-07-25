using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VisJsNetworkLibrary.Exceptions
{
    public class PathNotFoundException : Exception
    {
        public PathNotFoundException()
        {
        }

        public PathNotFoundException(string message) : base(message)
        {
        }

        public PathNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
