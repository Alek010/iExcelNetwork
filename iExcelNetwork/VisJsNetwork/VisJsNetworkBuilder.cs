// Ignore Spelling: Json

using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace iExcelNetwork.VisJsNetwork
{
    public class VisJsNetworkBuilder
    {
        private string _nodesJson { get; set; }
        private string _edgesJson { get; set; }

        private string HtmlContent { get; set; }
        private string TempFilePath { get; set; }

        public VisJsNetworkBuilder(string nodesJson, string edgesJson)
        {
            _nodesJson = nodesJson;
            _edgesJson = edgesJson;
        }

        public void ShowNetwork()
        {
            CreateHtmlContent();
            CreateTempFilePath();
            WriteHtmlContentToFile();
            OpenHtmlFile();
        }

        private void CreateHtmlContent()
        {
            string VisJsScript = GetEmbeddedResource("iExcelNetwork.Resources.vis-network.min.js");

            string htmlTemplate = GetEmbeddedResource("iExcelNetwork.Resources.VisJsNetworkTemplate.html");

            HtmlContent = htmlTemplate
                .Replace("{{VisJsScript}}", VisJsScript)
                .Replace("{{nodesJson}}", _nodesJson)
                .Replace("{{edgesJson}}", _edgesJson);
        }

        private void CreateTempFilePath()
        {
            TempFilePath = Path.Combine(Path.GetTempPath(), "visjs_network.html");
        }

        private void WriteHtmlContentToFile()
        {
            File.WriteAllText(TempFilePath, HtmlContent);
        }

        private void OpenHtmlFile()
        {
            // Open the temporary HTML file in the default web browser
            Process.Start(TempFilePath);
        }

        private string GetEmbeddedResource(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }


    }
}
