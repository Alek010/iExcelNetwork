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

        public static void SaveOutputFolderPath(string folderPath)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection settings = config.AppSettings.Settings;

            string pathToSave = "default";

            if (!string.IsNullOrWhiteSpace(folderPath) && Directory.Exists(folderPath))
            {
                pathToSave = folderPath;
            }

            if (settings["OutputFolderPath"] == null)
            {
                settings.Add("OutputFolderPath", pathToSave);
            }
            else
            {
                settings["OutputFolderPath"].Value = pathToSave;
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string GetNetworkFileName()
        {
            string value = ConfigurationManager.AppSettings["NetworkFileName"];

            return value == "default" ? "VisjsNetwork.html" : value;
        }
    }
}
