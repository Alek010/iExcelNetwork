using System.Configuration;
using System.IO;

namespace ExcelAddIn
{
    public static class ConfigManager
    {
        public static string GetOutputFolderPath()
        {
            string value = ConfigurationManager.AppSettings["OutputFolderPath"];

            return value == "default" ? Path.GetTempPath() : value;
        }

        public static string GetNetworkFileName()
        {
            string value = ConfigurationManager.AppSettings["NetworkFileName"];

            return value == "default" ? "VisjsNetwork.html" : value;
        }
    }
}
