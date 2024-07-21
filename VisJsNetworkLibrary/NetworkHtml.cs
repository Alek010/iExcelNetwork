using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using VisJsNetworkLibrary.Interfaces;
using VisJsNetworkLibrary.NetworkProperty;

namespace VisJsNetworkLibrary
{
    public class NetworkHtml : IFileContent
    {
        private string _nodesJson { get; set; }
        private string _edgesJson { get; set; }
        private NetworkProperties _networkProperties { get; set; }

        public NetworkHtml(NetworkProperties networkProperties, NetworkData NetworkData)
        {
            _nodesJson = JsonConvert.SerializeObject(NetworkData.GetNodes(), Formatting.Indented);
            _edgesJson = JsonConvert.SerializeObject(NetworkData.GetEdges(), Formatting.Indented);
            _networkProperties = networkProperties;
        }

        public string GenerateFileContent()
        {
            string VisJsScript = GetEmbeddedResource("VisJsNetworkLibrary.Resources.vis-network.min.js");

            string htmlTemplate = GetEmbeddedResource("VisJsNetworkLibrary.Resources.VisJsNetworkTemplate.html");

            return htmlTemplate
                .Replace("{{VisJsScript}}", VisJsScript)
                .Replace("{{nodesJson}}", _nodesJson)
                .Replace("{{edgesJson}}", _edgesJson)
                .Replace("selectedEdgesDirection", _networkProperties.EdgeProperty.SelectedDirection);
        }

        public string GetFilePath()
        {
            return Path.Combine(_networkProperties.OutputFolder, _networkProperties.OutputFileName) + ".html";
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
