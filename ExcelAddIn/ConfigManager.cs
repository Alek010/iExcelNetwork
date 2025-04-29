using System.Configuration;
using System.IO;
using System.Reflection;

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

            return value == "default" ? "VisjsNetwork" : value;
        }

        public static void SaveNetworkFileName(string fileName)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection settings = config.AppSettings.Settings;

            if (settings["NetworkFileName"] == null)
            {
                settings.Add("NetworkFileName", fileName);
            }
            else
            {
                settings["NetworkFileName"].Value = fileName;
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string GetAddInVersion()
        {
            return ConfigurationManager.AppSettings["AddInVersion"];
        }
    }
}
