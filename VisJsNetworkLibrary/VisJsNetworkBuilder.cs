﻿// Ignore Spelling: Json

using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using VisJsNetworkLibrary.NetworkProperty;

namespace VisJsNetworkLibrary
{
    public class VisJsNetworkBuilder
    {
        private string _nodesJson { get; set; }
        private string _edgesJson { get; set; }
        private NetworkProperties _networkProperties { get; set; }

        private string HtmlContent { get; set; }
        private string FilePath { get; set; }

        public VisJsNetworkBuilder(NetworkProperties networkProperties, NetworkData visJsNetworkData)
        {
            _nodesJson = JsonConvert.SerializeObject(visJsNetworkData.GetNodes(), Formatting.Indented);
            _edgesJson = JsonConvert.SerializeObject(visJsNetworkData.GetEdges(), Formatting.Indented);
            _networkProperties = networkProperties;
        }

        public void ShowNetwork()
        {
            CreateHtmlContent();
            CreateNetworkFilePath();
            WriteHtmlContentToFile();
            OpenHtmlFile();
        }

        private void CreateHtmlContent()
        {
            string VisJsScript = GetEmbeddedResource("VisJsNetworkLibrary.Resources.vis-network.min.js");

            string htmlTemplate = GetEmbeddedResource("VisJsNetworkLibrary.Resources.VisJsNetworkTemplate.html");

            HtmlContent = htmlTemplate
                .Replace("{{VisJsScript}}", VisJsScript)
                .Replace("{{nodesJson}}", _nodesJson)
                .Replace("{{edgesJson}}", _edgesJson)
                .Replace("selectedEdgesDirection", _networkProperties.EdgeProperty.SelectedDirection);
        }

        private void CreateNetworkFilePath()
        {
            FilePath = Path.Combine(_networkProperties.OutputFolder, _networkProperties.OutputFileName) + ".html";
        }

        private void WriteHtmlContentToFile()
        {
            File.WriteAllText(FilePath, HtmlContent);
        }

        private void OpenHtmlFile()
        {
            Process.Start(FilePath);
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
