using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iExcelNetwork.NetworkProperty
{
    public class NetworkProperties
    {
        public string OutputFolder { get; set; } = Path.GetTempPath();
    }
}
