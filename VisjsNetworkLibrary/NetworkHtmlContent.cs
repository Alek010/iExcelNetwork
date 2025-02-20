// Ignore Spelling: Visjs

using VisjsNetworkLibrary.Interfaces;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace VisjsNetworkLibrary
{
    public class NetworkHtmlContent : IFileContent
    {
        private string _nodesJson { get; set; }
        private string _edgesJson { get; set; }

        public NetworkHtmlContent(NetworkData networkData)
        {
            _nodesJson = JsonConvert.SerializeObject(networkData.GetNodes(), Formatting.Indented);
            _edgesJson = JsonConvert.SerializeObject(networkData.GetEdges(), Formatting.Indented);
        }

        public string GenerateFileContent()
        {
            string VisJsScript = GetEmbeddedResource("VisjsNetworkLibrary.Resources.vis-network.min.js");

            string htmlTemplate = GetEmbeddedResource("VisjsNetworkLibrary.Resources.VisJsNetworkTemplate.html");

            return htmlTemplate
                .Replace("{{VisJsScript}}", VisJsScript)
                .Replace("{{nodesJson}}", _nodesJson)
                .Replace("{{edgesJson}}", _edgesJson)
                .Replace("selectedEdgesDirection", "to");
        }

        public string GetFilePath()
        {
            return Path.Combine(Path.GetTempPath(), "VisjsNetwork") + ".html";
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
