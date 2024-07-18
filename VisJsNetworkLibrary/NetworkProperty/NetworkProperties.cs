using System.IO;

namespace VisJsNetworkLibrary.NetworkProperty
{
    public class NetworkProperties
    {
        public string OutputFolder { get; set; } = Path.GetTempPath();

        public string OutputFileName { get; set; } = "iExcelNetwork";

        public EdgeProperty EdgeProperty;

        public NetworkProperties(EdgeProperty edgeProperty)
        {
            EdgeProperty = edgeProperty;
        }
    }
}
