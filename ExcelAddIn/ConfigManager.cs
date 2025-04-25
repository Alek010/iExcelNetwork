using System.Configuration;
using System.IO;

namespace ExcelAddIn
{
    public static class ConfigManager
    {
        public static string GetOutputFolderPath()
        {
            string value = ConfigurationManager.AppSettings["OutputFolderPath"];

            return value == "null" ? Path.GetTempPath() : value;
        }
    }
}
