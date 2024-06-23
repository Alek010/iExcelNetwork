using System.IO;

namespace iExcelNetwork.NetworkProperty
{
    public class NetworkProperties
    {
        public string OutputFolder { get; set; } = Path.GetTempPath();

        public string OutputFileName { get; set; } = "visjs_network.html";

        public EdgeProperty EdgeProperty;

        public NetworkProperties(EdgeProperty edgeProperty)
        {
            EdgeProperty = edgeProperty;
        }
    }
}
