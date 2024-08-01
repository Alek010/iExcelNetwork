using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace iExcelNetwork.Exceptions
{
    public class TooManyCircularEdgesException : Exception
    {
        public TooManyCircularEdgesException()
        {
        }

        public TooManyCircularEdgesException(string message) : base(message)
        {
        }

        public TooManyCircularEdgesException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
