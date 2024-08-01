using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VisJsNetworkLibrary.Exceptions
{
    internal class NodeIdNotFoundException : Exception
    {
        public NodeIdNotFoundException()
        {
        }

        public NodeIdNotFoundException(string message) : base(message)
        {
        }

        public NodeIdNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
